using System.Text;
using SDVE.Conteo;
using SDVE.Datos;
using SDVE.Login;
using SDVE.Votaciones;

string rutaPadron = Path.Combine(AppContext.BaseDirectory, "Datos", "alumnos.csv");
byte[] padronOriginal = File.ReadAllBytes(rutaPadron);
try
{
    ProbarPadronYSesion();
    ProbarConteoYAgrupacion();
    ProbarDatosSimulados();
    ProbarFiltrosDelReporte();
    ProbarFormatosYErrores();
    ProbarConfirmacionYRecuperacion();
    Console.WriteLine("OK: padrón, filtros 72/54 y 75%, 1/2/3 convocatorias, cancelación, persistencia, propuestas, duplicados por elección y recuperación de archivos.");
}
finally
{
    // Las pruebas modifican únicamente la copia en la salida de este proyecto.
    File.WriteAllBytes(rutaPadron, padronOriginal);
}

void Comprobar(bool condicion, string mensaje)
{
    if (!condicion)
        throw new Exception(mensaje);
}

void ProbarPadronYSesion()
{
    List<Alumno> alumnos = RegistroAlumnos.ObtenerTodos();
    Comprobar(alumnos.Count == 72 && RegistroAlumnos.ContarAlumnos() == 72, "El padrón no tiene 72 alumnos válidos.");
    Comprobar(alumnos.Select(a => a.Id).Distinct().Count() == 72, "Hay IDs repetidos.");
    Comprobar(alumnos.GroupBy(a => a.Centro).Count() == 3
        && alumnos.GroupBy(a => a.Centro).All(g => g.Count() == 24), "Distribución incorrecta por centro.");
    Comprobar(alumnos.GroupBy(a => new { a.Centro, a.Carrera }).Count() == 6
        && alumnos.GroupBy(a => new { a.Centro, a.Carrera }).All(g => g.Count() == 12), "Distribución incorrecta por carrera.");
    Comprobar(alumnos.GroupBy(a => new { a.Centro, a.Carrera, a.Grupo }).Count() == 18
        && alumnos.GroupBy(a => new { a.Centro, a.Carrera, a.Grupo }).All(g => g.Count() == 4), "Distribución incorrecta por grupo.");

    Alumno alumno = RegistroAlumnos.BuscarPorId("123456")
        ?? throw new Exception("No se encontró un ID autorizado.");
    Comprobar(alumno.Centro == "Centro de Ciencias Básicas"
        && alumno.Carrera == "Ingeniería en Sistemas Computacionales"
        && alumno.Grupo == "A", "Los datos recuperados no corresponden al ID.");
    Sesion.IniciarAlumno(alumno);
    Comprobar(Sesion.RolActual == Rol.Alumno && Sesion.IdActual == alumno.Id
        && Sesion.CentroActual == alumno.Centro && Sesion.CarreraActual == alumno.Carrera
        && Sesion.GrupoActual == alumno.Grupo, "No se cargaron los datos del padrón en la sesión.");
    Comprobar(RegistroAlumnos.BuscarPorId("999999") == null, "Se aceptó un ID desconocido.");
    Comprobar(RegistroAlumnos.ObtenerTodos().Count == 72, "La búsqueda creó un alumno.");
    Comprobar(File.ReadAllBytes(rutaPadron).SequenceEqual(padronOriginal), "La consulta o el inicio de sesión modificó alumnos.csv.");

    Sesion.Cerrar();
    Comprobar(Sesion.RolActual == Rol.Alumno && Sesion.IdActual == ""
        && Sesion.CentroActual == "" && Sesion.CarreraActual == ""
        && Sesion.GrupoActual == "" && Sesion.SemestreActual == "",
        "Cerrar sesión dejó datos del alumno activos.");
    Sesion.RolActual = Rol.Admin;
    Sesion.IdActual = "admin";
    Sesion.Cerrar();
    Comprobar(Sesion.RolActual != Rol.Admin && Sesion.IdActual == "",
        "Cerrar sesión conservó el acceso de administrador.");
}

void ProbarConteoYAgrupacion()
{
    var procesador = new ProcesadorVotos();
    List<Alumno> alumnos = RegistroAlumnos.ObtenerTodos();
    var votos = new List<ResultadoCandidato>();
    var participacion = new List<Estadisticas>();
    foreach (var grupo in alumnos.GroupBy(a => new { a.Centro, a.Carrera, a.Grupo }))
    {
        // Dos votos anónimos por cada grupo de cuatro alumnos.
        foreach (string candidato in new[] { "Planilla A", "Planilla B" })
        {
            votos.Add(new ResultadoCandidato
            {
                Eleccion = "Sociedad de Alumnos",
                Centro = grupo.Key.Centro,
                Carrera = grupo.Key.Carrera,
                Grupo = grupo.Key.Grupo,
                Candidato = candidato,
                Registrado = true,
                Votos = 1
            });
        }

        Estadisticas estadistica = procesador.CalcularEstadisticas(grupo.Count(), 2);
        estadistica.Eleccion = "Sociedad de Alumnos";
        estadistica.Centro = grupo.Key.Centro;
        estadistica.Carrera = grupo.Key.Carrera;
        estadistica.Grupo = grupo.Key.Grupo;
        participacion.Add(estadistica);
    }

    Comprobar(procesador.ContarVotos(votos).Sum(v => v.Votos) == 36, "El conteo general perdió votos.");
    foreach (var caso in new[] { (Tipo: "Centro", Cantidad: 3, Registrados: 24, Votantes: 12),
        (Tipo: "Carrera", Cantidad: 6, Registrados: 12, Votantes: 6),
        (Tipo: "Grupo", Cantidad: 18, Registrados: 4, Votantes: 2) })
    {
        List<Estadisticas> estadisticas = procesador.Agrupar(participacion, caso.Tipo);
        Comprobar(estadisticas.Count == caso.Cantidad && estadisticas.All(e =>
            e.Registrados == caso.Registrados && e.Votantes == caso.Votantes
            && e.Abstenciones == caso.Registrados - caso.Votantes
            && e.Participacion == 50 && e.Abstencionismo == 50), "Estadísticas incorrectas por " + caso.Tipo);

        List<ResultadoCandidato> resultados = procesador.AgruparVotos(votos, caso.Tipo);
        Comprobar(resultados.Count == caso.Cantidad * 2
            && resultados.Sum(r => r.Votos) == 36
            && resultados.All(r => r.Votos == caso.Votantes / 2), "Agregación incorrecta por " + caso.Tipo);
    }
    Comprobar(procesador.CalcularPorcentaje(18, 36) == 50, "Porcentaje incorrecto.");
}

void ProbarDatosSimulados()
{
    List<Alumno> alumnos = RegistroAlumnos.ObtenerTodos();
    string rutaParticipacion = Path.Combine(AppContext.BaseDirectory, "Datos", "votantes.csv");
    string[] filas = File.ReadAllLines(rutaParticipacion);
    Comprobar(filas[0] == "Rol,Id", "El registro de participación contiene un esquema distinto.");
    var participantes = filas.Skip(1).Where(f => f.StartsWith("Alumno,"))
        .Select(f => f.Split(',')[1]).ToHashSet(StringComparer.Ordinal);
    Comprobar(participantes.Count == 54 && filas.Length == 55, "La simulación no tiene exactamente 54 alumnos participantes.");
    Comprobar(participantes.All(id => alumnos.Any(a => a.Id == id)), "Se incluyó un votante fuera del padrón.");
    Comprobar(alumnos.Count(a => !participantes.Contains(a.Id)) == 18, "El abstencionismo no corresponde a 18 alumnos.");
    Comprobar(alumnos.GroupBy(a => new { a.Centro, a.Carrera, a.Grupo })
        .All(g => g.Count(a => participantes.Contains(a.Id)) == 3), "La participación no está distribuida entre todos los grupos.");

    var procesador = new ProcesadorVotos();
    foreach (string eleccion in new[] { "Sociedad de Alumnos", "Consejo Universitario", "Consejo de Representantes" })
    {
        List<ResultadoCandidato> votos = RegistroVotos.ObtenerVotos(eleccion);
        Comprobar(votos.Count == 54 && votos.Sum(v => v.Votos) == 54, "Cantidad incorrecta de votos anónimos en " + eleccion);
        Comprobar(votos.GroupBy(v => new { v.Centro, v.Carrera, v.Grupo }).Count() == 18
            && votos.GroupBy(v => new { v.Centro, v.Carrera, v.Grupo }).All(g => g.Count() == 3), "Votos sin distribución por grupo.");
        List<ResultadoCandidato> resultados = DatosVotacion.ObtenerResultados(eleccion);
        Comprobar(resultados.Sum(r => r.Votos) == 54, "El reporte no cargó los 54 votos de " + eleccion);
        Comprobar(DatosVotacion.ObtenerResultados(eleccion).Sum(r => r.Votos) == 54, "La recarga del reporte duplicó los votos.");
        Estadisticas estadisticas = procesador.CalcularEstadisticas(alumnos.Count, resultados.Sum(r => r.Votos));
        Comprobar(estadisticas.Abstenciones == 18 && estadisticas.Participacion == 75
            && estadisticas.Abstencionismo == 25, "El reporte no calcula 75% de participación y 25% de abstencionismo.");
    }

    Aislado(() =>
    {
        Sesion.IniciarAlumno(RegistroAlumnos.BuscarPorId("123459")!);
        DatosVotacion.IniciarPapeleta();
        DatosVotacion.Seleccionar("Sociedad de Alumnos", true);
        DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "FEUUA");
        Comprobar(DatosVotacion.ObtenerResultados("Sociedad de Alumnos").Sum(v => v.Votos) == 54,
            "Una selección pendiente alteró el reporte.");
        DatosVotacion.Confirmar();
        Comprobar(DatosVotacion.ObtenerResultados("Sociedad de Alumnos").Sum(v => v.Votos) == 55,
            "El voto confirmado no se persistió.");
    });
}

void ProbarFiltrosDelReporte()
{
    const string centro = "Centro de Ciencias Básicas";
    const string carrera = "Ingeniería en Sistemas Computacionales";
    var procesador = new ProcesadorVotos();
    foreach (string eleccion in new[] { "Sociedad de Alumnos", "Consejo Universitario", "Consejo de Representantes" })
    {
        foreach (var filtro in new[]
        {
            (Centro: (string?)null, Carrera: (string?)null, Grupo: (string?)null, Registrados: 72, Votantes: 54, Grupos: 18),
            (Centro: (string?)centro, Carrera: (string?)null, Grupo: (string?)null, Registrados: 24, Votantes: 18, Grupos: 6),
            (Centro: (string?)centro, Carrera: (string?)carrera, Grupo: (string?)null, Registrados: 12, Votantes: 9, Grupos: 3),
            (Centro: (string?)centro, Carrera: (string?)carrera, Grupo: (string?)"A", Registrados: 4, Votantes: 3, Grupos: 1)
        })
        {
            int registrados = ConsultaResultados.ObtenerAlumnos(filtro.Centro, filtro.Carrera, filtro.Grupo).Count;
            List<ResultadoCandidato> resultados = DatosVotacion.ObtenerResultados(eleccion, filtro.Centro, filtro.Carrera, filtro.Grupo);
            Comprobar(registrados == filtro.Registrados && resultados.Sum(r => r.Votos) == filtro.Votantes,
                "El filtro no limita el padrón y los votos al mismo segmento.");
            Estadisticas datos = procesador.CalcularEstadisticas(registrados, resultados.Sum(r => r.Votos));
            Comprobar(datos.Participacion == 75 && datos.Abstencionismo == 25, "Porcentajes calculados con un padrón distinto al segmento filtrado.");
            Comprobar(resultados.All(r => r.Centro == (filtro.Centro ?? "")
                && r.Carrera == (filtro.Carrera ?? "") && r.Grupo == (filtro.Grupo ?? "")),
                "La exportación no conserva el alcance de los filtros.");
            List<Estadisticas> grupos = ConsultaResultados.ObtenerParticipacionPorGrupo(eleccion, filtro.Centro, filtro.Carrera, filtro.Grupo);
            Comprobar(grupos.Count == filtro.Grupos && grupos.All(g => g.Registrados == 4 && g.Votantes == 3
                && g.Abstenciones == 1 && g.Participacion == 75), "El detalle de participación incluye grupos fuera del filtro.");
        }
    }

    Comprobar(ConsultaResultados.ObtenerAlumnos("Centro inexistente").Count == 0
        && DatosVotacion.ObtenerResultados("Sociedad de Alumnos", "Centro inexistente").Sum(v => v.Votos) == 0,
        "Un filtro sin coincidencias mostró los resultados generales.");

    Aislado(() =>
    {
    Sesion.IniciarAlumno(RegistroAlumnos.BuscarPorId("123459")!);
    DatosVotacion.IniciarPapeleta();
    DatosVotacion.Seleccionar("Sociedad de Alumnos", true);
    DatosVotacion.Seleccionar("Consejo Universitario", true);
    DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "CONECTA");
    DatosVotacion.RegistrarVoto("Consejo Universitario", "Propuesta de prueba", false);
    DatosVotacion.Confirmar();
    {
        Comprobar(DatosVotacion.ObtenerResultados("Sociedad de Alumnos").Sum(v => v.Votos) == 55,
            "El voto nuevo no actualiza el total general.");
        Comprobar(DatosVotacion.ObtenerResultados("Sociedad de Alumnos", centro, carrera, "A").Sum(v => v.Votos) == 4,
            "El voto nuevo no se incluyó en el grupo del alumno.");
        Comprobar(DatosVotacion.ObtenerResultados("Sociedad de Alumnos", centro, carrera, "B").Sum(v => v.Votos) == 3,
            "El voto nuevo se incluyó en otro grupo.");
        Comprobar(DatosVotacion.ObtenerResultados("Sociedad de Alumnos", "Centro de Ciencias de la Salud").Sum(v => v.Votos) == 18,
            "El voto nuevo se incluyó en otro centro.");
        Comprobar(DatosVotacion.ObtenerResultados("Consejo Universitario", centro, carrera, "A")
            .Single(v => !v.Registrado && v.Candidato == "Propuesta de prueba").Votos == 1,
            "La propuesta no participa en el filtro del grupo.");
        Comprobar(ConsultaResultados.ObtenerParticipacionPorGrupo("Sociedad de Alumnos", centro, carrera, "A")
            .Single().Participacion == 100, "El grupo no alcanza 100% al votar el alumno pendiente.");
    }
    });

}

void ProbarFormatosYErrores()
{
    File.WriteAllText(rutaPadron, "Grupo,Carrera,Id,Centro\nA,\"Sistemas, software\",000123,Centro de prueba\n", Encoding.UTF8);
    Alumno alumno = RegistroAlumnos.BuscarPorId("000123")
        ?? throw new Exception("No se conservaron los ceros iniciales.");
    Comprobar(alumno.Grupo == "A" && alumno.Carrera == "Sistemas, software", "Se interpretaron mal las columnas o las comillas.");
    Comprobar(RegistroAlumnos.BuscarPorId("123") == null, "El lector alteró el ID.");

    File.WriteAllText(rutaPadron, "Id,Centro,Carrera,Semestre,Grupo\n123456,Centro,Carrera,2,B\n");
    alumno = RegistroAlumnos.BuscarPorId("123456")!;
    Comprobar(alumno.Semestre == "2" && alumno.Grupo == "B", "Se rompió el formato anterior de cinco columnas.");

    foreach (string contenido in new[]
    {
        "Id,Centro,Carrera,Grupo\n123456,Centro,Carrera,A\n123456,Centro,Carrera,B\n",
        "Id,Centro,Carrera,Grupo\n123456,Centro,Carrera\n",
        "Id,Centro,Carrera,Grupo\nabc,Centro,Carrera,A\n",
        "Id,Centro,Carrera,Grupo\n123456,,Carrera,A\n",
        "Id,Centro,Carrera,Grupo\n123456,Centro,\"Carrera,A\n",
        "Id,Centro,Carrera\n123456,Centro,Carrera\n"
    })
    {
        File.WriteAllText(rutaPadron, contenido);
        bool rechazado = false;
        try { RegistroAlumnos.ObtenerTodos(); }
        catch (InvalidDataException) { rechazado = true; }
        Comprobar(rechazado, "Se aceptó un padrón inválido.");
    }
    File.WriteAllBytes(rutaPadron, padronOriginal);
}

void Aislado(Action prueba)
{
    string carpeta = Path.Combine(AppContext.BaseDirectory, "Datos");
    var originales = new[] { "votos.csv", "participacion.csv", "convocatorias.csv", "candidatos.csv" }
        .ToDictionary(n => n, n => File.ReadAllBytes(Path.Combine(carpeta, n)));
    try { prueba(); }
    finally
    {
        DatosVotacion.LimpiarVotosSesion();
        foreach (var original in originales)
            File.WriteAllBytes(Path.Combine(carpeta, original.Key), original.Value);
    }
}

void Rechaza(Action accion, string mensaje)
{
    bool rechazo = false;
    try { accion(); }
    catch (Exception ex) when (ex is InvalidOperationException or ArgumentException or IOException or UnauthorizedAccessException)
    { rechazo = true; }
    Comprobar(rechazo, mensaje);
}

void ProbarConfirmacionYRecuperacion()
{
    string carpeta = Path.Combine(AppContext.BaseDirectory, "Datos");
    string votos = Path.Combine(carpeta, "votos.csv"), participacion = Path.Combine(carpeta, "participacion.csv");
    foreach (int cantidad in new[] { 1, 2, 3 }) Aislado(() =>
    {
        Sesion.IniciarAlumno(RegistroAlumnos.BuscarPorId("123459")!);
        DatosVotacion.IniciarPapeleta();
        byte[] antes = File.ReadAllBytes(votos), antesParticipacion = File.ReadAllBytes(participacion);
        Rechaza(DatosVotacion.Confirmar, "Se confirmó sin convocatorias.");
        string[] seleccionadas = CatalogoElecciones.Nombres.Take(cantidad).ToArray();
        foreach (string eleccion in seleccionadas) DatosVotacion.Seleccionar(eleccion, true);
        Rechaza(DatosVotacion.Confirmar, "Se confirmó una papeleta incompleta.");
        foreach (string eleccion in seleccionadas)
            DatosVotacion.RegistrarVoto(eleccion, CatalogoElecciones.ObtenerCandidatos(eleccion).First());
        Rechaza(() => DatosVotacion.RegistrarVoto(seleccionadas[0], "Duplicado", false), "Se emitieron dos votos para una papeleta.");
        Comprobar(File.ReadAllBytes(votos).SequenceEqual(antes)
            && File.ReadAllBytes(participacion).SequenceEqual(antesParticipacion), "Las selecciones escribieron antes de Enviar.");
        DatosVotacion.Confirmar();
        // Simula el fin de la sesión: el reporte solo lee los archivos.
        DatosVotacion.IniciarPapeleta();
        foreach (string eleccion in CatalogoElecciones.Nombres)
        {
            bool elegida = seleccionadas.Contains(eleccion);
            Comprobar(RegistroVotos.ObtenerVotos(eleccion).Count == (elegida ? 55 : 54), "Se perdió un voto o se votó una elección no seleccionada.");
            Comprobar(RegistroParticipacion.YaVoto(Rol.Alumno, "123459", eleccion) == elegida,
                "La participación no se controla por elección.");
        }
        Comprobar(RegistroParticipacion.ObtenerPendientes(Rol.Alumno, "123459").Count == 3 - cantidad,
            "No se puede regresar por las convocatorias restantes.");
        Rechaza(() => DatosVotacion.Seleccionar(seleccionadas[0], true), "Se permitió votar otra vez en una elección completada.");
        if (cantidad < 3)
        {
            string pendiente = CatalogoElecciones.Nombres[cantidad];
            DatosVotacion.Seleccionar(pendiente, true);
            DatosVotacion.RegistrarVoto(pendiente, "Propuesta, \"Ana\"", false);
            DatosVotacion.Confirmar();
            Comprobar(RegistroVotos.ObtenerVotos(pendiente).Any(v => v.Candidato == "Propuesta, \"Ana\"" && !v.Registrado),
                "Se perdió la propuesta o sus comillas.");
        }
        string[] filasVotos = File.ReadAllLines(votos), filasParticipacion = File.ReadAllLines(participacion);
        Comprobar(filasVotos[0] == "Eleccion,Centro,Carrera,Grupo,Candidato,Registrado"
            && !filasVotos.Skip(1).Any(l => l.Contains("123459"))
            && filasParticipacion[0] == "Rol,Id,Eleccion"
            && !filasParticipacion.Any(l => l.Contains("FEUUA") || l.Contains("Propuesta")), "Se vincul? ID y candidato en un archivo.");
    });

    Aislado(() =>
    {
        Sesion.IniciarAlumno(RegistroAlumnos.BuscarPorId("123459")!);
        DatosVotacion.IniciarPapeleta();
        DatosVotacion.Seleccionar("Sociedad de Alumnos", true);
        DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "FEUUA");
        DatosVotacion.Seleccionar("Sociedad de Alumnos", false);
        Comprobar(!DatosVotacion.PuedeConfirmar && !DatosVotacion.TieneVoto("Sociedad de Alumnos"), "Desmarcar conserva un voto pendiente.");
        DatosVotacion.Seleccionar("Consejo Universitario", true);
        DatosVotacion.RegistrarVoto("Consejo Universitario", "Propuesta cancelada", false);
        DatosVotacion.LimpiarVotosSesion();
        Comprobar(RegistroVotos.ObtenerVotos("Consejo Universitario").Count == 54
            && RegistroParticipacion.ObtenerPendientes(Rol.Alumno, "123459").Count == 3, "Cancelar registró votos o participación.");

        DatosVotacion.IniciarPapeleta();
        DatosVotacion.Seleccionar("Sociedad de Alumnos", true);
        Rechaza(() => DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "   ", false), "Se aceptó una propuesta vacía.");
        DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "FEUUA");
        byte[] votosAntes = File.ReadAllBytes(votos), participacionAntes = File.ReadAllBytes(participacion);
        string obstaculo = Path.Combine(carpeta, "participacion.csv.nueva");
        Directory.CreateDirectory(obstaculo);
        try { Rechaza(DatosVotacion.Confirmar, "No se detectó el error de escritura."); }
        finally { Directory.Delete(obstaculo); }
        Comprobar(File.ReadAllBytes(votos).SequenceEqual(votosAntes)
            && File.ReadAllBytes(participacion).SequenceEqual(participacionAntes), "Un error guardó parcialmente la votación.");
        DatosVotacion.Confirmar();
        Comprobar(RegistroVotos.ObtenerVotos("Sociedad de Alumnos").Count == 55, "Reintentar perdió o duplic? un voto.");

        // Simula cierre inesperado entre las dos escrituras, antes de completar la transacción.
        File.WriteAllBytes(votos + ".anterior", votosAntes);
        File.WriteAllBytes(participacion + ".anterior", participacionAntes);
        File.WriteAllText(Path.Combine(carpeta, "confirmacion.pendiente"), "restaurar");
        File.WriteAllText(votos, "escritura incompleta");
        Comprobar(RegistroVotos.ObtenerVotos("Sociedad de Alumnos").Count == 54
            && File.ReadAllBytes(participacion).SequenceEqual(participacionAntes), "La recuperación dejó archivos inconsistentes.");
    });

    Aislado(() =>
    {
        Sesion.IniciarAlumno(new Alumno { Id = "999999", Centro = "X", Carrera = "Y", Grupo = "Z" });
        DatosVotacion.IniciarPapeleta();
        DatosVotacion.Seleccionar("Sociedad de Alumnos", true);
        DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "FEUUA");
        Rechaza(DatosVotacion.Confirmar, "Se confirmó un ID fuera del padrón.");
    });

    Aislado(() =>
    {
        Sesion.IniciarAlumno(RegistroAlumnos.BuscarPorId("123459")!);
        DatosVotacion.IniciarPapeleta();
        DatosVotacion.Seleccionar("Sociedad de Alumnos", true);
        DatosVotacion.RegistrarVoto("Sociedad de Alumnos", "FEUUA");
        // Otro proceso completó la misma elección después de abrir esta papeleta.
        File.AppendAllText(participacion, "Alumno,123459,Sociedad de Alumnos\n");
        Rechaza(DatosVotacion.Confirmar, "La confirmación no volvió a comprobar duplicados.");
        Comprobar(RegistroVotos.ObtenerVotos("Sociedad de Alumnos").Count == 54, "El intento duplicado añadió un voto.");
    });

    Aislado(() =>
    {
        string rutaActivas = Path.Combine(carpeta, "convocatorias.csv");
        File.WriteAllText(rutaActivas, File.ReadAllText(rutaActivas).Replace("Sociedad de Alumnos,True", "Sociedad de Alumnos,False"));
        Sesion.IniciarAlumno(RegistroAlumnos.BuscarPorId("123459")!);
        DatosVotacion.IniciarPapeleta();
        Comprobar(RegistroParticipacion.ObtenerPendientes(Rol.Alumno, "123459").Count == 2, "Se incluyó una convocatoria inactiva.");
        Rechaza(() => DatosVotacion.Seleccionar("Sociedad de Alumnos", true), "Se permitió votar una convocatoria inactiva.");
        string candidatos = Path.Combine(carpeta, "candidatos.csv");
        File.AppendAllText(candidatos, "Consejo Universitario,Candidato del catálogo de prueba\n");
        Comprobar(CatalogoElecciones.ObtenerCandidatos("Consejo Universitario").Contains("Candidato del catálogo de prueba"), "La lista oficial no se carga desde CSV.");
    });
}

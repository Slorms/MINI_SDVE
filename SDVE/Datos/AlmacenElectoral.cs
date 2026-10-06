using System.Text;
using SDVE.Conteo;
using SDVE.Login;

namespace SDVE.Datos;

// Los votos y la participación se escriben en archivos separados. El marcador
// de recuperación contiene únicamente el estado de la operación, sin datos personales.
internal static class AlmacenElectoral
{
    private static readonly string Carpeta = Path.Combine(AppContext.BaseDirectory, "Datos");
    private static string Ruta(string nombre) => Path.Combine(Carpeta, nombre);
    private const string CabeceraVotos = "Eleccion,Centro,Carrera,Grupo,Candidato,Registrado";
    private const string CabeceraParticipacion = "Rol,Id,Eleccion";

    internal static T Leer<T>(Func<T> consulta)
    {
        Directory.CreateDirectory(Carpeta);
        using var bloqueo = new FileStream(Ruta("electoral.lock"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        Recuperar();
        InicializarParticipacion();
        return consulta();
    }

    private static void InicializarParticipacion()
    {
        if (File.Exists(Ruta("participacion.csv"))) return;
        var filas = new List<string> { CabeceraParticipacion };
        // El registro anterior correspondía a las tres papeletas obligatorias.
        if (File.Exists(Ruta("votantes.csv")))
        {
            var lineas = File.ReadAllLines(Ruta("votantes.csv"), Encoding.UTF8);
            if (lineas.Length == 0 || lineas[0] != "Rol,Id")
                throw new InvalidDataException("El registro anterior de votantes no es válido.");
            foreach (string linea in lineas.Skip(1).Where(l => !string.IsNullOrWhiteSpace(l)).Distinct())
            {
                string[] f = RegistroAlumnos.SepararCsv(linea);
                if (f.Length != 2 || !Enum.TryParse(f[0], out Rol rol) || !Enum.IsDefined(rol)
                    || rol == Rol.Admin || !EsId(f[1]))
                    throw new InvalidDataException("El registro anterior de votantes contiene una fila inválida.");
                foreach (string eleccion in CatalogoElecciones.Nombres)
                    filas.Add($"{rol},{f[1]},{eleccion}");
            }
        }
        EscribirTemporal(Ruta("participacion.csv.nueva"), string.Join(Environment.NewLine, filas) + Environment.NewLine);
        File.Move(Ruta("participacion.csv.nueva"), Ruta("participacion.csv"), true);
    }

    private static bool EsId(string id) => id.Length > 0 && id.Length <= 6 && id.All(c => c >= '0' && c <= '9');

    internal static List<(Rol Rol, string Id, string Eleccion)> LeerParticipacion()
    {
        var lineas = File.ReadAllLines(Ruta("participacion.csv"), Encoding.UTF8);
        if (lineas.Length == 0 || lineas[0] != CabeceraParticipacion)
            throw new InvalidDataException("El encabezado de participacion.csv no es válido.");
        var registros = new List<(Rol, string, string)>();
        foreach (string linea in lineas.Skip(1).Where(l => !string.IsNullOrWhiteSpace(l)))
        {
            string[] f = RegistroAlumnos.SepararCsv(linea);
            if (f.Length != 3 || !Enum.TryParse(f[0], out Rol rol) || !Enum.IsDefined(rol)
                || rol == Rol.Admin || !EsId(f[1]) || !CatalogoElecciones.Nombres.Contains(f[2]))
                throw new InvalidDataException("participacion.csv contiene una fila inválida.");
            registros.Add((rol, f[1], f[2]));
        }
        if (registros.Distinct().Count() != registros.Count)
            throw new InvalidDataException("participacion.csv contiene participaciones duplicadas.");
        return registros;
    }

    public static void Confirmar(Rol rol, string id, IReadOnlyCollection<string> seleccionadas,
        IReadOnlyCollection<ResultadoCandidato> votos)
    {
        Leer(() =>
        {
            var activas = CatalogoElecciones.ObtenerActivas();
            if (!Enum.IsDefined(rol) || rol == Rol.Admin || !EsId(id) || seleccionadas.Count == 0
                || seleccionadas.Distinct().Count() != seleccionadas.Count
                || seleccionadas.Any(e => !activas.Contains(e))
                || votos.Count != seleccionadas.Count
                || seleccionadas.Any(e => votos.Count(v => v.Eleccion == e) != 1)
                || votos.Any(v => string.IsNullOrWhiteSpace(v.Candidato) || v.Candidato.Length > 120 || v.Candidato.Contains('\n')
                    || v.Candidato.Contains('\r') || v.Votos != 1))
                throw new InvalidOperationException("Completa una papeleta por cada convocatoria seleccionada.");

            if (votos.Any(v => v.Registrado != CatalogoElecciones.ObtenerCandidatos(v.Eleccion)
                    .Contains(v.Candidato, StringComparer.OrdinalIgnoreCase)))
                throw new InvalidOperationException("El catálogo de candidatos cambió. Abre nuevamente la papeleta.");

            if (rol == Rol.Alumno)
            {
                Alumno alumno = RegistroAlumnos.BuscarPorId(id)
                    ?? throw new InvalidOperationException("El ID ingresado no se encuentra registrado.");
                if (votos.Any(v => v.Centro != alumno.Centro || v.Carrera != alumno.Carrera || v.Grupo != alumno.Grupo))
                    throw new InvalidOperationException("Los datos del alumno no coinciden con el padrón.");
            }
            var participacion = LeerParticipacion();
            if (participacion.Any(p => p.Rol == rol && p.Id == id && seleccionadas.Contains(p.Eleccion)))
                throw new InvalidOperationException("Ya participaste en una de las convocatorias seleccionadas.");

            // Mezclar todos los votos evita conservar el orden de llegada del padrón.
            var anonimos = CatalogoElecciones.Nombres.SelectMany(RegistroVotos.LeerSinBloqueo).Concat(votos).ToList();
            for (int i = anonimos.Count - 1; i > 0; i--)
            {
                int j = System.Security.Cryptography.RandomNumberGenerator.GetInt32(i + 1);
                (anonimos[i], anonimos[j]) = (anonimos[j], anonimos[i]);
            }
            string textoVotos = CabeceraVotos + Environment.NewLine + string.Join(Environment.NewLine,
                anonimos.Select(v => string.Join(",", new[] { v.Eleccion, v.Centro, v.Carrera, v.Grupo,
                    v.Candidato, v.Registrado.ToString() }.Select(Escapar)))) + Environment.NewLine;
            participacion.AddRange(seleccionadas.Select(e => (rol, id, e)));
            string textoParticipacion = CabeceraParticipacion + Environment.NewLine + string.Join(Environment.NewLine,
                participacion.OrderBy(p => p.Rol).ThenBy(p => p.Id).ThenBy(p => p.Eleccion)
                    .Select(p => $"{p.Rol},{p.Id},{p.Eleccion}")) + Environment.NewLine;
            GuardarJuntos(textoVotos, textoParticipacion);
            return true;
        });
    }

    private static void GuardarJuntos(string votos, string participacion)
    {
        string[] archivos = { "votos.csv", "participacion.csv" };
        // Crear los archivos iniciales antes del respaldo, sin registrar votos.
        if (!File.Exists(Ruta("votos.csv"))) EscribirTemporal(Ruta("votos.csv"), CabeceraVotos + Environment.NewLine);
        foreach (string nombre in archivos)
            EscribirBytes(Ruta(nombre + ".anterior"), File.ReadAllBytes(Ruta(nombre)));
        EscribirTemporal(Ruta("votos.csv.nueva"), votos);
        EscribirTemporal(Ruta("participacion.csv.nueva"), participacion);
        try
        {
            EscribirTemporal(Ruta("confirmacion.pendiente"), "restaurar");
            foreach (string nombre in archivos)
                File.Move(Ruta(nombre + ".nueva"), Ruta(nombre), true);
            // Al quitar el marcador, ambas escrituras están confirmadas.
            File.Delete(Ruta("confirmacion.pendiente"));
        }
        catch
        {
            Recuperar();
            throw;
        }
        LimpiarTemporales();
    }

    private static void Recuperar()
    {
        if (!File.Exists(Ruta("confirmacion.pendiente"))) return;
        foreach (string nombre in new[] { "votos.csv", "participacion.csv" })
        {
            // No leer resultados parciales si faltó completar una confirmación.
            EscribirBytes(Ruta(nombre + ".restaurado"), File.ReadAllBytes(Ruta(nombre + ".anterior")));
            File.Move(Ruta(nombre + ".restaurado"), Ruta(nombre), true);
        }
        File.Delete(Ruta("confirmacion.pendiente"));
        LimpiarTemporales();
    }

    private static void LimpiarTemporales()
    {
        foreach (string nombre in new[] { "votos.csv.anterior", "participacion.csv.anterior", "votos.csv.nueva", "participacion.csv.nueva" })
        {
            try { File.Delete(Ruta(nombre)); }
            catch (IOException) { /* No cambia la confirmación ya terminada. */ }
            catch (UnauthorizedAccessException) { }
        }
    }

    private static string Escapar(string valor) => "\"" + valor.Replace("\"", "\"\"") + "\"";
    private static void EscribirTemporal(string ruta, string contenido) => EscribirBytes(ruta, new UTF8Encoding(false).GetBytes(contenido));
    private static void EscribirBytes(string ruta, byte[] contenido)
    {
        using var archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
        archivo.Write(contenido);
        archivo.Flush(true);
    }
}

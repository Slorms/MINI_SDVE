using System.Text;

namespace SDVE.Datos
{
    public static class RegistroAlumnos
    {
        private static readonly string[] RutasPosibles =
        {
            Path.Combine(AppContext.BaseDirectory, "Datos", "alumnos.csv"),
            Path.Combine(AppContext.BaseDirectory, "alumnos.csv"),
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Datos", "alumnos.csv"),
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "alumnos.csv")
        };

        private static string? ObtenerRutaValida()
        {
            foreach (string ruta in RutasPosibles)
            {
                string rutaNormalizada = Path.GetFullPath(ruta);
                if (File.Exists(rutaNormalizada))
                    return rutaNormalizada;
            }

            return null;
        }

        public static Alumno? BuscarPorId(string id)
        {
            return ObtenerTodos().FirstOrDefault(alumno => alumno.Id == id);
        }

        // El padrón solo se lee: el login nunca crea ni modifica alumnos.
        public static List<Alumno> ObtenerTodos()
        {
            string ruta = ObtenerRutaValida()
                ?? throw new FileNotFoundException(
                    "No se encontró el padrón de alumnos. Coloca alumnos.csv en Datos/.");

            using var lector = new StreamReader(ruta, Encoding.UTF8);
            string? encabezado = lector.ReadLine();
            if (string.IsNullOrWhiteSpace(encabezado))
                throw new InvalidDataException("El padrón no contiene un encabezado válido.");

            string[] columnas = SepararCsv(encabezado)
                .Select(columna => columna.Trim()).ToArray();
            string[] requeridas = { "Id", "Centro", "Carrera", "Grupo" };
            if (columnas.Distinct(StringComparer.OrdinalIgnoreCase).Count() != columnas.Length
                || requeridas.Any(columna => !columnas.Contains(columna, StringComparer.OrdinalIgnoreCase))
                || columnas.Any(columna => !requeridas.Contains(columna, StringComparer.OrdinalIgnoreCase)
                    && !columna.Equals("Semestre", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidDataException(
                    "El padrón debe contener Id,Centro,Carrera,Grupo; Semestre es opcional.");
            }

            int indiceId = Array.FindIndex(columnas, columna => columna.Equals("Id", StringComparison.OrdinalIgnoreCase));
            int indiceCentro = Array.FindIndex(columnas, columna => columna.Equals("Centro", StringComparison.OrdinalIgnoreCase));
            int indiceCarrera = Array.FindIndex(columnas, columna => columna.Equals("Carrera", StringComparison.OrdinalIgnoreCase));
            int indiceGrupo = Array.FindIndex(columnas, columna => columna.Equals("Grupo", StringComparison.OrdinalIgnoreCase));
            int indiceSemestre = Array.FindIndex(columnas, columna => columna.Equals("Semestre", StringComparison.OrdinalIgnoreCase));
            var alumnos = new List<Alumno>();
            var ids = new HashSet<string>(StringComparer.Ordinal);
            int numeroLinea = 1;
            string? linea;

            while ((linea = lector.ReadLine()) != null)
            {
                numeroLinea++;
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                string[] datos = SepararCsv(linea).Select(dato => dato.Trim()).ToArray();
                if (datos.Length != columnas.Length)
                    throw new InvalidDataException($"La fila {numeroLinea} del padrón tiene columnas incompletas.");

                string id = datos[indiceId];
                if (id.Length == 0 || id.Length > 6 || id.Any(caracter => caracter < '0' || caracter > '9')
                    || string.IsNullOrWhiteSpace(datos[indiceCentro])
                    || string.IsNullOrWhiteSpace(datos[indiceCarrera])
                    || string.IsNullOrWhiteSpace(datos[indiceGrupo]))
                {
                    throw new InvalidDataException($"La fila {numeroLinea} del padrón contiene datos inválidos.");
                }

                if (!ids.Add(id))
                    throw new InvalidDataException($"El ID {id} está duplicado en el padrón.");

                alumnos.Add(new Alumno
                {
                    Id = id,
                    Centro = datos[indiceCentro],
                    Carrera = datos[indiceCarrera],
                    Grupo = datos[indiceGrupo],
                    Semestre = indiceSemestre >= 0 ? datos[indiceSemestre] : ""
                });
            }

            return alumnos;
        }

        public static int ContarAlumnos()
        {
            return ObtenerTodos().Count;
        }

        internal static string[] SepararCsv(string linea)
        {
            var campos = new List<string>();
            var campo = new StringBuilder();
            bool entreComillas = false;

            for (int i = 0; i < linea.Length; i++)
            {
                char c = linea[i];
                if (c == '"')
                {
                    if (entreComillas && i + 1 < linea.Length && linea[i + 1] == '"')
                    {
                        campo.Append('"');
                        i++;
                    }
                    else
                    {
                        entreComillas = !entreComillas;
                    }
                }
                else if (c == ',' && !entreComillas)
                {
                    campos.Add(campo.ToString());
                    campo.Clear();
                }
                else
                {
                    campo.Append(c);
                }
            }

            if (entreComillas)
                throw new InvalidDataException("El padrón contiene un campo con comillas sin cerrar.");

            campos.Add(campo.ToString());
            return campos.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Login
{
    public static class RegistroVotantes
    {
        private static readonly string Directorio =
            Path.Combine(AppContext.BaseDirectory, "Datos");
        private static readonly string DirectorioAnterior =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SDVE");
        private static readonly string Ruta =
            Path.Combine(Directorio, "votantes.csv");
        private static readonly HashSet<string> _ids = Cargar();

        private static HashSet<string> Cargar()
        {
            var ids = new HashSet<string>(StringComparer.Ordinal);

            if (File.Exists(Ruta))
            {
                foreach (string linea in File.ReadLines(Ruta, Encoding.UTF8).Skip(1))
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                        ids.Add(LeerClave(linea, ','));
                }
            }

            // Importa los registros de la ubicación anterior sin duplicarlos.
            var pendientes = new List<string>();
            foreach (string rutaAnterior in new[]
            {
                Path.Combine(DirectorioAnterior, "votantes.csv"),
                Path.Combine(DirectorioAnterior, "votantes.txt")
            })
            {
                if (!File.Exists(rutaAnterior))
                    continue;

                bool esCsv = Path.GetExtension(rutaAnterior) == ".csv";
                foreach (string linea in File.ReadLines(rutaAnterior, Encoding.UTF8)
                    .Skip(esCsv ? 1 : 0))
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    string clave = LeerClave(linea, esCsv ? ',' : ':');
                    if (ids.Add(clave))
                        pendientes.Add(clave);
                }

            }

            if (pendientes.Count > 0)
                Guardar(pendientes);

            return ids;
        }

        private static string LeerClave(string linea, char separador)
        {
            string[] campos = linea.Split(separador);
            if (campos.Length != 2
                || !Enum.TryParse(campos[0], out Rol rol)
                || !Enum.IsDefined(typeof(Rol), rol)
                || string.IsNullOrWhiteSpace(campos[1]))
            {
                throw new InvalidDataException("El registro de votantes contiene una fila inválida.");
            }

            return Clave(rol, campos[1]);
        }

        private static void Guardar(IEnumerable<string> claves)
        {
            Directory.CreateDirectory(Directorio);
            bool escribirEncabezado = !File.Exists(Ruta) || new FileInfo(Ruta).Length == 0;

            using (var archivo = new StreamWriter(Ruta, true, Encoding.UTF8))
            {
                if (escribirEncabezado)
                    archivo.WriteLine("Rol,Id");

                // Los IDs de alumnos y docentes se validan como números al ingresar.
                foreach (string clave in claves)
                    archivo.WriteLine(clave.Replace(':', ','));
            }
        }

        private static string Clave(Rol rol, string id) => rol + ":" + id;

        public static bool YaIngreso(Rol rol, string id) => _ids.Contains(Clave(rol, id));

        public static void Registrar(Rol rol, string id)
        {
            string clave = Clave(rol, id);
            if (_ids.Contains(clave))
                return;

            Guardar(new[] { clave });
            _ids.Add(clave);
        }
    }
}

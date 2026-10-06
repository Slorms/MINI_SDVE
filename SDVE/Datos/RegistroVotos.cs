namespace SDVE.Datos
{
    using SDVE.Conteo;
    using System.Text;

    internal class RegistroVotos
    {
        private static readonly string Ruta = Path.Combine(AppContext.BaseDirectory, "Datos", "votos.csv");
        public static List<ResultadoCandidato> ObtenerVotos(string eleccion) =>
            AlmacenElectoral.Leer(() => LeerSinBloqueo(eleccion));

        internal static List<ResultadoCandidato> LeerSinBloqueo(string eleccion)
        {
            var votos = new List<ResultadoCandidato>();
            if (!File.Exists(Ruta))
                return votos;

            using var lector = new StreamReader(Ruta, Encoding.UTF8);
            if (lector.ReadLine() != "Eleccion,Centro,Carrera,Grupo,Candidato,Registrado")
                throw new InvalidDataException("El encabezado de votos.csv no es válido.");

            string? linea;
            while ((linea = lector.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                string[] campos = RegistroAlumnos.SepararCsv(linea);
                if (campos.Length != 6 || !bool.TryParse(campos[5], out bool registrado)
                    || !CatalogoElecciones.Nombres.Contains(campos[0]) || string.IsNullOrWhiteSpace(campos[4]))
                    throw new InvalidDataException("votos.csv contiene una fila inválida.");

                if (campos[0] != eleccion)
                    continue;

                votos.Add(new ResultadoCandidato
                {
                    Eleccion = campos[0],
                    Centro = campos[1],
                    Carrera = campos[2],
                    Grupo = campos[3],
                    Candidato = campos[4],
                    Registrado = registrado,
                    Votos = 1
                });
            }

            return votos;
        }

    }
}

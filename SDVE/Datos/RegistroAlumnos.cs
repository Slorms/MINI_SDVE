namespace SDVE.Datos
{
    internal class RegistroAlumnos
    {
        private static readonly string Ruta =
            Path.Combine(AppContext.BaseDirectory, "Datos", "alumnos.csv");

        public static Alumno? BuscarPorId(string id)
        {
            if (!File.Exists(Ruta))
                return null;

            string[] lineas = File.ReadAllLines(Ruta);

            for (int i = 1; i < lineas.Length; i++)
            {
                string[] datos = lineas[i].Split(',');

                if (datos.Length < 5)
                    continue;

                if (datos[0].Trim() == id)
                {
                    return new Alumno
                    {
                        Id = datos[0].Trim(),
                        Centro = datos[1].Trim(),
                        Carrera = datos[2].Trim(),
                        Semestre = datos[3].Trim(),
                        Grupo = datos[4].Trim()
                    };
                }
            }

            return null;
        }
    }
}

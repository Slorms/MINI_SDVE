using SDVE.Login;
using SDVE.Datos;
using SDVE.Votaciones;

namespace SDVE.Conteo
{
    internal static class ConsultaResultados
    {
        public static List<Alumno> ObtenerAlumnos(string? centro = null,
            string? carrera = null, string? grupo = null)
        {
            return RegistroAlumnos.ObtenerTodos().Where(a =>
                (centro == null || a.Centro == centro)
                && (carrera == null || a.Carrera == carrera)
                && (grupo == null || a.Grupo == grupo)).ToList();
        }

        public static List<Estadisticas> ObtenerParticipacionPorGrupo(string eleccion,
            string? centro = null, string? carrera = null, string? grupo = null)
        {
            var procesador = new ProcesadorVotos();
            return ObtenerAlumnos(centro, carrera, grupo)
                .GroupBy(a => new { a.Centro, a.Carrera, a.Grupo })
                .Select(g =>
                {
                    int votantes = RegistroParticipacion.ContarAlumnos(eleccion, g);
                    Estadisticas estadistica = procesador.CalcularEstadisticas(g.Count(), votantes);
                    estadistica.Eleccion = eleccion;
                    estadistica.Centro = g.Key.Centro;
                    estadistica.Carrera = g.Key.Carrera;
                    estadistica.Grupo = g.Key.Grupo;
                    return estadistica;
                }).ToList();
        }
    }
}

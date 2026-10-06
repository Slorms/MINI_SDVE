using SDVE.Datos;

namespace SDVE.Login
{
    public enum Rol
    {
        Alumno,
        Docente,
        Admin
    }

    public static class Sesion
    {
        public static Rol RolActual { get; set; }
        public static string IdActual { get; set; } = "";
        public static string CentroActual { get; set; } = "";
        public static string CarreraActual { get; set; } = "";
        public static string SemestreActual { get; set; } = "";
        public static string GrupoActual { get; set; } = "";

        public static void Cerrar()
        {
            RolActual = Rol.Alumno;
            IdActual = "";
            CentroActual = "";
            CarreraActual = "";
            SemestreActual = "";
            GrupoActual = "";
        }

        public static void IniciarAlumno(Alumno alumno)
        {
            ArgumentNullException.ThrowIfNull(alumno);
            RolActual = Rol.Alumno;
            IdActual = alumno.Id;
            CentroActual = alumno.Centro;
            CarreraActual = alumno.Carrera;
            SemestreActual = alumno.Semestre;
            GrupoActual = alumno.Grupo;
        }
    }
}

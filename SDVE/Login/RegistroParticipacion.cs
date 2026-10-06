using SDVE.Datos;

namespace SDVE.Login;

internal static class RegistroParticipacion
{
    public static bool YaVoto(Rol rol, string id, string eleccion) =>
        AlmacenElectoral.Leer(() => AlmacenElectoral.LeerParticipacion()
            .Any(p => p.Rol == rol && p.Id == id && p.Eleccion == eleccion));

    public static List<string> ObtenerPendientes(Rol rol, string id) =>
        AlmacenElectoral.Leer(() =>
        {
            var completadas = AlmacenElectoral.LeerParticipacion()
                .Where(p => p.Rol == rol && p.Id == id).Select(p => p.Eleccion).ToHashSet();
            return CatalogoElecciones.ObtenerActivas().Where(e => !completadas.Contains(e)).ToList();
        });

    public static int ContarAlumnos(string eleccion, IEnumerable<Alumno> alumnos)
    {
        var ids = alumnos.Select(a => a.Id).ToHashSet();
        return AlmacenElectoral.Leer(() => AlmacenElectoral.LeerParticipacion()
            .Count(p => p.Rol == Rol.Alumno && p.Eleccion == eleccion && ids.Contains(p.Id)));
    }
}

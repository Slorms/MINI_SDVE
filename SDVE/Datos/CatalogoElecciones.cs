using System.Text;

namespace SDVE.Datos;

internal static class CatalogoElecciones
{
    public static readonly string[] Nombres =
        { "Sociedad de Alumnos", "Consejo Universitario", "Consejo de Representantes" };

    public static List<string> ObtenerActivas()
    {
        var filas = Leer("convocatorias.csv", "Eleccion,Activa", 2);
        if (filas.Count != Nombres.Length || filas.Select(f => f[0]).Distinct().Count() != Nombres.Length
            || filas.Any(f => !Nombres.Contains(f[0]) || !bool.TryParse(f[1], out _)))
            throw new InvalidDataException("Las convocatorias no son válidas.");
        return filas.Where(f => bool.Parse(f[1])).Select(f => f[0]).ToList();
    }

    public static List<string> ObtenerCandidatos(string eleccion)
    {
        if (!Nombres.Contains(eleccion))
            throw new ArgumentException("La elección no es válida.");
        var filas = Leer("candidatos.csv", "Eleccion,Candidato", 2);
        if (filas.Any(f => !Nombres.Contains(f[0]) || string.IsNullOrWhiteSpace(f[1])
                || f[1] != f[1].Trim() || f[1].Length > 120)
            || filas.GroupBy(f => (f[0], f[1].ToUpperInvariant())).Any(g => g.Count() > 1))
            throw new InvalidDataException("El catálogo de candidatos contiene filas inválidas o duplicadas.");
        return filas.Where(f => f[0] == eleccion).Select(f => f[1]).ToList();
    }

    private static List<string[]> Leer(string nombre, string encabezado, int columnas)
    {
        string[] lineas = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "Datos", nombre), Encoding.UTF8);
        if (lineas.Length == 0 || lineas[0] != encabezado)
            throw new InvalidDataException("Encabezado inválido en " + nombre);
        var filas = lineas.Skip(1).Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(RegistroAlumnos.SepararCsv).ToList();
        if (filas.Any(f => f.Length != columnas))
            throw new InvalidDataException("Fila inválida en " + nombre);
        return filas;
    }
}

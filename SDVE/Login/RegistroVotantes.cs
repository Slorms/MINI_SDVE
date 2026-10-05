namespace SDVE.Login
{
    // Guarda los IDs que ya ingresaron (en votantes.txt) para que no puedan volver a entrar
    public static class RegistroVotantes
    {
        static readonly string Ruta = Path.Combine(AppContext.BaseDirectory, "votantes.txt");
        static readonly HashSet<string> _ids = Cargar();

        static HashSet<string> Cargar()
        {
            try { if (File.Exists(Ruta)) return new HashSet<string>(File.ReadAllLines(Ruta)); }
            catch { }
            return new HashSet<string>();
        }

        static string Clave(Rol rol, string id) => rol + ":" + id;

        public static bool YaIngreso(Rol rol, string id) => _ids.Contains(Clave(rol, id));

        public static void Registrar(Rol rol, string id)
        {
            string k = Clave(rol, id);
            if (_ids.Add(k))
            {
                try { File.AppendAllText(Ruta, k + Environment.NewLine); }
                catch { }
            }
        }
    }
}


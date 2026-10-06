using SDVE.Conteo;
using SDVE.Datos;
using SDVE.Login;

namespace SDVE.Votaciones
{
    internal static class DatosVotacion
    {
        private static readonly List<ResultadoCandidato> votosSesion = new();

        private static readonly HashSet<string> seleccionadas = new();
        private static string idPendiente = "";
        private static Rol rolPendiente;

        public static void IniciarPapeleta()
        {
            LimpiarVotosSesion();
            idPendiente = Sesion.IdActual;
            rolPendiente = Sesion.RolActual;
        }

        public static void Seleccionar(string eleccion, bool seleccionada)
        {
            if (!seleccionada)
            {
                seleccionadas.Remove(eleccion);
                votosSesion.RemoveAll(v => v.Eleccion == eleccion);
                return;
            }
            if (!CatalogoElecciones.ObtenerActivas().Contains(eleccion))
                throw new InvalidOperationException("La convocatoria no está activa.");
            if (idPendiente != Sesion.IdActual || rolPendiente != Sesion.RolActual)
                throw new InvalidOperationException("La sesión cambió. Abre nuevamente la votación.");
            if (RegistroParticipacion.YaVoto(rolPendiente, idPendiente, eleccion))
                throw new InvalidOperationException("Ya participaste en esta convocatoria.");
            seleccionadas.Add(eleccion);
        }

        public static bool EstaSeleccionada(string eleccion) => seleccionadas.Contains(eleccion);
        public static bool TieneVoto(string eleccion) => votosSesion.Any(v => v.Eleccion == eleccion);
        public static bool PuedeConfirmar => seleccionadas.Count > 0
            && seleccionadas.All(TieneVoto) && votosSesion.Count == seleccionadas.Count;

        public static void RegistrarVoto(string eleccion, string candidato, bool registrado = true)
        {
            if (idPendiente != Sesion.IdActual || rolPendiente != Sesion.RolActual
                || !seleccionadas.Contains(eleccion) || TieneVoto(eleccion))
                throw new InvalidOperationException("La papeleta no está disponible.");
            candidato = candidato.Trim();
            if (candidato.Length == 0 || candidato.Length > 120 || candidato.Contains('\r') || candidato.Contains('\n'))
                throw new ArgumentException("Escribe un candidato válido (máximo 120 caracteres).");
            var oficiales = CatalogoElecciones.ObtenerCandidatos(eleccion);
            string? oficial = oficiales.FirstOrDefault(c => string.Equals(c, candidato, StringComparison.OrdinalIgnoreCase));
            if (registrado && oficial == null)
                throw new ArgumentException("El candidato no pertenece a la lista oficial.");
            votosSesion.Add(new ResultadoCandidato
            {
                Eleccion = eleccion,
                Centro = Sesion.CentroActual,
                Carrera = Sesion.CarreraActual,
                Grupo = Sesion.GrupoActual,
                Candidato = oficial ?? candidato,
                Registrado = oficial != null,
                Votos = 1
            });
        }

        public static void Confirmar()
        {
            if (idPendiente != Sesion.IdActual || rolPendiente != Sesion.RolActual || !PuedeConfirmar)
                throw new InvalidOperationException("Completa todas las convocatorias seleccionadas antes de enviar.");
            AlmacenElectoral.Confirmar(rolPendiente, idPendiente, seleccionadas.ToList(), votosSesion);
            LimpiarVotosSesion();
        }

        public static List<ResultadoCandidato> ObtenerVotos(string eleccion,
            string? centro = null, string? carrera = null, string? grupo = null)
        {
            // El reporte incluye únicamente votos confirmados y persistidos.
            return RegistroVotos.ObtenerVotos(eleccion)
                .Where(v => (centro == null || v.Centro == centro)
                    && (carrera == null || v.Carrera == carrera)
                    && (grupo == null || v.Grupo == grupo))
                .ToList();
        }

        public static List<ResultadoCandidato> ObtenerResultados(string eleccion,
            string? centro = null, string? carrera = null, string? grupo = null)
        {
            List<string> candidatos = CatalogoElecciones.ObtenerCandidatos(eleccion);

            var resultados = candidatos.Select(candidato => new ResultadoCandidato
            {
                Eleccion = eleccion,
                Centro = centro ?? "",
                Carrera = carrera ?? "",
                Grupo = grupo ?? "",
                Candidato = candidato,
                Registrado = true
            }).ToList();

            foreach (var candidatura in ObtenerVotos(eleccion, centro, carrera, grupo)
                .GroupBy(v => new { Nombre = v.Candidato.ToUpperInvariant(), v.Registrado }))
            {
                ResultadoCandidato? resultado = resultados.FirstOrDefault(r =>
                    r.Registrado == candidatura.Key.Registrado
                    && string.Equals(r.Candidato, candidatura.First().Candidato, StringComparison.OrdinalIgnoreCase));
                if (resultado == null)
                {
                    resultado = new ResultadoCandidato
                    {
                        Eleccion = eleccion,
                        Centro = centro ?? "",
                        Carrera = carrera ?? "",
                        Grupo = grupo ?? "",
                        Candidato = candidatura.First().Candidato,
                        Registrado = candidatura.Key.Registrado
                    };
                    resultados.Add(resultado);
                }
                resultado.Votos = candidatura.Sum(v => v.Votos);
            }
            return resultados;
        }

        internal static void LimpiarVotosSesion()
        {
            votosSesion.Clear();
            seleccionadas.Clear();
            idPendiente = "";
        }
    }
}

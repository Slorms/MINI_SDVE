namespace SDVE.Conteo
{
    internal class ResultadoCandidato
    {
        public string Eleccion { get; set; } = "";
        public string Centro { get; set; } = "";
        public string Carrera { get; set; } = "";
        public string Grupo { get; set; } = "";
        public string Candidato { get; set; } = "";
        public bool Registrado { get; set; }
        public int Votos { get; set; }
    }
}

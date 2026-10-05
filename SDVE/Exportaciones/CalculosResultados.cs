using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Exportaciones
{
    public struct ResultadoCandidato
    {
        public string candidato;
        public int votos;
        public double porcentaje;
    }

    public struct DatosResultados
    {
        public int alumnosRegistrados;
        public int alumnosVotantes;
        public double participacion;
        public double abstencionismo;
        public List<ResultadoCandidato> candidatos;
    }

    internal static class CalculosResultados
    {
        public static double CalcularParticipacion(
            int registrados,
            int votantes)
        {
            if (registrados <= 0)
                return 0;

            return (double)votantes / registrados * 100;
        }

        public static double CalcularAbstencionismo(
            double participacion)
        {
            return 100 - participacion;
        }

        public static double CalcularPorcentajeCandidato(
            int votosCandidato,
            int totalVotos)
        {
            if (totalVotos <= 0)
                return 0;

            return (double)votosCandidato / totalVotos * 100;
        }

        public static int CalcularTotalVotos(
            List<ResultadoCandidato> candidatos)
        {
            int total = 0;

            foreach (ResultadoCandidato candidato in candidatos)
            {
                total += candidato.votos;
            }

            return total;
        }

        public static DatosResultados ProcesarResultados(
            int alumnosRegistrados,
            List<ResultadoCandidato> candidatos)
        {
            DatosResultados datos = new DatosResultados();

            int totalVotos = CalcularTotalVotos(candidatos);

            for (int i = 0; i < candidatos.Count; i++)
            {
                ResultadoCandidato resultado = candidatos[i];

                resultado.porcentaje =
                    CalcularPorcentajeCandidato(
                        resultado.votos,
                        totalVotos);

                candidatos[i] = resultado;
            }

            datos.alumnosRegistrados = alumnosRegistrados;
            datos.alumnosVotantes = totalVotos;

            datos.participacion =
                CalcularParticipacion(
                    alumnosRegistrados,
                    totalVotos);

            datos.abstencionismo =
                CalcularAbstencionismo(
                    datos.participacion);

            datos.candidatos = candidatos;

            return datos;
        }
    }
}
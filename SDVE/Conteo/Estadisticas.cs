using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Conteo
{

    internal class Estadisticas
    {
        public string Eleccion { get; set; } = "";
        public string Centro { get; set; } = "";
        public string Carrera { get; set; } = "";
        public string Grupo { get; set; } = "";
        public int Registrados { get; set; }
        public int Votantes { get; set; }
        public int Abstenciones { get; set; }
        public double Participacion { get; set; }
        public double Abstencionismo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Votaciones
{
    public partial class prueba : Form
    {
        public prueba()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ASOCIACIÓN ESTUDIANTIL\n" +
                "Asociación 1: " + DatosVotacion.Asociacion1 + " votos\n" +
                "Asociación 2: " + DatosVotacion.Asociacion2 + " votos\n" +
                "Asociación 3: " + DatosVotacion.Asociacion3 + " votos\n\n" +

                "CONSEJERO UNIVERSITARIO\n" +
                "Candidato 1: " + DatosVotacion.Consejero1 + " votos\n" +
                "Candidato 2: " + DatosVotacion.Consejero2 + " votos\n" +
                "Candidato 3: " + DatosVotacion.Consejero3 + " votos\n" +
                "Candidato 4: " + DatosVotacion.Consejero4 + " votos\n" +
                "Candidato 5: " + DatosVotacion.Consejero5 + " votos\n\n" +

                "REPRESENTANTE DE CARRERA\n" +
                "Candidato 1: " + DatosVotacion.Representante1 + " votos\n" +
                "Candidato 2: " + DatosVotacion.Representante2 + " votos\n" +
                "Candidato 3: " + DatosVotacion.Representante3 + " votos\n" +
                "Candidato 4: " + DatosVotacion.Representante4 + " votos\n" +
                "Candidato 5: " + DatosVotacion.Representante5 + " votos",

                "Resultados de las votaciones",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}

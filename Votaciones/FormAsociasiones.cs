using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Votaciones
{
    public partial class FormAsociasiones : Form
    {
        public bool VotoRealizado { get; private set; } = false;
        public FormAsociasiones()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormAsociasiones_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosVotacion.Asociacion1++;

            DialogResult respuesta = MessageBox.Show(
        "¿Estás seguro de votar por FEUAA?",
        "Confirmar voto",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (respuesta == DialogResult.Yes)
            {
                VotoRealizado = true;
                MessageBox.Show(
                    "Tu voto ha sido registrado.",
                    "Voto realizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information

                );

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatosVotacion.Asociacion2++;

            DialogResult respuesta = MessageBox.Show(
        "¿Estás seguro de votar por CONECTA?",
        "Confirmar voto",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (respuesta == DialogResult.Yes)
            {
                VotoRealizado = true;
                MessageBox.Show(
                    "Tu voto ha sido registrado.",
                    "Voto realizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information

                );

                this.Close();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPropuesta.Enabled = true;
            btnConfirmarPropuesta.Enabled = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            txtPropuesta.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatosVotacion.Asociacion3++;
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de votar por MUCHACHOS?",
       "Confirmar voto",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (respuesta == DialogResult.Yes)
            {
                VotoRealizado = true;
                MessageBox.Show(
                    "Tu voto ha sido registrado.",
                    "Voto realizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information

                );

                this.Close();
            }
        }

        private void btnConfirmarPropuesta_Click(object sender, EventArgs e)
        {
            DatosVotacion.PropuestasAsociacion.Add(txtPropuesta.Text);
            
            if (string.IsNullOrWhiteSpace(txtPropuesta.Text))
            {
                MessageBox.Show(
                    "Debes escribir una propuesta antes de enviarla.",
                    "Propuesta vacía",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de enviar esta propuesta como tu voto?",
                "Confirmar propuesta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                VotoRealizado = true;

                MessageBox.Show(
                    "Tu propuesta ha sido registrada.",
                    "Voto realizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
        }
    }
}

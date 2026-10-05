namespace Votaciones
{
    public partial class FormConsejero : Form
    {
        public bool VotoRealizado { get; private set; } = false;
        public FormConsejero()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPropuesta_Click(object sender, EventArgs e)
        {

            txtPropuestaConsejero.Enabled = true;
            btnEnviarPropuesta.Enabled = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            txtPropuestaConsejero.Focus();
        }

        private void btnEnviarPropuesta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPropuestaConsejero.Text))
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
                DatosVotacion.PropuestasConsejero.Add(txtPropuestaConsejero.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de votar por este candidato?",
       "Confirmar voto",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (respuesta == DialogResult.Yes)
            {

                DatosVotacion.Consejero1++;
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
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de votar por este candidato?",
       "Confirmar voto",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Consejero2++;
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de votar por este candidato?",
       "Confirmar voto",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Consejero3++;
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de votar por este candidato?",
       "Confirmar voto",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Consejero4++;
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

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
       "¿Estás seguro de votar por este candidato?",
       "Confirmar voto",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Consejero5++;
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
    }
}

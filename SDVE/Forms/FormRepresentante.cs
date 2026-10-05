namespace Votaciones
{
    public partial class FormRepresentante : Form
    {
        public bool VotoRealizado { get; private set; } = false;
        public FormRepresentante()
        {
            InitializeComponent();
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

                DatosVotacion.Representante1++;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Verificar que haya escrito una propuesta
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(
                    "Debes escribir una propuesta antes de enviarla.",
                    "Propuesta vacía",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Confirmar antes de enviar
            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de enviar esta propuesta como tu voto?",
                "Confirmar propuesta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                // Guardar la propuesta
                DatosVotacion.PropuestasRepresentante.Add(textBox1.Text);

                // Marcar que ya votó en esta categoría
                VotoRealizado = true;

                MessageBox.Show(
                    "Tu propuesta ha sido registrada.",
                    "Voto realizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Regresar al Form1
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Habilitar propuesta y botón enviar
            textBox1.Enabled = true;
            button7.Enabled = true;

            // Deshabilitar candidatos
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            // Mandar el cursor al cuadro de texto
            textBox1.Focus();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
 "¿Estás seguro de votar por este candidato?",
 "Confirmar voto",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question
);

            if (respuesta == DialogResult.Yes)
            {

                DatosVotacion.Representante2++;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
 "¿Estás seguro de votar por este candidato?",
 "Confirmar voto",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question
);

            if (respuesta == DialogResult.Yes)
            {

                DatosVotacion.Representante3++;
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
 "¿Estás seguro de votar por este candidato?",
 "Confirmar voto",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question
);

            if (respuesta == DialogResult.Yes)
            {

                DatosVotacion.Representante4++;
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
 "¿Estás seguro de votar por este candidato?",
 "Confirmar voto",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question
);

            if (respuesta == DialogResult.Yes)
            {

                DatosVotacion.Representante5++;
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

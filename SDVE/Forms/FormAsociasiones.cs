using SDVE.Datos;
using SDVE.Login;

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
            DialogResult respuesta = MessageBox.Show(
        "¿Estás seguro de votar por FEUAA?",
        "Confirmar voto",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Asociacion1++;

                RegistroVotos.RegistrarVoto(
                    "Sociedad de Alumnos",
                    Sesion.CentroActual,
                    Sesion.CarreraActual,
                    Sesion.GrupoActual,
                    "FEUAA",
                    true
                );

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
                "¿Estás seguro de votar por CONECTA?",
                "Confirmar voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Asociacion2++;

                RegistroVotos.RegistrarVoto(
                    "Sociedad de Alumnos",
                    Sesion.CentroActual,
                    Sesion.CarreraActual,
                    Sesion.GrupoActual,
                    "CONECTA",
                    true
                );

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
            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de votar por MUCHACHOS?",
                "Confirmar voto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                DatosVotacion.Asociacion3++;

                RegistroVotos.RegistrarVoto(
                    "Sociedad de Alumnos",
                    Sesion.CentroActual,
                    Sesion.CarreraActual,
                    Sesion.GrupoActual,
                    "MUCHACHOS",
                    true
                );

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
            string propuesta = txtPropuesta.Text.Trim();

            if (string.IsNullOrWhiteSpace(propuesta))
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
                DatosVotacion.PropuestasAsociacion.Add(propuesta);

                RegistroVotos.RegistrarVoto(
                    "Sociedad de Alumnos",
                    Sesion.CentroActual,
                    Sesion.CarreraActual,
                    Sesion.GrupoActual,
                    propuesta,
                    false
                );

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

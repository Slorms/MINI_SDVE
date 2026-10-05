using Login;

namespace Votaciones
{
    public partial class Form1 : Form
    {
        private bool votoAsociacion = false;
        private bool votoConsejero = false;
        private bool votoRepresentante = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAsociacion_Click(object sender, EventArgs e)
        {
            FormAsociasiones form = new FormAsociasiones();
            form.ShowDialog();

            if (form.VotoRealizado)
            {
                button1.Text = "✓ Voto realizado";
                button1.Enabled = false;

                votoAsociacion = true;
                VerificarVotacionCompleta();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormConsejero form = new FormConsejero();
            form.ShowDialog();
            if (form.VotoRealizado)
            {
                button2.Text = "✓ Voto realizado";
                button2.Enabled = false;

                votoConsejero = true;
                VerificarVotacionCompleta();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmLogin ventana = new FrmLogin();
            ventana.Show();

            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)

        {
            FormRepresentante form = new FormRepresentante();
            form.ShowDialog();
            if (form.VotoRealizado)
            {
                button3.Text = "✓ Voto realizado";
                button3.Enabled = false;

                votoRepresentante = true;
                VerificarVotacionCompleta();
            }

        }
        private void VerificarVotacionCompleta()
        {
            if (votoAsociacion && votoConsejero && votoRepresentante)
            {
                button4.Enabled = true;
            }
        }
    }
}

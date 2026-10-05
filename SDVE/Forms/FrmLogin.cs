using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            Redondear(pnlAlumno, 12);
            Redondear(pnlDocente, 12);
            Redondear(pnlAdmin, 12);

            Redondear(pnlIngreso, 12);
            Redondear(pnlAviso, 8);

            Redondear(btnIngresar, 8);
            Redondear(btnMenu, 10);

            Navegacion.Registrar(this, Rol.Alumno);

            // Botones de rol (cambia los nombres si los tuyos son distintos)
            Navegacion.ConectarRoles(this, pnlAlumno, pnlDocente, pnlAdmin);

            Validacion.LimitarADigitos(txtId, 6);
            btnIngresar.Click += btnIngresar_Click;
            AcceptButton = btnIngresar;   // Enter = Ingresar
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();

            if (!Validacion.EsNumeroValido(id, 6))
            {
                MessageBox.Show("Ingresa un ID de alumno válido (solo números, máximo 6 dígitos).",
                    "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            if (RegistroVotantes.YaIngreso(Rol.Alumno, id))
            {
                MessageBox.Show("Este ID ya ingresó al sistema. No puede volver a entrar.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtId.Clear();
                return;
            }

            RegistroVotantes.Registrar(Rol.Alumno, id);
            Sesion.RolActual = Rol.Alumno;
            Sesion.IdActual = id;
            txtId.Clear();
            Navegacion.AbrirDestino(this, Rol.Alumno);
        }

        private void Redondear(Control control, int radio)
        {
            if (control.Width <= 0 || control.Height <= 0)
                return;

            using (GraphicsPath ruta = new GraphicsPath())
            {
                int d = radio * 2;
                int w = control.Width;
                int h = control.Height;

                ruta.AddArc(0, 0, d, d, 180, 90);
                ruta.AddArc(w - d, 0, d, d, 270, 90);
                ruta.AddArc(w - d, h - d, d, d, 0, 90);
                ruta.AddArc(0, h - d, d, d, 90, 90);
                ruta.CloseFigure();

                Region anterior = control.Region;
                control.Region = new Region(ruta);
                anterior?.Dispose();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

    }
}

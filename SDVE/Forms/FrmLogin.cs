using SDVE.Datos;
using SDVE.Login;
using System.Drawing.Drawing2D;


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

            // valida que el id sea correcto
            if (!Validacion.EsNumeroValido(id, 6))
            {
                MessageBox.Show(
                    "Ingresa un ID de alumno válido (solo números, máximo 6 dígitos).",
                    "ID inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtId.Focus();
                return;
            }

            // busca al alumno en alumnos.csv
            Alumno? alumno = RegistroAlumnos.BuscarPorId(id);

            if (alumno == null)
            {
                MessageBox.Show(
                    "El ID no está registrado como alumno.",
                    "Alumno no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtId.Clear();
                txtId.Focus();
                return;
            }

            // revisa si ya ingresó anteriormente
            if (RegistroVotantes.YaIngreso(Rol.Alumno, id))
            {
                MessageBox.Show(
                    "Este ID ya ingresó al sistema. No puede volver a entrar.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                txtId.Clear();
                return;
            }

            // guarda los datos del alumno en la sesión
            Sesion.RolActual = Rol.Alumno;
            Sesion.IdActual = alumno.Id;
            Sesion.CentroActual = alumno.Centro;
            Sesion.CarreraActual = alumno.Carrera;
            Sesion.SemestreActual = alumno.Semestre;
            Sesion.GrupoActual = alumno.Grupo;

            // registra que el alumno ingresó
            RegistroVotantes.Registrar(Rol.Alumno, id);

            txtId.Clear();

            // abre el siguiente formulario
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

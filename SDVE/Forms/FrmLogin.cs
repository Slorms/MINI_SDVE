using SDVE.Datos;
using SDVE.Login;
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

            Navegacion.RegistrarLogin(this, Rol.Alumno);

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
            Alumno? alumno;
            try
            {
                alumno = RegistroAlumnos.BuscarPorId(id);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo leer el padrón",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Padrón inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (alumno == null)
            {
                MessageBox.Show(
                    "El ID ingresado no se encuentra registrado.",
                    "Alumno no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtId.Clear();
                txtId.Focus();
                return;
            }

            // Permite regresar por las elecciones activas que todavía no completó.
            bool sinPendientes;
            try
            {
                sinPendientes = RegistroParticipacion.ObtenerPendientes(Rol.Alumno, id).Count == 0;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException)
            {
                MessageBox.Show(ex.Message, "No se pudo leer la participación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sinPendientes)
            {
                MessageBox.Show(
                    "No tienes convocatorias activas pendientes de votar.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                txtId.Clear();
                return;
            }

            // guarda los datos del alumno en la sesión
            Sesion.IniciarAlumno(alumno);

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

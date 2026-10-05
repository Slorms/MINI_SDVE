using SDVE.Login;

namespace Login
{
    public partial class LoginAdmin : Form
    {
        // CAMBIA AQUI LA CONTRASEÑA DEL ADMINISTRADOR (máximo 10 dígitos)
        private const string ClaveAdmin = "123456";

        public LoginAdmin()
        {
            InitializeComponent();
            Navegacion.Registrar(this, Rol.Admin);

            Navegacion.ConectarRoles(this, pnlAlumno, pnlDocente, pnlAdmin);

            Validacion.LimitarADigitos(txtPassword, 10);
            txtPassword.UseSystemPasswordChar = true;   // oculta lo que escribe
            btnIngresar.Click += btnIngresar_Click;
            AcceptButton = btnIngresar;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string clave = txtPassword.Text.Trim();

            if (!Validacion.EsNumeroValido(clave, 10))
            {
                MessageBox.Show("Ingresa la contraseña (solo números, máximo 10 dígitos).",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (clave != ClaveAdmin)
            {
                MessageBox.Show("Contraseña incorrecta.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            Sesion.RolActual = Rol.Admin;
            Sesion.IdActual = "admin";
            txtPassword.Clear();
            Navegacion.AbrirDestino(this, Rol.Admin);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}


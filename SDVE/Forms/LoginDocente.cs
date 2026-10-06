using SDVE.Login;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginDocente : Form
    {
        public LoginDocente()
        {
            InitializeComponent();
            Navegacion.RegistrarLogin(this, Rol.Docente);

            Navegacion.ConectarRoles(this, pnlAlumno, pnlDocentes, pnlAdmin);

            Validacion.LimitarADigitos(txtId, 4);
            btnIngresar.Click += btnIngresar_Click;
            AcceptButton = btnIngresar;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();

            if (!Validacion.EsNumeroValido(id, 4))
            {
                MessageBox.Show("Ingresa un ID de docente válido (solo números, máximo 4 dígitos).",
                    "ID inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            bool sinPendientes;
            try
            {
                sinPendientes = RegistroParticipacion.ObtenerPendientes(Rol.Docente, id).Count == 0;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException)
            {
                MessageBox.Show(ex.Message, "No se pudo leer la participación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sinPendientes)
            {
                MessageBox.Show("No tienes convocatorias activas pendientes de votar.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtId.Clear();
                return;
            }

            Sesion.RolActual = Rol.Docente;
            Sesion.IdActual = id;
            Sesion.CentroActual = "";
            Sesion.CarreraActual = "";
            Sesion.SemestreActual = "";
            Sesion.GrupoActual = "";
            txtId.Clear();
            Navegacion.AbrirDestino(this, Rol.Docente);
        }
    }
}

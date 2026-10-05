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
            Navegacion.Registrar(this, Rol.Docente);

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

            if (RegistroVotantes.YaIngreso(Rol.Docente, id))
            {
                MessageBox.Show("Este ID ya ingresó al sistema. No puede volver a entrar.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtId.Clear();
                return;
            }

            RegistroVotantes.Registrar(Rol.Docente, id);
            Sesion.RolActual = Rol.Docente;
            Sesion.IdActual = id;
            txtId.Clear();
            Navegacion.AbrirDestino(this, Rol.Docente);
        }
    }
}
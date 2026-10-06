using Login;
using System;
using System.Windows.Forms;

namespace SDVE.Login
{
    public static class Navegacion
    {
        // El alumno recibe sus datos del padrón y pasa directamente a votaciones.
        public static Func<Form> FormularioAlumno =
            () => new global::Votaciones.Form1();

        public static Func<Form> FormularioDocente =
            () => new global::Votaciones.Form1();

        // Conserva aquí el destino de administrador de tu proyecto.
        public static Func<Form> FormularioAdmin =
            () => new SDVE.Forms.FrmExportaciones();

        public static Form InstAlumno;
        public static Form InstDocente;
        public static Form InstAdmin;

        public static void RegistrarLogin(Form formulario, Rol rol)
        {
            switch (rol)
            {
                case Rol.Alumno:
                    InstAlumno = formulario;
                    break;

                case Rol.Docente:
                    InstDocente = formulario;
                    break;

                case Rol.Admin:
                    InstAdmin = formulario;
                    break;
            }

            formulario.FormClosed += (s, e) =>
            {
                Application.Exit();
            };
        }

        private static Form ObtenerLogin(Rol rol)
        {
            switch (rol)
            {
                case Rol.Alumno:
                    if (InstAlumno == null || InstAlumno.IsDisposed)
                    {
                        InstAlumno = new FrmLogin();
                    }

                    return InstAlumno;

                case Rol.Docente:
                    if (InstDocente == null || InstDocente.IsDisposed)
                    {
                        InstDocente = new LoginDocente();
                    }

                    return InstDocente;

                default:
                    if (InstAdmin == null || InstAdmin.IsDisposed)
                    {
                        InstAdmin = new LoginAdmin();
                    }

                    return InstAdmin;
            }
        }

        public static void IrALogin(Form actual, Rol rol)
        {
            Form destino = ObtenerLogin(rol);

            if (ReferenceEquals(destino, actual))
            {
                return;
            }

            destino.StartPosition = FormStartPosition.Manual;
            destino.Location = actual.Location;

            actual.Hide();
            destino.Show();
        }

        public static void AbrirDestino(Form login, Rol rol)
        {
            Sesion.RolActual = rol;

            Func<Form> fabrica;

            switch (rol)
            {
                case Rol.Alumno:
                    fabrica = FormularioAlumno;
                    break;

                case Rol.Docente:
                    fabrica = FormularioDocente;
                    break;

                default:
                    fabrica = FormularioAdmin;
                    break;
            }

            Form destino = fabrica();

            destino.FormClosed += (s, e) =>
            {
                if (!login.IsDisposed)
                {
                    login.Show();
                }
            };

            login.Hide();

            try
            {
                destino.Show();
            }
            catch
            {
                destino.Dispose();

                if (!login.IsDisposed)
                {
                    login.Show();
                }

                throw;
            }
        }

        // Abre el reporte final.
        // Al cerrar el siguiente formulario, vuelve al anterior.
        public static void Abrir(Form actual, Form siguiente)
        {
            actual.Hide();

            try
            {
                using (siguiente)
                {
                    siguiente.ShowDialog();
                }
            }
            finally
            {
                if (!actual.IsDisposed)
                {
                    actual.Show();
                }
            }
        }

        public static void ConectarRoles(
            Form actual,
            Control pnlAlumno,
            Control pnlDocente,
            Control pnlAdmin)
        {
            Enlazar(
                pnlAlumno,
                () => IrALogin(actual, Rol.Alumno));

            Enlazar(
                pnlDocente,
                () => IrALogin(actual, Rol.Docente));

            Enlazar(
                pnlAdmin,
                () => IrALogin(actual, Rol.Admin));
        }

        private static void Enlazar(Control control, Action accion)
        {
            control.Cursor = Cursors.Hand;
            control.Click += (s, e) => accion();

            foreach (Control hijo in control.Controls)
            {
                Enlazar(hijo, accion);
            }
        }
    }

    public static class Validacion
    {
        public static void LimitarADigitos(TextBox txt, int max)
        {
            txt.MaxLength = max;

            txt.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar)
                    && (e.KeyChar < '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            };

            txt.TextChanged += (s, e) =>
            {
                string limpio = string.Concat(
                    Array.FindAll(
                        txt.Text.ToCharArray(),
                        ch => ch >= '0' && ch <= '9'));

                if (limpio.Length > max)
                {
                    limpio = limpio.Substring(0, max);
                }

                if (limpio != txt.Text)
                {
                    txt.Text = limpio;
                    txt.SelectionStart = txt.Text.Length;
                }
            };
        }

        public static bool EsNumeroValido(string texto, int max)
        {
            if (string.IsNullOrWhiteSpace(texto)
                || texto.Length > max)
            {
                return false;
            }

            foreach (char caracter in texto)
            {
                if (caracter < '0' || caracter > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}

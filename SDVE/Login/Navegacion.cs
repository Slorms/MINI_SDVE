using Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDVE.Login
{ 
        public enum Rol { Alumno, Docente, Admin }

        // Datos de quien acaba de entrar (por si los formularios de tus compañeros los necesitan)
        public static class Sesion
        {
            public static Rol RolActual { get; set; }
            public static string IdActual { get; set; }  = "";
        }

        public static class Navegacion
        {
            // =====================================================================
            //  AQUI SE CONECTAN LOS FORMULARIOS DE TUS COMPAÑEROS
            //  Solo cambien "new FormPendiente(...)" por "new SuFormulario()"
            // =====================================================================
            public static Func<Form> FormularioAlumno = () => new FrmLogin();
        public static Func<Form> FormularioDocente = () => new LoginDocente();
        public static Func<Form> FormularioAdmin = () => new LoginAdmin();
        // Ejemplo:  public static Func<Form> FormularioAdmin = () => new FrmConteo();
        // =====================================================================

        // Instancias de los 3 logins (cada uno se registra solo al crearse)
        public static Form InstAlumno, InstDocente, InstAdmin;

            public static void Registrar(Form f, Rol rol)
            {
                if (rol == Rol.Alumno) InstAlumno = f;
                else if (rol == Rol.Docente) InstDocente = f;
                else InstAdmin = f;
                f.FormClosed += (s, e) => Application.Exit();   // cerrar con la X cierra todo
            }

            static Form ObtenerLogin(Rol rol)
            {
                switch (rol)
                {
                    case Rol.Alumno:
                        if (InstAlumno == null || InstAlumno.IsDisposed) new FrmLogin();
                        return InstAlumno;
                    case Rol.Docente:
                        if (InstDocente == null || InstDocente.IsDisposed) new LoginDocente();
                        return InstDocente;
                    default:
                        if (InstAdmin == null || InstAdmin.IsDisposed) new LoginAdmin();
                        return InstAdmin;
                }
            }

            // Cambia de un login a otro (botones Alumno / Docente / Administrador)
            public static void IrALogin(Form actual, Rol rol)
            {
                Form destino = ObtenerLogin(rol);
                if (ReferenceEquals(destino, actual)) return;
                destino.StartPosition = FormStartPosition.Manual;
                destino.Location = actual.Location;
                actual.Hide();
                destino.Show();
            }

            // Despues de validar el ID/contraseña: abre el formulario del modulo
            public static void AbrirDestino(Form login, Rol rol)
            {
                Func<Form> fabrica = rol == Rol.Alumno ? FormularioAlumno
                                   : rol == Rol.Docente ? FormularioDocente
                                   : FormularioAdmin;
                Form destino = fabrica();
                destino.FormClosed += (s, e) => { if (!login.IsDisposed) login.Show(); };
                login.Hide();
                destino.Show();
            }

            // Hace que los 3 botones de rol funcionen (incluye los controles que tengan dentro)
            public static void ConectarRoles(Form actual, Control pnlAlumno, Control pnlDocente, Control pnlAdmin)
            {
                Enlazar(pnlAlumno, () => IrALogin(actual, Rol.Alumno));
                Enlazar(pnlDocente, () => IrALogin(actual, Rol.Docente));
                Enlazar(pnlAdmin, () => IrALogin(actual, Rol.Admin));
            }

            static void Enlazar(Control c, Action accion)
            {
                c.Cursor = Cursors.Hand;
                c.Click += (s, e) => accion();
                foreach (Control hijo in c.Controls) Enlazar(hijo, accion);
            }
        }

        public static class Validacion
        {
            // Solo deja escribir numeros y limita la longitud
            public static void LimitarADigitos(TextBox txt, int max)
            {
                txt.MaxLength = max;
                txt.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && (e.KeyChar < '0' || e.KeyChar > '9'))
                        e.Handled = true;
                };
                txt.TextChanged += (s, e) =>   // por si pegan texto con letras
                {
                    string limpio = string.Concat(Array.FindAll(txt.Text.ToCharArray(), ch => ch >= '0' && ch <= '9'));
                    if (limpio != txt.Text) { txt.Text = limpio; txt.SelectionStart = txt.Text.Length; }
                };
            }

            public static bool EsNumeroValido(string texto, int max)
            {
                if (string.IsNullOrWhiteSpace(texto) || texto.Length > max) return false;
                foreach (char c in texto) if (c < '0' || c > '9') return false;
                return true;
            }
        }
        
    }


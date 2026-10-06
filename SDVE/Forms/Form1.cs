using SDVE.Datos;
using SDVE.Forms;
using SDVE.Login;
using SDVE.Votaciones;

namespace Votaciones;

public partial class Form1 : Form
{
    private readonly Dictionary<string, Button> convocatorias = new();
    private readonly HashSet<string> disponibles = new();
    private readonly HashSet<string> activas = new();
    private bool confirmado;

    public Form1()
    {
        InitializeComponent();
        DatosVotacion.IniciarPapeleta();
        var botones = new[] { button1, button2, button3 };
        for (int i = 0; i < CatalogoElecciones.Nombres.Length; i++)
            convocatorias.Add(CatalogoElecciones.Nombres[i], botones[i]);
        FormClosing += (_, e) =>
        {
            if (!confirmado && convocatorias.Keys.Any(DatosVotacion.TieneVoto)
                && MessageBox.Show("¿Descartar las selecciones pendientes? No se registrará ningún voto.",
                    "Cancelar votación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        };
        FormClosed += (_, _) => DatosVotacion.LimpiarVotosSesion();
        ActualizarEstado();
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        try
        {
            activas.UnionWith(CatalogoElecciones.ObtenerActivas());
            disponibles.UnionWith(RegistroParticipacion.ObtenerPendientes(Sesion.RolActual, Sesion.IdActual));
            ActualizarEstado();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException)
        {
            MessageBox.Show(ex.Message, "No se pudieron cargar las convocatorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }

    private void AlternarConvocatoria(string eleccion)
    {
        if (confirmado || !disponibles.Contains(eleccion)) return;
        try
        {
            DatosVotacion.Seleccionar(eleccion, !DatosVotacion.EstaSeleccionada(eleccion));
            ActualizarEstado();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException or InvalidOperationException)
        {
            MessageBox.Show(ex.Message, "Convocatoria no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ActualizarEstado()
    {
        int seleccionadas = 0, completas = 0;
        foreach (var (nombre, boton) in convocatorias)
        {
            bool seleccionada = DatosVotacion.EstaSeleccionada(nombre);
            bool listo = DatosVotacion.TieneVoto(nombre);
            boton.Enabled = !confirmado && disponibles.Contains(nombre);
            boton.BackColor = seleccionada ? Color.FromArgb(18, 63, 115) : Color.White;
            boton.ForeColor = seleccionada ? Color.White : Color.FromArgb(18, 63, 115);
            boton.FlatAppearance.BorderSize = seleccionada ? 2 : 1;
            boton.FlatAppearance.BorderColor = seleccionada ? Color.FromArgb(18, 63, 115) : Color.FromArgb(184, 197, 214);
            boton.FlatAppearance.MouseOverBackColor = seleccionada ? Color.FromArgb(25, 80, 140) : Color.FromArgb(235, 242, 250);
            boton.FlatAppearance.MouseDownBackColor = seleccionada ? Color.FromArgb(10, 45, 90) : Color.FromArgb(215, 229, 244);
            boton.Text = seleccionada ? nombre + (listo ? "\n✓ Papeleta completa" : "\n✓ Seleccionada")
                : nombre + (!boton.Enabled ? (activas.Contains(nombre) ? "\nYa participaste" : "\nInactiva") : "");
            boton.AccessibleName = nombre;
            boton.AccessibleDescription = seleccionada ? "Seleccionada. Pulsa para deseleccionar y descartar su papeleta pendiente."
                : boton.Enabled ? "Pulsa para seleccionar esta convocatoria." : "Convocatoria no disponible.";
            if (seleccionada) seleccionadas++;
            if (listo) completas++;
        }
        button4.Enabled = !confirmado && seleccionadas > 0;
        lblEstado.Text = $"Convocatorias seleccionadas: {seleccionadas}. Papeletas completas: {completas}.\n"
            + "Otro clic deselecciona. Los votos se guardan después de completar las papeletas y confirmar.";
    }

    private void button4_Click(object? sender, EventArgs e)
    {
        if (confirmado) return;
        var seleccionadas = convocatorias.Keys.Where(DatosVotacion.EstaSeleccionada).ToList();
        if (seleccionadas.Count == 0) return;
        try
        {
            foreach (string eleccion in seleccionadas.Where(e => !DatosVotacion.TieneVoto(e)))
            {
                using var papeleta = new FrmPapeleta(eleccion);
                DialogResult resultado = papeleta.ShowDialog(this);
                ActualizarEstado();
                if (resultado != DialogResult.OK) return;
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException or ArgumentException or InvalidOperationException)
        {
            MessageBox.Show(ex.Message, "No se pudo completar la papeleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (!DatosVotacion.PuedeConfirmar) return;
        string elecciones = string.Join("\n", seleccionadas.Select(e => "• " + e));
        if (MessageBox.Show("¿Confirmar tus votos para estas convocatorias?\n\n" + elecciones,
            "Confirmar envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try
        {
            DatosVotacion.Confirmar();
            confirmado = true;
            button4.Enabled = false;
            foreach (var boton in convocatorias.Values) boton.Enabled = false;
            btnCancelar.Enabled = false;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidDataException or InvalidOperationException or ArgumentException)
        {
            MessageBox.Show(ex.Message, "No se pudo confirmar la votación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        MessageBox.Show("Tus votos se guardaron correctamente.", "Votación confirmada");
        Navegacion.Abrir(this, new FrmExportaciones());
        Close();
    }

    private void btnAsociacion_Click(object? sender, EventArgs e) => AlternarConvocatoria("Sociedad de Alumnos");
    private void button2_Click(object? sender, EventArgs e) => AlternarConvocatoria("Consejo Universitario");
    private void button3_Click(object? sender, EventArgs e) => AlternarConvocatoria("Consejo de Representantes");
    private void btnCancelar_Click(object? sender, EventArgs e) => Close();
}

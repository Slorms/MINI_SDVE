using SDVE.Datos;
using SDVE.Votaciones;

namespace SDVE.Forms;

internal sealed class FrmPapeleta : Form
{
    public FrmPapeleta(string eleccion)
    {
        Text = eleccion;
        StartPosition = FormStartPosition.CenterParent;
        ClientSize = new Size(620, 490);
        MinimumSize = new Size(540, 450);
        var opciones = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown,
            WrapContents = false, AutoScroll = true, Padding = new Padding(20)
        };
        opciones.Controls.Add(new Label
        {
            Text = "Selecciona una candidatura. Tu voto se confirma al pulsar Enviar.",
            AutoSize = true, Margin = new Padding(0, 0, 0, 20)
        });
        var oficiales = new List<RadioButton>();
        foreach (string candidato in CatalogoElecciones.ObtenerCandidatos(eleccion))
        {
            var opcion = new RadioButton { Text = candidato, AutoSize = true, Margin = new Padding(0, 7, 0, 7) };
            oficiales.Add(opcion);
            opciones.Controls.Add(opcion);
        }
        var otra = new RadioButton { Text = "Candidato no registrado (escribe su nombre)", AutoSize = true, Margin = new Padding(0, 15, 0, 5) };
        var propuesta = new TextBox { Width = 460, MaxLength = 120, Enabled = false };
        otra.CheckedChanged += (_, _) => { propuesta.Enabled = otra.Checked; if (otra.Checked) propuesta.Focus(); };
        opciones.Controls.Add(otra);
        opciones.Controls.Add(propuesta);

        var acciones = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom, Height = 65, FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(10)
        };
        var guardar = new Button { Text = "Guardar selección", AutoSize = true, Height = 35 };
        var cancelar = new Button { Text = "Cancelar", AutoSize = true, Height = 35, DialogResult = DialogResult.Cancel };
        acciones.Controls.Add(guardar);
        acciones.Controls.Add(cancelar);
        guardar.Click += (_, _) =>
        {
            RadioButton? oficial = oficiales.FirstOrDefault(o => o.Checked);
            if (oficial == null && !otra.Checked)
            {
                MessageBox.Show("Selecciona un candidato o escribe uno no registrado.", "Papeleta incompleta");
                return;
            }
            try
            {
                DatosVotacion.RegistrarVoto(eleccion, otra.Checked ? propuesta.Text : oficial!.Text, !otra.Checked);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidDataException or InvalidOperationException or IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(ex.Message, "No se pudo guardar la selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        };
        Controls.Add(opciones);
        Controls.Add(acciones);
        AcceptButton = guardar;
        CancelButton = cancelar;
    }
}

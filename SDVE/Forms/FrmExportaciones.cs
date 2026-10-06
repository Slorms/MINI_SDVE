using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using SDVE.Votaciones;
using SDVE.Datos;
using SDVE.Conteo;

namespace SDVE.Forms
{
    public partial class FrmExportaciones : Form
    {
        // =========================================================
        // VARIABLES
        // =========================================================
        private bool hayResultados = false;

        private string convocatoriaSeleccionada = "Sociedad de Alumnos";
        private string tipoVistaSeleccionada = "General";
        private bool actualizandoFiltros;
        private List<Alumno> alumnosPadron = new();
        private SDVE.Conteo.ProcesadorVotos procesadorVotos =
            new SDVE.Conteo.ProcesadorVotos();        // Colores para la gráfica
        private List<SDVE.Conteo.ResultadoCandidato> resultadosConteoActuales =
    new List<SDVE.Conteo.ResultadoCandidato>();
        private readonly Color[] coloresGrafica =
        {
            Color.FromArgb(45, 137, 220),
            Color.FromArgb(67, 190, 145),
            Color.FromArgb(255, 174, 50),
            Color.FromArgb(126, 76, 190),
            Color.FromArgb(230, 80, 130),
            Color.FromArgb(80, 170, 210),
            Color.FromArgb(120, 180, 80)
        };


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public FrmExportaciones()
        {
            InitializeComponent();
            pictureBox15.Parent = button1;
            pictureBox17.Parent = btnConsejo;
            pictureBox16.Parent = btnRepresentantes;
            pictureBox15.Location = new Point(12, (button1.Height - pictureBox15.Height) / 2);

            pictureBox17.Location = new Point(12, (btnConsejo.Height - pictureBox17.Height) / 2);

            pictureBox16.Location = new Point(12, (btnRepresentantes.Height - pictureBox16.Height) / 2);

            pictureBox15.BackColor = Color.Transparent;
            pictureBox17.BackColor = Color.Transparent;
            pictureBox16.BackColor = Color.Transparent;
            ConfigurarFormulario();
            ConfigurarEventos();
            ConfigurarMenuExportacion();
            ActualizarResultadosDeVotacion();
        }
        // =========================================================
        // CONFIGURACIÓN INICIAL
        // =========================================================

        private void ConfigurarFormulario()
        {
            // Valores iniciales
            lblNumRegistro.Text = "--";
            lblNumVotantes.Text = "--";
            label3.Text = "--%";
            label4.Text = "--%";

            dgvResultados.Rows.Clear();

            // Selecciones iniciales
            SeleccionarConvocatoria(button1);
            SeleccionarTipoVista(btnGeneral);

            // Para que la gráfica se redibuje cuando cambie de tamaño
            pnlDona.Resize += (s, e) =>
            {
                if (hayResultados)
                    pnlDona.Invalidate();
            };

            pnlLeyenda.Resize += (s, e) =>
            {
                if (hayResultados &&
                    resultadosConteoActuales.Count > 0)
                {
                    CrearLeyendaConteo();
                }
            };
            // La primera opción significa que no hay restricción para ese campo.
            cmbCentro.Items.Clear();
            cmbCentro.Items.Add("Todos");
            cmbCentro.SelectedIndex = 0;
            cmbCarrera.Items.Clear();
            cmbCarrera.Items.Add("Todas");
            cmbCarrera.SelectedIndex = 0;
            cmbGrupo.Items.Clear();
            cmbGrupo.Items.Add("Todos");
            cmbGrupo.SelectedIndex = 0;
        }


        // =========================================================
        // EVENTOS
        // =========================================================

        private void ConfigurarEventos()
        {

            // Convocatorias
            button1.Click += button1_Click;
            btnConsejo.Click += btnConsejo_Click;
            btnRepresentantes.Click += btnRepresentantes_Click;

            // Tipo de vista
            btnGeneral.Click += btnGeneral_Click;
            btnVistaCarrera.Click += btnVistaCarrera_Click;
            btnVistaGrupo.Click += btnVistaGrupo_Click;
            btnVistaCentro.Click += btnVistaCentro_Click;

            // Filtros
            cmbCentro.SelectedIndexChanged += cmbCentro_SelectedIndexChanged;
            cmbCarrera.SelectedIndexChanged += cmbCarrera_SelectedIndexChanged;
            cmbGrupo.SelectedIndexChanged += cmbGrupo_SelectedIndexChanged;

            // Acciones
            btnProcesarResultados.Click += btnProcesarResultados_Click;
            btnDetalleCandidatura.Click += btnDetalleCandidatura_Click;
            btnParticipacionGrupo.Click += btnParticipacionGrupo_Click;
            btnExportarResultados.Click += btnExportarResultados_Click;

            // Gráfica
            pnlDona.Paint += pnlDona_Paint;
        }
        private void cmbCentro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (actualizandoFiltros)
                return;
            actualizandoFiltros = true;
            try
            {
                CargarCarreras();
                CargarGrupos();
            }
            finally { actualizandoFiltros = false; }
            ActualizarTipoVista();
            ActualizarResultadosDeVotacion();
        }

        private void cmbCarrera_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (actualizandoFiltros)
                return;
            actualizandoFiltros = true;
            try { CargarGrupos(); }
            finally { actualizandoFiltros = false; }
            ActualizarTipoVista();
            ActualizarResultadosDeVotacion();
        }

        private void cmbGrupo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (actualizandoFiltros)
                return;
            ActualizarTipoVista();
            ActualizarResultadosDeVotacion();
        }

        private static string? ValorFiltro(ComboBox control) =>
            control.SelectedIndex <= 0 ? null : control.SelectedItem?.ToString();

        private static void LlenarFiltro(ComboBox control, string todos, IEnumerable<string> valores)
        {
            control.Items.Clear();
            control.Items.Add(todos);
            control.Items.AddRange(valores.Distinct().OrderBy(v => v).Cast<object>().ToArray());
            control.SelectedIndex = 0;
        }

        private void CargarCarreras()
        {
            string? centro = ValorFiltro(cmbCentro);
            LlenarFiltro(cmbCarrera, "Todas", alumnosPadron
                .Where(a => centro == null || a.Centro == centro).Select(a => a.Carrera));
        }

        private void CargarGrupos()
        {
            string? centro = ValorFiltro(cmbCentro);
            string? carrera = ValorFiltro(cmbCarrera);
            LlenarFiltro(cmbGrupo, "Todos", alumnosPadron
                .Where(a => (centro == null || a.Centro == centro)
                    && (carrera == null || a.Carrera == carrera)).Select(a => a.Grupo));
        }

        private void ActualizarTipoVista()
        {
            if (ValorFiltro(cmbGrupo) != null)
            {
                tipoVistaSeleccionada = "Grupo";
                SeleccionarTipoVista(btnVistaGrupo);
            }
            else if (ValorFiltro(cmbCarrera) != null)
            {
                tipoVistaSeleccionada = "Carrera";
                SeleccionarTipoVista(btnVistaCarrera);
            }
            else if (ValorFiltro(cmbCentro) != null)
            {
                tipoVistaSeleccionada = "Centro";
                SeleccionarTipoVista(btnVistaCentro);
            }
            else
            {
                tipoVistaSeleccionada = "General";
                SeleccionarTipoVista(btnGeneral);
            }
        }


        // =========================================================
        // CONVOCATORIAS
        // =========================================================

        private void button1_Click(object sender, EventArgs e)
        {
            convocatoriaSeleccionada = "Sociedad de Alumnos";
            SeleccionarConvocatoria(button1);
            ActualizarResultadosDeVotacion();
        }

        private void btnConsejo_Click(object sender, EventArgs e)
        {
            convocatoriaSeleccionada = "Consejo Universitario";
            SeleccionarConvocatoria(btnConsejo);
            ActualizarResultadosDeVotacion();
        }

        private void btnRepresentantes_Click(object sender, EventArgs e)
        {
            convocatoriaSeleccionada = "Consejo de Representantes";
            SeleccionarConvocatoria(btnRepresentantes);
            ActualizarResultadosDeVotacion();
        }

        private bool ActualizarResultadosDeVotacion()
        {
            hayResultados = false;
            try
            {
                if (alumnosPadron.Count == 0)
                {
                    alumnosPadron = RegistroAlumnos.ObtenerTodos();
                    actualizandoFiltros = true;
                    try
                    {
                        LlenarFiltro(cmbCentro, "Todos", alumnosPadron.Select(a => a.Centro));
                        CargarCarreras();
                        CargarGrupos();
                    }
                    finally { actualizandoFiltros = false; }
                }
                string? centro = ValorFiltro(cmbCentro);
                string? carrera = ValorFiltro(cmbCarrera);
                string? grupo = ValorFiltro(cmbGrupo);
                CargarResultadosConteo(
                    ConsultaResultados.ObtenerAlumnos(centro, carrera, grupo).Count,
                    DatosVotacion.ObtenerResultados(convocatoriaSeleccionada, centro, carrera, grupo));
                return hayResultados;
            }
            catch (Exception ex) when (ex is IOException || ex is InvalidDataException
                || ex is UnauthorizedAccessException || ex is ArgumentException)
            {
                dgvResultados.Rows.Clear();
                pnlLeyenda.Controls.Clear();
                lblNumRegistro.Text = "--";
                lblNumVotantes.Text = "--";
                label3.Text = "--%";
                label4.Text = "--%";
                pnlDona.Invalidate();
                MessageBox.Show(
                    "No fue posible cargar los resultados.\n\n" + ex.Message,
                    "Error al cargar resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }


        private void SeleccionarConvocatoria(Button seleccionado)
        {
            Button[] botones =
            {
                button1,
                btnConsejo,
                btnRepresentantes
            };

            foreach (Button boton in botones)
            {
                boton.BackColor = Color.White;
                boton.ForeColor = Color.FromArgb(30, 50, 80);

                boton.FlatAppearance.BorderColor =
                    Color.FromArgb(212, 220, 231);

                boton.FlatAppearance.MouseOverBackColor =
                    Color.FromArgb(228, 235, 244);

                boton.FlatAppearance.MouseDownBackColor =
                    Color.FromArgb(207, 219, 235);
            }

            seleccionado.BackColor =
                Color.FromArgb(49, 88, 137);

            seleccionado.ForeColor = Color.White;

            seleccionado.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(36, 68, 109);

            seleccionado.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(36, 68, 109);
        }
        // =========================================================
        // TIPO DE VISTA
        // =========================================================

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            actualizandoFiltros = true;
            try
            {
                cmbCentro.SelectedIndex = 0;
                CargarCarreras();
                CargarGrupos();
            }
            finally { actualizandoFiltros = false; }
            tipoVistaSeleccionada = "General";
            SeleccionarTipoVista(btnGeneral);
            ActualizarResultadosDeVotacion();
        }

        private void btnVistaCarrera_Click(object sender, EventArgs e)
        {
            actualizandoFiltros = true;
            try { cmbGrupo.SelectedIndex = 0; }
            finally { actualizandoFiltros = false; }
            tipoVistaSeleccionada = "Carrera";
            SeleccionarTipoVista(btnVistaCarrera);
            ActualizarResultadosDeVotacion();
        }

        private void btnVistaGrupo_Click(object sender, EventArgs e)
        {
            tipoVistaSeleccionada = "Grupo";
            SeleccionarTipoVista(btnVistaGrupo);
            ActualizarResultadosDeVotacion();
        }

        private void btnVistaCentro_Click(object sender, EventArgs e)
        {
            actualizandoFiltros = true;
            try
            {
                cmbCarrera.SelectedIndex = 0;
                CargarGrupos();
            }
            finally { actualizandoFiltros = false; }
            tipoVistaSeleccionada = "Centro";
            SeleccionarTipoVista(btnVistaCentro);
            ActualizarResultadosDeVotacion();
        }


        private void SeleccionarTipoVista(Button seleccionado)
        {
            Button[] botones =
            {
                btnGeneral,
                btnVistaCarrera,
                btnVistaGrupo,
                btnVistaCentro
            };

            foreach (Button boton in botones)
            {
                boton.BackColor = Color.White;
                boton.ForeColor = Color.FromArgb(30, 50, 80);

                boton.FlatAppearance.BorderColor =
                    Color.FromArgb(212, 220, 231);

                boton.FlatAppearance.MouseOverBackColor =
                    Color.FromArgb(228, 235, 244);

                boton.FlatAppearance.MouseDownBackColor =
                    Color.FromArgb(207, 219, 235);
            }

            seleccionado.BackColor =
                Color.FromArgb(49, 88, 137);

            seleccionado.ForeColor = Color.White;

            seleccionado.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(36, 68, 109);

            seleccionado.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(36, 68, 109);
        }


        // =========================================================
        // RECIBIR RESULTADOS
        // =========================================================

        internal void CargarResultadosConteo(
    int alumnosRegistrados,
    List<SDVE.Conteo.ResultadoCandidato> resultadosConteo)
        {
            try
            {
                if (resultadosConteo == null)
                {
                    MessageBox.Show(
                        "No se recibieron resultados.",
                        "Resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // Usamos el procesador del módulo de Conteo
                resultadosConteoActuales =
                    procesadorVotos.ContarVotos(resultadosConteo);

                int totalVotos = 0;

                foreach (SDVE.Conteo.ResultadoCandidato resultado
                         in resultadosConteoActuales)
                {
                    totalVotos += resultado.Votos;
                }

                // Calcular estadísticas
                SDVE.Conteo.Estadisticas estadisticas =
                    procesadorVotos.CalcularEstadisticas(
                        alumnosRegistrados,
                        SDVE.Login.RegistroParticipacion.ContarAlumnos(
                            convocatoriaSeleccionada, ConsultaResultados.ObtenerAlumnos(
                                ValorFiltro(cmbCentro), ValorFiltro(cmbCarrera), ValorFiltro(cmbGrupo))));

                // Tarjetas
                lblNumRegistro.Text =
                    estadisticas.Registrados.ToString();

                lblNumVotantes.Text =
                    estadisticas.Votantes.ToString();

                label3.Text =
                    estadisticas.Participacion.ToString("0.0") + "%";

                label4.Text =
                    estadisticas.Abstencionismo.ToString("0.0") + "%";

                // Tabla
                dgvResultados.Rows.Clear();

                foreach (SDVE.Conteo.ResultadoCandidato resultado
                         in resultadosConteoActuales)
                {
                    double porcentaje =
                        procesadorVotos.CalcularPorcentaje(
                            resultado.Votos,
                            totalVotos);

                    dgvResultados.Rows.Add(
                        resultado.Candidato,
                        resultado.Votos,
                        porcentaje.ToString("0.0") + "%"
                    );
                }

                dgvResultados.ClearSelection();

                // Indicar que ya existen resultados
                hayResultados = true;

                // Actualizar gráfica y leyenda
                pnlDona.Invalidate();
                CrearLeyendaConteo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible procesar los resultados.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        // =========================================================
        // GRÁFICA DINÁMICA
        // =========================================================

        private void pnlDona_Paint(object sender, PaintEventArgs e)
        {
            if (!hayResultados)
                return;

            if (resultadosConteoActuales == null ||
                resultadosConteoActuales.Count == 0)
                return;

            int totalVotos = 0;

            foreach (SDVE.Conteo.ResultadoCandidato resultado
                     in resultadosConteoActuales)
            {
                totalVotos += resultado.Votos;
            }

            if (totalVotos <= 0)
                return;

            Graphics g = e.Graphics;

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            int margen = 8;

            int tamaño =
                Math.Min(
                    pnlDona.ClientSize.Width,
                    pnlDona.ClientSize.Height)
                - (margen * 2);

            if (tamaño <= 0)
                return;

            Rectangle rectangulo =
                new Rectangle(
                    (pnlDona.ClientSize.Width - tamaño) / 2,
                    (pnlDona.ClientSize.Height - tamaño) / 2,
                    tamaño,
                    tamaño);

            float anguloInicial = -90f;

            for (int i = 0;
                 i < resultadosConteoActuales.Count;
                 i++)
            {
                SDVE.Conteo.ResultadoCandidato resultado =
                    resultadosConteoActuales[i];

                float angulo =
                    (float)resultado.Votos /
                    totalVotos *
                    360f;

                using (SolidBrush brocha =
                       new SolidBrush(
                           coloresGrafica[
                               i % coloresGrafica.Length]))
                {
                    g.FillPie(
                        brocha,
                        rectangulo,
                        anguloInicial,
                        angulo);
                }

                anguloInicial += angulo;
            }

            // Centro blanco para convertirla en dona
            int tamañoCentro =
                (int)(tamaño * 0.48);

            Rectangle centro =
                new Rectangle(
                    rectangulo.X +
                        (tamaño - tamañoCentro) / 2,

                    rectangulo.Y +
                        (tamaño - tamañoCentro) / 2,

                    tamañoCentro,
                    tamañoCentro);

            using (SolidBrush brochaCentro =
                   new SolidBrush(Color.White))
            {
                g.FillEllipse(
                    brochaCentro,
                    centro);
            }
        }

        // =========================================================
        // LEYENDA DE LA GRÁFICA
        // =========================================================

        private void CrearLeyendaConteo()
        {
            pnlLeyenda.Controls.Clear();

            if (resultadosConteoActuales == null ||
                resultadosConteoActuales.Count == 0)
                return;

            int totalVotos = 0;

            foreach (SDVE.Conteo.ResultadoCandidato resultado
                     in resultadosConteoActuales)
            {
                totalVotos += resultado.Votos;
            }

            int y = 5;

            for (int i = 0;
                 i < resultadosConteoActuales.Count;
                 i++)
            {
                SDVE.Conteo.ResultadoCandidato resultado =
                    resultadosConteoActuales[i];

                Panel color = new Panel();

                color.BackColor =
                    coloresGrafica[
                        i % coloresGrafica.Length];

                color.Size =
                    new Size(12, 12);

                color.Location =
                    new Point(3, y + 4);


                Label texto = new Label();

                texto.AutoSize = false;

                texto.Location =
                    new Point(20, y);

                texto.Size =
                    new Size(
                        Math.Max(
                            90,
                            pnlLeyenda.ClientSize.Width - 25),
                        35);

                texto.Font =
                    new Font(
                        "Segoe UI",
                        7.5F,
                        FontStyle.Regular);

                texto.ForeColor =
                    Color.FromArgb(50, 60, 75);

                double porcentaje =
                    procesadorVotos.CalcularPorcentaje(
                        resultado.Votos,
                        totalVotos);

                texto.Text =
                    resultado.Candidato +
                    Environment.NewLine +
                    porcentaje.ToString("0.0") +
                    "%";

                pnlLeyenda.Controls.Add(color);
                pnlLeyenda.Controls.Add(texto);

                y += 40;
            }
        }


        // =========================================================
        // BOTÓN PROCESAR RESULTADOS
        // =========================================================

        private void btnProcesarResultados_Click(
     object sender,
     EventArgs e)
        {
            if (!ActualizarResultadosDeVotacion())
                return;

            MessageBox.Show(
                "Los resultados se procesaron correctamente.",
                "Resultados",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // DETALLE POR CANDIDATURA
        // =========================================================

        private void btnDetalleCandidatura_Click(
    object sender,
    EventArgs e)
        {
            if (!hayResultados ||
                resultadosConteoActuales == null ||
                resultadosConteoActuales.Count == 0)
            {
                MessageBox.Show(
                    "No hay resultados disponibles.",
                    "Detalle por candidatura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int totalVotos = 0;

            foreach (SDVE.Conteo.ResultadoCandidato resultado
                     in resultadosConteoActuales)
            {
                totalVotos += resultado.Votos;
            }

            StringBuilder detalle =
                new StringBuilder();

            detalle.AppendLine(convocatoriaSeleccionada);
            detalle.AppendLine();

            foreach (SDVE.Conteo.ResultadoCandidato resultado
                     in resultadosConteoActuales)
            {
                double porcentaje =
                    procesadorVotos.CalcularPorcentaje(
                        resultado.Votos,
                        totalVotos);

                detalle.AppendLine(
                    resultado.Candidato +
                    ": " +
                    resultado.Votos +
                    " votos (" +
                    porcentaje.ToString("0.0") +
                    "%)");
            }

            MessageBox.Show(
                detalle.ToString(),
                "Detalle por candidatura",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // PARTICIPACIÓN POR GRUPO
        // =========================================================

        private void btnParticipacionGrupo_Click(
            object sender,
            EventArgs e)
        {
            if (!ActualizarResultadosDeVotacion())
                return;

            List<Estadisticas> grupos = ConsultaResultados.ObtenerParticipacionPorGrupo(
                convocatoriaSeleccionada, ValorFiltro(cmbCentro), ValorFiltro(cmbCarrera), ValorFiltro(cmbGrupo));
            var contenido = new StringBuilder();
            contenido.AppendLine(convocatoriaSeleccionada);
            contenido.AppendLine();
            foreach (Estadisticas grupo in grupos)
            {
                contenido.AppendLine(grupo.Centro);
                contenido.AppendLine(grupo.Carrera + " — Grupo " + grupo.Grupo);
                contenido.AppendLine($"Registrados: {grupo.Registrados} | Votantes: {grupo.Votantes} | Abstenciones: {grupo.Abstenciones}");
                contenido.AppendLine($"Participación: {grupo.Participacion:0.0}% | Abstencionismo: {grupo.Abstencionismo:0.0}%");
                contenido.AppendLine();
            }
            if (grupos.Count == 0)
                contenido.AppendLine("No hay alumnos del padrón con estos filtros.");

            using var reporte = new Form
            {
                Text = "Participación por grupo",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(900, 550)
            };
            reporte.Controls.Add(new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Text = contenido.ToString()
            });
            reporte.ShowDialog(this);
        }


        // =========================================================
        // MENÚ DE EXPORTACIÓN
        // =========================================================

        private void ConfigurarMenuExportacion()
        {
            // El Designer tenía PDF y Excel.
            // Aquí usamos los formatos requeridos:
            // CSV, JSON y XML.

            cmsExportar.Items.Clear();

            ToolStripMenuItem itemCSV =
                new ToolStripMenuItem(
                    "Exportar como CSV");

            ToolStripMenuItem itemJSON =
                new ToolStripMenuItem(
                    "Exportar como JSON");

            ToolStripMenuItem itemXML =
                new ToolStripMenuItem(
                    "Exportar como XML");


            itemCSV.Click += ExportarCSV_Click;
            itemJSON.Click += ExportarJSON_Click;
            itemXML.Click += ExportarXML_Click;


            cmsExportar.Items.Add(itemCSV);
            cmsExportar.Items.Add(itemJSON);
            cmsExportar.Items.Add(itemXML);
        }


        private void btnExportarResultados_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarExportacion())
                return;

            cmsExportar.Show(
                btnExportarResultados,
                new Point(
                    0,
                    btnExportarResultados.Height));
        }


        private bool ValidarExportacion()
        {
            if (!hayResultados ||
                resultadosConteoActuales == null ||
                resultadosConteoActuales.Count == 0)
            {
                MessageBox.Show(
                    "Primero deben existir resultados " +
                    "para poder exportarlos.",
                    "Exportar resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }

            return true;
        }


        // =========================================================
        // EXPORTAR CSV
        // =========================================================

        private void ExportarCSV_Click(
     object sender,
     EventArgs e)
        {
            try
            {
                SaveFileDialog guardar =
                    new SaveFileDialog();

                guardar.Filter =
                    "Archivo CSV (*.csv)|*.csv";

                guardar.FileName =
                    CrearNombreArchivo("csv");

                if (guardar.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                StringBuilder contenido =
                    new StringBuilder();

                contenido.AppendLine(
                    "Eleccion,Centro,Carrera,Grupo,Candidato,Registrado,Votos,Porcentaje");

                int totalVotos = 0;

                foreach (SDVE.Conteo.ResultadoCandidato resultado
                         in resultadosConteoActuales)
                {
                    totalVotos += resultado.Votos;
                }

                foreach (SDVE.Conteo.ResultadoCandidato resultado
                         in resultadosConteoActuales)
                {
                    double porcentaje =
                        procesadorVotos.CalcularPorcentaje(
                            resultado.Votos,
                            totalVotos);

                    string eleccion =
                        resultado.Eleccion.Replace("\"", "\"\"");

                    string centro =
                        resultado.Centro.Replace("\"", "\"\"");

                    string carrera =
                        resultado.Carrera.Replace("\"", "\"\"");

                    string grupo =
                        resultado.Grupo.Replace("\"", "\"\"");

                    string candidato =
                        resultado.Candidato.Replace("\"", "\"\"");

                    contenido.AppendLine(
                        "\"" + eleccion + "\"," +
                        "\"" + centro + "\"," +
                        "\"" + carrera + "\"," +
                        "\"" + grupo + "\"," +
                        "\"" + candidato + "\"," +
                        resultado.Registrado + "," +
                        resultado.Votos + "," +
                        porcentaje.ToString(
                            "0.00",
                            System.Globalization.CultureInfo.InvariantCulture)
                    );
                }

                File.WriteAllText(
                    guardar.FileName,
                    contenido.ToString(),
                    Encoding.UTF8);

                MessageBox.Show(
                    "El archivo CSV se exportó correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarErrorExportacion(ex);
            }
        }

        // =========================================================
        // EXPORTAR JSON
        // =========================================================

        private void ExportarJSON_Click(
     object sender,
     EventArgs e)
        {
            try
            {
                SaveFileDialog guardar =
                    new SaveFileDialog();

                guardar.Filter =
                    "Archivo JSON (*.json)|*.json";

                guardar.FileName =
                    CrearNombreArchivo("json");

                if (guardar.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                JsonSerializerOptions opciones =
                    new JsonSerializerOptions();

                opciones.WriteIndented = true;

                string json =
                    JsonSerializer.Serialize(
                        resultadosConteoActuales,
                        opciones);

                File.WriteAllText(
                    guardar.FileName,
                    json,
                    Encoding.UTF8);

                MessageBox.Show(
                    "El archivo JSON se exportó correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarErrorExportacion(ex);
            }
        }

        // =========================================================
        // EXPORTAR XML
        // =========================================================

        private void ExportarXML_Click(
     object sender,
     EventArgs e)
        {
            try
            {
                SaveFileDialog guardar =
                    new SaveFileDialog();

                guardar.Filter =
                    "Archivo XML (*.xml)|*.xml";

                guardar.FileName =
                    CrearNombreArchivo("xml");

                if (guardar.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                XmlSerializer serializador =
                    new XmlSerializer(
                        typeof(List<SDVE.Conteo.ResultadoCandidato>));

                using (FileStream archivo =
                       new FileStream(
                           guardar.FileName,
                           FileMode.Create))
                {
                    serializador.Serialize(
                        archivo,
                        resultadosConteoActuales);
                }

                MessageBox.Show(
                    "El archivo XML se exportó correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarErrorExportacion(ex);
            }
        }


        // =========================================================
        // NOMBRE DE ARCHIVO
        // =========================================================

        private string CrearNombreArchivo(
            string extension)
        {
            string convocatoria =
                convocatoriaSeleccionada
                    .Replace(" ", "_");

            string vista =
                tipoVistaSeleccionada
                    .Replace(" ", "_");

            return
                "Resultados_" +
                convocatoria +
                "_" +
                vista +
                "." +
                extension;
        }


        private void MostrarErrorExportacion(
            Exception ex)
        {
            MessageBox.Show(
                "No fue posible exportar el archivo.\n\n" +
                ex.Message,
                "Error de exportación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        // =========================================================
        // EVENTOS QUE YA EXISTEN EN TU DESIGNER
        // =========================================================

        private void lblTituloEstadisticas_Click(
            object sender,
            EventArgs e)
        {
        }


        private void dgvResultados_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }


    }
}


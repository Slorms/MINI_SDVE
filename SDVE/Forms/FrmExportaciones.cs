using SDVE.Exportaciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SDVE.Forms
{
    public partial class FrmExportaciones : Form
    {
        // =========================================================
        // VARIABLES
        // =========================================================

        private DatosResultados datosActuales;
        private bool hayResultados = false;

        private string convocatoriaSeleccionada = "Sociedad de Alumnos";
        private string tipoVistaSeleccionada = "General";

        // Colores para la gráfica
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

            ConfigurarFormulario();
            ConfigurarEventos();
            ConfigurarMenuExportacion();
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
                if (hayResultados)
                    CrearLeyenda();
            };
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

            // Acciones
            btnProcesarResultados.Click += btnProcesarResultados_Click;
            btnDetalleCandidatura.Click += btnDetalleCandidatura_Click;
            btnParticipacionGrupo.Click += btnParticipacionGrupo_Click;
            btnExportarResultados.Click += btnExportarResultados_Click;

            // Gráfica
            pnlDona.Paint += pnlDona_Paint;
        }


        // =========================================================
        // CONVOCATORIAS
        // =========================================================

        private void button1_Click(object sender, EventArgs e)
        {
            convocatoriaSeleccionada = "Sociedad de Alumnos";
            SeleccionarConvocatoria(button1);
        }

        private void btnConsejo_Click(object sender, EventArgs e)
        {
            convocatoriaSeleccionada = "Consejo Universitario";
            SeleccionarConvocatoria(btnConsejo);
        }

        private void btnRepresentantes_Click(object sender, EventArgs e)
        {
            convocatoriaSeleccionada = "Consejo de Representantes";
            SeleccionarConvocatoria(btnRepresentantes);
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
            tipoVistaSeleccionada = "General";
            SeleccionarTipoVista(btnGeneral);
        }

        private void btnVistaCarrera_Click(object sender, EventArgs e)
        {
            tipoVistaSeleccionada = "Carrera";
            SeleccionarTipoVista(btnVistaCarrera);
        }

        private void btnVistaGrupo_Click(object sender, EventArgs e)
        {
            tipoVistaSeleccionada = "Semestre y Grupo";
            SeleccionarTipoVista(btnVistaGrupo);
        }

        private void btnVistaCentro_Click(object sender, EventArgs e)
        {
            tipoVistaSeleccionada = "Centro";
            SeleccionarTipoVista(btnVistaCentro);
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
        //
        // ESTE ES EL MÉTODO QUE DESPUÉS PODRÁ UTILIZAR EL RESTO
        // DEL PROYECTO PARA MANDARTE LOS RESULTADOS.
        //
        // No modificamos FrmConteo ni el módulo de votación.
        // =========================================================

        public void CargarResultados(
            int alumnosRegistrados,
            List<ResultadoCandidato> resultados)
        {
            try
            {
                if (resultados == null)
                {
                    MessageBox.Show(
                        "No se recibieron resultados.",
                        "Resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                datosActuales =
                    CalculosResultados.ProcesarResultados(
                        alumnosRegistrados,
                        resultados);

                hayResultados = true;

                PresentarResultados();
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
        // PRESENTAR RESULTADOS
        // =========================================================

        private void PresentarResultados()
        {
            if (!hayResultados)
                return;

            // Estadísticas
            lblNumRegistro.Text =
                datosActuales.alumnosRegistrados.ToString();

            lblNumVotantes.Text =
                datosActuales.alumnosVotantes.ToString();

            label3.Text =
                datosActuales.participacion.ToString("0.0") + "%";

            label4.Text =
                datosActuales.abstencionismo.ToString("0.0") + "%";

            PresentarTabla();

            pnlDona.Invalidate();

            CrearLeyenda();
        }


        // =========================================================
        // TABLA DE RESULTADOS
        // =========================================================

        private void PresentarTabla()
        {
            dgvResultados.Rows.Clear();

            if (datosActuales.candidatos == null)
                return;

            foreach (ResultadoCandidato candidato
                     in datosActuales.candidatos)
            {
                dgvResultados.Rows.Add(
                    candidato.candidato,
                    candidato.votos,
                    candidato.porcentaje.ToString("0.0") + "%"
                );
            }

            dgvResultados.ClearSelection();
        }


        // =========================================================
        // GRÁFICA DINÁMICA
        // =========================================================

        private void pnlDona_Paint(object sender, PaintEventArgs e)
        {
            if (!hayResultados)
                return;

            if (datosActuales.candidatos == null)
                return;

            if (datosActuales.candidatos.Count == 0)
                return;

            int totalVotos = 0;

            foreach (ResultadoCandidato candidato
                     in datosActuales.candidatos)
            {
                totalVotos += candidato.votos;
            }

            if (totalVotos <= 0)
                return;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int margen = 8;

            int tamaño =
                Math.Min(
                    pnlDona.ClientSize.Width,
                    pnlDona.ClientSize.Height)
                - (margen * 2);

            if (tamaño <= 0)
                return;

            Rectangle rectangulo = new Rectangle(
                (pnlDona.ClientSize.Width - tamaño) / 2,
                (pnlDona.ClientSize.Height - tamaño) / 2,
                tamaño,
                tamaño);

            float anguloInicial = -90f;

            for (int i = 0;
                 i < datosActuales.candidatos.Count;
                 i++)
            {
                ResultadoCandidato candidato =
                    datosActuales.candidatos[i];

                float angulo =
                    (float)candidato.votos /
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

            // Agujero central para convertirla en gráfica de dona
            int tamañoCentro =
                (int)(tamaño * 0.48);

            Rectangle centro = new Rectangle(
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

        private void CrearLeyenda()
        {
            pnlLeyenda.Controls.Clear();

            if (!hayResultados)
                return;

            if (datosActuales.candidatos == null)
                return;

            int y = 5;

            for (int i = 0;
                 i < datosActuales.candidatos.Count;
                 i++)
            {
                ResultadoCandidato candidato =
                    datosActuales.candidatos[i];

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

                texto.Text =
                    candidato.candidato +
                    Environment.NewLine +
                    candidato.porcentaje.ToString("0.0") +
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
            if (!hayResultados)
            {
                MessageBox.Show(
                    "Todavía no se han recibido resultados " +
                    "para procesar.",
                    "Procesar resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            PresentarResultados();

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
            if (!hayResultados)
            {
                MessageBox.Show(
                    "No hay resultados disponibles.",
                    "Detalle por candidatura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (datosActuales.candidatos == null ||
                datosActuales.candidatos.Count == 0)
            {
                MessageBox.Show(
                    "No hay candidaturas para mostrar.",
                    "Detalle por candidatura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            StringBuilder detalle =
                new StringBuilder();

            detalle.AppendLine(
                convocatoriaSeleccionada);

            detalle.AppendLine();

            foreach (ResultadoCandidato candidato
                     in datosActuales.candidatos)
            {
                detalle.AppendLine(
                    candidato.candidato +
                    ": " +
                    candidato.votos +
                    " votos (" +
                    candidato.porcentaje.ToString("0.0") +
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
            MessageBox.Show(
                "La participación por grupo se mostrará " +
                "cuando el módulo de emisión de voto proporcione " +
                "los resultados agrupados por semestre y grupo.",
                "Participación por grupo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
            if (!hayResultados)
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
                    "Candidato,Votos,Porcentaje");

                foreach (ResultadoCandidato candidato
                         in datosActuales.candidatos)
                {
                    string nombre =
                        candidato.candidato
                            .Replace("\"", "\"\"");

                    contenido.AppendLine(
                        "\"" +
                        nombre +
                        "\"," +
                        candidato.votos +
                        "," +
                        candidato.porcentaje
                            .ToString("0.00"));
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
                opciones.IncludeFields = true;


                string json =
                    JsonSerializer.Serialize(
                        datosActuales,
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
                        typeof(DatosResultados));


                using (FileStream archivo =
                       new FileStream(
                           guardar.FileName,
                           FileMode.Create))
                {
                    serializador.Serialize(
                        archivo,
                        datosActuales);
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



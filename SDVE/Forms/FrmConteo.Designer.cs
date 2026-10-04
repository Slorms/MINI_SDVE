namespace SDVE.Forms
{
    partial class FrmConteo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblEleccion = new Label();
            cmbEleccion = new ComboBox();
            lblAgrupacion = new Label();
            cmbAgrupacion = new ComboBox();
            btnProcesar = new Button();
            dgvResultados = new DataGridView();
            colCandidato = new DataGridViewTextBoxColumn();
            colGrupo = new DataGridViewTextBoxColumn();
            colCarrera = new DataGridViewTextBoxColumn();
            colCentro = new DataGridViewTextBoxColumn();
            colVotos = new DataGridViewTextBoxColumn();
            colPorcentaje = new DataGridViewTextBoxColumn();
            pnlEncabezado = new Panel();
            lblSubtitulo = new Label();
            pnlConfiguracion = new Panel();
            lblConfiguracion = new Label();
            pnlRegistrados = new Panel();
            lblRegistrados = new Label();
            lblTituloRegistrados = new Label();
            pnlVotantes = new Panel();
            lblVotantes = new Label();
            lblTituloVotantes = new Label();
            pnlParticipacion = new Panel();
            lblParticipacion = new Label();
            lblTituloParticipacion = new Label();
            pnlAbstencion = new Panel();
            label2 = new Label();
            lblTituloAbstencion = new Label();
            pnlDatos = new Panel();
            lblDatos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            pnlEncabezado.SuspendLayout();
            pnlConfiguracion.SuspendLayout();
            pnlRegistrados.SuspendLayout();
            pnlVotantes.SuspendLayout();
            pnlParticipacion.SuspendLayout();
            pnlAbstencion.SuspendLayout();
            pnlDatos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(35, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(536, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MOTOR DE AGREGACIÓN Y CONTEO";
            // 
            // lblEleccion
            // 
            lblEleccion.AutoSize = true;
            lblEleccion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEleccion.ForeColor = Color.FromArgb(50, 65, 85);
            lblEleccion.Location = new Point(25, 62);
            lblEleccion.Name = "lblEleccion";
            lblEleccion.Size = new Size(79, 23);
            lblEleccion.TabIndex = 1;
            lblEleccion.Text = "Elección:";
            // 
            // cmbEleccion
            // 
            cmbEleccion.BackColor = Color.FromArgb(248, 250, 252);
            cmbEleccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEleccion.FlatStyle = FlatStyle.Flat;
            cmbEleccion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEleccion.FormattingEnabled = true;
            cmbEleccion.Items.AddRange(new object[] { "Sociedad de Alumnos", "Consejo Universitario", "Consejo de Representantes" });
            cmbEleccion.Location = new Point(25, 85);
            cmbEleccion.Name = "cmbEleccion";
            cmbEleccion.Size = new Size(430, 31);
            cmbEleccion.TabIndex = 2;
            // 
            // lblAgrupacion
            // 
            lblAgrupacion.AutoSize = true;
            lblAgrupacion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgrupacion.ForeColor = Color.FromArgb(50, 65, 85);
            lblAgrupacion.Location = new Point(485, 62);
            lblAgrupacion.Name = "lblAgrupacion";
            lblAgrupacion.Size = new Size(116, 23);
            lblAgrupacion.TabIndex = 3;
            lblAgrupacion.Text = "Agrupar por:";
            // 
            // cmbAgrupacion
            // 
            cmbAgrupacion.BackColor = Color.FromArgb(248, 250, 252);
            cmbAgrupacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAgrupacion.FlatStyle = FlatStyle.Flat;
            cmbAgrupacion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbAgrupacion.FormattingEnabled = true;
            cmbAgrupacion.Items.AddRange(new object[] { "Todos", "Grupos", "Carrera", "Centro Universitario" });
            cmbAgrupacion.Location = new Point(485, 85);
            cmbAgrupacion.Name = "cmbAgrupacion";
            cmbAgrupacion.Size = new Size(320, 31);
            cmbAgrupacion.TabIndex = 4;
            // 
            // btnProcesar
            // 
            btnProcesar.BackColor = Color.FromArgb(36, 124, 145);
            btnProcesar.Cursor = Cursors.Hand;
            btnProcesar.FlatAppearance.BorderSize = 0;
            btnProcesar.FlatStyle = FlatStyle.Flat;
            btnProcesar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcesar.ForeColor = Color.White;
            btnProcesar.Location = new Point(825, 82);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(180, 42);
            btnProcesar.TabIndex = 5;
            btnProcesar.Text = "&Procesar votos";
            btnProcesar.UseVisualStyleBackColor = false;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 247, 251);
            dgvResultados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvResultados.BackgroundColor = Color.White;
            dgvResultados.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(23, 43, 77);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { colCandidato, colGrupo, colCarrera, colCentro, colVotos, colPorcentaje });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(40, 55, 75);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(218, 234, 249);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(23, 43, 77);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvResultados.DefaultCellStyle = dataGridViewCellStyle3;
            dgvResultados.EnableHeadersVisualStyles = false;
            dgvResultados.Location = new Point(20, 45);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.RowTemplate.Height = 32;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(995, 120);
            dgvResultados.TabIndex = 6;
            // 
            // colCandidato
            // 
            colCandidato.HeaderText = "Candidato";
            colCandidato.MinimumWidth = 6;
            colCandidato.Name = "colCandidato";
            colCandidato.ReadOnly = true;
            colCandidato.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colGrupo
            // 
            colGrupo.HeaderText = "Grupo";
            colGrupo.MinimumWidth = 6;
            colGrupo.Name = "colGrupo";
            colGrupo.ReadOnly = true;
            colGrupo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colCarrera
            // 
            colCarrera.HeaderText = "Carrera";
            colCarrera.MinimumWidth = 6;
            colCarrera.Name = "colCarrera";
            colCarrera.ReadOnly = true;
            colCarrera.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colCentro
            // 
            colCentro.HeaderText = "Centro Universitario";
            colCentro.MinimumWidth = 6;
            colCentro.Name = "colCentro";
            colCentro.ReadOnly = true;
            colCentro.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colVotos
            // 
            colVotos.HeaderText = "Votos";
            colVotos.MinimumWidth = 6;
            colVotos.Name = "colVotos";
            colVotos.ReadOnly = true;
            colVotos.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colPorcentaje
            // 
            colPorcentaje.HeaderText = "Porcentaje";
            colPorcentaje.MinimumWidth = 6;
            colPorcentaje.Name = "colPorcentaje";
            colPorcentaje.ReadOnly = true;
            colPorcentaje.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(23, 43, 77);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1082, 90);
            pnlEncabezado.TabIndex = 11;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(190, 208, 230);
            lblSubtitulo.Location = new Point(38, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(303, 23);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema Digital de Votación Estudiantil";
            // 
            // pnlConfiguracion
            // 
            pnlConfiguracion.BackColor = Color.White;
            pnlConfiguracion.BorderStyle = BorderStyle.FixedSingle;
            pnlConfiguracion.Controls.Add(lblConfiguracion);
            pnlConfiguracion.Controls.Add(lblEleccion);
            pnlConfiguracion.Controls.Add(cmbEleccion);
            pnlConfiguracion.Controls.Add(lblAgrupacion);
            pnlConfiguracion.Controls.Add(cmbAgrupacion);
            pnlConfiguracion.Controls.Add(btnProcesar);
            pnlConfiguracion.Location = new Point(25, 110);
            pnlConfiguracion.Name = "pnlConfiguracion";
            pnlConfiguracion.Size = new Size(1035, 175);
            pnlConfiguracion.TabIndex = 12;
            // 
            // lblConfiguracion
            // 
            lblConfiguracion.AutoSize = true;
            lblConfiguracion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfiguracion.ForeColor = Color.FromArgb(23, 43, 77);
            lblConfiguracion.Location = new Point(20, 15);
            lblConfiguracion.Name = "lblConfiguracion";
            lblConfiguracion.Size = new Size(326, 28);
            lblConfiguracion.TabIndex = 0;
            lblConfiguracion.Text = "Configuración del procesamiento";
            // 
            // pnlRegistrados
            // 
            pnlRegistrados.BackColor = Color.FromArgb(231, 241, 253);
            pnlRegistrados.Controls.Add(lblRegistrados);
            pnlRegistrados.Controls.Add(lblTituloRegistrados);
            pnlRegistrados.Location = new Point(25, 305);
            pnlRegistrados.Name = "pnlRegistrados";
            pnlRegistrados.Size = new Size(245, 125);
            pnlRegistrados.TabIndex = 13;
            // 
            // lblRegistrados
            // 
            lblRegistrados.AutoSize = true;
            lblRegistrados.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistrados.ForeColor = Color.FromArgb(23, 90, 164);
            lblRegistrados.Location = new Point(15, 48);
            lblRegistrados.Name = "lblRegistrados";
            lblRegistrados.Size = new Size(46, 54);
            lblRegistrados.TabIndex = 1;
            lblRegistrados.Text = "0";
            // 
            // lblTituloRegistrados
            // 
            lblTituloRegistrados.AutoSize = true;
            lblTituloRegistrados.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistrados.ForeColor = Color.FromArgb(23, 90, 164);
            lblTituloRegistrados.Location = new Point(15, 15);
            lblTituloRegistrados.Name = "lblTituloRegistrados";
            lblTituloRegistrados.Size = new Size(175, 23);
            lblTituloRegistrados.TabIndex = 0;
            lblTituloRegistrados.Text = "Alumnos registrados";
            // 
            // pnlVotantes
            // 
            pnlVotantes.BackColor = Color.FromArgb(231, 245, 238);
            pnlVotantes.Controls.Add(lblVotantes);
            pnlVotantes.Controls.Add(lblTituloVotantes);
            pnlVotantes.Location = new Point(288, 305);
            pnlVotantes.Name = "pnlVotantes";
            pnlVotantes.Size = new Size(245, 125);
            pnlVotantes.TabIndex = 14;
            // 
            // lblVotantes
            // 
            lblVotantes.AutoSize = true;
            lblVotantes.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVotantes.ForeColor = Color.FromArgb(24, 120, 88);
            lblVotantes.Location = new Point(15, 48);
            lblVotantes.Name = "lblVotantes";
            lblVotantes.Size = new Size(46, 54);
            lblVotantes.TabIndex = 1;
            lblVotantes.Text = "0";
            // 
            // lblTituloVotantes
            // 
            lblTituloVotantes.AutoSize = true;
            lblTituloVotantes.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloVotantes.ForeColor = Color.FromArgb(24, 120, 88);
            lblTituloVotantes.Location = new Point(15, 15);
            lblTituloVotantes.Name = "lblTituloVotantes";
            lblTituloVotantes.Size = new Size(79, 23);
            lblTituloVotantes.TabIndex = 0;
            lblTituloVotantes.Text = "Votantes";
            // 
            // pnlParticipacion
            // 
            pnlParticipacion.BackColor = Color.FromArgb(240, 234, 254);
            pnlParticipacion.Controls.Add(lblParticipacion);
            pnlParticipacion.Controls.Add(lblTituloParticipacion);
            pnlParticipacion.Location = new Point(551, 305);
            pnlParticipacion.Name = "pnlParticipacion";
            pnlParticipacion.Size = new Size(245, 125);
            pnlParticipacion.TabIndex = 15;
            // 
            // lblParticipacion
            // 
            lblParticipacion.AutoSize = true;
            lblParticipacion.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblParticipacion.ForeColor = Color.FromArgb(104, 67, 165);
            lblParticipacion.Location = new Point(15, 48);
            lblParticipacion.Name = "lblParticipacion";
            lblParticipacion.Size = new Size(92, 54);
            lblParticipacion.TabIndex = 1;
            lblParticipacion.Text = "0 %";
            // 
            // lblTituloParticipacion
            // 
            lblTituloParticipacion.AutoSize = true;
            lblTituloParticipacion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloParticipacion.ForeColor = Color.FromArgb(104, 67, 165);
            lblTituloParticipacion.Location = new Point(15, 15);
            lblTituloParticipacion.Name = "lblTituloParticipacion";
            lblTituloParticipacion.Size = new Size(114, 23);
            lblTituloParticipacion.TabIndex = 0;
            lblTituloParticipacion.Text = "Participación";
            // 
            // pnlAbstencion
            // 
            pnlAbstencion.BackColor = Color.FromArgb(252, 237, 239);
            pnlAbstencion.Controls.Add(label2);
            pnlAbstencion.Controls.Add(lblTituloAbstencion);
            pnlAbstencion.Location = new Point(814, 305);
            pnlAbstencion.Name = "pnlAbstencion";
            pnlAbstencion.Size = new Size(245, 125);
            pnlAbstencion.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(174, 61, 80);
            label2.Location = new Point(15, 48);
            label2.Name = "label2";
            label2.Size = new Size(92, 54);
            label2.TabIndex = 1;
            label2.Text = "0 %";
            // 
            // lblTituloAbstencion
            // 
            lblTituloAbstencion.AutoSize = true;
            lblTituloAbstencion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloAbstencion.ForeColor = Color.FromArgb(174, 61, 80);
            lblTituloAbstencion.Location = new Point(15, 15);
            lblTituloAbstencion.Name = "lblTituloAbstencion";
            lblTituloAbstencion.Size = new Size(137, 23);
            lblTituloAbstencion.TabIndex = 0;
            lblTituloAbstencion.Text = "Abstencionismo";
            // 
            // pnlDatos
            // 
            pnlDatos.BackColor = Color.White;
            pnlDatos.BorderStyle = BorderStyle.FixedSingle;
            pnlDatos.Controls.Add(lblDatos);
            pnlDatos.Controls.Add(dgvResultados);
            pnlDatos.Location = new Point(25, 450);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(1035, 185);
            pnlDatos.TabIndex = 17;
            // 
            // lblDatos
            // 
            lblDatos.AutoSize = true;
            lblDatos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatos.ForeColor = Color.FromArgb(23, 43, 77);
            lblDatos.Location = new Point(20, 12);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(179, 28);
            lblDatos.TabIndex = 7;
            lblDatos.Text = "Datos procesados";
            // 
            // FrmConteo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(242, 245, 249);
            ClientSize = new Size(1082, 653);
            Controls.Add(pnlDatos);
            Controls.Add(pnlAbstencion);
            Controls.Add(pnlParticipacion);
            Controls.Add(pnlVotantes);
            Controls.Add(pnlRegistrados);
            Controls.Add(pnlConfiguracion);
            Controls.Add(pnlEncabezado);
            MinimumSize = new Size(1100, 700);
            Name = "FrmConteo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Motor de Agregación y Conteo";
            Load += FrmConteo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlConfiguracion.ResumeLayout(false);
            pnlConfiguracion.PerformLayout();
            pnlRegistrados.ResumeLayout(false);
            pnlRegistrados.PerformLayout();
            pnlVotantes.ResumeLayout(false);
            pnlVotantes.PerformLayout();
            pnlParticipacion.ResumeLayout(false);
            pnlParticipacion.PerformLayout();
            pnlAbstencion.ResumeLayout(false);
            pnlAbstencion.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblEleccion;
        private ComboBox cmbEleccion;
        private Label lblAgrupacion;
        private ComboBox cmbAgrupacion;
        private Button btnProcesar;
        private DataGridView dgvResultados;
        private Panel pnlEncabezado;
        private Label lblSubtitulo;
        private Panel pnlConfiguracion;
        private Label lblConfiguracion;
        private Panel pnlRegistrados;
        private Label lblRegistrados;
        private Label lblTituloRegistrados;
        private Panel pnlVotantes;
        private Label lblVotantes;
        private Label lblTituloVotantes;
        private Panel pnlParticipacion;
        private Label lblParticipacion;
        private Label lblTituloParticipacion;
        private Panel pnlAbstencion;
        private Label label2;
        private Label lblTituloAbstencion;
        private Panel pnlDatos;
        private Label lblDatos;
        private DataGridViewTextBoxColumn colCandidato;
        private DataGridViewTextBoxColumn colGrupo;
        private DataGridViewTextBoxColumn colCarrera;
        private DataGridViewTextBoxColumn colCentro;
        private DataGridViewTextBoxColumn colVotos;
        private DataGridViewTextBoxColumn colPorcentaje;
    }
}
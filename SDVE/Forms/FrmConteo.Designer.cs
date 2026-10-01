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
            lblRegistrados = new Label();
            lblVotantes = new Label();
            lblParticipacion = new Label();
            lblAbstencion = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(183, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(294, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CONTEO DE VOTOS";
            // 
            // lblEleccion
            // 
            lblEleccion.AutoSize = true;
            lblEleccion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEleccion.Location = new Point(59, 107);
            lblEleccion.Name = "lblEleccion";
            lblEleccion.Size = new Size(95, 28);
            lblEleccion.TabIndex = 1;
            lblEleccion.Text = "Elección:";
            // 
            // cmbEleccion
            // 
            cmbEleccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEleccion.FormattingEnabled = true;
            cmbEleccion.Items.AddRange(new object[] { "Sociedad de Alumnos", "Consejo Universitario", "Consejo de Representantes" });
            cmbEleccion.Location = new Point(198, 107);
            cmbEleccion.Name = "cmbEleccion";
            cmbEleccion.Size = new Size(279, 28);
            cmbEleccion.TabIndex = 2;
            // 
            // lblAgrupacion
            // 
            lblAgrupacion.AutoSize = true;
            lblAgrupacion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgrupacion.Location = new Point(59, 150);
            lblAgrupacion.Name = "lblAgrupacion";
            lblAgrupacion.Size = new Size(133, 28);
            lblAgrupacion.TabIndex = 3;
            lblAgrupacion.Text = "Agrupar por:";
            // 
            // cmbAgrupacion
            // 
            cmbAgrupacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAgrupacion.FormattingEnabled = true;
            cmbAgrupacion.Items.AddRange(new object[] { "Todos", "Grupos", "Carrera", "Centro Universitario" });
            cmbAgrupacion.Location = new Point(198, 150);
            cmbAgrupacion.Name = "cmbAgrupacion";
            cmbAgrupacion.Size = new Size(279, 28);
            cmbAgrupacion.TabIndex = 4;
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(222, 240);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(203, 29);
            btnProcesar.TabIndex = 5;
            btnProcesar.Text = "Procesar votos";
            btnProcesar.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { colCandidato, colGrupo, colCarrera, colCentro, colVotos, colPorcentaje });
            dgvResultados.Location = new Point(-7, 323);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(737, 188);
            dgvResultados.TabIndex = 6;
            // 
            // colCandidato
            // 
            colCandidato.HeaderText = "Candidato";
            colCandidato.MinimumWidth = 6;
            colCandidato.Name = "colCandidato";
            colCandidato.ReadOnly = true;
            colCandidato.Width = 125;
            // 
            // colGrupo
            // 
            colGrupo.HeaderText = "Grupo";
            colGrupo.MinimumWidth = 6;
            colGrupo.Name = "colGrupo";
            colGrupo.ReadOnly = true;
            colGrupo.Width = 125;
            // 
            // colCarrera
            // 
            colCarrera.HeaderText = "Carrera";
            colCarrera.MinimumWidth = 6;
            colCarrera.Name = "colCarrera";
            colCarrera.ReadOnly = true;
            colCarrera.Width = 125;
            // 
            // colCentro
            // 
            colCentro.HeaderText = "Centro Universitario";
            colCentro.MinimumWidth = 6;
            colCentro.Name = "colCentro";
            colCentro.ReadOnly = true;
            colCentro.Width = 125;
            // 
            // colVotos
            // 
            colVotos.HeaderText = "Votos";
            colVotos.MinimumWidth = 6;
            colVotos.Name = "colVotos";
            colVotos.ReadOnly = true;
            colVotos.Width = 125;
            // 
            // colPorcentaje
            // 
            colPorcentaje.HeaderText = "Porcentaje";
            colPorcentaje.MinimumWidth = 6;
            colPorcentaje.Name = "colPorcentaje";
            colPorcentaje.ReadOnly = true;
            colPorcentaje.Width = 125;
            // 
            // lblRegistrados
            // 
            lblRegistrados.AutoSize = true;
            lblRegistrados.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistrados.Location = new Point(59, 580);
            lblRegistrados.Name = "lblRegistrados";
            lblRegistrados.Size = new Size(195, 23);
            lblRegistrados.TabIndex = 7;
            lblRegistrados.Text = "Alumnos registrados: 0";
            // 
            // lblVotantes
            // 
            lblVotantes.AutoSize = true;
            lblVotantes.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVotantes.Location = new Point(60, 615);
            lblVotantes.Name = "lblVotantes";
            lblVotantes.Size = new Size(99, 23);
            lblVotantes.TabIndex = 8;
            lblVotantes.Text = "Votantes: 0";
            // 
            // lblParticipacion
            // 
            lblParticipacion.AutoSize = true;
            lblParticipacion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblParticipacion.Location = new Point(59, 652);
            lblParticipacion.Name = "lblParticipacion";
            lblParticipacion.Size = new Size(149, 23);
            lblParticipacion.TabIndex = 9;
            lblParticipacion.Text = "Participación: 0%";
            // 
            // lblAbstencion
            // 
            lblAbstencion.AutoSize = true;
            lblAbstencion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAbstencion.Location = new Point(60, 689);
            lblAbstencion.Name = "lblAbstencion";
            lblAbstencion.Size = new Size(172, 23);
            lblAbstencion.TabIndex = 10;
            lblAbstencion.Text = "Abstencionismo: 0%";
            // 
            // FrmConteo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(731, 765);
            Controls.Add(lblAbstencion);
            Controls.Add(lblParticipacion);
            Controls.Add(lblVotantes);
            Controls.Add(lblRegistrados);
            Controls.Add(dgvResultados);
            Controls.Add(btnProcesar);
            Controls.Add(cmbAgrupacion);
            Controls.Add(lblAgrupacion);
            Controls.Add(cmbEleccion);
            Controls.Add(lblEleccion);
            Controls.Add(lblTitulo);
            Name = "FrmConteo";
            Text = "FrmConteo";
            Load += FrmConteo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblEleccion;
        private ComboBox cmbEleccion;
        private Label lblAgrupacion;
        private ComboBox cmbAgrupacion;
        private Button btnProcesar;
        private DataGridView dgvResultados;
        private DataGridViewTextBoxColumn colCandidato;
        private DataGridViewTextBoxColumn colGrupo;
        private DataGridViewTextBoxColumn colCarrera;
        private DataGridViewTextBoxColumn colCentro;
        private DataGridViewTextBoxColumn colVotos;
        private DataGridViewTextBoxColumn colPorcentaje;
        private Label lblRegistrados;
        private Label lblVotantes;
        private Label lblParticipacion;
        private Label lblAbstencion;
    }
}
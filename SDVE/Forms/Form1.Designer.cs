namespace Votaciones
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            lblEstado = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // button1
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.FromArgb(184, 197, 214);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(18, 63, 115);
            button1.Location = new Point(47, 160);
            button1.Name = "button1";
            button1.Size = new Size(229, 119);
            button1.TabIndex = 0;
            button1.Text = "Sociedad de Alumnos";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnAsociacion_Click;
            // button2
            button2.BackColor = Color.White;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderColor = Color.FromArgb(184, 197, 214);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(18, 63, 115);
            button2.Location = new Point(302, 160);
            button2.Name = "button2";
            button2.Size = new Size(210, 119);
            button2.TabIndex = 1;
            button2.Text = "Consejo Universitario";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // button3
            button3.BackColor = Color.White;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderColor = Color.FromArgb(184, 197, 214);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(18, 63, 115);
            button3.Location = new Point(540, 160);
            button3.Name = "button3";
            button3.Size = new Size(210, 119);
            button3.TabIndex = 2;
            button3.Text = "Consejo de Representantes";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // label1
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(45, 85);
            label1.Name = "label1";
            label1.Size = new Size(710, 60);
            label1.TabIndex = 3;
            label1.Text = "Haz clic en una, dos o tres convocatorias. Las seleccionadas quedan azules.\nPulsa Enviar para completar sus papeletas y confirmar tus votos.";
            // label2
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(45, 35);
            label2.Name = "label2";
            label2.Size = new Size(344, 46);
            label2.TabIndex = 15;
            label2.Text = "Proceso de votación";
            // button4
            button4.Enabled = false;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.FromArgb(18, 63, 115);
            button4.Location = new Point(190, 365);
            button4.Name = "button4";
            button4.Size = new Size(199, 50);
            button4.TabIndex = 16;
            button4.Text = "&Enviar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // lblEstado
            lblEstado.BackColor = Color.Transparent;
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.ForeColor = Color.White;
            lblEstado.Location = new Point(47, 298);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(703, 55);
            lblEstado.TabIndex = 17;
            lblEstado.Text = "Convocatorias seleccionadas: 0. Papeletas completas: 0.";
            // btnCancelar
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(18, 63, 115);
            btnCancelar.Location = new Point(411, 365);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(199, 50);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(lblEstado);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SDVE · Selección de convocatorias";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Button button4;
        private Label lblEstado;
        private Button btnCancelar;
    }
}

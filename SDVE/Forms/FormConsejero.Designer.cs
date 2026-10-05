namespace Votaciones
{
    partial class FormConsejero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsejero));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            btnPropuesta = new Button();
            btnEnviarPropuesta = new Button();
            txtPropuestaConsejero = new TextBox();
            label1 = new Label();
            pnlHeader = new Panel();
            panel1 = new Panel();
            picLogo = new PictureBox();
            btnMenu = new Button();
            lblTitulo = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(37, 128);
            button1.Name = "button1";
            button1.Size = new Size(194, 100);
            button1.TabIndex = 0;
            button1.Text = "Angel Carranza";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(268, 128);
            button2.Name = "button2";
            button2.Size = new Size(203, 100);
            button2.TabIndex = 1;
            button2.Text = "Daniel Garcia";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(526, 128);
            button3.Name = "button3";
            button3.Size = new Size(206, 100);
            button3.TabIndex = 2;
            button3.Text = "Alexa Janeth";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(132, 246);
            button4.Name = "button4";
            button4.Size = new Size(176, 93);
            button4.TabIndex = 3;
            button4.Text = "Valeria Ramirez";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(398, 246);
            button5.Name = "button5";
            button5.Size = new Size(192, 93);
            button5.TabIndex = 4;
            button5.Text = "Angel Enriquez";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btnPropuesta
            // 
            btnPropuesta.Location = new Point(104, 369);
            btnPropuesta.Name = "btnPropuesta";
            btnPropuesta.Size = new Size(81, 42);
            btnPropuesta.TabIndex = 5;
            btnPropuesta.Text = "Otro";
            btnPropuesta.UseVisualStyleBackColor = true;
            btnPropuesta.Click += btnPropuesta_Click;
            // 
            // btnEnviarPropuesta
            // 
            btnEnviarPropuesta.Enabled = false;
            btnEnviarPropuesta.Location = new Point(558, 374);
            btnEnviarPropuesta.Name = "btnEnviarPropuesta";
            btnEnviarPropuesta.Size = new Size(83, 32);
            btnEnviarPropuesta.TabIndex = 6;
            btnEnviarPropuesta.Text = "Enviar";
            btnEnviarPropuesta.UseVisualStyleBackColor = true;
            btnEnviarPropuesta.Click += btnEnviarPropuesta_Click;
            // 
            // txtPropuestaConsejero
            // 
            txtPropuestaConsejero.Enabled = false;
            txtPropuestaConsejero.Location = new Point(191, 377);
            txtPropuestaConsejero.Name = "txtPropuestaConsejero";
            txtPropuestaConsejero.Size = new Size(361, 27);
            txtPropuestaConsejero.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 85);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 8;
            label1.Text = "Consejero Universitario";
            label1.Click += label1_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 50, 105);
            pnlHeader.Controls.Add(panel1);
            pnlHeader.Controls.Add(picLogo);
            pnlHeader.Controls.Add(btnMenu);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Location = new Point(-6, 1);
            pnlHeader.Margin = new Padding(2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(885, 68);
            pnlHeader.TabIndex = 26;
            pnlHeader.TabStop = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(154, 10);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(2, 34);
            panel1.TabIndex = 2;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(47, 10);
            picLogo.Margin = new Padding(2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(98, 29);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // btnMenu
            // 
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 20F);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(9, 0);
            btnMenu.Margin = new Padding(2);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(41, 49);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(156, 14);
            lblTitulo.Margin = new Padding(2, 0, 2, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(529, 28);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Sistema de Votación Estudiantil (Centro de Ciencias Básicas)";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormConsejero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlHeader);
            Controls.Add(label1);
            Controls.Add(txtPropuestaConsejero);
            Controls.Add(btnEnviarPropuesta);
            Controls.Add(btnPropuesta);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormConsejero";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormConsejero";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button btnPropuesta;
        private Button btnEnviarPropuesta;
        private TextBox txtPropuestaConsejero;
        private Label label1;
        private Panel pnlHeader;
        private Panel panel1;
        private PictureBox picLogo;
        private Button btnMenu;
        private Label lblTitulo;
    }
}
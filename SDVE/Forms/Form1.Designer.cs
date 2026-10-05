namespace Votaciones
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
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
            button1.ForeColor = Color.Navy;
            button1.Location = new Point(36, 156);
            button1.Name = "button1";
            button1.Size = new Size(229, 119);
            button1.TabIndex = 0;
            button1.Text = "Asociacion Estudiantil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAsociacion_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Navy;
            button2.Location = new Point(291, 156);
            button2.Name = "button2";
            button2.Size = new Size(210, 119);
            button2.TabIndex = 1;
            button2.Text = "Consejero Universitario";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.Navy;
            button3.Location = new Point(529, 156);
            button3.Name = "button3";
            button3.Size = new Size(210, 119);
            button3.TabIndex = 2;
            button3.Text = "Representante Universitario";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(273, 118);
            label1.Name = "label1";
            label1.Size = new Size(252, 20);
            label1.TabIndex = 3;
            label1.Text = "Seleccione Una Categoria para Votar";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(291, 77);
            label2.Name = "label2";
            label2.Size = new Size(229, 28);
            label2.TabIndex = 15;
            label2.Text = "Proceso de Votacion";
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(352, 357);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 16;
            button4.Text = "Enviar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 50, 105);
            pnlHeader.Controls.Add(panel1);
            pnlHeader.Controls.Add(picLogo);
            pnlHeader.Controls.Add(btnMenu);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(879, 60);
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
            lblTitulo.Size = new Size(290, 28);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Sistema de Votación Estudiantil ";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlHeader);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
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
        private Label label1;
        private Label label2;
        private Button button4;
        private Panel pnlHeader;
        private Panel panel1;
        private PictureBox picLogo;
        private Button btnMenu;
        private Label lblTitulo;
    }
}

namespace Login
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lblTitulo = new Label();
            pictureBox2 = new PictureBox();
            pnlHeader = new Panel();
            panel1 = new Panel();
            picLogo = new PictureBox();
            btnMenu = new Button();
            pnlContenido = new Panel();
            lblBienvenido = new Label();
            lblSubtitulo = new Label();
            pnlAlumno = new Panel();
            lblSeleccionado = new Label();
            lblAlumno = new Label();
            picAlumno = new PictureBox();
            pnlDocente = new Panel();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            pnlAdmin = new Panel();
            label2 = new Label();
            pictureBox4 = new PictureBox();
            pnlIngreso = new Panel();
            pnlAviso = new Panel();
            lblAviso = new Label();
            btnIngresar = new Button();
            lblMaximo = new Label();
            txtId = new TextBox();
            lblID = new Label();
            panel2 = new Panel();
            pictureBox6 = new PictureBox();
            lblIngreso = new Label();
            pictureBox5 = new PictureBox();
            pictureBox1 = new PictureBox();
            picUrna = new PictureBox();
            lblFrase = new Label();
            lblfrase2 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlContenido.SuspendLayout();
            pnlAlumno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAlumno).BeginInit();
            pnlDocente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pnlAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pnlIngreso.SuspendLayout();
            pnlAviso.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picUrna).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(195, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(650, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Sistema de Votación Estudiantil (Centro de Ciencias Básicas)";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 501);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 50, 105);
            pnlHeader.Controls.Add(panel1);
            pnlHeader.Controls.Add(picLogo);
            pnlHeader.Controls.Add(btnMenu);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Location = new Point(1, -1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1085, 64);
            pnlHeader.TabIndex = 10;
            pnlHeader.TabStop = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(192, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(2, 42);
            panel1.TabIndex = 2;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(59, 13);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(123, 36);
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
            btnMenu.Location = new Point(11, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(51, 61);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(pictureBox2);
            pnlContenido.Location = new Point(1, 66);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(110, 581);
            pnlContenido.TabIndex = 11;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.BackColor = Color.Transparent;
            lblBienvenido.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBienvenido.Location = new Point(140, 84);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(209, 48);
            lblBienvenido.TabIndex = 12;
            lblBienvenido.Text = "Bienvenido";
            lblBienvenido.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.ForeColor = Color.FromArgb(95, 113, 135);
            lblSubtitulo.Location = new Point(140, 132);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(439, 25);
            lblSubtitulo.TabIndex = 13;
            lblSubtitulo.Text = "Selecciona el rol con el que deseas ingresar al sistema.";
            // 
            // pnlAlumno
            // 
            pnlAlumno.BackColor = Color.FromArgb(16, 58, 112);
            pnlAlumno.BorderStyle = BorderStyle.FixedSingle;
            pnlAlumno.Controls.Add(lblSeleccionado);
            pnlAlumno.Controls.Add(lblAlumno);
            pnlAlumno.Controls.Add(picAlumno);
            pnlAlumno.Cursor = Cursors.Hand;
            pnlAlumno.Location = new Point(139, 190);
            pnlAlumno.Name = "pnlAlumno";
            pnlAlumno.Size = new Size(167, 127);
            pnlAlumno.TabIndex = 14;
            // 
            // lblSeleccionado
            // 
            lblSeleccionado.AutoSize = true;
            lblSeleccionado.Font = new Font("Microsoft Sans Serif", 15F);
            lblSeleccionado.ForeColor = Color.White;
            lblSeleccionado.Location = new Point(115, -1);
            lblSeleccionado.Name = "lblSeleccionado";
            lblSeleccionado.Size = new Size(51, 36);
            lblSeleccionado.TabIndex = 3;
            lblSeleccionado.Text = "✔";
            // 
            // lblAlumno
            // 
            lblAlumno.AutoSize = true;
            lblAlumno.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAlumno.ForeColor = Color.White;
            lblAlumno.Location = new Point(44, 99);
            lblAlumno.Name = "lblAlumno";
            lblAlumno.Size = new Size(79, 25);
            lblAlumno.TabIndex = 1;
            lblAlumno.Text = "Alumno";
            // 
            // picAlumno
            // 
            picAlumno.BackColor = Color.Transparent;
            picAlumno.Image = (Image)resources.GetObject("picAlumno.Image");
            picAlumno.Location = new Point(32, 3);
            picAlumno.Name = "picAlumno";
            picAlumno.Size = new Size(101, 116);
            picAlumno.SizeMode = PictureBoxSizeMode.Zoom;
            picAlumno.TabIndex = 0;
            picAlumno.TabStop = false;
            // 
            // pnlDocente
            // 
            pnlDocente.BackColor = Color.White;
            pnlDocente.BorderStyle = BorderStyle.FixedSingle;
            pnlDocente.Controls.Add(pictureBox3);
            pnlDocente.Controls.Add(label1);
            pnlDocente.Cursor = Cursors.Hand;
            pnlDocente.Location = new Point(343, 190);
            pnlDocente.Name = "pnlDocente";
            pnlDocente.Size = new Size(178, 127);
            pnlDocente.TabIndex = 15;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(35, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(107, 93);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(16, 46, 91);
            label1.Location = new Point(48, 99);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 2;
            label1.Text = "Docente";
            // 
            // pnlAdmin
            // 
            pnlAdmin.BackColor = Color.White;
            pnlAdmin.BorderStyle = BorderStyle.FixedSingle;
            pnlAdmin.Controls.Add(label2);
            pnlAdmin.Controls.Add(pictureBox4);
            pnlAdmin.Cursor = Cursors.Hand;
            pnlAdmin.Location = new Point(542, 190);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(193, 127);
            pnlAdmin.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(16, 46, 91);
            label2.Location = new Point(30, 99);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 3;
            label2.Text = "Administrador";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(30, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(123, 107);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // pnlIngreso
            // 
            pnlIngreso.BackColor = Color.White;
            pnlIngreso.BorderStyle = BorderStyle.FixedSingle;
            pnlIngreso.Controls.Add(pnlAviso);
            pnlIngreso.Controls.Add(btnIngresar);
            pnlIngreso.Controls.Add(lblMaximo);
            pnlIngreso.Controls.Add(txtId);
            pnlIngreso.Controls.Add(lblID);
            pnlIngreso.Controls.Add(panel2);
            pnlIngreso.Controls.Add(pictureBox1);
            pnlIngreso.ForeColor = Color.FromArgb(100, 116, 139);
            pnlIngreso.Location = new Point(129, 349);
            pnlIngreso.Name = "pnlIngreso";
            pnlIngreso.Size = new Size(605, 263);
            pnlIngreso.TabIndex = 12;
            // 
            // pnlAviso
            // 
            pnlAviso.BackColor = Color.FromArgb(240, 245, 252);
            pnlAviso.Controls.Add(lblAviso);
            pnlAviso.Cursor = Cursors.Hand;
            pnlAviso.Location = new Point(-1, 217);
            pnlAviso.Name = "pnlAviso";
            pnlAviso.Size = new Size(605, 45);
            pnlAviso.TabIndex = 21;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.BackColor = Color.Transparent;
            lblAviso.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.FromArgb(83, 102, 129);
            lblAviso.Location = new Point(25, 13);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(366, 21);
            lblAviso.TabIndex = 22;
            lblAviso.Text = "ⓘ El ID de alumno es un número de hasta 6 dígitos.";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(16, 58, 112);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(17, 167);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(572, 44);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar →";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // lblMaximo
            // 
            lblMaximo.AutoSize = true;
            lblMaximo.BackColor = Color.Transparent;
            lblMaximo.Font = new Font("Segoe UI", 6F);
            lblMaximo.ForeColor = Color.FromArgb(16, 46, 91);
            lblMaximo.Location = new Point(17, 149);
            lblMaximo.Name = "lblMaximo";
            lblMaximo.Size = new Size(98, 15);
            lblMaximo.TabIndex = 20;
            lblMaximo.Text = "Máximo 6 dígitos";
            // 
            // txtId
            // 
            txtId.BackColor = Color.WhiteSmoke;
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Font = new Font("Segoe UI", 8F);
            txtId.ForeColor = Color.FromArgb(40, 55, 75);
            txtId.Location = new Point(17, 112);
            txtId.MaxLength = 6;
            txtId.Name = "txtId";
            txtId.PlaceholderText = " Ejemplo: 123456";
            txtId.Size = new Size(572, 29);
            txtId.TabIndex = 4;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.BackColor = Color.Transparent;
            lblID.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblID.ForeColor = Color.FromArgb(16, 46, 91);
            lblID.Location = new Point(17, 79);
            lblID.Name = "lblID";
            lblID.Size = new Size(151, 30);
            lblID.TabIndex = 19;
            lblID.Text = "ID de alumno";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(240, 245, 252);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(lblIngreso);
            panel2.Controls.Add(pictureBox5);
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(606, 63);
            panel2.TabIndex = 13;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(17, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(75, 55);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 3;
            pictureBox6.TabStop = false;
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.BackColor = Color.Transparent;
            lblIngreso.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngreso.ForeColor = Color.FromArgb(16, 58, 112);
            lblIngreso.Location = new Point(98, 16);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(191, 28);
            lblIngreso.TabIndex = 19;
            lblIngreso.Text = "Ingreso de Alumno";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(11, 310);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(113, 62);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 310);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(113, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // picUrna
            // 
            picUrna.BackColor = Color.Transparent;
            picUrna.Image = (Image)resources.GetObject("picUrna.Image");
            picUrna.Location = new Point(741, 132);
            picUrna.Name = "picUrna";
            picUrna.Size = new Size(345, 342);
            picUrna.SizeMode = PictureBoxSizeMode.Zoom;
            picUrna.TabIndex = 4;
            picUrna.TabStop = false;
            // 
            // lblFrase
            // 
            lblFrase.AutoSize = true;
            lblFrase.BackColor = Color.Transparent;
            lblFrase.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFrase.ForeColor = Color.FromArgb(16, 58, 112);
            lblFrase.Location = new Point(849, 489);
            lblFrase.Name = "lblFrase";
            lblFrase.Size = new Size(143, 25);
            lblFrase.TabIndex = 19;
            lblFrase.Text = "Tu voz también";
            // 
            // lblfrase2
            // 
            lblfrase2.AutoSize = true;
            lblfrase2.BackColor = Color.Transparent;
            lblfrase2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblfrase2.ForeColor = Color.FromArgb(16, 58, 112);
            lblfrase2.Location = new Point(809, 517);
            lblfrase2.Name = "lblfrase2";
            lblfrase2.Size = new Size(220, 25);
            lblfrase2.TabIndex = 20;
            lblfrase2.Text = "construye la universidad";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Navy;
            panel3.Location = new Point(849, 556);
            panel3.Name = "panel3";
            panel3.Size = new Size(42, 5);
            panel3.TabIndex = 21;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Yellow;
            panel4.Location = new Point(897, 556);
            panel4.Name = "panel4";
            panel4.Size = new Size(42, 5);
            panel4.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.Location = new Point(950, 556);
            panel5.Name = "panel5";
            panel5.Size = new Size(42, 5);
            panel5.TabIndex = 23;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 251);
            ClientSize = new Size(1078, 644);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(lblfrase2);
            Controls.Add(pnlIngreso);
            Controls.Add(lblFrase);
            Controls.Add(pnlAdmin);
            Controls.Add(picUrna);
            Controls.Add(pnlDocente);
            Controls.Add(pnlAlumno);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblBienvenido);
            Controls.Add(pnlContenido);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SDVE - Sistema de Votación Estudiantil";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlContenido.ResumeLayout(false);
            pnlAlumno.ResumeLayout(false);
            pnlAlumno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAlumno).EndInit();
            pnlDocente.ResumeLayout(false);
            pnlDocente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pnlIngreso.ResumeLayout(false);
            pnlIngreso.PerformLayout();
            pnlAviso.ResumeLayout(false);
            pnlAviso.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picUrna).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitulo;
        private PictureBox pictureBox2;
        private Panel pnlHeader;
        private Button btnMenu;
        private PictureBox picLogo;
        private Panel panel1;
        private Panel pnlContenido;
        private Label lblBienvenido;
        private Label lblSubtitulo;
        private Panel pnlAlumno;
        private Panel pnlDocente;
        private PictureBox picAlumno;
        private Panel pnlAdmin;
        private PictureBox pictureBox4;
        private Label lblAlumno;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox3;
        private Label lblSeleccionado;
        private Panel pnlIngreso;
        private Panel panel2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox1;
        private Label lblIngreso;
        private PictureBox pictureBox6;
        private TextBox txtId;
        private Label lblID;
        private Label lblMaximo;
        private Button btnIngresar;
        private Panel pnlAviso;
        private Label lblAviso;
        private Label lblFrase;
        private PictureBox picUrna;
        private Label lblfrase2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}

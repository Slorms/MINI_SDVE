namespace Votaciones
{
    partial class FormAsociasiones
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            txtPropuesta = new TextBox();
            btnPropuesta = new Button();
            btnConfirmarPropuesta = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(21, 108);
            button1.Name = "button1";
            button1.Size = new Size(230, 120);
            button1.TabIndex = 0;
            button1.Text = "FEUUA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(281, 108);
            button2.Name = "button2";
            button2.Size = new Size(230, 120);
            button2.TabIndex = 1;
            button2.Text = "CONECTA";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(539, 108);
            button3.Name = "button3";
            button3.Size = new Size(230, 120);
            button3.TabIndex = 2;
            button3.Text = "MUCHACHOS";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(347, 36);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 3;
            label1.Text = "Asociacion";
            label1.Click += label1_Click;
            // 
            // txtPropuesta
            // 
            txtPropuesta.Enabled = false;
            txtPropuesta.Location = new Point(217, 307);
            txtPropuesta.Multiline = true;
            txtPropuesta.Name = "txtPropuesta";
            txtPropuesta.Size = new Size(338, 34);
            txtPropuesta.TabIndex = 5;
            txtPropuesta.TextChanged += textBox1_TextChanged;
            // 
            // btnPropuesta
            // 
            btnPropuesta.Location = new Point(88, 293);
            btnPropuesta.Name = "btnPropuesta";
            btnPropuesta.Size = new Size(123, 48);
            btnPropuesta.TabIndex = 6;
            btnPropuesta.Text = "Otro";
            btnPropuesta.UseVisualStyleBackColor = true;
            btnPropuesta.Click += button5_Click;
            // 
            // btnConfirmarPropuesta
            // 
            btnConfirmarPropuesta.Enabled = false;
            btnConfirmarPropuesta.Location = new Point(561, 312);
            btnConfirmarPropuesta.Name = "btnConfirmarPropuesta";
            btnConfirmarPropuesta.Size = new Size(94, 29);
            btnConfirmarPropuesta.TabIndex = 7;
            btnConfirmarPropuesta.Text = "Enviar";
            btnConfirmarPropuesta.UseVisualStyleBackColor = true;
            btnConfirmarPropuesta.Click += btnConfirmarPropuesta_Click;
            // 
            // FormAsociasiones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirmarPropuesta);
            Controls.Add(btnPropuesta);
            Controls.Add(txtPropuesta);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormAsociasiones";
            Text = "FormAsociasiones";
            Load += FormAsociasiones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private TextBox txtPropuesta;
        private Button btnPropuesta;
        private Button btnConfirmarPropuesta;
    }
}
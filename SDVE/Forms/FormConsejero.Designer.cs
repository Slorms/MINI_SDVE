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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            btnPropuesta = new Button();
            btnEnviarPropuesta = new Button();
            txtPropuestaConsejero = new TextBox();
            label1 = new Label();
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
            label1.Location = new Point(289, 40);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 8;
            label1.Text = "Consejero Universitario";
            label1.Click += label1_Click;
            // 
            // FormConsejero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Text = "FormConsejero";
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
    }
}
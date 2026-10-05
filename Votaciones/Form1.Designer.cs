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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.ForeColor = Color.MidnightBlue;
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
            label1.Location = new Point(271, 117);
            label1.Name = "label1";
            label1.Size = new Size(252, 20);
            label1.TabIndex = 3;
            label1.Text = "Seleccione Una Categoria para Votar";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 76);
            label2.Name = "label2";
            label2.Size = new Size(144, 20);
            label2.TabIndex = 15;
            label2.Text = "Proceso de Votacion";
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(353, 362);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 16;
            button4.Text = "Enviar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
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
    }
}

namespace Votaciones
{
    partial class FormRepresentante
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
            label1 = new Label();
            button6 = new Button();
            button7 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(45, 137);
            button1.Name = "button1";
            button1.Size = new Size(201, 98);
            button1.TabIndex = 0;
            button1.Text = "Claudia SHeinbaun";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(278, 137);
            button2.Name = "button2";
            button2.Size = new Size(197, 98);
            button2.TabIndex = 1;
            button2.Text = "Antony Muñoz";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(525, 137);
            button3.Name = "button3";
            button3.Size = new Size(196, 98);
            button3.TabIndex = 2;
            button3.Text = "Daniel Ramirez";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(167, 241);
            button4.Name = "button4";
            button4.Size = new Size(187, 104);
            button4.TabIndex = 3;
            button4.Text = "Lupita Galvez";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(407, 241);
            button5.Name = "button5";
            button5.Size = new Size(187, 104);
            button5.TabIndex = 4;
            button5.Text = "Pedro Talaman";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(278, 51);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 5;
            label1.Text = "Representante Universitario";
            label1.Click += label1_Click;
            // 
            // button6
            // 
            button6.Location = new Point(133, 366);
            button6.Name = "button6";
            button6.Size = new Size(86, 41);
            button6.TabIndex = 6;
            button6.Text = "Otro";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(513, 370);
            button7.Name = "button7";
            button7.Size = new Size(91, 32);
            button7.TabIndex = 7;
            button7.Text = "Enviar";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(225, 375);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 27);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FormRepresentante
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormRepresentante";
            Text = "FormRepresentante";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private Button button6;
        private Button button7;
        private TextBox textBox1;
    }
}
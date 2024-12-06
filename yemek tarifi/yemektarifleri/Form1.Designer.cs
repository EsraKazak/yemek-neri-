namespace yemektarifleri
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(182, 75);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(136, 28);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Kategoriler";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.Enter += comcobox_enter;
            comboBox1.Leave += comcobox_leave;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(471, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "Yemek Tarifi Arayın";
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textbox1_enter;
            textBox1.Leave += textbox1_leave;
            // 
            // button1
            // 
            button1.Location = new Point(681, 74);
            button1.Name = "button1";
            button1.Size = new Size(162, 29);
            button1.TabIndex = 4;
            button1.Text = "Tarif Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(504, 25);
            button2.Name = "button2";
            button2.Size = new Size(171, 29);
            button2.TabIndex = 5;
            button2.Text = "Sonuçları filtrele ve Ara";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(866, 555);
            panel1.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(681, 25);
            button4.Name = "button4";
            button4.Size = new Size(162, 29);
            button4.TabIndex = 11;
            button4.Text = "Stok Bilgileri";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(503, 75);
            button3.Name = "button3";
            button3.Size = new Size(172, 29);
            button3.TabIndex = 10;
            button3.Text = "Malzemeye göre Ara";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Alfabetik (A-Z)", "Hazırlama Süresi(Artan)", "Hazırlama Süresi(Azalan)", "Maliyet(Artan)", "Maliyet(Azalan) " });
            comboBox3.Location = new Point(333, 75);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 9;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(13, 76);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 8;
            comboBox2.Text = "Malzemeler";
            comboBox2.Enter += comcobox2_enter;
            comboBox2.Leave += comcobox2_leave;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Location = new Point(13, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(841, 413);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 555);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button button3;
        private Button button4;
    }
}

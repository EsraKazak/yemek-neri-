namespace yemektarifleri
{
    partial class tarifDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tarifDetay));
            pictureBox1 = new PictureBox();
            labelAd = new Label();
            labelSüre = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            button5 = new Button();
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button4 = new Button();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(62, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(206, 304);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelAd
            // 
            labelAd.AutoSize = true;
            labelAd.BackColor = Color.Transparent;
            labelAd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelAd.Location = new Point(296, 62);
            labelAd.Name = "labelAd";
            labelAd.Size = new Size(79, 20);
            labelAd.TabIndex = 1;
            labelAd.Text = "Tarif Adı -";
            // 
            // labelSüre
            // 
            labelSüre.AutoSize = true;
            labelSüre.BackColor = Color.Transparent;
            labelSüre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSüre.Location = new Point(651, 62);
            labelSüre.Name = "labelSüre";
            labelSüre.Size = new Size(144, 20);
            labelSüre.TabIndex = 2;
            labelSüre.Text = "Hazırlanma Süresi -";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labelAd);
            panel1.Controls.Add(labelSüre);
            panel1.Location = new Point(4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(901, 719);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(button5);
            panel2.Location = new Point(644, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 224);
            panel2.TabIndex = 16;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(122, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(19, 138);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 7;
            label4.Text = "Birim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(19, 80);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 6;
            label3.Text = "Miktar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 18);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 5;
            label2.Text = "Malzeme Adı";
            label2.Click += label2_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(122, 131);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(122, 73);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 3;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(76, 192);
            button5.Name = "button5";
            button5.Size = new Size(121, 29);
            button5.TabIndex = 1;
            button5.Text = "Malzeme Ekle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // listBox1
            // 
            listBox1.Enabled = false;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(296, 142);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(321, 224);
            listBox1.TabIndex = 15;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(62, 428);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(635, 284);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(798, 62);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(53, 27);
            textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            textBox1.ForeColor = SystemColors.Desktop;
            textBox1.Location = new Point(376, 62);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(219, 27);
            textBox1.TabIndex = 12;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(717, 578);
            button3.Name = "button3";
            button3.Size = new Size(124, 29);
            button3.TabIndex = 11;
            button3.Text = "Tarifi Kaydet";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(717, 525);
            button2.Name = "button2";
            button2.Size = new Size(124, 29);
            button2.TabIndex = 8;
            button2.Text = "Tarifi Sil";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(399, 372);
            button4.Name = "button4";
            button4.Size = new Size(125, 29);
            button4.TabIndex = 0;
            button4.Text = "Malzeme Sil";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(717, 461);
            button1.Name = "button1";
            button1.Size = new Size(124, 29);
            button1.TabIndex = 7;
            button1.Text = "Tarifi Güncelle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(62, 391);
            label1.Name = "label1";
            label1.Size = new Size(125, 28);
            label1.TabIndex = 5;
            label1.Text = "Nasıl Yapılır?";
            // 
            // tarifDetay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(917, 732);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "tarifDetay";
            Text = "tarifDetay";
            FormClosed += tarifDetay_FormClosed;
            Load += tarifDetay_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelAd;
        private Label labelSüre;
        private Panel panel1;
        private Label label1;
        private Button button2;
        private Button button1;
        private Button button3;
        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox4;
        private Button button5;
        private Button button4;
        private TextBox textBox5;
        private ComboBox comboBox1;
    }
}
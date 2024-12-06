using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemektarifleri
{
    public partial class yenimalzeme : Form
    {
        private string kaynakform;
        public yenimalzeme()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string malzemeAdi = textBox1.Text;
            string toplamMiktar = textBox2.Text;
            string malzemeBirim = textBox3.Text;
            string birimFiyat = textBox4.Text;

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
         string.IsNullOrWhiteSpace(textBox2.Text) ||
         string.IsNullOrWhiteSpace(textBox3.Text) ||
         string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            
            sorgu sorguInstance = new sorgu();

            
            sorguInstance.MalzemeEkle(malzemeAdi, toplamMiktar, malzemeBirim, birimFiyat);

            MessageBox.Show("Malzeme başarıyla eklendi!");
            this.Close();
            tarifekle trf = new tarifekle();
            trf.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void yenimalzeme_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            
        }

        private void yenimalzeme_Load(object sender, EventArgs e)
        {

        }
    }
}

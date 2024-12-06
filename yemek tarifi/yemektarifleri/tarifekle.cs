using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemektarifleri
{
    public partial class tarifekle : Form
    {
        public tarifekle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tarifekle_Load(object sender, EventArgs e)
        {
            sorgu.KategoriDoldur(comboBox1);
            sorgu.MalzemeDoldur(comboBox2);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // OpenFileDialog ile okucaz 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Resim Seç";
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                pictureBox1.ImageLocation = openFileDialog.FileName;

              
                label3.Visible = false;
                
                label4.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            string tarifAdi = textBox1.Text.Trim();
            string yapilisi = richTextBox1.Text.Trim();
            string hazirlamaSuresi = textBox2.Text.Trim();
            string resimYolu = label4.Text.Trim(); 
            string kategoriAdi = comboBox1.SelectedItem?.ToString(); 

            
            if (string.IsNullOrEmpty(tarifAdi) || string.IsNullOrEmpty(yapilisi) ||
                string.IsNullOrEmpty(hazirlamaSuresi) || string.IsNullOrEmpty(resimYolu) ||
                string.IsNullOrEmpty(kategoriAdi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            List<Tuple<int, string>> secilenMalzemeler = new List<Tuple<int, string>>();

            // seçtiğimiz malzeme ve miktarını bu listeye eklşyoruz
            foreach (var item in listBox1.Items)
            {
                Malzeme malzeme = item as Malzeme;
                if (malzeme != null)
                {
                    int malzemeID = sorgu.GetMalzemeID(malzeme.Ad);
                    if (malzemeID != -1)
                    {
                        secilenMalzemeler.Add(new Tuple<int, string>(malzemeID, malzeme.Miktar));
                    }
                    else
                    {
                        MessageBox.Show($"Malzeme {malzeme.Ad} bulunamadı.");
                    }
                }
            }

           
            if (sorgu.TarifVarMi(tarifAdi))
            {
                MessageBox.Show("Bu isimde bir tarif zaten mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            bool tarifBasari = sorgu.TarifEkle(tarifAdi, yapilisi, hazirlamaSuresi, resimYolu, kategoriAdi, secilenMalzemeler);
            if (tarifBasari)
            {
                MessageBox.Show("Tarif başarıyla eklendi.");
                this.Close();
                Form1 frm = new Form1();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tarif eklenirken bir hata oluştu.");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string malzemeAd = comboBox2.SelectedItem?.ToString();

            
            string malzemeMiktar = textBox4.Text;
            string malzemeBirim = textBox5.Text; 

            
            if (!string.IsNullOrEmpty(malzemeAd) && !string.IsNullOrEmpty(malzemeMiktar) && !string.IsNullOrEmpty(malzemeBirim))
            {
                
                Malzeme yeniMalzeme = new Malzeme
                {
                    Ad = malzemeAd,
                    Miktar = malzemeMiktar,
                    Birim = malzemeBirim
                };

               
                listBox1.Items.Add(yeniMalzeme);

                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // eğer veitabanımda o malzeme yoksa yenisini eklemek için bu sayfa
            yenimalzeme yenmlzm = new yenimalzeme();
            yenmlzm.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tarifekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm=new Form1();
            frm.Show();
        }
    }
}

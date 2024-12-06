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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace yemektarifleri
{
    public partial class tarifDetay : Form
    {
        public tarifDetay()
        {
            InitializeComponent();
        }
        private int TarifID;


        private void tarifDetay_Load(object sender, EventArgs e)
        {

            sorgu.MalzemeDoldur(comboBox1);
        }

        public void Goster(Image resim, string tarifAd, string hazirlanmaSuresi, string talimat, int tarifID)
        {
            pictureBox1.Image = resim;
            textBox1.Text = tarifAd;
            textBox2.Text = hazirlanmaSuresi;
            richTextBox1.Text = talimat;
            TarifID = tarifID;


            List<string> malzemeler = sorgu.alTarifMalzemeler(tarifID);
            listBox1.Items.Clear();
            foreach (string malzeme in malzemeler)
            {
                listBox1.Items.Add(malzeme);
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            richTextBox1.Enabled = true;
            listBox1.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tarifAdi = textBox1.Text;
            string hazirlanmaSuresi = textBox2.Text;
            string yapilisi = richTextBox1.Text;
            button1.Enabled = false;

            

            if (!string.IsNullOrWhiteSpace(tarifAdi) && !string.IsNullOrWhiteSpace(hazirlanmaSuresi) && !string.IsNullOrWhiteSpace(yapilisi))
            {

                sorgu sorguNesnesi = new sorgu();
                bool basariliMi = sorguNesnesi.TarifGuncelle(TarifID,tarifAdi, hazirlanmaSuresi, yapilisi);

                if (basariliMi)
                {
                    MessageBox.Show("Tarif başarıyla güncellendi!");
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız oldu!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }


            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // silme butonuu
            string tarifAdi = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(tarifAdi))
            {

                sorgu sorguNesnesi = new sorgu();
                bool basariliMi = sorguNesnesi.TarifSil(TarifID);

                if (basariliMi)
                {
                    MessageBox.Show("Tarif başarıyla silindi!");
                    this.Hide();

                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız oldu!");
                }
            }
            else
            {
                MessageBox.Show("Silinecek tarif adını belirtiniz.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // malzeme silme butonuuu malzemeyi bu şekilde gümcelliyoz
            if (listBox1.SelectedItem != null)
            {


                string[] malzemedizi = listBox1.SelectedItem.ToString().Split('-');
                Malzeme secilenMalzeme = new Malzeme();
                secilenMalzeme.Ad = malzemedizi[0];
                secilenMalzeme.Miktar = malzemedizi[1];



                bool silmeBasariliMi = sorgu.MalzemeSil(TarifID, secilenMalzeme.Ad);

                if (silmeBasariliMi)
                {

                    listBox1.Items.Remove(secilenMalzeme);
                    MessageBox.Show("Malzeme başarıyla silindi!");
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız oldu!");
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir malzeme seçin.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // malzeme  ekleme butonuu
            string malzemeAd = comboBox1.SelectedItem?.ToString();


            string malzemeMiktar = textBox4.Text;
            string malzemeBirim = textBox5.Text;


            if (!string.IsNullOrEmpty(malzemeAd) && !string.IsNullOrEmpty(malzemeBirim))
            {


                bool eklemeBasariliMi = sorgu.MalzemeEkle2(TarifID, malzemeAd, malzemeMiktar);

                if (eklemeBasariliMi)
                {

                    listBox1.Items.Add($"{malzemeAd} - {malzemeMiktar} - {malzemeBirim}");
                    textBox4.Clear();
                    textBox5.Clear();
                    MessageBox.Show("Malzeme başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Malzeme eklenirken bir hata oluştu. Malzeme adı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tarifDetay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

     
    }
}

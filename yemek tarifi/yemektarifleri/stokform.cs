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
    public partial class stokform : Form
    {
        public stokform()
        {
            InitializeComponent();
            MalzemeTablosunuGoruntule();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";



        
        public static string ConnectionString
        {
            get { return connectionString; }
        }

        private void MalzemeTablosunuGoruntule()
        {
            
            string query = "SELECT  MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat FROM malzeme";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable malzemeTable = new DataTable();
                adapter.Fill(malzemeTable);

                
                dataGridView1.DataSource = malzemeTable;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

                
                string malzemeAdi = dataGridView1.Rows[selectedCell.RowIndex].Cells["MalzemeAdi"].Value.ToString();

                
                string yeniMiktar = textBox1.Text; 
                string yeniFiyat = textBox2.Text; 
                string ad = textBox3.Text;

                
                string query = "UPDATE malzeme SET ";

                
                if (!string.IsNullOrEmpty(yeniMiktar))
                {
                    query += "ToplamMiktar = @yeniMiktar ";
                }

                if (!string.IsNullOrEmpty(yeniFiyat))
                {
                    if (!string.IsNullOrEmpty(yeniMiktar))
                    {
                        query += ", "; 
                    }
                    query += "BirimFiyat = @yeniFiyat ";
                }

                query += "WHERE MalzemeAdi = @malzemeAdi";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        if (!string.IsNullOrEmpty(yeniMiktar))
                        {
                            command.Parameters.AddWithValue("@yeniMiktar", yeniMiktar);
                        }

                        if (!string.IsNullOrEmpty(yeniFiyat))
                        {
                            command.Parameters.AddWithValue("@yeniFiyat", yeniFiyat);
                        }

                        command.Parameters.AddWithValue("@malzemeAdi", ad);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Güncelleme başarılı!");
                                MalzemeTablosunuGoruntule();
                            }
                            else
                            {
                                MessageBox.Show("Güncelleme başarısız, malzeme bulunamadı.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir hücre seçin.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void stokform_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }


        private void stokform_FormClosed(object sender, FormClosedEventArgs e)
        {
            // direk kapatmak istediğimizde burdan geçiyoz
            Form1 anaForm = new Form1();
          anaForm.Show();
        } 
    }
}

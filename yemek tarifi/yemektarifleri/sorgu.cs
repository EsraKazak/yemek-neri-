using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yemektarifleri
{
    internal class sorgu
    {
        public static string connectionString = "Data Source=DESKTOP-IANIHDI\\SQLEXPRESS;Initial Catalog=tarif;Integrated Security=True";

        public static string ResimleriGetirSorgusu()
        {
            return "SELECT TarifID,resim, tarifAdi, hazirlamaSuresi ,Talimatlar FROM tarifler";
        }

        
        public static string ConnectionString
        {
            get { return connectionString; }
        }



        public bool TarifGuncelle(int tarifID, string tarifAdi, string hazirlanmaSuresi, string yapilisi)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    
                    string updateSorgu = "UPDATE tarifler SET TarifAdi = @tarifAdi, HazirlamaSuresi = @hazirlanmaSuresi, Talimatlar = @yapilisi WHERE TarifID = @tarifID";
                    SqlCommand updateKomut = new SqlCommand(updateSorgu, con);

                    
                    updateKomut.Parameters.AddWithValue("@tarifAdi", tarifAdi);
                    updateKomut.Parameters.AddWithValue("@hazirlanmaSuresi", hazirlanmaSuresi);
                    updateKomut.Parameters.AddWithValue("@yapilisi", yapilisi);
                    updateKomut.Parameters.AddWithValue("@tarifID", tarifID);

                   
                    int rowsAffected = updateKomut.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                       
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tarif bulunamadı.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    return false;
                }
            }
        }


        public bool TarifSil(int tarifID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //ilk tarifMalzemeden silicez hata çıkmasın diye ilişkiden dolayı
                string deleteMalzemeQuery = "DELETE FROM tarifMalzeme WHERE tarifID = @tarifID;";
                using (SqlCommand cmd = new SqlCommand(deleteMalzemeQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tarifID", tarifID);
                    cmd.ExecuteNonQuery(); 
                }

                // sonra tariflerden
                string deleteTarifQuery = "DELETE FROM tarifler WHERE TarifID = @tarifID;";
                using (SqlCommand cmd = new SqlCommand(deleteTarifQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@tarifID", tarifID);
                    int rowsAffected = cmd.ExecuteNonQuery(); 

                    
                    return rowsAffected > 0;
                }
            }
        }

        public static void KategoriDoldur(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT kategoriAdi FROM kategori", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["kategoriAdi"].ToString());
                    }
                }
            }
        }

        public static void MalzemeDoldur(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MalzemeAdi FROM malzeme ", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["MalzemeAdi"].ToString());
                    }
                }
            }
        }

        public static bool TarifEkle(string tarifAdi, string yapilisi, string hazirlamaSuresi, string resimYolu, string kategoriAdi, List<Tuple<int, string>> malzemeListesi)
        {
            int kategoriID = GetKategoriID(kategoriAdi);
            if (kategoriID == -1)
            {
                MessageBox.Show("Kategori bulunamadı.");
                return false;
            }

            string query = "INSERT INTO tarifler (TarifAdi, Talimatlar, HazirlamaSuresi, Resim, kategorii) " +
                           "VALUES (@tarifAdi, @Talimatlar, @hazirlamaSuresi, @resim, @kategorii);" +
                           "SELECT SCOPE_IDENTITY();"; // en sondaki işlm ıd yi almak için

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tarifAdi", tarifAdi);
                    cmd.Parameters.AddWithValue("@Talimatlar", yapilisi);
                    cmd.Parameters.AddWithValue("@hazirlamaSuresi", hazirlamaSuresi);
                    cmd.Parameters.AddWithValue("@resim", resimYolu);
                    cmd.Parameters.AddWithValue("@kategorii", kategoriID);

                    conn.Open();
                    
                    object result = cmd.ExecuteScalar();
                    int tarifID = Convert.ToInt32(result);

                    if (tarifID > 0)
                    {
                        
                        foreach (var malzeme in malzemeListesi)
                        {
                            int malzemeID = malzeme.Item1;
                            string miktar = malzeme.Item2;
                            //malzemeleri tarife ekleme kısmı
                            bool success = TarifMalzemeEkle(tarifID, malzemeID, miktar);
                            if (!success)
                            {
                                MessageBox.Show("Bir malzeme eklenemedi.");
                                return false;
                            }
                        }
                        return true;
                    }
                    return false;
                }
            }
        }


        public static bool TarifMalzemeEkle(int tarifID, int malzemeID, string miktar)
        {
            string query = "INSERT INTO tarifMalzeme (tarifID, malzemeID, MalzemeMiktar) VALUES (@tarifID, @malzemeID, @MalzemeMiktar)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tarifID", tarifID);
                    cmd.Parameters.AddWithValue("@malzemeID", malzemeID);
                    cmd.Parameters.AddWithValue("@MalzemeMiktar", miktar);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static int GetKategoriID(string kategoriAdi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT kategoriID FROM kategori WHERE kategoriAdi = @kategoriAdi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kategoriAdi", kategoriAdi);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return -1; 
            }
        }

        public static int GetMalzemeID(string malzemeAdi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT malzemeID FROM malzeme WHERE malzemeAdi = @malzemeAdi";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result); 
                }
                return -1; 
            }
        }





        public void MalzemeEkle(string malzemeAdi, string toplamMiktar, string malzemeBirim, string birimFiyat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO malzeme (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                    command.Parameters.AddWithValue("@ToplamMiktar", toplamMiktar);
                    command.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);
                    command.Parameters.AddWithValue("@BirimFiyat", birimFiyat);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        // aynı isimde tarif eklemeyi engelleme olayı buradaa
        public static bool TarifVarMi(string tarifAdi)
        {
            string query = "SELECT COUNT(*) FROM tarifler WHERE TarifAdi = @tarifAdi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tarifAdi", tarifAdi);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public static List<string> alTarifMalzemeler(int tarifID)
        {
            List<string> malzemeler = new List<string>();
            string query = "SELECT m.MalzemeAdi, tm.MalzemeMiktar,m.MalzemeBirim FROM tarifMalzeme tm " +
                           "JOIN malzeme m ON tm.malzemeID = m.MalzemeID " +
                           "WHERE tm.TarifID = @TarifID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tarifID", tarifID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string malzemeAdi = reader["MalzemeAdi"].ToString();
                        string miktar = reader["MalzemeMiktar"].ToString();
                        string birim = reader["MalzemeBirim"].ToString();    
                        malzemeler.Add($"{malzemeAdi} - {miktar} - {birim}");
                    }
                }
            }
            return malzemeler;
        }


        public static  decimal HesaplaMaliyet(int tarifID)
        {
            decimal toplamMaliyet = 0;

            string sql = @"
        SELECT 
            m.BirimFiyat, 
            m.MalzemeBirim, 
            tm.MalzemeMiktar 
        FROM 
            tarifMalzeme tm
        INNER JOIN 
            malzeme m ON tm.MalzemeID = m.MalzemeID
        WHERE 
            tm.TarifID = @TarifID";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TarifID", tarifID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            string birimFiyatStr = reader["BirimFiyat"].ToString();
                            
                            string malzemeBirim = reader["MalzemeBirim"].ToString();
                            
                            double malzemeMiktar = Convert.ToDouble(reader["MalzemeMiktar"]);

                            decimal birimFiyat;

                            // gram ve ml olarak giriyoruz arkada kg ve l ye çeviriyor
                            if (decimal.TryParse(birimFiyatStr, out birimFiyat))
                            {
                                decimal birimDönüşüm = 1; 

                                
                                if (malzemeBirim.Equals("gram", StringComparison.OrdinalIgnoreCase))
                                {
                                    
                                    birimDönüşüm = 1 / 1000m; 
                                }
                                else if (malzemeBirim.Equals("ml", StringComparison.OrdinalIgnoreCase))
                                {
                                    
                                    birimDönüşüm = 1/1000l; 
                                }
                                
                                toplamMaliyet += birimFiyat * (decimal)malzemeMiktar * birimDönüşüm; 
                            }
                            
                        }
                    }
                }
            }

            return toplamMaliyet;
        }


        public static bool YeterliMalzemeVarMi(int tarifID)
        {
            //tarifMalzeme  tablosu ile malzeme tablosunu birleştrip mşktar karşılaşılaştırması yaptık
            string sql = @"
        SELECT 
            m.ToplamMiktar, 
            tm.MalzemeMiktar 
        FROM 
            tarifMalzeme tm
        INNER JOIN 
            malzeme m ON tm.MalzemeID = m.MalzemeID
        WHERE 
            tm.TarifID = @TarifID";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TarifID", tarifID);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            decimal toplamMiktar = Convert.ToDecimal(reader["ToplamMiktar"]);
                          
                            double malzemeMiktar = Convert.ToDouble(reader["MalzemeMiktar"]);

                            
                            if (toplamMiktar < (decimal)malzemeMiktar)
                            {
                                return false; 
                            }
                        }
                    }
                }
            }

            return true; 
        }

        public static string tarifquery(string kategori, string malzeme, string aramaMetni, int? sortOrder)
        {
            // filtreleme için sorgu yapıyoz ve gelen bilgileri ekliyoz
            string query = "SELECT TarifID, resim, tarifAdi, hazirlamaSuresi, Talimatlar FROM tarifler WHERE 1=1";

            
            if (!string.IsNullOrEmpty(kategori))
            {
                query += " AND kategorii IN (SELECT kategoriID FROM kategori WHERE kategoriAdi = @kategori)";
            }

           
            if (!string.IsNullOrEmpty(malzeme))
            {
                query += " AND TarifID IN (SELECT tarifID FROM tarifMalzeme WHERE malzemeID = (SELECT malzemeID FROM malzeme WHERE MalzemeAdi = @malzeme))";
            }

            if (!string.IsNullOrEmpty(aramaMetni) && aramaMetni != "Yemek Tarifi Arayın")
            {
                query += " AND tarifAdi LIKE @tarifAdi";
            }

            
            if (sortOrder.HasValue)
            {
                switch (sortOrder.Value)
                {
                    case 0: 
                        query += " ORDER BY tarifAdi ASC";
                        break;
                    case 1: 
                        query += " ORDER BY hazirlamaSuresi ASC";
                        break;
                    case 2: 
                        query += " ORDER BY hazirlamaSuresi DESC";
                        break;
                        
                }
            }

            return query;
        }

        public static void Malzemeleripanelekoy(Panel panel, Panel tarifPanel)
{
              panel.Controls.Clear(); 
             panel.AutoScroll = true; 

            int x = 10; 
            int y = 10;
            int checkboxWidth = 160;
            int checkboxHeight = 30;
            int columnCount = 5;

    int currentColumn = 0; 

    // malzemeleri getirdiğimiz sorgu
        string query = "SELECT MalzemeID, MalzemeAdi FROM malzeme";
        using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    CheckBox cb = new CheckBox();
                    cb.Text = reader["MalzemeAdi"].ToString();
                    cb.Tag = reader["MalzemeID"]; 
                    cb.AutoSize = true;
                    cb.Location = new Point(x, y);

                    cb.CheckedChanged += (s, e) => 
                    {
                        MalzemelereGoreTarifGetir(panel, tarifPanel); // malzememize göre Tarifi listeleyen fonksiyon
                    };

                   
                    panel.Controls.Add(cb);

                    
                    currentColumn++;
                    if (currentColumn >= columnCount)
                    {
                        currentColumn = 0;
                                x = 10;
                        y += checkboxHeight; 
                    }
                    else
                    {
                        x += checkboxWidth; 
                    }
                }
            }
        }
    }
}
        public static void MalzemelereGoreTarifGetir(Panel malzemePanel, Panel tarifPanel)
        {
            
            List<int> secilenMalzemeIDler = new List<int>();
            foreach (Control control in malzemePanel.Controls)
            {
                if (control is CheckBox cb && cb.Checked)
                {
                    secilenMalzemeIDler.Add((int)cb.Tag); 
                }
            }
            
            if (secilenMalzemeIDler.Count == 0)
            {
                
                tarifPanel.Controls.Clear();
                return;
            }
           
            string malzemeFiltre = string.Join(",", secilenMalzemeIDler);
            string query = $@"
  SELECT 
    t.TarifID, 
    t.TarifAdi,
    t.HazirlamaSuresi,
    (COUNT(DISTINCT tm.MalzemeID) * 100.0) / NULLIF((SELECT COUNT(*) 
                                                      FROM tarifMalzeme 
                                                      WHERE TarifID = t.TarifID), 0) AS EslestirmeYuzdesi  
FROM 
    tarifler AS t
INNER JOIN 
    tarifMalzeme AS tm ON t.TarifID = tm.TarifID
WHERE 
    tm.MalzemeID IN ({malzemeFiltre}) -- Seçilen malzemeler
GROUP BY 
    t.TarifID, t.TarifAdi,t.HazirlamaSuresi
HAVING 
    COUNT(DISTINCT tm.MalzemeID) = {secilenMalzemeIDler.Count} -- Tarifin tüm seçilen malzemelere sahip olması
ORDER BY 
    EslestirmeYuzdesi DESC;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        tarifPanel.Controls.Clear();

                        int x = 10; 
                        int y = 10; 
                        int pictureBoxWidth = 100; 
                        int pictureBoxHeight = 100; 
                        int labelHeight = 30; 
                        int margin = 20; 

                        while (reader.Read())
                        {
                            int tarifID = (int)reader["TarifID"]; 
                            string tarifAdi = reader["TarifAdi"].ToString();
                            string hazirlamaSuresi = reader["HazirlamaSuresi"].ToString(); 
                            decimal eslestirmeYuzdesi = Convert.ToDecimal(reader["EslestirmeYuzdesi"]);

                            // resimi ve yapılışı farklı sorguda alıyoruz çünkü tip hatası veriyr
                            string talimat, resimYolu;
                            TarifDetaylariAl(tarifID, out talimat, out resimYolu);
                            Image resim = Image.FromFile(resimYolu);

                            PictureBox pictureBox = new PictureBox
                            {
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Image = resim,
                                Location = new Point(x, y),
                                Size = new Size(pictureBoxWidth, pictureBoxHeight)
                            };
                            bool yeterli = YeterliMalzemeVarMi(tarifID);
                            Label lblTarif = new Label
                            {


                                Text = $"{tarifAdi}\n{eslestirmeYuzdesi:F2}%",
                                AutoSize = true,
                                Location = new Point(x, y + pictureBoxHeight + 5), 
                                ForeColor = yeterli ? Color.Green : Color.Red
                        };
                            // bu kısım malzemeye göre ara kısmından tarif detaya geçmek için
                            pictureBox.Click += (sender, e) =>
                            {
                                
                                tarifDetay detayForm = new tarifDetay();
                                detayForm.Goster(resim, tarifAdi, hazirlamaSuresi, talimat, tarifID);
                                detayForm.ShowDialog(); 
                            };

                            
                            tarifPanel.Controls.Add(pictureBox);
                            tarifPanel.Controls.Add(lblTarif);

                            x += pictureBoxWidth + margin + 5; 

                            
                            if (x + pictureBoxWidth > tarifPanel.Width)
                            {
                                x = 10; 
                                y += pictureBoxHeight + labelHeight + margin + 10; 
                            }
                        }
                    }
                }
            }
        }

       
        private static void TarifDetaylariAl(int tarifID, out string talimat, out string resimYolu)
        {
            talimat = "";
            resimYolu = "default_image_path.jpg"; 

            string query = "SELECT Talimatlar, resim FROM tarifler WHERE TarifID = @TarifID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TarifID", tarifID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            talimat = reader["Talimatlar"].ToString();
                            resimYolu = reader["resim"].ToString();
                        }
                    }
                }
            }
        }


        // tarifdeki malzemeyi silmek için kullanılıyor 
        public static bool MalzemeSil(int tarifID, string malzemeAdi)
        {
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                
                string getMalzemeIDQuery = "SELECT MalzemeID FROM malzeme WHERE MalzemeAdi = @malzemeAdi";
                SqlCommand getMalzemeIDCommand = new SqlCommand(getMalzemeIDQuery, connection);
                getMalzemeIDCommand.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);

                connection.Open();
                object result = getMalzemeIDCommand.ExecuteScalar(); 

                
                if (result != null)
                {
                    int malzemeID = Convert.ToInt32(result);

                    
                    string deleteQuery = "DELETE FROM tarifMalzeme WHERE TarifID = @tarifID AND MalzemeID = @malzemeID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@tarifID", tarifID);
                    deleteCommand.Parameters.AddWithValue("@malzemeID", malzemeID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
                else
                {
                    return false; 
                }
            }
        }

        public static bool MalzemeEkle2(int tarifID, string malzemeAdi, string malzemeMiktar)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               
                string malzemeIDQuery = "SELECT MalzemeID FROM malzeme WHERE MalzemeAdi = @MalzemeAdi";

                int malzemeID;
                using (SqlCommand cmd = new SqlCommand(malzemeIDQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                    connection.Open();
                    var result = cmd.ExecuteScalar(); 
                    malzemeID = result != null ? Convert.ToInt32(result) : -1;
                }

           
                if (malzemeID == -1)
                {
                    return false; 
                }

               
                string query = "INSERT INTO tarifMalzeme (TarifID, MalzemeID, MalzemeMiktar) " +
                               "VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TarifID", tarifID);
                    command.Parameters.AddWithValue("@MalzemeID", malzemeID);
                    command.Parameters.AddWithValue("@MalzemeMiktar", malzemeMiktar);
                   

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Eğer bir veya daha fazla satır eklendiyse true döner
                }
            }
        }


    }
}

using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using Kütüphane_Otomasyonu.Properties;
using System.Reflection.Emit;

namespace Kütüphane_Otomasyonu
{
    public partial class Form3 : Form
    {
        // Veritabanı URL'sini tutan sabit bir değişken
        private static readonly string urlDatabase = ConnDatabase.HomeUrl;

        // Veritabanı bağlantı dizesini oluşturan sabit bir değişken
        private static readonly string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={urlDatabase}";

        // OleDb bağlantısı nesnesi
        private static readonly OleDbConnection connection = new OleDbConnection(connectionString);

        // Form3 sınıfının yapıcı metodu
        public Form3()
        {
            InitializeComponent();
            RefreshDataGridView();
            SetControlsVisibility(false);
        }

        // Form yüklenirken gerçekleşen olay işleyici metodu
        private void Form3_Load(object sender, EventArgs e)
        {
            // Bu metot boş, herhangi bir işlevi yok.
        }

        // Kontrollerin görünürlüğünü ayarlayan yardımcı bir metot
        private void SetControlsVisibility(bool visible)
        {
            // Belirtilen görünürlük durumuna göre kontrollerin görünürlüğünü ayarlar
            button1.Visible = visible;
            button2.Visible = visible;
            button3.Visible = visible;
            button4.Visible = visible;
            label1.Visible = visible;
            label2.Visible = visible;
            label3.Visible = visible;
            label4.Visible = visible;
            textBox1.Visible = visible;
            textBox2.Visible = visible;
            textBox3.Visible = visible;
            textBox4.Visible = visible;
        }

        // "kİTAPEKLEToolStripMenuItem" menü öğesine tıklandığında gerçekleşen olay işleyici metodu
        private void kİTAPEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kontrollerin görünürlüğünü ayarlar
            SetControlsVisibility(true);

            // Metin kutularını temizler
            ClearTextBoxes();

            // Veri tablosunu yeniler
            RefreshDataGridView();

            // Belirli düğmelerin görünürlüğünü ayarlar
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        // "kİTAPSİLToolStripMenuItem" menü öğesine tıklandığında gerçekleşen olay işleyici metodu
        private void kİTAPSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kontrollerin görünürlüğünü ayarlar
            SetControlsVisibility(true);

            // Metin kutularını temizler
            ClearTextBoxes();

            // Veri tablosunu yeniler
            RefreshDataGridView();

            // Belirli düğmelerin görünürlüğünü ayarlar
            button1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            // Belirli metin kutularının görünürlüğünü ayarlar
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        // "kİTAPARAToolStripMenuItem" menü öğesine tıklandığında gerçekleşen olay işleyici metodu
        private void kİTAPARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kontrollerin görünürlüğünü ayarlar
            SetControlsVisibility(true);

            // Metin kutularını temizler
            ClearTextBoxes();

            // Veri tablosunu yeniler
            RefreshDataGridView();

            // Belirli düğmelerin görünürlüğünü ayarlar
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;

            // Belirli metin kutularının görünürlüğünü ayarlar
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        // "kİTAPBİLGİLERİGÜNCELLEToolStripMenuItem" menü öğesine tıklandığında gerçekleşen olay işleyici metodu
        private void kİTAPBİLGİLERİGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kontrollerin görünürlüğünü ayarlar
            SetControlsVisibility(true);

            // Metin kutularını temizler
            ClearTextBoxes();

            // Veri tablosunu yeniler
            RefreshDataGridView();

            // Belirli düğmelerin görünürlüğünü ayarlar
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        // "button1" düğmesine tıklandığında gerçekleşen olay işleyici metodu
        private void button1_Click(object sender, EventArgs e)
        {
            // Metin kutularının boş olup olmadığını kontrol eder
            if (IsTextBoxEmpty(textBox1, textBox2, textBox3, textBox4))
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                // Metin kutularından alınan verileri değişkenlere atar
                string kitapAdı = textBox1.Text;
                int sayfaNo = Convert.ToInt32(textBox2.Text);
                string yazar = textBox3.Text;
                string basımEvi = textBox4.Text;

                // B10 sınıfındaki KitapEkle metodunu çağırır
                B10.KitapEkle(kitapAdı, sayfaNo, yazar, basımEvi);

                // Başarılı bir şekilde kitap eklendiğine dair bir ileti görüntüler
                MessageBox.Show("KİTAP SİSTEME BAŞARIYLA EKLENDİ...");

                // Veri tablosunu yeniler
                RefreshDataGridView();

                // Metin kutularını temizler
                ClearTextBoxes();
            }
        }

        // "button2" düğmesine tıklandığında gerçekleşen olay işleyici metodu
        private void button2_Click(object sender, EventArgs e)
        {
            // Metin kutularının boş olup olmadığını kontrol eder
            if (IsTextBoxEmpty(textBox1))
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                // Metin kutusundan alınan kitap adını değişkene atar
                string kitapAdı = textBox1.Text;

                // B10 sınıfındaki KitapSil metodunu çağırır
                B10.KitapSil(kitapAdı);

                // İstenilen kitabın başarıyla silindiğine dair bir ileti görüntüler
                MessageBox.Show("İstenilen Kitap Başarıyla Silindi...");

                // Metin kutularını temizler
                ClearTextBoxes();

                // Veri tablosunu yeniler
                RefreshDataGridView();
            }
        }

        // "button3" düğmesine tıklandığında gerçekleşen olay işleyici metodu
        private void button3_Click(object sender, EventArgs e)
        {
            // Metin kutularının boş olup olmadığını kontrol eder
            if (IsTextBoxEmpty(textBox1))
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                // Metin kutusundan alınan kitap adını değişkene atar
                string kitapAdı = textBox1.Text;

                // Kitap adına göre veritabanından ilgili kayıtları sorgular
                string query = $"SELECT * FROM Kitap WHERE KitapAdı LIKE '%{kitapAdı}%'";

                // OleDBDataAdapter nesnesini kullanarak sorguyu çalıştırır ve sonuçları DataSet'e doldurur
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }

                // Metin kutularını temizler
                ClearTextBoxes();
            }
        }

        // "button4" düğmesine tıklandığında gerçekleşen olay işleyici metodu
        private void button4_Click(object sender, EventArgs e)
        {
            // Metin kutularının boş olup olmadığını kontrol eder
            if (IsTextBoxEmpty(textBox1, textBox2, textBox3, textBox4))
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                // Metin kutularından alınan verileri değişkenlere atar
                string KitapAdı = textBox1.Text;
                int SayfaNo = Convert.ToInt32(textBox2.Text);
                string Yazar = textBox3.Text;
                string BasımEvi = textBox4.Text;

                // B10 sınıfındaki KitapGuncelle metodunu çağırır
                B10.KitapGuncelle(KitapAdı, SayfaNo, Yazar, BasımEvi);

                // Seçilen kitabın başarıyla güncellendiğine dair bir ileti görüntüler
                MessageBox.Show("SEÇİLEN KİTAP BAŞARIYLA GÜNCELLENDİ...");

                // Metin kutularını temizler
                ClearTextBoxes();

                // Veri tablosunu yeniler
                RefreshDataGridView();
            }
        }

        // Metin kutularının boş olup olmadığını kontrol eden bir yardımcı metot
        private bool IsTextBoxEmpty(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                    return true;
            }
            return false;
        }

        // Metin kutularını temizleyen bir yardımcı metot
        private void ClearTextBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                    textBox.Clear();
            }
        }

        // Veri tablosunu yenileyen bir yardımcı metot
        private void RefreshDataGridView()
        {
            // OleDBDataAdapter nesnesini kullanarak tüm Kitap kayıtlarını veritabanından seçer ve DataSet'e doldurur
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Kitap", connection))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }

        // DataGridView hücresine tıklandığında gerçekleşen olay işleyici metodu
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırın indeksini alır
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;

            // Seçilen satırdaki verileri alır
            string kitapAdı = dataGridView1.Rows[selectedRow].Cells[1].Value.ToString();
            string sayfaNo = dataGridView1.Rows[selectedRow].Cells[2].Value.ToString();
            string yazar = dataGridView1.Rows[selectedRow].Cells[3].Value.ToString();
            string basımEvi = dataGridView1.Rows[selectedRow].Cells[4].Value.ToString();

            // Metin kutularına seçilen kitap bilgilerini yerleştirir
            textBox1.Text = kitapAdı;
            textBox2.Text = sayfaNo;
            textBox3.Text = yazar;
            textBox4.Text = basımEvi;

            // Veri tablosunu yeniler
            RefreshDataGridView();
        }

        // "mENÜToolStripMenuItem" menü öğesine tıklandığında gerçekleşen olay işleyici metodu
        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Formu kapatır
            Close();

            // Form2'yi oluşturur ve gösterir
            Form2 form2 = new Form2();
            form2.Show();
        }

        // "çIKIŞToolStripMenuItem" menü öğesine tıklandığında gerçekleşen olay işleyici metodu
        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uygulamayı kapatır
            Application.Exit();
        }
    }
}
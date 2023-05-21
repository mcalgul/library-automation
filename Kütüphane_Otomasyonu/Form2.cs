using System;
using System.Windows.Forms;
using System.Data.OleDb;
using Kütüphane_Otomasyonu.Properties;

namespace Kütüphane_Otomasyonu
{
    public partial class Form2 : Form
    {
        private static readonly string urlDatabase = ConnDatabase.HomeUrl;  // Veritabanının URL'sini temsil eden bir değişken
        private static readonly string baglantiYolu = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={urlDatabase}";  // Veritabanı bağlantı dizesini temsil eden bir değişken
        private static readonly OleDbConnection baglanti = new OleDbConnection(baglantiYolu);  // Veritabanı bağlantısını temsil eden bir OleDbConnection nesnesi

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();  // label7'ye güncel saat ve tarih bilgisini yaz
        }

        private void hAKKIMIZDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayMessage("BU OTOMASYON UYGULAMASI SAKARYA UYGULAMALI BİLİMLER ÜNİVERSİTESİ HENDEK MESLEK YÜKSEKOKULU ÖĞRENCİSİ MUHAMMED CİHAT ALGÜL TARAFINDAN 'GÖRSEL PROGRAMLAMA 2' DERSİ ÖDEVİ OLARAK YAPILMIŞTIR.");  // Bir mesaj kutusuyla hakkımızda bilgisi göster
        }

        private void OpenExternalProcess(string processName) // Erişim Kolaylığı menüsü içerinde bulunan uygulamaları açmak için hazırlanan fonksiyon
        {
            try
            {
                System.Diagnostics.Process.Start(processName);  // Belirtilen işlemi başlat (harici bir uygulamayı çalıştır)
            }
            catch (Exception ex)
            {
                DisplayMessage($"Bir hata oluştu: {ex.Message}");  // Bir hata durumunda hatayı göster
            }
        }

        private void hESAPMAKİNESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenExternalProcess("calc.exe");  // Hesap makinesi uygulamasını aç
        }

        private void nOTDEFTERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenExternalProcess("notepad.exe");  // Not defteri uygulamasını aç
        }

        private void pOSTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenExternalProcess("mailto:");  // E-posta gönderme işlemi için varsayılan e-posta istemcisini aç
        }

        private void sAYAÇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenExternalProcess("ms-clock:");  // Saat ve tarih uygulamasını aç
        }

        private void tAKVİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenExternalProcess("outlookcal:");  // Takvim uygulamasını aç
        }

        private void DisplayForm<T>() where T : Form, new()
        {
            T yeni = new T();  // Yeni bir form nesnesi oluştur
            yeni.Show();  // Formu göster
            this.Hide();  // Şu anki formu gizle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayForm<Form3>();  // Form3'ü göstermek için DisplayForm fonksiyonunu çağır
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayForm<Form4>();  // Form4'ü göstermek için DisplayForm fonksiyonunu çağır
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayForm<Form5>();  // Form5'i göstermek için DisplayForm fonksiyonunu çağır
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Uygulamayı kapat
        }

        private void DisplayMessage(string message)
        {
            MessageBox.Show(message);  // Bir mesaj kutusuyla mesajı göster
        }
    }
}
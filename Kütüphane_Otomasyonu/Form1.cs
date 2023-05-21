using System;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public string KullaniciAdi;  // Kullanıcı adını temsil eden bir değişken
        public string Sifre;  // Şifreyi temsil eden bir değişken
        public bool sonuc;  // Doğrulama sonucunu temsil eden bir değişken

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Giriş Butonuna basıldığı zaman çalışacak fonksiyon.
        {
            if (textBox1.Text == null || textBox2.Text == null) // Giriş yapma aşamasında kullanıcı adı ve şifre bilgilerin girilip girilmediğini kontrol ediyor.
            {
                MessageBox.Show("Lütfen Kullanıcı Adınızı ve Şifrenizi Girin!");
            }
            else
            {
                KullaniciAdi = textBox1.Text;  // textBox1'in içeriğini KullaniciAdi değişkenine ata
                Sifre = textBox2.Text;  // textBox2'nin içeriğini Sifre değişkenine ata
                logControl(KullaniciAdi, Sifre);  // logControl fonksiyonunu çağır ve KullaniciAdi ile Sifre parametrelerini gönder.
            }
        }

        private void logControl(string KullaniciAdi, string Sifre)
        {
            sonuc = B10.Admin(KullaniciAdi, Sifre);  // B10 sınıfındaki Admin fonksiyonunu çağır ve sonuc değişkenine atama yap

            if (checkBox1.Checked)  // checkBox1'in işaretli olup olmadığını kontrol et
            {
                if (sonuc == false)  // Doğrulama sonucunun yanlış olduğunu kontrol et
                {
                    MessageBox.Show("Kullanıcı adı yada şifre yanlış!!!");
                    textBox1.Clear();  // textBox1'i temizle
                    textBox2.Clear();  // textBox2'yi temizle
                }
                else
                {
                    Form1 kapat = new Form1();  // Yeni bir Form1 nesnesi oluştur
                    kapat.Close();  // Oluşturulan Form1 nesnesini kapat
                    Form2 yeni = new Form2();  // Yeni bir Form2 nesnesi oluştur
                    yeni.Show();  // Form2'yi göster
                    this.Hide();  // Form1'i gizle
                }
            }
            else
            {
                MessageBox.Show("Siz Bir Robotsunuz!!!"); //  checkBox1'in işaretli olmadığı durumda mesaj yazdır
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e) // Yer alan LinkLabel1 eventinin kontrolleri
        {
            linkLabel1.LinkVisited = true;  // Link ziyaret edildi olarak işaretlendi

            System.Diagnostics.Process.Start("https://github.com/mcalgul/library-automation");  // Belirtilen URL'yi varsayılan tarayıcıda aç
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Uygulamayı kapat
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // CheckBox'ın durumu değiştirildiğinde herhangi bir işlem yapılmıyor
        }
    }
}
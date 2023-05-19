using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public string KullaniciAdi;
        public string Sifre;
        public bool sonuc;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null)
            {
                MessageBox.Show("Lütfen Kullanıcı Adınızı ve Şifrenizi Girin!");
            }
            else
            {
                KullaniciAdi = textBox1.Text;
                Sifre = textBox2.Text;
                logControl(KullaniciAdi, Sifre);
            }
        }
        private void logControl(string KullaniciAdi, string Sifre)
        {
            sonuc = B10.Admin(KullaniciAdi, Sifre);
            if (sonuc == false)
            {
                MessageBox.Show("Kullanıcı adı yada şifre yanlış!!!");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                Form1 kapat = new Form1();
                kapat.Close();
                Form2 yeni = new Form2();
                yeni.Show();
                this.Hide();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

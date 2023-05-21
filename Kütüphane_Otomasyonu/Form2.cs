using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Kütüphane_Otomasyonu.Properties;

namespace Kütüphane_Otomasyonu
{
    public partial class Form2 : Form
    {
        public static string urlDatabase = ConnDatebase.homeUrl;
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + urlDatabase;
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
        }

        private void hAKKIMIZDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU OTOMASYON UYGULAMASI SAKARYA UYGULAMALI BİLİMLER ÜNİVERSİTESİ HENDEK MESLEK YÜKSEKOKULU ÖĞRENCİSİ MUHAMMED CİHAT ALGÜL TARAFINDAN 'GÖRSEL PROGRAMLAMA 2' DERSİ ÖDEVİ OLARAK YAPILMIŞTIR.");
        }


        private void hESAPMAKİNESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void nOTDEFTERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void pOSTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void sAYAÇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("ms-clock:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void tAKVİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("outlookcal:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form3 yeni = new Form3();
            yeni.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form4 yeni = new Form4();
            yeni.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 kapat = new Form2();
            kapat.Close();
            Form5 yeni = new Form5();
            yeni.Show();
            this.Hide();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

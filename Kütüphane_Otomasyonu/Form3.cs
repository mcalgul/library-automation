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
    public partial class Form3 : Form
    {
        public static string urlDatabase = ConnDatebase.homeUrl;
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + urlDatabase;
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        public Form3()
        {
            InitializeComponent();
            kitapListele();

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void kİTAPEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void kİTAPSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void kİTAPARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void kİTAPBİLGİLERİGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string KitapAdı = textBox1.Text;
                int SayfaNo = Convert.ToInt32(textBox2.Text);
                string Yazar = textBox3.Text;
                string BasımEvi = textBox4.Text;
                B10.KitapEkle(KitapAdı, SayfaNo, Yazar, BasımEvi);
                MessageBox.Show("KİTAP SİSTEME BAŞARIYLA EKLENDİ...");
                kitapListele();
                clearText();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null) 
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string KitapAdı = textBox1.Text;
                B10.KitapSil(KitapAdı);
                MessageBox.Show("İstenilen Kitap Başarıyla Silindi...");
                clearText();
                kitapListele();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            } 
            else
            {
                baglanti.Open();
                string veri = "select * from Kitap where KitapAdı like '%" + textBox1.Text + "%'";
                OleDbCommand komut = new OleDbCommand(veri, baglanti);
                OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                baglanti.Close();
                clearText();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string KitapAdı = textBox1.Text;
                int SayfaNo = Convert.ToInt32(textBox2.Text);
                string Yazar = textBox3.Text;
                string BasımEvi = textBox4.Text;
                B10.KitapGuncelle(KitapAdı, SayfaNo, Yazar, BasımEvi);
                MessageBox.Show("SEÇİLEN KİTAP BAŞARIYLA GÜNCELLENDİ...");
                clearText();
                kitapListele();
            }
        }

        public void clearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        public void kitapListele()
        {
            string veri = "select*from Kitap";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string KitapAdı = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string SayfaNo = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string Yazar = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string BasımEvi = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            textBox1.Text = KitapAdı;
            textBox2.Text = SayfaNo.ToString();
            textBox3.Text = Yazar;
            textBox4.Text = BasımEvi;
            kitapListele();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 kapat = new Form3();
            kapat.Close();
            Form2 ac = new Form2();
            ac.Show();
            this.Hide();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

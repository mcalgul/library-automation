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
using System.Reflection.Emit;

namespace Kütüphane_Otomasyonu
{
    public partial class Form5 : Form
    {
        public static string urlDatabase = ConnDatebase.homeUrl;
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + urlDatabase;
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        public Form5()
        {
            InitializeComponent();
            üyeleriListele();

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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void üYEEKLEToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void üYESİLToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void üYEGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void üYEARAToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string ÜyeAdı = textBox1.Text;
                string ÜyeSoyadı = textBox2.Text;
                string Meslek = textBox3.Text;
                int TelNo = Convert.ToInt32(textBox4.Text);

                B10.üyeEkle(ÜyeAdı, ÜyeSoyadı, Meslek, TelNo);
                MessageBox.Show("ÜYE KAYDI  BAŞARILI...");
                üyeleriListele();
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
                string ÜyeAdı = textBox1.Text;
                B10.üyeSil(ÜyeAdı);
                MessageBox.Show("İSTENİLEN ÜYE BAŞARIYLA SİLİNDİ...");
                üyeleriListele();
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
                string ÜyeAdı = textBox1.Text;
                string ÜyeSoyadı = textBox2.Text;
                string Meslek = textBox3.Text;
                int TelNo = Convert.ToInt32(textBox4.Text);
                B10.üyeGuncelle(ÜyeAdı, ÜyeSoyadı, Meslek, TelNo);
                MessageBox.Show("SEÇİLEN KİŞİ BAŞARIYLA GÜNCELLENDİ...");
                üyeleriListele();
                clearText();
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
                string veri = "select * from Üyeler where ÜyeAdı like '%" + textBox1.Text + "%'";
                OleDbCommand komut = new OleDbCommand(veri, baglanti);
                OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                baglanti.Close();
                clearText();
            }
        }

        public void üyeleriListele()
        {
            string veri = "select*from Üyeler";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ÜyeAdı = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string ÜyeSoyadı = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string Meslek = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            int TelNo = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[4].Value);

            textBox1.Text = ÜyeAdı;
            textBox2.Text = ÜyeSoyadı;
            textBox3.Text = Meslek;
            textBox4.Text = TelNo.ToString();
            üyeleriListele();
        }

        public void clearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 kapat = new Form5();
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

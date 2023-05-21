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
    public partial class Form4 : Form
    {
        public static string urlDatabase = ConnDatebase.homeUrl;
        static string baglantiYolu = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + urlDatabase;
        static OleDbConnection baglanti = new OleDbConnection(baglantiYolu);

        public Form4()
        {
            InitializeComponent();
            emanetListele();

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void eMANETKİTAPEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void eMANETKİTAPSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void eMANETKİTAPGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void eMANETKİTAPARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null) 
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string KitapAdı = textBox1.Text;
                int KitapNo = Convert.ToInt32(textBox2.Text);
                string ÜyeAdı = textBox3.Text;
                int ÜyeNo = Convert.ToInt32(textBox4.Text);
                string AldığıTarih = dateTimePicker1.Text;
                B10.emanetEkle(KitapAdı, KitapNo, ÜyeAdı, ÜyeNo, AldığıTarih);
                MessageBox.Show("İSTENİLEN KİTAP EMANETLER LİSTESİNE BAŞARIYLA EKLENDİ...");
                emanetListele();
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
                B10.emanetSil(KitapAdı);
                MessageBox.Show("İSTENİLEN KİTAP BAŞARIYLA SİLİNDİ...");
                clearText();
                emanetListele();
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
                int KitapNo = Convert.ToInt32(textBox2.Text);
                string ÜyeAdı = textBox3.Text;
                int ÜyeNo = Convert.ToInt32(textBox4.Text);
                string AldığıTarih = dateTimePicker1.Text;
                B10.emanetGuncelle(KitapAdı, KitapNo, ÜyeAdı, ÜyeNo, AldığıTarih);
                MessageBox.Show("SEÇİLEN KİTAP BAŞARIYLA GÜNCELLENDİ...");
                clearText();
                emanetListele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == null)
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                baglanti.Open();
                string veri = "select * from Emanetler where KitapAdı like '%" + textBox1.Text + "%'";
                OleDbCommand komut = new OleDbCommand(veri, baglanti);
                OleDbDataAdapter adaptor = new OleDbDataAdapter(komut);
                DataSet DS = new DataSet();
                adaptor.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                baglanti.Close();
                clearText();
            }
        }

        public void emanetListele()
        {
            string veri = "select*from Emanetler";
            OleDbDataAdapter adaptor = new OleDbDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string KitapAdı = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            int KitapNo = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[2].Value);
            string ÜyeAdı = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            int ÜyeNo = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[4].Value);
            string AldığıTarih = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            textBox1.Text = KitapAdı;
            textBox2.Text = KitapNo.ToString();
            textBox3.Text = ÜyeAdı;
            textBox4.Text = ÜyeNo.ToString();
            dateTimePicker1.Text = AldığıTarih;
            emanetListele();
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
            Form4 kapat = new Form4();
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

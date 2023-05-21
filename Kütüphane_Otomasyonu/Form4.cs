using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using Kütüphane_Otomasyonu.Properties;
using System.Reflection.Emit;

namespace Kütüphane_Otomasyonu
{
    public partial class Form4 : Form
    {
        private static readonly string urlDatabase = ConnDatabase.HomeUrl;
        private static readonly string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={urlDatabase}";
        private static readonly OleDbConnection connection = new OleDbConnection(connectionString);

        public Form4()
        {
            InitializeComponent();
            RefreshDataGridView();
            SetControlsVisibility(false);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void SetControlsVisibility(bool visible)
        {
            button1.Visible = visible;
            button2.Visible = visible;
            button3.Visible = visible;
            button4.Visible = visible;
            label1.Visible = visible;
            label2.Visible = visible;
            label3.Visible = visible;
            label4.Visible = visible;
            label5.Visible = visible;
            textBox1.Visible = visible;
            textBox2.Visible = visible;
            textBox3.Visible = visible;
            textBox4.Visible = visible;
            dateTimePicker1.Visible = visible;
        }

        private void eMANETKİTAPEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetControlsVisibility(true);
            ClearTextBoxes();
            RefreshDataGridView();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        private void eMANETKİTAPSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetControlsVisibility(true);
            ClearTextBoxes();
            RefreshDataGridView();
            button1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void eMANETKİTAPARAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetControlsVisibility(true);
            ClearTextBoxes();
            RefreshDataGridView();
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void eMANETKİTAPGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetControlsVisibility(true);
            ClearTextBoxes();
            RefreshDataGridView();
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsTextBoxEmpty(textBox1, textBox2, textBox3, textBox4))
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
                RefreshDataGridView();
                ClearTextBoxes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsTextBoxEmpty(textBox1))
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string kitapAdı = textBox1.Text;
                B10.emanetSil(kitapAdı);
                MessageBox.Show("İstenilen Kitap Başarıyla Silindi...");
                ClearTextBoxes();
                RefreshDataGridView();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsTextBoxEmpty(textBox1))
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI DOLDURUN!");
            }
            else
            {
                string emanet = textBox1.Text;
                string query = $"SELECT * FROM Emanetler WHERE KitapAdı LIKE '%{emanet}%'";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    ClearTextBoxes();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsTextBoxEmpty(textBox1, textBox2, textBox3, textBox4))
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
                ClearTextBoxes();
                RefreshDataGridView();
            }
        }

        private bool IsTextBoxEmpty(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                    return true;
            }
            return false;
        }

        private void ClearTextBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                    textBox.Clear();
            }
        }

        private void RefreshDataGridView()
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Emanetler", connection))
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
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
            RefreshDataGridView();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
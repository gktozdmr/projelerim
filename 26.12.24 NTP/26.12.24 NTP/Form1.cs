using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{ 
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        DataTable dt = new DataTable();
        SqlCommand komut;

        void doldur()
        {
            con = new SqlConnection("Data Source=LAPTOP-GKK4AA8V;Initial Catalog=gkt;Integrated Security=True");
            da = new SqlDataAdapter("Select * From ogr", con);
            da.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            textBox1.DataBindings.Add("Text", bs, "kimlik");
            textBox2.DataBindings.Add("Text", bs, "ad");
            textBox3.DataBindings.Add("Text", bs, "soyad");
            textBox4.DataBindings.Add("Text", bs, "adres");
            textBox5.DataBindings.Add("Text", bs, "telefon");
            dataGridView1.ReadOnly = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            doldur();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("INSERT INTO ogr (Kimlik, ad, soyad, adres, telefon) VALUES (@Kimlik, @ad, @soyad, @adres, @telefon)", con);
            komut.Parameters.AddWithValue("@Kimlik", Int32.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@adres", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
        }
    
        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("DELETE FROM ogr WHERE Kimlik = @Kimlik", con);
            komut.Parameters.AddWithValue("@Kimlik", Int32.Parse(textBox1.Text));
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Silindi");
            doldur();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("UPDATE ogr SET ad = @ad, soyad = @soyad, adres = @adres, telefon = @telefon WHERE Kimlik = @Kimlik", con);
            komut.Parameters.AddWithValue("@Kimlik", Int32.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@adres", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşlem güncellendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.AddNew();
            textBox1.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            bs.AddNew();
            textBox1.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("INSERT INTO ogr (kimlik, ad, soyad, adres, telefon) VALUES (@Kimlik, @ad, @soyad, @adres, @telefon)", con);
            komut.Parameters.AddWithValue("@kimlik", (textBox1.Text));
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@adres", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("DELETE FROM ogr WHERE Kimlik = @Kimlik", con);
            komut.Parameters.AddWithValue("@kimlik", (textBox1.Text));
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Silindi");
            doldur();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("UPDATE ogr SET ad = @ad, soyad = @soyad, adres = @adres, telefon = @telefon WHERE Kimlik = @kimlik", con);
            komut.Parameters.AddWithValue("@kimlik", Int32.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@ad", textBox2.Text);
            komut.Parameters.AddWithValue("@soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@adres", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşlem güncellendi");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            doldur();
        }
    }
}

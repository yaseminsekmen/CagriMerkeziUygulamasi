using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CagriMerkeziUygulamasi
{
    public partial class Sube : Form
    {
        public Sube()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }
        CagriMerkeziDataContext baglanti = new CagriMerkeziDataContext();

        private void Sube_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Subelers.ToList();
            comboBox1.ValueMember = "subeNo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public void Temizle()
        {
            comboBox1.Text = "";
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        public void Listele()
        {
            var listele = baglanti.SuListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string ilce = textBox2.Text;
            string yet = textBox3.Text;



            var ekle = baglanti.SuEkle(ad, ilce, yet);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.SuSil(id);

            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["subeNo"].Value.ToString();
            textBox1.Text = satir.Cells["SubeAdi"].Value.ToString();
            textBox2.Text = satir.Cells["SubeIlce"].Value.ToString();
            textBox3.Text = satir.Cells["SubeYetkilisi"].Value.ToString();

            textBox1.Tag = satir.Cells["subeNo"].Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            string ad = textBox1.Text;
            string ilce = textBox2.Text;
            string yet = textBox3.Text;

            baglanti.SuYenile(id, ad, ilce, yet);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.SuAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }
    }
}

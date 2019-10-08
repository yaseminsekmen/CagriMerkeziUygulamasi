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
    public partial class Birim : Form
    {
        public Birim()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        CagriMerkeziDataContext baglanti = new CagriMerkeziDataContext();
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void Birim_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Birimlers.ToList();
            comboBox1.ValueMember = "birimNo";

            comboBox2.DataSource = baglanti.Subelers.ToList();
            comboBox2.ValueMember = "subeNo";
            comboBox2.DisplayMember = "SubeAdi";

            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public void Listele()
        {
            var listele = baglanti.BListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string ad = textBox1.Text;
            string mudur = textBox2.Text;
            int suno = Convert.ToInt32(comboBox2.SelectedValue);


            var ekle = baglanti.Bekle(ad, mudur,suno);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.BSil(id);

            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["birimNo"].Value.ToString();
            textBox1.Text = satir.Cells["BirimAdi"].Value.ToString();
            textBox2.Text = satir.Cells["BirimMuduru"].Value.ToString();

            comboBox2.Text = satir.Cells["subeNo"].Value.ToString();
           
            textBox1.Tag = satir.Cells["birimNo"].Value;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            string ad = textBox1.Text;
            string mudur = textBox2.Text;
            int suno = Convert.ToInt32(comboBox2.SelectedValue);

            baglanti.BYenile(id, ad, mudur, suno);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.BAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}

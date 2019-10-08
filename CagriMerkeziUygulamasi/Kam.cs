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
    public partial class Kam : Form
    {
        public Kam()
        {
            InitializeComponent();
        }
        CagriMerkeziDataContext baglanti = new CagriMerkeziDataContext();
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Kam_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Kampanyalars.ToList();
            comboBox1.ValueMember = "kampanyaNo";


            comboBox2.DataSource = baglanti.Tarifelers.ToList();
            comboBox2.ValueMember = "tarifeNo";
            comboBox2.DisplayMember = "TarifeAdi";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";

            textBox3.Text = "";

        }
        public void Listele()
        {
            var listele = baglanti.KListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["kampanyaNo"].Value.ToString();
            comboBox2.Text = satir.Cells["tarifeNo"].Value.ToString();
            textBox1.Text = satir.Cells["KAdi"].Value.ToString();
            textBox1.Tag = satir.Cells["kampanyaNo"].Value;
            comboBox3.Text = satir.Cells["KSuresi"].Value.ToString();
            textBox3.Text = satir.Cells["KUcreti"].Value.ToString();
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tarifeno = Convert.ToInt32(comboBox2.SelectedValue);
            string ad = textBox1.Text;
            string sure = comboBox3.SelectedItem.ToString();
            decimal ucret = Convert.ToDecimal(textBox3.Text);



            var ekle = baglanti.KEkle(tarifeno, ad, sure, ucret);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.KSil(id);

            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            int tarifeno = Convert.ToInt32(comboBox2.SelectedValue);
            string ad = textBox1.Text;
            string sure = comboBox3.SelectedItem.ToString();
            decimal ucret = Convert.ToDecimal(textBox3.Text);


            baglanti.KYenile(id, tarifeno, ad, sure, ucret);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.KAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}

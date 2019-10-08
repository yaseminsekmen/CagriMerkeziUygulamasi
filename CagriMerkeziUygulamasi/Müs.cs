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
    public partial class Müs : Form
    {
        public Müs()
        {
            InitializeComponent();
        }
        CagriMerkeziDataContext baglanti = new CagriMerkeziDataContext();
        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public void Listele()
        {
            var listele = baglanti.MListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void Müs_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Müsterilers.ToList();
            comboBox1.ValueMember = "musteriNo";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

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

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string tur = comboBox2.SelectedItem.ToString();
            string tel = maskedTextBox1.Text;
            string adres = textBox3.Text;
            int puan =Convert.ToInt32(textBox4.Text);
        

            var ekle = baglanti.MEkle(ad,tur,tel,adres,puan);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.MSil(id);
            //baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["musteriNo"].Value.ToString();
            textBox1.Text = satir.Cells["MAdSoyad"].Value.ToString();
            textBox1.Tag = satir.Cells["musteriNo"].Value;
            comboBox2.Text = satir.Cells["Turu"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["Telefon"].Value.ToString();
            textBox3.Text = satir.Cells["Adres"].Value.ToString();
            textBox4.Text = satir.Cells["Puan"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            string ad = textBox1.Text;
            string tur = comboBox2.SelectedItem.ToString();
            string tel = maskedTextBox1.Text;
            string adres = textBox3.Text;
            int puan = Convert.ToInt32(textBox4.Text);
            baglanti.MYenile(id, ad, tur, tel, adres, puan);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.MAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }
    }
}

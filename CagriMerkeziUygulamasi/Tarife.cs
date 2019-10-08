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
    public partial class Tarife : Form
    {
        public Tarife()
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

        private void Tarife_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Tarifelers.ToList();
            comboBox1.ValueMember = "tarifeNo";



            comboBox2.DataSource = baglanti.Müsterilers.ToList();
            comboBox2.ValueMember = "musteriNo";
            comboBox2.DisplayMember = "MAdSoyad";
            comboBox1.Text = "";
            comboBox2.Text = "";
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
            var listele = baglanti.TListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int musterino = Convert.ToInt32(comboBox2.SelectedValue);
            string ad = textBox1.Text;
            string tarifedurum = comboBox3.SelectedItem.ToString();
            decimal ucret = Convert.ToDecimal(textBox3.Text);
            string bas = dateTimePicker1.Value.ToString();
            string bit = dateTimePicker2.Value.ToString();


            var ekle = baglanti.TEkle(musterino, ad, tarifedurum, ucret, bas, bit);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.TSil(id);
            
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["tarifeNo"].Value.ToString();
            comboBox2.Text = satir.Cells["musteriNo"].Value.ToString();
            textBox1.Text = satir.Cells["TarifeAdi"].Value.ToString();
            textBox1.Tag = satir.Cells["tarifeNo"].Value;
            comboBox3.Text = satir.Cells["TarifeDurum"].Value.ToString();
            textBox3.Text = satir.Cells["Ucret"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["BaslangicTarihi"].Value.ToString();
            dateTimePicker2.Text = satir.Cells["BitisTarihi"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            int musterino = Convert.ToInt32(comboBox2.SelectedValue);
            string ad = textBox1.Text;
            string tarifedurum = comboBox3.SelectedItem.ToString();
            decimal ucret = Convert.ToDecimal(textBox3.Text);
            string bas = dateTimePicker1.Value.ToString();
            string bit = dateTimePicker2.Value.ToString();

            baglanti.TYenile(id, musterino, ad, tarifedurum, ucret, bas, bit);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.TAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }
    }
}

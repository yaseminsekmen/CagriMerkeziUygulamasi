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
    public partial class Ode : Form
    {
        public Ode()
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
        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox3.Text = "";

        }

        public void Listele()
        {
            var listele = baglanti.OdemeleriListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void Ode_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Ödemelers.ToList();
            comboBox1.ValueMember = "odemeNo";



            comboBox2.DataSource = baglanti.Müsterilers.ToList();
            comboBox2.ValueMember = "musteriNo";
            comboBox2.DisplayMember = "MAdSoyad";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int musterino = Convert.ToInt32(comboBox2.SelectedValue);
            string tipi = comboBox3.SelectedItem.ToString();
            string tarih = dateTimePicker1.Value.ToString();
          
            decimal tutar= Convert.ToDecimal(textBox1.Text);
            string gdurum = comboBox4.SelectedItem.ToString();
            int faiz = Convert.ToInt32(textBox3.Text);
           
         


            var ekle = baglanti.Oekle(musterino, tipi, tarih, tutar, gdurum, faiz);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.OSİl(id);

            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["odemeNo"].Value.ToString();
            comboBox2.Text = satir.Cells["musteriNo"].Value.ToString();
            comboBox3.Text = satir.Cells["Tipi"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["OdemeTarihi"].Value.ToString();
           textBox1.Text = satir.Cells["OdemeTutarı"].Value.ToString();
            comboBox4.Text = satir.Cells["OdemeGecikmeDurumu"].Value.ToString();
            textBox3.Text = satir.Cells["OdemeGecikmeFaizi"].Value.ToString();

            textBox1.Tag = satir.Cells["odemeNo"].Value;
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            int musterino = Convert.ToInt32(comboBox2.SelectedValue);
            string tipi = comboBox3.SelectedItem.ToString();
            string od = dateTimePicker1.Value.ToString();
            decimal ucret = Convert.ToDecimal(textBox1.Text);
            
            string gecikmedurum = comboBox4.SelectedItem.ToString();

            int faiz = Convert.ToInt32(textBox3.Text);

            baglanti.OdemeYenile(id, musterino, tipi, od,ucret, gecikmedurum, faiz);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.OAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["odemeNo"].Value.ToString();
            comboBox2.Text = satir.Cells["musteriNo"].Value.ToString();
            comboBox3.Text = satir.Cells["Tipi"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["OdemeTarihi"].Value.ToString();
            textBox1.Text = satir.Cells["OdemeTutarı"].Value.ToString();
            comboBox4.Text = satir.Cells["OdemeGecikmeDurumu"].Value.ToString();
            textBox3.Text = satir.Cells["OdemeGecikmeFaizi"].Value.ToString();

            textBox1.Tag = satir.Cells["odemeNo"].Value;
        }
    }
}

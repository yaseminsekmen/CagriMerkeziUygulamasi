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
    public partial class Gorev : Form
    {
        public Gorev()
        {
            InitializeComponent();
        }
        CagriMerkeziDataContext baglanti = new CagriMerkeziDataContext();
        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";

           

        }
        public void Listele()
        {
            var listele = baglanti.CGListele();
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
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

        private void button2_Click(object sender, EventArgs e)
        {
          
            string ad = textBox1.Text;
            string mezuniyet = comboBox2.SelectedItem.ToString();
            string vardiya = comboBox3.SelectedItem.ToString();

            string plan = "";
            if (checkBox1.Checked == true)
            {
                plan += "Pazartesi ,";
            }
            if (checkBox2.Checked == true)
            {
                plan += "Salı, ";
            }
            if (checkBox3.Checked == true)
            {
                plan += "Çarşamba, ";
            }
            if (checkBox4.Checked == true)
            {
                plan += "Perşembe, ";
            }
            if (checkBox5.Checked == true)
            {
                plan += "Cuma, ";
            }
            if (checkBox6.Checked == true)
            {
                plan += "Cumartesi, ";
            }
             if (checkBox7.Checked == true)
            {
                plan += "Pazar, ";
            }

            var ekle = baglanti.CGEkle(ad,mezuniyet,vardiya,plan);
            baglanti.SubmitChanges();
            Listele();
            Temizle();

        }

        private void Gorev_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.CGörevlisis.ToList();
            comboBox1.ValueMember = "cNo";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.CGSil(id);

            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["cNo"].Value.ToString();
            textBox1.Text = satir.Cells["CGAdSoyad"].Value.ToString();
            comboBox2.Text = satir.Cells["Mezuniyet"].Value.ToString();
            textBox1.Tag = satir.Cells["cNo"].Value;
            comboBox3.Text = satir.Cells["VardiyaDurumu"].Value.ToString();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            string ad = textBox1.Text;
            string mezuniyet = comboBox2.SelectedItem.ToString();
            string vardiya = comboBox3.SelectedItem.ToString();

            string plan = "";
            if (checkBox1.Checked == true)
            {
                plan += "Pazartesi ,";
            }
            if (checkBox2.Checked == true)
            {
                plan += "Salı, ";
            }
            if (checkBox3.Checked == true)
            {
                plan += "Çarşamba, ";
            }
            if (checkBox4.Checked == true)
            {
                plan += "Perşembe, ";
            }
            if (checkBox5.Checked == true)
            {
                plan += "Cuma, ";
            }
            if (checkBox6.Checked == true)
            {
                plan += "Cumartesi, ";
            }
            if (checkBox7.Checked == true)
            {
                plan += "Pazar, ";
            }

            baglanti.CGYenile(id, ad, mezuniyet, vardiya, plan);
            baglanti.SubmitChanges();
       
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.CGAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }
    }
}

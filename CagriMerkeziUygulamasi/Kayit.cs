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
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
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
        CagriMerkeziDataContext baglanti = new CagriMerkeziDataContext();
        private void Kayit_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.KayitTablosus.ToList();
            comboBox1.ValueMember = "kayitNo";



            comboBox2.DataSource = baglanti.Müsterilers.ToList();
            comboBox2.ValueMember = "musteriNo";
            comboBox2.DisplayMember = "MAdSoyad";

            comboBox3.DataSource = baglanti.CGörevlisis.ToList();
            comboBox3.ValueMember = "cNo";
            comboBox3.DisplayMember = "CGAdSoyad";

            comboBox4.DataSource = baglanti.Birimlers.ToList();
            comboBox4.ValueMember = "birimNo";
            comboBox4.DisplayMember = "BirimAdi";
            Temizle();


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
            var listele = baglanti.KTListele();
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
            int gno = Convert.ToInt32(comboBox3.SelectedValue);
            int sure = Convert.ToInt32(textBox1.Text);
            string tarih = dateTimePicker1.Value.ToString();
            string saat = textBox2.Text;
            string aciklama = textBox3.Text;
            int bno = Convert.ToInt32(comboBox4.SelectedValue);




            var ekle = baglanti.KTEkle(musterino, gno,sure,tarih,saat,aciklama,bno);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["kayitNo"].Value.ToString();
            comboBox2.Text = satir.Cells["musteriNo"].Value.ToString();
            comboBox3.Text = satir.Cells["cNo"].Value.ToString();
            textBox1.Text = satir.Cells["KayitSuresi"].Value.ToString();
            textBox1.Tag = satir.Cells["kayitNo"].Value;
            dateTimePicker1.Text = satir.Cells["KayitTarihi"].Value.ToString();

            textBox2.Text = satir.Cells["KayitSaati"].Value.ToString();
            textBox3.Text = satir.Cells["Aciklama"].Value.ToString();
            comboBox4.Text = satir.Cells["birimNo"].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            baglanti.KTSil(id);

            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)textBox1.Tag;
            int musterino = Convert.ToInt32(comboBox2.SelectedValue);
            int gno = Convert.ToInt32(comboBox3.SelectedValue);
            int sure = Convert.ToInt32(textBox1.Text);
            string tarih = dateTimePicker1.Value.ToString();
            string saat = textBox2.Text;
            string aciklama = textBox3.Text;
            int bno = Convert.ToInt32(comboBox4.SelectedValue);

            baglanti.KTYenile(id, musterino, gno, sure, tarih, saat, aciklama, bno);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var listele = baglanti.KTAra(id);
            baglanti.SubmitChanges();
            dataGridView1.DataSource = listele.ToList();
        }
    }
}

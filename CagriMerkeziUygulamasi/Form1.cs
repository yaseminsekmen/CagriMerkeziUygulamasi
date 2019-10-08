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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            Müs git = new Müs();
            git.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Tarife git = new Tarife();
            git.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Kam git = new Kam();
            git.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Gorev git = new Gorev();
            git.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Ode git = new Ode();
            git.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Kayit git = new Kayit();
            git.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Birim git = new Birim();
            git.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Sube git = new Sube();
            git.Show();
            this.Hide();
        }
    }
}

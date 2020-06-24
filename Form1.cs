using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18010011013
{
    public partial class GirisTuru : Form
    {
        public GirisTuru()
        {
            InitializeComponent();
        }

        private void GirisTuru_Load(object sender, EventArgs e)
        {
            this.Text = "Sisteme Giriş";
            timer1.Interval = 4000;
            timer1.Enabled = true;
            this.BackColor = Color.FromArgb(200, 25, 18);
            pictureBox2.Visible = false;
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = false;
            kullaniciGiris.Visible = saticiGiris.Visible = YoneticiGiris.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            pictureBox1.Image = null;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = true;
            kullaniciGiris.Visible = saticiGiris.Visible = YoneticiGiris.Visible = true;
        }

        private void kullaniciGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisSayfasi frm2 = new GirisSayfasi();
            frm2.label5.Text = "1";
            frm2.Show();
        }

        private void saticiGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisSayfasi frm2 = new GirisSayfasi();
            frm2.label5.Text = "2";
            frm2.Show();
        }

        private void YoneticiGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisSayfasi frm2 = new GirisSayfasi();
            frm2.label5.Text = "3";
            frm2.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _18010011013
{
    public partial class YoneticiAnasayfa : Form
    {
        public YoneticiAnasayfa()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");

        private Form aktifForm = null;
        private void SayfalarForm(Form Sayfalar)
        {
            if (aktifForm != null)
                aktifForm.Close();
            aktifForm = Sayfalar;
            Sayfalar.TopLevel = false;
            Sayfalar.FormBorderStyle = FormBorderStyle.None;
            Sayfalar.Dock = DockStyle.Fill;
            panelSayfalar3.Controls.Add(Sayfalar);
            panelSayfalar3.Tag = Sayfalar;
            Sayfalar.BringToFront();
            Sayfalar.Show();
        }

        private void YoneticiAnasayfa_Load(object sender, EventArgs e)
        {
            this.Text = "Yönetici Anasayfa";
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Logo1.png");
            timer1.Enabled = true;
        }

        private void profilimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar.durum = 0;
            SayfalarForm(new Ayarlar());
        }

        private void renkAyarlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar.durum = 1;
            SayfalarForm(new Ayarlar());
        }

        private void logoAyarlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar.durum = 2;
            SayfalarForm(new Ayarlar());
        }

        private void kullaniciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar.durum = 3;
            SayfalarForm(new Ayarlar());
        }

        private void kullaniciSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar.durum = 4;
            SayfalarForm(new Ayarlar());
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisTuru frm1 = new GirisTuru();
            frm1.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            statusBar1.Panels[0].Text = "" + zaman;
        }
    }
}

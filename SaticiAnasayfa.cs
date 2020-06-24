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
    public partial class SaticiAnasayfa : Form
    {
        public SaticiAnasayfa()
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
            panelSayfalar2.Controls.Add(Sayfalar);
            panelSayfalar2.Tag = Sayfalar;
            Sayfalar.BringToFront();
            Sayfalar.Show();
        }

        private void profilimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaticiKayitIslemleri.durum = true;
            SayfalarForm(new SaticiKayitIslemleri());
        }

        private void SaticiAnasayfa_Load(object sender, EventArgs e)
        {
            this.Text = "Satıcı Anasayfa";
            label1.Parent = panelSayfalar2;
            label1.BackColor = Color.Transparent;
            guncelZaman.Enabled = true;
            label1.Text = GirisSayfasi.saticikullaniciad;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Logo1.png");

            siparisim.Open();
            OleDbCommand search = new OleDbCommand("select * from saticilar where saticikullaniciad='" + GirisSayfasi.saticikullaniciad + "'", siparisim);
            OleDbDataReader kayitOkuma = search.ExecuteReader();
            while (kayitOkuma.Read())
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = kayitOkuma.GetValue(7).ToString();
                break;
            }
            siparisim.Close();
        }

        private void urunlerimiDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunBilgileri.durum = 0;
            SayfalarForm(new UrunBilgileri());
        }

        private void stoklaraGitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunBilgileri.durum = 1;
            SayfalarForm(new UrunBilgileri());
        }

        private void kazanclarimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunBilgileri.durum = 2;
            SayfalarForm(new UrunBilgileri());
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisTuru frm1 = new GirisTuru();
            frm1.Show();
        }

        private void siparisKutusuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparisGecmisi.durum = false;
            SayfalarForm(new SiparisGecmisi());
        }

        public void guncelZaman_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            statusBar1.Panels[0].Text = "" + zaman;
        }
    }
}

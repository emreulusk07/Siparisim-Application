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
    public partial class KullaniciAnasayfa : Form
    {
        public KullaniciAnasayfa()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        KayitIslemleri frm3 = new KayitIslemleri();

        private Form aktifForm = null;
        private void SayfalarForm(Form Sayfalar)
        {
            if (aktifForm != null)
                aktifForm.Close();
            aktifForm = Sayfalar;
            Sayfalar.TopLevel = false;
            Sayfalar.FormBorderStyle = FormBorderStyle.None;
            Sayfalar.Dock = DockStyle.Fill;
            panelSayfalar.Controls.Add(Sayfalar);
            panelSayfalar.Tag = Sayfalar;
            Sayfalar.BringToFront();
            Sayfalar.Show();
        }

        private void profilimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KayitIslemleri.durum = true;
            SayfalarForm(new KayitIslemleri());
        }

        private void KullaniciAnasayfa_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Anasayfa";
            label1.Parent = panelSayfalar;
            label1.BackColor = Color.Transparent;
            label1.Text = GirisSayfasi.kullaniciad;
            timer1.Interval = 3500;
            timer1.Enabled = true;
            timer2.Enabled = true;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = ımageList1.Images[0];
            yemekButon.ImageIndex = 3;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Logo1.png");

            siparisim.Open();
            OleDbCommand search = new OleDbCommand("select * from kullanicilar where kullaniciad='" + GirisSayfasi.kullaniciad + "'", siparisim);
            OleDbDataReader kayitOkuma = search.ExecuteReader();
            while (kayitOkuma.Read())
            {
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = kayitOkuma.GetValue(6).ToString();
                break;
            }
            siparisim.Close();
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            int adet = ımageList1.Images.Count;
            if (i == adet - 1)
                i = 0;

            pictureBox2.Image = ımageList1.Images[i];
        }

        private void yemekButon_Click(object sender, EventArgs e)
        {
            Urunler.durum = false;
            SayfalarForm(new Urunler());
        }

        private void sepetlerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Urunler.durum = true;
            SayfalarForm(new Urunler());
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisTuru frm1 = new GirisTuru();
            frm1.Show();
        }

        private void siparisGecmisimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparisGecmisi.durum = true;
            SayfalarForm(new SiparisGecmisi());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            statusBar1.Panels[0].Text = "" + zaman;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Veri tabanında islem yapacagımız icin ekliyoruz..

namespace _18010011013
{
    public partial class GirisSayfasi : Form
    {
        public GirisSayfasi()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");

        int ctrl = 0;
        public static int kullaniciId, saticiId, sayikontrol = 0;
        public static string adSoyad, kullaniciad, sifre, yetki, il, yoneticiad, yoneticisifre;
        public static string saticiAdSoyad, saticikullaniciad, saticisifre, saticiyetki, saticidogumtarihi, sirketadi;
        int i = 0;

        private void GirisSayfasi_Load(object sender, EventArgs e)
        {
            kaydolButon.Visible = true;
            if (i == 0)
            {
                i++;
                if (label5.Text == "1")
                    sayikontrol = 1;
                else if (label5.Text == "2")
                    sayikontrol = 2;
                else if (label5.Text == "3")
                {
                    sayikontrol = 3;

                    kaydolButon.Visible = false;
                }
            }
            if (sayikontrol == 1)
                this.Text = "Kullanıcı İşlemleri";
            else if (sayikontrol == 2)
                this.Text = "Satıcı İşlemleri";
            else if (sayikontrol == 3)
                this.Text = "Yönetici İşlemleri";

            if (ctrl == 0)
            {
                textBox2.PasswordChar = char.Parse("*");
                sifreGoster.Image = Image.FromFile(Application.StartupPath + "\\eye.png");
            }
            this.AcceptButton = girisyapButon;
            label4.Visible = label5.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Logo2.png");
        }

        private void geriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisTuru frm1 = new GirisTuru();
            frm1.Show();
        }

        private void sifreGoster_Click(object sender, EventArgs e)
        {
            if (ctrl == 1)
            {
                ctrl = 0;
                textBox2.PasswordChar = char.Parse("*");
                sifreGoster.Image = Image.FromFile(Application.StartupPath + "\\eye.png");
            }
            else if (ctrl == 0)
            {
                ctrl = 1;
                textBox2.PasswordChar = char.Parse("\0");
                sifreGoster.Image = Image.FromFile(Application.StartupPath + "\\hide.png");
            }
        }

        bool durum = false;
        private void girisyapButon_Click(object sender, EventArgs e)
        {
            if (sayikontrol == 1)
            {
                siparisim.Open();
                OleDbCommand select = new OleDbCommand("select * from kullanicilar", siparisim);
                OleDbDataReader kayitOku = select.ExecuteReader();
                while (kayitOku.Read())
                {
                    if (kayitOku["kullaniciad"].ToString() == textBox1.Text && kayitOku["sifre"].ToString() == textBox2.Text)
                    {
                        durum = true;
                        label3.ForeColor = Color.White;
                        kullaniciId = int.Parse(kayitOku.GetValue(0).ToString());
                        adSoyad = kayitOku.GetValue(1).ToString();
                        kullaniciad = kayitOku.GetValue(2).ToString();
                        sifre = kayitOku.GetValue(3).ToString();
                        yetki = kayitOku.GetValue(4).ToString();
                        il = kayitOku.GetValue(5).ToString();
                        this.Hide();
                        KullaniciAnasayfa frm4 = new KullaniciAnasayfa();
                        frm4.Show();
                        break;
                    }
                    else
                        label3.ForeColor = Color.Red;
                }
                siparisim.Close();
            }
            else if (sayikontrol == 2)
            {
                siparisim.Open();
                OleDbCommand select = new OleDbCommand("select * from saticilar", siparisim);
                OleDbDataReader kayitOku = select.ExecuteReader();
                while (kayitOku.Read())
                {
                    if (kayitOku["saticikullaniciad"].ToString() == textBox1.Text && kayitOku["saticisifre"].ToString() == textBox2.Text)
                    {
                        durum = true;
                        label3.ForeColor = Color.White;
                        saticiId = int.Parse(kayitOku.GetValue(0).ToString());
                        saticiAdSoyad = kayitOku.GetValue(1).ToString();
                        saticikullaniciad = kayitOku.GetValue(2).ToString();
                        saticisifre = kayitOku.GetValue(3).ToString();
                        saticiyetki = kayitOku.GetValue(4).ToString();
                        saticidogumtarihi = kayitOku.GetValue(5).ToString();
                        sirketadi = kayitOku.GetValue(6).ToString();
                        this.Hide();
                        SaticiAnasayfa frm6 = new SaticiAnasayfa();
                        frm6.Show();
                        break;
                    }
                    else
                        label3.ForeColor = Color.Red;
                }
                siparisim.Close();
            }
            else if (sayikontrol == 3)
            {
                siparisim.Open();
                OleDbCommand select = new OleDbCommand("select * from yöneticiler", siparisim);
                OleDbDataReader kayitOku = select.ExecuteReader();
                while (kayitOku.Read())
                {
                    if (kayitOku["yoneticiad"].ToString() == textBox1.Text && kayitOku["yoneticisifre"].ToString() == textBox2.Text)
                    {
                        label3.ForeColor = Color.White;
                        yoneticiad = kayitOku.GetValue(0).ToString();
                        yoneticisifre = kayitOku.GetValue(1).ToString();
                        this.Hide();
                        YoneticiAnasayfa frm11 = new YoneticiAnasayfa();
                        frm11.Show();
                        break;
                    }
                    else
                        label3.ForeColor = Color.Red;
                }
                siparisim.Close();
            }
        }

        private void kaydolButon_Click(object sender, EventArgs e)
        {
            if (sayikontrol == 1)
            {
                this.Hide();
                KayitIslemleri frm3 = new KayitIslemleri();
                KayitIslemleri.durum = false;
                frm3.Show();
            }
            else if (sayikontrol == 2)
            {
                this.Hide();
                SaticiKayitIslemleri frm5 = new SaticiKayitIslemleri();
                SaticiKayitIslemleri.durum = false;
                frm5.Show();
            }
            else if (sayikontrol == 3)
            {
                this.Hide();
                YoneticiAnasayfa frm11 = new YoneticiAnasayfa();
                frm11.Show();
            }
        }
    }
}

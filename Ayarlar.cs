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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        public string resimyolu;
        public static int durum;

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            if (durum == 0)
            {
                panelLogoAyarlari.Visible = panelLogoAyarlari.Enabled = false;
                panelKullaniciSil.Visible = panelKullaniciSil.Enabled = false;
                panelKullaniciEkle.Visible = panelKullaniciEkle.Enabled = false;
                panelRenkAyalari.Visible = panelRenkAyalari.Enabled = false;
                panelHesapBilgileri.Visible = panelHesapBilgileri.Enabled = true;
                this.AcceptButton = guncelleButon;
            }
            else if(durum == 1)
            {
                panelLogoAyarlari.Visible = panelLogoAyarlari.Enabled = false;
                panelKullaniciSil.Visible = panelKullaniciSil.Enabled = false;
                panelKullaniciEkle.Visible = panelKullaniciEkle.Enabled = false;
                panelHesapBilgileri.Visible = panelHesapBilgileri.Enabled = false;
                panelRenkAyalari.Visible = panelRenkAyalari.Enabled = true;
                numericUpDown1.Minimum = numericUpDown2.Minimum = numericUpDown3.Minimum = 0;
                numericUpDown1.Maximum = numericUpDown2.Maximum = numericUpDown3.Maximum = 255;
                numericUpDown1.Increment = numericUpDown2.Increment = numericUpDown3.Increment = 1;
                numericUpDown1.Visible = numericUpDown2.Visible = numericUpDown3.Visible = false;
                renkAyarlariKaydetButon.Visible = label4.Visible = label5.Visible = label6.Visible = textBox3.Visible = textBox3.Enabled = false;
                comboBox1.Items.Add("Butonların rengi");
                comboBox1.Items.Add("Açılış sayfası rengi");
                comboBox1.Items.Add("Giriş sayfası rengi");
                comboBox1.Items.Add("Listview ve Datagridview rengi");
            }
            else if(durum == 2)
            {
                panelHesapBilgileri.Visible = panelHesapBilgileri.Enabled = false;
                panelKullaniciSil.Visible = panelKullaniciSil.Enabled = false;
                panelKullaniciEkle.Visible = panelKullaniciEkle.Enabled = false;
                panelRenkAyalari.Visible = panelRenkAyalari.Enabled = false;
                panelLogoAyarlari.Visible = panelLogoAyarlari.Enabled = true;
                logosecButon.Visible = logoAyarlariKaydetButon.Visible = pictureBox2.Visible = false;
                comboBox2.Items.Add("Açılış sayfası logosu");
                comboBox2.Items.Add("Giriş sayfası logosu");
                comboBox2.Items.Add("Anasayfa logosu");
                comboBox2.Items.Add("Anasayfaya dön logosu");
            }
            else if(durum == 3)
            {
                panelKullaniciEkle.Visible = panelKullaniciEkle.Enabled = true;
                panelKullaniciSil.Visible = panelKullaniciSil.Enabled = false;
                panelHesapBilgileri.Visible = panelHesapBilgileri.Enabled = false;
                panelRenkAyalari.Visible = panelRenkAyalari.Enabled = false;
                panelLogoAyarlari.Visible = panelLogoAyarlari.Enabled = false;
                kullaniciBilgilerGroupBox.Visible = true;
                saticiBilgilerGroupBox.Visible = false;
                try
                {
                    siparisim.Open();
                    OleDbCommand iller = new OleDbCommand("select * from iller", siparisim);
                    OleDbDataReader ilEkle = iller.ExecuteReader();
                    while (ilEkle.Read())
                    {
                        comboBox3.Items.Add(ilEkle["sehirler"]);
                    }
                    siparisim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);
                    siparisim.Close();
                }
            }
            else if(durum == 4)
            {
                panelKullaniciSil.Visible = panelKullaniciSil.Enabled = true;
                panelKullaniciEkle.Visible = panelKullaniciEkle.Enabled = false;
                panelHesapBilgileri.Visible = panelHesapBilgileri.Enabled = false;
                panelRenkAyalari.Visible = panelRenkAyalari.Enabled = false;
                panelLogoAyarlari.Visible = panelLogoAyarlari.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label22.Text = "Kullanıcı ID";
            }
            else
            {
                label22.Text = "Satıcı ID";
            }
        }

        private void uyeSilButon_Click(object sender, EventArgs e)
        {
            if (textBox15.Text != "")
            {
                if(radioButton1.Checked == true)
                {
                    bool kayitAra = false;
                    siparisim.Open();
                    OleDbCommand search = new OleDbCommand("select * from kullanicilar where id=" + int.Parse(textBox15.Text) + "", siparisim);
                    OleDbDataReader kayitOkuma = search.ExecuteReader();
                    while (kayitOkuma.Read())
                    {
                        kayitAra = true;
                        OleDbCommand delete = new OleDbCommand("delete from kullanicilar where id=" + int.Parse(textBox15.Text) + "", siparisim);
                        delete.ExecuteNonQuery();
                        MessageBox.Show("Kullanıcı silme işlemi gerçekleşti.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        siparisim.Close();
                        this.Close();
                        break;
                    }
                    if (kayitAra == false)
                        MessageBox.Show("Silinecek kullanıcı kaydı bulunamadı !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }
                else
                {
                    bool kayitAra = false;
                    siparisim.Open();
                    OleDbCommand search = new OleDbCommand("select * from saticilar where id=" + int.Parse(textBox15.Text) + "", siparisim);
                    OleDbDataReader kayitOkuma = search.ExecuteReader();
                    while (kayitOkuma.Read())
                    {
                        kayitAra = true;
                        OleDbCommand delete = new OleDbCommand("delete from saticilar where id=" + int.Parse(textBox15.Text) + "", siparisim);
                        delete.ExecuteNonQuery();
                        MessageBox.Show("Satıcı silme işlemi gerçekleşti.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        siparisim.Close();
                        this.Close();
                        break;
                    }
                    if (kayitAra == false)
                        MessageBox.Show("Silinecek satıcı kaydı bulunamadı !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }
            }
            else
                MessageBox.Show("ID kısmının doldurulması zorunludur !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void kullaniciRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(kullaniciRadioButton.Checked == true)
            {
                saticiBilgilerGroupBox.Visible = false;
                kullaniciBilgilerGroupBox.Visible = true;
            }
            else
            {
                kullaniciBilgilerGroupBox.Visible = false;
                saticiBilgilerGroupBox.Visible = true;
            }
        }

        private void uyekaydetButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            siparisim.Open();
            OleDbCommand select = new OleDbCommand("select * from kullanicilar where kullaniciad='" + textBox6.Text + "'", siparisim);
            OleDbDataReader kayitOku = select.ExecuteReader();
            while (kayitOku.Read())
            {
                kayitKontrol = true;
                break;
            }
            siparisim.Close();

            if (kayitKontrol == false)
            {
                if (textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "" && textBox4.Text != ""
                    && comboBox3.Text != "" && textBox5.Text == textBox4.Text && textBox6.Text.Length > 4 && textBox4.Text.Length > 6)
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand insert = new OleDbCommand("insert into kullanicilar(adSoyad,kullaniciad,sifre,yetki,il,resim) values ('" + textBox7.Text + "','" + textBox6.Text +
                            "','" + textBox4.Text + "','" + "Kullanıcı" + "','" + comboBox3.Text + "','" + resimyolu + "')", siparisim);
                        insert.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Kaydetme işlemi tamamlandı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        siparisim.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı alanları tekrar gözden geçiriniz.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılmaktadır.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saticiKaydetButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            siparisim.Open();
            OleDbCommand select = new OleDbCommand("select * from saticilar where saticikullaniciad='" + textBox11.Text + "'", siparisim);
            OleDbDataReader kayitOku = select.ExecuteReader();
            while (kayitOku.Read())
            {
                kayitKontrol = true;
                break;
            }
            siparisim.Close();

            if(kayitKontrol == false)
            {
                if (textBox12.Text != "" && textBox11.Text != "" && textBox10.Text != "" && textBox9.Text != ""
                    && dateTimePicker1.Text != "" && textBox9.Text == textBox10.Text && textBox11.Text.Length > 4 && textBox10.Text.Length > 6)
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand insert = new OleDbCommand("insert into saticilar(saticiadsoyad,saticikullaniciad,saticisifre,saticiyetki,dogumtarihi,sirketad,saticiresim) values ('" + textBox12.Text + "','" + textBox11.Text +
                            "','" + textBox10.Text + "','" + "Satıcı" + "','" + dateTimePicker1.Text + "','" + textBox8.Text + "','" + resimyolu + "')", siparisim);
                        insert.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Kaydetme işlemi tamamlandı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        siparisim.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı alanları tekrar gözden geçiriniz.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılmaktadır.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Açılış sayfası logosu" || comboBox2.SelectedItem == "Giriş sayfası logosu" ||
                    comboBox2.SelectedItem == "Anasayfa logosu" || comboBox2.SelectedItem == "Anasayfaya dön logosu")
            {
                logosecButon.Visible = logoAyarlariKaydetButon.Visible = pictureBox2.Visible = true;
            }
        }

        private void logoAyarlariKaydetButon_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Açılış sayfası logosu")
            {
                renkAyarlariKaydetButon.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                    int.Parse(numericUpDown3.Value.ToString()));
            }
            else if (comboBox2.SelectedItem == "Giriş sayfası logosu")
            {
                GirisTuru frm1 = new GirisTuru();
                frm1.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                    int.Parse(numericUpDown3.Value.ToString()));
            }
            else if (comboBox2.SelectedItem == "Anasayfa logosu")
            {
                GirisSayfasi frm1 = new GirisSayfasi();
                KayitIslemleri frm3 = new KayitIslemleri();
                SaticiKayitIslemleri frm5 = new SaticiKayitIslemleri();
                frm1.BackColor = frm3.BackColor = frm5.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()),
                    int.Parse(numericUpDown2.Value.ToString()), int.Parse(numericUpDown3.Value.ToString()));
            }
            else if (comboBox2.SelectedItem == "Anasayfaya dön logosu")
            {
                //GirisTuru frm1 = new GirisTuru();
                //frm1.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                //    int.Parse(numericUpDown3.Value.ToString()));
            }
            MessageBox.Show("Ayarlar kaydedildi.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Butonların rengi" || comboBox1.SelectedItem == "Açılış sayfası rengi" ||
                    comboBox1.SelectedItem == "Giriş sayfası rengi" || comboBox1.SelectedItem == "Listview ve Datagridview rengi")
            {
                numericUpDown1.Visible = numericUpDown2.Visible = numericUpDown3.Visible = true;
                renkAyarlariKaydetButon.Visible = label4.Visible = label5.Visible = label6.Visible = textBox3.Visible = true;
            }
        }

        private void renkAyarlariKaydetButon_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Butonların rengi")
            {
                renkAyarlariKaydetButon.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                    int.Parse(numericUpDown3.Value.ToString()));
            }
            else if (comboBox1.SelectedItem == "Açılış sayfası rengi")
            {
                GirisTuru frm1 = new GirisTuru();
                frm1.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                    int.Parse(numericUpDown3.Value.ToString()));
            }
            else if (comboBox1.SelectedItem == "Giriş sayfası rengi")
            {
                GirisSayfasi frm1 = new GirisSayfasi();
                KayitIslemleri frm3 = new KayitIslemleri();
                SaticiKayitIslemleri frm5 = new SaticiKayitIslemleri();
                frm1.BackColor = frm3.BackColor = frm5.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()),
                    int.Parse(numericUpDown2.Value.ToString()), int.Parse(numericUpDown3.Value.ToString()));
            }
            else if (comboBox1.SelectedItem == "Listview ve Datagridview rengi")
            {
                //GirisTuru frm1 = new GirisTuru();
                //frm1.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                //    int.Parse(numericUpDown3.Value.ToString()));
            }
            MessageBox.Show("Ayarlar kaydedildi.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                int.Parse(numericUpDown3.Value.ToString()));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                int.Parse(numericUpDown3.Value.ToString()));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.FromArgb(int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()),
                int.Parse(numericUpDown3.Value.ToString()));
        }

        private void guncelleButon_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if(textBox1.Text == GirisSayfasi.yoneticiad && textBox2.Text == GirisSayfasi.yoneticisifre)
                {
                    MessageBox.Show("Girdiğiniz kullanıcı adı ve şifre zaten mevcut.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand update = new OleDbCommand("update yöneticiler set yoneticiad='" +
                            textBox1.Text + "',yoneticisifre='" + textBox2.Text + "'", siparisim);
                        update.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Güncelleme islemi başarıyla tamamlandı.", "Siparişim",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        siparisim.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Hatalı alanları tekrar gözden geçiriniz.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logosecButon_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog resimSec = new OpenFileDialog();
                resimSec.Title = "Resimler";
                resimSec.Filter = "Dosyalar |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                if (resimSec.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictureBox2.Image = Image.FromFile(resimSec.FileName);
                    resimyolu = resimSec.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    bool kayitKontrol = false;
                    siparisim.Open();
                    OleDbCommand select = new OleDbCommand("select * from kullanicilar where id=" + int.Parse(textBox15.Text) + "", siparisim);
                    OleDbDataReader kayitOku = select.ExecuteReader();
                    while (kayitOku.Read())
                    {
                        kayitKontrol = true;
                        break;
                    }

                    if (kayitKontrol == true)
                    {
                        textBox14.Text = kayitOku.GetValue(1).ToString();
                        textBox13.Text = kayitOku.GetValue(2).ToString();
                    }
                    siparisim.Close();
                }
                catch (Exception)
                {
                    textBox14.Text = "";
                    textBox13.Text = "";
                    siparisim.Close();
                }
            }
            else if(radioButton2.Checked == true)
            {
                try
                {
                    bool kayitKontrol = false;
                    siparisim.Open();
                    OleDbCommand select = new OleDbCommand("select * from saticilar where id=" + int.Parse(textBox15.Text) + "", siparisim);
                    OleDbDataReader kayitOku = select.ExecuteReader();
                    while (kayitOku.Read())
                    {
                        kayitKontrol = true;
                        break;
                    }
                    
                    if (kayitKontrol == true)
                    {
                        textBox14.Text = kayitOku.GetValue(1).ToString();
                        textBox13.Text = kayitOku.GetValue(2).ToString();
                    }
                    siparisim.Close();
                }
                catch (Exception)
                {
                    textBox14.Text = "";
                    textBox13.Text = "";
                    siparisim.Close();
                }
            }
        }

        private void resimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog resimSec = new OpenFileDialog();
                resimSec.Title = "Resimler";
                resimSec.Filter = "JPG Dosyalar (*.jpg) | *.jpg";
                if (resimSec.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictureBox2.Image = Image.FromFile(resimSec.FileName);
                    resimyolu = resimSec.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void anasayfaDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 5)
                errorProvider1.SetError(textBox2, "Kullanıcı adı en az 5 karakterden oluşmalıdır.");
            else
                errorProvider1.Clear();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length <= 7)
                errorProvider1.SetError(textBox3, "Şifre en az 7 karakterden oluşmalıdır.");
            else
                errorProvider1.Clear();

            if (textBox3.Text != textBox4.Text)
            {
                label4.ForeColor = Color.Red;
            }
            else
                label4.ForeColor = Color.Black;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                label4.ForeColor = Color.Red;
            }
            else
                label4.ForeColor = Color.Black;
        }
    }
}

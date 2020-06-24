using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace _18010011013
{
    public partial class SaticiKayitIslemleri : Form
    {
        public SaticiKayitIslemleri()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        public string resimyolu2;
        public static bool durum;

        private void SaticiKayitIslemleri_Load(object sender, EventArgs e)
        {
            this.Text = "Satıcı Kayıt İşlemleri";
            if(durum == false)
            {
                anasayfaDon.Visible = false;
                geriDon.Visible = label7.Visible = true;
                uyeolButon.Enabled = uyeolButon.Visible = pictureBox1.Visible = true;
                degisikliklerikaydetButon.Visible = degisikliklerikaydetButon.Enabled = false;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                pictureBox2.ImageLocation = null;
            }
            else if(durum == true)
            {
                anasayfaDon.Visible = true;
                geriDon.Visible = label7.Visible = false;
                uyeolButon.Enabled = uyeolButon.Visible = pictureBox1.Visible = false;
                degisikliklerikaydetButon.Visible = degisikliklerikaydetButon.Enabled = true;

                siparisim.Open();
                OleDbCommand search = new OleDbCommand("select * from saticilar where saticikullaniciad='" + GirisSayfasi.saticikullaniciad + "'", siparisim);
                OleDbDataReader kayitOkuma = search.ExecuteReader();
                while (kayitOkuma.Read())
                {
                    textBox1.Text = kayitOkuma.GetValue(1).ToString();
                    textBox2.Text = kayitOkuma.GetValue(2).ToString();
                    textBox3.Text = kayitOkuma.GetValue(3).ToString();
                    textBox4.Text = kayitOkuma.GetValue(3).ToString();
                    dateTimePicker1.Text = kayitOkuma.GetValue(5).ToString();
                    textBox5.Text = kayitOkuma.GetValue(6).ToString();
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.ImageLocation = kayitOkuma.GetValue(7).ToString();
                    break;
                }
                siparisim.Close();
            }

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(yil - 100, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 25, ay, gun);
            toolTip1.SetToolTip(anasayfaDon, "Anasayfa");
            toolTip1.SetToolTip(geriDon, "Giriş Sayfası");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Logo2.png");
        }

        private void uyeolButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            siparisim.Open();
            OleDbCommand select = new OleDbCommand("select * from saticilar where saticikullaniciad='" + textBox2.Text + "'", siparisim);
            OleDbDataReader kayitOku = select.ExecuteReader();
            while (kayitOku.Read())
            {
                kayitKontrol = true;
                break;
            }
            siparisim.Close();

            if (kayitKontrol == false)
            {
                if (textBox1.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (textBox2.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (textBox3.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (textBox4.Text == "" || textBox3.Text != textBox4.Text)
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (textBox5.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;


                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                    && textBox3.Text == textBox4.Text && textBox5.Text != "" && textBox2.Text.Length > 4 && textBox3.Text.Length > 6)
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand insert = new OleDbCommand("insert into saticilar(saticiadsoyad,saticikullaniciad,saticisifre,saticiyetki,dogumtarihi,sirketad,saticiresim) values ('" + textBox1.Text + "','" + textBox2.Text +
                            "','" + textBox3.Text + "','" + "Satıcı" + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + resimyolu2 + "')", siparisim);
                        insert.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Satıcı kaydı tamamlandı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Hide();
                        GirisSayfasi frm2 = new GirisSayfasi();
                        frm2.Show();
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

        private void resimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog resimSec = new OpenFileDialog();
                resimSec.Title = "Resimler";
                resimSec.Filter = "JPG Dosyalar (*.jpg) | *.jpg";
                if (resimSec.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox2.Image = Image.FromFile(resimSec.FileName);
                    resimyolu2 = resimSec.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void degisikliklerikaydetButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            siparisim.Open();
            OleDbCommand select = new OleDbCommand("select * from saticilar where saticikullaniciad='" + textBox2.Text + "'", siparisim);
            OleDbDataReader kayitOku = select.ExecuteReader();
            while (kayitOku.Read() && kayitOku.GetValue(2).ToString() != textBox2.Text)
            {
                kayitKontrol = true;
                break;
            }
            siparisim.Close();

            if (kayitKontrol == false)
            {
                if (textBox1.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (textBox2.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (textBox3.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (textBox4.Text == "" || textBox3.Text != textBox4.Text)
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (textBox5.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;


                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                    && textBox3.Text == textBox4.Text && textBox5.Text != "" && textBox2.Text.Length > 4 && textBox3.Text.Length > 6)
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand update = new OleDbCommand("update saticilar set saticiadsoyad='" +
                            textBox1.Text + "',saticisifre='" + textBox3.Text + "',dogumtarihi='" + dateTimePicker1.Text + "',sirketad='" + textBox5.Text + "',saticiresim='" +
                            resimyolu2 + "' where saticikullaniciad='" + textBox2.Text + "'", siparisim);
                        update.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Değişiklikler kaydedildi.", "Siparişim",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Bu satıcı kullanıcı adı zaten kullanılmaktadır.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 5)
                errorProvider1.SetError(textBox2, "Kullanıcı adı en az 5 karakterden oluşmalıdır.");
            else
                errorProvider1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                label4.ForeColor = Color.Red;
            }
            else
                label4.ForeColor = Color.Black;
        }

        private void geriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisSayfasi frm2 = new GirisSayfasi();
            frm2.Show();
        }

        private void anasayfaDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

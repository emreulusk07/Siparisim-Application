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
    public partial class SiparisVer : Form
    {
        public SiparisVer()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        Urunler frm7 = new Urunler();
        public static bool durum;

        private void SiparisVer_Load(object sender, EventArgs e)
        {
            this.Text = "Ürün Bilgileri";
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 1;
            timer1.Start();
            odemeIslemleriGroupBox.Visible = true;
            geriDon.Enabled = geriDon.Visible = odemeyapButon.Enabled = odemeyapButon.Visible = label3.Visible = label4.Visible = false;
            talimatBilgileriGroupBox.Visible = talimatBilgileriGroupBox.Enabled = odemeBilgileriGroupBox.Visible = odemeBilgileriGroupBox.Enabled = false;
            textBox1.Text = GirisSayfasi.adSoyad;
            comboBox1.SelectedItem = GirisSayfasi.il;
            numericUpDown1.Minimum = decimal.Parse(1.ToString());
            numericUpDown1.ReadOnly = true;
            maskedTextBox1.Mask = "0000";
            maskedTextBox2.Mask = "0000";
            maskedTextBox3.Mask = "0000";
            maskedTextBox4.Mask = "0000";
            maskedTextBox5.Mask = "000";
            
            if (durum == true)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = Urunler.urunresimyol;
                label1.Text = Urunler.urunad;
                label4.Text = Urunler.urunfiyat;
                //label3.Text = Urunler.urunstokadet;
                //label15.Text = Urunler.urunId;
                //label16.Text = Urunler.urunturu;
                //label17.Text = Urunler.urunsahibiId;
            }
            else
            {
                MessageBox.Show("saasfsa");
            }

            try
            {
                siparisim.Open();
                OleDbCommand iller = new OleDbCommand("select * from iller", siparisim);
                OleDbDataReader ilEkle = iller.ExecuteReader();
                while (ilEkle.Read())
                {
                    comboBox1.Items.Add(ilEkle["sehirler"]);
                }
                siparisim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                siparisim.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = label4.Text + " ₺";
            timer1.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = (double.Parse(label4.Text) * double.Parse(numericUpDown1.Value.ToString())).ToString() + " ₺";
            numericUpDown1.Maximum = decimal.Parse(Urunler.urunstokadet) + 1;
            if (numericUpDown1.Value == numericUpDown1.Maximum)
            {
                MessageBox.Show("Yeterli stok bulunmamaktadır.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numericUpDown1.Maximum = decimal.Parse(Urunler.urunstokadet);
            }
        }

        private void ilerleButon_Click(object sender, EventArgs e)
        {
            geriDon.Enabled = geriDon.Visible = odemeyapButon.Enabled = odemeyapButon.Visible = true;
            talimatBilgileriGroupBox.Visible = talimatBilgileriGroupBox.Enabled = odemeBilgileriGroupBox.Visible = odemeBilgileriGroupBox.Enabled = true;
            geriyeDon.Visible = label14.Visible = odemeIslemleriGroupBox.Visible = false;
            label13.Text = label2.Text;
        }

        private void geriDon_Click(object sender, EventArgs e)
        {
            geriDon.Enabled = geriDon.Visible = odemeyapButon.Enabled = odemeyapButon.Visible = false;
            talimatBilgileriGroupBox.Visible = talimatBilgileriGroupBox.Enabled = odemeBilgileriGroupBox.Visible = odemeBilgileriGroupBox.Enabled = false;
            geriyeDon.Visible = label14.Visible = odemeIslemleriGroupBox.Visible = true;
        }

        private void geriyeDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void odemeyapButon_Click(object sender, EventArgs e)
        {
            double fiyat;
            int guncelstokadet;
            bool satisKontrol = false;
            if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && maskedTextBox1.MaskCompleted != false &&
                maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && maskedTextBox4.MaskCompleted != false && maskedTextBox5.MaskCompleted != false)
            {
                try
                {
                    satisKontrol = true;
                    siparisim.Open();
                    fiyat = (double.Parse(label4.Text)) * (double.Parse(numericUpDown1.Value.ToString()));
                    OleDbCommand insert = new OleDbCommand("insert into satilanUrunler(id,satilanurunadi,satilanurunturu,satilanurunfiyati,satilanurunsahibiId,satilanurunresim,satilanurunualanId,satilanurunadet) values ('" + Urunler.urunId + "','" + label1.Text +
                        "','" + Urunler.urunturu + "','" + fiyat + "','" + Urunler.urunsahibiId + "','" + pictureBox2.ImageLocation + "','" + GirisSayfasi.kullaniciId + "','" + numericUpDown1.Value + "')", siparisim);
                    insert.ExecuteNonQuery();
                    siparisim.Close();
                    //MessageBox.Show("Satın alma işlemi başarıyla gerçekleşti.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //this.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);
                    siparisim.Close();
                }
            }
            else
            {
                MessageBox.Show("Boş alanları doldurmanız zorunludur !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int sayi2 = int.Parse(numericUpDown1.Value.ToString());
            string sayi1 = Urunler.urunstokadet;
            guncelstokadet = int.Parse(sayi1) - sayi2;

            if (satisKontrol == true)
            {
                try
                {
                    siparisim.Open();
                    OleDbCommand update = new OleDbCommand("update urunler set urunstokadet='" + guncelstokadet.ToString() + "',urunusepeteatanId='" + 0.ToString() + "' where id=" + int.Parse(Urunler.urunId) + "", siparisim);
                    update.ExecuteNonQuery();
                    siparisim.Close();
                    MessageBox.Show("Ödeme işlemi başarıyla gerçekleşti.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    frm7.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message);
                    siparisim.Close();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}

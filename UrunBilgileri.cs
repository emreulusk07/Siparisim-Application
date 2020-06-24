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
    public partial class UrunBilgileri : Form
    {
        public UrunBilgileri()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        public static int durum;
        public string urunresimyolu;
        string toplamStr = "";
        double toplam = 0;

        private void UrunBilgileri_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(anasayfaDon, "Anasayfa");
            if (durum == 0)
            {
                this.Text = "Ürünleri Düzenle";
                dataGridView1.Visible = pictureBox2.Visible = pictureBox1.Visible = false;
                label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = label8.Visible = label9.Visible = false;
                textBox1.Visible = textBox2.Visible = textBox3.Visible = comboBox1.Visible = numericUpDown1.Visible = false;
                stokaraButon.Visible = textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = false;
                urunleritopluekleButon.Visible = resimEkle.Visible = urunuekleButon.Visible = resimDegistir.Visible = urunuguncelleButon.Visible = urunusilButon.Visible = false;
                urunleritopluekleButon.Enabled = resimEkle.Enabled = urunuekleButon.Enabled = resimDegistir.Enabled = urunuguncelleButon.Enabled = urunusilButon.Enabled = false;

                string[] urunKategori = { "Fast - Food", "Yemek", "İçecek", "Tatlı" };
                comboBox1.Items.AddRange(urunKategori);
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                numericUpDown1.DecimalPlaces = 1;
                numericUpDown1.Increment = 0.2M;
                numericUpDown1.ReadOnly = true;
            }
            else if(durum == 1)
            {
                stokaraButon.Visible = label1.Visible = label7.Visible = dataGridView1.Visible = true;
                urunleritopluekleButon.Visible = false;
                label7.Text = "ÜRÜN STOK DURUMU";
                label1.Location = new Point(67, 160);
                textBox1.Visible = textBox1.Enabled = true;
                textBox1.Location = new Point(180, 160);
                try
                {
                    siparisim.Open();
                    OleDbDataAdapter stokListesi = new OleDbDataAdapter("select id AS[ÜRÜN ID], urunadi AS[ADI], " +
                        "urunturu AS[KATEGORİSİ], urunfiyati AS[FİYATI], urunstokadet AS[STOK ADETİ] from urunler where urunsahibiId=" + GirisSayfasi.saticiId + "", siparisim);
                    DataSet dshafiza = new DataSet();
                    stokListesi.Fill(dshafiza);
                    dataGridView1.DataSource = dshafiza.Tables[0];
                    siparisim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }

                urunekleButon.Enabled = urungucelleButon.Enabled = urunsilButon.Enabled = topluurunekleButon.Enabled = false;
                urunekleButon.Visible = urungucelleButon.Visible = urunsilButon.Visible = topluurunekleButon.Visible = false;
                label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label8.Visible = label9.Visible = false;
                textBox2.Visible = textBox3.Visible = comboBox1.Visible = numericUpDown1.Visible = false;
                textBox2.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = false;
                pictureBox2.Visible = pictureBox1.Visible = false;
                resimEkle.Visible = urunuekleButon.Visible = resimEkle.Enabled = urunuekleButon.Enabled = false;
                resimDegistir.Enabled = urunuguncelleButon.Enabled = resimDegistir.Visible = urunuguncelleButon.Visible = false;
                urunusilButon.Visible = urunusilButon.Enabled = false;
            }
            else if(durum == 2)
            {
                stokaraButon.Visible = label7.Visible = urunleritopluekleButon.Visible = false;
                label8.Visible = label9.Visible = dataGridView1.Visible = pictureBox1.Visible = true;
                try
                {
                    siparisim.Open();
                    OleDbDataAdapter kazanclarim = new OleDbDataAdapter("select id AS[ÜRÜN ID], satilanurunadi AS[ADI], " +
                        "satilanurunturu AS[KATEGORİSİ], satilanurunfiyati AS[FİYATI], satilanurunadet AS[ADET] from satilanUrunler where satilanurunsahibiId=" + GirisSayfasi.saticiId + "", siparisim);
                    DataSet dshafiza = new DataSet();
                    kazanclarim.Fill(dshafiza);
                    dataGridView1.DataSource = dshafiza.Tables[0];
                    siparisim.Close();
                    
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    toplamStr = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    toplam += Convert.ToDouble(toplamStr);
                }
                label9.Text = toplam.ToString();

                urunekleButon.Enabled = urungucelleButon.Enabled = urunsilButon.Enabled = topluurunekleButon.Enabled = false;
                urunekleButon.Visible = urungucelleButon.Visible = urunsilButon.Visible = topluurunekleButon.Visible = false;
                label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = false;
                textBox1.Visible = textBox2.Visible = textBox3.Visible = comboBox1.Visible = numericUpDown1.Visible = false;
                textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = false;
                pictureBox2.Visible = false;
                resimEkle.Visible = urunuekleButon.Visible = resimEkle.Enabled = urunuekleButon.Enabled = false;
                resimDegistir.Enabled = urunuguncelleButon.Enabled = resimDegistir.Visible = urunuguncelleButon.Visible = false;
                urunusilButon.Visible = urunusilButon.Enabled = false;
            }
        }

        private void stokaraButon_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                try
                {
                    siparisim.Open();
                    OleDbDataAdapter stokAra = new OleDbDataAdapter("select id AS[ÜRÜN ID], urunadi AS[ADI], urunturu AS[KATEGORİSİ], " +
                        "urunfiyati AS[FİYATI], urunstokadet AS[STOK ADETİ] from urunler where urunsahibiId=" + GirisSayfasi.saticiId + " and urunadi='" + textBox1.Text + "'", siparisim);
                    DataSet dshafiza = new DataSet();
                    stokAra.Fill(dshafiza);
                    dataGridView1.DataSource = dshafiza.Tables[0];
                    siparisim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }
            }
            else
                MessageBox.Show("Ürün adı alanını doldurunuz !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void topluurunekleButon_Click(object sender, EventArgs e)
        {
            urunekleButon.Enabled = urungucelleButon.Enabled = urunsilButon.Enabled = topluurunekleButon.Enabled = false;
            urunekleButon.Visible = urungucelleButon.Visible = urunsilButon.Visible = topluurunekleButon.Visible = false;
            label6.Text = "Toplu Ürün Adet";
            textBox3.Text = "5";
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = true;
            textBox1.Visible = textBox2.Visible = textBox3.Visible = comboBox1.Visible = numericUpDown1.Visible = true;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = false;
            urunleritopluekleButon.Enabled = true;
            pictureBox2.Visible = false;
            resimEkle.Visible = urunleritopluekleButon.Visible = true;
            resimEkle.Enabled = false;
        }

        private void urunekleButon_Click(object sender, EventArgs e)
        {
            urunekleButon.Enabled = urungucelleButon.Enabled = urunsilButon.Enabled = topluurunekleButon.Enabled = false;
            urunekleButon.Visible = urungucelleButon.Visible = urunsilButon.Visible = topluurunekleButon.Visible = false;
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = true;
            textBox1.Visible = textBox2.Visible = comboBox1.Visible = numericUpDown1.Visible = true;
            textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = true;
            pictureBox2.Visible = true;
            resimEkle.Visible = urunuekleButon.Visible = true;
            resimEkle.Enabled = urunuekleButon.Enabled = true;
            urunleritopluekleButon.Visible = urunleritopluekleButon.Enabled = false;
            resimDegistir.Enabled = urunuguncelleButon.Enabled = resimDegistir.Visible = urunuguncelleButon.Visible = false;
        }

        private void urungucelleButon_Click(object sender, EventArgs e)
        {
            urunekleButon.Enabled = urungucelleButon.Enabled = urunsilButon.Enabled = topluurunekleButon.Visible = false;
            urunekleButon.Visible = urungucelleButon.Visible = urunsilButon.Visible = topluurunekleButon.Visible = false;
            label6.Text = "Ürün ID";
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = true;
            textBox1.Visible = textBox2.Visible = textBox3.Visible = comboBox1.Visible = numericUpDown1.Visible = true;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = true;
            pictureBox2.Visible = true;
            urunleritopluekleButon.Visible = urunleritopluekleButon.Enabled = false;
            resimEkle.Visible = urunuekleButon.Visible = resimEkle.Enabled = urunuekleButon.Enabled = false;
            resimDegistir.Enabled = urunuguncelleButon.Enabled = resimDegistir.Visible = urunuguncelleButon.Visible = true;
        }

        private void urunsilButon_Click(object sender, EventArgs e)
        {
            urunekleButon.Enabled = urungucelleButon.Enabled = urunsilButon.Enabled = topluurunekleButon.Visible = false;
            urunekleButon.Visible = urungucelleButon.Visible = urunsilButon.Visible = topluurunekleButon.Visible = false;
            label6.Text = "Ürün ID";
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = true;
            textBox1.Visible = textBox2.Visible = textBox3.Visible = comboBox1.Visible = numericUpDown1.Visible = true;
            textBox1.Enabled = textBox2.Enabled = comboBox1.Enabled = numericUpDown1.Enabled = true;
            pictureBox2.Visible = true;
            urunleritopluekleButon.Visible = urunleritopluekleButon.Enabled = false;
            resimEkle.Visible = urunuekleButon.Visible = resimEkle.Enabled = urunuekleButon.Enabled = false;
            resimDegistir.Enabled = urunuguncelleButon.Enabled = resimDegistir.Visible = urunuguncelleButon.Visible = false;
            urunusilButon.Visible = urunusilButon.Enabled = true;
        }

        private void urunleritopluekleButon_Click(object sender, EventArgs e)
        {
            string dosya = Application.StartupPath + "\\UrunEkle.txt";
            string bilgi = System.IO.File.ReadAllText(dosya);
            string[] metin = bilgi.Split(new char[] { '_' });
            for (int i=0; i < metin.Length; i++)
            {
                bool kayitKontrol = false;
                siparisim.Open();
                OleDbCommand select = new OleDbCommand("select * from urunler where urunadi='" + metin[i] + "' and urunturu='" + metin[++i] + "' and urunsahibiId=" + GirisSayfasi.saticiId + "", siparisim);
                OleDbDataReader kayitOku = select.ExecuteReader();
                --i;
                while (kayitOku.Read())
                {
                    kayitKontrol = true;
                    break;
                }
                siparisim.Close();

                if (kayitKontrol == false)
                {
                    if (pictureBox2.Image == null)
                        resimEkle.ForeColor = Color.Red;

                    try
                    {
                        if (pictureBox2.Image == null)
                            resimEkle.ForeColor = Color.White;
                        siparisim.Open();
                        OleDbCommand insert = new OleDbCommand("insert into urunler(urunadi,urunturu,urunfiyati,urunstokadet,urunsahibiId,urunresim) values ('" + metin[i] + "','" + metin[++i] +
                            "','" + metin[++i] + "','" + metin[++i] + "','" + GirisSayfasi.saticiId + "','" + metin[++i] + "')", siparisim);
                        insert.ExecuteNonQuery();
                        siparisim.Close();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        siparisim.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Aynı özelliklere sahip ürün zaten mevcuttur.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                if(i == metin.Length - 1)
                {
                    MessageBox.Show("Toplu ürün kaydı tamamlandı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
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
                    urunresimyolu = resimSec.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void urunuekleButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            siparisim.Open();
            OleDbCommand select = new OleDbCommand("select * from urunler where urunadi='" + textBox1.Text + "' and urunturu='" + comboBox1.Text + "' and urunsahibiId=" + GirisSayfasi.saticiId + "", siparisim);
            OleDbDataReader kayitOku = select.ExecuteReader();
            while (kayitOku.Read())
            {
                kayitKontrol = true;
                break;
            }
            siparisim.Close();

            if (kayitKontrol == false)
            {
                if (pictureBox2.Image == null)
                    resimEkle.ForeColor = Color.Red;

                if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != ""
                    && numericUpDown1.Value != 0 && pictureBox2.Image != null)
                {
                    try
                    {
                        if (pictureBox2.Image == null)
                            resimEkle.ForeColor = Color.White;
                        siparisim.Open();
                        OleDbCommand insert = new OleDbCommand("insert into urunler(urunadi,urunturu,urunfiyati,urunstokadet,urunsahibiId,urunresim) values ('" + textBox1.Text + "','" + comboBox1.Text +
                            "','" + numericUpDown1.Value + "','" + textBox2.Text + "','" + GirisSayfasi.saticiId + "','" + urunresimyolu + "')", siparisim);
                        insert.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Ürün kaydı tamamlandı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Alanlar boş bırakılamaz !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bu özelliklere sahip ürün zaten mevcuttur.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resimDegistir_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = null;
            urunresimyolu = "";
            try
            {
                OpenFileDialog resimSec = new OpenFileDialog();
                resimSec.Title = "Resimler";
                resimSec.Filter = "JPG Dosyalar (*.jpg) | *.jpg";
                if (resimSec.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictureBox2.Image = Image.FromFile(resimSec.FileName);
                    urunresimyolu = resimSec.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void urunuguncelleButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            siparisim.Open();
            OleDbCommand select = new OleDbCommand("select * from urunler where id=" + int.Parse(textBox3.Text) + "", siparisim);
            OleDbDataReader kayitOku = select.ExecuteReader();
            while (kayitOku.Read() && kayitOku.GetValue(5).ToString() == GirisSayfasi.saticiId.ToString())
            {
                kayitKontrol = true;
                break;
            }
            siparisim.Close();

            if (kayitKontrol == true)
            {
                if (pictureBox2.Image == null)
                    resimDegistir.ForeColor = Color.Red;

                if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != ""
                    && numericUpDown1.Value != 0 && pictureBox2.Image != null)
                {
                    try
                    {
                        if (pictureBox2.Image == null)
                            resimDegistir.ForeColor = Color.White;
                        siparisim.Open();
                        OleDbCommand update = new OleDbCommand("update urunler set urunadi='" + textBox1.Text + "',urunturu='" + comboBox1.Text +
                            "',urunfiyati='" + numericUpDown1.Value + "',urunstokadet='" + textBox2.Text + "',urunresim='" + urunresimyolu + "' where id=" + int.Parse(textBox3.Text) + "", siparisim);
                        update.ExecuteNonQuery();
                        siparisim.Close();
                        MessageBox.Show("Ürün güncelleme işlemi tamamlandı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Alanlar boş bırakılamaz !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bu özelliklere sahip ürününüz bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void urunusilButon_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                bool kayitAra = false;
                siparisim.Open();
                OleDbCommand search = new OleDbCommand("select * from urunler where id=" + int.Parse(textBox3.Text) + "", siparisim);
                OleDbDataReader kayitOkuma = search.ExecuteReader();
                while (kayitOkuma.Read() && kayitOkuma.GetValue(5).ToString() == GirisSayfasi.saticiId.ToString())
                {
                    kayitAra = true;
                    OleDbCommand delete = new OleDbCommand("delete from urunler where id=" + int.Parse(textBox3.Text) + "", siparisim);
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Ürün veritabanından silindi.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    siparisim.Close();
                    this.Close();
                    break;
                }
                if (kayitAra == false)
                    MessageBox.Show("Silinecek ürün kaydınız bulunamadı !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                siparisim.Close();
            }
            else
                MessageBox.Show("Lütfen ID kısmını doldurunuz !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool kayitKontrol = false;
                siparisim.Open();
                OleDbCommand select = new OleDbCommand("select * from urunler where id=" + int.Parse(textBox3.Text) + "", siparisim);
                OleDbDataReader kayitOku = select.ExecuteReader();
                while (kayitOku.Read())
                {
                    kayitKontrol = true;
                    break;
                }

                if (kayitKontrol == true)
                {
                    textBox1.Text = kayitOku.GetValue(1).ToString();
                    textBox2.Text = kayitOku.GetValue(4).ToString();
                    comboBox1.Text = kayitOku.GetValue(2).ToString();
                    numericUpDown1.Value = int.Parse(kayitOku.GetValue(3).ToString());
                    pictureBox2.ImageLocation = kayitOku.GetValue(6).ToString();
                }
                siparisim.Close();
            }
            catch (Exception)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                numericUpDown1.Value = 0;
                pictureBox2.Image = null;
                siparisim.Close();
            }
        }

        private void anasayfaDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

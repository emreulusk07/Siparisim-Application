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
    public partial class SiparisGecmisi : Form
    {
        public SiparisGecmisi()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        public static bool durum;

        private void kullanici_datagridview()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            pictureBox2.Visible = false;

            DataGridViewTextBoxColumn urunad = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn uruntur = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn urunfiyat = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn satilanurunadet = new DataGridViewTextBoxColumn();
            DataGridViewImageColumn resim = new DataGridViewImageColumn();

            dataGridView1.Columns.Add(urunad);
            dataGridView1.Columns.Add(uruntur);
            dataGridView1.Columns.Add(urunfiyat);
            dataGridView1.Columns.Add(satilanurunadet);
            dataGridView1.Columns.Add(resim);

            urunad.Width = 110;
            uruntur.Width = 100;
            urunfiyat.Width = 100;
            satilanurunadet.Width = 100;
            resim.Width = 150;

            urunad.HeaderText = "ADI";
            uruntur.HeaderText = "KATEGORİ";
            urunfiyat.HeaderText = "ÖDENEN TUTAR";
            satilanurunadet.HeaderText = "SATIŞ ADET";
            resim.HeaderText = "RESİM";
        }

        private void satici_datagridview()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            pictureBox2.Visible = true;

            DataGridViewTextBoxColumn urunad = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn uruntur = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn urunfiyat = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn satilanurunadet = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn satinalanId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resim = new DataGridViewTextBoxColumn();

            dataGridView1.Columns.Add(urunad);
            dataGridView1.Columns.Add(uruntur);
            dataGridView1.Columns.Add(urunfiyat);
            dataGridView1.Columns.Add(satilanurunadet);
            dataGridView1.Columns.Add(satinalanId);
            dataGridView1.Columns.Add(resim);

            urunad.Width = 120;
            uruntur.Width = 110;
            urunfiyat.Width = 110;
            satilanurunadet.Width = 110;
            satinalanId.Width = 110;
            resim.Width = 100;

            urunad.HeaderText = "ADI";
            uruntur.HeaderText = "KATEGORİ";
            urunfiyat.HeaderText = "ÖDENEN TUTAR";
            satilanurunadet.HeaderText = "SATIŞ ADET";
            satinalanId.HeaderText = "SATIN ALAN ID";
            resim.HeaderText = "RESİM YOLU";
        }

        private void SiparisGecmisi_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(anasayfaDon, "Anasayfa");
            if (durum == true)
            {
                kullanici_datagridview();
                
                try
                {
                    siparisim.Open();
                    OleDbCommand siparisGecmisi = new OleDbCommand("select * from satilanUrunler where satilanurunualanId=" + GirisSayfasi.kullaniciId + "", siparisim);
                    OleDbDataReader kayitOku = siparisGecmisi.ExecuteReader();
                    while (kayitOku.Read())
                    {
                        dataGridView1.Rows.Add(kayitOku.GetValue(1).ToString(), kayitOku.GetValue(2).ToString(), kayitOku.GetValue(3).ToString(), kayitOku.GetValue(7).ToString(), Image.FromFile(kayitOku.GetValue(5).ToString()));
                    }
                    siparisim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }
            }
            else
            {
                satici_datagridview();

                try
                {
                    siparisim.Open();
                    OleDbCommand siparisKutusu = new OleDbCommand("select * from satilanUrunler where satilanurunsahibiId=" + GirisSayfasi.saticiId + "", siparisim);
                    OleDbDataReader kayitOku = siparisKutusu.ExecuteReader();
                    while (kayitOku.Read())
                    {
                        dataGridView1.Rows.Add(kayitOku.GetValue(1).ToString(), kayitOku.GetValue(2).ToString(), kayitOku.GetValue(3).ToString(), kayitOku.GetValue(7).ToString(), kayitOku.GetValue(6).ToString(), kayitOku.GetValue(5).ToString());
                    }
                    siparisim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    siparisim.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Selected == true && durum == false)
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.ImageLocation = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    //pictureBox2.ImageLocation = dataGridView1.Rows[i].Cells[4].Value.ToString();
                }
            }
        }

        private void stokaraButon_Click(object sender, EventArgs e)
        {
            bool kayitKontrol = false;
            if(durum == true)
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand siparisGecmisi = new OleDbCommand("select * from satilanUrunler where satilanurunualanId=" + GirisSayfasi.kullaniciId + " and satilanurunadi='" + textBox1.Text + "'", siparisim);
                        OleDbDataReader kayitOku = siparisGecmisi.ExecuteReader();
                        while (kayitOku.Read())
                        {
                            kayitKontrol = true;
                            kullanici_datagridview();
                            dataGridView1.Rows.Add(kayitOku.GetValue(1).ToString(), kayitOku.GetValue(2).ToString(), kayitOku.GetValue(3).ToString(), kayitOku.GetValue(7).ToString(), Image.FromFile(kayitOku.GetValue(5).ToString()));
                        }
                        if (kayitKontrol == false)
                        {
                            MessageBox.Show("Aradığınız isimde ürün bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
            else
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        siparisim.Open();
                        OleDbCommand siparisGecmisi = new OleDbCommand("select * from satilanUrunler where satilanurunsahibiId=" + GirisSayfasi.saticiId + " and satilanurunadi='" + textBox1.Text + "'", siparisim);
                        OleDbDataReader kayitOku = siparisGecmisi.ExecuteReader();
                        while (kayitOku.Read())
                        {
                            kayitKontrol = true;
                            satici_datagridview();
                            dataGridView1.Rows.Add(kayitOku.GetValue(1).ToString(), kayitOku.GetValue(2).ToString(), kayitOku.GetValue(3).ToString(), kayitOku.GetValue(7).ToString(), kayitOku.GetValue(6).ToString(), kayitOku.GetValue(5).ToString());
                        }
                        if (kayitKontrol == false)
                        {
                            MessageBox.Show("Aradığınız isimde ürün bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
        }

        private void anasayfaDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

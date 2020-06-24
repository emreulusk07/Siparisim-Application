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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        OleDbConnection siparisim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = Siparisim.accdb");
        public static bool durum;
        public int satirSayisi = 0;
        public int satirSayisi2 = 0;
        int kontrol = 0;
        int urunSayac = 0;

        private void Urunler_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox3, "Sepetlerim");
            toolTip1.SetToolTip(anasayfaDon, "Anasayfa");
            sepetlistView.Items.Clear();
            siparisim.Open();
            OleDbCommand search = new OleDbCommand("Select * From urunler where urunusepeteatanId=" + GirisSayfasi.kullaniciId + "", siparisim);
            try
            {
                OleDbDataReader kayitOkuma = search.ExecuteReader();
                while (kayitOkuma.Read())
                {
                    satirSayisi2 = sepetlistView.Items.Count;
                    ListViewItem item = new ListViewItem(kayitOkuma["urunturu"].ToString());
                    item.SubItems.Add(kayitOkuma["urunadi"].ToString());
                    item.SubItems.Add(kayitOkuma["urunfiyati"].ToString());
                    item.SubItems.Add(kayitOkuma["urunsahibiId"].ToString());
                    item.SubItems.Add(kayitOkuma["urunresim"].ToString());
                    item.SubItems.Add(kayitOkuma["urunstokadet"].ToString());
                    item.SubItems.Add(kayitOkuma["id"].ToString());
                    sepetlistView.Items.Add(item);
                    urunSayac++;
                    label2.Text = urunSayac.ToString();
                }
                siparisim.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                siparisim.Close();
            }
            if (durum == false)
            {
                this.Text = "Ürünler";
                string[] urunKategori = { "Fast - Food", "Yemek", "İçecek", "Tatlı" };
                comboBox1.Items.AddRange(urunKategori);
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                label1.Visible = label2.Visible = urunlistView.Visible = true;
                urunaraButon.Visible = sepeteekleButon.Visible = urunaraButon.Enabled = sepeteekleButon.Enabled = true;
                sepettensilButon.Visible = siparisverButon.Visible = sepettensilButon.Enabled = siparisverButon.Enabled = false;
                anasayfaDon.Visible = pictureBox2.Visible = pictureBox3.Visible = comboBox1.Visible = true;
                sepetlistView.Visible = geriDon.Visible = geriDon.Enabled = label3.Visible = false;
            }
            else
            {
                kontrol = 1;
                pictureBox3_Click(sender, e);
            }
        }

        private Form aktifForm = null;
        private void SayfalarForm(Form Sayfalar)
        {
            if (aktifForm != null)
                aktifForm.Close();
            aktifForm = Sayfalar;
            Sayfalar.TopLevel = false;
            Sayfalar.FormBorderStyle = FormBorderStyle.None;
            Sayfalar.Dock = DockStyle.Fill;
            panelSiparis.Controls.Add(Sayfalar);
            panelSiparis.Tag = Sayfalar;
            Sayfalar.BringToFront();
            Sayfalar.Show();
        }

        public static string urunresimyol, urunad, urunfiyat, urunstokadet, urunId, urunturu, urunsahibiId;
        private void siparisverButon_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < satirSayisi2 + 1; i++)
            {
                if (sepetlistView.Items.Count == 0)
                {
                    MessageBox.Show("Sipariş verilecek ürün bulunamadı !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                if (sepetlistView.Items[i].Selected == true)
                {
                    urunresimyol = sepetlistView.Items[i].SubItems[4].Text;
                    urunad = sepetlistView.Items[i].SubItems[1].Text;
                    urunfiyat = sepetlistView.Items[i].SubItems[2].Text;
                    urunstokadet = sepetlistView.Items[i].SubItems[5].Text;
                    urunId = sepetlistView.Items[i].SubItems[6].Text;
                    urunturu = sepetlistView.Items[i].SubItems[0].Text;
                    urunsahibiId = sepetlistView.Items[i].SubItems[3].Text;
                    SiparisVer.durum = true;
                    SayfalarForm(new SiparisVer());
                    break;
                }
            }
        }

        private void urunaraButon_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Fast - Food")
            {
                urunlistView.Items.Clear();
                siparisim.Open();
                OleDbCommand search = new OleDbCommand("Select * From urunler where urunturu='" + comboBox1.SelectedItem + "'", siparisim);
                try
                {
                    OleDbDataReader kayitOkuma = search.ExecuteReader();
                    while (kayitOkuma.Read())
                    {
                        satirSayisi = urunlistView.Items.Count;
                        ListViewItem item = new ListViewItem(kayitOkuma["urunturu"].ToString());
                        item.SubItems.Add(kayitOkuma["urunadi"].ToString());
                        item.SubItems.Add(kayitOkuma["urunfiyati"].ToString());
                        item.SubItems.Add(kayitOkuma["urunsahibiId"].ToString());
                        item.SubItems.Add(kayitOkuma["urunresim"].ToString());
                        urunlistView.Items.Add(item);
                    }
                    siparisim.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                    siparisim.Close();
                }
                if (urunlistView.Items.Count == 0)
                    MessageBox.Show("Seçtiğiniz kategoride ürün bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBox1.SelectedItem == "Yemek")
            {
                urunlistView.Items.Clear();
                siparisim.Open();
                OleDbCommand search = new OleDbCommand("Select * From urunler where urunturu='" + comboBox1.SelectedItem + "'", siparisim);
                try
                {
                    OleDbDataReader kayitOkuma = search.ExecuteReader();
                    while (kayitOkuma.Read())
                    {
                        satirSayisi = urunlistView.Items.Count;
                        ListViewItem item = new ListViewItem(kayitOkuma["urunturu"].ToString());
                        item.SubItems.Add(kayitOkuma["urunadi"].ToString());
                        item.SubItems.Add(kayitOkuma["urunfiyati"].ToString());
                        item.SubItems.Add(kayitOkuma["urunsahibiId"].ToString());
                        item.SubItems.Add(kayitOkuma["urunresim"].ToString());
                        urunlistView.Items.Add(item);
                    }
                    siparisim.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                    siparisim.Close();
                }
                if (urunlistView.Items.Count == 0)
                    MessageBox.Show("Seçtiğiniz kategoride ürün bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBox1.SelectedItem == "İçecek")
            {
                urunlistView.Items.Clear();
                siparisim.Open();
                OleDbCommand search = new OleDbCommand("Select * From urunler where urunturu='" + comboBox1.SelectedItem + "'", siparisim);
                try
                {
                    OleDbDataReader kayitOkuma = search.ExecuteReader();
                    while (kayitOkuma.Read())
                    {
                        satirSayisi = urunlistView.Items.Count;
                        ListViewItem item = new ListViewItem(kayitOkuma["urunturu"].ToString());
                        item.SubItems.Add(kayitOkuma["urunadi"].ToString());
                        item.SubItems.Add(kayitOkuma["urunfiyati"].ToString());
                        item.SubItems.Add(kayitOkuma["urunsahibiId"].ToString());
                        item.SubItems.Add(kayitOkuma["urunresim"].ToString());
                        urunlistView.Items.Add(item);
                    }
                    siparisim.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                    siparisim.Close();
                }
                if (urunlistView.Items.Count == 0)
                    MessageBox.Show("Seçtiğiniz kategoride ürün bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBox1.SelectedItem == "Tatlı")
            {
                urunlistView.Items.Clear();
                siparisim.Open();
                OleDbCommand search = new OleDbCommand("Select * From urunler where urunturu='" + comboBox1.SelectedItem + "'", siparisim);
                try
                {
                    OleDbDataReader kayitOkuma = search.ExecuteReader();
                    while (kayitOkuma.Read())
                    {
                        satirSayisi = urunlistView.Items.Count;
                        ListViewItem item = new ListViewItem(kayitOkuma["urunturu"].ToString());
                        item.SubItems.Add(kayitOkuma["urunadi"].ToString());
                        item.SubItems.Add(kayitOkuma["urunfiyati"].ToString());
                        item.SubItems.Add(kayitOkuma["urunsahibiId"].ToString());
                        item.SubItems.Add(kayitOkuma["urunresim"].ToString());
                        urunlistView.Items.Add(item);
                    }
                    siparisim.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                    siparisim.Close();
                }
                if (urunlistView.Items.Count == 0)
                    MessageBox.Show("Seçtiğiniz kategoride ürün bulunamadı.", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void urunlistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < satirSayisi + 1; i++)
            {
                if (urunlistView.Items[i].Selected == true)
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.ImageLocation = urunlistView.Items[i].SubItems[4].Text;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            urunlistView.Visible = label1.Visible = comboBox1.Visible = anasayfaDon.Visible = false;
            pictureBox2.Visible = false;
            sepetlistView.Visible = true;
            urunaraButon.Visible = urunaraButon.Enabled = sepeteekleButon.Visible = sepeteekleButon.Enabled = false;
            sepettensilButon.Visible = sepettensilButon.Enabled = siparisverButon.Visible = siparisverButon.Enabled = true;

            if (kontrol == 1)
            {
                anasayfaDon.Visible = true;
                geriDon.Visible = geriDon.Enabled = label3.Visible = false;
                kontrol = 0;
            }
            else
            {
                anasayfaDon.Visible = false;
                geriDon.Visible = geriDon.Enabled = label3.Visible = true;
            }

            sepetlistView.Items.Clear();
            siparisim.Open();
            OleDbCommand search = new OleDbCommand("Select * From urunler where urunusepeteatanId=" + GirisSayfasi.kullaniciId + "", siparisim);
            try
            {
                OleDbDataReader kayitOkuma = search.ExecuteReader();
                while (kayitOkuma.Read())
                {
                    satirSayisi2 = sepetlistView.Items.Count;
                    ListViewItem item = new ListViewItem(kayitOkuma["urunturu"].ToString());
                    item.SubItems.Add(kayitOkuma["urunadi"].ToString());
                    item.SubItems.Add(kayitOkuma["urunfiyati"].ToString());
                    item.SubItems.Add(kayitOkuma["urunsahibiId"].ToString());
                    item.SubItems.Add(kayitOkuma["urunresim"].ToString());
                    item.SubItems.Add(kayitOkuma["urunstokadet"].ToString());
                    item.SubItems.Add(kayitOkuma["id"].ToString());
                    sepetlistView.Items.Add(item);
                }
                siparisim.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                siparisim.Close();
            }
        }

        private void anasayfaDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void geriDon_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = urunlistView.Visible = label2.Visible = label1.Visible = comboBox1.Visible = anasayfaDon.Visible = true;
            sepetlistView.Visible = geriDon.Visible = geriDon.Enabled = label3.Visible = false;
            urunaraButon.Visible = urunaraButon.Enabled = sepeteekleButon.Visible = sepeteekleButon.Enabled = true;
            sepettensilButon.Visible = sepettensilButon.Enabled = siparisverButon.Visible = siparisverButon.Enabled = false;
        }

        private void sepeteekleButon_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < satirSayisi + 1; i++)
            {
                if (urunlistView.Items.Count == 0)
                {
                    MessageBox.Show("Sepete eklenecek ürün bulunamadı !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                if (urunlistView.Items[i].Selected == true)
                {
                    urunSayac++;
                    label2.Text = urunSayac.ToString();

                    try
                    {
                        siparisim.Open();
                        OleDbCommand update = new OleDbCommand("update urunler set urunusepeteatanId='" + GirisSayfasi.kullaniciId + "' where urunadi='" + urunlistView.Items[i].SubItems[1].Text + "' and urunturu='" + urunlistView.Items[i].SubItems[0].Text + "'", siparisim);
                        update.ExecuteNonQuery();
                        siparisim.Close();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        siparisim.Close();
                    }
                }
            }
        }

        private void sepettensilButon_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < satirSayisi2 + 1; i++)
            {
                if (sepetlistView.Items.Count == 0)
                {
                    MessageBox.Show("Sepetten silinecek ürün bulunamadı !", "Siparişim", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                if (sepetlistView.Items[i].Selected == true)
                {
                    urunSayac--;
                    label2.Text = urunSayac.ToString();

                    try
                    {
                        siparisim.Open();
                        OleDbCommand update = new OleDbCommand("update urunler set urunusepeteatanId='" + 0 + "' where urunadi='" + sepetlistView.Items[i].SubItems[1].Text + "' and urunturu='" + sepetlistView.Items[i].SubItems[0].Text + "'", siparisim);
                        update.ExecuteNonQuery();
                        siparisim.Close();
                        pictureBox3_Click(sender, e);
                    }
                    catch (Exception hatamsj)
                    {
                        urunSayac++;
                        label2.Text = urunSayac.ToString();
                        MessageBox.Show(hatamsj.Message);
                        siparisim.Close();
                    }
                }
            }
        }
    }
}

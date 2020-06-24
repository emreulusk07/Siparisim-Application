namespace _18010011013
{
    partial class GirisTuru
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisTuru));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kullaniciGiris = new System.Windows.Forms.PictureBox();
            this.saticiGiris = new System.Windows.Forms.PictureBox();
            this.YoneticiGiris = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciGiris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saticiGiris)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YoneticiGiris)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(299, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(511, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(368, 131);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(383, 125);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // kullaniciGiris
            // 
            this.kullaniciGiris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kullaniciGiris.Image = ((System.Drawing.Image)(resources.GetObject("kullaniciGiris.Image")));
            this.kullaniciGiris.Location = new System.Drawing.Point(343, 358);
            this.kullaniciGiris.Name = "kullaniciGiris";
            this.kullaniciGiris.Size = new System.Drawing.Size(120, 120);
            this.kullaniciGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kullaniciGiris.TabIndex = 2;
            this.kullaniciGiris.TabStop = false;
            this.kullaniciGiris.Click += new System.EventHandler(this.kullaniciGiris_Click);
            // 
            // saticiGiris
            // 
            this.saticiGiris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saticiGiris.Image = ((System.Drawing.Image)(resources.GetObject("saticiGiris.Image")));
            this.saticiGiris.Location = new System.Drawing.Point(502, 363);
            this.saticiGiris.Name = "saticiGiris";
            this.saticiGiris.Size = new System.Drawing.Size(120, 115);
            this.saticiGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.saticiGiris.TabIndex = 3;
            this.saticiGiris.TabStop = false;
            this.saticiGiris.Click += new System.EventHandler(this.saticiGiris_Click);
            // 
            // YoneticiGiris
            // 
            this.YoneticiGiris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.YoneticiGiris.Image = ((System.Drawing.Image)(resources.GetObject("YoneticiGiris.Image")));
            this.YoneticiGiris.Location = new System.Drawing.Point(652, 360);
            this.YoneticiGiris.Name = "YoneticiGiris";
            this.YoneticiGiris.Size = new System.Drawing.Size(120, 120);
            this.YoneticiGiris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.YoneticiGiris.TabIndex = 4;
            this.YoneticiGiris.TabStop = false;
            this.YoneticiGiris.Click += new System.EventHandler(this.YoneticiGiris_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gilroy-SemiBold", 14F);
            this.label1.Location = new System.Drawing.Point(471, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sisteme Giriş";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gilroy-SemiBold", 11F);
            this.label2.Location = new System.Drawing.Point(359, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kullanıcı";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gilroy-SemiBold", 11F);
            this.label3.Location = new System.Drawing.Point(531, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Satıcı";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gilroy-SemiBold", 11F);
            this.label4.Location = new System.Drawing.Point(668, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Yönetici";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gilroy-SemiBold", 15F);
            this.label5.Location = new System.Drawing.Point(24, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(327, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "EMRE ULUIŞIK - 18010011013";
            // 
            // GirisTuru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(25)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1082, 673);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YoneticiGiris);
            this.Controls.Add(this.saticiGiris);
            this.Controls.Add(this.kullaniciGiris);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GirisTuru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GirisTuru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kullaniciGiris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saticiGiris)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YoneticiGiris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox kullaniciGiris;
        private System.Windows.Forms.PictureBox saticiGiris;
        private System.Windows.Forms.PictureBox YoneticiGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
    }
}


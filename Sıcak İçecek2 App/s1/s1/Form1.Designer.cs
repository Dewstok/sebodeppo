namespace s1
{
    partial class Form1
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
            this.ONAY = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.siparisListe = new System.Windows.Forms.ListBox();
            this.caySecimComboBox = new System.Windows.Forms.ComboBox();
            this.kahveComboBox = new System.Windows.Forms.ComboBox();
            this.cayMiktar = new System.Windows.Forms.NumericUpDown();
            this.kahveMiktar = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toplam = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cayMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kahveMiktar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ONAY
            // 
            this.ONAY.Location = new System.Drawing.Point(444, 341);
            this.ONAY.Margin = new System.Windows.Forms.Padding(2);
            this.ONAY.Name = "ONAY";
            this.ONAY.Size = new System.Drawing.Size(185, 40);
            this.ONAY.TabIndex = 0;
            this.ONAY.Text = "ONAY";
            this.ONAY.UseVisualStyleBackColor = true;
            this.ONAY.Click += new System.EventHandler(this.ONAY_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seçiminiz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seçiminiz:";
            // 
            // siparisListe
            // 
            this.siparisListe.FormattingEnabled = true;
            this.siparisListe.Location = new System.Drawing.Point(446, 88);
            this.siparisListe.Margin = new System.Windows.Forms.Padding(2);
            this.siparisListe.Name = "siparisListe";
            this.siparisListe.Size = new System.Drawing.Size(183, 212);
            this.siparisListe.TabIndex = 3;
            // 
            // caySecimComboBox
            // 
            this.caySecimComboBox.FormattingEnabled = true;
            this.caySecimComboBox.Location = new System.Drawing.Point(90, 33);
            this.caySecimComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.caySecimComboBox.Name = "caySecimComboBox";
            this.caySecimComboBox.Size = new System.Drawing.Size(138, 21);
            this.caySecimComboBox.TabIndex = 4;
            this.caySecimComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // kahveComboBox
            // 
            this.kahveComboBox.FormattingEnabled = true;
            this.kahveComboBox.Location = new System.Drawing.Point(88, 40);
            this.kahveComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.kahveComboBox.Name = "kahveComboBox";
            this.kahveComboBox.Size = new System.Drawing.Size(138, 21);
            this.kahveComboBox.TabIndex = 5;
            // 
            // cayMiktar
            // 
            this.cayMiktar.Location = new System.Drawing.Point(232, 34);
            this.cayMiktar.Margin = new System.Windows.Forms.Padding(2);
            this.cayMiktar.Name = "cayMiktar";
            this.cayMiktar.Size = new System.Drawing.Size(33, 20);
            this.cayMiktar.TabIndex = 6;
            // 
            // kahveMiktar
            // 
            this.kahveMiktar.Location = new System.Drawing.Point(230, 41);
            this.kahveMiktar.Margin = new System.Windows.Forms.Padding(2);
            this.kahveMiktar.Name = "kahveMiktar";
            this.kahveMiktar.Size = new System.Drawing.Size(33, 20);
            this.kahveMiktar.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cayMiktar);
            this.groupBox1.Controls.Add(this.caySecimComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(364, 84);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Çay Çeşitleri";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.kahveMiktar);
            this.groupBox2.Controls.Add(this.kahveComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(20, 192);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(362, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kahve Çeşitleri";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(57, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "Şebo\'nun İçecek Tükkanı";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Toplam:";
            // 
            // toplam
            // 
            this.toplam.AutoSize = true;
            this.toplam.Location = new System.Drawing.Point(495, 312);
            this.toplam.Name = "toplam";
            this.toplam.Size = new System.Drawing.Size(35, 13);
            this.toplam.TabIndex = 12;
            this.toplam.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 437);
            this.Controls.Add(this.toplam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.siparisListe);
            this.Controls.Add(this.ONAY);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cayMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kahveMiktar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ONAY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox siparisListe;
        private System.Windows.Forms.ComboBox caySecimComboBox;
        private System.Windows.Forms.ComboBox kahveComboBox;
        private System.Windows.Forms.NumericUpDown cayMiktar;
        private System.Windows.Forms.NumericUpDown kahveMiktar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label toplam;
    }
}


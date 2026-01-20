using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sebo
{
    {
    public partial class Form1 : Form
    {
        private Label tKFiyatiLabel, fkFiyatiLabel, cayFiyatiLabel, musteriLabel;
        private TextBox musteriAdiTextBox;
        private ComboBox TÜRKADET, FİLTADET, CAYADET;
        private Button hesaplaButton;
        private ListBox Fatura;

        double tkFiyati = 115, fkFiyati = 85, cayFiyati = 60;
        private string connectionString = "Server=DESKTOP-LPE01RK\\SQLEXPRESS;Database=Satislar;User Id=DESKTOP-LPE01RK/sebnem;Password=Sifre;";

        public Form1()
        {
            InitializeComponent();
            this.Text = "Sıcak İçecek Satış Uygulaması";
            this.Size = new System.Drawing.Size(400, 300);

            tKFiyatiLabel = new Label { Text = "T.Kahvesi: (115 TL)", Location = new System.Drawing.Point(20, 20) };
            fkFiyatiLabel = new Label { Text = "F.Kahve: (85 TL)", Location = new System.Drawing.Point(20, 50) };
            cayFiyatiLabel = new Label { Text = "Çay: (60 TL)", Location = new System.Drawing.Point(20, 80) };
            musteriLabel = new Label { Text = "Müşteri Adı:", Location = new System.Drawing.Point(20, 110) };
            musteriAdiTextBox = new TextBox { Location = new System.Drawing.Point(150, 110), Width = 200 };

            TÜRKADET = new ComboBox { Location = new System.Drawing.Point(150, 20), Width = 40 };
            FİLTADET = new ComboBox { Location = new System.Drawing.Point(150, 50), Width = 40 };
            CAYADET = new ComboBox { Location = new System.Drawing.Point(150, 80), Width = 40 };

            for (int i = 0; i <= 5; i++)
            {
                TÜRKADET.Items.Add(i);
                FİLTADET.Items.Add(i);
                CAYADET.Items.Add(i);
            }

            hesaplaButton = new Button { Text = "Hesapla", Location = new System.Drawing.Point(20, 135) };
            hesaplaButton.Click += button1_Click;

            Fatura = new ListBox { Location = new System.Drawing.Point(20, 160), Width = 350, Height = 85 };

            this.Controls.Add(tKFiyatiLabel);
            this.Controls.Add(fkFiyatiLabel);
            this.Controls.Add(cayFiyatiLabel);
            this.Controls.Add(musteriLabel);
            this.Controls.Add(musteriAdiTextBox);
            this.Controls.Add(TÜRKADET);
            this.Controls.Add(FİLTADET);
            this.Controls.Add(CAYADET);
            this.Controls.Add(hesaplaButton);
            this.Controls.Add(Fatura);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string musteriAdi = musteriAdiTextBox.Text.Trim();
            int tKAdet = Convert.ToInt32(TÜRKADET.SelectedItem);
            int fKAdet = Convert.ToInt32(FİLTADET.SelectedItem);
            int cayAdet = Convert.ToInt32(CAYADET.SelectedItem);

            double toplamTutar = (tkFiyati * tKAdet) + (fkFiyati * fKAdet) + (cayFiyati * cayAdet);

            Fatura.Items.Clear();
            Fatura.Items.Add("Müşteri: " + (string.IsNullOrEmpty(musteriAdi) ? "Bilinmiyor" : musteriAdi));
            Fatura.Items.Add("Türk Kahvesi: " + tKAdet + " x " + tkFiyati + " TL");
            Fatura.Items.Add("Filtre Kahve: " + fKAdet + " x " + fkFiyati + " TL");
            Fatura.Items.Add("Çay: " + cayAdet + " x " + cayFiyati + " TL");
            Fatura.Items.Add("--------------------------------");
            Fatura.Items.Add("Toplam Tutar: " + toplamTutar + " TL");

            KaydetVeritabanina(musteriAdi, tKAdet, fKAdet, cayAdet, toplamTutar);
        }

        private void KaydetVeritabanina(string musteriAdi, int tkAdet, int fkAdet, int cayAdet, double toplamTutar)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Satislar (MusteriAdi, TurkKahvesiAdet, FiltreKahveAdet, CayAdet, ToplamTutar) " +
                                   "VALUES (@MusteriAdi, @TKAdet, @FKAdet, @CayAdet, @ToplamTutar)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MusteriAdi", string.IsNullOrEmpty(musteriAdi) ? "Bilinmiyor" : musteriAdi);
                        cmd.Parameters.AddWithValue("@TKAdet", tkAdet);
                        cmd.Parameters.AddWithValue("@FKAdet", fkAdet);
                        cmd.Parameters.AddWithValue("@CayAdet", cayAdet);
                        cmd.Parameters.AddWithValue("@ToplamTutar", toplamTutar);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Satış başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

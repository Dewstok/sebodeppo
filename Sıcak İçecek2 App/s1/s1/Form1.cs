using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s1
{
    public partial class Form1 : Form
    {
        private bool siparisAliyor = false;
        private bool odemeAliyor = false;
        private bool odemeAlindi = false;
        private int toplamFiyat = 0;


        List<SiparisItem> siparisler = new List<SiparisItem>();
        public Form1()
        {
            InitializeComponent();
            caySecimComboBox.Items.Add(new Urun("Bitki Çay", 75));
            caySecimComboBox.Items.Add(new Urun("Çay", 50));
            kahveComboBox.Items.Add(new Urun("Türk Kahvesi", 100));
            kahveComboBox.Items.Add(new Urun("Filtre Kahve", 150));
            siparisAliyor = true;
            odemeAliyor = false;
            odemeAlindi = false;
            toplamFiyat = 0;
            toplam.Text = "0 TL";
            ONAY.Text = "Onay";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Urun urun = (Urun)caySecimComboBox.SelectedItem;
            String caySecimMiktar = cayMiktar.Value.ToString();
            int miktar = Convert.ToInt32(caySecimMiktar);
            if (miktar > 0) 
            {
                SiparisItem siparisItem = new SiparisItem(urun, miktar);
                siparisListe.Items.Add(siparisItem);
                toplamFiyat += siparisItem.ToplamMiktar();
                toplam.Text = toplamFiyat + " TL";
                caySecimComboBox.SelectedIndex = -1;
                cayMiktar.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urun urun = (Urun)kahveComboBox.SelectedItem;
            String miktarDeger = kahveMiktar.Value.ToString();
            int miktar = Convert.ToInt32(miktarDeger);
            if (miktar > 0)
            {
                SiparisItem siparisItem = new SiparisItem(urun, miktar);
                siparisListe.Items.Add(siparisItem);
                toplamFiyat += siparisItem.ToplamMiktar();
                toplam.Text = toplamFiyat + " TL";
                kahveComboBox.SelectedIndex = -1;
                kahveMiktar.Value = 0;
            }

        }

        private void ONAY_Click(object sender, EventArgs e)
        {
            if (siparisAliyor)
            {
                siparisAliyor = false;
                odemeAliyor = true;
                odemeAlindi = false;
                ONAY.Text = "ÖDEME AL";
                siparisListe.Enabled = false;
                caySecimComboBox.Enabled = false;
                cayMiktar.Enabled = false;
                button1.Enabled = false;
                kahveComboBox.Enabled = false;
                kahveMiktar.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("Ödeme Al");
            }
            else if (odemeAliyor)
            {
                odemeAlindi = true;
                siparisAliyor = false;
                odemeAliyor = false;
                ONAY.Text = "Yeni Sipariş";
                MessageBox.Show(toplamFiyat + " TL Ödeme Alındı");
            }
            else if (odemeAlindi)
            {
                siparisAliyor = true;
                odemeAliyor = false;
                odemeAlindi = false;
                siparisListe.Items.Clear();
                siparisListe.Enabled = true;
                caySecimComboBox.Enabled = true;
                cayMiktar.Enabled = true;
                button1.Enabled = true;
                kahveComboBox.Enabled = true;
                kahveMiktar.Enabled = true;
                button2.Enabled = true;
                toplamFiyat = 0;
                toplam.Text = "";
                ONAY.Text = "ONAY";

            }
        }
    }
    class SiparisItem
    {
        public Urun Urun
        { get; set; }
        public int Miktar
        { get; set; }

        public SiparisItem(Urun u, int m)
        {
            Urun = u;
            Miktar = m;
        }

        public int ToplamMiktar()
        {
            return Miktar * Urun.Fiyat;
        }

        public override string ToString()
        {
            return Miktar + " Adet " + Urun.Isim + ", " + ToplamMiktar() + " TL";
        }

    }
    class Urun
    {
        public string Isim
        {  get; set; }

        public int Fiyat 
        { get; set; }

        
        public Urun(string s, int f)
        {
            Isim = s;
            Fiyat = f;
        }

        public override string ToString()
        {
            return Isim;
        }
    }
}

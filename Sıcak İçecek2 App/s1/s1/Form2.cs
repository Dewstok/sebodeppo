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
    public partial class Form2 : Form
    {
        private object Urunler;
        private object ToplamTutar;
        private IEnumerable<object> urunler;
        private IEnumerable<object> fiyatlar;

        public Form2()
        {
            InitializeComponent();

            decimal toplamTutar = 0;

            foreach (var urun in urunler)
            {
                Urunler = urun;

            }

            foreach (var fiyat in fiyatlar)
            {
                toplamTutar = toplamTutar + 1;

            }
            ToplamTutar = "Toplam Tutar: " + Convert.ToString(toplamTutar) + " TL";



        }
    }
}
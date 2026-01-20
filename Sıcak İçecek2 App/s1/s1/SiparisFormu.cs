using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s1
{
    internal class SiparisFormu
    {
        private List<string> secilenUrunler;
        private List<decimal> urunFiyatlari;

        public SiparisFormu(List<string> secilenUrunler, List<decimal> urunFiyatlari)
        {
            this.secilenUrunler = secilenUrunler;
            this.urunFiyatlari = urunFiyatlari;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}

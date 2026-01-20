using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Rastgele sayı 
            Random rastgele = new Random();
            int rastgeleSayi = rastgele.Next(1, 100); // 1-20 arasında rastgele bir sayı üretiyoruz.

            // Değişkenler
            int tahmin = 0;
            int denemeSayisi = 0;

            Console.WriteLine("1-100 arasında tuttuğum sayıyı bil bakalım!");

            //doğru tahmin yapana kadar döngü devam...
            while (tahmin != rastgeleSayi)
                
                {
                Console.Write("Tahmin gir: ");
                tahmin = Convert.ToInt32(Console.ReadLine());
                denemeSayisi++;

                if (tahmin < rastgeleSayi)
                {
                    Console.WriteLine("büyük bir sayı dene!");
                }

                else if (tahmin > rastgeleSayi)
                {
                    Console.WriteLine("küçük bir sayı dene!");
                }
            }

            // Doğru tahmin
            Console.WriteLine("..................................");
            Console.WriteLine("bildin,tebrikler! " + denemeSayisi + " . sayıda doğru tahmin ettin!");
            Console.ReadLine();
        }
    }
}

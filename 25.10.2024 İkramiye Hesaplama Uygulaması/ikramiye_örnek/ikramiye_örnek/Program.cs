using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ikramiye_örnek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dogruIsim = "Şebnem";
            string dogruSifre = "1234";

            Console.Write("Kullanıcı Adı: ");
            string isim = Console.ReadLine();

            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

           
            if (isim == dogruIsim && sifre == dogruSifre)
            {
                
                Console.Write("Yaş: ");
                int yas = int.Parse(Console.ReadLine());

                Console.Write("Prim günü girin: ");
                int primGunu = int.Parse(Console.ReadLine());

                
                if (yas > 40 && primGunu > 5000)
                {
                    Console.WriteLine("Emekliliğe hak kazandınız!");

                    
                    Console.Write("Maaş girin: ");
                    double maas = double.Parse(Console.ReadLine());

                    Console.Write("Toplam çalışma yılı girin: ");
                    int calismaYili = int.Parse(Console.ReadLine());

                    
                    double ikramiye;

                    if (calismaYili > 20)
                    {
                        ikramiye = maas * calismaYili * 0.775; // %77,5 ikramiye
                    }
                    else
                    {
                        ikramiye = maas * calismaYili * 0.505; // %50,5 ikramiye
                    }

                    Console.WriteLine("Toplam İkramiye: " + ikramiye);
                }
                else
                {
                    
                    int eksikGun = 5000 - primGunu;

                    Console.WriteLine("Emeklilik için " + eksikGun + " gün gerekli!");

                    

                    Console.Write("Prim borcu ödemek istiyor musunuz? (Evet/Hayır): ");
                    string odeme = Console.ReadLine();

                    bool borcOdendi = false;

                    if (odeme.ToLower() == "evet")
                    {
                        
                        double toplamOdeme = 50000;
                        double taksitTutari = toplamOdeme / 5;

                        Console.WriteLine("Toplam borç: " + toplamOdeme + " TL");
                        Console.WriteLine("Aylık taksit: " + taksitTutari + " TL (5 taksit)");

                        borcOdendi = true; 
                    }
                    else
                    {
                        Console.WriteLine("Prim borcu ödenmedi!");
                    }

                    
                    if (borcOdendi)
                    {
                        Console.WriteLine("Prim borcu ödendi, emekliliğe hak kazandınız!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Hatalı kullanıcı adı veya şifre!");
            }

            Console.ReadLine();
        }
    }
}

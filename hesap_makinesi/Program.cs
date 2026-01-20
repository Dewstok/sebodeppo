using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool devam = true;

            while (devam)
            {
                Console.Clear();
                Console.WriteLine("=== BASİT HESAP MAKİNESİ ===");
                Console.WriteLine("1 - Toplama");
                Console.WriteLine("2 - Çıkarma");
                Console.WriteLine("3 - Çarpma");
                Console.WriteLine("4 - Bölme");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                if (secim == "0")
                {
                    devam = false;
                    break;
                }

                Console.Write("1. Sayıyı girin: ");
                double sayi1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("2. Sayıyı girin: ");
                double sayi2 = Convert.ToDouble(Console.ReadLine());

                double sonuc = 0;

                switch (secim)
                {
                    case "1":
                        sonuc = Topla(sayi1, sayi2);
                        Console.WriteLine("Sonuç: " + sonuc);
                        break;

                    case "2":
                        sonuc = Cikar(sayi1, sayi2);
                        Console.WriteLine("Sonuç: " + sonuc);
                        break;

                    case "3":
                        sonuc = Carp(sayi1, sayi2);
                        Console.WriteLine("Sonuç: " + sonuc);
                        break;

                    case "4":
                        if (sayi2 == 0)
                        {
                            Console.WriteLine("Bir sayı 0'a bölünemez!");
                        }
                        else
                        {
                            sonuc = Bol(sayi1, sayi2);
                            Console.WriteLine("Sonuç: " + sonuc);
                        }
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }

                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        static double Topla(double a, double b)
        {
            return a + b;
        }

        static double Cikar(double a, double b)
        {
            return a - b;
        }

        static double Carp(double a, double b)
        {
            return a * b;
        }

        static double Bol(double a, double b)
        {
            return a / b;
        }
    }
}

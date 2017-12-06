using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pangaautomaat_ATM_
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string v;
            bool tööl = true;

            while (tööl == true)
            {
                Algus:
                DirectoryInfo dinfo = new DirectoryInfo(path);
                FileInfo[] Files = dinfo.GetFiles("*.txt");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Olemas olevad kontod on: ");
                foreach (FileInfo file in Files)
                {
                    Console.WriteLine(file.Name);
                }
                Console.WriteLine("--------------------------------");

                Console.WriteLine("Palun valige käsklus(NR.). \n1. Registreerumine\n2. Sisselogimine\n3. Programmist väljumine");
                int cmd = int.Parse(Console.ReadLine());

                var konto = new Kasutaja();

                if (cmd == 1)
                {
                    Reg:
                    Console.WriteLine("\nPalun sisestage kasutajanimi");
                    konto.Nimi = Console.ReadLine();
                    if (!File.Exists(konto.Nimi + ".txt"))
                    {
                        Console.WriteLine("Palun sisestage PIN");
                        Pin:
                        Console.WriteLine("PIN peab olema 4 numbriline");
                        konto.Pin = int.Parse(Console.ReadLine());
                        if (Math.Floor(Math.Log10(konto.Pin) + 1) != 4) goto Pin;
                        else
                        {
                            File.WriteAllText(konto.Nimi + ".txt", konto.Pin + "\n0");
                            Console.WriteLine("Kasutaja on registreeritud!");
                        }                                               
                    }
                    else
                    {
                        Console.WriteLine("Sellise nimega konto on juba olemas!");
                    }
                    Console.WriteLine("Kas soovite uuesti proovida? (Y/N)");
                    v = Console.ReadLine();
                    if (v != "Y") goto Reg;

                    if (v != "N")
                    {
                        goto Algus;
                    }
                }
                if (cmd == 2)
                {
                    Console.WriteLine("\nPalun sisestage kontonimi");
                    konto.Nimi = Console.ReadLine();
                    if (File.Exists(path + konto.Nimi + ".txt"))
                    {
                        Console.WriteLine("Palun sisestage PIN");
                        konto.Pin = int.Parse(Console.ReadLine());
                        string[] Sisu = File.ReadAllLines(konto.Nimi + ".txt");
                        if (konto.Pin == int.Parse(Sisu[0]))
                        {
                            konto.Jääk = int.Parse(Sisu[1]);
                            Console.WriteLine("PIN oli õige.\nArvel on " + konto.Jääk + " eurot.");
                            Siin:
                            Console.WriteLine("\nValige vastavalt oma soovile number.\n1. Raha sisse\n2. Raha välja");
                            cmd = int.Parse(Console.ReadLine());
                            if (cmd == 1)
                            {
                                konto.RahaS();
                                Console.WriteLine("Kas te soovite jätkata? (Y/N)");
                                v = Console.ReadLine();
                                if (v == "Y")
                                {
                                    goto Siin;
                                }
                                else break;
                            }
                            else if (cmd == 2)
                            {
                                konto.RahaV();
                                Console.WriteLine("Kas te soovite jätkata? (Y/N)");
                                v = Console.ReadLine();
                                if (v == "Y")
                                {
                                    goto Siin;
                                }
                                else break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("PIN kood on vale! Palun proovige uuesti!\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nSellist kontot pole andmebaasis. Proovige uuesti\n");
                    }
                }
                if (cmd == 3)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}

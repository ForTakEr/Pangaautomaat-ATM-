using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pangaautomaat_ATM_
{
    class Kasutaja
    {
        string path = Directory.GetCurrentDirectory();

        double vRaha;
        public string Nimi { get; set; }
        public int Pin { get; set; }
        public double Jääk { get; set; }


        public void RahaS()
        {
            Console.WriteLine("Kui palju soovite raha sisse panna?");
            Jääk = int.Parse(Console.ReadLine()) + Jääk;
            File.WriteAllText(Nimi + ".txt", Pin + "\n" + Jääk);
            Console.WriteLine("Uus konto jääk on: " + Jääk);

        }


        public void RahaV()
        {
            Console.WriteLine("Kui palju soovite raha välja võtta?");
            vRaha = int.Parse(Console.ReadLine());
            if (vRaha <= Jääk)
            {
                Jääk = Jääk - vRaha;
                File.WriteAllText(Nimi + ".txt", Pin + "\n" + Jääk);
                Console.WriteLine("Uus konto jääk on: " + Jääk);
            }
            else
            {
                Console.WriteLine("Teie kontol pole nii palju raha!");
            }

        }
    }
}

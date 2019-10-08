using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestOpdracht5();
        }

        public static void TestOpdracht2()
        {
            /*var kabel = new Kabel();

            kabel.NeemLijnInGebruik(new Lijn());
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(new Lijn());
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
            kabel.VerwijderLijnVanKabel();
            Console.WriteLine(kabel);*/
        }

        public static void TestOpdracht4()
        {
            /*var kabel = new Kabel();
            var waterskibaan = new Waterskibaan(kabel);
           
            for(int i = 0; i < 10; i++)
            {    
                waterskibaan.VerplaatsKabel();
                kabel.NeemLijnInGebruik(new Lijn());
                Console.WriteLine(waterskibaan);
            }*/
            
        }

        public static void TestOpdracht5()
        {
            var sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Console.WriteLine(sporter.BehaaldePunten);
        }
    }
}

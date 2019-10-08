using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    class Waterskibaan
    {
        private Kabel kabel;
        private LijnenVoorraad voorraad;
        public Waterskibaan(Kabel kabel)
        {
            this.kabel = kabel;
            voorraad = new LijnenVoorraad();
            for (int i = 0; i < 15; i++)
            {
                voorraad.LijnToevoegenAanRij(new Lijn());
            }
        }
        // Verschuift alle lijnen op de kabel met 1 en verwijdert een lijn als die op positie 9 is
        // Daarna wordt die lijn toegevoegd aan de voorraad
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            if(kabel.VerwijderLijnVanKabel() != null)
            {
                Lijn lijn = kabel.VerwijderLijnVanKabel();
                voorraad.LijnToevoegenAanRij(lijn);
            }

        }

        public void SporterStart(Sporter sporter)
        {
            Lijn lijn = voorraad.VerwijderEersteLijn();
            lijn.sporter = sporter;
            kabel.NeemLijnInGebruik(lijn);
        
            //1 of twee rondjes bepalen
            int randomNum = MoveCollection.random.Next(0, 2);
            if (randomNum == 0)
            {
                sporter.AantalRondenNogTeGaan = 1;
            }
            else
            {
                sporter.AantalRondenNogTeGaan = 2;
            }
            Console.WriteLine($"Aantal ronden te gaan = {sporter.AantalRondenNogTeGaan}");

            if (sporter.Skies == null)
            {
                throw new Exception(string.Format("Sporter heeft geen skies."));
            }
            else if (sporter.Zwemvest == null)
            {
                throw new Exception(string.Format("Sporter heeft geen zwemvest."));
            }
        }

        public override string ToString()
        {
            return voorraad.ToString() + "\n" + kabel.ToString();
        }
    }
}

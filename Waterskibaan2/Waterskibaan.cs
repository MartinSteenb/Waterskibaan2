using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Waterskibaan
    {
        public Kabel kabel;
        public LijnenVoorraad voorraad;
        public Waterskibaan(/*Kabel kabel*/)
        {
            //this.kabel = kabel;
            kabel = new Kabel();
            voorraad = new LijnenVoorraad();
            for (int i = 0; i < 15; i++)
            {
                voorraad.LijnToevoegenAanRij(new Lijn());
            }
        }
        // Verschuift alle lijnen op de kabel met 1 en verwijdert een lijn als die op positie 9 is en 
        // aantal ronder te gaan = 1
        // Daarna wordt die lijn toegevoegd aan de voorraad
        public void VerplaatsKabel()
        { 
            if(kabel._lijnen.Count > 0)
            {
                foreach (Lijn lijn in kabel._lijnen)
                {
                    if(MoveCollection.random.Next(0,4) == 0)
                    {
                        lijn.sporter.HuidigeMove = lijn.sporter.Moves[MoveCollection.random.Next(0, lijn.sporter.Moves.Count)];
                        Console.WriteLine($"Huidige move van sporter op positie {lijn.PositieOpDeKabel} = {lijn.sporter.HuidigeMove}");
                    }
                }
            }
            
            kabel.VerschuifLijnen();
            if(kabel.VerwijderLijnVanKabel() != null)
            {
                voorraad.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
            }
        }

        public void SporterStart(Sporter sporter)
        {
            Lijn lijn = voorraad.VerwijderEersteLijn();
            lijn.sporter = sporter;
            kabel.NeemLijnInGebruik(lijn);
            sporter.AantalRondenNogTeGaan = 1;//MoveCollection.random.Next(1, 3);

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

        public void Start()
        {
            throw new NotImplementedException();
        }
        public void Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return voorraad.ToString() + "\n" + kabel.ToString();
        }
    }
}

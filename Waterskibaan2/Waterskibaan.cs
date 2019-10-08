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

        public override string ToString()
        {
            return voorraad.ToString() + "\n" + kabel.ToString();
        }
    }
}

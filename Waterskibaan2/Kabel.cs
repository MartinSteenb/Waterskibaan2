using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Kabel
    {
        private LinkedList<Lijn> _lijnen;
        public Kabel()
        {
            _lijnen = new LinkedList<Lijn>();
        }

        public bool IsStartPositieLeeg()
        {
            if(_lijnen.Count == 0) // Als er nog geen lijnen aan de kabel gekoppeld zijn
            {
                return true;
            }
            else 
            {
                foreach (Lijn lijn in _lijnen)
                {
                    if (lijn.PositieOpDeKabel == 0)
                    {
                        Console.WriteLine("Positie 0 is al in gebruik.");
                        return false;
                    }
                }
            }
            return true;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PositieOpDeKabel = 0;
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 9)
                {
                    lijn.PositieOpDeKabel = 0;
                    lijn.sporter.AantalRondenNogTeGaan--;
                }
                else
                {
                    lijn.PositieOpDeKabel += 1;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            foreach(Lijn lijn in _lijnen)
            {
                if(lijn.PositieOpDeKabel == 9 && lijn.sporter.AantalRondenNogTeGaan == 1)
                {
                    _lijnen.Remove(lijn);
                    return lijn;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string lijnenString = "";
            foreach (Lijn lijn in _lijnen)
            {
                lijnenString += lijn.PositieOpDeKabel + "| ";
                
            }
            return lijnenString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen;
        public Kabel()
        {
            _lijnen = new LinkedList<Lijn>();
        }

        public bool IsStartPositieLeeg()
        {
            
            if(_lijnen.Count == 0) // Als er nog geen lijnen aan de kabel gekoppeld zijn
            {
                Console.WriteLine("Startpositie is leeg.");
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
            
            if (IsStartPositieLeeg() && _lijnen.Count <= 10)
            {
                Console.WriteLine("Lijn wordt in gebruik genomen");
                lijn.PositieOpDeKabel = 0;
                _lijnen.AddFirst(lijn);
            }
            Console.WriteLine($"_lijnen.count = {_lijnen.Count}");
        }

        public void VerschuifLijnen()
        {

            for (LinkedListNode<Lijn> current = _lijnen?.First; current != null; current = current.Next)
            {
                current.Value.PositieOpDeKabel++;
            }

            if (_lijnen?.Last?.Value?.PositieOpDeKabel >= 10)
            {
                Console.WriteLine("Positie op kabel groter of gelijk aan 10.");
                Lijn lijn = _lijnen.Last.Value;
                
                _lijnen.RemoveLast();
                lijn.sporter.AantalRondenNogTeGaan--;
                lijn.PositieOpDeKabel = 0;
                _lijnen.AddFirst(lijn);
            }
            
            
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn l = null;

            foreach(Lijn lijn in _lijnen)
            {
                if(lijn.PositieOpDeKabel >= 9 && lijn.sporter.AantalRondenNogTeGaan == 1)
                {
                    l = lijn;
                    _lijnen.RemoveLast();
                    Console.WriteLine("Lijn verwijdert en toegevoegd aan voorraad.");
                    Console.WriteLine();
                    return l;
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

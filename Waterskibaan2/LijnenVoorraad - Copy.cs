using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class LijnenVoorraad
    {
        public Queue<Lijn> _lijnenQueue;
        public LijnenVoorraad()
        {
            _lijnenQueue = new Queue<Lijn>();
        }

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnenQueue.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
            if (GetAantalLijnen() != 0)
            {
                return _lijnenQueue.Dequeue();
            }
            return null;
        }

        public int GetAantalLijnen()
        {
            return _lijnenQueue.Count();
        }

        public override string ToString()
        {
            return $"Aantal lijnen op voorraad: {GetAantalLijnen()}";
        }
    }
}

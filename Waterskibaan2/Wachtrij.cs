using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public abstract class Wachtrij
    {
        public abstract int MAX_LENGTE_RIJ { get; }
        private Queue<Sporter> _sportersQueue = new Queue<Sporter>();

        public string Type
        {
            get
            {
                return _wachtrijType;
            }
        }
        protected string _wachtrijType;

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (_sportersQueue.Count < MAX_LENGTE_RIJ)
            {
                _sportersQueue.Enqueue(sporter);
            }
        }

        public List<Sporter> GetAlleSporters()
        {
            return _sportersQueue.ToList();
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> sporters = new List<Sporter>();
            while (aantal > 0 && _sportersQueue.Count > 0)
            {
                sporters.Add(_sportersQueue.Dequeue());
                aantal--;
            }

            return sporters;
        }

        public override string ToString()
        {
            return $"{_sportersQueue.Count} sporters in de {_wachtrijType.ToLower()}";
        }
    }
}

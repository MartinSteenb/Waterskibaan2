using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; } = 0;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int BehaaldePunten { get; set; }

        public Sporter(List<IMoves> moves)
        {
            foreach(IMoves move in moves)
            {
                BehaaldePunten += move.Move();
            }
        }

    }
}

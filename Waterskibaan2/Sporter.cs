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
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Moves = moves;
            foreach(IMoves move in moves)
            {
                BehaaldePunten += move.Move();
            }

            int randomNum = MoveCollection.random.Next(0, 3);
            if (randomNum == 0)
            {
                KledingKleur = Color.FromArgb(0, 255, 255, 255);
            }
            else if (randomNum == 1)
            {
                KledingKleur = Color.FromArgb(0, 0, 255, 255);
            }
            else
            {
                KledingKleur = Color.FromArgb(0, 0, 0, 255);
            }
        }

    }
}

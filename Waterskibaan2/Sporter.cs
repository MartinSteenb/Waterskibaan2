using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Waterskibaan2
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; } = 0;
        public int AantalRondenGeskied { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public System.Windows.Media.Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; } 
        public int BehaaldePunten { get; set; }
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            Moves = moves;
            

            int randomNum = MoveCollection.random.Next(0, 3);
            if (randomNum == 0)
            {
                KledingKleur = Colors.White;
            }
            else if (randomNum == 1)
            {
                KledingKleur = Colors.Red;
            }
            else
            {
                KledingKleur = Colors.Blue;
            }
        }

    }
}

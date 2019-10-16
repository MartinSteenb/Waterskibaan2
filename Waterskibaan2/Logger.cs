using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Waterskibaan2
{
    public class Logger
    {
        private Kabel kabel;
        public List<Sporter> Bezoekers { get; } = new List<Sporter>();

        public Logger(Kabel kabel)
        {
            this.kabel = kabel;
        }
        public void voegBezoekerToe(Sporter sporter)
        {
            Bezoekers.Add(sporter);
        }

        public int totaalAantalBezoekers()
        {
            var totaal = (from bezoeker in Bezoekers select bezoeker).Count();
            return totaal;
        }

        public int hoogsteScore()
        {
            var score = (from bezoeker in Bezoekers select bezoeker.BehaaldePunten).Max();
            return score;
        }

        public int hoeveelheidBezoekersMetRodeKleding()
        {
            var bezoekesrMetRood = (from bezoeker in Bezoekers where ColorsAreClose(Colors.Red, bezoeker.KledingKleur) == true select bezoeker).Count();
            return bezoekesrMetRood;
        }

        private bool ColorsAreClose(Color a, Color z, int threshold = 50)
        {
            int r = a.R - z.R;
            int g = a.G - z.G;
            int b = a.B - z.B;
            return (r * r + g * g + b * b) < threshold * threshold;
        }

        public string lijstGesorteerdOpKledingMetLichtsteKleur()
        {
            List<Sporter> list = Bezoekers.OrderByDescending(bezoeker => getLichtheid(bezoeker.KledingKleur)).Take(10).ToList();
            string joined = string.Join(", \n", list.Select(z => stringToUpper($"{z.KledingKleur}")));
            return joined;
        }

        public string stringToUpper(string arg)
        {
            return arg.ToUpper();
        }

        private int getLichtheid(Color color)
        {
            int lichtHeid = color.R * color.R +
                            color.G * color.G +
                            color.B * color.B;
            return lichtHeid;
        }
        public int totaalAantalRondjes()
        {
            var totaal = (from bezoeker in Bezoekers select bezoeker.AantalRondenGeskied).Sum();
            return totaal;
        }

        public string uniekeMovesVanBezoekersAanLijn()
        {
            List<IMoves> uniekeMoves = new List<IMoves>();

            kabel._lijnen.ToList().ForEach(lijn => lijn.sporter.Moves.ForEach(move =>
            {
                bool uniek = true;
                foreach (var item in uniekeMoves)
                {
                    if (item.GetType().Equals(move.GetType()))
                    {
                        uniek = false;
                    }
                }
                if (uniek)
                {
                    uniekeMoves.Add(move);
                }
            }));

            string joined = string.Join(", ", uniekeMoves.Select(z => z.ToString()));
            return joined;
        }
    }
}

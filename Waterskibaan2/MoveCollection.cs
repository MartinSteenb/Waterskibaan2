using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public static class MoveCollection
    {
        private static List<IMoves> randomMoves = new List<IMoves>();
        private static Random random = new Random();

        public static List<IMoves> GetWillekeurigeMoves()
        {
            int randomNum = random.Next(0, 2);

            if (randomNum == 0)
            {
                randomMoves.Add(new Springen(random));
                Console.WriteLine("JUMP");
            }
            else
            {
                randomMoves.Add(new Springen(random));
                randomMoves.Add(new Draaien(random));
                Console.WriteLine("JUMP + TURN");
            }
            return randomMoves;
        }
    }
}

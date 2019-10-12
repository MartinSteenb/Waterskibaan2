using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public static class MoveCollection
    {
        private static List<IMoves> randomMoves;
        public static Random random = new Random();

        public static List<IMoves> GetWillekeurigeMoves()
        {
            randomMoves = new List<IMoves>();
            int randomNum = random.Next(0, 2);

            if (randomNum == 0)
            {
                randomMoves.Add(new Springen());
                //Console.WriteLine("JUMP");
            }
            else
            {
                randomMoves.Add(new Springen());
                randomMoves.Add(new Draaien());
                //Console.WriteLine("JUMP + TURN");
            }
            return randomMoves;
        }
    }
}

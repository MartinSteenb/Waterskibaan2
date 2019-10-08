using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Springen : IMoves
    {
        private int punten;
        private Random random;
        public Springen(Random random)
        {
            this.random = random;
        }
        public int Move()
        {
            
            int randomNum = random.Next(4, 6);
          
            if (randomNum == 4)
            {
                punten = 0;
                Console.WriteLine("Springen mislukt.");
            }
            else
            {
                punten = 5;
                Console.WriteLine("Springen gelukt.");
            }
            return punten;
        }
    }
}

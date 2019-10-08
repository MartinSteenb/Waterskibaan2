using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Draaien : IMoves
    {
        private int punten;
        private Random random;
        public Draaien(Random random)
        {
            this.random = random;
        }

        public int Move()
        {
            
            int randomNum = random.Next(6, 8);
           
            if (randomNum == 6)
            {
                punten = 0;
                Console.WriteLine("Draaien mislukt.");
            }
            else
            {
                punten = 10;
                Console.WriteLine("Draaien gelukt.");
            }
            return punten;
        }
    }
}

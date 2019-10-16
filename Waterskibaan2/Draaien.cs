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
        public int Move()
        {
            
            int randomNum = MoveCollection.random.Next(0, 2);
           
            if (randomNum == 0)
            {
                punten = 0;
                //Console.WriteLine("Draaien mislukt.");
            }
            else
            {
                punten = 10;
                //Console.WriteLine("Draaien gelukt.");
            }
            return punten;
        }

        public override string ToString()
        {
            return "Draaien";
        }
    }
}

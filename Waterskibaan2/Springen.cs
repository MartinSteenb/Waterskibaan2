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
        
        public int Move()
        {
            
            int randomNum = MoveCollection.random.Next(0, 2);
          
            if (randomNum == 0)
            {
                punten = 0;
                //Console.WriteLine("Springen mislukt.");
            }
            else
            {
                punten = 5;
                //Console.WriteLine("Springen gelukt.");
            }
            return punten;
        }
    }
}

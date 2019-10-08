using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class Lijn
    {
        public int PositieOpDeKabel { get; set; }
        Sporter sporter;
        public Lijn(Sporter sporter)
        {
            this.sporter = sporter;
        }
    }
}

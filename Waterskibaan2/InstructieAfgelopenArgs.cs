using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> Sporters { get; }
        public InstructieAfgelopenArgs(List<Sporter> sporters)
        {
            Sporters = sporters;
        }
    }
}

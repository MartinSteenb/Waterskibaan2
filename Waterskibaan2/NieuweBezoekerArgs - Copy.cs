using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class NieuweBezoekerArgs
    {
        public Sporter Sporter { get; }
        public NieuweBezoekerArgs(Sporter sporter)
        {
            Sporter = sporter;
        }
    }
}

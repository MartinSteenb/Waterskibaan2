using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class WachtrijStarten : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 20; } }

        public WachtrijStarten()
        {
            _wachtrijType = "Wachtrij voor starten";
        }
    }
}

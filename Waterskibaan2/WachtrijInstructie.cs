﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan2
{
    public class WachtrijInstructie : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 100; } }

        public WachtrijInstructie()
        {
            _wachtrijType = "Wachtrij instructie";
        }
    }
}

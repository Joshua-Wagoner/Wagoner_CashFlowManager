using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    interface IPayable
    {
        decimal GetPayableAmount();
        LedgerType Type { get; }
    }
}

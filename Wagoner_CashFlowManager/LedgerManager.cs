using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    class LedgerManager
    {
        private IPayable[] ledgers = new IPayable[50];

        private static LedgerManager ledgerManager = new LedgerManager();
        private int index;

        private LedgerManager() {}

        public static LedgerManager GetInstance()
        {
            return ledgerManager;
        }

        public void AddLedger(IPayable ledger)
        {
            ledgers[index] = ledger;
            index++;
            Console.WriteLine(ledger.Type);
        }

        public string GetLedgersReport()
        {
            return string.Format("Weekly Cash Flow Analysis is as follows: "
                + "\n\n" + ListItems()
                + "\nTotal Weekly Payout ${0:.00}"
                + "\nCategory Breakdown: "
                + "\n  Invoices ${1:.00}"
                + "\n  Salaried Payroll ${2:.00}"
                + "\n  Hourly Payroll ${3:.00}\n", 
                GetTotalPayout(), 
                GetTypePayout(LedgerType.Invoice), 
                GetTypePayout(LedgerType.Salaried), 
                GetTypePayout(LedgerType.Hourly));
        }

        private string ListItems()
        {
            string s = string.Empty;

            foreach (IPayable ledger in ledgers)
                if(ledger != null)
                    s += ledger.ToString() + "\n";
            return s;
        }

        private decimal GetTotalPayout()
        {
            decimal d = 0;

            foreach (IPayable ledger in ledgers)
                if (ledger != null)
                    d += ledger.GetPayableAmount();
            return d;
        }

        private decimal GetTypePayout(LedgerType Type)
        {
            decimal d = 0;

            IPayable temp;

            foreach (IPayable payable in ledgers)
                if (payable != null)
                {
                    temp = payable;
                    if (temp.Type == Type)
                        d += temp.GetPayableAmount();
                }

            return d;
        }
    }
}

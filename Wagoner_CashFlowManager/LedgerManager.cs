using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    class LedgerManager
    {
        private List<IPayable> ledgers;

        public LedgerManager(List<IPayable> ledgers) { this.ledgers = ledgers; }

        public void AddLedger(IPayable ledger)
        {
            ledgers.Add(ledger);
        }

        public string GetLedgersReport()
        {
            return GetTotalLedgerReport();
        }

        private string GetTotalLedgerReport()
        {
            return string.Format("Weekly Cash Flow Analysis as follows:"
                + "\n\n" + ListItems()
                + "\nTotal Weekly Payout: ${0:.00}"
                + "\nCategory Breakdown:"
                + "\n  Invoices: ${1:.00}"
                + "\n  Salaried Payroll: ${2:.00}"
                + "\n  Hourly Payroll: ${3:.00}\n",
                GetTotalPayout(),
                GetTotalTypePayout(LedgerType.Invoice),
                GetTotalTypePayout(LedgerType.Salaried),
                GetTotalTypePayout(LedgerType.Hourly));
        }

        private string ListItems()
        {
            string s = string.Empty;

            foreach (IPayable ledger in ledgers)
                s += ledger.ToString() + "\n";
            return s;
        }

        private decimal GetTotalPayout()
        {
            decimal d = 0;

            foreach (IPayable ledger in ledgers)
                d += ledger.GetPayableAmount();
            return d;
        }

        private decimal GetTotalTypePayout(LedgerType type)
        {
            decimal d = 0;

            foreach (IPayable ledger in ledgers)
                if (ledger.Type == type)
                    d += ledger.GetPayableAmount();
            return d;
        }

    }
}

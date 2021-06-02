using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    class Invoice : IPayable
    {
        private Random rand = new Random();

        private string partNumber;
        private string partDescription;
        private int quanity;
        private decimal price;

        public Invoice(string partNumber, string partDescription, int quanity, decimal price)
        {
            this.partNumber = partNumber;
            this.partDescription = partDescription;
            this.quanity = quanity;
            this.price = price;
        }

        public LedgerType Type { get { return LedgerType.Invoice; } }

        public decimal GetPayableAmount()
        {
            return price;
        }

        public override string ToString()
        {
            return string.Format("Invoice: " + rand.Next(99999, 1000000) + "_" + partNumber
                + "\nQuanity: " + quanity
                + "\nPart Description: " + partDescription
                + "\nUnit Price: ${0:.00}"
                + "\nExtended Price: ${1:.00}\n", price, ExtendedPrice());
        }

        private decimal ExtendedPrice()
        {
            return price * quanity;
        }
    }
}

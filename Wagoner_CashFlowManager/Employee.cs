using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    abstract class Employee : IPayable
    {
        private LedgerType ledgerType;
        private string firstName;
        private string lastName;
        private string socialSecurityNum;

        public Employee(LedgerType ledgerType, string firstName, string lastName, string socialSecurityNum)
        {
            this.ledgerType = ledgerType;
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNum = socialSecurityNum;
        }

        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string SSN { get { return socialSecurityNum; } }
        public LedgerType Type { get { return ledgerType; } }

        protected abstract decimal Earnings();

        public decimal GetPayableAmount()
        {
            return Earnings();
        }

    }
}

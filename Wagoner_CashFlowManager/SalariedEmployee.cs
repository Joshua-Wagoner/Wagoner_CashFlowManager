using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    class SalariedEmployee : Employee
    {
        private decimal salary;

        public SalariedEmployee(string firstName, string lastName, string socialSecurityNum, decimal salary) 
            : base(LedgerType.Salaried, firstName, lastName, socialSecurityNum)
        {
            this.salary = salary;
        }

        protected override decimal Earnings()
        {
            return salary;
        }

        public override string ToString()
        {
            return string.Format(Type + " Employee: " + FirstName + " " + LastName
                + "\nSSN: " + SSN
                + "\nWeekly Salary: ${0:.00}" 
                +"\nEarned: ${1:.00}\n", 
                salary, Earnings());
        }
    }
}

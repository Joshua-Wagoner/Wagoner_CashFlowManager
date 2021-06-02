using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wagoner_CashFlowManager
{
    class HourlyEmployee : Employee
    {
        private decimal hourlyWage;
        private int hoursWorked;

        public HourlyEmployee(string firstName, string lastName, string socialSecurityNum, decimal hourlyWage, int hoursWorked) 
            : base(LedgerType.Hourly, firstName, lastName, socialSecurityNum)
        {
            this.hourlyWage = hourlyWage;
            this.hoursWorked = hoursWorked;
        }

        protected override decimal Earnings()
        {
            return hoursWorked > 40 ? ((hoursWorked - (hoursWorked - 40)) * hourlyWage) + ((hoursWorked - 40) * (1.5M * hourlyWage)) : 
                hoursWorked * hourlyWage;
        }

        public override string ToString()
        {
            return string.Format(Type + " Employee: " + FirstName + " " + LastName
              + "\nSSN: " + SSN
              + "\nHourly Wage: ${0:.00}" 
              + "\nHours worked: " + hoursWorked 
              + "\nEarned: ${1:.00}\n",
                hourlyWage, Earnings());
        }
    }
}

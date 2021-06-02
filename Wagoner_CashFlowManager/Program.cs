using System;
using System.Collections.Generic;

namespace Wagoner_CashFlowManager
{
    class Program
    {
        private static List<IPayable> payables = new List<IPayable>();

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;
            
            payables.Add(new HourlyEmployee("Larry", "Willy", "111-11-1111", 10.02M, 40));
            payables.Add(new HourlyEmployee("Shelly", "Butter", "222-22-2222", .30M, 48));
            payables.Add(new HourlyEmployee("Bob", "Dick", "333-33-3333", 1.45M, 43));

            payables.Add(new SalariedEmployee("Robbie", "Nell", "444-44-4444", 1234.56M));
            payables.Add(new SalariedEmployee("Bell", "Ring", "555-55-5555", 5432.10M));
            payables.Add(new SalariedEmployee("Ding", "Dong", "666-66-6666", 6565.54M));

            payables.Add(new Invoice("2534", "Jingle Bells", 2, 1.00M));
            payables.Add(new Invoice("3521", "Sugar Cakes", 5, 2.00M));
            payables.Add(new Invoice("3321", "Lemon Pies", 1, 20.00M));

            bool optOut = false;

            while (!optOut)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Get Payroll Report"
                    +"\n2. Add a new Invoice"
                    +"\n3. Add a new Hourly Employee"
                    +"\n4. Add a new Salaried Employee"
                    +"\n5. Exit");

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine(GetPayrollReport());
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                }
                else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    string a, b;
                    int q;
                    decimal p;
                    Console.Clear();
                    Console.WriteLine("Enter the PartNumber: ");
                    a = Console.ReadLine();
                    Console.WriteLine("Enter the Part Description: ");
                    b = Console.ReadLine();
                    Console.WriteLine("Enter the Quanity: ");
                    q = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Price: ");
                    p = decimal.Parse(Console.ReadLine());

                    payables.Add(new Invoice(a, b, q, p));
                }
                else if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    string a, b, c;
                    decimal w;
                    int h;
                    Console.Clear();
                    Console.WriteLine("Enter the First Name: ");
                    a = Console.ReadLine();
                    Console.WriteLine("Enter the Last Name: ");
                    b = Console.ReadLine();
                    Console.WriteLine("Enter the SSN: ");
                    c = Console.ReadLine();
                    Console.WriteLine("Enter the Hourly Wage: ");
                    w = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Hours Worked: ");
                    h = int.Parse(Console.ReadLine());

                    payables.Add(new HourlyEmployee(a, b, c, w, h));
                }
                else if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad4)
                {
                    string a, b, c;
                    decimal s;
                    Console.Clear();
                    Console.WriteLine("Enter the First Name: ");
                    a = Console.ReadLine();
                    Console.WriteLine("Enter the Last Name: ");
                    b = Console.ReadLine();
                    Console.WriteLine("Enter the SSN: ");
                    c = Console.ReadLine();
                    Console.WriteLine("Enter the Weekly Salary: ");
                    s = decimal.Parse(Console.ReadLine());

                    payables.Add(new SalariedEmployee(a, b, c, s));
                }
                else if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad5)
                {
                    optOut = true;
                }
            }
        }

        private static string GetPayrollReport()
        {
            return GetTotalLedgerReport();
        }

        private static string GetTotalLedgerReport()
        {
            return string.Format("Weekly Cash Flow Analysis as follows:"
                + "\n\n"+ ListItems()
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

        private static string ListItems()
        {
            string s = string.Empty;

            foreach (IPayable payable in payables)
                s += payable.ToString() + "\n";
            return s;
        }

        private static decimal GetTotalPayout()
        {
            decimal d = 0;

            foreach (IPayable payable in payables)
                d += payable.GetPayableAmount();
            return d;
        }

        private static decimal GetTotalTypePayout(LedgerType type)
        {
            decimal d = 0;

            foreach (IPayable payable in payables)
                if (payable.Type == type)
                    d += payable.GetPayableAmount();
            return d;
        }
    }
}

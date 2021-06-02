using System;
using System.Collections.Generic;

namespace Wagoner_CashFlowManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPayable> payables = new List<IPayable>();

            payables.Add(new HourlyEmployee("Larry", "Willy", "111-11-1111", 10.02M, 40));
            payables.Add(new HourlyEmployee("Shelly", "Butter", "222-22-2222", .30M, 48));
            payables.Add(new HourlyEmployee("Bob", "Dick", "333-33-3333", 1.45M, 43));

            payables.Add(new SalariedEmployee("Robbie", "Nell", "444-44-4444", 1234.56M));
            payables.Add(new SalariedEmployee("Bell", "Ring", "555-55-5555", 5432.10M));
            payables.Add(new SalariedEmployee("Ding", "Dong", "666-66-6666", 6565.54M));

            payables.Add(new Invoice("2534", "Jingle Bells", 2, 1.00M));
            payables.Add(new Invoice("3521", "Sugar Cakes", 5, 2.00M));
            payables.Add(new Invoice("3321", "Lemon Pies", 1, 20.00M));

            //foreach(IPayable payable in payables)
            //    Console.WriteLine(payable.ToString()+"\n");

            bool optOut = false;

            while(!optOut)
            {
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private string TotalLedgerReport()
        {
            return string.Empty;
        }
    }
}

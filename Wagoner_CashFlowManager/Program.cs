using System;
using System.Collections.Generic;
/*
 * Joshua Wagoner
 * IT112
 * NOTES: This was definitely a challenging assignment; required me to think outside
 * of the box, and come up with ways that made it so no classes used
 * outside resources without explicitly using them. I used a manager class for all the 
 * ledger operations, so nothing would be done in the main class that had to do with calculations
 * and returning the ledger report; thus, it is also the class that manages all the items/ledgers.
 * I hope I did it right, and I gave it my very best shot. I guess I'll learn something new if I
 * did something wrong.
 * BEHAVIOURS NOT IMPLEMENTED AND WHY: I believe all parts of this assignment are completed in full!
 * 
 */
namespace Wagoner_CashFlowManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;

            LedgerManager manager = LedgerManager.GetInstance();

            Random rand = new Random();

            manager.AddLedger(new HourlyEmployee("Larry", "Willy", "111-11-1111", 10.02M, 40));
            manager.AddLedger(new HourlyEmployee("Shelly", "Butter", "222-22-2222", .30M, 48));
            manager.AddLedger(new HourlyEmployee("Bob", "Dick", "333-33-3333", 1.45M, 43));

            manager.AddLedger(new SalariedEmployee("Robbie", "Nell", "444-44-4444", 1234.56M));
            manager.AddLedger(new SalariedEmployee("Bell", "Ring", "555-55-5555", 5432.10M));
            manager.AddLedger(new SalariedEmployee("Ding", "Dong", "666-66-6666", 6565.54M));

            manager.AddLedger(new Invoice(rand.Next(99999, 1000000) + "_" + "2534", "Jingle Bells", 2, 1.00M));
            manager.AddLedger(new Invoice(rand.Next(99999, 1000000) + "_" + "3521", "Sugar Cakes", 5, 2.00M));
            manager.AddLedger(new Invoice(rand.Next(99999, 1000000) + "_" + "3321", "Lemon Pies", 1, 20.00M));

            bool optOut = false;

            while (!optOut)
            {
                Console.Clear();
                Console.WriteLine(
                    "1. Get Payroll Report"
                    + "\n2. Add a new Invoice"
                    + "\n3. Add a new Hourly Employee"
                    + "\n4. Add a new Salaried Employee"
                    + "\n5. Exit");

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine(manager.GetLedgersReport());
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

                    manager.AddLedger(new Invoice(rand.Next(99999, 1000000) + "_" + a, b, q, p));
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

                    manager.AddLedger(new HourlyEmployee(a, b, c, w, h));
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

                    manager.AddLedger(new SalariedEmployee(a, b, c, s));
                }
                else if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad5)
                {
                    optOut = true;
                }
            }
        }
    }
}

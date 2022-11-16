using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PersonalFinanceAdvisor
{
    class PFA
    {
        static int input()
        {
            Console.WriteLine("Enter your balance: ");
            int money = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your account balance: " + money);

            return money;
        }

        static void Sum(int dola)
        {
            double necessities = dola * 0.55;
            Console.WriteLine("Necessities: " + necessities);

            double longterm = dola * 0.1;
            Console.WriteLine("Long term: " + longterm);

            double entertainment = dola * 0.1;
            Console.WriteLine("Entertainment: " + entertainment);

            double education = dola * 0.1;
            Console.WriteLine("Education: " + education);

            double financial = dola * 0.1;
            Console.WriteLine("Financial: " + financial);

            double give = dola * 0.05;
            Console.WriteLine("Give: " + give);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AUT BANK");
            Sum(input());
        }
    }
}
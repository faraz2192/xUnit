using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCalculator objForCalculator = new MyCalculator();
            int ans = objForCalculator.Add(3, 7);
            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}

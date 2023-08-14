using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mean_Median_Mode
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = { 12, 23, 34, 45, 12, 13, 13, 35 };

            double Mean = numbers.Average();

            numbers = (from n in numbers
                      orderby n
                      select n).ToArray();

            int Median;

            if (numbers.Count() % 2 == 0)
            {
                 Median = (numbers[(numbers.Count() / 2)]+ numbers[(numbers.Count() / 2) + 1])/2;
            }
            else
            {
                 Median = numbers[((numbers.Count() + 1) / 2)];
            }

            IEnumerable<(int I, int N)> temp = (from n in numbers
                        select (n,( numbers.Count(nu => nu == n))));

            int max = (from n in temp
                      select n.N).Max();


            int[] Mode = (from t in temp
                         where t.N == max
                         select t.I).Distinct().ToArray();

            Console.WriteLine("Mean :- " + Mean);
            Console.WriteLine("Median :- " + Median);
            foreach(var m in Mode)
            Console.WriteLine("Mode :- " + m);

            Console.ReadKey();
        }
    }
}

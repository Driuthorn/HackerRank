using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusMinus
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            PlusMinus(arr);
        }

        public static void PlusMinus(List<int> arr)
        {
            var listSize = arr.Count();

            var positiveNumbersCount = arr.Where(x => x > 0).Count();
            var negativeNumbersCount = arr.Where(x => x < 0).Count();
            var zeroCount = arr.Where(x => x == 0).Count();

            var positiveProportion = Divide(positiveNumbersCount, listSize);
            var negativeProportion = Divide(negativeNumbersCount, listSize);
            var zeroProportion = Divide(zeroCount, listSize);

            Console.WriteLine($"{positiveProportion:N6}");
            Console.WriteLine($"{negativeProportion:N6}");
            Console.WriteLine($"{zeroProportion:N6}");
        }

        private static float Divide(int a, int b)
        {
            return (float)a / b;
        }
    }
}

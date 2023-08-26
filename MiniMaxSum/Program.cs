using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaxSum
{
    class Program
    {
        private static int maximumLength = 4;
        private static List<int> lowestValues = new List<int>();
        private static List<int> highestValues = new List<int>();
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            MiniMaxSum(arr);
        }

        public static void MiniMaxSum(List<int> arr)
        {
            foreach(var value in arr)
            {
                HandleHighestList(value);
                HandleMinimumList(value);
            }

            var highestValue = Sum(highestValues);
            var lowestValue = Sum(lowestValues);

            Console.WriteLine($"{lowestValue} {highestValue}");
        }

        private static long Sum(List<int> arr)
        {
            long sum = 0;

            foreach(var value in arr)
            {
                sum += value;
            }

            return sum;
        }

        private static void HandleMinimumList(int value)
        {
            if (lowestValues.Count == maximumLength)
            {
                if (lowestValues.Any(x => x > value))
                {
                    HandleLowerListValueExchange(value);
                }
            }
            else
            {
                lowestValues.Add(value);
            }
        }

        private static void HandleHighestList(int value)
        {
            if (highestValues.Count == maximumLength)
            {
                if (highestValues.Any(x => x < value))
                {
                    HandleHigherListValueExchange(value);
                }
            }
            else
            {
                highestValues.Add(value);
            }
        }

        private static void HandleLowerListValueExchange(int value)
        {
            foreach(var val in lowestValues)
            {
                if (val > value)
                {
                    var index = lowestValues.IndexOf(val);
                    lowestValues.RemoveAt(index);
                    lowestValues.Add(value);

                    if (lowestValues.Any(x => x < val))
                        HandleLowerListValueExchange(val);
                    break;
                }
            }
        }

        private static void HandleHigherListValueExchange(int value)
        {
            foreach (var val in highestValues)
            {
                if (val < value)
                {
                    var index = highestValues.IndexOf(val);
                    highestValues.RemoveAt(index);
                    highestValues.Add(value);

                    if (highestValues.Any(x => x < val))
                        HandleHigherListValueExchange(val);
                    break;
                }
            }
        }
    }
}

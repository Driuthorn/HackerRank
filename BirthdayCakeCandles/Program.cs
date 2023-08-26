using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BirthdayCakeCandles
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int candlesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> candles = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

            int result = BirthdayCakeCandles(candles);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        public static int BirthdayCakeCandles(List<int> candles)
        {
            var highestValues = 0;

            foreach(var candle in candles)
            {
                if (candle > highestValues)
                    highestValues = candle;
            }

            return candles.Where(x => x == highestValues).Count();
        }
    }
}

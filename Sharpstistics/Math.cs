using System.Collections.Generic;
using System.Linq;

namespace Sharpstistics
{
    public class Math
    {
        public static double Average(IEnumerable<double> numbers)
        {
            return numbers.Average();
        }

        public static double StandardDeviation(IEnumerable<double> numbers)
        {
            numbers = numbers as IList<double> ?? numbers.ToList();
            int count = numbers.Count();
            double average = Average(numbers);

            numbers = numbers.Select(number => System.Math.Pow(number - average, 2)).ToList();
            return System.Math.Sqrt(numbers.Sum() / (count * 1.0));
        }

        public static double StandardDeviation(double[] numbers)
        {
            return StandardDeviation(numbers.ToList());
        }

        public static double ConfidenceInterval(double[] numbers, double studentValue)
        {
            Endpoints endpoints = ConfidenceIntervalEndpoints(numbers, studentValue);
            double interval = endpoints.Right - endpoints.Left;
            return 100.0 * (interval / Average(numbers));
        }

        public static Endpoints ConfidenceIntervalEndpoints(double[] numbers, double studentValue)
        {
            int count = numbers.Count();
            double left = Average(numbers) - studentValue * (StandardDeviation(numbers) / System.Math.Sqrt(count));
            double right = Average(numbers) + studentValue * (StandardDeviation(numbers) / System.Math.Sqrt(count));
            return new Endpoints
            {
                Left = left,
                Right = right
            };
        }
    }
}

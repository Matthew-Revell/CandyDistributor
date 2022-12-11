using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyDistributor
{
    internal static class Program
    {
        private static void Main()
        {
            int[] ratings = { 1, 2, 2 };
            Console.WriteLine($"Minimum number of candies needed: {Candy(ratings)}");
        }

        private static int Candy(IReadOnlyList<int> ratings)
        {
            var n = ratings.Count;
            var candies = Enumerable.Repeat(1, n).ToArray();
            for (var i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
            }

            for (var i = n - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1] && candies[i] <= candies[i + 1])
                {
                    candies[i] = candies[i + 1] + 1;
                }
            }

            return candies.Sum();
        }
    }
}
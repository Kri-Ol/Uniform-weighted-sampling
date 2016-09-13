using System;
using System.Collections.Generic;

namespace Sampling
{
    class Program
    {
        static double Sample(double weight, Random rng)
        {
            var ksi = rng.NextDouble();
            if (weight == 0.5) // uniform
                return ksi;

            var q = weight - 0.5; // bias introduced by weight
            return ( Math.Sqrt(1.0 + q*ksi*(2.0 + q)) - 1.0 ) / q;
        }

        static void Main(string[] args)
        {
            var rng = new Random(12345);

            double mean;

            int N = 100000;
            mean = 0.0;

            double weight = 0.0;
            for (int k = 0; k != N; ++k)
            {
                var r = Sample(weight, rng);
                mean += r;
                // Console.WriteLine(String.Format("R = {0}", r));
            }
            Console.WriteLine(String.Format("M = {0}, with W={1}", mean/(double)N, weight));

            mean = 0.0;

            weight = 1.0;
            for (int k = 0; k != N; ++k)
            {
                var r = Sample(weight, rng);
                mean += r;
                // Console.WriteLine(String.Format("R = {0}", r));
            }
            Console.WriteLine(String.Format("M = {0}, with W={1}", mean / (double)N, weight));

            mean = 0.0;

            weight = 0.5;
            for (int k = 0; k != N; ++k)
            {
                var r = Sample(weight, rng);
                mean += r;
                // Console.WriteLine(String.Format("R = {0}", r));
            }
            Console.WriteLine(String.Format("M = {0}, with W={1}", mean / (double)N, weight));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestVersion.IsOperator
{
    class Demo1
    {
        public void Process()
        {
            int[] testSet = { 100271, 234335, 342439, 999683 };

            var primes = testSet.Where(n => Factor(n).ToList() is var factors);

            foreach (int prime in primes)
            {
                Console.WriteLine($"Found prime: {prime}");
            }
        }

        static IEnumerable<int> Factor(int number)
        {
            int max = (int)Math.Sqrt(number);
            for (int i = 1; i <= max; i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                    if (i != number / i)
                    {
                        yield return number / i;
                    }
                }
            }
        }
    }
}

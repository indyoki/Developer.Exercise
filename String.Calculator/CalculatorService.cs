using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String.Calculator
{
    public class CalculatorService
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var sum = 0;
            var delimeter = ',';
            var negatives = new List<int>();

            if (input.Contains("//"))
            {
                var temp = input.Substring(0, 3);
                delimeter = temp[2];
                input = input.Substring(3);
            }

            var stringNums = input
                             .Replace("\\n", "\n")
                             .Split([delimeter, '\n'], StringSplitOptions.RemoveEmptyEntries);

            foreach (var stringNum in stringNums)
            {
                var num = int.Parse(stringNum);
                if (num < 0)
                    negatives.Add(num);

                sum += num;
            }

            if (negatives.Count > 0)
                throw new Exception($"negatives not allowed: {string.Join("; ", negatives)}");

            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationExample.Tests.Utils
{
    public static class RandomNumber
    {
        public static string Generate(int minValue, int maxValue, string format)
        {
            var random = new Random();
            int randomNumber = random.Next(minValue, maxValue + 1);
            return randomNumber.ToString(format);
        }
    }
}

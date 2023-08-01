using System;
using System.Collections.Generic;
using System.Linq;

/*
*                                  CodeKata Number 8
*                           Numbers in a Fibonacci sequence
* 
* Create a method which takes an int[] array and returns a Dictionary<int, bool> 
* where the Key in the Dictionary is the number from the array, and the Value is a 
* boolean stating (true or false) whether or not it is in the Fibonacci sequence
* 
* If you have not already, attempt to write the method, which returns the dictionary 
* of numbers as the key and the value as true or false if it's a fibonacci number, in one line
*/
namespace CodeKata.Asos
{
    public class CodeKata_8
    {
        public static Dictionary<int, bool> FibonacciSequence(int[] num)
        {
            var list = new Dictionary<int, bool>();

            foreach (var i in num)
            {
                list.TryAdd(i, IsAFibonnaciNumber(i));
            }

            return list;
        }

        public static bool IsAFibonnaciNumber(int num)
        {
            bool result = false;
            double fibonacciEquation1 = 5 * Math.Pow(num, 2) + 4;
            int sqrtOfEquation1 = (int)Math.Sqrt(fibonacciEquation1);
            double fibonacciEquation2 = 5 * Math.Pow(num, 2) - 4;
            int sqrtOfEquation2 = (int)Math.Sqrt(fibonacciEquation2);

            if (fibonacciEquation1 % sqrtOfEquation1 == 0 || fibonacciEquation2 % sqrtOfEquation2 == 0)
                result = true;
            if (num < 0) result = false;

            return result;
        }

        public static bool IsInTheFibonacciSequence2(int num)
        {
            List<int> fibonacciNumber = new List<int> { 0, 1 };
            bool result = false;
            int listLength = 2;

            for (int i = 0; i < num; i++)
            {
                fibonacciNumber.Add(fibonacciNumber[listLength - 1] + fibonacciNumber[listLength - 2]);
                listLength++;
            }

            if (fibonacciNumber.Contains(num))
                result = true;

            return result;
        }

        public static bool IsInTheFibonacciSequence(int num)
        {
            List<int> fibonacciNumber = new List<int> { 0, 1 };
            bool result = false;

            for (int i = 0; i < num; i++)
            {
                fibonacciNumber.Add(fibonacciNumber[fibonacciNumber.Count() - 1] + fibonacciNumber[fibonacciNumber.Count() - 2]);
            }

            if (fibonacciNumber.Contains(num))
                result = true;

            return result;
        }

        public static Dictionary<int, bool> FibDict(int[] num)
        {
            return num.ToList().Select(x => new KeyValuePair<int, bool>(x, ((5 * Math.Pow(x, 2) + 4) % (int)Math.Sqrt(5 * Math.Pow(x, 2) + 4) == 0 || (5 * Math.Pow(x, 2) - 4) % (int)Math.Sqrt(5 * Math.Pow(x, 2) - 4) == 0) && (x >= 0) ? true : false)).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
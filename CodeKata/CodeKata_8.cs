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
*/
namespace CodeKata
{
    public class CodeKata_8
    {
        public static Dictionary<int, bool> FibonacciSequence(int[] num)
        {
            var list = new Dictionary<int, bool>();

            foreach (var i in num)
            {
                list.Add(i, IsInTheFibonacciSequence(i));
            }

            return list;
        }

        public static bool IsInTheFibonacciSequence(int num)
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
    }
}
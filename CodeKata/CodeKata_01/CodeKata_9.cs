using System;
using System.Collections.Generic;
using System.Linq;
/*
*                                  CodeKata Number 9
*                     Sum of all numbers in a Fibonacci sequence
* 
* Create a method which returns the sum of fibonacci numbers up to the nth fibonacci number.
* As this should be quite straightforward, I want it to be written in one line also.
*/
namespace CodeKata
{
    public class CodeKata_9
    {
        public static ulong ReturnSumFiboList(int limit)
        {
            return (ulong)Enumerable.Range(0, limit).Sum(x => (1 / Math.Sqrt(5)) * 
            (Math.Pow((1 + Math.Sqrt(5)) / 2, x) - Math.Pow((1 - Math.Sqrt(5)) / 2, x)));
        }
    }
}
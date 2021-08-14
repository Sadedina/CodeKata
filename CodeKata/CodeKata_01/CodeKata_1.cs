using System;
using System.Collections.Generic;
using System.Linq;
/*
*                                  CodeKata Number 1
*                    Convert number to reversed array of digits
*                     
* Given a random non-negative number, you have to return the digits of this number within an array in reverse order.
* 
* Example:
* 348597 => [7,9,5,8,4,3]
* 
* Link: www.codewars.com/kata/5583090cbe83f4fd8c000051/train/csharp
* */
namespace CodeKata
{
    public class CodeKata_1
    {
        public static long[] Digitize(long n)
        {
            string numb = Convert.ToString(n);
            int counter = numb.Length;
            long[] newArr = new long[counter];
            for (int i = 0; i < counter; i++)
            {
                newArr[i] = (long)(numb[counter - i - 1] - 48);
            }

            return newArr;
        }
    }
}
using System;
using System.Collections.Generic;
/*
*                                  CodeKata Number 6
*                                  
* Create a method which takes a string, and returns, both, the sum of the the underlying
* numerical value of each character which is a prime number AND a string which does NOT
* contain characters which have underlying numerical values which are prime numbers.

* For example, if you feed the method "Nishant Mandal", it should return "Nishnt Mndl" and 291

* Once you have completed the above, also extend your method so it returns the the sum of all the digits
* in the sum of the the underlying numerical value of each character which is a prime number in the same method.

* After you have completed that, in the same method, make it also return a dictionary where the
* characters of the new string(i.e. string which does NOT contain characters which has an underlying
* numerical values which are prime numbers) and the characters underlying numerical value as the value.

* Create Unit Tests
* The method must use the 'out' keyword
*/
namespace CodeKata
{
    public class CodeKata_6
    {
        public static (int, Dictionary<char, int>, int) PrimeNumberConversion(string str, out string outputStr)
        {
            Dictionary<char, int> list = new Dictionary<char, int>();
            int primeSum = 0, nonePrimeSum = 0;

            outputStr = "";

            foreach (var c in str)
            {
                if (CheckIfNumberIsPrimeNumber(Convert.ToInt32(c)))
                {
                    primeSum += c;
                }
                else
                {
                    if (!list.ContainsKey(c))
                        list.Add(c, c);
                    outputStr += c;
                    nonePrimeSum += c;
                }
            }
            return (primeSum, list, nonePrimeSum);
        }

        public static bool CheckIfNumberIsPrimeNumber(int num)
        {
            if (num == 0)
                return false;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
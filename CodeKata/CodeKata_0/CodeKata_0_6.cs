using System;

/*
*                                  CodeKata Number 0.6
*                                  Fizz Buzz Puzzle
* 
* Print integers 1 to N, but print “Fizz” if an integer is divisible by 3, 
* “Buzz” if an integer is divisible by 5, and “FizzBuzz” 
* if an integer is divisible by both 3 and 5.
*/
namespace CodeKata
{
    public class CodeKata_0_6
    { 
        public static string FizzBuzz(int num)
        {
            string result = Convert.ToString(num);

            if (num % 15 == 0) result = "Fizz Buzz";
            else if (num % 5 == 0) result = "Buzz";
            else if (num % 3 == 0) result = "Fizz";

            return result;
        }
        
        public static void Print(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
        }
    }
}
using System;
/*
 *                                  CodeKata Number 0
 *                      Find the Highest 2nd Number in an Array
 *                              
 *  This file contains a solution to finding the highest second number in an array
 * 
 */
namespace CodeKata
{
    public class CodeKata_0_0
    {
        public static void Highest2Integer(int[] arrs)
        {
            try
            {
                Console.WriteLine(Find(arrs));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static int Find(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new Exception("The list is empty");
            }
            if (numbers.Length == 1)
            {
                throw new Exception($"The list only contains one element, which is {numbers[0]}");
            }
            Array.Sort(numbers);
            Array.Reverse(numbers);
            int result = 0;
            int CounterForComparison = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                // Throws exception if all numbers in array are the same
                if (numbers[i - 1] == numbers[i])
                {
                    CounterForComparison++;
                    if (CounterForComparison == numbers.Length)
                    {
                        throw new Exception($"All numbers in Array are equal with value {numbers[0]}.");
                    }
                }

                // Find highest number in an array with multiple numbers having highest number (e.g. 7, 7, 7, 4, 4, 2, 1)
                if (numbers[0] != numbers[i] && numbers[0] == numbers[i - 1])
                {
                    result = numbers[i];
                }
            }
            return result;
        }
    }
}

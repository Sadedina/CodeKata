/*
*                                  CodeKata Number 0.2
*                                    (C# Basic Test)
*                                Largest Number in Array
* 
* Given an int[] Array return the largest number in the array
*/
namespace SpartaGlobal;

public class SG_2
{
    public static int ArrayInt(int[] numbers)
    {
        int largestNum;

        if (numbers.Length == 0)
        {
            throw new ArgumentException("Cannot have a large number with an empty list!");
        }


        largestNum = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (largestNum <= numbers[i])
            {
                largestNum = numbers[i];
            }
        }

        return largestNum;
    }
}
/*
*                                  CodeKata Number 0.3
*                                    (C# Basic Test)
*                                Sum in an Array n1 to n2 
* 
* Given an Array and n1 and n2. Where n2 > n1 and lenght of array > n2. 
* Find the sum of all the integers inbetween n1 and n2. Including n2 but not n1
* 
* Example
* int[] Array = {1, 2, 3, 4, 5, 6, 7, 8, 9}
* n1 = 2       n2 = 6      sum = 3 + 4 + ... + 6 = 
*/
namespace CodeKata
{
    public class CodeKata_0_3
    {
        public static int SumArrayInt(int num1, int num2, int[] arr)
        {
            int sum = 0;
            for (int i = num1; i <= num2; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
}
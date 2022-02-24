using System;

/*
*                                  CodeKata Number 5
* Create a method that takes an int[] array and returns number (int) closest to 0
*          
* Create a class library project and write unit tests.
* Consider minus numbers, arrays which contain all the same integer, empty arrays, 
* minus numbers, two numbers the same distance from 0 etc.
*/
namespace CodeKata
{
    public class CodeKata_5
    {
        public static int[] ClosestToZero(int[] nums)
        {
            if (nums.Length == 0) { throw new ArgumentNullException("List is empty"); }
            int[] returnlist = new int[2];
            Array.Sort(nums);
            int comparison = int.MaxValue;
            int closestIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int current = Math.Abs(nums[i]);
                if (current < comparison)
                {
                    closestIndex = i;
                    comparison = current;
                    returnlist[0] = nums[closestIndex];
                }
                else if (current == comparison && nums[closestIndex] < 0 && nums[i] > 0)
                {
                    closestIndex = i;
                    returnlist[1] = nums[closestIndex];
                }
            }

            return returnlist;
        }
    }
}
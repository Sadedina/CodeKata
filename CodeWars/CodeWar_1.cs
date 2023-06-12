/*
*                                  CodeWars Number 1
*                                  Find the odd int
*           https://www.codewars.com/kata/54da5a58ea159efa38000836/train/csharp
*/

namespace CodeWars
{
    public class CodeWar_1
    {
        public static int find_it(int[] seq)
        {
            foreach (var item in seq.Where(item => seq.Count(x => x == item) % 2 != 0))
            {
                return item;
            }

            return -1;
        }
    }
}
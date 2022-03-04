/*
*                                  CodeKata Number 12
*                                  Multiples of 3 or 5
*                     
* Link: projecteuler.net/problem=1
*
*/

namespace CodeKata
{
    public class CodeKata_12
    {
        public static int MultipleOfThreeAndFive(int limit)
        {
            var multiple = 0;
            
            for (int i = 0; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    multiple += i;
            }

            return multiple;
        }
    }
}
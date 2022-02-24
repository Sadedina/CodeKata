/*
*                                  CodeKata Number 2
*                                Cat years, Dog years
*                     
* I have a cat and a dog.
* I got them at the same time as kitten/puppy. That was humanYears years ago.
* Return their respective ages now as [humanYears,catYears,dogYears]
* 
* NOTES:
* 
* humanYears >= 1
* humanYears are whole numbers only
* 
* Cat Years
* 15 cat years for first year
* +9 cat years for second year
* +4 cat years for each year after that
* 
* Dog Years
* 15 dog years for first year
* +9 dog years for second year
* +5 dog years for each year after that
* 
* Link: www.codewars.com/kata/5a6663e9fd56cb5ab800008b/train/csharp
*
*/
namespace CodeKata
{
    public class CodeKata_2
    {
        public static int[] humanYearsCatYearsDogYears(int humanYears)
        {
            //int cat = 0;
            //int dog = 0;

            //if (humanYears == 1)
            //{
            //    cat = 15;
            //    dog = 15;
            //}
            //else if (humanYears == 2)
            //{
            //    cat = 24;
            //    dog = 24;
            //}
            //else
            //{
            //    cat = (humanYears -2) * 4 +24;
            //    dog = (humanYears - 2) * 5 + 24;
            //}
            //return new int[] { humanYears, cat, dog };

            var y = humanYears;

            return y == 1 ? new int[] { y, 15, 15 } : y == 2 ?
                new int[] { y, 24, 24 } : new int[] { y, (y - 2) * 4 + 24, (y - 2) * 5 + 24 };
        }
    }
}
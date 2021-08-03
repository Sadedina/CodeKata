using System;

namespace PetAgeApp
{
    public class Dinglemouse
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

/*
*                                  CodeWars Number 3
*                                  Price of Mangoes
*               https://www.codewars.com/kata/57a77726bb9944d000000b06
*                          Sum a list but ignore any duplicates
*               https://www.codewars.com/kata/5993fb6c4f5d9f770c0000f2
*
*/

namespace CodeWars
{
    public static class CodeWar_3
    {
        #region Price of Mangoes
        public static int Mango(int quantity, int price)
            => price * (quantity - quantity / 3);
        #endregion

        #region Sum a list but ignore any duplicates
        public static int SumNoDuplicates(int[] arr)
        {
            var arrToList = new List<int>();

            arrToList.AddRange(arr.ToList().Where(item => arr.Count(x => x == item) == 1));

            return arrToList.Sum();
        }

        public static int SumNoDuplicates_VersionTwo(int[] arr)
        {
            var arrToList = arr.ToList();

            foreach (var item in arr.ToList())
            {
                if (arr.Count(x => x == item) > 1)
                    arrToList.RemoveAll(x => x == item);
            }

            return arrToList.Sum();
        }

        public static int SumNoDuplicates_VersionOne(int[] arr)
        {
            var newArr = new List<int>();
            var discarded = new List<int>();

            foreach (var item in arr)
            {
                if (!newArr.Contains(item))
                {
                    newArr.Add(item);
                }
                else
                {
                    if (!discarded.Contains(item))
                        newArr.Add(-item);

                    discarded.Add(item);
                }
            }

            return newArr.Sum();
        }
        #endregion
    }
}
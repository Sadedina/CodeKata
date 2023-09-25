/*
*                                  CodeWars Number 3
*                                  Price of Mangoes
*           https://www.codewars.com/kata/57a77726bb9944d000000b06
*/

namespace CodeWars
{
    public static class CodeWar_3
    {
        public static int Mango(int quantity, int price)
            => price * (quantity - quantity / 3);

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
    }
}
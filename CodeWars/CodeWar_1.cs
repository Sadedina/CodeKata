/*
*                                  CodeWars Number 1
*                                  Find the odd int
*           https://www.codewars.com/kata/54da5a58ea159efa38000836/train/csharp
*                                   Mumbling
*           https://www.codewars.com/kata/5667e8f4e3f572a8f2000039
*/

namespace CodeWars
{
    public class CodeWar_1
    {
        #region Find the odd int
        public static int find_it(int[] seq)
        {
            foreach (var item in seq.Where(item => seq.Count(x => x == item) % 2 != 0))
            {
                return item;
            }

            return -1;
        }
        #endregion

        #region Mumbling
        public static String Accum(string s)
        {
            var mumble = "";
            var wordLength = s.Length;

            for (int i = 0; i < wordLength; i++)
            {
                mumble += s[i].ToString().ToUpper();

                for (int j = 0; j < i; j++)
                    mumble += s[i].ToString().ToLower();

                mumble += "-";
            }

            return mumble.Remove(mumble.Length - 1);
        }
        #endregion
    }
}
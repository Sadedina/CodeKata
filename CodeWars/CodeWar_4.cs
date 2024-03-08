/*
*                                  CodeWars Number 4
*                                Is he gonna survive?
*                   https://www.codewars.com/kata/59ca8246d751df55cc00014c
*                                   Death by Coffee
*                   https://www.codewars.com/kata/57db78d3b43dfab59c001abe
*/

namespace CodeWars
{
    public static class CodeWar_4
    {
        #region Is he gonna survive?

        public static bool Hero(int bullets, int dragons)
            => bullets < dragons * 2 ? false : true;

        #endregion

        #region Death by Coffee
        public static (int, int) CoffeeLimits(int year, int month, int day)
        {
            var cafePoison = FormatFromHexadecimal("CAFE");
            var decafPoison = FormatFromHexadecimal("DECAF");

            var formattedMonth = AddPrefixToDate(month);
            var formattedDay = AddPrefixToDate(day);

            var dateOfBirth = $"{year}{formattedMonth}{formattedDay}";

            Int32.TryParse(dateOfBirth, out int intFormattedDate);

            var cafeLimit = CaffeLimitEvaluator(intFormattedDate, cafePoison);
            var decafLimit = CaffeLimitEvaluator(intFormattedDate, decafPoison);

            return (cafeLimit, decafLimit);
        }

        private static int FormatFromHexadecimal(string formattedDate)
            => Convert.ToInt32(formattedDate, 16);

        public static string AddPrefixToDate(int month)
        {
            var monthToString = month.ToString();

            if (monthToString.Length == 2)
                return monthToString;

            var numberDictionary = new Dictionary<int, string>
            {
                {1, "01"},
                {2, "02"},
                {3, "03"},
                {4, "04"},
                {5, "05"},
                {6, "06"},
                {7, "07"},
                {8, "08"},
                {9, "09"}
            };

            return numberDictionary.FirstOrDefault(x => x.Key == month).Value;
        }

        private static int CaffeLimitEvaluator(int number, int poison)
        {
            var hexadecimal = "";
            var poisonNumber = 0;

            do
            {
                number += poison;
                hexadecimal = FormatIntoHexadecimal(number);

                poisonNumber++;

                if (poisonNumber >= 5000)
                    return 0;

            } while (!DeathEvaluator(hexadecimal));

            return poisonNumber;
        }

        private static string FormatIntoHexadecimal(int formattedDate)
            => formattedDate.ToString("X");

        private static bool DeathEvaluator(string word)
            => word.Contains("DEAD");
        #endregion
    }
}
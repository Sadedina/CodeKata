namespace SoftwareCrafters.SF_Module_4;

public class RomanNumerals
{
    #region Second Attempt
    private static readonly Dictionary<int, string> Mapper =
        new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

    public static string Convert(int number)
    {
        var result = string.Empty;

        foreach (var item in Mapper)
        {
            while (number >= item.Key)
            {
                result += item.Value;
                number -= item.Key;
            }

            if (number == 0)    //Added break to stop iterating through dictionary ASAP
                break;
        }

        return result;
    }
    #endregion

    #region First attempt
    //private static readonly Dictionary<double, string> Mapper = NumbersDictionary();

    //public static string Convert(int number)
    //{
    //    var result = "";
    //    var intoBaseTenList = IntoBaseTenList(number);

    //    foreach (var numbers in intoBaseTenList)
    //    {
    //        if (numbers == 0)
    //            continue;

    //        var num = numbers;
    //        foreach (var item in Mapper)
    //        {
    //            while (num >= item.Key)
    //            {
    //                result += item.Value;
    //                num -= item.Key;
    //            }

    //            if (num == 0)
    //                break;
    //        }
    //    }

    //    return result;
    //}

    //private static List<double> IntoBaseTenList(int arabicNumber)
    //{
    //    var numbersIntoList = IntoList(arabicNumber);
    //    var reverseList = ReverseList(numbersIntoList);
    //    var convertIntoBaseTens = ConvertToBaseTen(reverseList);
    //    return ReverseList(convertIntoBaseTens);
    //}

    //private static List<double> IntoList(int num)
    //{
    //    var numAsString = num.ToString();

    //    return numAsString
    //        .Select(letter => Convert.ToDouble(letter.ToString()))
    //        .ToList();
    //}

    //private static List<double> ReverseList(List<double> numbers)
    //{
    //    numbers.Reverse();

    //    return numbers;
    //}

    //private static List<double> ConvertToBaseTen(List<double> numbers)
    //    => numbers.Select((number, position) => number * Math.Pow(10, position)).ToList();

    //private static Dictionary<double, string> NumbersDictionary()
    //{
    //    return new()
    //    {
    //        { 1000, "M" },
    //        { 900, "CM" },
    //        { 500, "D" },
    //        { 400, "CD" },
    //        { 100, "C" },
    //        { 90, "XC" },
    //        { 50, "L" },
    //        { 40, "XL" },
    //        { 10, "X" },
    //        { 9, "IX" },
    //        { 5, "V" },
    //        { 4, "IV" },
    //        { 1, "I" }
    //    };
    //}
    #endregion
}
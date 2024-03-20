namespace SoftwareCrafters.SF_Module_4;

public class RomanNumerals
{
    private static readonly Dictionary<double, string> ArabicToRomanDictionary = NumbersDictionary();

    public static string ConvertIntoRomanNumerals(int arabicNumber)
    {
        var romanNumeral = "";
        var intoBaseTenList = IntoBaseTenList(arabicNumber);

        foreach (var numbers in intoBaseTenList)
        {
            if (numbers == 0)
                continue;

            var num = numbers;
            foreach (var dictionary in ArabicToRomanDictionary)
            {
                while (num >= dictionary.Key)
                {
                    romanNumeral += dictionary.Value;
                    num -= dictionary.Key;
                }

                if (num == 0)
                    break;
            }
        }

        return romanNumeral;
    }

    private static List<double> IntoBaseTenList(int arabicNumber)
    {
        var numbersIntoList = IntoList(arabicNumber);
        var reverseList = ReverseList(numbersIntoList);
        var convertIntoBaseTens = ConvertToBaseTen(reverseList);
        return ReverseList(convertIntoBaseTens);
    }

    private static List<double> IntoList(int num)
    {
        var numAsString = num.ToString();

        return numAsString
            .Select(letter => Convert.ToDouble(letter.ToString()))
            .ToList();
    }

    private static List<double> ReverseList(List<double> numbers)
    {
        numbers.Reverse();

        return numbers;
    }

    private static List<double> ConvertToBaseTen(List<double> numbers)
        => numbers.Select((number, position) => number * Math.Pow(10, position)).ToList();

    private static Dictionary<double, string> NumbersDictionary()
    {
        return new()
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
    }
}
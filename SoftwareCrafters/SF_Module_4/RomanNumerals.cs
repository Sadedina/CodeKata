namespace SoftwareCrafters.SF_Module_4;

public class RomanNumerals
{
    private static readonly Dictionary<int, string> ArabicToRomanDictionary = NumbersDictionary();

    public static string ConvertIntoRomanNumerals(int arabicNumber)
    {
        var numbersIntoList = IntoList(arabicNumber);
        var reverseList = ReverseList(numbersIntoList);
        var convertIntoBaseTens = ConvertToBaseTen(reverseList);
        var reReveresedList = ReverseList(convertIntoBaseTens);

        if (arabicNumber == 1)
            return "I";

        if (arabicNumber == 2)
            return "II";

        if (arabicNumber == 3)
            return "III";

        if (arabicNumber == 4)
            return "IV";

        if (arabicNumber == 5)
            return "V";

        if (arabicNumber == 6)
            return "VI";

        if (arabicNumber == 7)
            return "VII";

        if (arabicNumber == 8)
            return "VIII";

        if (arabicNumber == 9)
            return "IX";

        if (arabicNumber == 10)
            return "X";

        return "";
    }

    private static List<double> ReverseList(List<double> numbers)
    {
        numbers.Reverse();

        return numbers;
    }

    private static List<double> IntoList(int num)
    {
        var numAsString = num.ToString();

        return numAsString
            .Select(letter => Convert.ToDouble(letter.ToString()))
            .ToList();
    }

    private static List<double> ConvertToBaseTen(List<double> numbers)
        => numbers.Select((number, position) => number * Math.Pow(10, position)).ToList();


    private static Dictionary<int, string> NumbersDictionary()
    {
        return new()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" }
        };
    }
}
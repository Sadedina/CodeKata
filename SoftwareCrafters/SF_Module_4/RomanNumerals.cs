namespace SoftwareCrafters.SF_Module_4;

public class RomanNumerals
{
    private static readonly Dictionary<int, string> ArabicToRomanDictionary = NumbersDictionary();

    public static string ConvertIntoRomanNumerals(int arabicNumber)
    {
        ToBaseFive(arabicNumber);

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

    //private static int Converter(int arabicNumber, out string romanNumeral)
    //{
    //    if (arabicNumber < 4)
    //    {
    //        for (int i = 0; i < arabicNumber; i++)
    //        {
    //            romanNumber += ArabicToRomanDictionary[1];
    //        }

    //        return romanNumber;
    //    }
    //}

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

    private static string ToBaseFive(int num)
    {
        num = 15;
        var remainder = num % 5;
        if (num - remainder == 0)
            return toChar(remainder).ToString();

        return ToBaseFive((num - remainder) / 16) + toChar(remainder);
    }

    private static char toChar(int num)
    {
        var alpha = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        return alpha[num];
    }
}
namespace SoftwareCrafters.SF_Module_4;

public class ArabicNumbers
{
    private static readonly Dictionary<string, int> RomanToArabicDictionary = NumbersDictionary();


    public static int ConvertIntoArabicNumbers(string romanNumeral)
    {
        var arabicNumber = 0;

        do
        {
            foreach (var item in RomanToArabicDictionary.Where(item => romanNumeral.StartsWith(item.Key)))
            {
                arabicNumber += item.Value;
                romanNumeral = romanNumeral.Remove(0, item.Key.Length);
                break;
            }

        } while (romanNumeral.Length != 0);


        return arabicNumber;
    }

    private static Dictionary<string, int> NumbersDictionary()
    {
        return new()
        {
            { "M", 1000 },
            { "CM" , 900 },
            { "D" , 500 },
            { "CD" , 400 },
            { "C" , 100 },
            { "XC" , 90 },
            { "L" , 50 },
            { "XL" , 40 },
            { "X" , 10 },
            { "IX" , 9 },
            { "V" , 5 },
            { "IV" , 4 },
            { "I" , 1 }
        };
    }
}
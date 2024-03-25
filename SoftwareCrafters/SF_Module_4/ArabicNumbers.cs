namespace SoftwareCrafters.SF_Module_4;

public class ArabicNumbers
{
    #region Second Attempt
    //private static readonly Dictionary<string, int> Mappers =
    //    new Dictionary<string, int>
    //    {
    //        { "M", 1000 },
    //        { "CM", 900 },
    //        { "D", 500 },
    //        { "CD", 400 },
    //        { "C", 100 },
    //        { "XC", 90 },
    //        { "L", 50 },
    //        { "XL", 40 },
    //        { "X", 10 },
    //        { "IX", 9 },
    //        { "V", 5 },
    //        { "IV", 4 },
    //        { "I", 1 }
    //    };

    //public static int Convert(string numeral)
    //{
    //    if (Mappers.ContainsKey(numeral))
    //        return Mappers[numeral];

    //    foreach (var item in Mappers.Where(item => numeral.StartsWith(item.Key)))
    //    {
    //        return item.Value + Convert(numeral.Remove(0, item.Key.Length));
    //    }

    //    return 0;
    //}
    #endregion

    #region First Attempt
    private static readonly Dictionary<string, int> Mappers = NumbersDictionary();

    public static int Convert(string numeral)
    {
        var result = 0;

        do
        {
            foreach (var item in NumeralStartsWith(numeral))
            {
                result += item.Value;
                numeral = numeral.Remove(0, item.Key.Length);
                break;
            }

        } while (numeral.Length != 0);

        return result;
    }

    private static IEnumerable<KeyValuePair<string, int>> NumeralStartsWith(string numeral)
        => Mappers.Where(item => numeral.StartsWith(item.Key));

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
    #endregion
}
namespace PersonalDevelopment;

public class StringCalculator
{
    private const string NewLine = "\n";
    private const string LineStarter = "//";

    public int Add(string stringNum)
    {
        var separators = new List<string> { ",", "\n" };

        if (stringNum.StartsWith(LineStarter))
        {
            separators.Add(GetSeparator(stringNum));
            stringNum = GetString(stringNum);
        }

        if (stringNum.Contains("-"))
            ThrowException(separators, stringNum);

        foreach (var item in separators.Where(item => stringNum.Contains(item)))
        {
            return StringAdder(item, stringNum);
        }

        if (stringNum == "")
            return 0;

        return Convert.ToInt32(stringNum);
    }

    private int StringAdder(string splitter, string stringNum)
    {
        var stringArray = stringNum.Split(splitter);

        return stringArray.Sum(Convert.ToInt32);
    }

    private static void ThrowException(List<string> collectionSeparators, string stringNum)
    {
        var errorMessage = "Negatives not allowed:";

        foreach (var separator in collectionSeparators)
        {
            if (stringNum.Contains(separator))
            {
                var numArr = stringNum
                    .Split(separator)
                    .Where(number => number.StartsWith("-"))
                    .ToList();

                foreach (var negativeNum in numArr)
                    errorMessage += $" {negativeNum}";

                throw new ArgumentException(errorMessage);
            }
        }

        throw new ArgumentException($"{errorMessage} {stringNum}");
    }

    private string GetSeparator(string stringNum)
    {
        var lengthOfSeparator = stringNum.IndexOf(NewLine) - NewLine.Length - 1;

        return stringNum.Substring(LineStarter.Length, lengthOfSeparator);
    }

    private static string GetString(string stringNum)
    {
        var indexOfNewLine = stringNum.IndexOf(NewLine);

        return stringNum.Substring(indexOfNewLine + NewLine.Length);
    }
}
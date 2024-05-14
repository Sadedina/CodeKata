namespace PersonalDevelopment;

public class PD15
{
    public static string CreateMethodName(string sentence)
    {
        var words = sentence.Split("\r\n").ToList();

        return CreateMethodName(words);
    }

    public static string CreateMethodName(List<string> method)
    {
        var methodName = "";

        for (var i = 0; i < method.Count; i++)
        {
            methodName += SanitiseSentence(method[i]);

            if (i < method.Count - 1)
                methodName += "_";
        }

        return methodName;
    }

    private static string SanitiseSentence(string sentence)
    {
        var words = sentence.Replace(",", "").Split(' ');

        return words.Aggregate("", (current, word) => current + SanitiseWord(word));
    }

    private static string SanitiseWord(string word)
    {
        var finalWord = "";

        for (var i = 0; i < word.Length; i++)
        {
            var wordChar = word[i].ToString().ToLower();

            if (i == 0)
                wordChar = wordChar.ToUpper();

            finalWord += wordChar;
        }

        return finalWord;
    }
}
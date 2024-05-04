namespace PersonalDevelopment;

public class PD15
{
    public static string CretaeMethodName(string sentence)
    {
        var words = sentence.Split("\r\n").ToList();

        return CretaeMethodName(words);
    }

    public static string CretaeMethodName(List<string> method)
    {
        var methodName = "";

        for (int i = 0; i < method.Count; i++)
        {
            methodName += SanitiseSentence(method[i]);

            if (i < method.Count - 1)
                methodName += "_";
        }

        return methodName;
    }

    private static string SanitiseSentence(string sentence)
    {
        var finalSentence = "";

        var words = sentence.Replace(",", "").Split(' ');

        foreach (var word in words)
        {
            finalSentence += SanitiseWord(word);
        }

        return finalSentence;
    }

    private static string SanitiseWord(string word)
    {
        var finalWord = "";

        for (int i = 0; i < word.Length; i++)
        {
            var wordChar = word[i].ToString().ToLower();

            if (i == 0)
                wordChar = wordChar.ToUpper();

            finalWord += wordChar;
        }

        return finalWord;
    }

}
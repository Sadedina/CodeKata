namespace SoftwareCrafters.SF_Module_4;

public class WordWrap
{
    public static string Wrap(string word, int number)
    {
        if (string.IsNullOrEmpty(word))
            return string.Empty;

        if (word.Length > number)
            word = word.Insert(number, "/n");

        return word;
    }


}
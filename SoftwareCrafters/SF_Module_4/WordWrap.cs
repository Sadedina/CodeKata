namespace SoftwareCrafters.SF_Module_4;

public static class WordWrap
{
    public static string Wrap(string sentence, int columnNumber)
    {
        if (string.IsNullOrEmpty(sentence)) return string.Empty;

        var currentNewLinePosition = 0;
        do
        {
            if (sentence.Substring(currentNewLinePosition).Length <= columnNumber)
                break;

            var wordSubstring = sentence.Substring(currentNewLinePosition, columnNumber);
            var nextNewLinePosition = currentNewLinePosition + columnNumber;

            if (wordSubstring.Contains(' '))
            {
                nextNewLinePosition = wordSubstring.LastIndexOf(' ') + currentNewLinePosition;
                sentence = sentence.Remove(nextNewLinePosition, 1);
            }

            sentence = sentence.Insert(nextNewLinePosition, "\n");
            currentNewLinePosition = sentence.IndexOf("\n", currentNewLinePosition) + 1;

        } while (sentence.Length > currentNewLinePosition + columnNumber);

        return sentence;
    }
}
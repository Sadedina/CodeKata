/*
*                                  CodeKata Number 7
*                             Duplicate chars in a string
* 
* Create a method which takes a string and returns an array of duplicate characters
*/
namespace CodeKata
{
    public class CodeKata_7
    {
        public static char[] Duplicates(string word)
        {
            string checkedLetters = "";
            string duplicatedLetters = "";
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                if (checkedLetters.Contains(word[i]) && !duplicatedLetters.Contains(word[i]))
                    duplicatedLetters += word[i];
                checkedLetters += word[i];
            }

            return duplicatedLetters.ToCharArray();
        }
    }
}
using System.Collections.Generic;

/*
*                                  CodeKata Number 0.7
*                           Find number of ATCG in string
*/
namespace CodeKata
{
    public class CodeKata_0_7
    {
        public static string ATCG(string word)
        {
            word = word.ToUpper();
            Dictionary<char, int> dict = new Dictionary<char, int>()
            { 
                {'A', 0},
                {'T', 0},
                {'C', 0},
                {'G', 0}
            };

            foreach (var item in word)
            {
                if (dict.ContainsKey(item))     dict[item]++;
                else                            dict.TryAdd(item, 1);
            }

            return $"A:{dict['A']}, T:{dict['T']}, C:{dict['C']}, G:{dict['G']}";
        }
    }
}
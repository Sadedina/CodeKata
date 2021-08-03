using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapApp
{
    public class Kata
    {        public static string Switcheroo(string x)
        {
            //string newString = "";
            //foreach (var l in x)
            //{
            //    if (l == 'a')
            //        newString += 'b';
            //    else if (l == 'b')
            //        newString += 'a';
            //    else
            //        newString += c;
            //}
            //return newString;


            return x.Replace('a', 'x').Replace('b', 'a').Replace('x', 'b');
        }
    }
}

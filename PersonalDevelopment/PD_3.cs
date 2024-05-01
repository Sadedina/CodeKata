/*
*                                  CodeKata Number 3
*                                     Switcheroo
*                     
* Given a string made up of letters a, b, and/or c, switch the position of letters a and b 
* (change a to b and vice versa). Leave any incidence of c untouched.
* 
* Example:
* 
* 'acb' --> 'bca'
* 'aabacbaa' --> 'bbabcabb'
* 
* Link: www.codewars.com/kata/57f759bb664021a30300007d/train/csharp
*
*/
namespace PersonalDevelopment;

public class PD_3
{
    public static string Switcheroo(string x)
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
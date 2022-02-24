/*
*                                  CodeKata Number 4
*                                   Who likes it?
*                     
* You probably know the "like" system from Facebook and other pages. People can "like" blog posts, 
* pictures or other items. We want to create the text that should be displayed next to such an item.
* 
* Implement the function likes which takes an array containing the names of people that like an item. 
* It must return the display text as shown in the examples:
* 
* Kata.Likes(new string[0]) => "no one likes this"
* Kata.Likes(new string[] {"Peter"}) => "Peter likes this"
* Kata.Likes(new string[] {"Jacob", "Alex"}) => "Jacob and Alex like this"
* Kata.Likes(new string[] {"Max", "John", "Mark"}) => "Max, John and Mark like this"
* Kata.Likes(new string[] {"Alex", "Jacob", "Mark", "Max"}) => "Alex, Jacob and 2 others like this"
* 
* 
* After you have worked out a solution, try to redo it in one line!!
* 
* Link: www.codewars.com/kata/5266876b8f4bf2da9b000362/train/csharp
*/
namespace CodeKata
{
    public class CodeKata_4
    {
        public static string Likes(string[] name)
        {
            //var lengths = name.Length;
            //string result = "";

            //if(lengths > 3)
            //{
            //    result = $"{name[0]}, {name[1]} and {lengths - 2} others like this";
            //}
            //else if(lengths > 2)
            //{
            //    result = $"{name[0]}, {name[1]} and {name[2]} like this";
            //}
            //else if (lengths > 1)
            //{
            //    result = $"{name[0]} and {name[1]} like this";
            //}
            //else if (lengths > 0)
            //{
            //    result = $"{name[0]} likes this";
            //}
            //else
            //{
            //    result = $"no one likes this";
            //}

            //return result;


            //return $"{(name.Length > 0 ? (name.Length > 3 ? $"{name[0]}, {name[1]} and {name.Length - 2} others like this" : (name.Length == 3 ? $"{name[0]}, {name[1]} and {name[2]} like this" : (name.Length == 2 ? $"{name[0]} and {name[1]} like this" : $"{name[0]} likes this"))) : "no one likes this")}";


            return name.Length > 3 ? $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
                                                                                                    : name.Length == 3 ? $"{name[0]}, {name[1]} and {name[2]} like this"
                                                                                                    : name.Length == 2 ? $"{name[0]} and {name[1]} like this"
                                                                                                    : name.Length == 1 ? $"{name[0]} likes this" : $"no one likes this";
        }
    }
}
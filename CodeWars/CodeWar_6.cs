/*
*                                  CodeWars Number 6
*                                The Supermarket Queue
*          https://www.codewars.com/CodeWar_6/57b06f90e298a7b53d000a86/train/csharp
*/

namespace CodeWars;

public static class CodeWar_6
{
    public static long QueueTime(int[] customers, int n)
    {
        var tills = new int[n];
        foreach (var customer in customers)
        {
            tills[0] += customer;
            Array.Sort(tills);
        }

        Array.Reverse(tills);

        return tills[0];
    }
}
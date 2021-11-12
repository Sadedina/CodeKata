using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
/*
*                                  CodeKata Number 11
*                                     Poker hands
*                     
* Link: projecteuler.net/problem=54
*
*/

namespace CodeKata
{
    public class CodeKata_11
    {
        public static string ReadFile()
        {
            var url = "https://projecteuler.net/project/resources/p054_poker.txt";

            return (new WebClient()).DownloadString(url).Replace(" ", "").Replace("\n", "");
        }
        public static void PokerHands(string file)
        {
            int counter = file.Length;
            string[,] player1Cards = new string[1010,5];
            string[,] player2Cards = new string[1010,5];
            int x = 0, y = 0, i = 0, j = 10;

            do
            {
                player1Cards[x, y] = file.Substring(i, 2);
                player2Cards[x, y] = file.Substring(j, 2);

                y++;
                i += 2;
                j += 2;
                if (y == 5)
                {
                    y = 0;
                    i += 10;
                    j += 10;
                    x++;
                }

                counter -= 20;
            } while (counter >= 0);
        }
    }
}
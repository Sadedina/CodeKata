using System;
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
        const int lineLenght = 20;
        const int halfLineLength = 10;

        public static int? PokerHands()
        {
            var file = ReadFile();
            string[] playerOneCards = PlayerHand(file).Item1;
            string[] playerTwoCards = PlayerHand(file).Item2;

            //string[] plauerOneHandValue = ;
            //string[] plauerTwoHandValue = ;

            var oder = OrderCards("ASKD3DJD8H");

            return null;
        }

        private static string ReadFile()
        {
            var url = "https://projecteuler.net/project/resources/p054_poker.txt";

            return (new WebClient()).DownloadString(url).Replace(" ", "").Replace("\n", "");
        }

        private static (string[], string[]) PlayerHand(string file)
        {
            int counter = file.Length;
            string[] playerOneCards = new string[counter / lineLenght];
            string[] playerTwoCards = new string[counter / lineLenght];
            int x = 0, i = 0, j = halfLineLength;

            do
            {
                playerOneCards[x] = file.Substring(i, halfLineLength);
                playerTwoCards[x] = file.Substring(j, halfLineLength);

                x++;
                i += lineLenght;
                j += lineLenght;

                counter -= lineLenght;
            } while (counter >= lineLenght);

            return (playerOneCards, playerTwoCards);
        }

        private static string[] OrderCards(string hand)
        {
            var oderedCards = new string[5];
            var cards = new string[]
            {
                hand.Substring(0, 2),
                hand.Substring(2, 2),
                hand.Substring(4, 2),
                hand.Substring(6, 2),
                hand.Substring(8, 2),
            };
            

            Array.Sort(cards);


            for (int i = 0; i < 5; i++)
            {

            }


            return cards;
        }

        //private static int HighCard(string[] cards)
        //{

        //}
    }
}
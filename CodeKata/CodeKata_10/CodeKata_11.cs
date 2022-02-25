﻿using System;
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
        const int lineLenght = 20;
        const int halfLineLength = 10;

        public static int? PokerHands()
        {
            var file = ReadFile();

            // Strings of hand "4S8C9HTSKC" in order
            string[] playerOneCards = PlayerHand(file).Item1;
            string[] playerTwoCards = PlayerHand(file).Item2;

            //string[] playerOneHandValue = ;
            //string[] playerTwoHandValue = ;



            var handTest = CountPairValue("4S8C9HTSKC");
            var handTest1 = CountPairValue("4S8C9HKSKC");
            var handTest2 = CountPairValue("4S4C9HKSKC");
            var handTest3 = CountPairValue("4S4C4HTSKC");
            var handTest4 = CountPairValue("4S4C4HKSKC");
            var handTest5 = CountPairValue("4S4C4H4SKC");
            var handTest6 = SameSuits("4S8S9STSKS");
            var testCard = new string[]
            {
                "TH", "JH", "QH", "KH", "2H"
            };

            return null;
        }

        private static string ReadFile()
        {
            var url = "https://projecteuler.net/project/resources/p054_poker.txt";

            return (new WebClient()).DownloadString(url).Replace(" ", "").Replace("\n", "").ToUpper();
        }

        private static (string[], string[]) PlayerHand(string file)
        {
            int counter = file.Length;
            string[] playerOneCards = new string[counter / lineLenght];
            string[] playerTwoCards = new string[counter / lineLenght];
            int x = 0, i = 0, j = halfLineLength;

            do
            {
                playerOneCards[x] = OrderCards(file.Substring(i, halfLineLength));
                playerTwoCards[x] = OrderCards(file.Substring(j, halfLineLength));

                x++;
                i += lineLenght;
                j += lineLenght;

                counter -= lineLenght;
            } while (counter >= lineLenght);

            return (playerOneCards, playerTwoCards);
        }

        private static string OrderCards(string hand)
        {
            var cards = SplitHandsToCards(hand);
            var cardsValue = new Dictionary<char, string>()
            {
                { '2', "" },
                { '3', "" },
                { '4', "" },
                { '5', "" },
                { '6', "" },
                { '7', "" },
                { '8', "" },
                { '9', "" },
                { 'T', "" },
                { 'J', "" },
                { 'Q', "" },
                { 'K', "" },
                { 'A', "" }
            };

            for (int i = 0; i < 5; i++)
            {
                cardsValue[char.Parse(cards[i].Substring(0, 1))] = cardsValue[char.Parse(cards[i].Substring(0, 1))] + cards[i];
            }

            return string.Join(Environment.NewLine, cardsValue.Values).Replace("\r", "").Replace("\n", "");
        }

        private static string[] SplitHandsToCards(string hand)
        {
            return new string[]
            {
                hand.Substring(0, 2),
                hand.Substring(2, 2),
                hand.Substring(4, 2),
                hand.Substring(6, 2),
                hand.Substring(8, 2),
            };
        }

        private static string[] CountPairValue(string hand)
        {
            bool HasOnlyOnePair = false, HasTwoPairs = false, HasThreeOfKind = false,
                HasFullHouse = false, HasFourOfKind = false;
            var counter = new Dictionary<string, int>();
            var handValue = new string[6];
            var value = "";

            var splitHand = SplitHandsToCards(hand).ToList();
            for (int i = 0; i < 5; i++)
            {
                value = splitHand[i].Substring(0, 1);

                if (!counter.ContainsKey(value))
                    counter.Add(value, 0);

                counter[value]++;
            }

            HasOnlyOnePair = counter.Count(card => card.Value == 2) == 1 && !counter.ContainsValue(3);
            HasTwoPairs = counter.Count(card => card.Value == 2) == 2;
            HasThreeOfKind = counter.ContainsValue(3) && !counter.ContainsValue(2);
            HasFullHouse = counter.ContainsValue(3) && counter.ContainsValue(2);
            HasFourOfKind = counter.ContainsValue(4);

            if (HasOnlyOnePair)
            {
                handValue[0] = "15";
                handValue[1] = counter.FirstOrDefault(card => card.Value == 2).Key.ToString();

                for (int i = 0; i < 2; i++)
                {
                    var index = splitHand.FindIndex(pair => pair.Contains(handValue[1]));
                    splitHand.RemoveAt(index);
                }

                handValue[3] = splitHand[2].Substring(0, 1);
                handValue[4] = splitHand[1].Substring(0, 1);
                handValue[5] = splitHand[0].Substring(0, 1);
            }

            if (HasTwoPairs)
            {
                handValue[0] = "16";
                handValue[1] = counter.LastOrDefault(card => card.Value == 2).Key.ToString();
                handValue[2] = counter.FirstOrDefault(card => card.Value == 2).Key.ToString();
                
                for (int i = 0; i < 2; i++)
                {
                    var indexOne = splitHand.FindIndex(pair => pair.Contains(handValue[1]));
                    var indexTwo = splitHand.FindIndex(pair => pair.Contains(handValue[2]));
                    splitHand.RemoveAt(indexOne);
                    splitHand.RemoveAt(indexTwo);
                }
                handValue[3] = splitHand[0].Substring(0, 1);
            }

            if (HasThreeOfKind)
            {
                handValue[0] = "17";
                handValue[1] = counter.FirstOrDefault(card => card.Value == 3).Key.ToString();

                for (int i = 0; i < 3; i++)
                {
                    var index = splitHand.FindIndex(pair => pair.Contains(handValue[1]));
                    splitHand.RemoveAt(index);
                }

                handValue[3] = splitHand[1].Substring(0, 1);
                handValue[4] = splitHand[0].Substring(0, 1);
            }

            if (HasFullHouse)
            {
                handValue[0] = "20";
                handValue[1] = counter.FirstOrDefault(card => card.Value == 3).Key.ToString();
                handValue[2] = counter.FirstOrDefault(card => card.Value == 2).Key.ToString();
            }

            if (HasFourOfKind)
            {
                handValue[0] = "21";
                handValue[1] = counter.FirstOrDefault(card => card.Value == 4).Key.ToString();

                for (int i = 0; i < 4; i++)
                {
                    var index = splitHand.FindIndex(pair => pair.Contains(handValue[1]));
                    splitHand.RemoveAt(index);
                }

                handValue[3] = splitHand[0].Substring(0, 1);
            }

            return handValue;
        }

        private static string[] HighestCard(string hand)
        {
            var handValue = new string[6];
            handValue[0] = hand.Substring(8, 1);

            if (handValue[0] == "J") handValue[0] = "11";
            if (handValue[0] == "Q") handValue[0] = "12";
            if (handValue[0] == "K") handValue[0] = "13";
            if (handValue[0] == "A") handValue[0] = "14";

            return handValue;
        }

        private static bool SameSuits(string hand)
        {
            var hasFourSameSuit = hand.Count(h => h == 'H') == 5 || 
                hand.Count(d => d == 'D') == 5 || 
                hand.Count(c => c == 'C') == 5 || 
                hand.Count(s => s == 'S') == 5;

            if (hasFourSameSuit)
                return true;

            return false;
        }

        private static string[] ConsecutiveCards(string hand)
        {



            return null;
        }

    }
}
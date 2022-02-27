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
        const int lineLenght = 20;
        const int halfLineLength = 10;

        public static int WinRateOfPlayerOne()
        {
            var file = ReadFile();

            var playerOneCards = PlayerHand(file).Item1;
            var playerTwoCards = PlayerHand(file).Item2;

            var playerOneHandValues = AllPlayersCardsValue(playerOneCards);
            var playerTwoHandValues = AllPlayersCardsValue(playerTwoCards);

            var winnerPerRound = WinnerOfARound(playerOneHandValues, playerTwoHandValues);


            var test = PlayerOneWins(winnerPerRound);
            var test1 = PlayerOneWins(winnerPerRound);
            return PlayerOneWins(winnerPerRound);

            //var handTest = HandValue("4S8C9HTSKC");
            //var handTest1 = HandValue("4S8C9HKSKC");
            //var handTest2 = HandValue("4S4C9HKSKC");
            //var handTest3 = HandValue("4S4C4HTSKC");
            //var handTest4 = HandValue("4S4C4HKSKC");
            //var handTest5 = HandValue("4S4C4H4SKC");
            //var handTest6 = HandValue("4S8S9STSKS");
            //var handTest7 = HandValue("4S8S9STSKS");
            //var handTest8 = HandValue("4S5C6H7S8C");
            //var handTest9 = HandValue("4S5S6S7S8S");
            //var handTest10 = HandValue("THJHQHKHAH");

            //var testCard = new string[]
            //{
            //    "TH", "JH", "QH", "KH", "2H"
            //};
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

        private static int CardsToValueConverter(string number)
        {
            if (number == "T")
                return 10;

            if (number == "J")
                return 11;

            if (number == "Q")
                return 12;

            if (number == "K")
                return 13;

            if (number == "A")
                return 14;

            return Convert.ToInt32(number);
        }

        private static string[] HandValue(string playerCard)
        {
            var handValue = new string[6];

            handValue = ConsecutiveCards(playerCard);
            if (handValue[0] != null)
                return handValue;

            handValue = CountPairValue(playerCard);
            if (handValue[0] != null)
                return handValue;

            if (HasSameSuits(playerCard))
            {
                handValue[0] = "18";
                handValue[1] = playerCard.Substring(8, 1);
                return handValue;
            }

            handValue = HighestCard(playerCard);

            return handValue;
        }

        private static string[,] AllPlayersCardsValue(string[] playerCard)
        {
            int rounds = playerCard.Count();
            var playerGame = new string[rounds, 6];

            for (int i = 0; i < rounds; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    playerGame[i, j] = HandValue(playerCard[i])[j];
                }
            }

            return playerGame;
        }

        private static string[] WinnerOfARound(string[,] playerOne, string[,] playerTwo)
        {
            // REMOVE
            //var one = new string[6];
            //var two = new string[6];

            int valuePlayerOne = 0, valuePlayerTwo = 0;
            var winner = new string[1000];

            for (int i = 0; i < 1000; i++)
            {
                // REMOVE
                //for (int x = 0; x < 6; x++)
                //{
                //    one[x] = playerOne[i,x];
                //    two[x] = playerTwo[i,x];
                //}

                for (int j = 0; j < 6; j++)
                {
                    valuePlayerOne = Convert.ToInt32(playerOne[i, j]);
                    valuePlayerTwo = Convert.ToInt32(playerTwo[i, j]);
                    winner[i] = "Draw";

                    if (valuePlayerOne > valuePlayerTwo)
                    {
                        winner[i] = "Player One";
                        break;
                    }
                        
                    if (valuePlayerOne < valuePlayerTwo)
                    {
                        winner[i] = "Player Two";
                        break;
                    }
                }
            }

            return winner;
        }

        private static int PlayerOneWins(string[] rounds)
        {
            var counter = 0;

            foreach (var winner in rounds)
            {
                if (winner == "Player One")
                    counter++;
            }

            return counter;
        }

        // Get Value of Hand
        private static string[] HighestCard(string hand)
        {
            var handValue = new string[6];
            handValue[0] = CardsToValueConverter(hand.Substring(8, 1)).ToString();

            return handValue;
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

        private static bool HasSameSuits(string hand)
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
            const string straight = "A23456789TJQKA";
            const string royal = "TJQKA";
            var handValue = new string[6];
            var cardsNoSuit = hand.Replace("H", "").Replace("D", "").Replace("C", "").Replace("S", "");
            

            if (straight.Contains(cardsNoSuit))
            {
                handValue[0] = "18";
                handValue[1] = CardsToValueConverter(hand.Substring(8, 1)).ToString();

                if (HasSameSuits(hand))
                {
                    handValue[0] = "22";

                    if (royal.Contains(cardsNoSuit))
                        handValue[0] = "23";
                }
            }

            return handValue;
        }
    }
}
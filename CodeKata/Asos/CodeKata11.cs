using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

/*
*                                  CodeKata Number 11
*                                     Poker hands
*                     
* Link: projecteuler.net/problem=54
*
*/

namespace CodeKata.Asos
{
    public class CodeKata11
    {
        const int lineLenght = 20;
        const int halfLineLength = 10;

        public static string WinRateOfPlayerOne()
        {
            var file = ReadFile();

            var playerOneCards = PlayerHand(file).Item1;
            var playerTwoCards = PlayerHand(file).Item2;

            var playerOneHandValues = AllPlayersCardsValue(playerOneCards);
            var playerTwoHandValues = AllPlayersCardsValue(playerTwoCards);

            var winnerPerRound = WinnerOfARound(playerOneHandValues, playerTwoHandValues);

            return $"Poker Game:\n" +
                $"Round won by Player One: {PlayerOneWins(winnerPerRound.Item1)}\n" +
                $"Round won by Player Two: {winnerPerRound.Item4}\n" +
                $"Rounds ended with draw: {winnerPerRound.Item3}\n" +
                $"\nTotal number of rounds: {PlayerOneWins(winnerPerRound.Item1) + winnerPerRound.Item3 + winnerPerRound.Item4}";
        }

        public static string ReadFile()
        {
            var url = "https://projecteuler.net/project/resources/p054_poker.txt";

            return new WebClient().DownloadString(url).Replace(" ", "").Replace("\n", "").ToUpper();
        }

        public static bool ValidatePlayersHand(string hand)
        {
            var cardsNoSuit = hand.Replace("H", "").Replace("D", "").Replace("C", "").Replace("S", "");
            var suitCounter = hand.Count() - cardsNoSuit.Count();
            var errorHandCounter = Regex.Matches(hand, @"[a-zBEFGILMNOPRUVWXYZ!@#$%^&*]").Count;
            var errorSuitlessCounter = Regex.Matches(cardsNoSuit, @"BCDEFGHILMNOPRSUVWXYZ]").Count;

            if (hand.Length < halfLineLength && cardsNoSuit.Count() == hand.Count() / 2)
                throw new InvalidOperationException("Not enough cards to play Poker");

            if (hand.Length > halfLineLength && cardsNoSuit.Count() == hand.Count() / 2)
                throw new InvalidOperationException("Too many cards to play Poker");

            if (cardsNoSuit.Count() != 5 || suitCounter != 5 || errorHandCounter > 0 || errorSuitlessCounter > 0)
                throw new InvalidOperationException("Invalid set of cards");

            return true;
        }

        public static string[] SplitHandsToCards(string hand)
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

        public static string OrderCards(string hand)
        {
            ValidatePlayersHand(hand);
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

        public static (string[], string[]) PlayerHand(string file)
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

        public static int CardsToValueConverter(string value)
        {
            if (value == "T")
                return 10;

            if (value == "J")
                return 11;

            if (value == "Q")
                return 12;

            if (value == "K")
                return 13;

            if (value == "A")
                return 14;

            return Convert.ToInt32(value);
        }

        // Get Value of Hand
        public static int[] HighestCard(string hand)
        {
            return new int[]
            {
                CardsToValueConverter(hand.Substring(8, 1)),
                CardsToValueConverter(hand.Substring(8, 1)),
                0,
                CardsToValueConverter(hand.Substring(6, 1)),
                CardsToValueConverter(hand.Substring(4, 1)),
                CardsToValueConverter(hand.Substring(2, 1)),
                CardsToValueConverter(hand.Substring(0, 1)),
            };
        }

        public static int[] CountPairValue(string hand)
        {
            bool HasOnlyOnePair = false, HasTwoPairs = false, HasThreeOfKind = false,
                HasFullHouse = false, HasFourOfKind = false;
            var counter = new Dictionary<string, int>();
            var handValue = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

            var splitHand = SplitHandsToCards(hand).ToList();
            for (int i = 0; i < 5; i++)
            {
                var value = splitHand[i].Substring(0, 1);

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
                var cardValue = counter.FirstOrDefault(card => card.Value == 2);
                handValue[0] = 15;
                handValue[1] = CardsToValueConverter(cardValue.Key);

                for (int i = 0; i < cardValue.Value; i++)
                {
                    var index = splitHand.FindIndex(pair => pair.Contains(cardValue.Key));
                    splitHand.RemoveAt(index);
                }

                handValue[3] = CardsToValueConverter(splitHand[2].Substring(0, 1));
                handValue[4] = CardsToValueConverter(splitHand[1].Substring(0, 1));
                handValue[5] = CardsToValueConverter(splitHand[0].Substring(0, 1));
            }

            if (HasTwoPairs)
            {
                var cardValueOne = counter.LastOrDefault(card => card.Value == 2);
                var cardValueTwo = counter.FirstOrDefault(card => card.Value == 2);
                handValue[0] = 16;
                handValue[1] = CardsToValueConverter(cardValueOne.Key);
                handValue[2] = CardsToValueConverter(cardValueTwo.Key);

                for (int i = 0; i < cardValueOne.Value; i++)
                {
                    var indexOne = splitHand.FindIndex(pair => pair.Contains(cardValueOne.Key));
                    var indexTwo = splitHand.FindIndex(pair => pair.Contains(cardValueTwo.Key));
                    splitHand.RemoveAt(indexOne);
                    splitHand.RemoveAt(indexTwo);
                }

                handValue[3] = CardsToValueConverter(splitHand[0].Substring(0, 1));
            }

            if (HasThreeOfKind)
            {
                var cardValue = counter.FirstOrDefault(card => card.Value == 3);
                handValue[0] = 17;
                handValue[1] = CardsToValueConverter(cardValue.Key);

                for (int i = 0; i < cardValue.Value; i++)
                {
                    var index = splitHand.FindIndex(pair => pair.Contains(cardValue.Key));
                    splitHand.RemoveAt(index);
                }

                handValue[3] = CardsToValueConverter(splitHand[1].Substring(0, 1));
                handValue[4] = CardsToValueConverter(splitHand[0].Substring(0, 1));
            }

            if (HasFullHouse)
            {
                handValue[0] = 20;
                handValue[1] = CardsToValueConverter(counter.FirstOrDefault(card => card.Value == 3).Key);
                handValue[2] = CardsToValueConverter(counter.FirstOrDefault(card => card.Value == 2).Key);
            }

            if (HasFourOfKind)
            {
                var cardValue = counter.FirstOrDefault(card => card.Value == 4);
                handValue[0] = 21;
                handValue[1] = CardsToValueConverter(cardValue.Key);

                for (int i = 0; i < cardValue.Value; i++)
                {
                    var index = splitHand.FindIndex(pair => pair.Contains(cardValue.Key));
                    splitHand.RemoveAt(index);
                }

                handValue[3] = CardsToValueConverter(splitHand[0].Substring(0, 1));
            }

            return handValue;
        }

        public static bool HasSameSuits(string hand)
        {
            var hasFourSameSuit = hand.Count(h => h == 'H') == 5 ||
                hand.Count(d => d == 'D') == 5 ||
                hand.Count(c => c == 'C') == 5 ||
                hand.Count(s => s == 'S') == 5;

            if (hasFourSameSuit)
                return true;

            return false;
        }

        public static int[] ConsecutiveCards(string hand)
        {
            const string straightOne = "23456789TJQKA";
            const string straightTwo = "2345A";
            const string royal = "TJQKA";
            var handValue = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            var cardsNoSuit = hand.Replace("H", "").Replace("D", "").Replace("C", "").Replace("S", "");

            if (straightOne.Contains(cardsNoSuit) || straightTwo.Contains(cardsNoSuit))
            {
                handValue[0] = 18;
                handValue[1] = CardsToValueConverter(hand.Substring(8, 1));

                if (straightTwo.Contains(cardsNoSuit))
                    handValue[1] = CardsToValueConverter(hand.Substring(6, 1));

                if (HasSameSuits(hand))
                {
                    handValue[0] = 22;

                    if (royal.Contains(cardsNoSuit))
                    {
                        handValue[0] = 23;
                    }
                }
            }

            return handValue;
        }

        // Get Value of Player
        public static int[] HandValue(string playerCard)
        {
            var handValue = ConsecutiveCards(playerCard);
            if (handValue[0] != 0)
                return handValue;

            handValue = CountPairValue(playerCard);
            if (handValue[0] != 0)
                return handValue;

            if (HasSameSuits(playerCard))
            {
                handValue[0] = 19;
                handValue[1] = CardsToValueConverter(playerCard.Substring(8, 1));
                handValue[3] = CardsToValueConverter(playerCard.Substring(6, 1));
                handValue[4] = CardsToValueConverter(playerCard.Substring(4, 1));
                handValue[5] = CardsToValueConverter(playerCard.Substring(2, 1));
                handValue[6] = CardsToValueConverter(playerCard.Substring(0, 1));

                var cardsNoSuit = playerCard.Replace("H", "").Replace("D", "").Replace("C", "").Replace("S", "");
                if ("2345A".Contains(cardsNoSuit))
                    handValue[1] = CardsToValueConverter(playerCard.Substring(6, 1));

                return handValue;
            }

            handValue = HighestCard(playerCard);

            return handValue;
        }

        public static int[,] AllPlayersCardsValue(string[] playerCard)
        {
            int rounds = playerCard.Count();
            var playerGame = new int[rounds, 7];

            for (int i = 0; i < rounds; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    playerGame[i, j] = HandValue(playerCard[i])[j];
                }
            }

            return playerGame;
        }

        public static (string[], int, int, int) WinnerOfARound(int[,] playerOne, int[,] playerTwo)
        {
            // int[x,y]
            var x = playerOne.GetUpperBound(0) + 1;
            var y = playerOne.GetUpperBound(1) + 1;
            int winRatePlayerOne = 0, draw = 0, winRatePlayerTwo = 0;

            int valuePlayerOne = 0, valuePlayerTwo = 0;
            var winner = new string[x];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    valuePlayerOne = Convert.ToInt32(playerOne[i, j]);
                    valuePlayerTwo = Convert.ToInt32(playerTwo[i, j]);
                    winner[i] = "Draw";

                    if (valuePlayerOne > valuePlayerTwo)
                    {
                        winner[i] = "Player One";
                        winRatePlayerOne++;
                        break;
                    }

                    if (valuePlayerOne < valuePlayerTwo)
                    {
                        winner[i] = "Player Two";
                        winRatePlayerTwo++;
                        break;
                    }

                    if (j == y - 1 && valuePlayerOne == valuePlayerTwo)
                        draw++;
                }
            }

            return (winner, winRatePlayerOne, draw, winRatePlayerTwo);
        }

        public static int PlayerOneWins(string[] rounds)
        {
            var counter = 0;

            foreach (var winner in rounds)
            {
                if (winner == "Player One")
                    counter++;
            }

            return counter;
        }
    }
}
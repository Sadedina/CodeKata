using System;
using System.Collections.Generic;
using CodeKata;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CkTests_11
    {
        [Theory]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("\t")]
        public void ReadFile_ReturnsStringFormattedWithNoSpacesAndUpperCase(string invalidChar)
        {
            var file = CodeKata_11.ReadFile();

            file.Should().NotBe(string.Empty);
            file.Should().NotContain(invalidChar);
        }

        [Fact]
        public void ValidatePlayersHand_WhenValidHandIsGiven_NoExceptionisThrown()
        {
            var hand = "AD2D3D4D5D";

            var result = CodeKata_11.ValidatePlayersHand(hand);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("AD2D3D4D", "Not enough cards to play Poker")]
        [InlineData("AD2D3D4D5D6D", "Too many cards to play Poker")]
        [InlineData("AD2D3D4D5d", "Invalid set of cards")]
        [InlineData("AD2D3D34D", "Invalid set of cards")]
        [InlineData("0123456789", "Invalid set of cards")]
        [InlineData("abcdefghij", "Invalid set of cards")]
        public void ValidatePlayersHand_WhenInvalidHandIsGiven_ThrowsException(string hand, string message)
        {
            Action act = () => CodeKata_11.ValidatePlayersHand(hand);

            act.Should().Throw<InvalidOperationException>().WithMessage(message);
        }

        [Fact]
        public void SplitHandsToCards_ReturnsPlayerCardsSeperately()
        {
            var hand = "AD2D3D4D5D";

            var expectedCards = new string[] { "AD", "2D", "3D", "4D", "5D" };

            var result = CodeKata_11.SplitHandsToCards(hand);

            result.Should().NotBeEmpty();
            result.Should().HaveCount(5);
            result.Should().Contain(expectedCards);
            result[0].Should().BeEquivalentTo("AD");
        }

        [Theory]
        [InlineData("2C3C4C5CAD", "2C3C4C5CAD")]
        [InlineData("2C5C3CAC4C", "2C3C4C5CAC")]
        [InlineData("2CAD3CAC4C", "2C3C4CADAC")]
        [InlineData("2C7DJHACKS", "2C7DJHKSAC")]
        public void OrderCards_ReturnsCardInOrder(string hand, string expectedHand)
        {
            var result = CodeKata_11.OrderCards(hand);

            result.Should().Be(expectedHand);
        }

        [Fact]
        public void PlayerHand_ReturnsTwoDeckOfCards()
        {
            var file = "2C3C4C5CAC2C5C3CAC4C2CAD3CAC4C2C7DJHACKS";
            var expectedHand = new string[] { "2C3C4C5CAC", "2C3C4CADAC" };

            var result = CodeKata_11.PlayerHand(file);
            var playerOne = result.Item1;
            var playerTwo = result.Item2;

            playerOne.Should().HaveCount(2);
            playerOne.Should().BeEquivalentTo(expectedHand);
            playerTwo.Should().HaveCount(2);
            playerTwo[0].Should().Be("2C3C4C5CAC");
            playerTwo[1].Should().Be("2C7DJHKSAC");
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("7", 7)]
        [InlineData("T", 10)]
        [InlineData("J", 11)]
        [InlineData("Q", 12)]
        [InlineData("K", 13)]
        [InlineData("A", 14)]
        public void CardsToValueConverter_ReturnsValueOfCard(string card, int value)
        {
            var result = CodeKata_11.CardsToValueConverter(card);

            result.Should().Be(value);
        }

        [Fact]
        public void HighestCard_ReturnsValueOfHandWithHighestCard()
        {
            var hand = "2C3C4C5CAC";
            var expectedResult = new int[] { 14, 14, 0, 5, 4, 3, 2 };

            var result = CodeKata_11.HighestCard(hand);

            result.Should().HaveCount(7);
            result.Should().BeEquivalentTo(expectedResult);
        }


        [Theory]
        [MemberData(nameof(ValueHandOfPairs))]
        public void CountPairValue_ReturnsValueOfHandWithHighestCard(
            string hand,
            int value,
            int highPair,
            int lowPair,
            int highRemainderCard,
            int mediumRemainderCard,
            int lowRemainderCard,
            int lastRemainderCard)
        {
            var expectedResult = new int[]
            {
                value,
                highPair,
                lowPair,
                highRemainderCard,
                mediumRemainderCard,
                lowRemainderCard,
                lastRemainderCard,
            };

            var result = CodeKata_11.CountPairValue(hand);

            result.Should().HaveCount(7);
            result.Should().BeEquivalentTo(expectedResult);
        }


        [Theory]
        [InlineData("2C3C4C5CAC", true)]
        [InlineData("2C3D4H5SAC", false)]
        [InlineData("2C3C4C5CAD", false)]
        public void HasSameSuits_ReturnsCorrectBoolean(string hand, bool expectedResult)
        {
            var result = CodeKata_11.HasSameSuits(hand);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(ValueHandOfConsecutives))]
        public void ConsecutiveCards_ReturnsValueOfHandWithHighestCard(
            string hand,
            int value,
            int highPair)
        {
            var expectedResult = new int[]
            {
                value,
                highPair,
                0,
                0,
                0,
                0,
                0,
            };

            var result = CodeKata_11.ConsecutiveCards(hand);

            result.Should().HaveCount(7);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [MemberData(nameof(ValueHandOfDifferentHands))]
        public void HandValue_ReturnsValueOfHandWithHighestCard(
            string hand,
            int value,
            int highPair,
            int lowPair,
            int highRemainderCard,
            int mediumRemainderCard,
            int lowRemainderCard,
            int lastRemainderCard)
        {
            var expectedResult = new int[]
            {
                value,
                highPair,
                lowPair,
                highRemainderCard,
                mediumRemainderCard,
                lowRemainderCard,
                lastRemainderCard,
            };

            var result = CodeKata_11.HandValue(hand);

            result.Should().HaveCount(7);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void AllPlayersCardsValue_ReturnsPlayersValuedHands()
        {
            var playerHand = new string[]
            {
                "2C3C4S5D9C",
                "2C4C4H4DJC",
                "3D5D6D9DQD",
                "2C2D9C9S9H",
                "TSJSQSKSAS"
            };

            var expectedResult = new int[,]
            {
                { 9, 9, 0, 5, 4, 3, 2 },    // Highest 9
                { 17, 4, 0, 11, 2, 0, 0 },  // 3 of a Kind of 4s
                { 19, 12, 0, 9, 6, 5, 3 },  // Flush
                { 20, 9, 2, 0, 0, 0, 0 },   // 1 Pairs of 2s and 3 of Kind of 9s
                { 23, 14, 0, 0, 0, 0, 0 }   // Royal Flush
            };

            var result = CodeKata_11.AllPlayersCardsValue(playerHand);

            result.Should().BeOfType<int[,]>();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void WinnerOfARound_ReturnsWinnerOfTheRound()
        {
            var playerOneHand = new int[,]
            {
                { 15, 13, 0, 5, 3, 2, 0 },
                { 17, 11, 0, 10, 2, 0, 0 },
                { 19, 11, 0, 9, 7, 5, 2 },
                {  7, 7, 0, 5, 4, 3, 2 },
                { 19, 12, 0, 9, 6, 5, 3 }
            };
            var playerTwoHand = new int[,]
            {
                { 15, 5, 0, 13, 3, 2, 0 },
                { 16, 14, 12, 2, 0, 0, 0 },
                { 20, 3, 10, 0, 0, 0, 0 },
                { 7, 7, 0, 5, 4, 3, 2 },
                { 17, 4, 0, 11, 2, 0, 0 }
            };
            var expectedResult = new string[]
            {
                "Player One",
                "Player One",
                "Player Two",
                "Draw",
                "Player One"
            };

            var result = CodeKata_11.WinnerOfARound(playerOneHand, playerTwoHand).Item1;

            result.Should().BeOfType<string[]>();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void PlayerOneWins_ReturnsNumberOfPlayerOneWins()
        {
            var winners = new string[]
            {
                "Player One",
                "Player One",
                "Player Two",
                "Draw",
                "Player One"
            };
            var expectedNumber = 3;

            var result = CodeKata_11.PlayerOneWins(winners);

            result.Should().Be(expectedNumber);
        }

        public static IEnumerable<object[]> ValueHandOfPairs =>
        new List<object[]>
        {
            new object[] { "2C3C4C5CAC", 0, 0, 0, 0, 0, 0, 0 },     // No Pairs
            new object[] { "2C3C5C5DKC", 15, 5, 0, 13, 3, 2, 0 },   // 1 Pair of 5s
            new object[] { "2C2D5C5DQC", 16, 5, 2, 12, 0, 0, 0 },   // 2 Pairs of 5s and 2s
            new object[] { "2CTCTHTDJC", 17, 10, 0, 11, 2, 0, 0 },  // 3 of a Kind of Ts
            new object[] { "3C3D3HTSTH", 20, 3, 10, 0, 0, 0, 0 },   // 1 Pairs of Ts and 3 of Kind of 3s
            new object[] { "3C3D3H3SJH", 21, 3, 0, 11, 0, 0, 0 },   // 4 of a Kind of 3s
        };

        public static IEnumerable<object[]> ValueHandOfConsecutives =>
        new List<object[]>
        {
            new object[] { "2C4C6CTCAC", 0, 0 },     // No Straights
            new object[] { "2C3C5C6D7C", 0, 0 },     // No Straights
            new object[] { "2C3D4C5SAH", 18, 5 },    // Straights with A-5
            new object[] { "3H4C5H6D7C", 18, 7 },    // Straights with 3-7
            new object[] { "TCJCQHKDAS", 18, 14 },   // Straights with T-A
            new object[] { "2C3C4C5CAC", 22, 5 },    // Straights Flush with A-5
            new object[] { "3S4S5S6S7S", 22, 7 },    // Straights Flush with 3-7
            new object[] { "9STSJSQSKS", 22, 13 },   // Straights Flush with 9-K
            new object[] { "TSJSQSKSAS", 23, 14 }     // Royal Flush
        };

        public static IEnumerable<object[]> ValueHandOfDifferentHands =>
        new List<object[]>
        {
            new object[] { "2C3C4S5D7C", 7, 7, 0, 5, 4, 3, 2 },     // Highest 7
            new object[] { "2C3C6STDKC", 13, 13, 0, 10, 6, 3, 2 },  // Highest K
            new object[] { "2C3C6S9DAC", 14, 14, 0, 9, 6, 3, 2 },   // Highest A
            new object[] { "2C3C5CKDKC", 15, 13, 0, 5, 3, 2, 0 },   // 1 Pair of Ks
            new object[] { "2CQDQCADAC", 16, 14, 12, 2, 0, 0, 0 },  // 2 Pairs of Qs and As
            new object[] { "2CTCJHJDJC", 17, 11, 0, 10, 2, 0, 0 },  // 3 of a Kind of Js
            new object[] { "TCJCQHKDAS", 18, 14, 0, 0, 0, 0, 0 },   // Straights with T-A
            new object[] { "2C5C7C9CJC", 19, 11, 0, 9, 7, 5, 2 },   // Flush
            new object[] { "QCQDQHASAH", 20, 12, 14, 0, 0, 0, 0 },  // 1 Pairs of As and 3 of Kind of Qs
            new object[] { "3CTDTHTSTC", 21, 10, 0, 3, 0, 0, 0 },   // 4 of a Kind of Ts          
            new object[] { "9HTHJHQHKH", 22, 13, 0, 0, 0, 0, 0 },   // Straights Flush with 9-K
            new object[] { "TCJCQCKCAC", 23, 14, 0, 0, 0, 0, 0 }    // Royal Flush
        };
    }
}
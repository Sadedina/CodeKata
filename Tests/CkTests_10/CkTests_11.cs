using System;
using System.Collections.Generic;
using CodeKata;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CkTests_11
    {
        /*  ==================================== Test Case Contents =======================================
         *
         *  1 - 
         *  2 - 
         *  3 - 
         *  3 - 
         */


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
            var expectedResult = new string[] { "14", "14", null, "5", "4", "3", "2" };

            var result = CodeKata_11.HighestCard(hand);

            result.Should().HaveCount(7);
            result.Should().BeEquivalentTo(expectedResult);
        }


        [Theory]
        [InlineData()]
        public void CountPairValue_ReturnsValueOfHandWithHighestCard()
        {
            var hand = "2C3C4C5CAC";
            var expectedResult = new string[] { "14", "14", null, "5", "4", "3", "2" };

            var result = CodeKata_11.HighestCard(hand);

            result.Should().HaveCount(7);
            result.Should().BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> ValueHand =>
        new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };
    }
}
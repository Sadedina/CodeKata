using SoftwareCrafters.Module_5;
using SoftwareCrafters.Module_5.Models_RockPaperScissors;

namespace Tests.SoftwareCrafters.Tests.Module_5;

[TestFixture]
public class RockPaperScissors_Tests
{
    [TestCase(Hand.Rock, Hand.Rock)]
    [TestCase(Hand.Paper, Hand.Paper)]
    [TestCase(Hand.Scissors, Hand.Scissors)]
    public void Game_GivenOneRoundWherePlayersHandAreTheSame_ReturnsDraw(Hand playerOne, Hand playerTwo)
    {
        var rounds = new List<Hand[]>()
        {
            new Hand[] { playerOne, playerTwo }
        };
        var expectedOutcome = RoundOutcome.Draw;

        // Game needs to have a winner
        //var result = RockPaperScissors.Game(rounds);

        //Assert.AreEqual(expectedOutcome, result);
    }

    [TestCase(Hand.Rock, Hand.Scissors)]
    [TestCase(Hand.Paper, Hand.Rock)]
    [TestCase(Hand.Scissors, Hand.Paper)]
    public void Game_GivenARoundWherePlayerOneDefeatsPlayerTwo_ReturnsPlayerOne(Hand playerOne, Hand playerTwo)
    {
        var sameHand = Hand.Rock;
        var rounds = new List<Hand[]>()
        {
            new Hand[] { playerOne, playerTwo },
            new Hand[] { sameHand, sameHand },
            new Hand[] { sameHand, sameHand }
        };
        var expectedOutcome = RoundOutcome.PlayerOne;

        var play = new RockPaperScissors();
        var result = play.Game(rounds);

        Assert.AreEqual(expectedOutcome, result);
    }

    [TestCase(Hand.Paper, Hand.Scissors)]
    [TestCase(Hand.Scissors, Hand.Rock)]
    [TestCase(Hand.Rock, Hand.Paper)]
    public void Game_GivenARoundWherePlayerTwoDefeatsPlayerOne_ReturnsPlayerOne(Hand playerOne, Hand playerTwo)
    {
        var sameHand = Hand.Rock;
        var rounds = new List<Hand[]>()
        {
            new Hand[] { playerOne, playerTwo },
            new Hand[] { sameHand, sameHand },
            new Hand[] { sameHand, sameHand }
        };
        var expectedOutcome = RoundOutcome.PlayerTwo;

        var play = new RockPaperScissors();
        var result = play.Game(rounds);

        Assert.AreEqual(expectedOutcome, result);
    }

    [TestCase(Hand.Paper, Hand.Scissors, RoundOutcome.PlayerTwo)]
    [TestCase(Hand.Rock, Hand.Scissors, RoundOutcome.PlayerOne)]
    public void Game_GivenFourRounds_ReturnsCorrectPlayer(
        Hand playerOne,
        Hand playerTwo,
        RoundOutcome expectedOutcome)
    {
        var winningHand = Hand.Rock;
        var losingHand = Hand.Scissors;
        var sameHand = Hand.Paper;
        var rounds = new List<Hand[]>()
        {
            new Hand[] { winningHand, losingHand },
            new Hand[] { losingHand, winningHand },
            new Hand[] { sameHand, sameHand },
            new Hand[] { playerOne, playerTwo }
        };

        var play = new RockPaperScissors();
        var result = play.Game(rounds);

        Assert.AreEqual(expectedOutcome, result);
    }
}
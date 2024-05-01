using SoftwareCrafters.Module_3;
using SoftwareCrafters.Module_3.Enum;

namespace Tests.SoftwareCrafters.Tests.Module_3;

[TestFixture]
public class BoardGame_Tests
{
    [TestCaseSource(nameof(PlayerXWins))]
    public void Game_ReturnsGamesOutcome(PlayerType[] player, GameResult expectedWinner)
    {
        var result = BoardGame.TicTacToeEvaluatorGame(player);

        Assert.AreEqual(expectedWinner, result);
    }

    public static object[] PlayerXWins =
    {
        new object[]
        {
            new PlayerType[] { PlayerType.Player_X, PlayerType.Player_X, PlayerType.Player_X, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None },
            GameResult.Player_X
        },
        new object[]
        {
            new PlayerType[] { PlayerType.Player_O, PlayerType.Player_O, PlayerType.Player_O, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None },
            GameResult.Player_O
        },
        new object[]
        {
            new PlayerType[] { PlayerType.Player_X, PlayerType.Player_O, PlayerType.Player_O, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None, PlayerType.None },
            GameResult.Draw
        }
    };
}
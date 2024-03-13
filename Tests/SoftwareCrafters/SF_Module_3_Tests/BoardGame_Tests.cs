using NUnit.Framework;
using SoftwareCrafters.SF_Module_3;
using SoftwareCrafters.SF_Module_3.Enum;

namespace Tests.SoftwareCrafters.SF_Module_3_Tests;

[TestFixture]
public class BoardGame_Tests
{
    // Array available
    // Player[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8 }
    //
    //    0   |   1   |   2
    //  ----------------------
    //    3   |   4   |   5
    //  ----------------------
    //    6   |   7   |   8
    //
    // For any player to win they must occupy either:
    //      * 0, 1 & 2
    //      * 3, 4 & 5
    //      * 6, 7 & 8
    //      * 0, 3 & 6
    //      * 1, 4 & 7
    //      * 2, 5 & 8
    //      * 0, 4 & 8
    //      * 2, 4 & 6

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
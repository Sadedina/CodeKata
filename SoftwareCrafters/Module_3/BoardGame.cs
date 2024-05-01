using SoftwareCrafters.Module_3.Enum;

namespace SoftwareCrafters.Module_3;

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

public static class BoardGame
{
    private static readonly List<int[]> WinningPositions = WinningLines();

    public static GameResult TicTacToeEvaluatorGame(PlayerType[] player)
    {
        if (player.Length != 9)
            throw new ArgumentException();

        foreach (var winningPosition in WinningPositions
                     .Where(winningPosition => EvaluateThreeInARow(player, winningPosition)))
        {
            return player[winningPosition[0]] == PlayerType.Player_O
                ? GameResult.Player_O
                : GameResult.Player_X;
        }

        return GameResult.Draw;
    }

    private static List<int[]> WinningLines()
    {
        return new()
        {
            new[] {0, 1, 2},
            new[] {3, 4, 5},
            new[] {6, 7, 8},
            new[] {0, 3, 6},
            new[] {1, 4, 7},
            new[] {2, 5, 8},
            new[] {0, 4, 8},
            new[] {2, 4, 6}
        };
    }

    private static bool EvaluateThreeInARow(PlayerType[] player, int[] position)
    {
        var p1 = position[0];
        var p2 = position[1];
        var p3 = position[2];

        var sameSymbolInARow = player[p1] == player[p2]
                               && player[p1] == player[p3]
                               && player[p1] != PlayerType.None;

        return sameSymbolInARow;
    }
}
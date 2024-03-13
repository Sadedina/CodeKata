/*
                                                
                                            Tic Tac Toe
   Rules:
      - X always goes first
      - Players alternate placing Xs and Os on the board until either:
          - One player has three in a row, horizontally, vertically or diagonally
          * All nine squares are filled
   
      * If a player is able to draw three Xs or three Os in a row, that player wins
      * If all nine squares are filled and neither player has three in a row, the game is a draw
*/

using SoftwareCrafters.SF_Module_3.Enum;

namespace SoftwareCrafters.SF_Module_3;

public static class BoardGame
{
    private static readonly List<int[]> WinningPositions = new List<int[]>
    {
        new []{ 0, 1, 2 },
        new []{ 3, 4, 5 },
        new []{ 6, 7, 8 },
        new []{ 0, 3, 6 },
        new []{ 1, 4, 7 },
        new []{ 2, 5, 8 },
        new []{ 0, 4, 8 },
        new []{ 2, 4, 6 }
    };

    public static GameResult TicTacToeEvaluatorGame(PlayerType[] player)
    {
        if (player.Length != 9)
            throw new ArgumentException();

        foreach (var position in WinningPositions)
        {
            var p1 = position[0];
            var p2 = position[1];
            var p3 = position[2];

            var sameSymbolInARow = player[p1] == player[p2]
                                   && player[p1] == player[p3]
                                   && player[p1] != PlayerType.None;

            if (sameSymbolInARow)
            {
                return player[p1] == PlayerType.Player_O
                    ? GameResult.Player_O
                    : GameResult.Player_X;
            }
        }

        return GameResult.Draw;
    }
}
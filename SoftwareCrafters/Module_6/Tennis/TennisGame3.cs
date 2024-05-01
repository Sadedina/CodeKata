namespace SoftwareCrafters.Module_6.Tennis;

public class TennisGame3 : ITennisGame
{
    private readonly string playerOne;
    private readonly string playerTwo;
    private int playerTwoScore;
    private int playerOneScore;

    public TennisGame3(string playerOne, string playerTwo)
        => (this.playerOne, this.playerTwo) = (playerOne, playerTwo);

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
            playerOneScore += 1;

        if (playerName == "player2")
            playerTwoScore += 1;
    }

    public string GetScore()
    {
        if (playerOneScore < 4 && playerTwoScore < 4 && playerOneScore + playerTwoScore < 6)
            return EvaluateScore();

        if (playerOneScore == playerTwoScore)
            return "Deuce";

        return EvaluateWinningPlayer();
    }

    private string EvaluateScore()
    {
        var points = new[] { "Love", "Fifteen", "Thirty", "Forty" };

        var score = points[playerOneScore];

        return playerOneScore == playerTwoScore
            ? score + "-All"
            : score + "-" + points[playerTwoScore];
    }

    private string EvaluateWinningPlayer()
    {
        var winningPlayer = playerOneScore > playerTwoScore
            ? playerOne
            : playerTwo;

        return ((playerOneScore - playerTwoScore) * (playerOneScore - playerTwoScore) == 1)
            ? "Advantage " + winningPlayer
            : "Win for " + winningPlayer;
    }
}
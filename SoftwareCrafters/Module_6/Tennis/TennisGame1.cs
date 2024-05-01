namespace SoftwareCrafters.Module_6.Tennis;

#region Original
//public class TennisGame1 : ITennisGame
//{
//    private int m_score1 = 0;
//    private int m_score2 = 0;
//    private string player1Name;
//    private string player2Name;

//    public TennisGame1(string player1Name, string player2Name)
//    {
//        this.player1Name = player1Name;
//        this.player2Name = player2Name;
//    }

//    public void WonPoint(string playerName)
//    {
//        if (playerName == "player1")
//            m_score1 += 1;
//        else
//            m_score2 += 1;
//    }

//    public string GetScore()
//    {
//        string score = "";
//        var tempScore = 0;
//        if (m_score1 == m_score2)
//        {
//            switch (m_score1)
//            {
//                case 0:
//                    score = "Love-All";
//                    break;
//                case 1:
//                    score = "Fifteen-All";
//                    break;
//                case 2:
//                    score = "Thirty-All";
//                    break;
//                default:
//                    score = "Deuce";
//                    break;

//            }
//        }
//        else if (m_score1 >= 4 || m_score2 >= 4)
//        {
//            var minusResult = m_score1 - m_score2;
//            if (minusResult == 1) score = "Advantage player1";
//            else if (minusResult == -1) score = "Advantage player2";
//            else if (minusResult >= 2) score = "Win for player1";
//            else score = "Win for player2";
//        }
//        else
//        {
//            for (var i = 1; i < 3; i++)
//            {
//                if (i == 1) tempScore = m_score1;
//                else { score += "-"; tempScore = m_score2; }
//                switch (tempScore)
//                {
//                    case 0:
//                        score += "Love";
//                        break;
//                    case 1:
//                        score += "Fifteen";
//                        break;
//                    case 2:
//                        score += "Thirty";
//                        break;
//                    case 3:
//                        score += "Forty";
//                        break;
//                }
//            }
//        }
//        return score;
//    }
//}
#endregion

public class TennisGame1 : ITennisGame
{
    private readonly string playerOne;
    private readonly string playerTwo;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;

    public TennisGame1(string playerOne, string playerTwo)
    {
        this.playerOne = playerOne;
        this.playerTwo = playerTwo;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == playerOne)
            scorePlayerOne += 1;

        if (playerName == playerTwo)
            scorePlayerTwo += 1;
    }

    public string GetScore()
    {
        if (scorePlayerOne == scorePlayerTwo)
            return EvaluateSameScore();

        if (scorePlayerOne >= 4 || scorePlayerTwo >= 4)
            return EvaluateWinningPlayer();

        return EvaluateScore(scorePlayerOne) + "-" + EvaluateScore(scorePlayerTwo);
    }

    private string EvaluateSameScore()
    {
        if (scorePlayerOne == 0)
            return "Love-All";

        if (scorePlayerOne == 1)
            return "Fifteen-All";

        if (scorePlayerOne == 2)
            return "Thirty-All";

        return "Deuce";
    }

    private string EvaluateWinningPlayer()
    {
        var scoreDifference = scorePlayerOne - scorePlayerTwo;

        if (scoreDifference == 1)
            return "Advantage player1";

        if (scoreDifference == -1)
            return "Advantage player2";

        if (scoreDifference >= 2)
            return "Win for player1";

        return "Win for player2";
    }

    private static string EvaluateScore(int score)
    {
        if (score == 0)
            return "Love";

        if (score == 1)
            return "Fifteen";

        if (score == 2)
            return "Thirty";

        return "Forty";
    }
}
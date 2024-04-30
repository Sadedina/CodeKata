namespace SoftwareCrafters.SF_Module_6.Tennis;

#region Original
//public class TennisGame2 : ITennisGame
//{
//    private int p1point;
//    private int p2point;

//    private string p1res = "";
//    private string p2res = "";
//    private string player1Name;
//    private string player2Name;

//    public TennisGame2(string player1Name, string player2Name)
//    {
//        this.player1Name = player1Name;
//        p1point = 0;
//        this.player2Name = player2Name;
//    }

//    public string GetScore()
//    {
//        var score = "";
//        if (p1point == p2point && p1point < 3)
//        {
//            if (p1point == 0)
//                score = "Love";
//            if (p1point == 1)
//                score = "Fifteen";
//            if (p1point == 2)
//                score = "Thirty";
//            score += "-All";
//        }
//        if (p1point == p2point && p1point > 2)
//            score = "Deuce";

//        if (p1point > 0 && p2point == 0)
//        {
//            if (p1point == 1)
//                p1res = "Fifteen";
//            if (p1point == 2)
//                p1res = "Thirty";
//            if (p1point == 3)
//                p1res = "Forty";

//            p2res = "Love";
//            score = p1res + "-" + p2res;
//        }
//        if (p2point > 0 && p1point == 0)
//        {
//            if (p2point == 1)
//                p2res = "Fifteen";
//            if (p2point == 2)
//                p2res = "Thirty";
//            if (p2point == 3)
//                p2res = "Forty";

//            p1res = "Love";
//            score = p1res + "-" + p2res;
//        }

//        if (p1point > p2point && p1point < 4)
//        {
//            if (p1point == 2)
//                p1res = "Thirty";
//            if (p1point == 3)
//                p1res = "Forty";
//            if (p2point == 1)
//                p2res = "Fifteen";
//            if (p2point == 2)
//                p2res = "Thirty";
//            score = p1res + "-" + p2res;
//        }
//        if (p2point > p1point && p2point < 4)
//        {
//            if (p2point == 2)
//                p2res = "Thirty";
//            if (p2point == 3)
//                p2res = "Forty";
//            if (p1point == 1)
//                p1res = "Fifteen";
//            if (p1point == 2)
//                p1res = "Thirty";
//            score = p1res + "-" + p2res;
//        }

//        if (p1point > p2point && p2point >= 3)
//        {
//            score = "Advantage player1";
//        }

//        if (p2point > p1point && p1point >= 3)
//        {
//            score = "Advantage player2";
//        }

//        if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
//        {
//            score = "Win for player1";
//        }
//        if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
//        {
//            score = "Win for player2";
//        }
//        return score;
//    }

//    public void SetP1Score(int number)
//    {
//        for (int i = 0; i < number; i++)
//        {
//            P1Score();
//        }
//    }

//    public void SetP2Score(int number)
//    {
//        for (var i = 0; i < number; i++)
//        {
//            P2Score();
//        }
//    }

//    private void P1Score()
//    {
//        p1point++;
//    }

//    private void P2Score()
//    {
//        p2point++;
//    }

//    public void WonPoint(string player)
//    {
//        if (player == "player1")
//            P1Score();
//        else
//            P2Score();
//    }
//}
#endregion

public class TennisGame2 : ITennisGame
{
    private int pointPlayerOne;
    private int pointPlayerTwo;

    private string p1res = "";
    private string p2res = "";

    public TennisGame2(string playerOne, string playerTwo)
    {
    }

    public string GetScore()
    {
        if (pointPlayerOne == pointPlayerTwo)
            return EvaluateSameScore();

        if (pointPlayerOne <= 3 && pointPlayerTwo == 0)
            return EvaluateScore(pointPlayerOne) + "-Love";

        if (pointPlayerTwo <= 3 && pointPlayerOne == 0)
            return "Love-" + EvaluateScore(pointPlayerTwo);

        var score = "";
        if (pointPlayerOne > pointPlayerTwo && pointPlayerOne < 4)
        {
            if (pointPlayerOne == 2)
                p1res = "Thirty";
            if (pointPlayerOne == 3)
                p1res = "Forty";
            if (pointPlayerTwo == 1)
                p2res = "Fifteen";
            if (pointPlayerTwo == 2)
                p2res = "Thirty";
            score = p1res + "-" + p2res;
        }

        if (pointPlayerTwo > pointPlayerOne && pointPlayerTwo < 4)
        {
            if (pointPlayerTwo == 2)
                p2res = "Thirty";
            if (pointPlayerTwo == 3)
                p2res = "Forty";
            if (pointPlayerOne == 1)
                p1res = "Fifteen";
            if (pointPlayerOne == 2)
                p1res = "Thirty";
            score = p1res + "-" + p2res;
        }

        if (pointPlayerOne > pointPlayerTwo && pointPlayerTwo >= 3)
        {
            score = "Advantage player1";
        }

        if (pointPlayerTwo > pointPlayerOne && pointPlayerOne >= 3)
        {
            score = "Advantage player2";
        }

        if (pointPlayerOne >= 4 && pointPlayerTwo >= 0 && (pointPlayerOne - pointPlayerTwo) >= 2)
        {
            score = "Win for player1";
        }

        if (pointPlayerTwo >= 4 && pointPlayerOne >= 0 && (pointPlayerTwo - pointPlayerOne) >= 2)
        {
            score = "Win for player2";
        }
        return score;
    }



    private string EvaluateSameScore()
    {
        if (pointPlayerOne == 0)
            return "Love-All";

        if (pointPlayerOne == 1)
            return "Fifteen-All";

        if (pointPlayerOne == 2)
            return "Thirty-All";

        return "Deuce";
    }

    private static string EvaluateScore(int score)
    {
        if (score == 1)
            return "Fifteen";

        if (score == 2)
            return "Thirty";

        return "Forty";
    }

    public void SetP1Score(int number)
    {
        for (int i = 0; i < number; i++)
        {
            P1Score();
        }
    }

    public void SetP2Score(int number)
    {
        for (var i = 0; i < number; i++)
        {
            P2Score();
        }
    }

    private void P1Score()
    {
        pointPlayerOne++;
    }

    private void P2Score()
    {
        pointPlayerTwo++;
    }

    public void WonPoint(string player)
    {
        if (player == "player1")
            P1Score();
        else
            P2Score();
    }
}
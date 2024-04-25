using SoftwareCrafters.SF_Module_5.Models_RockPaperScissors;

namespace SoftwareCrafters.SF_Module_5;

public class RockPaperScissors
{
    private Dictionary<RoundOutcome, int> Result = new()
    {
        {RoundOutcome.Draw, 0},
        {RoundOutcome.PlayerOne, 0},
        {RoundOutcome.PlayerTwo, 0}
    };

    public RoundOutcome Game(IEnumerable<Hand[]> rounds)
    {
        var outcome = RoundOutcome.Draw;
        var roundCount = 0;

        foreach (var round in rounds)
        {
            Result[PlayersOutcomeWinner(round)]++;
            roundCount++;

            if (roundCount > 2)
                outcome = EvaluateWinner();

            if (outcome != RoundOutcome.Draw)
                break;
        }

        return outcome;
    }

    private RoundOutcome PlayersOutcomeWinner(Hand[] round)
    {
        if (round[0] == round[1])
            return RoundOutcome.Draw;

        if (HasPlayerOneWon(round))
            return RoundOutcome.PlayerOne;

        return RoundOutcome.PlayerTwo;
    }

    private bool HasPlayerOneWon(Hand[] round)
    {
        return round[0] == Hand.Rock && round[1] == Hand.Scissors
             || round[0] == Hand.Paper && round[1] == Hand.Rock
             || round[0] == Hand.Scissors && round[1] == Hand.Paper;
    }

    private RoundOutcome EvaluateWinner()
    {
        var roundsPlayerOneWon = Result[RoundOutcome.PlayerOne];
        var roundsPlayerTwoWon = Result[RoundOutcome.PlayerTwo];

        if (roundsPlayerOneWon == roundsPlayerTwoWon)
            return RoundOutcome.Draw;

        if (roundsPlayerOneWon > roundsPlayerTwoWon)
            return RoundOutcome.PlayerOne;

        return RoundOutcome.PlayerTwo;
    }
}
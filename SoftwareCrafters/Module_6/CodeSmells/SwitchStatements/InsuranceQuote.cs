namespace SoftwareCrafters.Module_6.CodeSmells.SwitchStatements;

#region Original
//public class InsuranceQuote
//{
//    private readonly Motorist motorist;

//    public InsuranceQuote(Motorist motorist)
//    {
//        this.motorist = motorist;
//    }

//    public RiskFactor CalculateMotoristRisk()
//    {
//        if (motorist.PointsOnLicense > 3 || motorist.Age < 25)
//        {
//            return RiskFactor.HIGH_RISK;
//        }

//        if (motorist.PointsOnLicense > 0)
//        {
//            return RiskFactor.MODERATE_RISK;
//        }

//        return RiskFactor.LOW_RISK;
//    }

//    public double CalculateInsurancePremium(double insuranceValue)
//    {
//        var riskFactor = CalculateMotoristRisk();

//        switch (riskFactor)
//        {
//            case RiskFactor.LOW_RISK:
//                return insuranceValue * 0.02;
//            case RiskFactor.MODERATE_RISK:
//                return insuranceValue * 0.04;
//            default:
//                return insuranceValue * 0.06;
//        }
//    }
//}
#endregion

public class InsuranceQuote
{
    private readonly Motorist motorist;

    public InsuranceQuote(Motorist motorist) => this.motorist = motorist;

    public double CalculateInsurancePremium(double insuranceValue)
    {
        var riskFactor = CalculateMotoristRisk();

        if (riskFactor == RiskFactor.LOW_RISK)
            return insuranceValue * 0.02;

        if (riskFactor == RiskFactor.MODERATE_RISK)
            return insuranceValue * 0.04;

        return insuranceValue * 0.06;
    }

    public RiskFactor CalculateMotoristRisk()
    {
        if (motorist.PointsOnLicense > 3 || motorist.Age < 25)
            return RiskFactor.HIGH_RISK;

        if (motorist.PointsOnLicense > 0)
            return RiskFactor.MODERATE_RISK;

        return RiskFactor.LOW_RISK;
    }
}
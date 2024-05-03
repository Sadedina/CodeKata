namespace SoftwareCrafters.Module_6.CodeSmells.InappropriateIntimacy;

public class Motorist
{
    public License license;

    public Motorist(License license) => this.license = license;

    public RiskFactor RiskFactor => CalculateRisckFactor();

    private RiskFactor CalculateRisckFactor()
    {
        if (license.Points > 3)
            return RiskFactor.HIGH_RISK;

        if (license.Points > 0)
            return RiskFactor.MODERATE_RISK;

        return RiskFactor.LOW_RISK;
    }
}
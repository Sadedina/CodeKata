using System;
using NUnit.Framework;
using SoftwareCrafters.Module_6.CodeSmells.SwitchStatements;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.SwitchStatements_Tests;

[TestFixture]
public class InsuranceQuotationTests
{
    [Test]
    public void AnyMotoristUnderTwentyFiveIsHighRisk()
        => Assert.That(RiskFactor.HIGH_RISK, Is.EqualTo(CalculateMotoristRisk("2005-01-01", 0)));

    [Test]
    public void HighRiskMotoristsPayPremiumOfSixPercentOfInsuranceValue()
    {
        var quote = BuildInsuranceQuoteForMotorist("1990-01-01", 5);
        Assert.That(600, Is.EqualTo(quote.CalculateInsurancePremium(10000)));
    }

    [Test]
    public void LowRiskMotoristsPayPremiumOfTwoPercentOfInsuranceValue()
    {
        var quote = BuildInsuranceQuoteForMotorist("1960-01-01", 0);
        Assert.That(200, Is.EqualTo(quote.CalculateInsurancePremium(10000)));
    }

    [Test]
    public void ModerateRiskMotoristsPayPremiumOfFourPercentOfInsuranceValue()
    {
        var quote = BuildInsuranceQuoteForMotorist("1960-01-01", 1);
        Assert.That(400, Is.EqualTo(quote.CalculateInsurancePremium(10000)));
    }

    [Test]
    public void MotoristWithMoreThanThreePointsOnLicenseOverTwentyFivePresentsHighRisk()
        => Assert.That(RiskFactor.HIGH_RISK, Is.EqualTo(CalculateMotoristRisk("1970-01-01", 4)));

    [Test]
    public void MotoristWithNoPointsOnLicenseAndOverTwentyFivePresentsLowRisk()
        => Assert.That(RiskFactor.LOW_RISK, Is.EqualTo(CalculateMotoristRisk("1970-01-01", 0)));

    [Test]
    public void MotoristWithOneToThreePointsOnLicenseAndOverTwentyFivePresentsModerateRisk()
        => Assert.That(RiskFactor.MODERATE_RISK, Is.EqualTo(CalculateMotoristRisk("1970-01-01", 3)));

    private static RiskFactor CalculateMotoristRisk(string dateOfBirth, int pointsOnLicense)
        => BuildInsuranceQuoteForMotorist(dateOfBirth, pointsOnLicense).CalculateMotoristRisk();

    private static InsuranceQuote BuildInsuranceQuoteForMotorist(string dateOfBirth, int pointsOnLicense)
        => new(new Motorist(ParseDate(dateOfBirth), pointsOnLicense));

    private static DateTime ParseDate(string dateOfBirth) => DateTime.Parse(dateOfBirth);
}
﻿using SoftwareCrafters.Module_6.CodeSmells.InappropriateIntimacy;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.InappropriateIntimacy_Tests;

#region Original
//[TestFixture]
//public class MotoristTests
//{
//    [Test]
//    public void MotoristWithMoreThanThreePointsOnLicenseIsHighRisk()
//        => Assert.That(RiskFactor.HIGH_RISK, Is.EqualTo(CreateMotoristWithPointsOnLicense(4).RiskFactor));

//    [Test]
//    public void MotoristWithNoPointsOnLicenseIsLowRisk()
//        => Assert.That(RiskFactor.LOW_RISK, Is.EqualTo(CreateMotoristWithPointsOnLicense(0).RiskFactor));

//    [Test]
//    public void MotoristWithOneToThreePointsOnLicenseIsModerateRisk()
//        => Assert.That(RiskFactor.MODERATE_RISK, Is.EqualTo(CreateMotoristWithPointsOnLicense(1).RiskFactor));

//    private static Motorist CreateMotoristWithPointsOnLicense(int points)
//    {
//        var license = new License();
//        license.addPoints(points);
//        var motorist = new Motorist(license, "", "", "");
//        return motorist;
//    }
//}
#endregion


[TestFixture]
public class MotoristTests
{
    [Test]
    public void MotoristWithMoreThanThreePointsOnLicenseIsHighRisk()
        => Assert.That(RiskFactor.HIGH_RISK, Is.EqualTo(CreateMotoristWithPointsOnLicense(4).RiskFactor));

    [Test]
    public void MotoristWithNoPointsOnLicenseIsLowRisk()
        => Assert.That(RiskFactor.LOW_RISK, Is.EqualTo(CreateMotoristWithPointsOnLicense(0).RiskFactor));

    [Test]
    public void MotoristWithOneToThreePointsOnLicenseIsModerateRisk()
        => Assert.That(RiskFactor.MODERATE_RISK, Is.EqualTo(CreateMotoristWithPointsOnLicense(1).RiskFactor));

    private static Motorist CreateMotoristWithPointsOnLicense(int points)
    {
        var license = new License();
        license.AddPoints(points);

        return new(license);
    }
}
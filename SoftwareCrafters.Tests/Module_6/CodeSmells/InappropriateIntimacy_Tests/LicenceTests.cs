using SoftwareCrafters.Module_6.CodeSmells.InappropriateIntimacy;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.InappropriateIntimacy_Tests;

#region
//[TestFixture]
//public class LicenseTests
//{
//    [Test]
//    public void LicenseSummaryShouldIncludeLicenseHolderFullNameAndPoints()
//    {
//        var license = new License();
//        license.AddPoints(3);
//        var motorist = new Motorist(license, "Gorman", "Jason", "Mr");
//        Assert.That("Mr Jason Gorman, 3 points", Is.EqualTo(license.Summary));
//    }
//}
#endregion

[TestFixture]
public class LicenseTests
{
    [Test]
    public void LicenseSummaryShouldIncludeLicenseHolderFullNameAndPoints()
    {
        var license = new License
        {
            Title = "Mr",
            Surname = "Gorman",
            FirstName = "Jason"
        };

        license.AddPoints(3);

        Assert.That("Mr Jason Gorman, 3 points", Is.EqualTo(license.Summary));
    }
}
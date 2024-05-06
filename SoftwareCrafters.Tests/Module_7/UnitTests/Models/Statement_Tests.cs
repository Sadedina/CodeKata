using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.UnitTests.Models;

public class Statement_Tests
{
    [Test]
    public void ToArray_GivenADeposit_ReturnsExpectedStrings()
    {
        var deposit = 500;
        var date = new DateTime(2012, 01, 14);

        var statement = new Statement(date, deposit, null, deposit);
        var expected = new string[] { "14/01/2012", "500.00", "0.00", "500.00" };

        Assert.AreEqual(expected, statement.ToArray());
    }

    [Test]
    public void ToArray_GivenAWithdrawal_ReturnsExpectedStrings()
    {
        decimal withdrawal = (decimal)50.86;
        var balance = -withdrawal;
        var date = new DateTime(1997, 11, 3);

        var statement = new Statement(date, null, withdrawal, balance);
        var expected = new string[] { "03/11/1997", "0.00", "50.86", "-50.86" };

        Assert.AreEqual(expected, statement.ToArray());
    }
}
using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7;

public class AccountStatement_Tests
{
    [Test]
    public void AddStatement_AddsToStatement()
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client);

        var date = new DateTime(2012, 01, 10);
        var statement = new Statement(date, null, null, 0);

        var account = new Account(details);
        account.AddStatement(statement);

        var expectedStatement = new string[] { "10/01/2012", "0.00", "0.00", "0.00" };

        Assert.Contains(expectedStatement, details.Statements);
    }

    [Test]
    public void GetStatement_ReturnsLog()
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client);

        var date = new DateTime(2012, 01, 10);
        var statement = new Statement(date, null, null, 0);

        var account = new Account(details);
        account.AddStatement(statement);
        var statements = account.GetStatement();

        var expectedStatement = new string[] { "10/01/2012", "0.00", "0.00", "0.00" };

        Assert.Contains(expectedStatement, statements);
    }
}
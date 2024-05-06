using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.UnitTests.Models;

public class AccountDetails_Tests
{
    [Test]
    public void AddLog_AddsToLog()
    {
        var message = "Test message";
        var client = new Client("Mr", "John", "Smith");
        var details = new AccountDetails(client);

        details.AddLog(message);

        Assert.Contains(message, details.Logs);
    }

    [Test]
    public void AddStatement_AddsToStatements()
    {
        var client = new Client("Mr", "John", "Smith");
        var details = new AccountDetails(client);

        var deposit = 500;
        var date = new DateTime(2012, 01, 14);
        var statement = new Statement(date, deposit, null, deposit);
        var expectedStatement = new string[] { "14/01/2012", "500.00", "0.00", "500.00" };

        details.AddStatement(statement);

        Assert.Contains(expectedStatement, details.Statements);
    }
}
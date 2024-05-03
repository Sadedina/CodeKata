using SoftwareCrafters.Module_6.CodeSmells.DuplicateCode;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.DuplicateCode_Tests;

[TestFixture]
public class TechnicalDebtShould
{
    [Test]
    public void AddAmountFromBalanceRecordTransactionAndUpdateLastDebitDate()
    {
        var account = new TechnicalDebt();
        account.Register(50, "Some technical debt");
        Assert.That(50, Is.EqualTo(account.Balance));

        var lastTransaction = account.LastTransaction;
        Assert.That(50, Is.EqualTo(lastTransaction.EffortManHours));

        var now = DateTime.Now;
        Assert.That(now.Date + "/" + now.Month + "/" + now.Year, Is.EqualTo(account.LastTransactionDate));
    }

    [Test]
    public void DeductAmountFromBalanceRecordTransactionAndUpdateLastdebitDate()
    {
        var account = new TechnicalDebt();
        account.Register(100, "Some technical debt");
        account.Fix(50, "Fix technical debt");

        Assert.That(50, Is.EqualTo(account.Balance));
        var lastTransaction = account.LastTransaction;

        Assert.That(-50, Is.EqualTo(lastTransaction.EffortManHours));

        var now = DateTime.Now;
        Assert.That(now.Date + "/" + now.Month + "/" + now.Year, Is.EqualTo(account.LastTransactionDate));
    }
}
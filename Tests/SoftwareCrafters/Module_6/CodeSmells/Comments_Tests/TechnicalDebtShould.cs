using System;
using NUnit.Framework;
using SoftwareCrafters.SF_Module_6.CodeSmells.Comments;

namespace Tests.SoftwareCrafters.SF_Module_6.CodeSmells.Comments_Tests;

[TestFixture]
public class TechnicalDebtShould
{
    private TechnicalDebt technicalDebt;

    [SetUp]
    public void BeforeEach() => technicalDebt = new TechnicalDebt();

    [Test]
    public void FixingIssueIssueDeductsEffortFromTotal()
    {
        technicalDebt.Register(50, "Declared Issue class in same file as TechnicalDebt class");

        technicalDebt.Fixed(50);

        Assert.That(0, Is.EqualTo(technicalDebt.Total));
    }

    [Test]
    public void RegisteringIssueIncreasesTotal()
    {
        technicalDebt.Register(50, "Declared Issue class in same file as TechnicalDebt class");

        Assert.That(50, Is.EqualTo(technicalDebt.Total));
    }

    [Test]
    public void RegisteringIssueUpdatesLastIssueDate()
    {
        technicalDebt.Register(50, "Declared Issue class in same file as TechnicalDebt class");

        var now = DateTime.Now;
        Assert.That(now.Date + "/" + now.Month + "/" + now.Year, Is.EqualTo(technicalDebt.LastIssueDate));
    }

    [Test]
    public void RegisteringMoreThanMaxAllowedEffortThrowsException()
        => Assert.Throws<ArgumentException>(() => technicalDebt.Register(1001, "The PM forced me to register this"));
}
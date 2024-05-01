using System;
using NUnit.Framework;
using SoftwareCrafters.Module_6.CodeSmells.LongMethods;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.LongMethods_Tests;

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
    public void RegisteringIssueWithEffortBiggerThanFiveHundredMarksItAsCriticalPriority()
    {
        technicalDebt.Register(501, "Declared Issue class in same file as TechnicalDebt class");

        Assert.That(Priority.Critical, Is.EqualTo(technicalDebt.LastIssue.Priority));
    }

    [Test]
    public void RegisteringIssueWithEffortBiggerThanTwoHundredAndFiftyMarksItAsHighPriority()
    {
        technicalDebt.Register(251, "Declared Issue class in same file as TechnicalDebt class");

        Assert.That(Priority.High, Is.EqualTo(technicalDebt.LastIssue.Priority));
    }

    [Test]
    public void RegisteringIssueWithEffortBiggerThanOneHundredMarksItAsHighPriority()
    {
        technicalDebt.Register(101, "Declared Issue class in same file as TechnicalDebt class");

        Assert.That(Priority.Medium, Is.EqualTo(technicalDebt.LastIssue.Priority));
    }

    [Test]
    public void RegisteringIssueWithEffortEqualOrLowerThanOneHundredMarksItAsLowPriority()
    {
        technicalDebt.Register(100, "Declared Issue class in same file as TechnicalDebt class");

        Assert.That(Priority.Low, Is.EqualTo(technicalDebt.LastIssue.Priority));
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

    [Test]
    public void RegisteringLessThanMinAllowedEffortThrowsException()
        => Assert.Throws<ArgumentException>(() => technicalDebt.Register(0, "The PM forced me to register this"));
}
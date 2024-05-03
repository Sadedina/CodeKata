using SoftwareCrafters.Module_6.CodeSmells.DataClasses;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.DataClasses_Tests;

#region Original
//[TestFixture]
//public class IssueSummaryViewShould
//{
//    [Test]
//    public void CustomerSummaryIncludesFullNameWithTitleAndCityPostCodeAndCountry()
//    {
//        var issue = new Issue(10, "Some critical issue", Priority.Critical);
//        var summary = new IssueSummarizer(issue).IssueSummary;

//        Assert.That("Description:'Some critical issue' Effort:'10' Priority:'Critical'", Is.EqualTo(summary));
//    }
//}
#endregion

[TestFixture]
public class IssueSummaryViewShould
{
    [Test]
    public void CustomerSummaryIncludesFullNameWithTitleAndCityPostCodeAndCountry()
    {
        var issue = new Issue(10, "Some critical issue", Priority.Critical);

        Assert.That("Description:'Some critical issue' Effort:'10' Priority:'Critical'", Is.EqualTo(issue.IssueSummary));
    }
}
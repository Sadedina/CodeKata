namespace SoftwareCrafters.Module_6.CodeSmells.DataClasses;

public class IssueSummarizer
{
    private readonly Issue issue;

    public IssueSummarizer(Issue issue)
    {
        this.issue = issue;
    }

    public string IssueSummary
    {
        get
        {
            return "Description:'" + issue.Description + "' Effort:'" + issue.EffortManHours + "' Priority:'" + issue.Priority + "'";
        }
    }
}
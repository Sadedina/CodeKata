namespace SoftwareCrafters.Module_6.CodeSmells.DataClasses;

#region Original
//public class Issue
//{
//    public float EffortManHours { get; set; }

//    public string Description { get; set; }

//    public Priority Priority { get; set; }

//    public Issue(float effortManHours, string description)
//    {
//        EffortManHours = effortManHours;
//        Description = description;
//    }

//    public Issue(float effortManHours, string description, Priority priority)
//        : this(effortManHours, description)
//    {
//        this.Priority = priority;
//    }
//}
#endregion

public class Issue
{
    private readonly float effortManHours;
    private readonly string description;
    private readonly Priority priority;

    public Issue(float effortManHours, string description, Priority priority)
    {
        this.effortManHours = effortManHours;
        this.description = description;
        this.priority = priority;
    }

    public string IssueSummary => IssueSummarizer();

    private string IssueSummarizer()
        => "Description:'" + description + "' Effort:'" + effortManHours + "' Priority:'" + priority + "'";
}
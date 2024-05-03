namespace SoftwareCrafters.Module_6.CodeSmells.LongMethods;

#region Original
//public class TechnicalDebt
//{
//    private readonly IList<Issue> issues = new List<Issue>();

//    public float Total { get; private set; }

//    public Issue LastIssue
//    {
//        get
//        {
//            return issues[(issues.Count - 1)];
//        }
//    }

//    public string LastIssueDate { get; private set; }

//    public void Fixed(float amount)
//    {
//        Total -= amount;
//    }

//    public void Register(float effortManHours, string description)
//    {
//        if (effortManHours > 1000 || effortManHours <= 0)
//        {
//            throw new ArgumentException("Cannot register tech debt where effort is bigger than 1000 man hours to fix");
//        }

//        var priority = Priority.Low;

//        if (effortManHours > 100)
//        {
//            priority = Priority.Medium;
//        }

//        if (effortManHours > 250)
//        {
//            priority = Priority.High;
//        }

//        if (effortManHours > 500)
//        {
//            priority = Priority.Critical;
//        }

//        Total += effortManHours;

//        issues.Add(new Issue(effortManHours, description, priority));

//        var now = DateTime.Now;
//        LastIssueDate = now.Date + "/" + now.Month + "/" + now.Year;
//    }
//}
#endregion

public class TechnicalDebt
{
    private readonly IList<Issue> issues = new List<Issue>();

    public float Total { get; private set; }
    public string LastIssueDate { get; private set; }
    public Issue LastIssue => issues[issues.Count - 1];

    public void Fixed(float amount) => Total -= amount;

    public void Register(float effortManHours, string description)
    {
        if (effortManHours is > 1000 or <= 0)
            throw new ArgumentException("Cannot register tech debt where effort is bigger than 1000 man hours to fix");

        Total += effortManHours;

        var priority = SetPriority(effortManHours);
        issues.Add(new Issue(effortManHours, description, priority));

        SetLastIssueDate();
    }

    private static Priority SetPriority(float effortManHours)
    {
        if (effortManHours is > 100 and <= 250)
            return Priority.Medium;

        if (effortManHours is > 250 and <= 500)
            return Priority.High;

        if (effortManHours > 500)
            return Priority.Critical;

        return Priority.Low;
    }

    private void SetLastIssueDate()
    {
        var now = DateTime.Now;
        LastIssueDate = now.Date + "/" + now.Month + "/" + now.Year;
    }
}
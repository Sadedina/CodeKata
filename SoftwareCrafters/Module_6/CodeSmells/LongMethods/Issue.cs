namespace SoftwareCrafters.Module_6.CodeSmells.LongMethods;

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
    public Issue(float effortManHours, string description, Priority? priority = null)
    {
        EffortManHours = effortManHours;
        Description = description;

        if (priority != null)
            Priority = (Priority)priority;
    }

    public float EffortManHours { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
}
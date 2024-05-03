namespace SoftwareCrafters.Module_6.CodeSmells.DuplicateCode;

#region Original
//public class Issue
//{
//    public float EffortManHours { get; set; }
//    public string Description { get; set; }

//    public Issue(float effortManHours, string description)
//    {
//        EffortManHours = effortManHours;
//        Description = description;
//    }
//}
#endregion

public class Issue
{
    public Issue(float effortManHours, string description)
    {
        EffortManHours = effortManHours;
        Description = description;
    }

    public float EffortManHours { get; set; }
    public string Description { get; set; }
}
namespace SoftwareCrafters.Module_6.CodeSmells.InappropriateIntimacy;

#region Original
//public class License
//{
//    private Motorist motorist;

//    public Motorist Motorist
//    {
//        set
//        {
//            motorist = value;
//        }
//    }

//    public int Points { get; private set; }

//    public string Summary
//    {
//        get
//        {
//            return motorist.Title + " " + motorist.FirstName + " " + motorist.Surname + ", " + Points + " points";
//        }
//    }

//    public void addPoints(int points)
//    {
//        this.Points += points;
//    }
//}
#endregion

public class License
{
    public string Title { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public int Points { get; private set; }
    public string Summary => LicenseToString();


    public void AddPoints(int points) => Points += points;

    private string LicenseToString()
        => Title + " " + FirstName + " " + Surname + ", " + Points + " points";
}
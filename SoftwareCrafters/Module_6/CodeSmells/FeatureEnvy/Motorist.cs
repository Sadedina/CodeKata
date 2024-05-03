namespace SoftwareCrafters.Module_6.CodeSmells.FeatureEnvy;

#region Original
//public class Motorist
//{
//    private DateTime dateOfBirth;

//    public Motorist(DateTime dateOfBirth, int pointsOnLicense)
//    {
//        this.PointsOnLicense = pointsOnLicense;
//        this.dateOfBirth = dateOfBirth;
//    }

//    public int PointsOnLicense { get; private set; }

//    public int Age
//    {
//        get
//        {
//            var now = DateTime.Now;
//            var ageYr = now.Year - dateOfBirth.Year;
//            var ageMo = now.Month - dateOfBirth.Month;
//            return adustYearsDownIfNegativeMonthDifference(ageYr, ageMo);
//        }
//    }

//    private int adustYearsDownIfNegativeMonthDifference(int ageYr, int ageMo)
//    {
//        if (ageMo < 0)
//        {
//            ageYr--;
//        }
//        return ageYr;
//    }
//}
#endregion

public class Motorist
{
    private readonly int pointsOnLicense;

    public Motorist(int pointsOnLicense) => this.pointsOnLicense = pointsOnLicense;

    public int PointsOnLicense => pointsOnLicense;
}
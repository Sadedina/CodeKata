namespace SoftwareCrafters.Module_6.CodeSmells.FeatureEnvy;

public class MotoristAge
{
    private readonly DateTime dateOfBirth;

    public MotoristAge(DateTime dateOfBirth) => this.dateOfBirth = dateOfBirth;

    public int Age => CalculateAge();

    private int CalculateAge()
    {
        var now = DateTime.Now;

        var age = now.Year - dateOfBirth.Year;

        var hasNotFullyCompletedLastYear = now.Month < dateOfBirth.Month;
        if (hasNotFullyCompletedLastYear)
            age--;

        return age;
    }
}
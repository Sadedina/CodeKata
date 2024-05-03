namespace SoftwareCrafters.Module_6.CodeSmells.SwitchStatements;

public class MotoristAge
{
    private readonly DateTime dateOfBirth;

    public MotoristAge(string dateOfBirth) => this.dateOfBirth = DateTime.Parse(dateOfBirth);

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
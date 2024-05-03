namespace SoftwareCrafters.Module_6.CodeSmells.MessageChains;

#region Original
//public class Country
//{
//    public Country(bool inEurope)
//    {
//        this.IsInEurope = inEurope;
//    }

//    public bool IsInEurope { get; private set; }
//}
#endregion

public class Country
{
    private readonly bool isInEurope;

    public Country(bool inEurope) => isInEurope = inEurope;

    public bool IsInEurope => isInEurope;
}
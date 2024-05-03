namespace SoftwareCrafters.Module_6.CodeSmells.MessageChains;

#region
//public class Address
//{
//    public Address(Country country)
//    {
//        this.Country = country;
//    }

//    public Country Country { get; private set; }
//}
#endregion

public class Address
{
    private readonly Country country;

    public Address(Country country) => this.country = country;

    public Country Country => country;
}
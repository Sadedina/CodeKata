namespace SoftwareCrafters.Module_6.CodeSmells.LongParametersLists;

#region Original
//public class Address
//{
//    public string City { get; set; }

//    public string Country { get; set; }

//    public string Postcode { get; set; }
//}
#endregion

public class Address
{
    public string City { get; set; }

    public string Country { get; set; }

    public string Postcode { get; set; }

    public string ToString()
        => City + ", " + Postcode + ", " + Country;
}
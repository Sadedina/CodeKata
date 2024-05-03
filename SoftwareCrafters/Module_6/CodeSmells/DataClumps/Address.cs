namespace SoftwareCrafters.Module_6.CodeSmells.DataClumps;

public class Address
{
    public string House { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }

    public string Summary => House + ", " + Street + ", " + City + ", " + PostCode + ", " + Country;
}
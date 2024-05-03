namespace SoftwareCrafters.Module_6.CodeSmells.LongParametersLists;

#region Original
//public class Customer
//{
//    public string FirstName { get; set; }

//    public string LastName { get; set; }

//    public string Title { get; set; }

//    public Address Address { get; set; }

//    public string Summary
//    {
//        get
//        {
//            return buildCustomerSummary(
//                FirstName,
//                LastName,
//                Title,
//                this.Address.City,
//                this.Address.Postcode,
//                this.Address.Country);
//        }
//    }

//    private string buildCustomerSummary(
//        string customerFirstName,
//        string customerLastName,
//        string customerTitle,
//        string customerCity,
//        string customerPostCode,
//        string customerCountry)
//    {
//        return customerTitle + " " + customerFirstName + " " + customerLastName + ", " + customerCity + ", "
//               + customerPostCode + ", " + customerCountry;
//    }
//}
#endregion

public class Customer
{
    public string Title { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public Address Address { get; set; }
    public string Summary => EvaluateSummary();

    private string EvaluateSummary() => CustomerToString() + ", " + Address.ToString();
    private string CustomerToString() => Title + " " + FirstName + " " + LastName;
}
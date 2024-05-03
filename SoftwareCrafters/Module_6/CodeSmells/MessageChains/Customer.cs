namespace SoftwareCrafters.Module_6.CodeSmells.MessageChains;

#region Original
//public class Customer
//{
//    public Customer(Address address)
//    {
//        this.Address = address;
//    }

//    public Address Address { get; private set; }
//}
#endregion

public class Customer
{
    private readonly Address address;

    public Customer(Address address) => this.address = address;

    public Address Address => address;
}
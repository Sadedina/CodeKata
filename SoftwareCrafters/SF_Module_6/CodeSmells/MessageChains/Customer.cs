namespace SoftwareCrafters.SF_Module_6.CodeSmells.MessageChains;

public class Customer
{
    public Customer(Address address)
    {
        this.Address = address;
    }

    public Address Address { get; private set; }
}
namespace SoftwareCrafters.Module_7.Models;

public class Client
{
    private readonly string title;
    private readonly string firstName;
    private readonly string lastName;
    private readonly int? age;

    public Client(
        string title,
        string firstName,
        string lastName,
        int? age = null)
    {
        this.title = title.ToUpper();
        this.firstName = firstName.ToUpper();
        this.lastName = lastName.ToUpper();
        this.age = age;
    }

    public string Title => title;
    public string FirstName => firstName;
    public string LastName => lastName;
    public int? Age => age;
}
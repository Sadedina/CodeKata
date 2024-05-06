namespace SoftwareCrafters.Module_7.Models;

public record Client
{
    private readonly string title;
    private readonly string firstName;
    private readonly string lastName;

    public Client(string title, string firstName, string lastName)
    {
        this.title = title;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public string Title => title;
    public string FirstName => firstName;
    public string LastName => lastName;

    public override string ToString() => $"{title} {lastName}";
}
namespace SoftwareCrafters.Module_7.Models;

public record AccountDetails
{
    private readonly List<string> logs = new();
    private readonly Client client;

    public AccountDetails(Client client) => this.client = client;

    public Client Client => client;
    public decimal Balance { get; set; } = 0;
    public List<string> Logs => logs;

    public void AddIntoLog(string message) => logs.Add(message);
}
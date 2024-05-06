namespace SoftwareCrafters.Module_7.Models;

public record AccountDetails
{
    private readonly List<string> logs = new();
    private readonly List<string[]> statements = new();
    private readonly Client client;

    public AccountDetails(Client client) => this.client = client;

    public Client Client => client;
    public decimal Balance { get; set; } = 0;
    public List<string> Logs => logs;
    public List<string[]> Statements => statements;

    public void AddLog(string message) => logs.Add(message);

    public void AddStatement(Statement statement) => statements.Add(statement.ToArray());
}
namespace SoftwareCrafters.Module_6.CodeSmells.DivergentChange;

public class OnDemandLog
{
    private readonly string username;

    public OnDemandLog(OnDemandCustomer customer) => username = customer.Username;

    public List<string> Log { get; set; } = new();

    public void LogInfo(bool startNewAgent = false)
    {
        var info = "Starting on-demand agent startup logic";

        if (startNewAgent)
            info = string.Format("User {0} will attempt to start a new on-demand agent.", username);

        Log.Add(string.Concat("INFO: ", info));
    }

    public void LogWarning()
    {
        var warning = string.Format("User {0} attempted to start a new on-demand agent.", username);

        Log.Add(string.Concat("WARNING: ", warning));
    }

    public void LogError()
    {
        var error = "Exception in on-demand agent creation logic";

        Log.Add(string.Concat("ERROR: ", error));
    }
}
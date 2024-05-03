namespace SoftwareCrafters.Module_6.CodeSmells.DivergentChange;

public class OnDemandLog
{
    public List<string> Log { get; set; } = new();

    public void LogInfo(string info) => Log.Add(string.Concat("INFO: ", info));

    public void LogWarning(string warning) => Log.Add(string.Concat("WARNING: ", warning));

    public void LogError()
    {
        var error = "Exception in on-demand agent creation logic";

        Log.Add(string.Concat("ERROR: ", error));
    }
}
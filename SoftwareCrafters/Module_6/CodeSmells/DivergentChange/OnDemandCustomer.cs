namespace SoftwareCrafters.Module_6.CodeSmells.DivergentChange;

public class OnDemandCustomer
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsAuthorized => Username == "admin" && Password == "passw0rd";
}
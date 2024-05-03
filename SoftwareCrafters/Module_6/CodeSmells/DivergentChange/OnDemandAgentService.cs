namespace SoftwareCrafters.Module_6.CodeSmells.DivergentChange;

#region Original
//public class OnDemandAgentService
//{
//    public string Username { get; set; }

//    public string Password { get; set; }

//    public List<string> Log { get; set; }

//    public OnDemandAgent StartNewOnDemandMachine()
//    {
//        LogInfo("Starting on-demand agent startup logic");

//        try
//        {
//            if (IsAuthorized(Username, Password))
//            {
//                LogInfo(string.Format("User {0} will attempt to start a new on-demand agent.", Username));
//                var agent = StartNewAmazonServer();
//                SendEmailToAdmin(string.Format("User {0} has successfully started a machine with ip {1}.", Username, agent.Ip));
//                return agent;
//            }

//            LogWarning(string.Format("User {0} attempted to start a new on-demand agent.", Username));
//            throw new UnauthorizedAccessException("Unauthorized access to StartNewOnDemandMachine method.");
//        }
//        catch (Exception)
//        {
//            LogError("Exception in on-demand agent creation logic");
//            throw;
//        }
//    }

//    private OnDemandAgent StartNewAmazonServer()
//    {
//        // Call Amazon API and start a new EC2 instance, implementation omitted
//        var amazonAgent = new OnDemandAgent();
//        amazonAgent.Host = "usweav-ec2.mycompany.local";
//        amazonAgent.Ip = "54.653.234.23";
//        amazonAgent.ImageId = "ami-784930";
//        return amazonAgent;
//    }

//    private void LogInfo(string info)
//    {
//        Log.Add(string.Concat("INFO: ", info));
//    }

//    private void LogWarning(string warning)
//    {
//        Log.Add(string.Concat("WARNING: ", warning));
//    }

//    private void LogError(string error)
//    {
//        Log.Add(string.Concat("ERROR: ", error));
//    }

//    private bool IsAuthorized(string username, string password)
//    {
//        return username == "admin" && password == "passw0rd";
//    }

//    private void SendEmailToAdmin(string message)
//    {
//        var emailHost = "email.mycompany.com";
//        var recipient = "admin@mycompany.com";

//        // actual email sending implementation omitted
//    }
//}
#endregion

public class OnDemandAgentService : OnDemandLog
{
    private readonly OnDemandCustomer customer;

    public OnDemandAgentService(OnDemandCustomer customer) => this.customer = customer;

    public OnDemandAgent StartNewOnDemandMachine()
    {
        LogInfo("Starting on-demand agent startup logic");

        try
        {
            if (customer.IsAuthorized)
            {
                var info = string.Format("User {0} will attempt to start a new on-demand agent.", customer.Username);
                LogInfo(info);
                var agent = StartNewAmazonServer();
                SendEmailToAdmin(agent.Ip);
                return agent;
            }

            var warning = string.Format("User {0} attempted to start a new on-demand agent.", customer.Username);
            LogWarning(warning);
            throw new UnauthorizedAccessException("Unauthorized access to StartNewOnDemandMachine method.");
        }
        catch (Exception)
        {
            LogError();
            throw;
        }
    }

    private OnDemandAgent StartNewAmazonServer()
    {
        // Call Amazon API and start a new EC2 instance, implementation omitted
        return new OnDemandAgent
        {
            Host = "usweav-ec2.mycompany.local",
            Ip = "54.653.234.23",
            ImageId = "ami-784930"
        };
    }

    private void SendEmailToAdmin(string agentIp)
    {
        var message = string.Format("User {0} has successfully started a machine with ip {1}.", customer.Username, agentIp);

        var emailHost = "email.mycompany.com";
        var recipient = "admin@mycompany.com";

        // actual email sending implementation omitted
    }
}
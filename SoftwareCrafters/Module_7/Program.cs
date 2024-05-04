#region Original
//namespace BankApp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            DependencyInjectionProvider.Setup();
//        }
//    }
//}
#endregion

using SoftwareCrafters.Module_7.DependencyInjection;

namespace SoftwareCrafters.Module_7;

public class Program
{
    public static void Main(string[] args)
    {
        DependencyInjectionProvider.Setup();
    }
}
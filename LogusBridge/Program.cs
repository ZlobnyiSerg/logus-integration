using Topshelf;

namespace LogusBridge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.RunAsLocalSystem();
                x.StartAutomatically();                
                x.SetDescription("Logus Integration Bridge");
                x.Service<BridgeService>();                
            });
        }
    }
}

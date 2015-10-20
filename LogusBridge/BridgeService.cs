using NServiceBus;
using NServiceBus.Logging;
using Topshelf;

namespace LogusBridge
{
    public class BridgeService : ServiceControl
    {
        protected static readonly ILog Log = LogManager.GetLogger<BridgeService>();
        private IStartableBus _bus;

        public bool Start(HostControl hostControl)
        {
            Log.Info("Starting bridge service...");
            _bus = (IStartableBus) BusFactory.Create();
            _bus.Start();

            Log.Info("Bridge service started.");

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Log.Info("Stopping bridge service...");

            if (_bus != null)
            {
                _bus.Dispose();
                _bus = null;
            }

            Log.Info("Bridge service stopped.");
            return true;
        }
    }
}
using NServiceBus;
using NServiceBus.Persistence;

namespace LogusBridge
{
    /// <summary>
    /// Factory to create and configure instance of service bus
    /// </summary>
    public class BusFactory
    {
        public static IBus Create()
        {
            var config = new BusConfiguration();

            config.ScaleOut().UseSingleBrokerQueue();
            config.Transactions().EnableDistributedTransactions();
            config.UseTransport<SqlServerTransport>();
            config.UsePersistence<NHibernatePersistence, StorageType.Sagas>();
            config.UsePersistence<NHibernatePersistence, StorageType.Subscriptions>();
            config.UsePersistence<NHibernatePersistence, StorageType.Timeouts>();
            config.UsePersistence<NHibernatePersistence, StorageType.Outbox>();
            config.PurgeOnStartup(false);
            config.EnableInstallers();

            return Bus.Create(config);
        }
    }
}
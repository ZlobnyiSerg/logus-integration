using Logus.HMS.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace LogusBridge.Handlers
{
    /// <summary>
    ///     Обработчик сообщения об изменении в брони
    /// </summary>
    public class AvailabilityChangedHandler : IHandleMessages<AvailabilityChangedEvent>
    {
        protected static readonly ILog Log = LogManager.GetLogger<AvailabilityChangedHandler>();        

        public void Handle(AvailabilityChangedEvent message)
        {
            Log.InfoFormat($"Получено сообщение об изменении наличия в отеле {message.PropertyId}, на даты {message.DateRange}, тип комнаты '{message.RoomTypeCode}'");
        }
    }
}

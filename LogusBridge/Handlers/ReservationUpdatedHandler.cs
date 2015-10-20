using Logus.HMS.Messages.Booking;
using NServiceBus;
using NServiceBus.Logging;

namespace LogusBridge.Handlers
{
    /// <summary>
    ///     Обработчик сообщения об изменении в брони
    /// </summary>
    public class ReservationUpdatedHandler : IHandleMessages<ReservationUpdatedMessage>
    {
        protected static readonly ILog Log = LogManager.GetLogger<ReservationUpdatedHandler>();        

        public void Handle(ReservationUpdatedMessage message)
        {
            Log.InfoFormat("Получено сообщение об изменении в брони №{0} (на гостя {1})", message.GenericNo, message.MainGuest.GetFullName());
        }
    }
}

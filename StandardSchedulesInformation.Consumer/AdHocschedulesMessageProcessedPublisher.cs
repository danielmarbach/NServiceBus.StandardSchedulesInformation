using System;
using NServiceBus;
using StandardSchedulesInformation.Messages.Events;

namespace StandardSchedulesInformation.Consumer
{
    public class AdHocschedulesMessageProcessedPublisher
    {
        private readonly IBus bus;

        public AdHocschedulesMessageProcessedPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish(Guid messageId)
        {
            this.bus.Publish(new AdHocSchedulesMessageProcessed(messageId));
        }
    }
}
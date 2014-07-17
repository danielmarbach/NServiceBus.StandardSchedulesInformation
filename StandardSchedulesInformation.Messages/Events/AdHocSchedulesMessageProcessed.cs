using System;

namespace StandardSchedulesInformation.Messages.Events
{
    public class AdHocSchedulesMessageProcessed
    {
        public AdHocSchedulesMessageProcessed(Guid messageId)
        {
            MessageId = messageId;
        }

        public Guid MessageId { get; private set; }
    }
}

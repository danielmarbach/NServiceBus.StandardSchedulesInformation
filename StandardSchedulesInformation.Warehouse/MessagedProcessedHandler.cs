using NServiceBus;
using StandardSchedulesInformation.Contracts;
using StandardSchedulesInformation.Messages.Events;

namespace StandardSchedulesInformation.Warehouse
{
    public class MessagedProcessedHandler : IHandleMessages<AdHocSchedulesMessageProcessed>
    {
        private readonly AdHocSchedulesMessageQuery query;
        private AdHocSchedulesMessageModifier modifier;

        public MessagedProcessedHandler(AdHocSchedulesMessageQuery query, AdHocSchedulesMessageModifier modifier)
        {
            this.modifier = modifier;
            this.query = query;
        }

        public void Handle(AdHocSchedulesMessageProcessed message)
        {
            AdHocSchedulesMessage schedulesMessage = this.query.Find(new AdHocSchedulesMessageId(message.MessageId));

            this.modifier.Modify(schedulesMessage);
        }
    }
}
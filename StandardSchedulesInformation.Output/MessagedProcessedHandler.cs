using System;
using NServiceBus;
using StandardSchedulesInformation.Contracts;
using StandardSchedulesInformation.Messages.Events;

namespace StandardSchedulesInformation.Output
{
    public class MessagedProcessedHandler : IHandleMessages<AdHocSchedulesMessageProcessed>
    {
        private readonly AdHocSchedulesMessageQuery query;
        private AdHocSchedulesMessageOutputGenerator generator;

        public MessagedProcessedHandler(AdHocSchedulesMessageQuery query, AdHocSchedulesMessageOutputGenerator generator)
        {
            this.generator = generator;
            this.query = query;
        }

        public void Handle(AdHocSchedulesMessageProcessed message)
        {
            Tuple<AdHocSchedulesMessage, string> messageAndOriginalContent = this.query.Find(new AdHocSchedulesMessageId(message.MessageId));

            this.generator.Generate(messageAndOriginalContent.Item1, messageAndOriginalContent.Item2);
        }
    }
}
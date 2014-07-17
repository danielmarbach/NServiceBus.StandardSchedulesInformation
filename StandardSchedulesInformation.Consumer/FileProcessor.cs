using System;
using NServiceBus;
using StandardSchedulesInformation.Consumer.Commands;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Consumer
{
    public class FileProcessor : IHandleMessages<ProcessFile>
    {
        private readonly AdHocSchedulesMessageParser parser;
        private readonly AdHocSchedulesMessageModifier modifier;
        private readonly AdHocschedulesMessageProcessedPublisher publisher;
        private readonly AdHocSchedulesMessageCleaner cleaner;

        public FileProcessor(
            AdHocSchedulesMessageParser parser, 
            AdHocSchedulesMessageModifier modifier, 
            AdHocSchedulesMessageCleaner cleaner,
            AdHocschedulesMessageProcessedPublisher publisher)
        {
            this.cleaner = cleaner;
            this.publisher = publisher;
            this.modifier = modifier;
            this.parser = parser;
        }

        public void Handle(ProcessFile message)
        {
            Tuple<AdHocSchedulesMessage, string> messageAndContent = this.parser.Parse(message);
            if (messageAndContent.Item1 == AdHocSchedulesMessage.Empty)
            {
                return;
            }

            this.modifier.Modify(messageAndContent);
            this.cleaner.Clean(message);
            this.publisher.Publish(message);
        }
    }
}
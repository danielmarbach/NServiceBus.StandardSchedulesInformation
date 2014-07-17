using System;
using StandardSchedulesInformation.Consumer.Commands;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Consumer
{
    public static class FileProcessorExtenstions
    {
        public static Tuple<AdHocSchedulesMessage, string> Parse(this AdHocSchedulesMessageParser parser, ProcessFile message)
        {
            return parser.Parse(message.Name, message.FullPath, message.Id);
        }

        public static void Clean(this AdHocSchedulesMessageCleaner cleaner, ProcessFile message)
        {
            cleaner.Clean(message.FullPath);
        }

        public static void Publish(this AdHocschedulesMessageProcessedPublisher publisher, ProcessFile message)
        {
            publisher.Publish(message.Id);
        }
    }
}
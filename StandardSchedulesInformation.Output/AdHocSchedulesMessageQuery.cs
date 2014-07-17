using System;
using System.IO;
using System.Text;
using Raven.Client;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Output
{
    public class AdHocSchedulesMessageQuery
    {
        private readonly IDocumentSession session;

        public AdHocSchedulesMessageQuery(IDocumentSession session)
        {
            this.session = session;
        }

        public Tuple<AdHocSchedulesMessage, string> Find(AdHocSchedulesMessageId messageId)
        {
            var message = this.session.Load<AdHocSchedulesMessage>(messageId);
            var attachement = this.session.Advanced.DocumentStore.DatabaseCommands.GetAttachment(messageId);
            var stream = attachement.Data();
            StreamReader reader = new StreamReader(stream, new UTF8Encoding());
            string content = reader.ReadToEnd();

            return new Tuple<AdHocSchedulesMessage, string>(message, content);
        }
    }
}
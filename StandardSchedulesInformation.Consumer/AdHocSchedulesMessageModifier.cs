using System;
using System.IO;
using System.Text;
using Raven.Client;
using Raven.Json.Linq;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Consumer
{
    public class AdHocSchedulesMessageModifier
    {
        private readonly IDocumentSession session;

        public AdHocSchedulesMessageModifier(IDocumentSession session)
        {
            this.session = session;
        }

        public void Modify(Tuple<AdHocSchedulesMessage, string> mesageAndContent)
        {
            this.session.Store(mesageAndContent.Item1);

            Stream data = new MemoryStream(Encoding.UTF8.GetBytes(mesageAndContent.Item2));

            this.session.Advanced.DocumentStore.DatabaseCommands.PutAttachment(mesageAndContent.Item1.Id, null, data, new RavenJObject());
        }
    }
}
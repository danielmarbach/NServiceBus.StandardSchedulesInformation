using Raven.Client;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Warehouse
{
    public class AdHocSchedulesMessageQuery
    {
        private readonly IDocumentSession session;

        public AdHocSchedulesMessageQuery(IDocumentSession session)
        {
            this.session = session;
        }

        public AdHocSchedulesMessage Find(AdHocSchedulesMessageId messageId)
        {
            var message = this.session.Load<AdHocSchedulesMessage>(messageId);

            return message;
        }
    }
}
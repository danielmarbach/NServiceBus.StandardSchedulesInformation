using System;
using System.Globalization;

namespace StandardSchedulesInformation.Contracts
{
    public class AdHocSchedulesMessage
    {
        private static Lazy<AdHocSchedulesMessage> empty = new Lazy<AdHocSchedulesMessage>(() => new AdHocSchedulesMessage(new AdHocSchedulesMessageId(Guid.Empty)), true);

        public AdHocSchedulesMessage()
        {
        }

        public AdHocSchedulesMessage(AdHocSchedulesMessageId messageId)
        {
            this.Id = messageId;
        }

        public string Id { get; private set; }

        public MessageHeading MessageHeading { get; set; }
        public ActionInformation ActionInformation { get; set; }
        public FlightInformation FlightInformation { get; set; }
        public EquipmentInformation EquipmentInformation { get; set; }

        public static AdHocSchedulesMessage Empty
        {
            get { return empty.Value; }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AdHocSchedulesMessage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (MessageHeading != null ? MessageHeading.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ActionInformation != null ? ActionInformation.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FlightInformation != null ? FlightInformation.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (EquipmentInformation != null ? EquipmentInformation.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(AdHocSchedulesMessage other)
        {
            return Equals(MessageHeading, other.MessageHeading) && string.Equals(Id, other.Id) && Equals(ActionInformation, other.ActionInformation) && Equals(FlightInformation, other.FlightInformation) && Equals(EquipmentInformation, other.EquipmentInformation);
        }

        public static bool operator ==(AdHocSchedulesMessage left, AdHocSchedulesMessage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AdHocSchedulesMessage left, AdHocSchedulesMessage right)
        {
            return !Equals(left, right);
        }
    }
}
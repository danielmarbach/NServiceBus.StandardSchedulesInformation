using System;
using System.Globalization;

namespace StandardSchedulesInformation.Contracts
{
    public class AdHocSchedulesMessageId
    {
        protected bool Equals(AdHocSchedulesMessageId other)
        {
            return string.Equals(id, other.id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AdHocSchedulesMessageId) obj);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(AdHocSchedulesMessageId left, AdHocSchedulesMessageId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AdHocSchedulesMessageId left, AdHocSchedulesMessageId right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return this.id;
        }

        public static implicit operator string(AdHocSchedulesMessageId messageId)
        {
            return messageId.id;
        }

        private string id;

        public AdHocSchedulesMessageId(Guid messageId)
        {
            this.id = string.Format(CultureInfo.InvariantCulture, "AdHocSchedulesMessages/{0}", messageId);
        }
    }
}
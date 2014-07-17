using System.Collections.Generic;

namespace StandardSchedulesInformation.Contracts
{
    public class ActionInformation
    {
        public string ActionIdentifier { get; set; }
        public string SecondaryActionIdentifier { get; set; }
        public List<string> ChangeReasons { get; set; }
    }
}
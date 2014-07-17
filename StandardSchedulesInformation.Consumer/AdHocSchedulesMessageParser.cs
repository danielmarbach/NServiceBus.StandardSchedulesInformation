using System;
using System.Collections.Generic;
using System.IO;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Consumer
{
    public class AdHocSchedulesMessageParser
    {
        private static readonly Dictionary<string, Func<Guid, AdHocSchedulesMessage>> 
            PreparedMessages =
                new Dictionary<string, Func<Guid, AdHocSchedulesMessage>>
                {
                    { "ASM EQT AB.snd", id => new AdHocSchedulesMessage(new AdHocSchedulesMessageId(id))
                    {
                        MessageHeading = new MessageHeading { StandardMessageIdentifier = "ASM", TimeMode = "UTC" },
                        ActionInformation = new ActionInformation { ActionIdentifier = "EQT", },
                        FlightInformation = new FlightInformation { FlightIdentifier = "AB8888", AircraftOwner = "X3" },
                        EquipmentInformation = new EquipmentInformation { ServiceType = "J", AirCraftType = "73H" },
                    }
                    },
                    { "ASM EQT HG.snd", id => new AdHocSchedulesMessage(new AdHocSchedulesMessageId(id))
                    {
                        MessageHeading = new MessageHeading { StandardMessageIdentifier = "ASM", TimeMode = "UTC" },
                        ActionInformation = new ActionInformation { ActionIdentifier = "EQT", },
                        FlightInformation = new FlightInformation { FlightIdentifier = "HG8475", AircraftOwner = "HE" },
                        EquipmentInformation = new EquipmentInformation { ServiceType = "J", AirCraftType = "DH4" },
                    }
                    },
                };

        public Tuple<AdHocSchedulesMessage, string> Parse(string fileName, string filePath, Guid messageId)
        {
            Func<Guid, AdHocSchedulesMessage> emptyMessageFactory = id => AdHocSchedulesMessage.Empty;

            Func<Guid, AdHocSchedulesMessage> factory;
            if (!PreparedMessages.TryGetValue(fileName, out factory))
            {
                factory = emptyMessageFactory;
            }

            string readAllText = null;
            if (File.Exists(filePath))
            {
                readAllText = File.ReadAllText(filePath);
            }
            else
            {
                factory = emptyMessageFactory;
            }

            AdHocSchedulesMessage message = factory(messageId);
            return new Tuple<AdHocSchedulesMessage, string>(message, readAllText);
        }
    }
}
using System.IO;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Output
{
    public class AdHocSchedulesMessageOutputGenerator
    {
        public void Generate(AdHocSchedulesMessage message, string originalContent)
        {
            string outputDirectory = Path.Combine(@"C:\outputlocation", message.FlightInformation.AircraftOwner);
            string outputPath = Path.Combine(outputDirectory, Path.GetFileName(Path.GetTempFileName()));

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Use extreme brute force here, hey it's a demo :)
            string airCraftType = message.EquipmentInformation.AirCraftType == "73H"
                ? "73Y"
                : message.EquipmentInformation.AirCraftType;

            File.WriteAllText(outputPath, originalContent.Replace(message.EquipmentInformation.AirCraftType, airCraftType));
        }
    }
}
using System.IO;

namespace StandardSchedulesInformation.Consumer
{
    public class AdHocSchedulesMessageCleaner
    {
        public void Clean(string filePath)
        {
            File.Delete(filePath);
        }
    }
}
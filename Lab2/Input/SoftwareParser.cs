using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Lab2.Software;

namespace Lab2.Input
{
    public static class SoftwareParser
    {
        public static ASoftware ParseSoftware<T>(string software) where T : ASoftware
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(software);
            writer.Flush();
            var serializer = new DataContractJsonSerializer(typeof(T),
                new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat("dd.MM.yyyy")
                });
            stream.Position = 0;
            return serializer.ReadObject(stream) as ASoftware;
        }
    }
}
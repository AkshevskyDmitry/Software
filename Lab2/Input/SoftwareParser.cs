using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Lab2.Software;

namespace Lab2.Input
{
    public static class SoftwareParser
    {
        /// <summary>
        /// Создание объекта типа Software из JSON строки
        /// </summary>
        /// <param name="software">JSON строка с описанием параметров класса</param>
        /// <typeparam name="T">Тип программного обеспечения</typeparam>
        /// <returns>Экземпляр класса ASoftware полученный из заданной строки</returns>
        public static ASoftware ParseSoftware<T>(string software) where T : ASoftware
        {
            Trace.WriteLine($"ParseSoftware");
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
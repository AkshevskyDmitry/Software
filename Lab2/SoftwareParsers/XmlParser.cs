using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Lab2.Software;

namespace Lab2.Input
{
    public class XmlParser : ISoftwareParser
    {
        /// <summary>
        /// Создание объекта типа Software из XML строки
        /// </summary>
        /// <param name="software">XML строка с описанием параметров класса</param>
        /// <typeparam name="T">Тип программного обеспечения</typeparam>
        /// <returns>Экземпляр класса ASoftware полученный из заданной строки</returns>
        public ASoftware ParseSoftware<T>(string software) where T : ASoftware
        {
            Trace.WriteLine($"ParseSoftwareFromXML");
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(software);
            writer.Flush();
            var serializer = new XmlSerializer(typeof(T));
            stream.Position = 0;
            return serializer.Deserialize(stream) as ASoftware;
        }
    }
}
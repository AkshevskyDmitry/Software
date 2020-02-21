using System;
using System.IO;
using System.Xml.Serialization;
using Lab2.Input;
using Lab2.Software;

namespace Lab2.SoftwareFillers
{
    public static class XmlFiller
    {
        /// <summary>
        /// Создание XML объекта из классов ASoftware
        /// </summary>
        /// <param name="software">Сериализуемый класс</param>
        /// <typeparam name="T">Тип програмного обеспечения</typeparam>
        /// <returns>Строку с XML описанием объекта</returns>
        public static string CreateXml<T> (ASoftware software) where T: ASoftware
        {
            var serializer = new XmlSerializer(typeof(T));
            var stream = new MemoryStream();
            
            serializer.Serialize(stream, software);
            stream.Position = 0;
            
            var streamReader = new StreamReader(stream);
            var xmlObject = streamReader.ReadToEnd();
            
            return xmlObject;
        }
    }
}
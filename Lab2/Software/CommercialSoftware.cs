using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Lab2.Software
{
    /// <summary>
    /// Описание Комерческого ПО
    /// </summary>
    [DataContract]
    [XmlRoot]
    public class CommercialSoftware: ASoftware
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        [DataMember]
        [XmlElement(DataType = "date")]
        public DateTime InstallationDate;
        
        /// <summary>
        /// Срок использования в днях
        /// </summary>
        [DataMember]
        [XmlElement]
        public int UsagePeriod;
        
        /// <summary>
        /// Стоимость ПО в долларах
        /// </summary>
        [DataMember]
        [XmlElement]
        public int Price;

        private CommercialSoftware()
        {
        }
        
        public CommercialSoftware(
            string name,
            string company,
            DateTime installDate,
            int usagePeriod,
            int price) : base(name, company)
        {
            InstallationDate = installDate;
            UsagePeriod = usagePeriod;
            Price = price;
        }

        public override void PrintInfo()
        {
            Trace.WriteLine($"CommercialSoftware: PrintInfo");
            Console.WriteLine($"{Company}: {Name} Installed: {InstallationDate.ToShortDateString()} Usage period: {UsagePeriod} days Price: {Price}$");
        }
        public override bool IsActive(DateTime date)
        {
            Trace.WriteLine($"CommercialSoftware: IsActive");
            return InstallationDate.AddDays(UsagePeriod) > date;
        }

        public override bool IsActive()
        {
            Trace.WriteLine($"CommercialSoftware: IsActive for current date");
            return IsActive(DateTime.Today);
        }
    }
}
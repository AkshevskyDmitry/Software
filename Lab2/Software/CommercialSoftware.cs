using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    /// <summary>
    /// Описание Комерческого ПО
    /// </summary>
    [DataContract]
    public class CommercialSoftware: ASoftware
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        [DataMember]
        public DateTime InstallationDate;
        
        /// <summary>
        /// Срок использования в днях
        /// </summary>
        [DataMember]
        public int UsagePeriod;
        
        /// <summary>
        /// Стоимость ПО в долларах
        /// </summary>
        [DataMember]
        public int Price;
        
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
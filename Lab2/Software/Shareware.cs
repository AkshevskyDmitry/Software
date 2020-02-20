using System;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    /// <summary>
    /// Описание Условно-Бесплатного ПО
    /// </summary>
    [DataContract]
    public class Shareware: ASoftware
    {
        /// <summary>
        /// Дата установки ПО
        /// </summary>
        [DataMember]
        public DateTime InstallationDate;
        
        /// <summary>
        /// Период бесплатного использования в днях
        /// </summary>
        [DataMember]
        public int FreePeriod; 
        
        public Shareware(string name, string company, DateTime installDate, int freePeriod) : base(name, company)
        {
            InstallationDate = installDate;
            FreePeriod = freePeriod;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Company}: {Name} Installed: {InstallationDate.ToShortDateString()} Free period: {FreePeriod} days");
        }
        public override bool IsActive(DateTime date)
        {
            return InstallationDate.AddDays(FreePeriod) > date;
        }

        public override bool IsActive()
        {
            return IsActive(DateTime.Today);
        }
    }
}
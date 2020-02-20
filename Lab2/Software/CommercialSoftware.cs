using System;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    [DataContract]
    public class CommercialSoftware: ASoftware
    {
        [DataMember]
        public DateTime InstallationDate;
        [DataMember]
        public int UsagePeriod;
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
            Console.WriteLine($"{Company}: {Name} Installed: {InstallationDate.ToShortDateString()} Usage period: {UsagePeriod} days Price: {Price}$");
        }
        public override bool IsActive(DateTime date)
        {
            return InstallationDate.AddDays(UsagePeriod) > date;
        }

        public override bool IsActive()
        {
            return IsActive(DateTime.Today);
        }
    }
}
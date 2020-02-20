using System;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    [DataContract]
    public class Shareware: ASoftware
    {
        [DataMember]
        public DateTime InstallationDate;
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
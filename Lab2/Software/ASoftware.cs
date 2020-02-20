using System;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    [DataContract]
    public abstract class ASoftware
    {
        [DataMember]
        public string Name;
        [DataMember]
        public readonly string Company;

        public ASoftware(string name, string company)
        {
            Name = name;
            Company = company;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine(Company + ": " + Name);
        }

        public abstract bool IsActive(DateTime date);
        public abstract bool IsActive();
    }
}
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    /// <summary>
    /// Описание бесплатного ПО
    /// </summary>
    [DataContract]
    public class FreeSoftware: ASoftware
    {
        public FreeSoftware(string name, string company) : base(name, company)
        {
        }

        public override bool IsActive(DateTime date)
        {
            Trace.WriteLine($"FreeSoftware: IsActive");
            return true;
        }

        public override bool IsActive()
        {
            Trace.WriteLine($"FreeSoftware: IsActive for current date");
            return true;
        }
    }
}
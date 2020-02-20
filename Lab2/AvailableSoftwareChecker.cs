using System;
using System.Collections.Generic;
using System.Linq;
using Lab2.Software;

namespace Lab2
{
    static class AvailableSoftwareChecker
    {
        public static ASoftware[] CheckSoftware(ASoftware[] softwares, DateTime date)
        {
            return softwares.Where(software => software.IsActive()).ToArray();
        }
        
        public static ASoftware[] CheckSoftware(ASoftware[] softwares)
        {
            return CheckSoftware(softwares, DateTime.Today);
        }
    }
}
using System;
using System.IO;
using Lab2.Software;
using Lab2.Input;

namespace Lab2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\..\Data\input.txt");
            var n = Convert.ToInt32(sr.ReadLine());
            ASoftware[] installedSoft = new ASoftware[n];
            
            for (int i = 0; i < n; i++)
            {
                var line = sr.ReadLine();
                var type = line.Substring(0, line.IndexOf('{') - 1);
                var json = line.Substring(line.IndexOf('{'));
                ASoftware software = null;
                switch (type)
                {
                    case "FreeSoftware":
                        software = SoftwareParser.ParseSoftware<FreeSoftware>(json);
                        break;
                    case "Shareware":
                        software = SoftwareParser.ParseSoftware<Shareware>(json);
                        break;
                    case "CommercialSoftware":
                        software = SoftwareParser.ParseSoftware<CommercialSoftware>(json);
                        break;
                    default: 
                        throw new FormatException($"Unknown type of Software: {type}");
                }

                installedSoft[i] = software;
            }

            var availableSoft = AvailableSoftwareChecker.CheckSoftware(installedSoft);
            foreach (var software in availableSoft)
            {
                software.PrintInfo();
            }
        }
    }
}
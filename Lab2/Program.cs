using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Lab2.Software;
using Lab2.Input;
using Lab2.SoftwareFillers;

namespace Lab2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\..\Data\input.txt");
            var n = Convert.ToInt32(sr.ReadLine());
            var installedSoft = new ASoftware[n];

            ISoftwareParser parser = new JsonSoftwareParser();
            var xmlObjects = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var line = sr.ReadLine();
                var type = line.Substring(0, line.IndexOf('{') - 1);
                var json = line.Substring(line.IndexOf('{'));
                ASoftware software = null;
                
                switch (type)
                {
                    case "FreeSoftware":
                        software = parser.ParseSoftware<FreeSoftware>(json);
                        xmlObjects.Add(XmlFiller.CreateXml<FreeSoftware>(software));
                        break;
                    case "Shareware":
                        software = parser.ParseSoftware<Shareware>(json);
                        xmlObjects.Add(XmlFiller.CreateXml<Shareware>(software));
                        break;
                    case "CommercialSoftware":
                        software = parser.ParseSoftware<CommercialSoftware>(json);
                        xmlObjects.Add(XmlFiller.CreateXml<CommercialSoftware>(software));
                        break;
                    default: 
                        throw new FormatException($"Unknown type of Software: {type}");
                }

                installedSoft[i] = software;
            }

            Console.WriteLine("List of XmlObjects: ");
            foreach (var xmlObject in xmlObjects)
            {
                Console.WriteLine(xmlObject);
            }
            
            Console.WriteLine();
            Console.WriteLine("List of Available Software for current date: ");
            var availableSoft = AvailableSoftwareChecker.CheckSoftware(installedSoft);
            foreach (var software in availableSoft)
            {
                software.PrintInfo();
            }
        }
    }
}
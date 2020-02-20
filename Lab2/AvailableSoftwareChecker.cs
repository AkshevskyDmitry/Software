using System;
using System.Diagnostics;
using System.Linq;
using Lab2.Software;

namespace Lab2
{
    static class AvailableSoftwareChecker
    {
        /// <summary>
        /// Получение доступных ПО на заданную дату
        /// </summary>
        /// <param name="softwares">Массив ПО</param>
        /// <param name="date">Дата для проверки</param>
        /// <returns>Массив доступных ПО на данную дату</returns>
        public static ASoftware[] CheckSoftware(ASoftware[] softwares, DateTime date)
        {
            Trace.WriteLine($"CheckSoftware");
            return softwares.Where(software => software.IsActive()).ToArray();
        }
        
        /// <summary>
        /// Получение доступных ПО на текущую дату
        /// </summary>
        /// <param name="softwares">Массив ПО</param>
        /// <returns>Массив доступных ПО на данную дату</returns>
        public static ASoftware[] CheckSoftware(ASoftware[] softwares)
        {
            Trace.WriteLine($"CheckSoftware for current date");
            return CheckSoftware(softwares, DateTime.Today);
        }
    }
}
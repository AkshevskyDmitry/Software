using System;
using System.Runtime.Serialization;

namespace Lab2.Software
{
    /// <summary>
    /// Описание ПО
    /// </summary>
    [DataContract]
    public abstract class ASoftware
    {
        /// <summary>
        /// Название ПО
        /// </summary>
        [DataMember]
        public string Name;
        
        /// <summary>
        /// Компания произовдитель 
        /// </summary>
        [DataMember]
        public readonly string Company;

        public ASoftware(string name, string company)
        {
            Name = name;
            Company = company;
        }

        /// <summary>
        /// Вывод в консоль информации об ПО
        /// </summary>
        public virtual void PrintInfo()
        {
            Console.WriteLine(Company + ": " + Name);
        }

        /// <summary>
        /// Проверка доступности ПО на заданную дату
        /// </summary>
        /// <param name="date">Дата проверки</param>
        /// <returns>Доступно ли ПО</returns>
        public abstract bool IsActive(DateTime date);
        
        /// <summary>
        /// Проверка доступности ПО на текущую дату
        /// </summary>
        /// <returns>Доступно ли ПО</returns>
        public abstract bool IsActive();
    }
}
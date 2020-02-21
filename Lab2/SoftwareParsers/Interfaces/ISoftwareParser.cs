using Lab2.Software;

namespace Lab2.Input
{
    public interface ISoftwareParser
    {
        /// <summary>
        /// Создание объекта типа Software из строки
        /// </summary>
        /// <param name="software">Строка с описанием параметров класса</param>
        /// <typeparam name="T">Тип программного обеспечения</typeparam>
        /// <returns>Экземпляр класса ASoftware полученный из заданной строки</returns>
        ASoftware ParseSoftware<T>(string software) where T : ASoftware;
    }
}
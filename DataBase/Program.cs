namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.AddOrder("ЛУ-190", "Усов");
            dataBase.AddOrder("ЛУ-191", "Писос");
            dataBase.AddOrder("ЛУ-192", "Чюля");
            dataBase.AddOrder("ЛУ-193", "Коч");

            dataBase.GetOrderInfo("ЛУ-193");
        }
    }
}
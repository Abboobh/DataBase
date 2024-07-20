using System.ComponentModel.Design;
using System.Text.Json;

namespace DataBase
{
    internal class Program
    {
        public static void Print()
        {
            Console.WriteLine("Введите команду:\n" +
                   "1 - Добавить заказ\n" +
                   "2 - Добавить цену за раскрой в заказ\n" +
                   "3 - Просмотреть заказ\n" +
                   "4 - Удалить цену за раскрой из заказа\n" +
                   "5 - Изменить статус заказа на \"Выполнено\"\n" +
                   "6 - Изменить статус заказа на \"Не выполнено\"");
        }
        public static void AddOrder(ref DataBase dataBase)
        {
            string name_order;
            string name_orderer;
            Console.WriteLine("Введите номер заказа");
            name_order = Console.ReadLine();
            Console.WriteLine("Введите наименование заказчика");
            name_orderer = Console.ReadLine();
            dataBase.AddOrder(name_order, name_orderer);
        }
        public static void AddPrice(ref DataBase dataBase)
        {
            bool flag = true;
            int price;
            Console.WriteLine("Введите номер заказа");
            string name_order = Console.ReadLine();
            while (flag)
            {
                Console.WriteLine("Введите выработку за лист");
                price = Convert.ToInt32(Console.ReadLine());
                if (price > 0)
                {
                    dataBase.AddPrice(name_order, price);
                }
                else
                {
                    Console.WriteLine("Ценник не может быть отрицательный");
                    continue;
                }
                Console.WriteLine("Ввести еще выработку\n 1 - да;\n2 - нет.");
                string continue_cmd = Console.ReadLine();
                if (continue_cmd == "2")
                {
                    flag = false;
                }
                else if (continue_cmd == "1")
                {
                    Console.Clear();
                    dataBase.PrintOrders();
                }
                else 
                {
                    Console.WriteLine("Нет такой команды");
                    continue;
                }

            }
        }
        public static void RemovePrice(ref DataBase dataBase)
        {
            Console.WriteLine("Введите номер заказа");
            string name_order = Console.ReadLine();
            Console.Clear();
            dataBase.PrintOrderInfo(name_order);
            Console.WriteLine("Введите номер цены за раскрой");
            int index_price = Convert.ToInt32(Console.ReadLine());
            dataBase.RemovePrice(name_order, index_price);
        }
        public static void PrintOrder(ref DataBase dataBase)
        {
            Console.WriteLine("Введите номер заказа");
            string name_order = Console.ReadLine();
            Console.Clear();
            dataBase.PrintOrderInfo(name_order);
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
        }
        public static void SetStatusReady(ref DataBase dataBase)
        {
            Console.WriteLine("Введите номер заказа");
            string name_order = Console.ReadLine();
            dataBase.SetStatusReady(name_order);
        }
        public static void SetStatusUnReady(ref DataBase dataBase)
        {
            Console.WriteLine("Введите номер заказа");
            string name_order = Console.ReadLine();
            dataBase.SetStatusUnReady(name_order);
        }
        public static void TestDataBase(ref DataBase dataBase)
        {
            dataBase.AddOrder("ЛУ-115", "Усов");
            dataBase.AddPrice("ЛУ-115", 614);
            dataBase.AddPrice("ЛУ-115", 543);
            dataBase.AddOrder("ЛУ-123", "Верон");
            dataBase.AddPrice("ЛУ-123", 1144);
            dataBase.AddPrice("ЛУ-123", 5456);
            dataBase.AddOrder("ЛУ-666", "Сотона");
            dataBase.AddPrice("ЛУ-666", 666);
            dataBase.AddPrice("ЛУ-666", 13);
        }
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            TestDataBase(ref dataBase);
            while (true) 
            {
                dataBase.PrintOrders();
                int command = 0;
                Print();
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        AddOrder(ref dataBase);
                        break;

                    case 2:
                        AddPrice(ref dataBase);
                        break;

                    case 3:
                        PrintOrder(ref dataBase);
                        break;

                    case 4:
                        RemovePrice(ref dataBase);
                        break;

                    case 5:
                        SetStatusReady(ref dataBase);
                        break;
                    case 6:
                        SetStatusUnReady(ref dataBase);
                        break;
                    default:
                        Console.WriteLine("Команды с таким номером не существует");
                        break;
                }
                Console.Clear();
            }
        }
    }
}
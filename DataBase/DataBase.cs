namespace DataBase
{
    internal class DataBase
    {
        public const int TABLINE = 110;
        private class Order
        {
            public Order()
            {
                AddCount();
            }

            public Order(string name_order, string name_orderer)
            {
                this._name_order = name_order;
                this._name_orderer = name_orderer;
                AddCount();
            }

            private void AddCount()
            {
                _id = _count;
                _count++;
            }

            public string _name_order = "";
            public string _name_orderer = "";
            public int _id = 0;

            public List<Tuple<int, int>> _price = new List<Tuple<int, int>>();
            public void AddPrice(int price)
            {
                int id_price = _price.Count;
                _price.Add(new Tuple<int, int>(id_price, price));

            }
            public void RemovePrice(int index)
            {
                _price.RemoveAt(index);
            }
            public int SumPrice()
            {
                int result = 0;

                for (int i = 0; i < _price.Count; i++)
                {
                    result += _price[i].Item2;
                }

                return result;
            }
        }

        private List<Order> _orders = new List<Order>();
        private static int _count;
        /*--------------Методы упрощения---------------*/
        private static void PrintHat()
        {
            Console.WriteLine("[ID]\t\t\t\t[Order]\t\t\t\t[Orderer]\t\t\t[Sum price]");
            for (int tab = 0; tab < TABLINE; tab++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
        }
        private static string PrintBody(Order order)
        {
            return "[" + order._id + "]\t\t\t\t[" + order._name_order + "]\t\t\t["
                       + order._name_orderer + "]\t\t\t\t[" + order.SumPrice() + "]";
        }
        /*-------------Методы манипуляциии-------------*/
        /// <summary>
        /// Добавить заказ в базу данных
        /// </summary>
        /// <param name="name_order">Номер заказа</param>
        /// <param name="name_orderer">Наименование заказчика</param>
        public void AddOrder(string name_order, string name_orderer) 
        {
            Order order = new Order(name_order, name_orderer);
            _orders.Add(order);
        }
        public void AddPrice(int index, int price)
        {
            _orders[index].AddPrice(price);
        }
        public void AddPrice(string order, int price)
        {
            foreach (var item in _orders)
            {
                if (item._name_order == order)
                {
                    AddPrice(item._id, price);
                }
            }
        }
        public void RemovePrice(int index_order, int index_price)
        {
            _orders[index_order].RemovePrice(index_price);
        }
        public void RemovePrice(string order_name, int index_price)
        {
            foreach (var item in _orders)
            {
                if (item._name_order == order_name)
                {
                    _orders[item._id].RemovePrice(index_price);
                }
            }
        }
        public int SumPrice(int index)
        {
            return _orders[index].SumPrice();
        }

        /*-------------Методы информации--------------*/
        public string GetOrderInfo(int index)
        {
            PrintHat();
            return PrintBody(_orders[index]);
        }
        public string GetOrderInfo(string order)
        {
            foreach (var item in _orders)
            {
                if(item._name_order == order)
                {
                   return GetOrderInfo(item._id);
                }
            }
            return "Order not found";
        }
        public void PrintOrders()
        {
            PrintHat();
            for (int index = 0; index < _count; index++)
            {
                Console.WriteLine(PrintBody(_orders[index]));
            }
            Console.WriteLine();
        }
        public void PrintOrderInfo(int index)
        {
            PrintHat();
            Console.WriteLine("[" + _orders[index]._id + "]\t\t\t\t[" + _orders[index]._name_order + "]\t\t\t[" + _orders[index]._name_orderer + "]");
            for (int index2 = 0; index2 <= _orders[index]._price.Count - 1; index2++)
            { 
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t[" + _orders[index]._price[index2] + "]");
            }
        }
        public void PrintOrderInfo(string order)
        {
            foreach (var item in _orders)
            {
                if (item._name_order == order)
                {
                    PrintOrderInfo(item._id);
                }
            }
        }
    }
    static class General
    {

    }
}

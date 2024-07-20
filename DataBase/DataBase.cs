using Mysqlx.Crud;
using System.Diagnostics;

namespace DataBase
{
    internal class DataBase
    {
        public const int TABLINE = 110;
        public const int WHITESPACE = 25;

        public enum STATUS
        { READY, UNREDY}

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
            public STATUS _status = STATUS.UNREDY;

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
            Console.WriteLine("[ID]" + new string(' ', 23) +
                              "[Order]" + new string(' ', 20) +
                              "[Orderer]" + new string(' ', 18) + "[Sum price]");
            Console.WriteLine(new string('_', TABLINE));
            Console.WriteLine();
        }
        private static string PrintBody(Order order)
        {
            return "[" + order._id + "]" + new string(' ',(WHITESPACE - Convert.ToString(order._id).Length)) + 
                   "[" + order._name_order + "]" + new string(' ', (WHITESPACE - Convert.ToString(order._name_order).Length)) + 
                   "[" + order._name_orderer + "]" + new string(' ', (WHITESPACE - Convert.ToString(order._name_orderer).Length)) + 
                   "[" + order.SumPrice() + "]" + new string(' ', (WHITESPACE - Convert.ToString(order.SumPrice()).Length)) +
                   "[" + order._status + "]";
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
        public float SumAllPrice()
        {
            float sum = 0;
            foreach (var item in _orders)
                foreach (var item_price in item._price)
                    sum += item_price.Item2;

            return sum;
        }
        public void SetStatusReady(int index)
        {
            _orders[index]._status = STATUS.READY;
        }
        public void SetStatusReady(string order)
        {
            foreach (var item in _orders)
            {
                if (item._name_order == order)
                {
                    SetStatusReady(item._id);
                }
            }
        }
        public void SetStatusUnReady(int index)
        {
            _orders[index]._status = STATUS.UNREDY;
        }
        public void SetStatusUnReady(string order)
        {
            foreach (var item in _orders)
            {
                if (item._name_order == order)
                {
                    SetStatusReady(item._id);
                }
            }
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
            Console.WriteLine(new string('_', TABLINE));
            Console.WriteLine(new string(' ', 25) + "Общая сумма выроботки [" + SumAllPrice() + "]    " + 
                                "Суммы выработки с учетом коэффициента [" + SumAllPrice()/7.5f + "]");
            Console.WriteLine();
        }
        public void PrintOrderInfo(int index)
        {
            PrintHat();
            Console.WriteLine("[" + _orders[index]._id + "]" + new string(' ', (WHITESPACE - Convert.ToString(_orders[index]._id).Length)) +
                              "[" + _orders[index]._name_order + "]" + new string(' ', (WHITESPACE - Convert.ToString(_orders[index]._name_order).Length)) + 
                              "[" + _orders[index]._name_orderer + "]");
            for (int index2 = 0; index2 <= _orders[index]._price.Count - 1; index2++)
            { 
                Console.WriteLine(new string(' ', 81) + _orders[index]._price[index2] + "]");
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

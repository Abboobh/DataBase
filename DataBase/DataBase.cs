using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class DataBase
    {
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

            public List<int> _price = new List<int>();
            public void AddPrice(int price)
            {
                _price.Add(price);
            }
            public int SumPrice()
            {
                int result = 0;

                for (int i = 0; i < _price.Count; i++)
                {
                    result += _price[i];
                }

                return result;
            }
        }

        private List<Order> _orders = new List<Order>();
        private static int _count;

        /*-------------Методы манипуляциии-------------*/
        public void AddOrder(string name_order, string name_orderer)
        {
            Order order = new Order(name_order, name_orderer);
            _orders.Add(order);
        }
        public void AddPrice(int index, int price)
        {
            _orders[index].AddPrice(price);
        }
        public int SumPrice(int index)
        {
            return _orders[index].SumPrice();
        }

        /*-------------Методы информации--------------*/
        public string GetOrderInfo(int index)
        {
            return _orders[index]._id + " " + _orders[index]._name_order + " " + _orders[index]._name_orderer + " " + _orders[index].SumPrice();
        }
        public string GetOrderInfo(string order)
        {
            List<Order> sortedlist = _orders;

            sortedlist.Sort();

            int result = _orders.BinarySearch(new Order { _name_order = order });

            return sortedlist[result]._id + " " + sortedlist[result]._name_order + " " 
                 + sortedlist[result]._name_orderer + " " + sortedlist[result].SumPrice();
        }
        public void PrintInfo()
        {
            for (int index = 0; index < _count; index++)
            {
                Console.WriteLine(_orders[index]._id + " " + _orders[index]._name_order + " " 
                                + _orders[index]._name_orderer + " " + _orders[index].SumPrice());
            }
        }
    }
    static class Method
    {

    }
}

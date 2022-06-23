using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    public static class DBConnection
    {
        public static List<Order> orders = new List<Order>();
        public static Cut cut1 = new Cut(1, 26, 2, 0);
        public static Cut cut2 = new Cut(2, 4, 1, 2);
        public static Cut cut3 = new Cut(3, 14, 0, 3);
        public static int order1 = 1;
        public static int order2 = 21;
        public static int maxoveruse = 5;

        public static int extrai1 = 0;
        public static int extrai2 = 0;

        public static void AddOrder(string number,DateTime dateStart, DateTime dateEnd)
        {
            Order order = new Order();
            order.number = number;
            order.dateCreated = dateStart;
            order.endDate = dateEnd;
            orders.Add(order);
        }

        public static void fillOrder(string number, List<BoxMapped> boxes, List<int> count)
        {
            Order order = new Order();
            order.number = number;
            foreach (Order o in orders)
            {
                if (o.number == number)
                {
                    order = o;
                    break;
                }
            }
            order.boxes = boxes;
            order.count = count;
        }
    }
}

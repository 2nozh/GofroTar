using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    public static class DBConnection
    {
        public static List<Order> orders = new List<Order>();
        public static List<Cut> cuts = new List<Cut>();
        

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

        public static void getPlan()
        {
            cuts.Add(new Cut(1, 26, 2, 0));
            cuts.Add(new Cut(2, 4, 1, 2));
            cuts.Add(new Cut(3, 14, 0, 3));
 int order1 = 1;
 int order2 = 21;
 int maxoveruse = 5;
        }
    }
}

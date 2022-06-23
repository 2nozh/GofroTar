using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    public class Order
    {
        public string number;
        public DateTime dateCreated;
        public DateTime endDate;

        public List<BoxMapped> boxes;
        public List<int> count;
    }
}

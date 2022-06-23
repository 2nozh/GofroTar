using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    public class BoxMapped
    {
        public int width;
        public int length;
        public string name;

        public BoxMapped()
        {
            width = 0;
            length = 0;
        }
        public BoxMapped(int width,int length)
        {
            this.width = width;
            this.length = length;

        }
        public BoxMapped(string name)
        {
            this.name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    public class Cut
    {
        public int number;
        public double looses;
        public double providesI1;
        public double providesI2;
        public Cut(int number, int looses, int providesI1, int providesI2)
        {
            this.number = number;
            this.looses = looses;
            this.providesI1 = providesI1;
            this.providesI2 = providesI2;
        }
    }
}

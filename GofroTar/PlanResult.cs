using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    public class PlanResult
    {
        public  List<Cut> cuts;
        public  List<double> count;

        public PlanResult()
        {
            cuts= new List<Cut>();
            count = new List<double>();
        }
    }
}

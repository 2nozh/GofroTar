using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace GofroTar
{
    class Optimize
    {
        public static PlanResult DoSimplex(List<Order> orders)
        {
            
            int maxoveruse = 5;

            double[] mainF = new double[DBConnection.cuts.Count];
            double[,] borders = new double[4, DBConnection.cuts.Count];
            double[] borderValues = new double[4];    
            for (int i = 0; i < DBConnection.cuts.Count; i++)
            {
                mainF[i] = 1 / DBConnection.cuts[i].looses;
                borders[0,i] = DBConnection.cuts[i].providesI1;
                borders[1,i] = DBConnection.cuts[i].providesI2;
                borders[2,i] = -DBConnection.cuts[i].providesI1;
                borders[3,i] = -DBConnection.cuts[i].providesI2;
            }

            
            borderValues[0] = orders[0].count[0];
            borderValues[1] = orders[0].count[1];
            borderValues[2] = orders[0].count[0] + maxoveruse;
            borderValues[3] = orders[0].count[1] + maxoveruse;

            var s = new Simplex(mainF, borders, borderValues);

            var answer = s.Minimize();
            
            PlanResult pr = new PlanResult();
            for(int i=0;i< DBConnection.cuts.Count; i++)
            {
                pr.cuts.Add(DBConnection.cuts[i]);
                pr.count.Add(answer.Item2[i]);
            }    
            return pr;
        }





        public static string DoOptimize()
        {
            int depth = 100;
            List < BoxMapped > mapps = new List <BoxMapped>();

            mapps.Add(new BoxMapped(5, 10));
            mapps.Add(new BoxMapped(5, 10));
            mapps.Add(new BoxMapped(5, 10));
            mapps.Add(new BoxMapped(5, 10));

            //int[] weights = {20,20,9,9,9,9,9};
            BoxMapped[] weights = mapps.ToArray();
            int[] prices = {20,20,20,20};



            Canvas canvas = new Canvas();
            Graphic graphic = new Graphic(canvas);
            graphic.Show();

            //int count = weights.Length;
            int count = mapps.Count;
            //int maxWeight = 56;
            
            int maxWeight = (canvas.width * canvas.length);

            int[][] A;
            A = new int[count + 1][];
            for (int i = 0; i < count + 1; i++)
            {
                A[i] = new int[maxWeight + 1];
            }
            for(int k = 0; k <= count; k++)
            {
                for(int s = 0; s <= maxWeight;s=s+depth)
                {
                    if (k == 0 || s == 0)
                    {
                        A[k][s] = 0;
                    }
                    else
                    {

                        if (s >= weights[k - 1].width * weights[k - 1].length && graphic.TryFitting(weights[k-1]))
                        {
                            A[k][s] = Math.Max(A[k-1][s],A[k-1][s-(weights[k-1].width* weights[k - 1].length)]+prices[k-1]);
                        }
                        else
                        {
                            A[k][s] = A[k - 1][s];
                        }
                    }

                }
            }

            List<int> result = new List<int>();
            traceResult(A, weights, count, maxWeight, result);
            string sres="";
            foreach(int item in result)
            {
                sres = sres + item.ToString() + " ";
            }
            return sres;

        }

        public static void traceResult(int[][] A, BoxMapped[] weight,int k,int s, List<int> result)
        {
            if (A[k][s] == 0)
            {
                return;
            }
            if (A[k - 1][s] == A[k][s])
            {
                traceResult(A, weight, k - 1, s, result);
            }
            else
            {
                traceResult(A, weight, k - 1, s - (weight[k - 1].width * weight[k - 1].length), result);
                result.Add(k);
            }
        }
        

    }
}

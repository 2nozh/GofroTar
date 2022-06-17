using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace GofroTar
{
    class Optimize
    {
        public static string DoOptimize()
        {
            int[] weights = {20,20,9,9,9,9,9};
            int[] prices = {20,20,1,1,1,1,1};



            Graphic graphic = new Graphic();
            graphic.Show();

            int count = weights.Length;
            int maxWeight = 56;

            int[][] A;
            A = new int[count + 1][];
            for (int i = 0; i < count + 1; i++)
            {
                A[i] = new int[maxWeight + 1];
            }
            for(int k = 0; k <= count; k++)
            {
                for(int s = 0; s <= maxWeight;s++)
                {
                    if (k == 0 || s == 0)
                    {
                        A[k][s] = 0;
                    }
                    else
                    {
                        if (s >= weights[k - 1])
                        {
                            A[k][s] = Math.Max(A[k-1][s],A[k-1][s-weights[k-1]]+prices[k-1]);
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

        public static void traceResult(int[][] A, int[] weight,int k,int s, List<int> result)
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
                traceResult(A, weight, k - 1, s - weight[k - 1], result);
                result.Add(k);
            }
        }
        

    }
}

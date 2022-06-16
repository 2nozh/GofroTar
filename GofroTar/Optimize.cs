using System;
using System.Collections.Generic;
using System.Text;

namespace GofroTar
{
    class Optimize
    {
        public static string DoOptimize()
        {
            int[] weights = { 3,4,5,8,9 };
            int[] prices = { 1,6,4,7,6};

            int count = weights.Length;
            int maxWeight = 13;

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
                            A[k][s] = Math.Max(A[k-1][s],A[k-1][s]+prices[k-1]);
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

            return result[0].ToString()+" "+result[1].ToString();

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

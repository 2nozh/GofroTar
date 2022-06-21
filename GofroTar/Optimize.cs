using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace GofroTar
{
    class Optimize
    {
        public static string DoSimplex()
        {
            string results="";
            double[,] table = { {-10,-2,-1,0},
                                {20,2,1,0},
                                {-5,0,-2,-3},
                                { 15,0,2,3},
                                { 0,-26,-4,-14} };

            double[] result = new double[3];
            double[,] table_result;
            Simplex S = new Simplex(table);
            table_result = S.Calculate(result);
            results = results + "\nРешенная симплекс-таблица:\n";
            for (int i = 0; i < table_result.GetLength(0); i++)
            {
                for (int j = 0; j < table_result.GetLength(1); j++)
                {
                    results = results + table_result[i, j]+ " ";
                }
                results = results + "\n";
            }
            results = results + "\n\nРешение\n\n";
            results = results + "X[1] = " + result[0]+"\n";
            results = results + "X[2] = " + result[1] + "\n";
            results = results + "X[3] = " + result[2] + "\n";
            double funcValue = 26 * result[0] + 4 * result[1] + 14 * result[2];
            results = results + "\n\nцф=\n\n";
            results = results + funcValue;
            return results;
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

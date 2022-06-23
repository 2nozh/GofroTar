using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace GofroTar
{
    class Optimize
    {
        public static PlanResult DoSimplex()
        {
            Cut cut1 = DBConnection.cuts[0];
            Cut cut2 = DBConnection.cuts[1];
            Cut cut3 = DBConnection.cuts[2];
            int order1 = 1;
            int order2 = 21;
            int maxoveruse = 5;

            int extrai1 = 0;
            int extrai2 = 0;
            var s = new Simplex(
        new[] { 1/cut1.looses, 1/cut2.looses, 1/cut3.looses,0,0},
        new[,] {
          {cut1.providesI1,cut2.providesI1,cut3.providesI1,extrai1,0},
          {cut1.providesI2,cut2.providesI2,cut3.providesI2,0,extrai2},
          {-cut1.providesI1,-cut2.providesI1,-cut3.providesI1,-extrai1,0},
          {-cut1.providesI2,-cut2.providesI2,-cut3.providesI2,0,-extrai2},
        },
        new double[] { order1,order2,order1+maxoveruse,order2+maxoveruse}
      );

            var answer = s.Minimize();

            string results = "";
            double[] result = new double[6];
            result[0] = answer.Item2[0];
            result[1] = answer.Item2[1];
            result[2] = answer.Item2[2];
            result[3] = answer.Item1;
            result[4] = answer.Item2[3];
            result[5] = answer.Item2[4];
            results = results + "\n\nРешение\n\n";
            results = results + "X[1] = " + result[0] + "\n";
            results = results + "X[2] = " + result[1] + "\n";
            results = results + "X[3] = " + result[2] + "\n";
            results = results + "item1 = " + result[3] + "\n";
            results = results + "extrai1 = " + result[4] + "\n";
            results = results + "extrai2 = " + result[5] + "\n";
            double funcValue = cut1.looses * result[0] + cut2.looses * result[1] + cut3.looses * result[2];
            results = results + "\n\nцф=\n\n";
            results = results + funcValue;

            results = results + "\n\nпроизведено i1,i2\n\n";
            double i1 = cut1.providesI1 * result[0] + cut2.providesI1 * result[1] + cut3.providesI1 * result[2]+ result[4];
            double i2 = cut1.providesI2 * result[0] + cut2.providesI2 * result[1] + cut3.providesI2 * result[2]+ result[5];
            results = results + i1 + "   " + i2;

            PlanResult pr = new PlanResult();
            pr.cuts.Add(cut1);
            pr.count.Add(answer.Item2[0]);
            pr.cuts.Add(cut2);
            pr.count.Add(answer.Item2[1]);
            pr.cuts.Add(cut3);
            pr.count.Add(answer.Item2[2]);
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

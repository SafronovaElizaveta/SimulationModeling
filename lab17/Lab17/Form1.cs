using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab17
{
    public partial class Form1 : Form
    {
        Model P1;
        Model P2;
        Model P1_with_P2;
        double l1, l2, t;
        int n;
        bool new_ = true;

        public Form1()
        {
            InitializeComponent();
            chart2.Series[0].IsValueShownAsLabel = true;
            chart2.Series[1].IsValueShownAsLabel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new_)
            {
                l1 = (double)numericUpDown1.Value;
                l2 = (double)numericUpDown2.Value;
                t = (double)numericUpDown4.Value;
                n = (int)numericUpDown3.Value;
                for (int i = 0; i < 4; i++)
                {
                    chart1.Series[i].Points.Clear();
                }
                P1 = new Model(l1, t, n);
                P2 = new Model(l2, t, n);
                P1_with_P2 = new Model ((double)(l1 + l2), t, n);
                chart1.Series[0].Points.AddXY(P1.time_get, P1.lambda_get);
                chart1.Series[1].Points.AddXY(P2.time_get, P2.lambda_get);
                chart1.Series[4].Points.AddXY(P1_with_P2.time_get, P1_with_P2.lambda_get);
                new_ = false;
                timer1.Start();
            }

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            for (int i = 0; i < 5; i++)
            {
                chart1.Series[i].Points.Clear();
            }
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (P1.Modeling() == 2)
            {
                chart1.Series[0].Points.AddXY(P1.time_get, P1.lambda_get);
                chart1.Series[2].Points.AddXY(P1.time_get, P1.lambda_get);
            }
            else if (P1.Modeling() == 1)
            {
                chart2.Series[0].Points.AddXY(P1.GetCount(), P1.Statistics());
            }
            else
            {
            }

            if (P2.Modeling() == 2)
            {
                chart1.Series[1].Points.AddXY(P2.time_get, P2.lambda_get);
                chart1.Series[3].Points.AddXY(P2.time_get, P2.lambda_get);
            }
            else if (P2.Modeling() == 2)
            {
                chart2.Series[0].Points.AddXY(P2.GetCount(), P2.Statistics());
            }
            else
            {

            }

            if (P1_with_P2.Modeling() == 2)
            {
                chart1.Series[4].Points.AddXY(P1_with_P2.time_get, P1_with_P2.lambda_get);
                chart1.Series[5].Points.AddXY(P1_with_P2.time_get, P1_with_P2.lambda_get);
            }
            else if (P1_with_P2.Modeling() == 1)
            {
                chart2.Series[1].Points.AddXY(P1_with_P2.GetCount(), P1_with_P2.Statistics());
            }
            else
            {
               
            }
        }

        class Model
        {
            int n, k = 0;
            int[] Points;
            double time_end, l, time = 0;
            Random rnd = new Random();
            Dictionary<int, int> freq = new Dictionary<int, int>();
            Dictionary<int, double> freq_stat = new Dictionary<int, double>();

            public double time_get
            { get => time; }

            public double lambda_get
            { get => l; }

            public Model(double l1, double t, int n_set)
            {
                l = l1;
                time_end = t;
                n = n_set;
                Points = new int[n];
                foreach (int i in Points)
                {
                    Points[i] = 0;
                }
            }

            public int GetCount()
            {
                return Points[k];
            }

            public int Modeling()
            {
                if (k < n)
                {
                    if (time < time_end)
                    {
                        time += Exponential();
                        Points[k]++;
                        return 2;
                    }
                    else
                    {
                        try
                        {
                            freq_stat.Add(Points[k], 0);
                            freq.Add(Points[k], 0);
                        }
                        catch
                        {
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }

            }

            private double Exponential()
            {
                double Xi;
                double A = rnd.NextDouble();

                Xi = -Math.Log(A) / l;

                return Xi;
            }

            public double Statistics()
            {
                freq[Points[k]]++;
                freq_stat[Points[k]] = (double)freq[Points[k]] / (double)(k + 1);
                k++;
                time = 0;

                return freq_stat[Points[k - 1]];
            }

        }

    }
}

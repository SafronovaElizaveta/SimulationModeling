using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab14
{
    public partial class Form1 : Form
    {
        public Stopwatch time = new Stopwatch();

        public decimal e, d;
        public double e_error, d_error;

        public int a, b;
        public decimal[] values, prob;

        const int n = 5;

        decimal[] freq = new decimal[n];

        decimal e0, d0, chi;


        int[] stat = new int[n];

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sum((int)numericUpDown3.Value, numericUpDown1.Value, numericUpDown2.Value);
            DrawGraph();
        }

        private void DrawGraph()
        {
            decimal[] Freq = Get();
            chart1.Series[0].Points.Clear();
            
            double ai = a;
            chart1.ChartAreas[0].Axes[0].Interval = ((double)(b - a)) / n;
            
            for (int i = 0; i < Freq.Length; i++)
            {
                chart1.Series[0].Points.AddXY(ai + ((double)(b - a)) / 10, Math.Round((double)Freq[i], 3));
                ai += ((double)(b - a)) / n;
            }
            
            chart1.ChartAreas[0].Axes[0].Maximum = b;
            label6.Text = "Время: " + time.ElapsedMilliseconds.ToString() + " сек";
            Mean();
            
            label4.Text = "Среднее: " + e + " (ошибка = " + e_error + " %)";
            label5.Text = "Дисперсия: " + d + " (ошибка = " + d_error + " %)";
            
            label7.Text = Chi();
            
            Dis(numericUpDown1.Value, numericUpDown2.Value);
        }

        private void Dis(decimal e, decimal d)
        {
            chart1.Series[1].Points.Clear();
            double ai = a;
            for (int i = 0; i < n; i++)
            {
                chart1.Series[1].Points.AddXY(ai + ((double)(b - a)) / 10, P1(ai + ((double)(b - a)) / 10));
                ai += ((double)(b - a)) / n;
            }
        }

        public double P1(double x)
        {
            return Math.Exp(-(x - (double)e0) * (x - (double)e0) / (2 * (double)d0)) / Math.Sqrt(2 * Math.PI * (double)d0);
        }

        public void Sum(int n, decimal e_0, decimal d_0)
        {
            time.Restart();

            e0 = e_0;
            d0 = d_0;
            values = new decimal[n];
            double x;

            for (int i = 0; i < n; i++)
            {
                x = 0;
                for (int j = 0; j < 12; j++)
                    x += rnd.NextDouble();
                values[i] = (decimal)((x - 6) * Math.Sqrt((double)d0)) + e0;
            }
            time.Stop();
        }
 

        public decimal[] Get()
        {
            decimal min = values[0], max = values[0];
            int j;

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] < min) min = values[i];
                if (values[i] > max) max = values[i];
            }

            a = (int)Math.Floor(min); b = (int)Math.Ceiling(max);

            for (int i = 0; i < n; i++)
                stat[i] = 0;

            for (int i = 0; i < values.Length; i++)
            {
                j = 0;

                while (a + j * ((decimal)(b - a)) / n >= values[i] || a + (j + 1) * ((decimal)(b - a)) / n < values[i])
                    j++;

                stat[j]++;
            }

            for (int i = 0; i < n; i++)
                freq[i] = (decimal)stat[i] / values.Length;

            return freq;
        }
        public void Mean()
        {
            chi = e = d = 0;
            prob = new decimal[n];

            for (int i = 0; i < n; i++)
            {
                prob[i] = (decimal)((b - a) * P1((2 * a + i * ((double)(b - a)) / n + (i + 1) * ((double)(b - a)) / n) / 2) / n);
                chi += stat[i] * stat[i] / (prob[i] * values.Length);
            }

            chi -= values.Length;

            for (int i = 0; i < values.Length; i++)
            {
                e += values[i];
                d += values[i] * values[i];
            }

            e /= values.Length;
            d /= values.Length;
            d -= e * e;

            e = Math.Round(e, 3);
            d = Math.Round(d, 3);

            e_error = Math.Round(Math.Abs((double)(e - e0)) * 100 / Math.Abs((double)e0), 3);
            d_error = Math.Round(Math.Abs((double)(d - d0)) * 100 / Math.Abs((double)d0), 3);
        }

        public string Chi()
        {
            if ((double)chi < 11.07) 
                return "Хи-квадрат: " + Math.Round((double)chi, 3) + " < 11.07 верно";
            return "Хи-квадрат: " + Math.Round((double)chi, 3) + " > 11.07 ошибка";
        }

    }
}
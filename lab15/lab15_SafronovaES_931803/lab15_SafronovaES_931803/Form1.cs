using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab15_SafronovaES_931803
{
    public partial class Form1 : Form
    {
        const int n = 3;
        public double time = 0, temp;
        double[] p = new double[n] { 0.33333, 0.33333, 0.33333 };
        double[,] m = new double[n, n] { { -0.4, 0.3, 0.1 }, { 0.4, -0.8, 0.4 }, { 0.1, 0.4, -0.5 } };
        int state, i, k = 0;
        Random rnd = new Random();
        double a;
        DateTime dtStart;
        double x;
        string[] wether = new string[3] { "Ясно", "Облачно", "Пасмурно" };
        
        public Dictionary<double, double> state_weather = new Dictionary<double, double>();



        public Form1()
        {
            InitializeComponent();
            state_weather.Add(0, 1);
            state_weather.Add(1, 1);
            state_weather.Add(2, 1);
            state_weather.Add(3, 1);
            chart2.Series[0].IsValueShownAsLabel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(numericUpDown1.Value);

            if (time == 0)
            {
                a = rnd.NextDouble();
                i = 0;
                while (a > 0)
                {
                    a -= p[i];
                    i++;
                }
                state_weather[state]++;
                state = i;
                k++;
            }
            
            if (time == 0)
                chart1.Series[0].Points.AddXY(0, state);
            
            dtStart = DateTime.Now;
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            for (int i = 1; i < state_weather.Count; i++)
            {
                chart2.Series[0].Points.AddXY(i, state_weather[i] / k);
            }

            int[] maP = new int[3];
            int[] mF = new int[3];
            for (int i = 1; i < state_weather.Count; i++)
            {
                maP[i - 1] = (int)(p[i - 1] * k);
                mF[i - 1] = (int)(state_weather[i] * k);
            }

            double chi = 0;

            for (int i = 1; i < state_weather.Count; i++)
            {
                chi += Math.Pow((mF[i - 1] - maP[i - 1]), 2) / maP[i - 1];
            }

            if (chi < 5.991)
                label3.Text = "   Эмпирическое и теоретическое\n распределения не различаются\n между собой";
            else
                label3.Text = "   Эмпирическое и теоретическое\n распределения различаются\n между собой";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            time = 0;
            label3.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            x = Convert.ToDouble(numericUpDown1.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = dtStart.Subtract(DateTime.Now);

            if (ts.TotalSeconds <= (-3600/x))
            {
                Generate();
                chart1.Series[0].Points.AddXY(time, state);
                label2.Text = wether[state - 1];
                state_weather[state]++;
                k++;
            }
        }

        public void Generate()
        {
            a = rnd.NextDouble();
            temp = Math.Log(a) / m[state - 1, state - 1];
            time += temp;

            double[] prob = new double[n];

            for (i = 0; i < n; i++)
            {
                if (i == (state - 1))
                {
                    prob[i] = 0;
                }
                else
                {
                    prob[i] = Math.Abs(m[state - 1, i] / m[state - 1, state - 1] );
                }
            }

            i = 0;
            while (a > 0)
            {
                a -= prob[i];
                i++;
            }
            state = i;
        }
    }

}

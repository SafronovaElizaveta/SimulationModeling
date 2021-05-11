using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13
{
    public partial class Form1 : Form
    {
        Statistica stat = new Statistica();
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].Axes[1].Maximum = 1.1;
            chart1.ChartAreas[0].Axes[0].Maximum = 4.5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set();
            Get();
        }

        private void Set()
        {
            stat.Set((int)numericUpDown1.Value, numericUpDown2.Value);
        }
        void Get()
        {
            chart1.Series[0].Points.Clear();
            decimal[] pointsY = stat.Get();
            for (int i = 0; i < 5; i++)
            {
                chart1.Series[0].Points.AddXY(i, Math.Round(pointsY[i], 3));
            }
            label4.Text = "Average: " + stat.Mat() + stat.MatErr();
            label5.Text = "Variance: " + stat.Disp() + " (error = " + Math.Round(stat.DispErr(), 3) + " %)";
            label6.Text = "Chi-squared: " + stat.ChiCheck();
        }
        class Statistica
        {
            int N;
            decimal E, E0, D, D0, Chi, p;
            int[] Statistics = new int[5];
            decimal[] Probabilities = new decimal[5], Frequency = new decimal[5];
            public void Set(int N, decimal p)
            {
                E = E0 = D = D0 = Chi = 0;
                this.p = p;
                this.N = N;
                decimal m = p;
                Probabilities[4] = 1; //Здесь значение 4 означает, что выпало значение > 3
                Statistics[4] = 0;
                for (int i = 0; i < 4; i++)
                {
                    Probabilities[i] = m;
                    Probabilities[4] -= Probabilities[i];
                    Statistics[i] = 0;
                    E0 += (i + 1) * Probabilities[i];
                    D0 += (i + 1) * (i + 1) * Probabilities[i];
                    m *= 1 - p;
                }
                E0 += 4 * Probabilities[4];
                D0 += 16 * Probabilities[4];
                D0 -= E0 * E0;
            }
            public decimal[] Get()
            {
                Random rnd = new Random();
                int x;
                for (int i = 0; i < N; i++)
                {
                    x = (int)Math.Truncate(Math.Log(rnd.NextDouble()) / Math.Log((double)(1 - p)));
                    if (x < 5) Statistics[x]++;
                    else Statistics[4]++;
                }
                for (int i = 0; i < Statistics.Length; i++)
                {
                    Frequency[i] = (decimal)Statistics[i] / N;
                }
                return Frequency;
            }
            public decimal Mat()
            {
                for (int i = 0; i < 5; i++) E += (i + 1) * Frequency[i];
                return E;
            }
            public string MatErr()
            {
                return " (error = " + Math.Round(Math.Abs(E - E0) * 100 / Math.Abs(E0), 3) + "%)";
            }
            public decimal Disp()
            {
                for (int i = 0; i < 5; i++) D += (i + 1) * (i + 1) * Frequency[i];
                D -= E * E;
                return D;
            }
            public decimal DispErr()
            {
                return Math.Abs(D - D0) * 100 / Math.Abs(D0);
            }
            public string ChiCheck()
            {
                for (int i = 0; i < Probabilities.Length; i++) Chi += Statistics[i] * Statistics[i] / (N * Probabilities[i]);
                Chi -= N;
                if (Chi < (decimal)11.07) return Math.Round(Chi, 3) + " < 11.07 is true";
                else return Math.Round(Chi, 3) + " > 11.07 is false";
            }
        }
    }
}

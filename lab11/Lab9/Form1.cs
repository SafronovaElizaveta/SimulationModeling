using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        Statistica stat = new Statistica();
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].Axes[1].Maximum = 1.1;
            chart1.ChartAreas[0].Axes[0].Maximum = 5.5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set();
        }
        private void Set()
        {
            if (stat.Set(numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value, numericUpDown5.Value)) Get();
            else MessageBox.Show(
                "Не соблюдено условие нормировки!",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void Get()
        {
            chart1.Series[0].Points.Clear();
            decimal[] pointsY = stat.Get();
            for (int i = 0; i < pointsY.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, pointsY[i]);

            }
            chart1.Series[0].IsValueShownAsLabel = true;
            label7.Text = "Average: " + stat.Mat() + " (error = " + Math.Round(stat.MatErr(), 3) + "%)";
            label8.Text = "Variance: " + stat.Disp() + " (error = " + Math.Round(stat.DispErr(), 3) + " %)";
            label9.Text = "Chi-squared: " + stat.ChiCheck();
        }
        class Statistica
        {
            int N;
            decimal E, E0, D, D0, Chi;
            int[] Statistics;
            decimal[] Probabilities, Frequency;
            public bool Set(params decimal[] p)
            {
                Probabilities = new decimal[p.Length];
                Statistics = new int[p.Length];
                Frequency = new decimal[p.Length];
                N = (int)p[0]; 
                E = E0 = D = D0 = Chi = 0;
                Probabilities[p.Length - 1] = 1;
                Statistics[p.Length - 1] = 0;
                for (int i = 1; i < p.Length; i++)
                {
                    Probabilities[i - 1] = p[i];
                    Probabilities[p.Length - 1] -= p[i];
                    Statistics[i - 1] = 0;
                }
                for (int i = 0; i < Probabilities.Length; i++)
                {
                    E0 += (i + 1) * Probabilities[i];
                    D0 += (i + 1) * (i + 1) * Probabilities[i];
                }
                D0 -= E0 * E0;
                if (Probabilities[p.Length - 1] < 0) return false;
                return true;
            }
            public decimal[] Get()
            {
                Random rnd = new Random();
                Frequency = new decimal[Statistics.Length];
                int k; decimal A;
                for (int i = 0; i < N; i++)
                {
                    A = (decimal)rnd.NextDouble();
                    for (k = -1; A > 0; k++) A -= Probabilities[k + 1];
                    Statistics[k]++;
                }
                for (int i = 0; i < Statistics.Length; i++)
                {
                    Frequency[i] = (decimal)Statistics[i] / N;
                }
                return Frequency;
            }
            public decimal Mat()
            {
                for (int i = 0; i < Frequency.Length; i++) E += (i + 1) * Frequency[i];
                return E;
            }
            public decimal MatErr()
            {
                return Math.Abs(E - E0) * 100 / Math.Abs(E0);
            }
            public decimal Disp()
            {
                for (int i = 0; i < Frequency.Length; i++) D += (i + 1) * (i + 1) * Frequency[i];
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
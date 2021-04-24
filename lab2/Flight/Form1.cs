using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double dt = 0.01;
        const double g = 9.81;

        double a;
        double v0;
        double y0;

        double t;
        double x;
        double y;
        int time;


        private void btStart_Click(object sender, EventArgs e)
        {
            a = (double)edAngle.Value;
            v0 = (double)edSpeed.Value;
            y0 = (double)edHeight.Value;

            if (a>90 || a<=0)
            {
                LabelTime.Text = "Ошибка. Данные не корректны! Угол должен быть от 0 до 90. ";
                label4.Text = "";
                label5.Text = "";
                timer1.Stop();
            }
            else
            {
                timer1.Start();
                
                double Ymax = y0 + (v0 * v0 * Math.Sin(a * Math.PI / 180) * Math.Sin(a * Math.PI / 180)) / (2 * g);
                double Xmax = v0 * Math.Cos(a * Math.PI / 180) * (v0 * Math.Sin(a * Math.PI / 180) + Math.Sqrt(v0 * v0 * Math.Sin(a * Math.PI / 180) * Math.Sin(a * Math.PI / 180) + 2 * g * y0)) / g;

                chart1.ChartAreas[0].AxisX.Maximum = Xmax + Xmax * 0.02;
                chart1.ChartAreas[0].AxisY.Maximum =  Ymax + Ymax * 0.02;
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Minimum = 0;

            }


            if (btStart.Text == "Старт!" & timer1.Enabled == true)
            {
                chart1.Series[0].Points.Clear();
                btStart.Text = "Пауза";
                t = 0;
                x = 0;
                y = y0;
                time = 0;
                chart1.Series[0].Points.AddXY(x, y);
            }
            else if (btStart.Text == "Пауза")
            {
                btStart.Text = "Продолжить";
                timer1.Enabled = false;
            }
            else if (btStart.Text == "Продолжить")
            {
                btStart.Text = "Пауза";
                timer1.Enabled = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            x = v0 * Math.Cos(a * Math.PI / 180) * t;
            y = y0 + v0 * Math.Sin(a * Math.PI / 180) * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);
            if (y <= 0)
            {
                timer1.Stop();
                btStart.Text = "Старт!";
            }
            time++;
            LabelTime.Text = $"Sec: {t}";
            label4.Text = $"X: {x}";
            label5.Text = $"Y: {y}";
        }


    }
}

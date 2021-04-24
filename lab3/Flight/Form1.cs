using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double a;
        double v0;
        double y0;
        double S;
        double m;
        Graf graf;
        private void btStart_Click(object sender, EventArgs e)
        {
            a = (double)edAngle.Value;
            v0 = (double)edSpeed.Value;
            y0 = (double)edHeight.Value;
            m = (double)edWeight.Value;
            S = (double)edSquare.Value;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, y0);
            graf = new Graf();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graf.createGraf(a, v0, y0, m, S);
            chart1.Series[0].Points.AddXY(graf.pointX(), graf.pointY());
            if (graf.pointY() <= 0) timer1.Stop();
        }
    }

    class Graf
    {
        double k;
        double t = 0;
        double x1;
        double y1;
        const double dt = 0.1;
        const double C = 0.15;
        const double rho = 1.29;
        public Point[] points = new Point[2];

        public Graf()
        {
            points[0] = new Point();
            points[1] = new Point();

        }
        public void createGraf (double a, double v0, double y0, double m, double S)
        {
            k = 0.5 * C * S * rho / m;
            t += dt;
            x1 = points[0].findX(a, v0, k, t);
            y1 = points[1].findY(a, v0, y0, k, t);
        }

        public double pointX ()
            {
                return x1;
            }
        public double pointY()
        {
            return y1;
        }
    }

    class Point 
    {
        double x;
        double y;
        double vx;
        double vy;
        const double g = 9.81;

        public Point()
        {

        }
        public double findVX (double v0, double a)
        {
            vx = v0 * Math.Cos(a * Math.PI / 180);
            return vx;
        }

        public double findVY(double v0, double a)
        {
            vy = v0 * Math.Sin(a * Math.PI / 180);
            return vy;
        }

        public double findX(double a, double v0,  double k, double dt)
        {
            vx = findVX(v0,a) - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
            x = x + vx * dt;
            return x;
        }

        public double findY(double a, double v0, double y0,  double k, double dt)
        {
            y = y0;
            vy = findVY(v0, a) - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;
            y = y + vy * dt;
            return y;
        }

    }


}

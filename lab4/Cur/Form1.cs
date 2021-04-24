using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.05;
        double rate = 70;
        int time = 0;
        Random random = new Random();
        double rub;
        double dol;
        double q;

        private void btStart_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, rate);
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            rate = rate * (1 + k * (random.NextDouble() - 0.5));
            time++;
            chart1.Series[0].Points.AddXY(time, rate);
            CurrentRate.Text = rate.ToString();
            chart1.ChartAreas[0].AxisX.Maximum = time;
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            rub = (double)rubles.Value;
            dol = (double)dollar.Value;
            q = (double)quantity.Value;

            if (rub < rate * q)
            {
                MessageBox.Show(
                        "Вы превысили лимит!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                rubles.Value = (decimal)(rub - rate * q);
                dollar.Value = (decimal)(dol + q);
            }
        }

        private void Sell_Click(object sender, EventArgs e)
        {
            rub = (double)rubles.Value;
            dol = (double)dollar.Value;
            q = (double)quantity.Value;

            if (dol < q)
            {
                MessageBox.Show(
                        "Вы превысили лимит!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                rubles.Value = (decimal)(rub + rate * q);
                dollar.Value = (decimal)(dol - q);
            }
        }
    }
}

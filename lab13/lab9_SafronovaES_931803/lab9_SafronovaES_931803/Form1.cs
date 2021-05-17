using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9_SafronovaES_931803
{
    public partial class Form1 : Form
    {
        int n;
        public int[] stat;
        public decimal[] prob;
        public decimal[] freq;

        Random rnd = new Random();

        decimal e, e0, d, d0, chi, p;

        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
           try
           {
                p = numericUpDown4.Value;
                n = (int)numericUpDown5.Value;
                stat = new int[5];
                prob = new decimal[5];
                freq = new decimal[5];

                Forecast();

                chart1.Series[0].Points.Clear();

                DrawGraph();

                for (int i = 0; i < 5; i++)
                    chart1.Series[0].Points.AddXY(i + 1, Math.Round(prob[i], 3));

                chart1.Series[0].IsValueShownAsLabel = true;

                label3.Text = "Среднее: " + Mat() + "     - ошибка = " + MatError() + "%";
                label4.Text = "Дисперсия: " + Disp() + "     - ошибка = " + Math.Round(DispError(), 3) + " %";
                label5.Text = "Хи-квадрат: " + Chi();
            }
           catch
           {
                MessageBox.Show(
                "Проверьте корректность введёных данных!",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
           }
      
        }

        public void  Forecast ()
        {
            e = e0 = d = d0 = chi = 0;
            decimal m = p;
            prob[4] = 1; 
            stat[4] = 0;
            for (int i = 0; i < 4; i++)
            {
                prob[i] = m;
                prob[4] -= prob[i];
                stat[i] = 0;
                e0 += (i + 1) * prob[i];
                d0 += (i + 1) * (i + 1) * prob[i];
                m *= 1 - p;
            }
            e0 += 4 * prob[4];
            d0 += 16 * prob[4];
            d0 -= e0 * e0;

        }

        public void DrawGraph ()
        {
            Random rnd = new Random();
            int x;
            for (int i = 0; i < n; i++)
            {
                x = (int)Math.Truncate(Math.Log(rnd.NextDouble()) / Math.Log((double)(1 - p)));
                if (x < 5) stat[x]++;
                else stat[4]++;
            }
            for (int i = 0; i < stat.Length; i++)
            {
                freq[i] = (decimal)stat[i] / n;
            }
        }

        public decimal Mat()
        {
            for (int i = 0; i < 5; i++) 
                e += (i + 1) * freq[i];
            return e;
        }
        public decimal MatError()
        {
            return Math.Round(Math.Abs(e - e0) * 100 / Math.Abs(e0), 3);
        }
        public decimal Disp()
        {
            for (int i = 0; i < 5; i++) 
                d += (i + 1) * (i + 1) * freq[i];
            d -= e * e;
            return d;
        }
        public decimal DispError()
        {
            return Math.Abs(d - d0) * 100 / Math.Abs(d0);
        }
        public string Chi()
        {
            for (int i = 0; i < 5; i++) 
                chi += stat[i] * stat[i] / (n * prob[i]);
            chi -= n;
           
            if (chi < (decimal)11.07) 
                return Math.Round(chi, 3) + " < 11.07 ложь";
            else return Math.Round(chi, 3) + " > 11.07 ложь";
        }

    }
}

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
        int[] stat;
        decimal[] prob;
        decimal[] freq;
        Random rnd = new Random();
        decimal sum;

        decimal e, e0, d, d0, chi;

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            sum = numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value + numericUpDown6.Value;
            
            if (1-sum <= 0 )
                label2.Text = "Не соблюдено условие нормировки! Проба №5 < 0";
            else if (sum + numericUpDown4.Value != 1) 
                numericUpDown4.Value = 1 - sum;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
           {
                n = (int)numericUpDown5.Value;

                Forecast(numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value, numericUpDown6.Value);

                chart1.Series[0].Points.Clear();

                DrawGraph();

                for (int i = 0; i < freq.Length; i++)
                    chart1.Series[0].Points.AddXY(i + 1, freq[i]);

                chart1.Series[0].IsValueShownAsLabel = true;

                label3.Text = "Среднее: " + Mat() + "     - ошибка = " + Math.Round(MatError(), 3) + "%";
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

        public void  Forecast (params decimal[] p)
        {
            prob = new decimal[p.Length];
            stat = new int[p.Length];
            prob [p.Length - 1] = 1;
            stat [p.Length - 1] = 0;

            e = e0 = d = d0 = chi = 0;

            for (int i = 1; i < p.Length; i++)
            {
                prob [i - 1] = p[i];
                prob[p.Length - 1] -= p[i];
                stat [i - 1] = 0;
            }

            for (int i = 0; i < prob.Length; i++)
            {
                e0 += (i + 1) * prob[i];
                d0 += (i + 1) * (i + 1) * prob[i];
            }
            d0 -= e0 * e0;
        }

        public void DrawGraph ()
        {
            freq = new decimal[stat.Length];
            int k; 
            decimal A;

            for (int i = 0; i < n; i++)
            {
                A = (decimal)rnd.NextDouble();
                for (k = -1; A > 0; k++) A -= prob[k + 1];
                stat[k]++;
            }
            for (int i = 0; i < stat.Length; i++)
                freq[i] = (decimal)stat[i] / n;          
        }

        public decimal Mat()
        {
            for (int i = 0; i < freq.Length; i++) 
                e += (i + 1) * freq[i];
            return e;
        }
        public decimal MatError()
        {
            return Math.Abs(e - e0) * 100 / Math.Abs(e0);
        }
        public decimal Disp()
        {
            for (int i = 0; i < freq.Length; i++) 
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
            for (int i = 0; i < prob.Length; i++) 
                chi += stat[i] * stat[i] / (n * prob[i]);
            chi -= n;
           
            if (chi < (decimal)11.07) 
                return Math.Round(chi, 3) + " < 11.07 ложь";
            else return Math.Round(chi, 3) + " > 11.07 ложь";
        }

    }
}

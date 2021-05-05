using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8_SafronovaES_931803
{
    public partial class Form1 : Form
    {
        public double p1;
        public double p2;
        public double p3;
        public NumericUpDown _getP1 = new System.Windows.Forms.NumericUpDown();
        public NumericUpDown _getP2 = new System.Windows.Forms.NumericUpDown();
        public NumericUpDown _getP3 = new System.Windows.Forms.NumericUpDown();
        public Form _params = new Form();


        public Form1()
        {
            InitializeComponent();

            _params.ClientSize = new System.Drawing.Size(130, 150);
            _params.Location = new System.Drawing.Point(150, 150);

            _getP1.Location = new System.Drawing.Point(5, 5);
            _getP1.Name = "P";
            _getP1.Size = new System.Drawing.Size(118, 27);
            _getP1.TabIndex = 5;
            _getP1.Value = 34;
            _getP1.Minimum = 0;
            _getP1.Maximum = 100;

            _getP2.Location = new System.Drawing.Point(5, 35);
            _getP2.Name = "P";
            _getP2.Size = new System.Drawing.Size(118, 27);
            _getP2.TabIndex = 5;
            _getP2.Value = 33;
            _getP2.Minimum = 0;
            _getP2.Maximum = 100;

            _getP3.Location = new System.Drawing.Point(5, 65);
            _getP3.Name = "P";
            _getP3.Size = new System.Drawing.Size(118, 27);
            _getP3.TabIndex = 5;
            _getP3.Value = 33;
            _getP3.Minimum = 0;
            _getP3.Maximum = 100;

            _getP1.ValueChanged += new System.EventHandler(this.Change);
            _getP2.ValueChanged += new System.EventHandler(this.Change);
            _getP3.ValueChanged += new System.EventHandler(this.Change);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var rand = new Random();
            
            var a = rand.Next(1, 100);

            p1 = (double)_getP1.Value;
            p2 = (double)_getP2.Value;
            p3 = (double)_getP3.Value;

            double[] prob = new double[3] { p1, p2, p3 };

            Dictionary<int, string> answer = new Dictionary<int, string>(3);
            answer.Add(1, "Yes");
            answer.Add(2, "No");
            answer.Add(3, "May be");

            int i = 0;


            foreach (int p in prob)
            {
                if (a > 0)
                {
                    a -= p;
                    i++;
                }
                else
                {
                    break;
                }
            }
            label1.Text = answer[i];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            _params.Controls.Add(_getP1);
            _params.Controls.Add(_getP2);
            _params.Controls.Add(_getP3);
            _params.ShowDialog(this);
        }

        private void Change(object sender, EventArgs e)
        {
            if ((_getP1.Value + _getP2.Value + _getP3.Value) !=100)
                _getP3.Value = 100- _getP1.Value - _getP2.Value;
        }

    }
}

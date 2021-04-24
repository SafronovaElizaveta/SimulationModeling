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
        public double p;
        public NumericUpDown _getP = new System.Windows.Forms.NumericUpDown();
        public Form _params = new Form();

        public Form1()
        {
            InitializeComponent();

            _params.ClientSize = new System.Drawing.Size(130, 35);
            _params.Location = new System.Drawing.Point(150, 150);

            _getP.Location = new System.Drawing.Point(5, 5);
            _getP.Name = "P";
            _getP.Size = new System.Drawing.Size(118, 27);
            _getP.TabIndex = 5;
            _getP.Value = 50;
            _getP.Minimum = 0;
            _getP.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var rand = new Random();
            
            var a = rand.Next(0, 100);

            p = (double)_getP.Value;

            if (a < p)  
                label1.Text = "Yes";
            else          
                label1.Text = "No";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _params.Controls.Add(_getP);
            _params.ShowDialog(this);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12_SaronovaES_931803
{

    public partial class Form1 : Form
    {
        int j, i, k;

        public Team[] game;
        public Form1()
        {
            InitializeComponent();
            
            game = new Team[8];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            j = 0;

            foreach (NumericUpDown lambda in panel1.Controls)
            {
                game[j] = new Team ((int)lambda.Value, 0);
                j++;
            }

            for (i = 0; i < 7; i++)
            {
                listBox1.Items.Add("Team " + (i + 1));
                for (k = i + 1; k < 8; k++)
                    listBox1.Items.Add( " vs Team " + (k + 1) + " (" + game[i].Result() + ":" + game[k].Result() + ")\n             ");
            }
            int ws = 0;
            for (i = 0; i < 8; i++)
            {
                if (game[i].ts > ws) 
                    ws = game[i].ts;
            }
            label10.Text = "Winners:   team ";
            
            for (i = 0; i < 8; i++)
            {
                if (game[i].ts == ws) 
                    label10.Text += (i + 1) + "  ";
            }
        }

        public class Team
        {
            public int lambda, ts;
            Random rnd = new Random();
            double sum;
            int goal;

            public Team (int lam, int tot_s)
            {
                lambda = lam;
                ts = tot_s;
            }

            public int Result()
            {
                sum = 0;
                for (goal = -1; sum >= -lambda; goal++) 
                    sum += Math.Log(rnd.NextDouble());
                ts += goal;
                return goal;
            }
        }
    }
}

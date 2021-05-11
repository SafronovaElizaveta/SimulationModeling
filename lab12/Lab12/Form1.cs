using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        Team[] Game;
        public Form1()
        {
            InitializeComponent();
            Game = new Team[8];
            for (int i = 0; i < 8; i++)
                Game[i] = new Team();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Set();
            Get();
        }
        void Set()
        {
            int i = 0;
            foreach (NumericUpDown lambda in panel1.Controls)
            {
                Game[i].Lambda = (int)lambda.Value;
                Game[i].TotalScore = 0;
                i++;
            }
        }
        void Get()
        {
            label3.Text = "";
            for (int i = 0; i < 7; i++)
            {
                label3.Text += "Team " + (i + 1);
                for (int j = i + 1; j < 8; j++)
                    label3.Text += " vs Team " + (j + 1) + " (" + Game[i].Result() + ":" + Game[j].Result() + ")\n             ";
                label3.Text += "\n";
            }
            int WinnersScore = 0;
            for (int i = 0; i < 8; i++)
            {
                if (Game[i].TotalScore > WinnersScore) WinnersScore = Game[i].TotalScore;
            }
            label4.Text = "Winners:\n";
            for (int i = 0; i < 8; i++)
            {
                if (Game[i].TotalScore == WinnersScore) label4.Text += "               Team " + (i + 1) + "\n";
            }
        }
        class Team
        {
            public int Lambda, TotalScore;
            Random rnd = new Random();
            public int Result()
            {
                int goals; double sum = 0;
                for (goals = -1; sum >= -Lambda; goals++) sum += Math.Log(rnd.NextDouble());
                TotalScore += goals;
                return goals;
            }
        }
    }
}

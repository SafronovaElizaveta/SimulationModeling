using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        int money = 100;

        int time = 0;

        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        public Form1()
        {
            InitializeComponent();

            foreach (CheckBox cb in panel1.Controls)
                field.Add(cb, new Cell());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked)
            {
                money -= 2;
                StartGrow(cb);
            }
            else
            {
                switch (field[cb].state)
                {
                    case CellState.Green:
                        money += 1;
                        break;
                    case CellState.Yellow:
                        money += 3;
                        break;
                    case CellState.Red:
                        money += 5;
                        break;
                    case CellState.Overgrow:
                        money -= 1;
                        break;
                }
                Cut(cb);
            }
            textBox1.Text = money.ToString();
        }

        internal void StartGrow(CheckBox cb)
        {
            field[cb].StartGrow();
            UpdateBox(cb);
        }

        internal void Cut(CheckBox cb)
        {
            field[cb].Cut();
            UpdateBox(cb);
        }

        internal void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;

            switch (field[cb].state)
            {
                case CellState.Planted:
                    c = Color.Black;
                    break;
                case CellState.Green:
                    c = Color.Green;
                    break;
                case CellState.Yellow:
                    c = Color.Yellow;
                    break;
                case CellState.Red:
                    c = Color.Red;
                    break;
                case CellState.Overgrow:
                    c = Color.Brown;
                    break;
            }
            cb.BackColor = c;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            foreach (CheckBox cb in panel1.Controls)
                NextStep(cb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 25;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    class Cell
    {
        public CellState state = CellState.Empty;
        public int progress = 0;
        const int prPlanted = 20;
        const int prGreen = 100;
        const int prYellow = 120;
        const int prRed = 140;


        internal void StartGrow()
        {
            state++;
            progress = 1;
        }
        internal void Cut()
        {
            state = CellState.Empty;
            progress = 0;
        }
        internal void NextStep()
        {
            if (state != CellState.Empty && state != CellState.Overgrow)
            {
                progress++;
                if (progress < prPlanted) state = CellState.Planted;
                else if (progress < prGreen) state = CellState.Green;
                else if (progress < prYellow) state = CellState.Yellow;
                else if (progress < prRed) state = CellState.Red;
                else state = CellState.Overgrow;
            }

        }

    }

    enum CellState
    {
        Empty,
        Planted,
        Green,
        Yellow,
        Red,
        Overgrow
    }

}

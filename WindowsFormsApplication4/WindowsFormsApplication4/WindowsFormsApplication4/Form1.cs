using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{

    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        Dictionary<CheckBox, Economy> income = new Dictionary<CheckBox, Economy>();
        Economy expenses = new Economy();
        public int time = 0;
        Label label = new Label();


        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
            {
                field.Add(cb, new Cell());
                label = new Label { Parent = cb, BorderStyle = BorderStyle.FixedSingle, AutoSize = true };
                income.Add(cb, new Economy());
                income[cb].budget = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked) Plant(cb);
            else Harvest(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (CheckBox cb in panel1.Controls)
                NextStep(cb);
            time++;
            label1.Text = "Time is " + time;
            label2.Text = "Budget is " + expenses.budget;

            if (expenses.budget < 2)
                label2.Text = "Insufficient funds: " + expenses.budget;
        }

        private void Plant(CheckBox cb)
        {
            if (expenses.budget >= 2)
            {
                income[cb].Plant();
                expenses.Plant();
                field[cb].Plant();
                UpdateBox(cb);
            }
        }

        private void Harvest(CheckBox cb)
        {
            if (expenses.budget >= 2)
            {
                income[cb].Harvest(field[cb].state);
                expenses.Harvest(field[cb].state);
                field[cb].Harvest();
                UpdateBox(cb);
            }

        }

        private void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;
            String textbox = "Empty";
            switch (field[cb].state)
            {
                case CellState.Planted: c = Color.Gray;
                    textbox = "Planted";
                    break;
                case CellState.Green: c = Color.Green;
                    textbox = "Green";
                    break;
                case CellState.Immature: c = Color.Yellow;
                    textbox = "Immature";
                    break;
                case CellState.Mature: c = Color.Red;
                    textbox = "Mature";
                    break;
                case CellState.Overgrown: c = Color.Brown;
                    textbox = "Overgrown";
                    break;
            }
            cb.BackColor = c;
            int timeCell = 0;
            String textCell;
            if (field[cb].state != CellState.Empty && field[cb].state != CellState.Overgrown)
            {
                timeCell = field[cb].GetTimeProgress();
                textCell = $"State: {textbox} \nTime = {timeCell}";
            }
            else
                textCell = $"State: {textbox}";
            cb.Text = textCell;

            foreach (Label labelText in cb.Controls)
            {
                labelText.Text = $"{income[cb].budget}";
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           string timeModel = textBox1.Text;
            if (String.IsNullOrEmpty(timeModel))
                Cell.Getpr(1) = 0;
            else
                Cell.Getpr(1) = Int32.Parse(timeModel);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string timeModel = textBox2.Text;
            if (String.IsNullOrEmpty(timeModel))
                Cell.Getpr(2) = 0;
            else
                Cell.Getpr(2) = Int32.Parse(timeModel);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string timeModel = textBox3.Text;
            if (String.IsNullOrEmpty(timeModel))
                Cell.Getpr(3) = 0;
            else
                Cell.Getpr(3) = Int32.Parse(timeModel);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string timeModel = textBox4.Text;
            if (String.IsNullOrEmpty(timeModel))
                Cell.Getpr(4) = 0;
            else
                Cell.Getpr(4) = Int32.Parse(timeModel);
        }

    }

    enum CellState
    {
        Empty,
        Planted,
        Green,
        Immature,
        Mature,
        Overgrown
    }


    class Cell
    {
        public CellState state = CellState.Empty;
        public int progress = 0;

        public static int prPlanted = 20;
        public static int prGreen = 100;
        public static int prImmature = 120;
        public static int prMature = 140;

        public static ref int Getpr (int n)
        {
            switch (n)
            {
                case 1:
                    return ref prPlanted;
                case 2:
                    return ref prGreen;
                case 3:
                    return ref prImmature;
            }

            return ref prMature;

        }

        public int GetTimeProgress()
        {
            return progress;
        }

        public void Plant()
        {
            state = CellState.Planted;
            progress = 1;

        }

        public void Harvest()
        {
            state = CellState.Empty;
            progress = 0;

        }

        public void NextStep()
        {
            if ((state != CellState.Empty) && (state != CellState.Overgrown))
            {
                progress++;
                if (progress < prPlanted) state = CellState.Planted;
                else if (progress < prGreen) state = CellState.Green;
                else if (progress < prImmature) state = CellState.Immature;
                else if (progress < prMature) state = CellState.Mature;
                else state = CellState.Overgrown;
            }

        }

    }

    class Economy
    {
        public int budget = 100;

        public void Plant()
        {
            budget -= 2;
        }

        public void Harvest(CellState state)
        {
            switch (state)
            {
                case CellState.Immature:
                    budget += 3 ;
                    break;
                case CellState.Mature:
                    budget += 5;
                    break;
                case CellState.Overgrown:
                    budget -= 1;
                    break;
            }
        }


    }

}



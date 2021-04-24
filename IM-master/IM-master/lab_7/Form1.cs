using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab_7
{
    public partial class Form1 : Form
    {
        public Simulation simulation;
        private decimal rent;
        private decimal balance;
        private decimal salaries;
        private decimal speed;
        public Form1()
        {
            InitializeComponent();
            balance = BalanceNumeric.Value;
            salaries = SalaryNumeric.Value;
            rent = RentNumeric.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            simulation.TimeTick();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            simulation = new Simulation(balance, rent, salaries, speed, chart1, dateTimePicker1, listBox1);
            buttonPause.Enabled = true;
            buttonStop.Enabled = true;
            dateTimePicker1.Enabled = false;
            chart1.Series[0].Points.Clear();
            timer1.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            chart1.Series[0].Points.Clear();
            timer1.Stop();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "Пауза")
            {
                timer1.Stop();
                buttonPause.Text = "Возобновить";
            }
            else
            {
                buttonPause.Text = "Пауза";
                timer1.Start();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval /= (int)(sender as NumericUpDown).Value;
        }
    }



    public class Simulation
    {
        private Chart _chart;
        private ListBox _listBox;
        private Balance _balance;
        private Balance _previousBalance;
        private AdBudget _adBudget;
        private DateTimePicker _dateTimePicker;

        private decimal _rent;
        private decimal _salaries;
        private decimal _income;

        private int _days = 1;
        private int _hours = 1;
        private int _amountOfOrders;
        private int _orders;

        private const int _standardClientsFlow = 2;
        private const int _MaxOrders = 18;


        public Simulation(decimal balance, decimal rent, decimal salaries, decimal speed, Chart chart,
            DateTimePicker dateTimePicker, ListBox listBox)
        {
            _balance = new Balance();
            _previousBalance = new Balance();
            _balance.Value = balance;
            _previousBalance.Value = balance;
            _adBudget = new AdBudget(_balance);
            _rent = rent;
            _salaries = salaries;
            _chart = chart;
            _amountOfOrders = _standardClientsFlow * _adBudget.GetMultiplicator();
            _listBox = listBox;
            _dateTimePicker = dateTimePicker;
            ShowEveryDayInfo();
            _listBox.Items.Add($"Рекламный бюджет - {Math.Round(_adBudget.Value, 2).ToString()}");
        }

        public void TimeTick()
        {
            if (_days % 31 == 0)
            {
                PassMonth();
            }

            Order order;
            if (_orders < _amountOfOrders)
            {
                order = new Order(false);
                _orders++;
                ShowOrderInfo(order);
            }
            else
                order = new Order(true);
            _balance.Income(order.Cost);

            RenderChart(_hours, _balance.Value);

            _hours++;
            if (_hours > 18)
            {
                PassDay();
            }
        }

        private void PassMonth()
        {
            _days = 1;
            _balance.Value -= _rent + _salaries;
            _adBudget.Value = _balance.Value * AdBudget.coefficient;

            _previousBalance.Value = _balance.Value;
            ShowMonthInfo();
        }

        private void ShowEveryDayInfo()
        {
            _listBox.Items.Add($"Дата - {_dateTimePicker.Value.ToShortDateString()}");
            _listBox.Items.Add($"Количество заказов - {_amountOfOrders}");
            _listBox.Items.Add($"Прибыль - {Math.Round(_income,2).ToString()}");
            _listBox.Items.Add("");
            _listBox.Items.Add("");
        }


        private void ShowOrderInfo(Order order)
        {
            _listBox.Items.Add($"Заказ: {order.OrderAndCost.Item1}" + 
                $" Стоимость заказа: {Math.Round(order.OrderAndCost.Item2,2).ToString()}");
        }

        private void ShowMonthInfo()
        {
            _listBox.Items.Add("=================================================");
            _listBox.Items.Add($"Уплачена зарплата сотрудникам в размере {_salaries}");
            _listBox.Items.Add($"Уплачена аренда в размере {_rent}");
            _listBox.Items.Add($"Рекламный бюджет - {Math.Round(_adBudget.Value, 2).ToString()}");
            _listBox.Items.Add("");
        }

        private void PassDay()
        {
            _hours = 1;
            _income = _balance.Value -_previousBalance.Value;
            var income = Math.Round(_income, 2);
            _chart.Series[0].Points.Clear();
            Random random = new Random();
            _amountOfOrders = random.Next(3,_standardClientsFlow * _adBudget.GetMultiplicator());

            _dateTimePicker.Value = _dateTimePicker.Value.AddDays(1);
            _previousBalance.Value = _balance.Value;
            _orders = 0;
            _listBox.Items.Add("");
            ShowEveryDayInfo();
            _days++;
        }
        private void RenderChart(int hour, decimal balance)
        {
            _chart.Series[0].Points.AddXY(hour, balance);
        }
    }



    public class Balance
    {
        public decimal Value { get; set; }

        public void MonthPayment(decimal rent, decimal salaries)
        {
            
            Value -= (salaries + rent);
        }
        public void Income(decimal income)
        {
            Value += income;
        }
    }


    public class AdBudget
    {
        public const decimal coefficient = 0.15M;
        public decimal Value { get; set; }
        public AdBudget(Balance balance)
        {
            Value = balance.Value * coefficient;
        }

        public int GetMultiplicator()
        {
            return (int)Math.Floor(Value / 100);
        }
    }

    public class Order
    {
        public decimal Cost { get; set; }
        private Random _random;
        private static string[] orders =
            {
                "Торт Фруктовый",
                "Пирожное Картошка",
                "Торт Наполеон",
                "Леденцы",
                "Мармеладные червячки",
                "Торт бисквитный",
                "Конфеты шоколадные",
                "Торт шоколадный",
            };
        public bool IsNull { get; }
        public (string, decimal) OrderAndCost { get; }

        public Order(bool isNull)
        {
            IsNull = isNull;
            if (!isNull)
            {
                _random = new Random(Environment.TickCount);
                var number = _random.Next(1, orders.Length);
                var chosenString = orders[number];
                Cost = (decimal)(_random.NextDouble() * 40d);
                if (Cost < 5)
                {
                    OrderAndCost = (chosenString, 5);
                    Cost = 5;
                }
                else
                {
                    OrderAndCost = (chosenString, Cost);
                }
            }
            else
            {
                Cost = 0;
            }
        }
    }
}


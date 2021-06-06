using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab18
{

    public partial class Form1 : Form
    {
        Model md;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            md = new Model((double)numericUpDown3.Value, (double)numericUpDown4.Value, (int)numericUpDown1.Value, (double)numericUpDown2.Value, (int)numericUpDown5.Value);


            md.Probability(md.OriginalAO(), md.OriginalAQP());
            md.Statistics();

            var sortedStat = new SortedDictionary<int, double>(md.stat);

            foreach (int i in sortedStat.Keys)
            {
                chart2.Series[0].Points.AddXY(i, md.stat[i]);
            }

            foreach (int i in md.freq.Keys)
            {
                chart1.Series[0].Points.AddXY(i, md.freq[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
        }
    }

    public class Model
    {
        double next_person, next_operator;
        double time = 0;
        double T;
        int k;
        int N;

        double lambda;
        double psi;
        double rho;

        int number_operator;
        double ISD;

        public Dictionary<int, double> freq = new Dictionary<int, double>();
        public Dictionary<int, double> stat;

        public Model(double l, double m, int n0, double t0, int noo)
        {
            lambda = l;
            psi = m;
            rho = l / m;
            N = n0;
            T = t0;
            k = 0;
            number_operator = noo;
            ISD = OriginalStationaryDistribution(noo);


        }
        public Agent OriginalAQP()
        {
            Agent AQP = new Agent();
            AQP.CreateAgentQueuePerson(lambda);
            return AQP;
        }
        public Agent OriginalAO()
        {
            Agent AO = new Agent();
            AO.CreateAgentOperator(psi, number_operator);
            return AO;
        }

        public void Statistics()
        {
            stat = freq;

            foreach (int i in stat.Keys.ToList())
            {
                if (i < number_operator)
                {
                    stat[i] = (Math.Pow(rho, i) / Factorial(i)) * ISD;
                }
                else
                {
                    stat[i] = (Math.Pow(rho, i) / (Factorial(i) * Math.Pow(number_operator, i - number_operator))) * ISD;
                }
            }
        }

        public void Probability(Agent ao, Agent aqp)
        {
            while (k < N)
            {
                while (time < T)
                {
                    next_operator = ao.GetNextEventOperation();
                    next_person = aqp.GetNextEventForQueueClient();
                    if (next_person < next_operator)
                    {
                        aqp.ProcessEventForQueueClient(ao);
                        time += next_person;
                    }
                    else
                    {
                        ao.ProcessEventOperation(aqp);
                        time += next_operator;
                    }
                }
                k++;
                time = 0;
                try
                {
                    freq.Add(ao.engaged_orerator_ + aqp.number_client_, 0);
                }
                catch
                {

                }

                freq[ao.engaged_orerator_ + aqp.number_client_]++;

            }
            foreach (int i in freq.Keys.ToList())
            {
                freq[i] /= N;
            }
        }


        private double OriginalStationaryDistribution(int noo)//ISD
        {
            double temp = 0;

            for (int i = 0; i < noo; i++)
            {
                temp += Math.Pow(rho, i) / Factorial(i);
            }

            double temp1 = Math.Pow(rho, (noo + 1)) / Factorial(noo) * (noo - rho);

            return Math.Pow((temp + temp1), -1);
        }
        private int Factorial(int i)
        {
            int temp = 1;

            for (int j = 1; j <= i; j++)
            {
                temp *= j;
            }

            return temp;
        }
    }

    public class Agent
    {
        double lambda;
        double psi;
        
        int engaged_orerator;
        int number_operator;
        int number_client;
        
        Random rnd = new Random();

        public void CreateAgentOperator(double m, int noo)
        {
            psi = m;
            number_operator = noo;
        }

        public void CreateAgentQueuePerson(double l)
        {
            lambda = l;
            number_client = 0;
        }

        public int engaged_orerator_ { get => engaged_orerator; set => engaged_orerator = value; }
        public int number_operator_ { get => number_operator; }
        public int number_client_ { get => number_client; set => number_client = value; }

        public double GetNextEventOperation()
        {
            if (engaged_orerator > 0)
            {
                double A = rnd.NextDouble();
                double temp = A * engaged_orerator;
                return (-Math.Log(temp) / psi);
            }
            else { return Double.PositiveInfinity; }
        }

        public void ProcessEventOperation(Agent aqp)
        {
            if (aqp.number_client_ == 0)
            {
                engaged_orerator--;
            }
            else
            {
                aqp.number_client_--;
            }
        }

        public double GetNextEventForQueueClient()
        {
            double A = rnd.NextDouble();
            return (-Math.Log(A) / lambda);
        }

        public void ProcessEventForQueueClient(Agent ao)
        {
            if (ao.engaged_orerator_ < ao.number_operator_)
            {
                ao.engaged_orerator_++;
            }
            else
            {
                number_client++;
            }
        }
    }
}

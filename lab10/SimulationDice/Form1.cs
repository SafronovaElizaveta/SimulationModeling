using System;
using System.Windows.Forms;

namespace SimulationDice
{
    public partial class Form1 : Form
    {
        Tossed cube = new Tossed();
        CheatTossed cheat_cube = new CheatTossed();

        

        int c_cube_1, c_cube_2;
        int sum_1, sum_2;
        int count, win, losse;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Quit_Click(object sender, EventArgs e)
        {
            if (CheckCheat.Checked == false)
            {
                c_cube_1 = cube.Throw();
                c_cube_2 = cube.Throw();
            }
            else
            {
                c_cube_1 = cheat_cube.Throw();
                c_cube_2 = cube.Throw();
            }
    
            YourTossed.Text = c_cube_1.ToString();
            OtherTossed.Text = c_cube_2.ToString();
            
            if (count <= 5)
            {
                count++;
                
                Quit.Text = count.ToString();
                ResultBox.Text = "";
                
                sum_1 += c_cube_1;
                sum_2 += c_cube_2;

                LabelSum1.Text = "Ваши очки:" + sum_1;
                LabelSum2.Text = "Очки соперника:" + sum_2;

                if (count == 5)
                {
                    if (sum_1 < sum_2)
                    {
                        ResultBox.Text = "Победил соперник";
                        losse++;
                    }
                    else if (sum_1 > sum_2)
                    {
                        ResultBox.Text = "Вы победили";
                        win++;
                    }
                    else if (sum_1 == sum_2)

                        ResultBox.Text = "Ничья";
                    count = 0;
                    sum_1 = 0;
                    sum_2 = 0;
                }
                
            }
                   
            LabelLoss.Text = "Выигрышей соперника:" + losse;
            LabelWin.Text = "Ваших выигрышей:" + win;
        }

    }

    
   
}

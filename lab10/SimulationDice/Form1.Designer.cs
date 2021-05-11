namespace SimulationDice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.YourTossed = new System.Windows.Forms.TextBox();
            this.OtherTossed = new System.Windows.Forms.TextBox();
            this.Quit = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.RichTextBox();
            this.LabelLoss = new System.Windows.Forms.Label();
            this.LabelWin = new System.Windows.Forms.Label();
            this.CheckCheat = new System.Windows.Forms.CheckBox();
            this.LabelSum1 = new System.Windows.Forms.Label();
            this.LabelSum2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваш бросок:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Бросок соперника:";
            // 
            // YourTossed
            // 
            this.YourTossed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.YourTossed.Location = new System.Drawing.Point(162, 31);
            this.YourTossed.Margin = new System.Windows.Forms.Padding(4);
            this.YourTossed.Name = "YourTossed";
            this.YourTossed.ReadOnly = true;
            this.YourTossed.Size = new System.Drawing.Size(88, 34);
            this.YourTossed.TabIndex = 2;
            // 
            // OtherTossed
            // 
            this.OtherTossed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.OtherTossed.Location = new System.Drawing.Point(162, 91);
            this.OtherTossed.Margin = new System.Windows.Forms.Padding(4);
            this.OtherTossed.Name = "OtherTossed";
            this.OtherTossed.ReadOnly = true;
            this.OtherTossed.Size = new System.Drawing.Size(88, 34);
            this.OtherTossed.TabIndex = 3;
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Transparent;
            this.Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Quit.Location = new System.Drawing.Point(405, 60);
            this.Quit.Margin = new System.Windows.Forms.Padding(4);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(165, 41);
            this.Quit.TabIndex = 1;
            this.Quit.Text = "0";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.BackColor = System.Drawing.Color.White;
            this.ResultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ResultBox.Location = new System.Drawing.Point(16, 172);
            this.ResultBox.Margin = new System.Windows.Forms.Padding(4);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(554, 62);
            this.ResultBox.TabIndex = 6;
            this.ResultBox.Text = "";
            // 
            // LabelLoss
            // 
            this.LabelLoss.AutoSize = true;
            this.LabelLoss.Location = new System.Drawing.Point(322, 260);
            this.LabelLoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLoss.Name = "LabelLoss";
            this.LabelLoss.Size = new System.Drawing.Size(163, 17);
            this.LabelLoss.TabIndex = 7;
            this.LabelLoss.Text = "Выигрышей соперника:";
            // 
            // LabelWin
            // 
            this.LabelWin.AutoSize = true;
            this.LabelWin.Location = new System.Drawing.Point(98, 260);
            this.LabelWin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelWin.Name = "LabelWin";
            this.LabelWin.Size = new System.Drawing.Size(133, 17);
            this.LabelWin.TabIndex = 8;
            this.LabelWin.Text = "Выигрышей ваших:";
            // 
            // CheckCheat
            // 
            this.CheckCheat.AutoSize = true;
            this.CheckCheat.Location = new System.Drawing.Point(463, 308);
            this.CheckCheat.Margin = new System.Windows.Forms.Padding(4);
            this.CheckCheat.Name = "CheckCheat";
            this.CheckCheat.Size = new System.Drawing.Size(107, 21);
            this.CheckCheat.TabIndex = 9;
            this.CheckCheat.Text = "Помоги мне";
            this.CheckCheat.UseVisualStyleBackColor = true;
            // 
            // LabelSum1
            // 
            this.LabelSum1.AutoSize = true;
            this.LabelSum1.Location = new System.Drawing.Point(272, 48);
            this.LabelSum1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSum1.Name = "LabelSum1";
            this.LabelSum1.Size = new System.Drawing.Size(83, 17);
            this.LabelSum1.TabIndex = 10;
            this.LabelSum1.Text = "Ваши очки:";
            // 
            // LabelSum2
            // 
            this.LabelSum2.AutoSize = true;
            this.LabelSum2.Location = new System.Drawing.Point(272, 108);
            this.LabelSum2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSum2.Name = "LabelSum2";
            this.LabelSum2.Size = new System.Drawing.Size(120, 17);
            this.LabelSum2.TabIndex = 11;
            this.LabelSum2.Text = "Очки соперника:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 342);
            this.Controls.Add(this.LabelSum2);
            this.Controls.Add(this.LabelSum1);
            this.Controls.Add(this.CheckCheat);
            this.Controls.Add(this.LabelWin);
            this.Controls.Add(this.LabelLoss);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.OtherTossed);
            this.Controls.Add(this.YourTossed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YourTossed;
        private System.Windows.Forms.TextBox OtherTossed;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.RichTextBox ResultBox;
        private System.Windows.Forms.Label LabelLoss;
        private System.Windows.Forms.Label LabelWin;
        private System.Windows.Forms.CheckBox CheckCheat;
        private System.Windows.Forms.Label LabelSum1;
        private System.Windows.Forms.Label LabelSum2;
    }
}



namespace lab_7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BalanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.RentNumeric = new System.Windows.Forms.NumericUpDown();
            this.SalaryNumeric = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Maximum = 18D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(15, 134);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(553, 475);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Зарплата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Аренда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Баланс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Дата";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(599, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(490, 612);
            this.listBox1.TabIndex = 13;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(457, 19);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(111, 23);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(457, 87);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(111, 23);
            this.buttonStop.TabIndex = 15;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(457, 51);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(111, 23);
            this.buttonPause.TabIndex = 16;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BalanceNumeric
            // 
            this.BalanceNumeric.Location = new System.Drawing.Point(101, 88);
            this.BalanceNumeric.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.BalanceNumeric.Name = "BalanceNumeric";
            this.BalanceNumeric.Size = new System.Drawing.Size(120, 22);
            this.BalanceNumeric.TabIndex = 17;
            this.BalanceNumeric.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // RentNumeric
            // 
            this.RentNumeric.Location = new System.Drawing.Point(101, 52);
            this.RentNumeric.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.RentNumeric.Name = "RentNumeric";
            this.RentNumeric.Size = new System.Drawing.Size(120, 22);
            this.RentNumeric.TabIndex = 18;
            this.RentNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // SalaryNumeric
            // 
            this.SalaryNumeric.Location = new System.Drawing.Point(101, 20);
            this.SalaryNumeric.Maximum = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.SalaryNumeric.Name = "SalaryNumeric";
            this.SalaryNumeric.Size = new System.Drawing.Size(120, 22);
            this.SalaryNumeric.TabIndex = 19;
            this.SalaryNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(286, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(154, 22);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(320, 52);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Скорость";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 652);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.SalaryNumeric);
            this.Controls.Add(this.RentNumeric);
            this.Controls.Add(this.BalanceNumeric);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown BalanceNumeric;
        private System.Windows.Forms.NumericUpDown RentNumeric;
        private System.Windows.Forms.NumericUpDown SalaryNumeric;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
    }
}


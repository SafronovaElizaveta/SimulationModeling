namespace Cur
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Sell = new System.Windows.Forms.Button();
            this.dollar = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rubles = new System.Windows.Forms.NumericUpDown();
            this.Buy = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CurrentRate = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dollar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quantity);
            this.panel1.Controls.Add(this.CurrentRate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Sell);
            this.panel1.Controls.Add(this.dollar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rubles);
            this.panel1.Controls.Add(this.Buy);
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 101);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "$";
            // 
            // Sell
            // 
            this.Sell.Location = new System.Drawing.Point(550, 58);
            this.Sell.Margin = new System.Windows.Forms.Padding(4);
            this.Sell.Name = "Sell";
            this.Sell.Size = new System.Drawing.Size(100, 28);
            this.Sell.TabIndex = 10;
            this.Sell.Text = "Продать";
            this.Sell.UseVisualStyleBackColor = true;
            this.Sell.Click += new System.EventHandler(this.Sell_Click);
            // 
            // dollar
            // 
            this.dollar.DecimalPlaces = 2;
            this.dollar.Location = new System.Drawing.Point(361, 64);
            this.dollar.Margin = new System.Windows.Forms.Padding(4);
            this.dollar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.dollar.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.dollar.Name = "dollar";
            this.dollar.Size = new System.Drawing.Size(128, 22);
            this.dollar.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Руб.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Кошелёк";
            // 
            // rubles
            // 
            this.rubles.DecimalPlaces = 2;
            this.rubles.Location = new System.Drawing.Point(141, 62);
            this.rubles.Margin = new System.Windows.Forms.Padding(4);
            this.rubles.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rubles.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.rubles.Name = "rubles";
            this.rubles.Size = new System.Drawing.Size(128, 22);
            this.rubles.TabIndex = 6;
            this.rubles.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // Buy
            // 
            this.Buy.Location = new System.Drawing.Point(550, 22);
            this.Buy.Margin = new System.Windows.Forms.Padding(4);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(100, 28);
            this.Buy.TabIndex = 5;
            this.Buy.Text = "Купить";
            this.Buy.UseVisualStyleBackColor = true;
            this.Buy.Click += new System.EventHandler(this.Buy_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(843, 56);
            this.btStart.Margin = new System.Windows.Forms.Padding(4);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(100, 28);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Старт";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущий курс";
            // 
            // chart1
            // 
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 101);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsValueShownAsLabel = true;
            series5.LabelFormat = "F2";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(956, 453);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CurrentRate
            // 
            this.CurrentRate.AutoSize = true;
            this.CurrentRate.Location = new System.Drawing.Point(138, 22);
            this.CurrentRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentRate.Name = "CurrentRate";
            this.CurrentRate.Size = new System.Drawing.Size(0, 17);
            this.CurrentRate.TabIndex = 12;
            // 
            // quantity
            // 
            this.quantity.DecimalPlaces = 2;
            this.quantity.Location = new System.Drawing.Point(667, 28);
            this.quantity.Margin = new System.Windows.Forms.Padding(4);
            this.quantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(128, 22);
            this.quantity.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 554);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dollar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Buy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown rubles;
        private System.Windows.Forms.NumericUpDown dollar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Sell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label CurrentRate;
        private System.Windows.Forms.NumericUpDown quantity;
    }
}


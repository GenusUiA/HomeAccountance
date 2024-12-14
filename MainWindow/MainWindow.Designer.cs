using System.Windows.Forms;

namespace Course_project_HOME_ACCOUNTANCE
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Home = new System.Windows.Forms.PictureBox();
            this.Closer = new System.Windows.Forms.Label();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MainWind = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.DateTimePicker();
            this.For = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.Calculate = new System.Windows.Forms.Button();
            this.From1 = new System.Windows.Forms.DateTimePicker();
            this.For1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(177)))), ((int)(((byte)(201)))));
            this.panel1.Controls.Add(this.Home);
            this.panel1.Location = new System.Drawing.Point(1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 634);
            this.panel1.TabIndex = 7;
            // 
            // Home
            // 
            this.Home.Image = global::Course_project_HOME_ACCOUNTANCE.Properties.Resources.home;
            this.Home.Location = new System.Drawing.Point(11, 14);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(80, 80);
            this.Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Home.TabIndex = 0;
            this.Home.TabStop = false;
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(1026, 12);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 12;
            this.Closer.Text = "X";
            this.Closer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Closer_MouseClick);
            this.Closer.MouseEnter += new System.EventHandler(this.Closer_MouseEnter);
            this.Closer.MouseLeave += new System.EventHandler(this.Closer_MouseLeave);
            // 
            // chartPie
            // 
            this.chartPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.chartPie.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 100F;
            chartArea2.InnerPlotPosition.Width = 100F;
            chartArea2.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartPie.Legends.Add(legend2);
            this.chartPie.Location = new System.Drawing.Point(374, 129);
            this.chartPie.MaximumSize = new System.Drawing.Size(652, 439);
            this.chartPie.MinimumSize = new System.Drawing.Size(652, 439);
            this.chartPie.Name = "chartPie";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chartPie.Series.Add(series2);
            this.chartPie.Size = new System.Drawing.Size(652, 439);
            this.chartPie.TabIndex = 13;
            this.chartPie.Text = "chart1";
            // 
            // MainWind
            // 
            this.MainWind.AutoSize = true;
            this.MainWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.MainWind.Location = new System.Drawing.Point(412, 29);
            this.MainWind.Name = "MainWind";
            this.MainWind.Size = new System.Drawing.Size(291, 46);
            this.MainWind.TabIndex = 14;
            this.MainWind.Text = "Главное меню";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(674, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 31);
            this.label3.TabIndex = 31;
            this.label3.Text = "Расходы";
            // 
            // From
            // 
            this.From.AllowDrop = true;
            this.From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.From.Location = new System.Drawing.Point(587, 115);
            this.From.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(111, 22);
            this.From.TabIndex = 35;
            this.From.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // For
            // 
            this.For.AllowDrop = true;
            this.For.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.For.Location = new System.Drawing.Point(818, 115);
            this.For.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.For.Name = "For";
            this.For.Size = new System.Drawing.Size(107, 22);
            this.For.TabIndex = 34;
            this.For.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(780, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "По";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(560, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "С";
            // 
            // Generate
            // 
            this.Generate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Generate.Location = new System.Drawing.Point(659, 146);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(153, 33);
            this.Generate.TabIndex = 36;
            this.Generate.Text = "Сгенерировать";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Calculate
            // 
            this.Calculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Calculate.Location = new System.Drawing.Point(217, 524);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(153, 33);
            this.Calculate.TabIndex = 41;
            this.Calculate.Text = "Рассчитать";
            this.Calculate.UseVisualStyleBackColor = false;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // From1
            // 
            this.From1.AllowDrop = true;
            this.From1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.From1.Location = new System.Drawing.Point(165, 493);
            this.From1.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.From1.Name = "From1";
            this.From1.Size = new System.Drawing.Size(111, 22);
            this.From1.TabIndex = 40;
            this.From1.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // For1
            // 
            this.For1.AllowDrop = true;
            this.For1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.For1.Location = new System.Drawing.Point(358, 493);
            this.For1.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.For1.Name = "For1";
            this.For1.Size = new System.Drawing.Size(107, 22);
            this.For1.TabIndex = 39;
            this.For1.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(320, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "По";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(138, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "С";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1066, 627);
            this.ControlBox = false;
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.From1);
            this.Controls.Add(this.For1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.From);
            this.Controls.Add(this.For);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MainWind);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartPie);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Home;
        private Label Closer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private Label MainWind;
        private Label label3;
        private DateTimePicker From;
        private DateTimePicker For;
        private Label label2;
        private Label label1;
        private Button Generate;
        private Button Calculate;
        private DateTimePicker From1;
        private DateTimePicker For1;
        private Label label4;
        private Label label5;
    }
}
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Home = new System.Windows.Forms.PictureBox();
            this.Closer = new System.Windows.Forms.Label();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MainWind = new System.Windows.Forms.Label();
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
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 100F;
            chartArea1.InnerPlotPosition.Width = 100F;
            chartArea1.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(411, 98);
            this.chartPie.Name = "chartPie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series2";
            this.chartPie.Series.Add(series1);
            this.chartPie.Size = new System.Drawing.Size(567, 471);
            this.chartPie.TabIndex = 13;
            this.chartPie.Text = "chart1";
            // 
            // MainWind
            // 
            this.MainWind.AutoSize = true;
            this.MainWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.MainWind.Location = new System.Drawing.Point(451, 24);
            this.MainWind.Name = "MainWind";
            this.MainWind.Size = new System.Drawing.Size(260, 46);
            this.MainWind.TabIndex = 14;
            this.MainWind.Text = "Main Window";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1066, 627);
            this.ControlBox = false;
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
    }
}
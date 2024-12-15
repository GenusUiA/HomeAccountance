namespace Course_project_HOME_ACCOUNTANCE.Reports_creating
{
    partial class Reports
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
            this.CreateReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateform = new System.Windows.Forms.DateTimePicker();
            this.From = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Closer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(49, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "С";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(269, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "По";
            // 
            // CreateReport
            // 
            this.CreateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.CreateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CreateReport.Location = new System.Drawing.Point(135, 208);
            this.CreateReport.Name = "CreateReport";
            this.CreateReport.Size = new System.Drawing.Size(180, 33);
            this.CreateReport.TabIndex = 4;
            this.CreateReport.Text = "Создать отчет";
            this.CreateReport.UseVisualStyleBackColor = false;
            this.CreateReport.Click += new System.EventHandler(this.CreateReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(149, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Транзакции";
            // 
            // dateform
            // 
            this.dateform.AllowDrop = true;
            this.dateform.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateform.Location = new System.Drawing.Point(304, 153);
            this.dateform.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.dateform.Name = "dateform";
            this.dateform.Size = new System.Drawing.Size(107, 22);
            this.dateform.TabIndex = 25;
            this.dateform.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // From
            // 
            this.From.AllowDrop = true;
            this.From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.From.Location = new System.Drawing.Point(76, 150);
            this.From.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(111, 22);
            this.From.TabIndex = 26;
            this.From.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(164, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 39);
            this.label4.TabIndex = 27;
            this.label4.Text = "Отчеты";
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(412, 9);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 28;
            this.Closer.Text = "X";
            this.Closer.Click += new System.EventHandler(this.Closer_Click);
            this.Closer.MouseEnter += new System.EventHandler(this.Closer_MouseEnter);
            this.Closer.MouseLeave += new System.EventHandler(this.Closer_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course_project_HOME_ACCOUNTANCE.Properties.Resources.Undo_Transparent_Background;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(452, 267);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.From);
            this.Controls.Add(this.dateform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CreateReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(470, 314);
            this.MinimumSize = new System.Drawing.Size(470, 314);
            this.Name = "Reports";
            this.Text = "Отчеты";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateform;
        private System.Windows.Forms.DateTimePicker From;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Closer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
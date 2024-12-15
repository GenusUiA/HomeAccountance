namespace Course_project_HOME_ACCOUNTANCE.Incomes_form
{
    partial class IncomesAdd
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
            this.Incomes = new System.Windows.Forms.LinkLabel();
            this.sumform = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddIncome = new System.Windows.Forms.Button();
            this.categoryform = new System.Windows.Forms.TextBox();
            this.Closer = new System.Windows.Forms.Label();
            this.dateform = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Incomes
            // 
            this.Incomes.ActiveLinkColor = System.Drawing.Color.AntiqueWhite;
            this.Incomes.AutoSize = true;
            this.Incomes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Incomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Incomes.LinkColor = System.Drawing.Color.Black;
            this.Incomes.Location = new System.Drawing.Point(235, 20);
            this.Incomes.Name = "Incomes";
            this.Incomes.Size = new System.Drawing.Size(122, 33);
            this.Incomes.TabIndex = 23;
            this.Incomes.TabStop = true;
            this.Incomes.Text = "Доходы";
            this.Incomes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Incomes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Incomes_LinkClicked);
            // 
            // sumform
            // 
            this.sumform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.sumform.Location = new System.Drawing.Point(32, 133);
            this.sumform.Multiline = true;
            this.sumform.Name = "sumform";
            this.sumform.Size = new System.Drawing.Size(125, 24);
            this.sumform.TabIndex = 19;
            this.sumform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(47, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 31);
            this.label3.TabIndex = 17;
            this.label3.Text = "Сумма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(224, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Категория";
            // 
            // AddIncome
            // 
            this.AddIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.AddIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddIncome.Location = new System.Drawing.Point(187, 186);
            this.AddIncome.Name = "AddIncome";
            this.AddIncome.Size = new System.Drawing.Size(212, 33);
            this.AddIncome.TabIndex = 15;
            this.AddIncome.Text = "Добавить доход";
            this.AddIncome.UseVisualStyleBackColor = false;
            this.AddIncome.Click += new System.EventHandler(this.AddIncome_Click);
            // 
            // categoryform
            // 
            this.categoryform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.categoryform.Location = new System.Drawing.Point(217, 133);
            this.categoryform.Multiline = true;
            this.categoryform.Name = "categoryform";
            this.categoryform.Size = new System.Drawing.Size(160, 24);
            this.categoryform.TabIndex = 24;
            this.categoryform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(554, 9);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 25;
            this.Closer.Text = "X";
            this.Closer.Click += new System.EventHandler(this.Closer_Click);
            this.Closer.MouseEnter += new System.EventHandler(this.Closer_MouseEnter);
            this.Closer.MouseLeave += new System.EventHandler(this.Closer_MouseLeave);
            // 
            // dateform
            // 
            this.dateform.AllowDrop = true;
            this.dateform.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateform.Location = new System.Drawing.Point(430, 135);
            this.dateform.MaxDate = new System.DateTime(2024, 11, 22, 0, 0, 0, 0);
            this.dateform.Name = "dateform";
            this.dateform.Size = new System.Drawing.Size(134, 22);
            this.dateform.TabIndex = 27;
            this.dateform.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(458, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 31);
            this.label1.TabIndex = 26;
            this.label1.Text = "Дата";
            // 
            // IncomesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(594, 231);
            this.ControlBox = false;
            this.Controls.Add(this.dateform);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.categoryform);
            this.Controls.Add(this.Incomes);
            this.Controls.Add(this.sumform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddIncome);
            this.MaximumSize = new System.Drawing.Size(612, 278);
            this.MinimumSize = new System.Drawing.Size(612, 278);
            this.Name = "IncomesAdd";
            this.Text = "Добавление доходов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel Incomes;
        private System.Windows.Forms.TextBox sumform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddIncome;
        private System.Windows.Forms.TextBox categoryform;
        private System.Windows.Forms.Label Closer;
        private System.Windows.Forms.DateTimePicker dateform;
        private System.Windows.Forms.Label label1;
    }
}
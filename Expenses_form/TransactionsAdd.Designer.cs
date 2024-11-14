namespace Course_project_HOME_ACCOUNTANCE
{
    partial class TransactionsAdd
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
            this.CreateTransaction = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sumform = new System.Windows.Forms.TextBox();
            this.dateform = new System.Windows.Forms.DateTimePicker();
            this.placeform = new System.Windows.Forms.TextBox();
            this.categoryform = new System.Windows.Forms.ComboBox();
            this.Expenses = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(61, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "date";
            // 
            // CreateTransaction
            // 
            this.CreateTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.CreateTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CreateTransaction.Location = new System.Drawing.Point(266, 203);
            this.CreateTransaction.Name = "CreateTransaction";
            this.CreateTransaction.Size = new System.Drawing.Size(212, 33);
            this.CreateTransaction.TabIndex = 2;
            this.CreateTransaction.Text = "Create transaction";
            this.CreateTransaction.UseVisualStyleBackColor = false;
            this.CreateTransaction.Click += new System.EventHandler(this.CreateTransaction_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(402, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(239, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "sum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(618, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "place";
            // 
            // sumform
            // 
            this.sumform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.sumform.Location = new System.Drawing.Point(209, 130);
            this.sumform.Multiline = true;
            this.sumform.Name = "sumform";
            this.sumform.Size = new System.Drawing.Size(125, 24);
            this.sumform.TabIndex = 7;
            this.sumform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateform
            // 
            this.dateform.AllowDrop = true;
            this.dateform.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateform.Location = new System.Drawing.Point(33, 128);
            this.dateform.MaxDate = new System.DateTime(2024, 11, 7, 10, 30, 20, 0);
            this.dateform.Name = "dateform";
            this.dateform.Size = new System.Drawing.Size(134, 22);
            this.dateform.TabIndex = 10;
            this.dateform.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // placeform
            // 
            this.placeform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.placeform.Location = new System.Drawing.Point(597, 130);
            this.placeform.Multiline = true;
            this.placeform.Name = "placeform";
            this.placeform.Size = new System.Drawing.Size(125, 24);
            this.placeform.TabIndex = 11;
            this.placeform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // categoryform
            // 
            this.categoryform.FormattingEnabled = true;
            this.categoryform.Location = new System.Drawing.Point(400, 130);
            this.categoryform.Name = "categoryform";
            this.categoryform.Size = new System.Drawing.Size(121, 24);
            this.categoryform.TabIndex = 12;
            // 
            // Expenses
            // 
            this.Expenses.ActiveLinkColor = System.Drawing.Color.AntiqueWhite;
            this.Expenses.AutoSize = true;
            this.Expenses.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Expenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Expenses.LinkColor = System.Drawing.Color.Black;
            this.Expenses.Location = new System.Drawing.Point(301, 22);
            this.Expenses.Name = "Expenses";
            this.Expenses.Size = new System.Drawing.Size(143, 33);
            this.Expenses.TabIndex = 13;
            this.Expenses.TabStop = true;
            this.Expenses.Text = "Expenses";
            this.Expenses.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Expenses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Expenses_LinkClicked);
            // 
            // TransactionsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(798, 260);
            this.Controls.Add(this.Expenses);
            this.Controls.Add(this.categoryform);
            this.Controls.Add(this.placeform);
            this.Controls.Add(this.dateform);
            this.Controls.Add(this.sumform);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CreateTransaction);
            this.Controls.Add(this.label1);
            this.Name = "TransactionsAdd";
            this.Text = "TransactionsAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateTransaction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sumform;
        private System.Windows.Forms.DateTimePicker dateform;
        private System.Windows.Forms.TextBox placeform;
        private System.Windows.Forms.ComboBox categoryform;
        private System.Windows.Forms.LinkLabel Expenses;
    }
}
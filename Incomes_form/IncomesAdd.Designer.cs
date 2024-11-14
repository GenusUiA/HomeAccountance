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
            this.categoryform = new System.Windows.Forms.ComboBox();
            this.sumform = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddIncome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Incomes
            // 
            this.Incomes.ActiveLinkColor = System.Drawing.Color.AntiqueWhite;
            this.Incomes.AutoSize = true;
            this.Incomes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Incomes.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Incomes.LinkColor = System.Drawing.Color.Black;
            this.Incomes.Location = new System.Drawing.Point(174, 27);
            this.Incomes.Name = "Incomes";
            this.Incomes.Size = new System.Drawing.Size(126, 33);
            this.Incomes.TabIndex = 23;
            this.Incomes.TabStop = true;
            this.Incomes.Text = "Incomes";
            this.Incomes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Incomes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Incomes_LinkClicked);
            // 
            // categoryform
            // 
            this.categoryform.FormattingEnabled = true;
            this.categoryform.Location = new System.Drawing.Point(272, 133);
            this.categoryform.Name = "categoryform";
            this.categoryform.Size = new System.Drawing.Size(146, 24);
            this.categoryform.TabIndex = 22;
            // 
            // sumform
            // 
            this.sumform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.sumform.Location = new System.Drawing.Point(61, 133);
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
            this.label3.Location = new System.Drawing.Point(91, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 31);
            this.label3.TabIndex = 17;
            this.label3.Text = "sum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(289, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "category";
            // 
            // AddIncome
            // 
            this.AddIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.AddIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddIncome.Location = new System.Drawing.Point(130, 202);
            this.AddIncome.Name = "AddIncome";
            this.AddIncome.Size = new System.Drawing.Size(212, 33);
            this.AddIncome.TabIndex = 15;
            this.AddIncome.Text = "Add income";
            this.AddIncome.UseVisualStyleBackColor = false;
            this.AddIncome.Click += new System.EventHandler(this.AddIncome_Click);
            // 
            // IncomesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(499, 260);
            this.Controls.Add(this.Incomes);
            this.Controls.Add(this.categoryform);
            this.Controls.Add(this.sumform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddIncome);
            this.Name = "IncomesAdd";
            this.Text = "IncomesAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel Incomes;
        private System.Windows.Forms.ComboBox categoryform;
        private System.Windows.Forms.TextBox sumform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddIncome;
    }
}
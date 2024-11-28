namespace Course_project_HOME_ACCOUNTANCE.Expenses_functions
{
    partial class Expenses
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
            this.AddIncome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Sorting = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.Transactions = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.Button();
            this.Searcher = new System.Windows.Forms.TextBox();
            this.Closer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sorting_form = new System.Windows.Forms.ComboBox();
            this.LoadTr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Transactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddIncome
            // 
            this.AddIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.AddIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddIncome.Location = new System.Drawing.Point(87, 443);
            this.AddIncome.Name = "AddIncome";
            this.AddIncome.Size = new System.Drawing.Size(180, 33);
            this.AddIncome.TabIndex = 3;
            this.AddIncome.Text = "Add transactions";
            this.AddIncome.UseVisualStyleBackColor = false;
            this.AddIncome.Click += new System.EventHandler(this.AddIncome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(362, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Expenses";
            // 
            // Sorting
            // 
            this.Sorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Sorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Sorting.Location = new System.Drawing.Point(303, 443);
            this.Sorting.Name = "Sorting";
            this.Sorting.Size = new System.Drawing.Size(149, 33);
            this.Sorting.TabIndex = 4;
            this.Sorting.Text = "Sorting for";
            this.Sorting.UseVisualStyleBackColor = false;
            this.Sorting.Click += new System.EventHandler(this.Sorting_Click);
            // 
            // Remove
            // 
            this.Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Remove.Location = new System.Drawing.Point(613, 443);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(176, 33);
            this.Remove.TabIndex = 5;
            this.Remove.Text = "Remove transaction";
            this.Remove.UseVisualStyleBackColor = false;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Transactions
            // 
            this.Transactions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Transactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Transactions.Location = new System.Drawing.Point(127, 163);
            this.Transactions.Name = "Transactions";
            this.Transactions.RowHeadersWidth = 51;
            this.Transactions.RowTemplate.Height = 24;
            this.Transactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Transactions.Size = new System.Drawing.Size(617, 248);
            this.Transactions.TabIndex = 6;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Search.Location = new System.Drawing.Point(541, 97);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(85, 29);
            this.Search.TabIndex = 7;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Searcher
            // 
            this.Searcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Searcher.Location = new System.Drawing.Point(396, 97);
            this.Searcher.Multiline = true;
            this.Searcher.Name = "Searcher";
            this.Searcher.Size = new System.Drawing.Size(148, 29);
            this.Searcher.TabIndex = 8;
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(834, 9);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 13;
            this.Closer.Text = "X";
            this.Closer.Click += new System.EventHandler(this.Closer_Click);
            this.Closer.MouseEnter += new System.EventHandler(this.Closer_MouseEnter_1);
            this.Closer.MouseLeave += new System.EventHandler(this.Closer_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course_project_HOME_ACCOUNTANCE.Properties.Resources.Undo_Transparent_Background;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sorting_form
            // 
            this.sorting_form.FormattingEnabled = true;
            this.sorting_form.Location = new System.Drawing.Point(458, 449);
            this.sorting_form.Name = "sorting_form";
            this.sorting_form.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sorting_form.Size = new System.Drawing.Size(121, 24);
            this.sorting_form.TabIndex = 15;
            // 
            // LoadTr
            // 
            this.LoadTr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.LoadTr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LoadTr.Location = new System.Drawing.Point(181, 93);
            this.LoadTr.Name = "LoadTr";
            this.LoadTr.Size = new System.Drawing.Size(176, 33);
            this.LoadTr.TabIndex = 16;
            this.LoadTr.Text = "Load transactions";
            this.LoadTr.UseVisualStyleBackColor = false;
            this.LoadTr.Click += new System.EventHandler(this.LoadTr_Click);
            // 
            // Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(874, 516);
            this.ControlBox = false;
            this.Controls.Add(this.LoadTr);
            this.Controls.Add(this.sorting_form);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.Searcher);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Transactions);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Sorting);
            this.Controls.Add(this.AddIncome);
            this.Controls.Add(this.label1);
            this.Name = "Expenses";
            this.Text = "Expenses";
            this.Load += new System.EventHandler(this.Expenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Transactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddIncome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Sorting;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.DataGridView Transactions;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox Searcher;
        private System.Windows.Forms.Label Closer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox sorting_form;
        private System.Windows.Forms.Button LoadTr;
    }
}
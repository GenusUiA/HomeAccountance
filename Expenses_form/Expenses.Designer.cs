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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddIncome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Sorting = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.Transactions = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trans_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.AddIncome.Location = new System.Drawing.Point(41, 443);
            this.AddIncome.Name = "AddIncome";
            this.AddIncome.Size = new System.Drawing.Size(229, 33);
            this.AddIncome.TabIndex = 3;
            this.AddIncome.Text = "Добавить покупку";
            this.AddIncome.UseVisualStyleBackColor = false;
            this.AddIncome.Click += new System.EventHandler(this.AddIncome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(362, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Расходы";
            // 
            // Sorting
            // 
            this.Sorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Sorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Sorting.Location = new System.Drawing.Point(295, 443);
            this.Sorting.Name = "Sorting";
            this.Sorting.Size = new System.Drawing.Size(157, 33);
            this.Sorting.TabIndex = 4;
            this.Sorting.Text = "Сортировка по";
            this.Sorting.UseVisualStyleBackColor = false;
            this.Sorting.Click += new System.EventHandler(this.Sorting_Click);
            // 
            // Remove
            // 
            this.Remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Remove.Location = new System.Drawing.Point(611, 443);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(238, 33);
            this.Remove.TabIndex = 5;
            this.Remove.Text = "Удалить покупку";
            this.Remove.UseVisualStyleBackColor = false;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Transactions
            // 
            this.Transactions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Transactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Transactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.sum,
            this.category,
            this.place,
            this.trans_id});
            this.Transactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Transactions.Location = new System.Drawing.Point(87, 147);
            this.Transactions.Name = "Transactions";
            this.Transactions.RowHeadersWidth = 51;
            this.Transactions.RowTemplate.Height = 24;
            this.Transactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Transactions.Size = new System.Drawing.Size(726, 275);
            this.Transactions.TabIndex = 6;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Дата";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.Width = 125;
            // 
            // sum
            // 
            this.sum.DataPropertyName = "sum";
            this.sum.HeaderText = "Сумма";
            this.sum.MinimumWidth = 6;
            this.sum.Name = "sum";
            this.sum.Width = 125;
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "Категория";
            this.category.MinimumWidth = 6;
            this.category.Name = "category";
            this.category.Width = 125;
            // 
            // place
            // 
            this.place.DataPropertyName = "place";
            this.place.HeaderText = "Место";
            this.place.MinimumWidth = 6;
            this.place.Name = "place";
            this.place.Width = 125;
            // 
            // trans_id
            // 
            this.trans_id.DataPropertyName = "trans_id";
            this.trans_id.HeaderText = "trans_id";
            this.trans_id.MinimumWidth = 6;
            this.trans_id.Name = "trans_id";
            this.trans_id.Visible = false;
            this.trans_id.Width = 125;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Search.Location = new System.Drawing.Point(541, 97);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(85, 29);
            this.Search.TabIndex = 7;
            this.Search.Text = "Поиск";
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
            this.Searcher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Searcher_KeyPress);
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
            this.LoadTr.Location = new System.Drawing.Point(148, 93);
            this.LoadTr.Name = "LoadTr";
            this.LoadTr.Size = new System.Drawing.Size(226, 33);
            this.LoadTr.TabIndex = 16;
            this.LoadTr.Text = "Загрузить расходы";
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
            this.MaximumSize = new System.Drawing.Size(892, 563);
            this.MinimumSize = new System.Drawing.Size(892, 563);
            this.Name = "Expenses";
            this.Text = "Расходы";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn place;
        private System.Windows.Forms.DataGridViewTextBoxColumn trans_id;
    }
}
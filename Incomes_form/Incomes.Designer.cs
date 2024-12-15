namespace Course_project_HOME_ACCOUNTANCE
{
    partial class Incomes
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
            this.sorting_form = new System.Windows.Forms.ComboBox();
            this.Closer = new System.Windows.Forms.Label();
            this.Searcher = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.Inc = new System.Windows.Forms.DataGridView();
            this.removeincome = new System.Windows.Forms.Button();
            this.Sorting = new System.Windows.Forms.Button();
            this.addincome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.income_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Inc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(300, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Доходы";
            // 
            // sorting_form
            // 
            this.sorting_form.FormattingEnabled = true;
            this.sorting_form.Location = new System.Drawing.Point(404, 454);
            this.sorting_form.Name = "sorting_form";
            this.sorting_form.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sorting_form.Size = new System.Drawing.Size(121, 24);
            this.sorting_form.TabIndex = 25;
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(707, 15);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 23;
            this.Closer.Text = "X";
            this.Closer.Click += new System.EventHandler(this.Closer_Click);
            this.Closer.MouseEnter += new System.EventHandler(this.Closer_MouseEnter);
            this.Closer.MouseLeave += new System.EventHandler(this.Closer_MouseLeave);
            // 
            // Searcher
            // 
            this.Searcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Searcher.Location = new System.Drawing.Point(250, 92);
            this.Searcher.Multiline = true;
            this.Searcher.Name = "Searcher";
            this.Searcher.Size = new System.Drawing.Size(148, 29);
            this.Searcher.TabIndex = 22;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.White;
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Search.Location = new System.Drawing.Point(395, 92);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(85, 29);
            this.Search.TabIndex = 21;
            this.Search.Text = "Поиск";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Inc
            // 
            this.Inc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Inc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Inc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sum,
            this.category,
            this.date,
            this.income_id});
            this.Inc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Inc.Location = new System.Drawing.Point(107, 144);
            this.Inc.Name = "Inc";
            this.Inc.RowHeadersWidth = 51;
            this.Inc.RowTemplate.Height = 24;
            this.Inc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Inc.Size = new System.Drawing.Size(539, 284);
            this.Inc.TabIndex = 20;
            // 
            // removeincome
            // 
            this.removeincome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.removeincome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.removeincome.Location = new System.Drawing.Point(559, 448);
            this.removeincome.Name = "removeincome";
            this.removeincome.Size = new System.Drawing.Size(176, 33);
            this.removeincome.TabIndex = 19;
            this.removeincome.Text = "Удалить доход";
            this.removeincome.UseVisualStyleBackColor = false;
            this.removeincome.Click += new System.EventHandler(this.removeincome_Click);
            // 
            // Sorting
            // 
            this.Sorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Sorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Sorting.Location = new System.Drawing.Point(245, 448);
            this.Sorting.Name = "Sorting";
            this.Sorting.Size = new System.Drawing.Size(153, 33);
            this.Sorting.TabIndex = 18;
            this.Sorting.Text = "Сортировка по";
            this.Sorting.UseVisualStyleBackColor = false;
            this.Sorting.Click += new System.EventHandler(this.Sorting_Click);
            // 
            // addincome
            // 
            this.addincome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.addincome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addincome.Location = new System.Drawing.Point(33, 448);
            this.addincome.Name = "addincome";
            this.addincome.Size = new System.Drawing.Size(180, 33);
            this.addincome.TabIndex = 17;
            this.addincome.Text = "Добавить доход";
            this.addincome.UseVisualStyleBackColor = false;
            this.addincome.Click += new System.EventHandler(this.addincome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course_project_HOME_ACCOUNTANCE.Properties.Resources.Undo_Transparent_Background;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Дата";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.Width = 125;
            // 
            // income_id
            // 
            this.income_id.DataPropertyName = "income_id";
            this.income_id.HeaderText = "income_id";
            this.income_id.MinimumWidth = 6;
            this.income_id.Name = "income_id";
            this.income_id.Visible = false;
            this.income_id.Width = 125;
            // 
            // Incomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(742, 519);
            this.ControlBox = false;
            this.Controls.Add(this.sorting_form);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.Searcher);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Inc);
            this.Controls.Add(this.removeincome);
            this.Controls.Add(this.Sorting);
            this.Controls.Add(this.addincome);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(760, 566);
            this.MinimumSize = new System.Drawing.Size(760, 566);
            this.Name = "Incomes";
            this.Text = "Доходы";
            this.Load += new System.EventHandler(this.Incomes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Inc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sorting_form;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Closer;
        private System.Windows.Forms.TextBox Searcher;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridView Inc;
        private System.Windows.Forms.Button removeincome;
        private System.Windows.Forms.Button Sorting;
        private System.Windows.Forms.Button addincome;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn income_id;
    }
}
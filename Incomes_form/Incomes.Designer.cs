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
            ((System.ComponentModel.ISupportInitialize)(this.Inc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(373, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incomes";
            // 
            // sorting_form
            // 
            this.sorting_form.FormattingEnabled = true;
            this.sorting_form.Location = new System.Drawing.Point(477, 448);
            this.sorting_form.Name = "sorting_form";
            this.sorting_form.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sorting_form.Size = new System.Drawing.Size(121, 24);
            this.sorting_form.TabIndex = 25;
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(853, 8);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 23;
            this.Closer.Text = "X";
            // 
            // Searcher
            // 
            this.Searcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Searcher.Location = new System.Drawing.Point(371, 96);
            this.Searcher.Multiline = true;
            this.Searcher.Name = "Searcher";
            this.Searcher.Size = new System.Drawing.Size(148, 29);
            this.Searcher.TabIndex = 22;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.White;
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Search.Location = new System.Drawing.Point(554, 96);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(85, 29);
            this.Search.TabIndex = 21;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Inc
            // 
            this.Inc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Inc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Inc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Inc.Location = new System.Drawing.Point(106, 152);
            this.Inc.Name = "Inc";
            this.Inc.RowHeadersWidth = 51;
            this.Inc.RowTemplate.Height = 24;
            this.Inc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Inc.Size = new System.Drawing.Size(702, 248);
            this.Inc.TabIndex = 20;
            // 
            // removeincome
            // 
            this.removeincome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.removeincome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.removeincome.Location = new System.Drawing.Point(632, 442);
            this.removeincome.Name = "removeincome";
            this.removeincome.Size = new System.Drawing.Size(176, 33);
            this.removeincome.TabIndex = 19;
            this.removeincome.Text = "Remove income";
            this.removeincome.UseVisualStyleBackColor = false;
            this.removeincome.Click += new System.EventHandler(this.removeincome_Click);
            // 
            // Sorting
            // 
            this.Sorting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Sorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Sorting.Location = new System.Drawing.Point(322, 442);
            this.Sorting.Name = "Sorting";
            this.Sorting.Size = new System.Drawing.Size(149, 33);
            this.Sorting.TabIndex = 18;
            this.Sorting.Text = "Sorting for";
            this.Sorting.UseVisualStyleBackColor = false;
            // 
            // addincome
            // 
            this.addincome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.addincome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addincome.Location = new System.Drawing.Point(106, 442);
            this.addincome.Name = "addincome";
            this.addincome.Size = new System.Drawing.Size(180, 33);
            this.addincome.TabIndex = 17;
            this.addincome.Text = "Add income";
            this.addincome.UseVisualStyleBackColor = false;
            this.addincome.Click += new System.EventHandler(this.addincome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course_project_HOME_ACCOUNTANCE.Properties.Resources.Undo_Transparent_Background;
            this.pictureBox1.Location = new System.Drawing.Point(31, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Incomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(895, 519);
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
            this.Name = "Incomes";
            this.Text = "Incomes";
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
    }
}
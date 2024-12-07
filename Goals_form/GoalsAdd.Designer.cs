namespace Course_project_HOME_ACCOUNTANCE.Goals_form
{
    partial class Goals
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
            this.sumform = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddGoal = new System.Windows.Forms.Button();
            this.defform = new System.Windows.Forms.TextBox();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.For = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Closer = new System.Windows.Forms.Label();
            this.deldef = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DelGoal = new System.Windows.Forms.Button();
            this.SumAdd = new System.Windows.Forms.Button();
            this.sumdef = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addsum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sumform
            // 
            this.sumform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.sumform.Location = new System.Drawing.Point(210, 139);
            this.sumform.Multiline = true;
            this.sumform.Name = "sumform";
            this.sumform.Size = new System.Drawing.Size(125, 24);
            this.sumform.TabIndex = 27;
            this.sumform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(601, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 31);
            this.label3.TabIndex = 26;
            this.label3.Text = "sum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(37, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 31);
            this.label2.TabIndex = 25;
            this.label2.Text = "definition";
            // 
            // AddGoal
            // 
            this.AddGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.AddGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddGoal.Location = new System.Drawing.Point(262, 201);
            this.AddGoal.Name = "AddGoal";
            this.AddGoal.Size = new System.Drawing.Size(212, 33);
            this.AddGoal.TabIndex = 24;
            this.AddGoal.Text = "Add goal";
            this.AddGoal.UseVisualStyleBackColor = false;
            this.AddGoal.Click += new System.EventHandler(this.AddGoal_Click);
            // 
            // defform
            // 
            this.defform.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.defform.Location = new System.Drawing.Point(35, 139);
            this.defform.Multiline = true;
            this.defform.Name = "defform";
            this.defform.Size = new System.Drawing.Size(125, 24);
            this.defform.TabIndex = 30;
            this.defform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(375, 139);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(153, 22);
            this.from.TabIndex = 31;
            this.from.Value = new System.DateTime(2024, 11, 22, 8, 46, 2, 0);
            // 
            // For
            // 
            this.For.Location = new System.Drawing.Point(571, 139);
            this.For.Name = "For";
            this.For.Size = new System.Drawing.Size(153, 22);
            this.For.TabIndex = 32;
            this.For.Value = new System.DateTime(2024, 11, 22, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(418, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 31);
            this.label1.TabIndex = 33;
            this.label1.Text = "from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(618, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 31);
            this.label4.TabIndex = 34;
            this.label4.Text = "for";
            // 
            // Closer
            // 
            this.Closer.AutoSize = true;
            this.Closer.Font = new System.Drawing.Font("Microsoft YaHei", 12.8F, System.Drawing.FontStyle.Bold);
            this.Closer.Location = new System.Drawing.Point(696, 9);
            this.Closer.Name = "Closer";
            this.Closer.Size = new System.Drawing.Size(28, 30);
            this.Closer.TabIndex = 35;
            this.Closer.Text = "X";
            this.Closer.Click += new System.EventHandler(this.Closer_Click);
            this.Closer.MouseEnter += new System.EventHandler(this.Closer_MouseEnter);
            this.Closer.MouseLeave += new System.EventHandler(this.Closer_MouseLeave);
            // 
            // deldef
            // 
            this.deldef.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.deldef.Location = new System.Drawing.Point(96, 318);
            this.deldef.Multiline = true;
            this.deldef.Name = "deldef";
            this.deldef.Size = new System.Drawing.Size(125, 24);
            this.deldef.TabIndex = 37;
            this.deldef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(98, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 31);
            this.label5.TabIndex = 36;
            this.label5.Text = "definition";
            // 
            // DelGoal
            // 
            this.DelGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.DelGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DelGoal.Location = new System.Drawing.Point(54, 360);
            this.DelGoal.Name = "DelGoal";
            this.DelGoal.Size = new System.Drawing.Size(212, 33);
            this.DelGoal.TabIndex = 38;
            this.DelGoal.Text = "Delete goal";
            this.DelGoal.UseVisualStyleBackColor = false;
            this.DelGoal.Click += new System.EventHandler(this.DelGoal_Click);
            // 
            // SumAdd
            // 
            this.SumAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.SumAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SumAdd.Location = new System.Drawing.Point(452, 360);
            this.SumAdd.Name = "SumAdd";
            this.SumAdd.Size = new System.Drawing.Size(212, 33);
            this.SumAdd.TabIndex = 41;
            this.SumAdd.Text = "Add sum";
            this.SumAdd.UseVisualStyleBackColor = false;
            this.SumAdd.Click += new System.EventHandler(this.SumAdd_Click);
            // 
            // sumdef
            // 
            this.sumdef.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.sumdef.Location = new System.Drawing.Point(403, 316);
            this.sumdef.Multiline = true;
            this.sumdef.Name = "sumdef";
            this.sumdef.Size = new System.Drawing.Size(125, 24);
            this.sumdef.TabIndex = 40;
            this.sumdef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label6.Location = new System.Drawing.Point(405, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 31);
            this.label6.TabIndex = 39;
            this.label6.Text = "definition";
            // 
            // addsum
            // 
            this.addsum.Font = new System.Drawing.Font("Swis721 BT", 10F);
            this.addsum.Location = new System.Drawing.Point(571, 316);
            this.addsum.Multiline = true;
            this.addsum.Name = "addsum";
            this.addsum.Size = new System.Drawing.Size(125, 24);
            this.addsum.TabIndex = 43;
            this.addsum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label7.Location = new System.Drawing.Point(241, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 31);
            this.label7.TabIndex = 42;
            this.label7.Text = "sum";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course_project_HOME_ACCOUNTANCE.Properties.Resources.Undo_Transparent_Background;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label8.Location = new System.Drawing.Point(313, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 39);
            this.label8.TabIndex = 45;
            this.label8.Text = "Goals";
            // 
            // Goals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(748, 406);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.addsum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SumAdd);
            this.Controls.Add(this.sumdef);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DelGoal);
            this.Controls.Add(this.deldef);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Closer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.For);
            this.Controls.Add(this.from);
            this.Controls.Add(this.defform);
            this.Controls.Add(this.sumform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddGoal);
            this.Name = "Goals";
            this.Text = "Goals";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox sumform;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddGoal;
        private System.Windows.Forms.TextBox defform;
        private System.Windows.Forms.DateTimePicker from;
        private System.Windows.Forms.DateTimePicker For;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Closer;
        private System.Windows.Forms.TextBox deldef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DelGoal;
        private System.Windows.Forms.Button SumAdd;
        private System.Windows.Forms.TextBox sumdef;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox addsum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
    }
}
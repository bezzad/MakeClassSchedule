namespace MakeClassSchedule
{
    partial class BranchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BranchForm));
            this.dgvBranch = new System.Windows.Forms.DataGridView();
            this.colID_Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDegree = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBranch
            // 
            this.dgvBranch.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvBranch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBranch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBranch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvBranch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBranch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBranch.ColumnHeadersHeight = 40;
            this.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID_Branch,
            this.colBranchName,
            this.colDegree});
            this.dgvBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBranch.Location = new System.Drawing.Point(0, 0);
            this.dgvBranch.Name = "dgvBranch";
            this.dgvBranch.RowHeadersWidth = 25;
            this.dgvBranch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBranch.RowTemplate.Height = 30;
            this.dgvBranch.Size = new System.Drawing.Size(564, 422);
            this.dgvBranch.TabIndex = 0;
            this.dgvBranch.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvBranch_UserDeletingRow);
            this.dgvBranch.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvBranch_RowsAdded);
            // 
            // colID_Branch
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colID_Branch.DefaultCellStyle = dataGridViewCellStyle3;
            this.colID_Branch.Frozen = true;
            this.colID_Branch.HeaderText = "ID";
            this.colID_Branch.MinimumWidth = 50;
            this.colID_Branch.Name = "colID_Branch";
            this.colID_Branch.ReadOnly = true;
            this.colID_Branch.Width = 60;
            // 
            // colBranchName
            // 
            this.colBranchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBranchName.HeaderText = "Education Course Name";
            this.colBranchName.MinimumWidth = 100;
            this.colBranchName.Name = "colBranchName";
            // 
            // colDegree
            // 
            this.colDegree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.colDegree.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDegree.HeaderText = "Education Degree";
            this.colDegree.Items.AddRange(new object[] {
            "کاردانی",
            "کارشناسی ناپیوسته",
            "کارشناسی پیوسته",
            "کارشناسی ارشد ناپیوسته",
            "کارشناسی ارشد پیوسته",
            "دکتری ناپیوسته",
            "دکتری پیوسته",
            "دکترای تخصصی"});
            this.colDegree.Name = "colDegree";
            this.colDegree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDegree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 422);
            this.Controls.Add(this.dgvBranch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BranchForm";
            this.Text = "Branch Data";
            this.Load += new System.EventHandler(this.BranchForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BranchForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID_Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranchName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDegree;
    }
}
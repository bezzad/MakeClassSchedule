namespace MakeClassSchedule
{
    partial class GroupsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupsForm));
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSemesterEntryYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSemesterEntry = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSelectBranch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowDrop = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvGroup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGroup.ColumnHeadersHeight = 40;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colSemesterEntryYear,
            this.colSemesterEntry,
            this.colSelectBranch,
            this.colSize});
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroup.Location = new System.Drawing.Point(0, 0);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvGroup.RowHeadersWidth = 25;
            this.dgvGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvGroup.RowTemplate.Height = 40;
            this.dgvGroup.Size = new System.Drawing.Size(614, 322);
            this.dgvGroup.TabIndex = 0;
            this.dgvGroup.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGroup_UserDeletingRow);
            this.dgvGroup.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvGroup_RowsAdded);
            // 
            // colID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colID.Frozen = true;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 50;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 50;
            // 
            // colSemesterEntryYear
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colSemesterEntryYear.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSemesterEntryYear.HeaderText = "Semester Entry Year";
            this.colSemesterEntryYear.MaxInputLength = 4;
            this.colSemesterEntryYear.Name = "colSemesterEntryYear";
            // 
            // colSemesterEntry
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            this.colSemesterEntry.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSemesterEntry.HeaderText = "Semester Entry";
            this.colSemesterEntry.Items.AddRange(new object[] {
            "مهر",
            "بهمن"});
            this.colSemesterEntry.Name = "colSemesterEntry";
            this.colSemesterEntry.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSemesterEntry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSemesterEntry.ToolTipText = "Select First Semester or Second Semester";
            // 
            // colSelectBranch
            // 
            this.colSelectBranch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.colSelectBranch.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSelectBranch.HeaderText = "Select academic field";
            this.colSelectBranch.Name = "colSelectBranch";
            this.colSelectBranch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelectBranch.ToolTipText = "Academic field";
            // 
            // colSize
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.colSize.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSize.HeaderText = "Size";
            this.colSize.MaxInputLength = 5;
            this.colSize.MinimumWidth = 50;
            this.colSize.Name = "colSize";
            this.colSize.Width = 60;
            // 
            // GroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 322);
            this.Controls.Add(this.dgvGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupsForm";
            this.Text = "Groups Data";
            this.Load += new System.EventHandler(this.GroupsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSemesterEntryYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSemesterEntry;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSelectBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
    }
}
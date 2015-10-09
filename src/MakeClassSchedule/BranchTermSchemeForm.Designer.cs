namespace MakeClassSchedule
{
    partial class BranchTermSchemeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBranchTermScheme = new System.Windows.Forms.DataGridView();
            this.ColTerm_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPractical_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheory_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranchTermScheme)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBranchTermScheme
            // 
            this.dgvBranchTermScheme.AllowUserToAddRows = false;
            this.dgvBranchTermScheme.AllowUserToDeleteRows = false;
            this.dgvBranchTermScheme.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvBranchTermScheme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBranchTermScheme.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvBranchTermScheme.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBranchTermScheme.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBranchTermScheme.ColumnHeadersHeight = 40;
            this.dgvBranchTermScheme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBranchTermScheme.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTerm_No,
            this.colInCourseID,
            this.colPreCourseID,
            this.ColCourseType,
            this.ColPractical_Unit,
            this.colTheory_Unit,
            this.colCourse});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBranchTermScheme.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBranchTermScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBranchTermScheme.GridColor = System.Drawing.Color.Maroon;
            this.dgvBranchTermScheme.Location = new System.Drawing.Point(0, 0);
            this.dgvBranchTermScheme.Name = "dgvBranchTermScheme";
            this.dgvBranchTermScheme.ReadOnly = true;
            this.dgvBranchTermScheme.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvBranchTermScheme.RowHeadersVisible = false;
            this.dgvBranchTermScheme.RowHeadersWidth = 25;
            this.dgvBranchTermScheme.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBranchTermScheme.RowTemplate.Height = 30;
            this.dgvBranchTermScheme.RowTemplate.ReadOnly = true;
            this.dgvBranchTermScheme.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBranchTermScheme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBranchTermScheme.Size = new System.Drawing.Size(784, 442);
            this.dgvBranchTermScheme.TabIndex = 0;
            // 
            // ColTerm_No
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ColTerm_No.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColTerm_No.Frozen = true;
            this.ColTerm_No.HeaderText = "Term No";
            this.ColTerm_No.Name = "ColTerm_No";
            this.ColTerm_No.ReadOnly = true;
            this.ColTerm_No.Width = 40;
            // 
            // colInCourseID
            // 
            this.colInCourseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInCourseID.HeaderText = "InRequisite Course";
            this.colInCourseID.MinimumWidth = 50;
            this.colInCourseID.Name = "colInCourseID";
            this.colInCourseID.ReadOnly = true;
            // 
            // colPreCourseID
            // 
            this.colPreCourseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPreCourseID.HeaderText = "PreRequisite Course";
            this.colPreCourseID.MinimumWidth = 50;
            this.colPreCourseID.Name = "colPreCourseID";
            this.colPreCourseID.ReadOnly = true;
            // 
            // ColCourseType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColCourseType.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCourseType.HeaderText = "Course Type";
            this.ColCourseType.Name = "ColCourseType";
            this.ColCourseType.ReadOnly = true;
            this.ColCourseType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCourseType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCourseType.Width = 80;
            // 
            // ColPractical_Unit
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.ColPractical_Unit.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColPractical_Unit.HeaderText = "Practical Unit";
            this.ColPractical_Unit.MaxInputLength = 2;
            this.ColPractical_Unit.MinimumWidth = 50;
            this.ColPractical_Unit.Name = "ColPractical_Unit";
            this.ColPractical_Unit.ReadOnly = true;
            this.ColPractical_Unit.Width = 60;
            // 
            // colTheory_Unit
            // 
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colTheory_Unit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTheory_Unit.HeaderText = "Theory Unit";
            this.colTheory_Unit.MaxInputLength = 2;
            this.colTheory_Unit.MinimumWidth = 50;
            this.colTheory_Unit.Name = "colTheory_Unit";
            this.colTheory_Unit.ReadOnly = true;
            this.colTheory_Unit.Width = 60;
            // 
            // colCourse
            // 
            this.colCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            this.colCourse.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCourse.HeaderText = "Course Name";
            this.colCourse.Name = "colCourse";
            this.colCourse.ReadOnly = true;
            this.colCourse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BranchTermSchemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.dgvBranchTermScheme);
            this.Name = "BranchTermSchemeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Term Scheme\'s";
            this.TransparencyKey = System.Drawing.SystemColors.WindowFrame;
            this.Load += new System.EventHandler(this.BranchTermSchemeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranchTermScheme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBranchTermScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTerm_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPractical_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheory_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourse;
    }
}
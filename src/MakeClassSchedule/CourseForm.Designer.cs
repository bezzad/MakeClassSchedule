namespace MakeClassSchedule
{
    partial class CourseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseForm));
            this.dgvCourse = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTermNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInReqCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnInReqCourseID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPreReqCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnPreReqCourseID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTheoryUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPracticalUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlusUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCourse
            // 
            this.dgvCourse.AllowDrop = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvCourse.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCourse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCourse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCourse.ColumnHeadersHeight = 40;
            this.dgvCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTermNo,
            this.colInReqCourseID,
            this.colBtnInReqCourseID,
            this.colPreReqCourseID,
            this.colBtnPreReqCourseID,
            this.colTheoryUN,
            this.colPracticalUN,
            this.colPlusUnit,
            this.colType,
            this.colName,
            this.colCode});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCourse.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCourse.Location = new System.Drawing.Point(0, 0);
            this.dgvCourse.Name = "dgvCourse";
            this.dgvCourse.RowHeadersWidth = 30;
            this.dgvCourse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCourse.RowTemplate.Height = 30;
            this.dgvCourse.Size = new System.Drawing.Size(944, 397);
            this.dgvCourse.TabIndex = 0;
            this.dgvCourse.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCourse_UserDeletingRow);
            this.dgvCourse.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvCourse_RowsAdded);
            this.dgvCourse.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellEndEdit);
            this.dgvCourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellContentClick);
            // 
            // colID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colID.Frozen = true;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 40;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 40;
            // 
            // colTermNo
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.colTermNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTermNo.Frozen = true;
            this.colTermNo.HeaderText = "Term No";
            this.colTermNo.MinimumWidth = 50;
            this.colTermNo.Name = "colTermNo";
            this.colTermNo.Width = 50;
            // 
            // colInReqCourseID
            // 
            this.colInReqCourseID.HeaderText = "InRequisite Course ID";
            this.colInReqCourseID.Name = "colInReqCourseID";
            this.colInReqCourseID.ReadOnly = true;
            this.colInReqCourseID.Width = 80;
            // 
            // colBtnInReqCourseID
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Select";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3);
            this.colBtnInReqCourseID.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBtnInReqCourseID.HeaderText = "Select InRequisite Course";
            this.colBtnInReqCourseID.Name = "colBtnInReqCourseID";
            this.colBtnInReqCourseID.Width = 80;
            // 
            // colPreReqCourseID
            // 
            this.colPreReqCourseID.HeaderText = "PreRequisite Course ID";
            this.colPreReqCourseID.Name = "colPreReqCourseID";
            this.colPreReqCourseID.ReadOnly = true;
            this.colPreReqCourseID.Width = 80;
            // 
            // colBtnPreReqCourseID
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "Select";
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            this.colBtnPreReqCourseID.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBtnPreReqCourseID.HeaderText = "Select PreRequisite Course";
            this.colBtnPreReqCourseID.Name = "colBtnPreReqCourseID";
            this.colBtnPreReqCourseID.Width = 80;
            // 
            // colTheoryUN
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.colTheoryUN.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTheoryUN.HeaderText = "Theory Unit No";
            this.colTheoryUN.Name = "colTheoryUN";
            this.colTheoryUN.Width = 60;
            // 
            // colPracticalUN
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.colPracticalUN.DefaultCellStyle = dataGridViewCellStyle8;
            this.colPracticalUN.HeaderText = "Practical Unit No";
            this.colPracticalUN.Name = "colPracticalUN";
            this.colPracticalUN.Width = 60;
            // 
            // colPlusUnit
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.colPlusUnit.DefaultCellStyle = dataGridViewCellStyle9;
            this.colPlusUnit.HeaderText = "Total Units No";
            this.colPlusUnit.Name = "colPlusUnit";
            this.colPlusUnit.ReadOnly = true;
            this.colPlusUnit.Width = 60;
            // 
            // colType
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(3);
            this.colType.DefaultCellStyle = dataGridViewCellStyle10;
            this.colType.HeaderText = "Type of Course";
            this.colType.Items.AddRange(new object[] {
            "پایه",
            "عمومی",
            "اصلی",
            "تخصصی",
            "اختیاری"});
            this.colType.Name = "colType";
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colName.DefaultCellStyle = dataGridViewCellStyle11;
            this.colName.HeaderText = "Course Name";
            this.colName.MinimumWidth = 100;
            this.colName.Name = "colName";
            // 
            // colCode
            // 
            this.colCode.HeaderText = "Course Code";
            this.colCode.Name = "colCode";
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 397);
            this.Controls.Add(this.dgvCourse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CourseForm";
            this.Text = "Course Data";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CourseForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTermNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInReqCourseID;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnInReqCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreReqCourseID;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnPreReqCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheoryUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPracticalUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlusUnit;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;

    }
}
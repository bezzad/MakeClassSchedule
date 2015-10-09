namespace MakeClassSchedule
{
    partial class ClassForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassForm));
            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.txtCurrentTerm = new System.Windows.Forms.TextBox();
            this.btnShowHide = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSemesterEntry = new System.Windows.Forms.ComboBox();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfessor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPriorityProf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colGroup = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colGroup_ID_List = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClass
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aqua;
            this.dgvClass.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvClass.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClass.ColumnHeadersHeight = 40;
            this.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colProfessor,
            this.colPriorityProf,
            this.colCourse,
            this.colCode,
            this.colPU,
            this.colTU,
            this.ColType,
            this.colGroup,
            this.colGroup_ID_List});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClass.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClass.Location = new System.Drawing.Point(0, 53);
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.RowHeadersWidth = 25;
            this.dgvClass.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvClass.RowTemplate.Height = 40;
            this.dgvClass.ShowCellErrors = false;
            this.dgvClass.ShowRowErrors = false;
            this.dgvClass.Size = new System.Drawing.Size(854, 309);
            this.dgvClass.TabIndex = 0;
            this.dgvClass.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvClass_UserDeletingRow);
            this.dgvClass.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvClass_RowsAdded);
            this.dgvClass.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellEndEdit);
            this.dgvClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Term No:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackgroundImage = global::MakeClassSchedule.Properties.Resources.Add;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(796, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 43);
            this.btnAdd.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAdd, "Add Term Scheme data to class form");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbGroups
            // 
            this.cmbGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroups.BackColor = System.Drawing.SystemColors.Info;
            this.cmbGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbGroups.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(131, 15);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbGroups.Size = new System.Drawing.Size(356, 21);
            this.cmbGroups.Sorted = true;
            this.cmbGroups.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cmbGroups, "Choose the academic field that has the term is information.");
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // txtCurrentTerm
            // 
            this.txtCurrentTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCurrentTerm.ForeColor = System.Drawing.Color.Maroon;
            this.txtCurrentTerm.Location = new System.Drawing.Point(684, 16);
            this.txtCurrentTerm.MaxLength = 4;
            this.txtCurrentTerm.Name = "txtCurrentTerm";
            this.txtCurrentTerm.Size = new System.Drawing.Size(50, 21);
            this.txtCurrentTerm.TabIndex = 6;
            this.txtCurrentTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtCurrentTerm, "Current Term: (Example) 1389");
            this.txtCurrentTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCurrentTerm_KeyUp);
            this.txtCurrentTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentTerm_KeyPress);
            // 
            // btnShowHide
            // 
            this.btnShowHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnShowHide.AutoSize = true;
            this.btnShowHide.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnShowHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShowHide.ForeColor = System.Drawing.Color.Teal;
            this.btnShowHide.Location = new System.Drawing.Point(493, 13);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(48, 25);
            this.btnShowHide.TabIndex = 8;
            this.btnShowHide.Text = "&Show";
            this.btnShowHide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.btnShowHide, "Toggle (Show / Hide)");
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.CheckedChanged += new System.EventHandler(this.btnShowHide_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Group for View:";
            // 
            // cmbSemesterEntry
            // 
            this.cmbSemesterEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSemesterEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSemesterEntry.ForeColor = System.Drawing.Color.Maroon;
            this.cmbSemesterEntry.FormattingEnabled = true;
            this.cmbSemesterEntry.Items.AddRange(new object[] {
            "مهر",
            "بهمن"});
            this.cmbSemesterEntry.Location = new System.Drawing.Point(738, 16);
            this.cmbSemesterEntry.Name = "cmbSemesterEntry";
            this.cmbSemesterEntry.Size = new System.Drawing.Size(50, 21);
            this.cmbSemesterEntry.TabIndex = 7;
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
            // colProfessor
            // 
            this.colProfessor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "+ Professor";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            this.colProfessor.DefaultCellStyle = dataGridViewCellStyle4;
            this.colProfessor.HeaderText = "Select Professors";
            this.colProfessor.MinimumWidth = 80;
            this.colProfessor.Name = "colProfessor";
            this.colProfessor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProfessor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProfessor.ToolTipText = "Select Class Professor\'s";
            this.colProfessor.Width = 80;
            // 
            // colPriorityProf
            // 
            this.colPriorityProf.HeaderText = "Priority of Professors";
            this.colPriorityProf.MinimumWidth = 50;
            this.colPriorityProf.Name = "colPriorityProf";
            this.colPriorityProf.ReadOnly = true;
            this.colPriorityProf.Width = 80;
            // 
            // colCourse
            // 
            this.colCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            this.colCourse.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCourse.HeaderText = "Course";
            this.colCourse.MinimumWidth = 100;
            this.colCourse.Name = "colCourse";
            this.colCourse.Sorted = true;
            this.colCourse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCode
            // 
            dataGridViewCellStyle6.NullValue = null;
            this.colCode.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCode.HeaderText = "Course Code";
            this.colCode.MaxInputLength = 11;
            this.colCode.Name = "colCode";
            this.colCode.ToolTipText = "Selected Course Code";
            this.colCode.Width = 80;
            // 
            // colPU
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.colPU.DefaultCellStyle = dataGridViewCellStyle7;
            this.colPU.HeaderText = "Practical Unit";
            this.colPU.MaxInputLength = 2;
            this.colPU.MinimumWidth = 50;
            this.colPU.Name = "colPU";
            this.colPU.Width = 60;
            // 
            // colTU
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.colTU.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTU.HeaderText = "Theory Unit";
            this.colTU.MaxInputLength = 2;
            this.colTU.MinimumWidth = 50;
            this.colTU.Name = "colTU";
            this.colTU.Width = 60;
            // 
            // ColType
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            this.ColType.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColType.HeaderText = "Room Type";
            this.ColType.Name = "ColType";
            this.ColType.Sorted = true;
            this.ColType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colGroup
            // 
            this.colGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = "+ Group";
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            this.colGroup.DefaultCellStyle = dataGridViewCellStyle10;
            this.colGroup.HeaderText = "Groups";
            this.colGroup.MinimumWidth = 70;
            this.colGroup.Name = "colGroup";
            this.colGroup.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGroup.Text = "+ Group";
            this.colGroup.ToolTipText = "Add Group";
            this.colGroup.Width = 80;
            // 
            // colGroup_ID_List
            // 
            this.colGroup_ID_List.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGroup_ID_List.HeaderText = "Groups ID List";
            this.colGroup_ID_List.MinimumWidth = 70;
            this.colGroup_ID_List.Name = "colGroup_ID_List";
            this.colGroup_ID_List.ReadOnly = true;
            // 
            // ClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 362);
            this.Controls.Add(this.btnShowHide);
            this.Controls.Add(this.cmbSemesterEntry);
            this.Controls.Add(this.txtCurrentTerm);
            this.Controls.Add(this.cmbGroups);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvClass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClassForm";
            this.Text = "Class Data";
            this.Load += new System.EventHandler(this.ClassForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClass;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentTerm;
        private System.Windows.Forms.ComboBox cmbSemesterEntry;
        private System.Windows.Forms.CheckBox btnShowHide;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewButtonColumn colProfessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriorityProf;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTU;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColType;
        private System.Windows.Forms.DataGridViewButtonColumn colGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroup_ID_List;
    }
}
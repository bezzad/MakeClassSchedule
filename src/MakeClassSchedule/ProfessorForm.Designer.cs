namespace MakeClassSchedule
{
    partial class ProfessorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessorForm));
            this.dgvProfessor = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEducationDegree = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSchedule = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfessor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProfessor
            // 
            this.dgvProfessor.AllowDrop = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvProfessor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProfessor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProfessor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvProfessor.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvProfessor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfessor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProfessor.ColumnHeadersHeight = 40;
            this.dgvProfessor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProfessor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ProfName,
            this.colBranch,
            this.colEmail,
            this.colEducationDegree,
            this.btnSchedule,
            this.colSchedule});
            this.dgvProfessor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProfessor.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvProfessor.Location = new System.Drawing.Point(0, 0);
            this.dgvProfessor.Name = "dgvProfessor";
            this.dgvProfessor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfessor.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProfessor.RowHeadersWidth = 30;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            this.dgvProfessor.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProfessor.RowTemplate.Height = 30;
            this.dgvProfessor.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfessor.Size = new System.Drawing.Size(844, 452);
            this.dgvProfessor.TabIndex = 0;
            this.dgvProfessor.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProfessor_UserDeletingRow);
            this.dgvProfessor.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProfessor_RowsAdded);
            this.dgvProfessor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProfessor_CellContentClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.Frozen = true;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.ToolTipText = "Professor ID Number";
            this.id.Width = 48;
            // 
            // ProfName
            // 
            this.ProfName.HeaderText = "Name";
            this.ProfName.Name = "ProfName";
            this.ProfName.Width = 150;
            // 
            // colBranch
            // 
            this.colBranch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBranch.HeaderText = "Branch";
            this.colBranch.MinimumWidth = 100;
            this.colBranch.Name = "colBranch";
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 150;
            // 
            // colEducationDegree
            // 
            this.colEducationDegree.HeaderText = "Education degree";
            this.colEducationDegree.Items.AddRange(new object[] {
            "دیپلم",
            "فوق دیپلم",
            "لیسانس",
            "فوق لیسانس",
            "دکتری",
            "دکترای تخصصی",
            "پروفسور"});
            this.colEducationDegree.Name = "colEducationDegree";
            this.colEducationDegree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEducationDegree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEducationDegree.Width = 120;
            // 
            // btnSchedule
            // 
            this.btnSchedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.NullValue = "Schedule";
            this.btnSchedule.DefaultCellStyle = dataGridViewCellStyle4;
            this.btnSchedule.HeaderText = "DateTime Schedule";
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnSchedule.Text = "&Schedule";
            this.btnSchedule.ToolTipText = "Enter Professor Schedule Info";
            // 
            // colSchedule
            // 
            this.colSchedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSchedule.HeaderText = "Schedule";
            this.colSchedule.MinimumWidth = 100;
            this.colSchedule.Name = "colSchedule";
            // 
            // ProfessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 452);
            this.Controls.Add(this.dgvProfessor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfessorForm";
            this.Text = "Professor Data";
            this.Load += new System.EventHandler(this.ProfessorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfessorForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfessor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProfessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEducationDegree;
        private System.Windows.Forms.DataGridViewButtonColumn btnSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSchedule;
    }
}
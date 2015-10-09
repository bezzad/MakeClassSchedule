namespace MakeClassSchedule
{
    partial class ProfScheduleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.SAT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SUN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TUE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.THUR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FRI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvSchedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSchedule.ColumnHeadersHeight = 40;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.SAT,
            this.SUN,
            this.MON,
            this.TUE,
            this.WED,
            this.THUR,
            this.FRI});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSchedule.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.RowHeadersWidth = 20;
            this.dgvSchedule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSchedule.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dgvSchedule.RowTemplate.Height = 30;
            this.dgvSchedule.Size = new System.Drawing.Size(523, 402);
            this.dgvSchedule.TabIndex = 0;
            this.dgvSchedule.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellEnter);
            this.dgvSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvSchedule_MouseDown);
            // 
            // SAT
            // 
            this.SAT.FalseValue = "false";
            this.SAT.Frozen = true;
            this.SAT.HeaderText = "SAT";
            this.SAT.IndeterminateValue = "indeterminat";
            this.SAT.Name = "SAT";
            this.SAT.TrueValue = "true";
            this.SAT.Width = 60;
            // 
            // SUN
            // 
            this.SUN.FalseValue = "false";
            this.SUN.Frozen = true;
            this.SUN.HeaderText = "SUN";
            this.SUN.IndeterminateValue = "indeterminat";
            this.SUN.Name = "SUN";
            this.SUN.TrueValue = "true";
            this.SUN.Width = 60;
            // 
            // MON
            // 
            this.MON.FalseValue = "false";
            this.MON.Frozen = true;
            this.MON.HeaderText = "MON";
            this.MON.IndeterminateValue = "indeterminat";
            this.MON.Name = "MON";
            this.MON.TrueValue = "true";
            this.MON.Width = 60;
            // 
            // TUE
            // 
            this.TUE.FalseValue = "false";
            this.TUE.Frozen = true;
            this.TUE.HeaderText = "TUE";
            this.TUE.IndeterminateValue = "indeterminat";
            this.TUE.Name = "TUE";
            this.TUE.TrueValue = "true";
            this.TUE.Width = 60;
            // 
            // WED
            // 
            this.WED.FalseValue = "false";
            this.WED.Frozen = true;
            this.WED.HeaderText = "WED";
            this.WED.IndeterminateValue = "indeterminat";
            this.WED.Name = "WED";
            this.WED.TrueValue = "true";
            this.WED.Width = 60;
            // 
            // THUR
            // 
            this.THUR.FalseValue = "false";
            this.THUR.Frozen = true;
            this.THUR.HeaderText = "THUR";
            this.THUR.IndeterminateValue = "indeterminat";
            this.THUR.Name = "THUR";
            this.THUR.TrueValue = "true";
            this.THUR.Width = 60;
            // 
            // FRI
            // 
            this.FRI.FalseValue = "false";
            this.FRI.Frozen = true;
            this.FRI.HeaderText = "FRI";
            this.FRI.IndeterminateValue = "indeterminat";
            this.FRI.Name = "FRI";
            this.FRI.TrueValue = "true";
            this.FRI.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Time / Day";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Time
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Time.DefaultCellStyle = dataGridViewCellStyle3;
            this.Time.Frozen = true;
            this.Time.HeaderText = "Time / Day";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // ProfScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 402);
            this.Controls.Add(this.dgvSchedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfScheduleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Professor Schedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfScheduleForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SAT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SUN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MON;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TUE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WED;
        private System.Windows.Forms.DataGridViewCheckBoxColumn THUR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FRI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
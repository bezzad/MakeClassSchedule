namespace MakeClassSchedule
{
    partial class AddGroupsForm
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
            this.dgvSelectGroups = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectGroups
            // 
            this.dgvSelectGroups.AllowDrop = true;
            this.dgvSelectGroups.AllowUserToAddRows = false;
            this.dgvSelectGroups.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvSelectGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSelectGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectGroups.ColumnHeadersHeight = 40;
            this.dgvSelectGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectGroups.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelectGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelectGroups.Location = new System.Drawing.Point(0, 0);
            this.dgvSelectGroups.MultiSelect = false;
            this.dgvSelectGroups.Name = "dgvSelectGroups";
            this.dgvSelectGroups.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvSelectGroups.RowHeadersVisible = false;
            this.dgvSelectGroups.RowHeadersWidth = 25;
            this.dgvSelectGroups.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSelectGroups.RowTemplate.Height = 40;
            this.dgvSelectGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSelectGroups.Size = new System.Drawing.Size(702, 372);
            this.dgvSelectGroups.TabIndex = 1;
            // 
            // AddGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 372);
            this.Controls.Add(this.dgvSelectGroups);
            this.Name = "AddGroupsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Groups";
            this.Load += new System.EventHandler(this.AddGroupsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddGroupsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectGroups;


    }
}
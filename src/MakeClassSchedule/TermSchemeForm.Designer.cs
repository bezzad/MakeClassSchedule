namespace MakeClassSchedule
{
    partial class TermSchemeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermSchemeForm));
            this.dgvTermScheme = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermScheme)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTermScheme
            // 
            this.dgvTermScheme.AllowUserToAddRows = false;
            this.dgvTermScheme.AllowUserToDeleteRows = false;
            this.dgvTermScheme.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvTermScheme.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTermScheme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTermScheme.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvTermScheme.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTermScheme.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTermScheme.ColumnHeadersHeight = 40;
            this.dgvTermScheme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTermScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTermScheme.Location = new System.Drawing.Point(0, 0);
            this.dgvTermScheme.MultiSelect = false;
            this.dgvTermScheme.Name = "dgvTermScheme";
            this.dgvTermScheme.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTermScheme.RowHeadersVisible = false;
            this.dgvTermScheme.RowHeadersWidth = 25;
            this.dgvTermScheme.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTermScheme.RowTemplate.Height = 30;
            this.dgvTermScheme.Size = new System.Drawing.Size(484, 412);
            this.dgvTermScheme.TabIndex = 0;
            this.dgvTermScheme.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTermScheme_CellContentClick);
            // 
            // TermSchemeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.dgvTermScheme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TermSchemeForm";
            this.Text = "Term Scheme";
            this.Load += new System.EventHandler(this.TermSchemeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTermScheme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTermScheme;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnTermScheme;
    }
}
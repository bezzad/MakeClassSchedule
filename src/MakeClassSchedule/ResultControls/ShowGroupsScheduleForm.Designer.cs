namespace MakeClassSchedule.ResultControls
{
    partial class ShowGroupsScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowGroupsScheduleForm));
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.pGroups = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.Azure;
            this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.Red;
            this.btnExportToExcel.Location = new System.Drawing.Point(257, 12);
            this.btnExportToExcel.MaximumSize = new System.Drawing.Size(271, 31);
            this.btnExportToExcel.MinimumSize = new System.Drawing.Size(271, 31);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(271, 31);
            this.btnExportToExcel.TabIndex = 2;
            this.btnExportToExcel.Text = "&Export Groups Schedule To Excel File";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // pGroups
            // 
            this.pGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pGroups.AutoScroll = true;
            this.pGroups.BackColor = System.Drawing.Color.Azure;
            this.pGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGroups.Location = new System.Drawing.Point(0, 49);
            this.pGroups.Name = "pGroups";
            this.pGroups.Size = new System.Drawing.Size(784, 512);
            this.pGroups.TabIndex = 3;
            // 
            // ShowGroupsScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pGroups);
            this.Controls.Add(this.btnExportToExcel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowGroupsScheduleForm";
            this.Text = "Show Groups Schedule";
            this.Load += new System.EventHandler(this.ShowGroupsScheduleForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.ShowGroupsScheduleForm_ClientSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Panel pGroups;
    }
}
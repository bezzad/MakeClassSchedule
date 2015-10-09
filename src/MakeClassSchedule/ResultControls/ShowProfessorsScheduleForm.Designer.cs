namespace MakeClassSchedule.ResultControls
{
    partial class ShowProfessorsScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowProfessorsScheduleForm));
            this.pProfessors = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.colorDialogFreeTimeColor = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pProfessors
            // 
            this.pProfessors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pProfessors.AutoScroll = true;
            this.pProfessors.BackColor = System.Drawing.Color.LavenderBlush;
            this.pProfessors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pProfessors.Location = new System.Drawing.Point(0, 49);
            this.pProfessors.Name = "pProfessors";
            this.pProfessors.Size = new System.Drawing.Size(784, 512);
            this.pProfessors.TabIndex = 4;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.BackColor = System.Drawing.Color.AliceBlue;
            this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExportToExcel.Location = new System.Drawing.Point(497, 12);
            this.btnExportToExcel.MaximumSize = new System.Drawing.Size(275, 31);
            this.btnExportToExcel.MinimumSize = new System.Drawing.Size(275, 31);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(275, 31);
            this.btnExportToExcel.TabIndex = 5;
            this.btnExportToExcel.Text = "&Export Professors Schedule To Excel File";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // colorDialogFreeTimeColor
            // 
            this.colorDialogFreeTimeColor.AnyColor = true;
            this.colorDialogFreeTimeColor.FullOpen = true;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.LightGreen;
            this.btnColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(159, 12);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(33, 31);
            this.btnColor.TabIndex = 6;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Free Time Slot Colors:";
            // 
            // ShowProfessorsScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.pProfessors);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowProfessorsScheduleForm";
            this.Text = "Show Professors Schedule";
            this.Load += new System.EventHandler(this.ShowProfessorsScheduleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pProfessors;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.ColorDialog colorDialogFreeTimeColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label1;
    }
}
namespace MakeClassSchedule.ResultControls
{
    partial class CheckListCellsTextDataForm
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
            this.chklstExportCell = new System.Windows.Forms.CheckedListBox();
            this.btnSetCellText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklstExportCell
            // 
            this.chklstExportCell.BackColor = System.Drawing.Color.LightPink;
            this.chklstExportCell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chklstExportCell.CheckOnClick = true;
            this.chklstExportCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklstExportCell.FormattingEnabled = true;
            this.chklstExportCell.Location = new System.Drawing.Point(0, 0);
            this.chklstExportCell.Name = "chklstExportCell";
            this.chklstExportCell.Size = new System.Drawing.Size(200, 149);
            this.chklstExportCell.TabIndex = 4;
            // 
            // btnSetCellText
            // 
            this.btnSetCellText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetCellText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSetCellText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSetCellText.Location = new System.Drawing.Point(0, 144);
            this.btnSetCellText.Name = "btnSetCellText";
            this.btnSetCellText.Size = new System.Drawing.Size(200, 30);
            this.btnSetCellText.TabIndex = 5;
            this.btnSetCellText.Text = "Set Cell Text Data";
            this.btnSetCellText.UseVisualStyleBackColor = true;
            this.btnSetCellText.Click += new System.EventHandler(this.btnSetCellText_Click);
            // 
            // CheckListCellsTextDataForm
            // 
            this.AcceptButton = this.btnSetCellText;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 174);
            this.ControlBox = false;
            this.Controls.Add(this.btnSetCellText);
            this.Controls.Add(this.chklstExportCell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckListCellsTextDataForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CheckListCellsTextDataForm";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetCellText;
        internal System.Windows.Forms.CheckedListBox chklstExportCell;
    }
}
namespace MakeClassSchedule.ResultControls
{
    partial class OneFieldOfRoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneFieldOfRoomForm));
            this.btnProfessor = new System.Windows.Forms.Button();
            this.txtProfessor = new System.Windows.Forms.TextBox();
            this.chkGroups = new System.Windows.Forms.CheckedListBox();
            this.lblGroups = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkListProfessor = new System.Windows.Forms.CheckedListBox();
            this.btnSaveProfessor = new System.Windows.Forms.Button();
            this.btnCancelProfessor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProfessor
            // 
            this.btnProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfessor.Location = new System.Drawing.Point(221, 114);
            this.btnProfessor.Name = "btnProfessor";
            this.btnProfessor.Size = new System.Drawing.Size(113, 23);
            this.btnProfessor.TabIndex = 1;
            this.btnProfessor.Text = "Change &Professor";
            this.btnProfessor.UseVisualStyleBackColor = true;
            this.btnProfessor.Click += new System.EventHandler(this.btnProfessor_Click);
            // 
            // txtProfessor
            // 
            this.txtProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProfessor.Location = new System.Drawing.Point(12, 116);
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.ReadOnly = true;
            this.txtProfessor.Size = new System.Drawing.Size(203, 20);
            this.txtProfessor.TabIndex = 2;
            // 
            // chkGroups
            // 
            this.chkGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGroups.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkGroups.CheckOnClick = true;
            this.chkGroups.FormattingEnabled = true;
            this.chkGroups.Location = new System.Drawing.Point(12, 161);
            this.chkGroups.Name = "chkGroups";
            this.chkGroups.Size = new System.Drawing.Size(322, 105);
            this.chkGroups.TabIndex = 3;
            this.chkGroups.SelectedIndexChanged += new System.EventHandler(this.chkGroups_SelectedIndexChanged);
            this.chkGroups.SelectedValueChanged += new System.EventHandler(this.chkGroups_SelectedValueChanged);
            this.chkGroups.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chkGroups_KeyUp);
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(9, 145);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(44, 13);
            this.lblGroups.TabIndex = 0;
            this.lblGroups.Text = "Groups:";
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.BackColor = System.Drawing.SystemColors.Control;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInfo.Size = new System.Drawing.Size(322, 96);
            this.txtInfo.TabIndex = 4;
            this.txtInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(12, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(93, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkListProfessor
            // 
            this.chkListProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListProfessor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkListProfessor.CheckOnClick = true;
            this.chkListProfessor.FormattingEnabled = true;
            this.chkListProfessor.Location = new System.Drawing.Point(0, 0);
            this.chkListProfessor.Name = "chkListProfessor";
            this.chkListProfessor.Size = new System.Drawing.Size(345, 287);
            this.chkListProfessor.TabIndex = 7;
            this.chkListProfessor.TabStop = false;
            this.chkListProfessor.UseCompatibleTextRendering = true;
            this.chkListProfessor.Visible = false;
            this.chkListProfessor.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListProfessor_ItemCheck);
            // 
            // btnSaveProfessor
            // 
            this.btnSaveProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSaveProfessor.Location = new System.Drawing.Point(0, 286);
            this.btnSaveProfessor.Name = "btnSaveProfessor";
            this.btnSaveProfessor.Size = new System.Drawing.Size(172, 33);
            this.btnSaveProfessor.TabIndex = 8;
            this.btnSaveProfessor.TabStop = false;
            this.btnSaveProfessor.Text = "Save";
            this.btnSaveProfessor.UseVisualStyleBackColor = true;
            this.btnSaveProfessor.Visible = false;
            this.btnSaveProfessor.Click += new System.EventHandler(this.btnSaveProfessor_Click);
            // 
            // btnCancelProfessor
            // 
            this.btnCancelProfessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelProfessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancelProfessor.Location = new System.Drawing.Point(173, 286);
            this.btnCancelProfessor.Name = "btnCancelProfessor";
            this.btnCancelProfessor.Size = new System.Drawing.Size(172, 33);
            this.btnCancelProfessor.TabIndex = 8;
            this.btnCancelProfessor.TabStop = false;
            this.btnCancelProfessor.Text = "Cancel";
            this.btnCancelProfessor.UseVisualStyleBackColor = true;
            this.btnCancelProfessor.Visible = false;
            this.btnCancelProfessor.Click += new System.EventHandler(this.btnCancelProfessor_Click);
            // 
            // OneFieldOfRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 319);
            this.Controls.Add(this.btnCancelProfessor);
            this.Controls.Add(this.btnSaveProfessor);
            this.Controls.Add(this.chkListProfessor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.chkGroups);
            this.Controls.Add(this.txtProfessor);
            this.Controls.Add(this.btnProfessor);
            this.Controls.Add(this.lblGroups);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 240);
            this.Name = "OneFieldOfRoomForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change a field of the room";
            this.Load += new System.EventHandler(this.OneFieldOfRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProfessor;
        private System.Windows.Forms.TextBox txtProfessor;
        private System.Windows.Forms.CheckedListBox chkGroups;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckedListBox chkListProfessor;
        private System.Windows.Forms.Button btnSaveProfessor;
        private System.Windows.Forms.Button btnCancelProfessor;
    }
}
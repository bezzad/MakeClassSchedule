namespace MakeClassSchedule.ResultControls
{
    partial class ChangeRoomsDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeRoomsDataForm));
            this.pRooms = new System.Windows.Forms.Panel();
            this.contextMenuStripRightClickOnCell = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.contextMenuStripRightClickOnCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // pRooms
            // 
            this.pRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pRooms.AutoScroll = true;
            this.pRooms.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pRooms.ContextMenuStrip = this.contextMenuStripRightClickOnCell;
            this.pRooms.Location = new System.Drawing.Point(0, 32);
            this.pRooms.Name = "pRooms";
            this.pRooms.Size = new System.Drawing.Size(784, 530);
            this.pRooms.TabIndex = 0;
            // 
            // contextMenuStripRightClickOnCell
            // 
            this.contextMenuStripRightClickOnCell.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contextMenuStripRightClickOnCell.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCut,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemEdit});
            this.contextMenuStripRightClickOnCell.Name = "contextMenuStripRightClickOnCell";
            this.contextMenuStripRightClickOnCell.Size = new System.Drawing.Size(157, 274);
            // 
            // toolStripMenuItemCut
            // 
            this.toolStripMenuItemCut.Image = global::MakeClassSchedule.Properties.Resources.cut;
            this.toolStripMenuItemCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemCut.Name = "toolStripMenuItemCut";
            this.toolStripMenuItemCut.Size = new System.Drawing.Size(156, 54);
            this.toolStripMenuItemCut.Text = "Cut";
            this.toolStripMenuItemCut.Click += new System.EventHandler(this.toolStripMenuItemCut_Click);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Image = global::MakeClassSchedule.Properties.Resources.copy;
            this.toolStripMenuItemCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(156, 54);
            this.toolStripMenuItemCopy.Text = "Copy";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemPaste
            // 
            this.toolStripMenuItemPaste.Enabled = false;
            this.toolStripMenuItemPaste.Image = global::MakeClassSchedule.Properties.Resources.paste;
            this.toolStripMenuItemPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
            this.toolStripMenuItemPaste.Size = new System.Drawing.Size(156, 54);
            this.toolStripMenuItemPaste.Text = "Paste";
            this.toolStripMenuItemPaste.Click += new System.EventHandler(this.toolStripMenuItemPaste_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::MakeClassSchedule.Properties.Resources.delete;
            this.toolStripMenuItemDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(156, 54);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Image = global::MakeClassSchedule.Properties.Resources._327_Options_48x48_72;
            this.toolStripMenuItemEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(156, 54);
            this.toolStripMenuItemEdit.Text = "Edit";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.Location = new System.Drawing.Point(317, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Changed Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnExport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExport.Location = new System.Drawing.Point(142, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export to Excel Files";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnReset.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnReset.Location = new System.Drawing.Point(492, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset Changed Data";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ChangeRoomsDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pRooms);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeRoomsDataForm";
            this.Text = "Change Rooms Schedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeRoomsDataForm_FormClosing);
            this.contextMenuStripRightClickOnCell.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pRooms;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightClickOnCell;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReset;
    }
}
namespace MakeClassSchedule
{
    partial class RoomForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomForm));
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvType = new System.Windows.Forms.DataGridView();
            this.colTypeOfRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvType)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoom
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoom.ColumnHeadersHeight = 40;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colType,
            this.colSize});
            this.dgvRoom.Location = new System.Drawing.Point(0, 186);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.RowHeadersWidth = 25;
            this.dgvRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRoom.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dgvRoom.RowTemplate.Height = 30;
            this.dgvRoom.Size = new System.Drawing.Size(459, 276);
            this.dgvRoom.TabIndex = 0;
            this.dgvRoom.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRoom_UserDeletingRow);
            this.dgvRoom.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvRoom_RowsAdded);
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
            this.colID.Width = 50;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Room Name";
            this.colName.MinimumWidth = 100;
            this.colName.Name = "colName";
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.colType.DefaultCellStyle = dataGridViewCellStyle4;
            this.colType.HeaderText = "Type";
            this.colType.MinimumWidth = 50;
            this.colType.Name = "colType";
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.ToolTipText = "Type: Lab , Site , . . . ";
            // 
            // colSize
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colSize.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Width = 80;
            // 
            // dgvType
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvType.ColumnHeadersHeight = 40;
            this.dgvType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTypeOfRoom});
            this.dgvType.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvType.Location = new System.Drawing.Point(0, 0);
            this.dgvType.Name = "dgvType";
            this.dgvType.RowHeadersWidth = 25;
            this.dgvType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvType.RowTemplate.Height = 30;
            this.dgvType.Size = new System.Drawing.Size(459, 189);
            this.dgvType.TabIndex = 1;
            this.dgvType.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvType_UserDeletingRow);
            this.dgvType.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvType_UserDeletedRow);
            this.dgvType.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvType_CellEndEdit);
            // 
            // colTypeOfRoom
            // 
            this.colTypeOfRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTypeOfRoom.HeaderText = "Type Of Room";
            this.colTypeOfRoom.Name = "colTypeOfRoom";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 462);
            this.Controls.Add(this.dgvType);
            this.Controls.Add(this.dgvRoom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomForm";
            this.Text = "Room Data";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridView dgvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeOfRoom;
    }
}
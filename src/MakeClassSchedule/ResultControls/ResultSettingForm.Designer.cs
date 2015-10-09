namespace MakeClassSchedule.ResultControls
{
    partial class ResultSettingForm
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
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.btnGAS = new System.Windows.Forms.Button();
            this.chkFragmental = new System.Windows.Forms.CheckBox();
            this.chkActivityMonitor = new System.Windows.Forms.CheckBox();
            this.chkParallelProcessing = new System.Windows.Forms.CheckBox();
            this.chkSaveStoped = new System.Windows.Forms.CheckBox();
            this.chkRealTimeDisplay = new System.Windows.Forms.CheckBox();
            this.grbTools = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeRoomsData = new System.Windows.Forms.Button();
            this.btnClassroomsSchedule = new System.Windows.Forms.Button();
            this.btnProfessorsSchedule = new System.Windows.Forms.Button();
            this.btnGroupsSchedule = new System.Windows.Forms.Button();
            this.toolTipFragment = new System.Windows.Forms.ToolTip(this.components);
            this.grbSetting.SuspendLayout();
            this.grbTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSetting
            // 
            this.grbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSetting.Controls.Add(this.btnGAS);
            this.grbSetting.Controls.Add(this.chkFragmental);
            this.grbSetting.Controls.Add(this.chkActivityMonitor);
            this.grbSetting.Controls.Add(this.chkParallelProcessing);
            this.grbSetting.Controls.Add(this.chkSaveStoped);
            this.grbSetting.Controls.Add(this.chkRealTimeDisplay);
            this.grbSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.grbSetting.ForeColor = System.Drawing.Color.Blue;
            this.grbSetting.Location = new System.Drawing.Point(12, 12);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.Size = new System.Drawing.Size(400, 183);
            this.grbSetting.TabIndex = 0;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "Setting";
            // 
            // btnGAS
            // 
            this.btnGAS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnGAS.ForeColor = System.Drawing.Color.Crimson;
            this.btnGAS.Location = new System.Drawing.Point(73, 151);
            this.btnGAS.Name = "btnGAS";
            this.btnGAS.Size = new System.Drawing.Size(254, 26);
            this.btnGAS.TabIndex = 2;
            this.btnGAS.Text = "&Genetic Algorithm Setting (GAS)";
            this.btnGAS.UseVisualStyleBackColor = true;
            this.btnGAS.Click += new System.EventHandler(this.btnGAS_Click);
            // 
            // chkFragmental
            // 
            this.chkFragmental.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFragmental.AutoSize = true;
            this.chkFragmental.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFragmental.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.chkFragmental.ForeColor = System.Drawing.Color.Crimson;
            this.chkFragmental.Location = new System.Drawing.Point(73, 119);
            this.chkFragmental.Name = "chkFragmental";
            this.chkFragmental.Size = new System.Drawing.Size(254, 26);
            this.chkFragmental.TabIndex = 0;
            this.chkFragmental.Text = "Fragment Classes More than Two Units.";
            this.chkFragmental.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipFragment.SetToolTip(this.chkFragmental, "Fragmented classes that is not recoverable. \r\nThis operation is done only once.\r\n" +
                    "Please before fragmentation of class information, \r\ndo backup of them.");
            this.chkFragmental.UseVisualStyleBackColor = true;
            this.chkFragmental.CheckedChanged += new System.EventHandler(this.chkFragmental_CheckedChanged);
            // 
            // chkActivityMonitor
            // 
            this.chkActivityMonitor.AutoSize = true;
            this.chkActivityMonitor.Location = new System.Drawing.Point(10, 94);
            this.chkActivityMonitor.Name = "chkActivityMonitor";
            this.chkActivityMonitor.Size = new System.Drawing.Size(280, 19);
            this.chkActivityMonitor.TabIndex = 0;
            this.chkActivityMonitor.Text = "Show Activity Monitor for Performance Counter.";
            this.chkActivityMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkActivityMonitor.UseVisualStyleBackColor = true;
            this.chkActivityMonitor.CheckedChanged += new System.EventHandler(this.chkActivityMonitor_CheckedChanged);
            // 
            // chkParallelProcessing
            // 
            this.chkParallelProcessing.AutoSize = true;
            this.chkParallelProcessing.Checked = true;
            this.chkParallelProcessing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkParallelProcessing.Location = new System.Drawing.Point(10, 44);
            this.chkParallelProcessing.Name = "chkParallelProcessing";
            this.chkParallelProcessing.Size = new System.Drawing.Size(364, 19);
            this.chkParallelProcessing.TabIndex = 0;
            this.chkParallelProcessing.Text = "Parallel Processing for Genetic Algorithm (for Multi Core CPU).";
            this.chkParallelProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkParallelProcessing.UseVisualStyleBackColor = true;
            this.chkParallelProcessing.CheckedChanged += new System.EventHandler(this.chkParallelProcessing_CheckedChanged);
            // 
            // chkSaveStoped
            // 
            this.chkSaveStoped.AutoSize = true;
            this.chkSaveStoped.Checked = true;
            this.chkSaveStoped.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveStoped.Location = new System.Drawing.Point(10, 69);
            this.chkSaveStoped.Name = "chkSaveStoped";
            this.chkSaveStoped.Size = new System.Drawing.Size(347, 19);
            this.chkSaveStoped.TabIndex = 0;
            this.chkSaveStoped.Text = "Save Classroom Data when the Algorithm State is Stopped.";
            this.chkSaveStoped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSaveStoped.UseVisualStyleBackColor = true;
            this.chkSaveStoped.CheckedChanged += new System.EventHandler(this.chkSaveStoped_CheckedChanged);
            // 
            // chkRealTimeDisplay
            // 
            this.chkRealTimeDisplay.AutoSize = true;
            this.chkRealTimeDisplay.Checked = true;
            this.chkRealTimeDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRealTimeDisplay.Location = new System.Drawing.Point(10, 19);
            this.chkRealTimeDisplay.Name = "chkRealTimeDisplay";
            this.chkRealTimeDisplay.Size = new System.Drawing.Size(381, 19);
            this.chkRealTimeDisplay.TabIndex = 0;
            this.chkRealTimeDisplay.Text = "Display RealTime Genetic Algorithm Processing in DataGridView.";
            this.chkRealTimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRealTimeDisplay.UseVisualStyleBackColor = true;
            this.chkRealTimeDisplay.CheckedChanged += new System.EventHandler(this.chkRealTimeDisplay_CheckedChanged);
            // 
            // grbTools
            // 
            this.grbTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbTools.Controls.Add(this.label4);
            this.grbTools.Controls.Add(this.label3);
            this.grbTools.Controls.Add(this.label2);
            this.grbTools.Controls.Add(this.label1);
            this.grbTools.Controls.Add(this.btnChangeRoomsData);
            this.grbTools.Controls.Add(this.btnClassroomsSchedule);
            this.grbTools.Controls.Add(this.btnProfessorsSchedule);
            this.grbTools.Controls.Add(this.btnGroupsSchedule);
            this.grbTools.Location = new System.Drawing.Point(12, 201);
            this.grbTools.Name = "grbTools";
            this.grbTools.Size = new System.Drawing.Size(400, 129);
            this.grbTools.TabIndex = 0;
            this.grbTools.TabStop = false;
            this.grbTools.Text = "Tools";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 39);
            this.label4.TabIndex = 1;
            this.label4.Text = "Change\r\nRooms\r\nSchedule";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Show\r\nClassrooms\r\nSchedule";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Show\r\nProfessors\r\nSchedule";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show\r\nGroups\r\nSchedule";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangeRoomsData
            // 
            this.btnChangeRoomsData.BackgroundImage = global::MakeClassSchedule.Properties.Resources.Create_classroom_icon;
            this.btnChangeRoomsData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChangeRoomsData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeRoomsData.Location = new System.Drawing.Point(31, 18);
            this.btnChangeRoomsData.Name = "btnChangeRoomsData";
            this.btnChangeRoomsData.Size = new System.Drawing.Size(80, 60);
            this.btnChangeRoomsData.TabIndex = 0;
            this.btnChangeRoomsData.UseVisualStyleBackColor = true;
            this.btnChangeRoomsData.Click += new System.EventHandler(this.btnChangeRoomsData_Click);
            // 
            // btnClassroomsSchedule
            // 
            this.btnClassroomsSchedule.BackgroundImage = global::MakeClassSchedule.Properties.Resources.Classroom;
            this.btnClassroomsSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClassroomsSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClassroomsSchedule.Location = new System.Drawing.Point(117, 18);
            this.btnClassroomsSchedule.Name = "btnClassroomsSchedule";
            this.btnClassroomsSchedule.Size = new System.Drawing.Size(80, 60);
            this.btnClassroomsSchedule.TabIndex = 0;
            this.btnClassroomsSchedule.UseVisualStyleBackColor = true;
            this.btnClassroomsSchedule.Click += new System.EventHandler(this.btnClassroomsSchedule_Click);
            // 
            // btnProfessorsSchedule
            // 
            this.btnProfessorsSchedule.BackgroundImage = global::MakeClassSchedule.Properties.Resources.Professor;
            this.btnProfessorsSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProfessorsSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfessorsSchedule.Location = new System.Drawing.Point(289, 18);
            this.btnProfessorsSchedule.Name = "btnProfessorsSchedule";
            this.btnProfessorsSchedule.Size = new System.Drawing.Size(80, 60);
            this.btnProfessorsSchedule.TabIndex = 0;
            this.btnProfessorsSchedule.UseVisualStyleBackColor = true;
            this.btnProfessorsSchedule.Click += new System.EventHandler(this.btnProfessorsSchedule_Click);
            // 
            // btnGroupsSchedule
            // 
            this.btnGroupsSchedule.BackgroundImage = global::MakeClassSchedule.Properties.Resources.groups;
            this.btnGroupsSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGroupsSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroupsSchedule.Location = new System.Drawing.Point(203, 18);
            this.btnGroupsSchedule.Name = "btnGroupsSchedule";
            this.btnGroupsSchedule.Size = new System.Drawing.Size(80, 60);
            this.btnGroupsSchedule.TabIndex = 0;
            this.btnGroupsSchedule.UseVisualStyleBackColor = true;
            this.btnGroupsSchedule.Click += new System.EventHandler(this.btnGroupsSchedule_Click);
            // 
            // toolTipFragment
            // 
            this.toolTipFragment.AutomaticDelay = 50;
            this.toolTipFragment.AutoPopDelay = 10000;
            this.toolTipFragment.InitialDelay = 50;
            this.toolTipFragment.IsBalloon = true;
            this.toolTipFragment.OwnerDraw = true;
            this.toolTipFragment.ReshowDelay = 10;
            this.toolTipFragment.ShowAlways = true;
            this.toolTipFragment.StripAmpersands = true;
            this.toolTipFragment.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipFragment.ToolTipTitle = "Is Usable Only Once";
            // 
            // ResultSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 342);
            this.Controls.Add(this.grbTools);
            this.Controls.Add(this.grbSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultSettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools and Setting";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ResultSettingForm_Load);
            this.grbSetting.ResumeLayout(false);
            this.grbSetting.PerformLayout();
            this.grbTools.ResumeLayout(false);
            this.grbTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSetting;
        private System.Windows.Forms.GroupBox grbTools;
        private System.Windows.Forms.CheckBox chkRealTimeDisplay;
        private System.Windows.Forms.CheckBox chkActivityMonitor;
        private System.Windows.Forms.CheckBox chkParallelProcessing;
        private System.Windows.Forms.CheckBox chkSaveStoped;
        private System.Windows.Forms.Button btnGroupsSchedule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeRoomsData;
        private System.Windows.Forms.Button btnClassroomsSchedule;
        private System.Windows.Forms.Button btnProfessorsSchedule;
        private System.Windows.Forms.CheckBox chkFragmental;
        private System.Windows.Forms.ToolTip toolTipFragment;
        private System.Windows.Forms.Button btnGAS;
    }
}
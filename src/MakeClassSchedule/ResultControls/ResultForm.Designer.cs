namespace MakeClassSchedule.ResultControls
{
    partial class ResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblFitness = new System.Windows.Forms.Label();
            this.lblWorkingSet = new System.Windows.Forms.Label();
            this.timerWorkingSet = new System.Windows.Forms.Timer(this.components);
            this.lblGeneration = new System.Windows.Forms.Label();
            this.chPerformanceCounter = new System.Windows.Forms.CheckBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelRoomDGV = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&START";
            this.toolTip1.SetToolTip(this.btnStart, "Start/Resume GA Solver");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(184, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 28);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "S&TOP";
            this.toolTip1.SetToolTip(this.btnStop, "Stop any process about GA Solver");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(98, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 28);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "&PAUSE";
            this.toolTip1.SetToolTip(this.btnPause, "Pause GA Solver Process");
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblFitness
            // 
            this.lblFitness.AutoSize = true;
            this.lblFitness.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFitness.ForeColor = System.Drawing.Color.Crimson;
            this.lblFitness.Location = new System.Drawing.Point(284, 15);
            this.lblFitness.Name = "lblFitness";
            this.lblFitness.Size = new System.Drawing.Size(162, 23);
            this.lblFitness.TabIndex = 0;
            this.lblFitness.Text = "Fitness: 0.000000";
            this.toolTip1.SetToolTip(this.lblFitness, "The Best Chromosome Fitness");
            // 
            // lblWorkingSet
            // 
            this.lblWorkingSet.AutoSize = true;
            this.lblWorkingSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblWorkingSet.Location = new System.Drawing.Point(12, 43);
            this.lblWorkingSet.Name = "lblWorkingSet";
            this.lblWorkingSet.Size = new System.Drawing.Size(330, 15);
            this.lblWorkingSet.TabIndex = 3;
            this.lblWorkingSet.Text = "Amount of physical memory mapped to the process context:";
            this.toolTip1.SetToolTip(this.lblWorkingSet, "Physical Memory Used by This Program\'s in any time");
            // 
            // timerWorkingSet
            // 
            this.timerWorkingSet.Interval = 500;
            this.timerWorkingSet.Tick += new System.EventHandler(this.timerWorkingSet_Tick);
            // 
            // lblGeneration
            // 
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblGeneration.ForeColor = System.Drawing.Color.Crimson;
            this.lblGeneration.Location = new System.Drawing.Point(462, 15);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(190, 23);
            this.lblGeneration.TabIndex = 0;
            this.lblGeneration.Text = "Generation: 0000000";
            this.toolTip1.SetToolTip(this.lblGeneration, "Number of Generation in Genetic Algorithm\'s hereunto");
            // 
            // chPerformanceCounter
            // 
            this.chPerformanceCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chPerformanceCounter.Appearance = System.Windows.Forms.Appearance.Button;
            this.chPerformanceCounter.AutoSize = true;
            this.chPerformanceCounter.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chPerformanceCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chPerformanceCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chPerformanceCounter.Location = new System.Drawing.Point(588, 41);
            this.chPerformanceCounter.Name = "chPerformanceCounter";
            this.chPerformanceCounter.Size = new System.Drawing.Size(122, 24);
            this.chPerformanceCounter.TabIndex = 3;
            this.chPerformanceCounter.Text = "Performance Counter";
            this.chPerformanceCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chPerformanceCounter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.chPerformanceCounter, "Show/Hide Activity Monitor of Performance Counter");
            this.chPerformanceCounter.UseCompatibleTextRendering = true;
            this.chPerformanceCounter.UseVisualStyleBackColor = true;
            this.chPerformanceCounter.CheckedChanged += new System.EventHandler(this.chPerformanceCounter_CheckedChanged);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.Location = new System.Drawing.Point(714, 11);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(58, 54);
            this.btnSetting.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnSetting, "Tools and Setting for RealTime Data");
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panelRoomDGV
            // 
            this.panelRoomDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRoomDGV.AutoScroll = true;
            this.panelRoomDGV.BackColor = System.Drawing.SystemColors.Control;
            this.panelRoomDGV.Location = new System.Drawing.Point(0, 74);
            this.panelRoomDGV.Name = "panelRoomDGV";
            this.panelRoomDGV.Size = new System.Drawing.Size(784, 487);
            this.panelRoomDGV.TabIndex = 0;
            this.toolTip1.SetToolTip(this.panelRoomDGV, "Rooms Schedule in RealTime Working");
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panelRoomDGV);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.chPerformanceCounter);
            this.Controls.Add(this.lblWorkingSet);
            this.Controls.Add(this.lblGeneration);
            this.Controls.Add(this.lblFitness);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(788, 600);
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblWorkingSet;
        private System.Windows.Forms.Timer timerWorkingSet;
        public System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label lblFitness;
        private System.Windows.Forms.CheckBox chPerformanceCounter;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelRoomDGV;

    }
}
namespace PerformanceCounterControls
{
    sealed partial class PerformanceCounters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SpPerfChart.ChartPen chartPen1 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen2 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen3 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen4 = new SpPerfChart.ChartPen();
            this.subPanel = new System.Windows.Forms.Panel();
            this.lblProcessorName = new System.Windows.Forms.Label();
            this.lblMemPercent = new System.Windows.Forms.Label();
            this.lblProcessor = new System.Windows.Forms.Label();
            this.lblSplit2 = new System.Windows.Forms.Label();
            this.lblSplit1 = new System.Windows.Forms.Label();
            this.lblTotalNo = new System.Windows.Forms.Label();
            this.lblFreeNo = new System.Windows.Forms.Label();
            this.lblUsedNo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblFree = new System.Windows.Forms.Label();
            this.lblUsed = new System.Windows.Forms.Label();
            this.prbMemory = new System.Windows.Forms.ProgressBar();
            this.lblMemory = new System.Windows.Forms.Label();
            this.performanceCounterChart = new PerformanceCounterControls.PerformanceCounterChart();
            this.SuspendLayout();
            // 
            // subPanel
            // 
            this.subPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subPanel.AutoScroll = true;
            this.subPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.subPanel.Location = new System.Drawing.Point(3, 325);
            this.subPanel.Name = "subPanel";
            this.subPanel.Size = new System.Drawing.Size(388, 67);
            this.subPanel.TabIndex = 2;
            // 
            // lblProcessorName
            // 
            this.lblProcessorName.AutoSize = true;
            this.lblProcessorName.ForeColor = System.Drawing.Color.Black;
            this.lblProcessorName.Location = new System.Drawing.Point(95, 309);
            this.lblProcessorName.Name = "lblProcessorName";
            this.lblProcessorName.Size = new System.Drawing.Size(113, 13);
            this.lblProcessorName.TabIndex = 50;
            this.lblProcessorName.Text = "NumberOfCoreXBit.No";
            // 
            // lblMemPercent
            // 
            this.lblMemPercent.AutoSize = true;
            this.lblMemPercent.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMemPercent.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblMemPercent.Location = new System.Drawing.Point(320, 238);
            this.lblMemPercent.Name = "lblMemPercent";
            this.lblMemPercent.Size = new System.Drawing.Size(29, 15);
            this.lblMemPercent.TabIndex = 46;
            this.lblMemPercent.Text = "0%";
            // 
            // lblProcessor
            // 
            this.lblProcessor.AutoSize = true;
            this.lblProcessor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblProcessor.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblProcessor.Location = new System.Drawing.Point(6, 306);
            this.lblProcessor.Name = "lblProcessor";
            this.lblProcessor.Size = new System.Drawing.Size(83, 16);
            this.lblProcessor.TabIndex = 45;
            this.lblProcessor.Text = "PROCESSOR";
            // 
            // lblSplit2
            // 
            this.lblSplit2.AutoSize = true;
            this.lblSplit2.Location = new System.Drawing.Point(255, 264);
            this.lblSplit2.Name = "lblSplit2";
            this.lblSplit2.Size = new System.Drawing.Size(9, 39);
            this.lblSplit2.TabIndex = 43;
            this.lblSplit2.Text = "|\r\n|\r\n|";
            // 
            // lblSplit1
            // 
            this.lblSplit1.AutoSize = true;
            this.lblSplit1.Location = new System.Drawing.Point(132, 264);
            this.lblSplit1.Name = "lblSplit1";
            this.lblSplit1.Size = new System.Drawing.Size(9, 39);
            this.lblSplit1.TabIndex = 44;
            this.lblSplit1.Text = "|\r\n|\r\n|";
            // 
            // lblTotalNo
            // 
            this.lblTotalNo.AutoSize = true;
            this.lblTotalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblTotalNo.Location = new System.Drawing.Point(288, 281);
            this.lblTotalNo.Name = "lblTotalNo";
            this.lblTotalNo.Size = new System.Drawing.Size(59, 16);
            this.lblTotalNo.TabIndex = 42;
            this.lblTotalNo.Text = "0000 MB";
            // 
            // lblFreeNo
            // 
            this.lblFreeNo.AutoSize = true;
            this.lblFreeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblFreeNo.Location = new System.Drawing.Point(169, 281);
            this.lblFreeNo.Name = "lblFreeNo";
            this.lblFreeNo.Size = new System.Drawing.Size(59, 16);
            this.lblFreeNo.TabIndex = 40;
            this.lblFreeNo.Text = "0000 MB";
            // 
            // lblUsedNo
            // 
            this.lblUsedNo.AutoSize = true;
            this.lblUsedNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblUsedNo.Location = new System.Drawing.Point(48, 281);
            this.lblUsedNo.Name = "lblUsedNo";
            this.lblUsedNo.Size = new System.Drawing.Size(59, 16);
            this.lblUsedNo.TabIndex = 41;
            this.lblUsedNo.Text = "0000 MB";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(299, 263);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 15);
            this.lblTotal.TabIndex = 37;
            this.lblTotal.Text = "Total";
            // 
            // lblFree
            // 
            this.lblFree.AutoEllipsis = true;
            this.lblFree.AutoSize = true;
            this.lblFree.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFree.ForeColor = System.Drawing.Color.Black;
            this.lblFree.Location = new System.Drawing.Point(182, 263);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(32, 15);
            this.lblFree.TabIndex = 38;
            this.lblFree.Text = "Free";
            // 
            // lblUsed
            // 
            this.lblUsed.AutoEllipsis = true;
            this.lblUsed.AutoSize = true;
            this.lblUsed.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUsed.ForeColor = System.Drawing.Color.Black;
            this.lblUsed.Location = new System.Drawing.Point(60, 263);
            this.lblUsed.Name = "lblUsed";
            this.lblUsed.Size = new System.Drawing.Size(33, 15);
            this.lblUsed.TabIndex = 39;
            this.lblUsed.Text = "Used";
            // 
            // prbMemory
            // 
            this.prbMemory.Location = new System.Drawing.Point(46, 233);
            this.prbMemory.MarqueeAnimationSpeed = 50;
            this.prbMemory.Name = "prbMemory";
            this.prbMemory.Size = new System.Drawing.Size(270, 23);
            this.prbMemory.TabIndex = 36;
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMemory.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblMemory.Location = new System.Drawing.Point(6, 214);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(64, 16);
            this.lblMemory.TabIndex = 35;
            this.lblMemory.Text = "MEMORY";
            // 
            // performanceCounterChart
            // 
            this.performanceCounterChart.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.DarkGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            chartPen1.Width = 2F;
            this.performanceCounterChart.AvgLinePen = chartPen1;
            this.performanceCounterChart.AvgLinePenColor = System.Drawing.Color.DarkGreen;
            this.performanceCounterChart.AvgLinePenDashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.performanceCounterChart.AvgLinePenWidth = 2F;
            this.performanceCounterChart.BackgroundColorBottom = System.Drawing.Color.Azure;
            this.performanceCounterChart.BackgroundColorTop = System.Drawing.Color.Gold;
            chartPen2.Color = System.Drawing.Color.Blue;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.performanceCounterChart.ChartLinePen = chartPen2;
            this.performanceCounterChart.ChartLinePenColor = System.Drawing.Color.Blue;
            this.performanceCounterChart.ChartLinePenDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.performanceCounterChart.ChartLinePenWidth = 1F;
            chartPen3.Color = System.Drawing.Color.Gray;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen3.Width = 1F;
            this.performanceCounterChart.HorizontalGridPen = chartPen3;
            this.performanceCounterChart.HorizontalGridPenColor = System.Drawing.Color.Gray;
            this.performanceCounterChart.HorizontalGridPenDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.performanceCounterChart.HorizontalGridPenWidth = 1F;
            this.performanceCounterChart.Location = new System.Drawing.Point(3, 3);
            this.performanceCounterChart.MarqueeAnimationSpeed = 1;
            this.performanceCounterChart.Maximum = 100;
            this.performanceCounterChart.Minimum = 0;
            this.performanceCounterChart.Name = "performanceCounterChart";
            this.performanceCounterChart.ScaleMode = SpPerfChart.ScaleMode.Absolute;
            this.performanceCounterChart.ShowAverageLine = true;
            this.performanceCounterChart.ShowHorizontalGridLines = true;
            this.performanceCounterChart.ShowVerticalGridLines = true;
            this.performanceCounterChart.Size = new System.Drawing.Size(388, 218);
            this.performanceCounterChart.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.performanceCounterChart.TabIndex = 34;
            this.performanceCounterChart.TimerInterval = 15;
            this.performanceCounterChart.TimerMode = SpPerfChart.TimerMode.Disabled;
            this.performanceCounterChart.Value = 0;
            chartPen4.Color = System.Drawing.Color.Gray;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen4.Width = 1F;
            this.performanceCounterChart.VerticalGridPen = chartPen4;
            this.performanceCounterChart.VerticalGridPenColor = System.Drawing.Color.Gray;
            this.performanceCounterChart.VerticalGridPenDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.performanceCounterChart.VerticalGridPenWidth = 1F;
            this.performanceCounterChart.VerticalText = "Total CPU Usage";
            // 
            // PerformanceCounters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProcessorName);
            this.Controls.Add(this.lblMemPercent);
            this.Controls.Add(this.lblProcessor);
            this.Controls.Add(this.lblSplit2);
            this.Controls.Add(this.lblSplit1);
            this.Controls.Add(this.lblTotalNo);
            this.Controls.Add(this.lblFreeNo);
            this.Controls.Add(this.lblUsedNo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblFree);
            this.Controls.Add(this.lblUsed);
            this.Controls.Add(this.prbMemory);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.performanceCounterChart);
            this.Controls.Add(this.subPanel);
            this.Name = "PerformanceCounters";
            this.Size = new System.Drawing.Size(394, 395);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel subPanel;
        private System.Windows.Forms.Label lblProcessorName;
        private System.Windows.Forms.Label lblMemPercent;
        private System.Windows.Forms.Label lblProcessor;
        private System.Windows.Forms.Label lblSplit2;
        private System.Windows.Forms.Label lblSplit1;
        private System.Windows.Forms.Label lblTotalNo;
        private System.Windows.Forms.Label lblFreeNo;
        private System.Windows.Forms.Label lblUsedNo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFree;
        private System.Windows.Forms.Label lblUsed;
        private System.Windows.Forms.ProgressBar prbMemory;
        private System.Windows.Forms.Label lblMemory;
        private global::PerformanceCounterControls.PerformanceCounterChart performanceCounterChart;
    }
}

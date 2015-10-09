using PerformanceCounterControls;
namespace MakeClassSchedule.PerformanceCounterControls
{
    partial class PerformanceCounterForm
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
            SpPerfChart.ChartPen chartPen1 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen2 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen3 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen4 = new SpPerfChart.ChartPen();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceCounterForm));
            this.PC_ActivityMonitor = new PerformanceCounters();
            this.SuspendLayout();
            // 
            // PC_ActivityMonitor
            // 
            this.PC_ActivityMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PC_ActivityMonitor.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.DarkGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            chartPen1.Width = 2F;
            this.PC_ActivityMonitor.AvgLinePen = chartPen1;
            this.PC_ActivityMonitor.AvgLinePenColor = System.Drawing.Color.DarkGreen;
            this.PC_ActivityMonitor.AvgLinePenDashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.PC_ActivityMonitor.AvgLinePenWidth = 2F;
            this.PC_ActivityMonitor.BackgroundColorBottom = System.Drawing.Color.Azure;
            this.PC_ActivityMonitor.BackgroundColorTop = System.Drawing.Color.Gold;
            chartPen2.Color = System.Drawing.Color.Blue;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.PC_ActivityMonitor.ChartLinePen = chartPen2;
            this.PC_ActivityMonitor.ChartLinePenColor = System.Drawing.Color.Blue;
            this.PC_ActivityMonitor.ChartLinePenDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.PC_ActivityMonitor.ChartLinePenWidth = 1F;
            chartPen3.Color = System.Drawing.Color.Gray;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen3.Width = 1F;
            this.PC_ActivityMonitor.HorizontalGridPen = chartPen3;
            this.PC_ActivityMonitor.HorizontalGridPenColor = System.Drawing.Color.Gray;
            this.PC_ActivityMonitor.HorizontalGridPenDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.PC_ActivityMonitor.HorizontalGridPenWidth = 1F;
            this.PC_ActivityMonitor.Location = new System.Drawing.Point(0, 0);
            this.PC_ActivityMonitor.MarqueeAnimationSpeed = 1;
            this.PC_ActivityMonitor.Name = "PC_ActivityMonitor";
            this.PC_ActivityMonitor.ScaleMode = SpPerfChart.ScaleMode.Absolute;
            this.PC_ActivityMonitor.ShowAverageLine = true;
            this.PC_ActivityMonitor.ShowHorizontalGridLines = true;
            this.PC_ActivityMonitor.ShowVerticalGridLines = true;
            this.PC_ActivityMonitor.Size = new System.Drawing.Size(394, 393);
            this.PC_ActivityMonitor.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.PC_ActivityMonitor.TabIndex = 0;
            this.PC_ActivityMonitor.TimerInterval = 15;
            this.PC_ActivityMonitor.TimerMode = SpPerfChart.TimerMode.Disabled;
            chartPen4.Color = System.Drawing.Color.Gray;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen4.Width = 1F;
            this.PC_ActivityMonitor.VerticalGridPen = chartPen4;
            this.PC_ActivityMonitor.VerticalGridPenColor = System.Drawing.Color.Gray;
            this.PC_ActivityMonitor.VerticalGridPenDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.PC_ActivityMonitor.VerticalGridPenWidth = 1F;
            // 
            // PerformanceCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 392);
            this.Controls.Add(this.PC_ActivityMonitor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 430);
            this.Name = "PerformanceCounterForm";
            this.ShowInTaskbar = false;
            this.Text = "Activity Monitor";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PerformanceCounterForm_FormClosed);
            this.Load += new System.EventHandler(this.PerformanceCounterForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public PerformanceCounters PC_ActivityMonitor;

    }
}
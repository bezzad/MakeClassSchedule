namespace PerformanceCounterControls
{
    partial class PerformanceCounterChart
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
            this.label_Percent = new System.Windows.Forms.Label();
            this.label_Vertical = new PerformanceCounterControls.VerticalLabel();
            this.progressBar_Vertical = new PerformanceCounterControls.VerticalProgressBar();
            this.chart = new PerformanceCounterControls.Chart();
            this.SuspendLayout();
            // 
            // label_Percent
            // 
            this.label_Percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Percent.AutoSize = true;
            this.label_Percent.BackColor = System.Drawing.Color.Transparent;
            this.label_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label_Percent.Location = new System.Drawing.Point(336, 198);
            this.label_Percent.Name = "label_Percent";
            this.label_Percent.Size = new System.Drawing.Size(29, 18);
            this.label_Percent.TabIndex = 1;
            this.label_Percent.Text = "0%";
            this.label_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Percent.UseMnemonic = false;
            // 
            // label_Vertical
            // 
            this.label_Vertical.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Vertical.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label_Vertical.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Vertical.Location = new System.Drawing.Point(370, 57);
            this.label_Vertical.Name = "label_Vertical";
            this.label_Vertical.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.label_Vertical.Size = new System.Drawing.Size(20, 77);
            this.label_Vertical.TabIndex = 0;
            this.label_Vertical.TabStop = false;
            this.label_Vertical.Text = "Vertical Text";
            this.label_Vertical.TextDrawMode = PerformanceCounterControls.DrawMode.TopBottom;
            this.label_Vertical.TransparentBackground = true;
            // 
            // progressBar_Vertical
            // 
            this.progressBar_Vertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Vertical.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar_Vertical.Location = new System.Drawing.Point(339, 0);
            this.progressBar_Vertical.MarqueeAnimationSpeed = 40;
            this.progressBar_Vertical.MaximumSize = new System.Drawing.Size(25, 1000);
            this.progressBar_Vertical.MinimumSize = new System.Drawing.Size(25, 0);
            this.progressBar_Vertical.Name = "progressBar_Vertical";
            this.progressBar_Vertical.Size = new System.Drawing.Size(25, 195);
            this.progressBar_Vertical.Step = 100;
            this.progressBar_Vertical.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_Vertical.TabIndex = 0;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BorderStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.chart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.DarkGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            chartPen1.Width = 2F;
            this.chart.PerfChartStyle.AvgLinePen = chartPen1;
            this.chart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.Azure;
            this.chart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gold;
            chartPen2.Color = System.Drawing.Color.Blue;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.chart.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.Gray;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen3.Width = 1F;
            this.chart.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.chart.PerfChartStyle.ShowAverageLine = true;
            this.chart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.chart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.Gray;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen4.Width = 1F;
            this.chart.PerfChartStyle.VerticalGridPen = chartPen4;
            this.chart.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.chart.Size = new System.Drawing.Size(338, 195);
            this.chart.TabIndex = 0;
            this.chart.TimerInterval = 100;
            this.chart.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // PerformanceCounterChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Vertical);
            this.Controls.Add(this.label_Percent);
            this.Controls.Add(this.progressBar_Vertical);
            this.Controls.Add(this.chart);
            this.Name = "PerformanceCounterChart";
            this.Size = new System.Drawing.Size(393, 219);
            this.SizeChanged += new System.EventHandler(this.PerformanceCounterChart_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PerformanceCounterControls.Chart chart;
        private PerformanceCounterControls.VerticalProgressBar progressBar_Vertical;
        private System.Windows.Forms.Label label_Percent;
        private PerformanceCounterControls.VerticalLabel label_Vertical;

    }
}

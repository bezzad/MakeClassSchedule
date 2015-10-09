namespace PerformanceCounterControls
{
    partial class Chart
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
            this.SuspendLayout();
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.Name = "Chart";
            this.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.DarkGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            chartPen1.Width = 2F;
            this.PerfChartStyle.AvgLinePen = chartPen1;
            this.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.Azure;
            this.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gold;
            chartPen2.Color = System.Drawing.Color.Blue;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.Gray;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen3.Width = 1F;
            this.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.PerfChartStyle.ShowAverageLine = true;
            this.PerfChartStyle.ShowHorizontalGridLines = true;
            this.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.Gray;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            chartPen4.Width = 1F;
            this.PerfChartStyle.VerticalGridPen = chartPen4;
            this.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.Size = new System.Drawing.Size(368, 210);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

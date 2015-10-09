using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PerformanceCounterControls
{
    public partial class PerformanceCounterChart : UserControl
    {
        public PerformanceCounterChart()
        {
            InitializeComponent();
            Value = 0;
            Maximum = 100;
            Minimum = 0;
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.VerticalText = "Vertical Text";
            this.Style = ProgressBarStyle.Continuous;
        }

        /// <summary>
        /// Vertical Text Font
        /// </summary>
        public override Font Font
        {
            get
            {
                return this.label_Vertical.Font;
            }
            set
            {
                this.label_Vertical.Font = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Vertical Text ForeColor
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return this.label_Vertical.ForeColor;
            }
            set
            {
                this.label_Vertical.ForeColor = value;
            }
        }

        /// <summary>
        /// The current value for the VerticalProgressBar and Chart 
        /// and Percent Label, in the range specified by the 
        /// minimum and maximum properties.
        /// </summary>
        public int Value
        {
            get { return this.progressBar_Vertical.Value; }
            set
            {
                try
                {
                    this.chart.AddValue((decimal)value);
                    this.progressBar_Vertical.Value = value;
                    this.label_Percent.Text = value.ToString() + "%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
            }
        }

        /// <summary>
        /// The upper bound of the range this VerticalProgressBar is working with.
        /// </summary>
        public int Maximum
        {
            get { return this.progressBar_Vertical.Maximum; }
            set 
            {
                progressBar_Vertical.Maximum = value;
            }
        }

        /// <summary>
        /// The lower bound of the range this VerticalProgressBar is working with.
        /// </summary>
        public int Minimum
        {
            get { return this.progressBar_Vertical.Minimum; }
            set 
            {
                progressBar_Vertical.Minimum = value;
            }
        }

        /// <summary>
        /// The verticalText associated with the control.
        /// </summary>
        [Browsable(true)]
        [DefaultValue("Vertical Text")]
        public string VerticalText
        {
            get { return this.label_Vertical.Text; }
            set
            {
                base.Text = value;
                label_Vertical.Text = value;
                label_Vertical.Size = calculateTextHeight(value, label_Vertical.Font);
                PerformanceCounterChart_SizeChanged(label_Vertical, new EventArgs());
                this.Invalidate();
            }
        }

        public bool AntiAliasing
        {
            get { return this.chart.PerfChartStyle.AntiAliasing; }
            set
            {
                this.chart.PerfChartStyle.AntiAliasing = value;
                this.Invalidate();
            }
        }
        public Color BackgroundColorBottom
        {
            get { return chart.PerfChartStyle.BackgroundColorBottom; }
            set
            {
                chart.PerfChartStyle.BackgroundColorBottom = value;
                this.Invalidate();
            }
        }
        public Color BackgroundColorTop
        {
            get { return chart.PerfChartStyle.BackgroundColorTop; }
            set
            {
                chart.PerfChartStyle.BackgroundColorTop = value;
                this.Invalidate();
            }
        }
        public bool ShowAverageLine
        {
            get { return this.chart.PerfChartStyle.ShowAverageLine; }
            set
            {
                this.chart.PerfChartStyle.ShowAverageLine = value;
                this.Invalidate();
            }
        }
        public bool ShowHorizontalGridLines
        {
            get { return this.chart.PerfChartStyle.ShowHorizontalGridLines; }
            set
            {
                this.chart.PerfChartStyle.ShowHorizontalGridLines = value;
                this.Invalidate();
            }
        }
        public bool ShowVerticalGridLines
        {
            get { return this.chart.PerfChartStyle.ShowVerticalGridLines; }
            set
            {
                this.chart.PerfChartStyle.ShowVerticalGridLines = value;
                this.Invalidate();
            }
        }
        public SpPerfChart.ScaleMode ScaleMode
        {
            get { return this.chart.ScaleMode; }
            set
            {
                this.chart.ScaleMode = value;
                this.Invalidate();
            }
        }
        public int TimerInterval
        {
            get { return this.chart.TimerInterval; }
            set
            {
                this.chart.TimerInterval = value;
                MarqueeAnimationSpeed = value / 10;
            }
        }
        public int MarqueeAnimationSpeed
        {
            get { return progressBar_Vertical.MarqueeAnimationSpeed; }
            set { progressBar_Vertical.MarqueeAnimationSpeed = value; }
        }
        public SpPerfChart.TimerMode TimerMode
        {
            get { return this.chart.TimerMode; }
            set { this.chart.TimerMode = value; }
        }
        public ProgressBarStyle Style
        {
            get { return progressBar_Vertical.Style; }
            set
            {
                progressBar_Vertical.Style = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public SpPerfChart.ChartPen AvgLinePen
        {
            get { return chart.PerfChartStyle.AvgLinePen; }
            set
            {
                chart.PerfChartStyle.AvgLinePen = value;
                this.Invalidate();
            }
        }
        public Color AvgLinePenColor
        {
            get { return AvgLinePen.Color; }
            set { AvgLinePen.Color = value; }
        }
        public System.Drawing.Drawing2D.DashStyle AvgLinePenDashStyle
        {
            get { return AvgLinePen.DashStyle; }
            set { AvgLinePen.DashStyle = value; }
        }
        public float AvgLinePenWidth
        {
            get { return AvgLinePen.Width; }
            set { AvgLinePen.Width = value; }
        }

        [Browsable(false)]
        public SpPerfChart.ChartPen VerticalGridPen
        {
            get { return chart.PerfChartStyle.VerticalGridPen; }
            set
            {
                chart.PerfChartStyle.VerticalGridPen = value;
                this.Invalidate();
            }
        }
        public Color VerticalGridPenColor
        {
            get { return VerticalGridPen.Color; }
            set { VerticalGridPen.Color = value; }
        }
        public System.Drawing.Drawing2D.DashStyle VerticalGridPenDashStyle
        {
            get { return VerticalGridPen.DashStyle; }
            set { VerticalGridPen.DashStyle = value; }
        }
        public float VerticalGridPenWidth
        {
            get { return VerticalGridPen.Width; }
            set { VerticalGridPen.Width = value; }
        }

        [Browsable(false)]
        public SpPerfChart.ChartPen HorizontalGridPen
        {
            get { return chart.PerfChartStyle.HorizontalGridPen; }
            set
            {
                chart.PerfChartStyle.HorizontalGridPen = value;
                this.Invalidate();
            }
        }
        public Color HorizontalGridPenColor
        {
            get { return HorizontalGridPen.Color; }
            set { HorizontalGridPen.Color = value; }
        }
        public System.Drawing.Drawing2D.DashStyle HorizontalGridPenDashStyle
        {
            get { return HorizontalGridPen.DashStyle; }
            set { HorizontalGridPen.DashStyle = value; }
        }
        public float HorizontalGridPenWidth
        {
            get { return HorizontalGridPen.Width; }
            set { HorizontalGridPen.Width = value; }
        }

        [Browsable(false)]
        public SpPerfChart.ChartPen ChartLinePen
        {
            get { return chart.PerfChartStyle.ChartLinePen; }
            set
            {
                chart.PerfChartStyle.ChartLinePen = value;
                this.Invalidate();
            }
        }
        public Color ChartLinePenColor
        {
            get { return ChartLinePen.Color; }
            set { ChartLinePen.Color = value; }
        }
        public System.Drawing.Drawing2D.DashStyle ChartLinePenDashStyle
        {
            get { return ChartLinePen.DashStyle; }
            set { ChartLinePen.DashStyle = value; }
        }
        public float ChartLinePenWidth
        {
            get { return ChartLinePen.Width; }
            set { ChartLinePen.Width = value; }
        }

        public void Clear()
        {
            this.chart.Clear();
            this.progressBar_Vertical.Value = 0;
            this.label_Percent.Text = "0%";
            this.Invalidate();
        }

        private Size calculateTextHeight(string value, Font font)
        {
            float height = 0;
            int width = font.Height;
            float UpperCaseSize = 11; // for TimeNewsRoman 10pt Font's
            float LowerCaseSize = 10; // for TimeNewsRoman 10pt Font's

            UpperCaseSize = font.Size;
            LowerCaseSize = font.SizeInPoints;

            foreach (char ch in value.ToCharArray())
            {
                height += (Char.IsUpper(ch)) ? UpperCaseSize : LowerCaseSize;
            }

            return new Size(width, (int)height);
        }

        private void PerformanceCounterChart_SizeChanged(object sender, EventArgs e)
        {
            Point procLoc = progressBar_Vertical.Location;
            int Height = this.Height;
            int Width = this.Width;
            int X = Width - 23;
            int h = ((Height / 2) - (label_Vertical.Size.Height / 2));
            int Y = procLoc.Y + ((h < 0) ? 0 : h);
            label_Vertical.Location = new Point(X, Y);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            label_Percent.ForeColor = Color.Black;
        }
    }
}

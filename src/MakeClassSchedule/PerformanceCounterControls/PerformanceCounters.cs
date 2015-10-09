using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;

namespace PerformanceCounterControls
{
    public partial class PerformanceCounters : UserControl
    {
        #region CPU and MEMORY Codes
        Label[] lblCore;
        Label[] lblPercent;
        internal ProgressBar[] prbCore;
        ManagementObject mObject;
        // Represent windows NT performance counter component for cpu 
        private static PerformanceCounter cpuCounter;
        MemoryStatus stat = new MemoryStatus();
        object Locker = new object(); // For Lock
        Dictionary<string, CounterSample> cs = new Dictionary<string, CounterSample>();
        string[] instances;

        public PerformanceCounters()
        {
            InitializeComponent();
            mObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
            mObject.Get();
            cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time");
            performanceCounterChart.MarqueeAnimationSpeed = 1;
            Style = ProgressBarStyle.Blocks;
            ScaleMode = SpPerfChart.ScaleMode.Absolute;
        }

        private static Double Calculate(CounterSample oldSample, CounterSample newSample)
        {
            double difference = newSample.RawValue - oldSample.RawValue;
            double timeInterval = newSample.TimeStamp100nSec - oldSample.TimeStamp100nSec;
            if (timeInterval != 0) return 100 * (1 - (difference / timeInterval));
            return 0;
        }

        private void buildCoreObjects(int NumberOfCore)
        {
            for (int core = 0; core < NumberOfCore; core++)
            {
                lblCore[core] = lblCore_Specification(new Point(3, 15 + (26 * core)), core + 1);
                subPanel.Controls.Add(lblCore[core]);

                lblPercent[core] = lblPercent_Specification(new Point(333, 15 + (26 * core)));
                subPanel.Controls.Add(lblPercent[core]);

                prbCore[core] = prbCore_Specification(new Point(57, 13 + (26 * core)));
                subPanel.Controls.Add(prbCore[core]);
            }
        }

        private Label lblCore_Specification(Point location, int No)
        {
            Label lbl_core = new Label();
            // 
            // lblCore
            // 
            lbl_core.AutoSize = true;
            lbl_core.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl_core.Location = location;
            lbl_core.Size = new System.Drawing.Size(48, 15);
            lbl_core.TabIndex = 0;
            lbl_core.Text = string.Format("Core{0}: ", No);
            // 
            return lbl_core;
        }

        private Label lblPercent_Specification(Point location)
        {
            Label lbl_percent = new Label();
            // 
            // lblPercent
            // 
            lbl_percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lbl_percent.AutoSize = true;
            lbl_percent.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            lbl_percent.Location = location;
            lbl_percent.Size = new System.Drawing.Size(29, 15);
            lbl_percent.TabIndex = 0;
            lbl_percent.Text = "0%";
            // 
            return lbl_percent;
        }

        private ProgressBar prbCore_Specification(Point location)
        {
            ProgressBar prb_Core = new ProgressBar();
            // 
            // progressBar Core
            // 
            prb_Core.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            prb_Core.Location = location;
            prb_Core.MarqueeAnimationSpeed = MarqueeAnimationSpeed;
            prb_Core.Size = new System.Drawing.Size(270, 20);
            prb_Core.Style = Style;
            prb_Core.TabIndex = 0;
            // 
            return prb_Core;
        }

        private bool firstRun = false;
        private bool FirstRun
        {
            get { return firstRun; }
            set
            {
                if (!firstRun)
                {
                    firstRun = value;
                    int NumberOfCore = Environment.ProcessorCount;
                    lblCore = new Label[NumberOfCore];
                    lblPercent = new Label[NumberOfCore];
                    prbCore = new ProgressBar[NumberOfCore];
                    buildCoreObjects(NumberOfCore);
                    lblProcessorName.Text = CPU_Name();

                    instances = new string[NumberOfCore + 1];
                    for (int cpu = 0; cpu < NumberOfCore; cpu++)
                    {
                        instances[cpu] = "0," + cpu.ToString();
                        cpuCounter.InstanceName = instances[cpu];
                        cs.Add(cpuCounter.InstanceName, cpuCounter.NextSample());
                    }
                    instances[instances.Length - 1] = "_Total";
                    cpuCounter.InstanceName = instances[instances.Length - 1];
                    cs.Add(cpuCounter.InstanceName, cpuCounter.NextSample());
                }
            }
        }

        public void RefreshData()
        {
            lock (Locker)
            {
                FirstRun = true;

                #region CPU Information
                int NumberOfCore = Environment.ProcessorCount;
                string s = string.Empty;
                long percent = 0;
                for (int core = 0; core < NumberOfCore; core++)
                {
                    s = instances[core];
                    cpuCounter.InstanceName = s;
                    percent = (long)Calculate(cs[s], cpuCounter.NextSample());
                    if (percent < 0) percent = 0;
                    if (percent > 100) percent = 100;
                    prbCore[core].Value = (int)percent;
                    lblPercent[core].Text = percent.ToString() + "%";
                    cs[s] = cpuCounter.NextSample();
                }
                s = instances[instances.Length - 1];
                cpuCounter.InstanceName = s;
                percent = (uint)Calculate(cs[s], cpuCounter.NextSample());
                if (percent < 0) percent = 0;
                if (percent > 100) percent = 100;
                performanceCounterChart.Value = (int)percent;
                cs[s] = cpuCounter.NextSample();
                #endregion
                #region MEMORY Information
                GlobalMemoryStatus(out stat);
                long Total = ((long)stat.TotalPhysical / 1024 / 1024);
                long Free = ((long)stat.AvailablePhysical / 1024 / 1024);
                long Used = Total - Free;
                lblFreeNo.Text = Free.ToString() + " MB";
                lblUsedNo.Text = Used.ToString() + " MB";
                lblTotalNo.Text = Total.ToString() + " MB";
                int Mem = (int)(100 * Used / Total);
                prbMemory.Value = Mem;
                lblMemPercent.Text = Mem.ToString() + "%";
                #endregion
            }
        }

        public uint CPU_CurrentClockSpeed()
        {
            return (uint)mObject.Properties["CurrentClockSpeed"].Value;
        }

        public uint CPU_MaxClockSpeed()
        {
            return (uint)mObject.Properties["MaxClockSpeed"].Value;
        }

        private string CPU_Name()
        {
            return (string)mObject.GetPropertyValue("Name");
        }

        [DllImport("kernel32.dll")]
        public static extern void GlobalMemoryStatus(out MemoryStatus stat);
        #endregion

        #region Graphics Properties
        public bool AntiAliasing
        {
            get { return this.performanceCounterChart.AntiAliasing; }
            set
            {
                this.performanceCounterChart.AntiAliasing = value;
                this.Invalidate();
            }
        }
        public Color BackgroundColorBottom
        {
            get { return performanceCounterChart.BackgroundColorBottom; }
            set
            {
                performanceCounterChart.BackgroundColorBottom = value;
                this.Invalidate();
            }
        }
        public Color BackgroundColorTop
        {
            get { return performanceCounterChart.BackgroundColorTop; }
            set
            {
                performanceCounterChart.BackgroundColorTop = value;
                this.Invalidate();
            }
        }
        public bool ShowAverageLine
        {
            get { return this.performanceCounterChart.ShowAverageLine; }
            set
            {
                this.performanceCounterChart.ShowAverageLine = value;
                this.Invalidate();
            }
        }
        public bool ShowHorizontalGridLines
        {
            get { return this.performanceCounterChart.ShowHorizontalGridLines; }
            set
            {
                this.performanceCounterChart.ShowHorizontalGridLines = value;
                this.Invalidate();
            }
        }
        public bool ShowVerticalGridLines
        {
            get { return this.performanceCounterChart.ShowVerticalGridLines; }
            set
            {
                this.performanceCounterChart.ShowVerticalGridLines = value;
                this.Invalidate();
            }
        }
        public SpPerfChart.ScaleMode ScaleMode
        {
            get { return this.performanceCounterChart.ScaleMode; }
            set { this.performanceCounterChart.ScaleMode = value; }
        }
        public int TimerInterval
        {
            get { return this.performanceCounterChart.TimerInterval; }
            set
            {
                this.performanceCounterChart.TimerInterval = value;
                MarqueeAnimationSpeed = value / 10;
            }
        }
        public int MarqueeAnimationSpeed
        {
            get { return performanceCounterChart.MarqueeAnimationSpeed; }
            set
            {
                performanceCounterChart.MarqueeAnimationSpeed = value;
                prbMemory.MarqueeAnimationSpeed = value;
            }
        }
        public SpPerfChart.TimerMode TimerMode
        {
            get { return this.performanceCounterChart.TimerMode; }
            set { this.performanceCounterChart.TimerMode = value; }
        }
        public ProgressBarStyle Style
        {
            get { return performanceCounterChart.Style; }
            set { performanceCounterChart.Style = value; }
        }

        [Browsable(false)]
        public SpPerfChart.ChartPen AvgLinePen
        {
            get { return performanceCounterChart.AvgLinePen; }
            set { performanceCounterChart.AvgLinePen = value; }
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
            get { return performanceCounterChart.VerticalGridPen; }
            set
            {
                performanceCounterChart.VerticalGridPen = value;
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
            get { return performanceCounterChart.HorizontalGridPen; }
            set
            {
                performanceCounterChart.HorizontalGridPen = value;
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
            get { return performanceCounterChart.ChartLinePen; }
            set { performanceCounterChart.ChartLinePen = value; }
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
            this.performanceCounterChart.Clear();
            this.prbMemory.Value = 0;
            foreach(Control anyC in subPanel.Controls)
            {
                subPanel.Controls.Remove(anyC);
            }
            for (int i = 0; i < prbCore.Length; i++)
            {
                prbCore[i].Dispose();
                lblCore[i].Dispose();
                lblPercent[i].Dispose();
            }
            prbCore = null;
            lblPercent = null;
            lblCore = null;
            this.Invalidate();
        }
        #endregion
    }

    public struct MemoryStatus
    {
        public uint Length;
        public uint MemoryLoad;
        public uint TotalPhysical;
        public uint AvailablePhysical;
        public uint TotalPageFile;
        public uint AvailablePageFile;
        public uint TotalVirtual;
        public uint AvailableVirtual;
    }
}

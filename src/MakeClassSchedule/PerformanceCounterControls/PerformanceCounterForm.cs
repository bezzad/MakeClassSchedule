using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PerformanceCounterControls;

namespace MakeClassSchedule.PerformanceCounterControls
{
    public partial class PerformanceCounterForm : Form
    {
        public CheckBox chClosed;

        public PerformanceCounterForm()
        {
            InitializeComponent();
        }

        private void PerformanceCounterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            chClosed.Checked = false;
        }

        private void PerformanceCounterForm_Load(object sender, EventArgs e)
        {
            this.Size = this.MaximumSize =
                new System.Drawing.Size(this.Size.Width,
                    ((PC_ActivityMonitor.prbCore[PC_ActivityMonitor.prbCore.Length - 1].Location.Y + 395) > this.MinimumSize.Height) ?
                    (PC_ActivityMonitor.prbCore[PC_ActivityMonitor.prbCore.Length - 1].Location.Y + 395) : this.MinimumSize.Height);
        }
    }
}

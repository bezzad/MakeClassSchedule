using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpannedDataGridView;
using MakeClassSchedule.Algorithm;
using MakeClassSchedule;
using System.Threading;
using PerformanceCounterControls;

namespace MakeClassSchedule.ResultControls
{
    public partial class ResultForm : Form
    {
        public static CreateDataGridViews create_GridView;
        public static Algorithm.Algorithm AA;
        PerformanceCounterControls.PerformanceCounterForm PCF;
        public static ThreadState state = new ThreadState();
        public static Setting _setting = new Setting(Environment.ProcessorCount > 1);

        public ResultForm()
        {
            InitializeComponent();
        }

        private void ShowPerformanceCounter()
        {
            PCF = new MakeClassSchedule.PerformanceCounterControls.PerformanceCounterForm();
            PCF.chClosed = this.chPerformanceCounter;
            PCF.PC_ActivityMonitor.RefreshData();
            this.chPerformanceCounter.Checked = true;
            PCF.Show();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            Configuration.GetInstance.ParseFile(new LINQDataContext());
            btnPause.Enabled = false;
            btnStop.Enabled = false;

            if (Configuration.GetInstance.GetNumberOfRooms() > 0)
            {
                create_GridView = new CreateDataGridViews(Configuration.GetInstance.Rooms, this);
                Schedule prototype = new Schedule(5, 5, 90, 10); 
                Schedule.ScheduleObserver sso = new Schedule.ScheduleObserver();
                sso.SetWindow(create_GridView);

                AA = new MakeClassSchedule.Algorithm.Algorithm(1000, 180, 50, prototype, sso); 

                state = ThreadState.Unstarted;
                timerWorkingSet.Start();
            }
            else
            {
                MessageBox.Show("Number of rooms is less than the limit!", "Number of Rooms Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                timerWorkingSet.Stop();
                AA = null;
                Dispose();
                return;
            }

            if (Configuration.GetInstance.GetNumberOfCourseClasses() <= 0)
            {
                btnStart.Enabled = false;
            }
        }

        int StartedTick = 0;
        object TimerControler = new object();
        private void timerWorkingSet_Tick(object sender, EventArgs e)
        {
            long memByte = Environment.WorkingSet;
            long memKByte = memByte / 1024;
            int memMByte = (int)(memKByte / 1024);

            lblWorkingSet.Text =
                string.Format("Amount of physical memory mapped to the process context:  ({0} Byte)   ({1} KB)   ({2} MB)",
                              memByte.ToString(), memKByte.ToString(), memMByte.ToString());

            lblGeneration.Text = "Generation: " + Algorithm.Algorithm.GetInstance().GetCurrentGeneration().ToString();

            if (state == ThreadState.Running || state == ThreadState.WaitSleepJoin || state == ThreadState.Suspended)
            {
                int timeLenght = (Environment.TickCount - StartedTick) / 1000; // Convert to Second

                string S = (timeLenght % 60).ToString();
                string M = ((timeLenght / 60) % 60).ToString();
                string H = (timeLenght / 3600).ToString();
                S = (S.Length > 1) ? S : S.Insert(0, "0");
                M = (M.Length > 1) ? M : M.Insert(0, "0");
                H = (H.Length > 1) ? H : H.Insert(0, "0");
                this.Text = string.Format("Result             Working Time ({0}:{1}:{2})", H, M, S);
            }

            Monitor.Enter(TimerControler);
            if (PCF != null)
                if (!PCF.IsDisposed)
                    PCF.PC_ActivityMonitor.RefreshData();
            Monitor.Exit(TimerControler);

            //
            // check end of solving
            //
            if (Algorithm.Algorithm._state == AlgorithmState.AS_CRITERIA_STOPPED)
            {
                btnStop_Click(sender, e);
                Algorithm.Algorithm._state = AlgorithmState.AS_USER_STOPPED;
                MessageBox.Show("This Program could successfully solve the problem.", "Finishing the GA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); 
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (state == ThreadState.Unstarted || state == ThreadState.Stopped)
            {
                new LINQDataContext().Classroom_TimeDeleteAll();
                if (Algorithm.Algorithm.GetInstance().Start())
                {
                    btnPause.Enabled = true;
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                    btnPause.Text = "&Pause";
                    state = ThreadState.Running;
                    StartedTick = Environment.TickCount;
                }
            }
            else if (state == ThreadState.Suspended)
            {
                if (Algorithm.Algorithm.GetInstance().Resume())
                {
                    btnPause.Enabled = true;
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                    btnStart.Text = "&Start";
                    btnPause.Text = "&Pause";
                    state = ThreadState.Running;
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (state == ThreadState.Running) // Press Pause Button's
            {
                if (Algorithm.Algorithm.GetInstance().Pause())
                {
                    state = ThreadState.Suspended;
                    btnStart.Enabled = true;
                    btnPause.Enabled = false;
                    btnPause.Text = "&Pause";
                    btnStop.Enabled = true;
                    btnStart.Text = "&Resume";
                    if (ResultForm._setting.AutoSave_OnStopped)
                    {
                        Save(Algorithm.Algorithm.GetInstance().GetBestChromosome());
                    }
                }
            }
            else if (state == ThreadState.Stopped || state == ThreadState.Aborted) // Press Sava Button's
            {
                Save(Algorithm.Algorithm.GetInstance().GetBestChromosome());
                btnStart.Enabled = true;
                btnPause.Enabled = false;
                btnPause.Text = "&Pause";
                btnStop.Enabled = false;
            }
            this.Cursor = Cursors.Default;
        }

        private void Save(Schedule schedule)
        {
            int numberOfRooms = Configuration.GetInstance.GetNumberOfRooms();
            int daySize = schedule.day_Hours * numberOfRooms;
            var db = new LINQDataContext();
            db.Classroom_TimeDeleteAll();
            foreach (KeyValuePair<CourseClass, int> it in schedule.GetClasses().ToList())
            {
                // coordinate of time-space slot
                int pos = it.Value; // int pos of _slot array
                int day = pos / daySize;
                int time = pos % daySize; // this is not time now!
                int room = time / schedule.day_Hours;
                time = time % schedule.day_Hours;  // this is a time now!
                int dur = it.Key.GetDuration;

                CourseClass cc = it.Key;
                Algorithm.Room r = Configuration.GetInstance.GetRoomById(room);
                //
                // Save Classroom_Time
                //
                
                db.Classroom_TimeSave(r.Origin_ID_inDB, cc.Class_ID, cc.GetProfessor.GetId, time, dur, day);
                //
                // Save New_GroupsPerClassroom
                //
                foreach (var gs in cc.GetGroups)
                {
                    db.New_GroupsPerClassSave(r.Origin_ID_inDB, cc.Class_ID, time, day, gs.GetId);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnStart.Text = "&Start";
            btnPause.Text = "S&ave";
            btnPause.Enabled = true;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            if (state == ThreadState.Running)
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Stop();
                StartedTick = 0;
            }
            else if (state == ThreadState.Suspended)
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Resume();
                Algorithm.Algorithm.GetInstance().Stop();
            }
            if (ResultForm._setting.AutoSave_OnStopped)
            {
                Save(Algorithm.Algorithm.GetInstance().GetBestChromosome());
            }
            this.Cursor = Cursors.Default;
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (state == ThreadState.Running)
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Stop();
                StartedTick = 0;
            }
            else if (state == ThreadState.Suspended)
            {
                state = ThreadState.Stopped;
                Algorithm.Algorithm.GetInstance().Resume();
                Algorithm.Algorithm.GetInstance().Stop();
            }
        }

        private void chPerformanceCounter_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (chPerformanceCounter.Checked)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    if (MessageBox.Show("Your system is 64Bit Operating System. \n\rSo this application is 32Bit and dose not work safely on your system." +
                         "\n\rDo you want to open Activity Monitor for this system ?", "64Bit System Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                          MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly) == System.Windows.Forms.DialogResult.Yes)
                    {
                        _setting.Show_ActivityMonitor = true;
                        PCF = new MakeClassSchedule.PerformanceCounterControls.PerformanceCounterForm();
                        PCF.chClosed = this.chPerformanceCounter;
                        PCF.PC_ActivityMonitor.RefreshData();
                        this.chPerformanceCounter.Checked = true;
                        PCF.Show();
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        chPerformanceCounter.Checked = false;
                        return;
                    }
                }
                else
                {
                    _setting.Show_ActivityMonitor = true;
                    PCF = new MakeClassSchedule.PerformanceCounterControls.PerformanceCounterForm();
                    PCF.chClosed = this.chPerformanceCounter;
                    PCF.PC_ActivityMonitor.RefreshData();
                    this.chPerformanceCounter.Checked = true;
                    PCF.Show();
                }
            }
            else if (PCF != null) 
            {
                PCF.Dispose();
                _setting.Show_ActivityMonitor = false;
            }
            this.Cursor = Cursors.Default;
        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PCF != null)
                if (!PCF.IsDisposed)
                    PCF.Dispose();

            if(Algorithm.Algorithm.GetInstance().MultiThreads != null)
            {
                if (Algorithm.Algorithm.GetInstance().MultiThreads.Length > 0)
                {
                    for (int th = 0; th < Algorithm.Algorithm.GetInstance().MultiThreads.Length; th++)
                    {
                        if (Algorithm.Algorithm.GetInstance().MultiThreads[th].IsAlive)
                            Algorithm.Algorithm.GetInstance().MultiThreads[th].Abort();
                    }
                }
                Algorithm.Algorithm.GetInstance().MultiThreads = null;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //
            //-------------------------------------------------------------
            if (btnPause.Enabled && state == ThreadState.Running)
            {
                btnPause_Click(sender, e);
                ResultControls.ResultSettingForm RSF = new ResultControls.ResultSettingForm();
                RSF.ResultFormControler = this;
                RSF.ShowDialog();
                chPerformanceCounter.Checked = _setting.Show_ActivityMonitor;
                btnStart_Click(sender, e);
            }
            else
            {
                ResultControls.ResultSettingForm RSF = new ResultControls.ResultSettingForm();
                RSF.ResultFormControler = this;
                RSF.ShowDialog();
                chPerformanceCounter.Checked = _setting.Show_ActivityMonitor;
            }
            //-------------------------------------------------------------
            //
            this.Cursor = Cursors.Default;
        }
    }

    public struct Setting
    {
        public Setting(bool Parallel)
        {
            Display_RealTime = true;
            Parallel_Process = Parallel; // (Environment.ProcessorCount > 1);
            AutoSave_OnStopped = true;
            Show_ActivityMonitor = false;
            Fragmental_Classes = false;
        }

        public bool Display_RealTime;
        public bool Parallel_Process;
        public bool AutoSave_OnStopped;
        public bool Show_ActivityMonitor;
        public bool Fragmental_Classes;
    };
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MakeClassSchedule.ResultControls
{
    public partial class ResultSettingForm : Form
    {
        private LINQDataContext DB = new LINQDataContext();
        public Form ResultFormControler;

        public ResultSettingForm()
        {
            InitializeComponent();
        }

        private void ResultSettingForm_Load(object sender, EventArgs e)
        {
            // Started or paused
            if (ResultForm.state != System.Threading.ThreadState.Unstarted && 
                ResultForm.state != System.Threading.ThreadState.Stopped)
            {
                btnChangeRoomsData.Enabled = false;
                btnClassroomsSchedule.Enabled = false;
                btnGroupsSchedule.Enabled = false;
                btnProfessorsSchedule.Enabled = false;
                chkParallelProcessing.Enabled = false;
                chkFragmental.Enabled = false;
                btnGAS.Enabled = false;
            }
            else // unStarted or Stopped
            {
                //this.Controls.OfType<object>().AsParallel().ForAll(obj=>
                //    {
                //        ((Control)obj).Enabled = true;
                //    });
                foreach (Control c in this.Controls)
                {
                    c.Enabled = true;
                }
            }
            //
            //
            chkRealTimeDisplay.Checked = ResultForm._setting.Display_RealTime;
            chkSaveStoped.Checked = ResultForm._setting.AutoSave_OnStopped;
            chkParallelProcessing.Checked = ResultForm._setting.Parallel_Process;
            chkActivityMonitor.Checked = ResultForm._setting.Show_ActivityMonitor;
            chkFragmental.Checked = ResultForm._setting.Fragmental_Classes;
        }

        private void btnChangeRoomsData_Click(object sender, EventArgs e)
        {
            if (checkRoomData_ExistOn_PLINQ())
            {
                ChangeRoomsDataForm CRDF = new ChangeRoomsDataForm();
                ResultFormControler.Hide();
                this.Hide();
                CRDF.ShowDialog();
                this.Show();
                ResultFormControler.Show();
            }
        }

        private bool checkRoomData_ExistOn_PLINQ()
        {
            var EmptyDB = (from X in DB.Classroom_Times.AsParallel().WithDegreeOfParallelism(Algorithm.Algorithm.GetInstance().numCore)
                           select X).ToArray();
            if (EmptyDB.Length > 0) return true;
            return false;
        }

        private void btnClassroomsSchedule_Click(object sender, EventArgs e)
        {
            if (checkRoomData_ExistOn_PLINQ())
            {
                ShowClassroomsScheduleForm SCSF = new ShowClassroomsScheduleForm();
                ResultFormControler.Hide();
                this.Hide();
                SCSF.ShowDialog();
                this.Show();
                ResultFormControler.Show();
            }
        }

        private void btnGroupsSchedule_Click(object sender, EventArgs e)
        {
            if (checkRoomData_ExistOn_PLINQ())
            {
                ShowGroupsScheduleForm SGSF = new ShowGroupsScheduleForm();
                ResultFormControler.Hide();
                this.Hide();
                SGSF.ShowDialog();
                this.Show();
                ResultFormControler.Show();
            }
        }

        private void btnProfessorsSchedule_Click(object sender, EventArgs e)
        {
            if (checkRoomData_ExistOn_PLINQ())
            {
                ShowProfessorsScheduleForm SPSF = new ShowProfessorsScheduleForm();
                ResultFormControler.Hide();
                this.Hide();
                SPSF.ShowDialog();
                this.Show();
                ResultFormControler.Show();
            }
        }

        private void chkRealTimeDisplay_CheckedChanged(object sender, EventArgs e)
        {
            ResultForm._setting.Display_RealTime = chkRealTimeDisplay.Checked;
        }

        private void chkParallelProcessing_CheckedChanged(object sender, EventArgs e)
        {
            ResultForm._setting.Parallel_Process = chkParallelProcessing.Checked;
        }

        private void chkSaveStoped_CheckedChanged(object sender, EventArgs e)
        {
            ResultForm._setting.AutoSave_OnStopped = chkSaveStoped.Checked;
        }

        private void chkActivityMonitor_CheckedChanged(object sender, EventArgs e)
        {
            ResultForm._setting.Show_ActivityMonitor = chkActivityMonitor.Checked;
        }

        private void chkFragmental_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ResultForm._setting.Fragmental_Classes = chkFragmental.Checked;
                if (ResultForm._setting.Fragmental_Classes)
                {
                    #region Fragment the Class more than two units
                    var dbClasses = DB.Classes.ToList();
                    //
                    /// A list for store any class by unit more than 2.
                    ///  Tuple< Classes, Unit >
                    List<Tuple<Class, int>> lstFragmentClass = new List<Tuple<Class, int>>();
                    //
                    // Delete old classroom, because it has this class information!
                    new LINQDataContext().Classroom_TimeDeleteAll();
                    //
                    // Search for any class by unit more than 2.
                    foreach (var any in dbClasses)
                    {
                        if (any.Practical_unit + any.Theory_unit > 2)
                        {
                            lstFragmentClass.Add(new Tuple<Class, int>(any, any.Practical_unit + any.Theory_unit));
                        }
                    }
                    //
                    // Read any Finded Class and Fragment that to 2 Unit Quantums.
                    foreach (var anyClass in lstFragmentClass)
                    {
                        int u = 0;
                        do
                        {
                            int id = findNewClassID(); // create a new class ID
                            //
                            // delete old and hyper data
                            DB.Group_ID_ListDeleteClass(id);
                            DB.Priority_ProfessorDeleteClass(id);
                            //
                            Class c = new Class() // create new Classes
                            {
                                Class_ID = id,
                                Course_ID = anyClass.Item1.Course_ID,
                                RoomType = anyClass.Item1.RoomType,
                                Practical_unit = 0,
                                Theory_unit = ((anyClass.Item2 - u) >= 2) ? 2 : 1
                            };
                            //
                            // create new Group_ID_List for this new Class
                            List<Group_ID_List> g = new List<Group_ID_List>();
                            g.AddRange(anyClass.Item1.Group_ID_Lists);
                            for (int i = 0; i < g.Count; i++)
                            {
                                g[i].Class_ID = id;
                            }
                            //
                            // create new Priority_Professor for this new Class
                            List<Priority_Professor> p = new List<Priority_Professor>();
                            p.AddRange(anyClass.Item1.Priority_Professors);
                            for (int i = 0; i < p.Count; i++)
                            {
                                p[i].Class_ID = id;
                            }
                            //
                            // add new data to DB
                            DB.ClassSave(c.Class_ID, c.Course_ID, c.Practical_unit, c.Theory_unit, c.RoomType);
                            foreach (var anyG in g)
                                DB.Group_ID_ListSave(anyG.Group_ID, anyG.Class_ID);
                            foreach (var anyP in p)
                                DB.Priority_ProfessorSave(anyP.Professor_ID, anyP.Class_ID, anyP.Priority);
                            //DB.Classes.InsertOnSubmit(c);
                            //DB.SubmitChanges();
                            //DB.Group_ID_Lists.InsertAllOnSubmit(g);
                            //DB.Priority_Professors.InsertAllOnSubmit(p);
                            //DB.SubmitChanges();
                            u += 2;
                        }
                        while (anyClass.Item2 - u > 0);

                        //
                        // delete old class data (original class who has more than 2 units)
                        DB.Group_ID_ListDeleteClass(anyClass.Item1.Class_ID);
                        DB.Priority_ProfessorDeleteClass(anyClass.Item1.Class_ID);
                        DB.ClassDelete(anyClass.Item1.Class_ID);
                    }
                    #endregion

                    MakeClassSchedule.Algorithm.Configuration.GetInstance.ParseFile(new LINQDataContext());
                    chkFragmental.Enabled = false;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Search all class id for find a unUsed iD
        /// </summary>
        /// <returns>UnUsed ID</returns>
        private int findNewClassID()
        {
            int id = 1;
            while(true)
            {
                bool finded = false;
                foreach (var any in DB.Classes)
                {
                    if (any.Class_ID == id)
                    {
                        id++;
                        finded = true;
                        break;
                    }
                }
                if (finded)
                    continue;
                else
                    return id;
            }
        }

        private void btnGAS_Click(object sender, EventArgs e)
        {
            GeneticAlgorithmSettingForm GASF = new GeneticAlgorithmSettingForm();
            GASF.ShowDialog();
        }       
    }
}

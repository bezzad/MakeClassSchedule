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
    public partial class OneFieldOfRoomForm : Form
    {
        public DataGridViewCell CurrentCell;
        int _roomKey, _classId, _startTime, _dayNo;
        LINQDataContext db = new LINQDataContext();
        Classroom_Time cr;
        Dictionary<int, Professor> Prof = new Dictionary<int, Professor>();
        System.Windows.Forms.RightToLeft _RightToLeft = RightToLeft.No;
        Dictionary<int, Group> dicGroups = new Dictionary<int, Group>();

        public OneFieldOfRoomForm(int RoomKey, int ClassId, int StartTime, int DayNo)
        {
            InitializeComponent();
            _roomKey = RoomKey;
            _classId = ClassId;
            _startTime = StartTime;
            _dayNo = DayNo;
            _RightToLeft = System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ?
                System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
        }

        private void OneFieldOfRoomForm_Load(object sender, EventArgs e)
        {
            cr = (from c in db.Classroom_Times
                  where ((c.Class_ID == _classId) && (c.Room_ID == _roomKey) && (c.StartTime == _startTime) && (c.Day_No == _dayNo))
                  select c).SingleOrDefault();

            txtProfessor.RightToLeft = _RightToLeft;
            txtProfessor.Text = cr.Professor.Name_Professor;
            chkListProfessor.RightToLeft = _RightToLeft;

            var ng = (from g in db.New_GroupsPerClasses
                      where ((g.Class_ID == _classId) && (g.Room_ID == _roomKey) && (g.StartTime == _startTime) && (g.Day_No == _dayNo))
                      select g.Group_ID).ToList();

            var gs = (from g in db.Groups
                      select g).ToList();

            chkGroups.RightToLeft = _RightToLeft;
            int IndexOfList = 0;
            foreach (var g in gs)
            {
                chkGroups.Items.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} - {1}   {2}-{3}",
                    g.Branch.Branch_Name, g.Branch.Degree, g.Semester_Entry_Year, ((g.Semester_Entry_FS) ? "1" : "2")), ng.Contains(g.ID));
                dicGroups.Add(IndexOfList++, g);
            }
            txtInfo.RightToLeft = _RightToLeft;
            txtInfo.Text = CurrentCell.Value.ToString();
            //
            // Find any professor for this time slot's
            //
            chkListProfessor.Items.Clear();
            int pI = 0;
            foreach (var p in db.Professors)
            {
                ProfessorInfoCompiler PIC = new ProfessorInfoCompiler();
                if (PIC.StartScanner(p.Schedule)) 
                {
                    if (PIC.CompiledData[_startTime, _dayNo + 1])
                    {
                        Prof.Add(pI++, p);
                        chkListProfessor.Items.Add(p.Name_Professor, (cr.Professor.ID == p.ID));
                    }
                }
            }
            //
        }

        private void RefreshCHK()
        {
            string groups_Name = "";
            for(int i=0;i< chkGroups.Items.Count;i++)
            {
                if (chkGroups.GetItemChecked(i))
                {
                    var g = dicGroups[i];
                    groups_Name += string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}  {1}  {2}-{3}\r\n",
                              g.Branch.Degree, g.Branch.Branch_Name, g.Semester_Entry_Year, (g.Semester_Entry_FS ? "1" : "2"));
                }
            }
            groups_Name = groups_Name.Trim();

            txtInfo.Text = string.Empty;
            txtInfo.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture,"{0}\r\n{1}\r\n{2}\r\n{3}", 
                cr.Class.Course.Name_Course, cr.Professor.Name_Professor, groups_Name, cr.Room.Type_Room);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.Classroom_TimeEdit(_roomKey, cr.Room_ID, _classId, cr.Class_ID, cr.Professor_ID, _startTime,
                cr.StartTime, cr.Duration, _dayNo, cr.Day_No);
            //
            CurrentCell.Value = txtInfo.Text;
            //
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCHK();
        }

        Dictionary<int, Professor> dicProfessor = new Dictionary<int, Professor>();
        private void btnProfessor_Click(object sender, EventArgs e)
        {
            chkListProfessor.Visible = true;
            chkListProfessor.BringToFront();
            btnCancelProfessor.Visible = true;
            btnCancelProfessor.BringToFront();
            btnSaveProfessor.Visible = true;
            btnSaveProfessor.BringToFront();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        private void chkGroups_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshCHK();
        }

        private void chkGroups_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshCHK();
        }

        private void chkListProfessor_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                foreach (int anyChecked in ((CheckedListBox)sender).CheckedIndices)
                    ((CheckedListBox)sender).SetItemChecked(anyChecked, false);
            else
            {
                if (((CheckedListBox)sender).CheckedItems.Count < 1) // one checked items is exist and it is self of item
                {
                    e.NewValue = CheckState.Checked;
                }
            }            
        }

        private void btnSaveProfessor_Click(object sender, EventArgs e)
        {
            if (chkListProfessor.CheckedItems.Count > 0)
            {
                cr.Professor = Prof[chkListProfessor.CheckedIndices[0]];
                txtProfessor.Text = chkListProfessor.CheckedItems[0].ToString();
                RefreshCHK();
            }
            btnCancelProfessor_Click(sender, e);
        }

        private void btnCancelProfessor_Click(object sender, EventArgs e)
        {
            chkListProfessor.Visible = false;
            btnCancelProfessor.Visible = false;
            btnSaveProfessor.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }
    }
}

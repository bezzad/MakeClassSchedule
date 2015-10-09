using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Globalization;

namespace MakeClassSchedule
{
    public partial class ClassForm : Form
    {
        public ClassForm()
        {
            InitializeComponent();
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            dgvClass.RowsAdded -= new DataGridViewRowsAddedEventHandler(dgvClass_RowsAdded);
            PersianCalendar pc = new PersianCalendar();
            txtCurrentTerm.Text = pc.GetYear(DateTime.Today).ToString();
            cmbSemesterEntry.SelectedIndex = (pc.GetMonth(DateTime.Today) > 7) ? 1 : 0;
            //
            dgvClass.Rows.Clear();
            var db = new LINQDataContext();
            this.colCourse.Items.AddRange((from QC in db.Courses select QC.Name_Course).ToArray());
            this.ColType.Items.AddRange((from QR in db.Room_Types select QR.Type_Name).ToArray());
            var qBName = (from QG in db.Groups
                          select new
                          {
                              GroupName =
                                          (QG.ID.ToString() + ".  " +
                                           QG.Branch.Branch_Name + "  -  " +
                                           QG.Branch.Degree + "  [" +
                                           QG.Semester_Entry_Year.ToString() + " " +
                                           ((QG.Semester_Entry_FS == true) ? "First" : "Second") + " Entry]")
                          }).ToArray();
            foreach (var anyBN in qBName)
                this.cmbGroups.Items.Add(anyBN.GroupName);
            //
            // read class data in db.Classes
            //
            var dbClass = (from c in db.Classes
                           orderby c.Class_ID
                           select new
                           {
                               c.Class_ID,
                               c.Course.Name_Course,
                               c.Practical_unit,
                               c.Theory_unit,
                               c.Course.CourseCode.Value,
                               c.RoomType
                           }).ToArray();
                           

            foreach (var row in dbClass)
            {
                //
                // Find Group_ID_List
                //
                string strGroup_ID_List = "";
                foreach (int any in (from GIL in db.Group_ID_Lists
                                     where GIL.Class_ID == row.Class_ID
                                     select GIL.Group_ID).ToArray())
                {
                    strGroup_ID_List += any.ToString() + " ";
                }
                //
                // Find Professor_ID_List And it's Priority 
                //
                var dbPriority = from p in db.Priority_Professors
                                 where p.Class_ID == row.Class_ID
                                 select p;
                
                string strProfessor_Priority = "";
                foreach (var anyPriority in dbPriority.ToArray())
                {
                    strProfessor_Priority += 
                        anyPriority.Professor_ID.ToString() + "(" 
                        + anyPriority.Priority.ToString() + ")  ";
                }
                dgvClass.Rows.Add(new object[] 
                                     {
                                         row.Class_ID,
                                         "+ Professor",
                                         strProfessor_Priority,
                                         row.Name_Course,
                                         row.Value,
                                         row.Practical_unit, 
                                         row.Theory_unit,
                                         row.RoomType, 
                                         "+ Group",
                                         strGroup_ID_List
                                     });
            }
            dgvClass.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvClass_RowsAdded);
        }

        private void dgvClass_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int ID_Counter = 1;
                bool Find = true;
                while (Find)
                {
                    Find = false;
                    for (int rowC = 0; rowC < dgvClass.RowCount - 2; rowC++)
                    {
                        if (dgvClass[0, rowC].Value != null)
                        {
                            if (int.Parse(dgvClass[0, rowC].Value.ToString()) == ID_Counter)
                            {
                                ID_Counter++;
                                Find = true;
                                break;
                            }
                        }
                        else continue;
                    }
                }
                dgvClass.Rows[e.RowIndex - 1].Cells[0].Value = ID_Counter;
            }
        }

        private void ClassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvClass[0, 0].Selected = true;
            // ----------------------------------------------------------------------------------------------
            //
            var db = new LINQDataContext();
            //
            // Delete Group_ID_List Where Class_ID == this.ID
            //
            db.Group_ID_ListDeleteAll();
            db.Priority_ProfessorDelete();
            for (int rowCounter = 0; rowCounter < dgvClass.RowCount - 1; rowCounter++)
            {
                try
                {
                    //
                    // search dgvClass.rows in db.Class
                    //
                    int id_class = int.Parse(dgvClass[0, rowCounter].Value.ToString());

                    var query = (from QC in db.Classes
                                 where QC.Class_ID == id_class
                                 select QC).SingleOrDefault();
                    if (dgvClass[2, rowCounter].Value.ToString() == "")
                    {
                        new LINQDataContext().ClassDelete(int.Parse(dgvClass[0, rowCounter].Value.ToString()));
                        throw new Exception("Null Professor Value's");
                    }
                    if (query != null) // edit (UPDATE)
                    {
                        int PU = 0;
                        int TU = 0;
                        decimal code = 0;
                        db.ClassEdit(id_class, (dgvClass[3, rowCounter].Value != null) ?
                                               (from courseID in db.Courses
                                                where (courseID.Name_Course == dgvClass[3, rowCounter].Value.ToString()) &&
                                                      (courseID.CourseCode == ((decimal.TryParse(dgvClass[4, rowCounter].Value.ToString(), out code)) ? code : 0))
                                                select courseID.Course_ID).Single() : 0,
                                    (int.TryParse(dgvClass[5, rowCounter].Value.ToString(), out PU)) ? PU : 0,
                                    (int.TryParse(dgvClass[6, rowCounter].Value.ToString(), out TU)) ? TU : 0,
                                     dgvClass[7, rowCounter].Value.ToString());
                    }
                    else //save (INSERT or Create NEW)
                    {
                        int PU = 0;
                        int TU = 0;
                        decimal code = 0;
                        db.ClassSave(id_class, (dgvClass[3, rowCounter].Value != null) ?
                                               (from courseID in db.Courses
                                                where (courseID.Name_Course == dgvClass[3, rowCounter].Value.ToString()) &&
                                                      (courseID.CourseCode == ((decimal.TryParse(dgvClass[4, rowCounter].Value.ToString(), out code)) ? code : 0))
                                                select courseID.Course_ID).Single() : 0,
                                    (int.TryParse(dgvClass[5, rowCounter].Value.ToString(), out PU)) ? PU : 0,
                                    (int.TryParse(dgvClass[6, rowCounter].Value.ToString(), out TU)) ? TU : 0,
                                     dgvClass[7, rowCounter].Value.ToString());
                    }
                    //
                    // Group in db.Group_ID_List
                    //
                    saveAndCompile_Groups((dgvClass[9, rowCounter].Value != null) ?
                                           dgvClass[9, rowCounter].Value.ToString() : " ",
                                          Convert.ToInt32(dgvClass[0, rowCounter].Value.ToString()));
                    //
                    // Priority in db.Priority_Professors
                    //
                    saveAndCompile_Priority((dgvClass[2, rowCounter].Value != null) ?
                                             dgvClass[2, rowCounter].Value.ToString() : " ",
                                            Convert.ToInt32(dgvClass[0, rowCounter].Value.ToString()));
                }
                catch { }
            }
        }

        private void saveAndCompile_Priority(string priority, int classId)
        {
            var db = new LINQDataContext().Priority_Professors;
            //
            // Compile the priority 
            //
            Dictionary<int, int> ProfessorKey_PriorityValue = new Dictionary<int, int>();

            string keyBuffer = "";
            string valueBuffer = "";
            bool showParantes = false;
            try
            {
                foreach (char ch in priority.ToCharArray())
                {
                    if (char.IsDigit(ch) && !showParantes) // a Key Number char
                    {
                        keyBuffer += ch.ToString();
                    }
                    else if (ch == '(') // a '(' before Value Number char
                    {
                        showParantes = true;
                    }
                    else if (char.IsDigit(ch) && showParantes) // a Value Number char
                    {
                        valueBuffer += ch.ToString();
                    }
                    else if (ch == ')')
                    {
                        showParantes = false;
                        ProfessorKey_PriorityValue.Add(int.Parse(keyBuffer), int.Parse(valueBuffer));
                        keyBuffer = string.Empty;
                        valueBuffer = string.Empty;
                    }
                    else
                        continue;
                }
                //
                // Save by classId
                //
                foreach (var anyPP in ProfessorKey_PriorityValue)
                    new LINQDataContext().Priority_ProfessorSave(anyPP.Key, classId, anyPP.Value);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void saveAndCompile_Groups(string strGroups, int classId)
        {
            var db = new LINQDataContext();
            //
            // compile strGroups for Parsing group id
            //
            char[] spell = strGroups.ToCharArray();
            string strBuffer = "";
            for (int indexC = 0; indexC < spell.Length; indexC++)
            {
                if (char.IsWhiteSpace(spell[indexC]))
                {
                    if (strBuffer != "")
                    {
                        int intBuffer = int.Parse(strBuffer);
                        db.Group_ID_ListSave(intBuffer, classId);
                        strBuffer = "";
                    }
                }
                else if (char.IsDigit(spell[indexC]))
                {
                    strBuffer += spell[indexC].ToString();
                }
                else
                {
                    //error
                    if (strBuffer != "")
                    {
                        int intBuffer = int.Parse(strBuffer);
                        db.Group_ID_ListSave(intBuffer, classId);
                        strBuffer = "";
                    }
                }
            }
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Groups Button
                if (e.ColumnIndex == 8 && e.RowIndex >= 0 && e.RowIndex < dgvClass.RowCount - 1)
                {
                    AddGroupsForm agForm = new AddGroupsForm();
                    agForm.Text = "Add Groups To Class";
                    agForm.Interface_TextBox = (DataGridViewTextBoxCell)dgvClass[9, e.RowIndex];
                    agForm.ShowDialog();
                }
                #endregion              

                #region Professor Button
                if (e.ColumnIndex == 1 && e.RowIndex >= 0 && e.RowIndex < dgvClass.RowCount - 1)
                {
                    AddProfessorsForm apForm = new AddProfessorsForm(int.Parse(dgvClass[0, e.RowIndex].Value.ToString()));
                    apForm.Text = "Add Professors To Class";
                    apForm.Location = new Point((this.Location.X + dgvClass.Columns[0].Width + 25),
                                                (this.Location.Y + 100));
                    apForm.Interface_TextBox = (DataGridViewTextBoxCell)dgvClass[2, e.RowIndex];
                    apForm.ShowDialog();
                }
                #endregion
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCurrentTerm.Text != "" && cmbSemesterEntry.Text != "")
            {
                int ThisYear = int.Parse(txtCurrentTerm.Text);
                bool ThisSemesterEntry = (cmbSemesterEntry.SelectedIndex == 0) ? true : false;
                Dictionary<int, int> GroupsTerm = new Dictionary<int, int>(); // <Key, Value> = <Group_ID, Term_No>
                Dictionary<int, int> GroupsBranch = new Dictionary<int,int>(); // <Key, Value> = <Group_ID, Branch_ID>
                foreach(var anyGroup in new LINQDataContext().Groups.ToArray())
                {
                    int TermNO = (((2 * ThisYear) + ((ThisSemesterEntry) ? 0 : 1))
                               - ((2 * anyGroup.Semester_Entry_Year) + ((anyGroup.Semester_Entry_FS) ? 0 : 1))) + 1;
                    GroupsTerm.Add(anyGroup.ID, TermNO);
                    GroupsBranch.Add(anyGroup.ID, anyGroup.Branch_Selection.Value);
                }
                //
                // disable RowsAdded Handler for add some rows
                //
                dgvClass.RowsAdded -= new DataGridViewRowsAddedEventHandler(dgvClass_RowsAdded);
                //
                // set data for DataGridView Class
                //
                foreach (var anyGroup in GroupsBranch)
                {
                    var results = (from qCourse in new LINQDataContext().Courses
                                   where (qCourse.Branch_ID == anyGroup.Value) && 
                                         (qCourse.TermNo == GroupsTerm[anyGroup.Key]) &&
                                         (qCourse.TermNo > 0)
                                   select new
                                   {
                                       qCourse.Name_Course,
                                       qCourse.CourseCode,
                                       qCourse.PracticalUnitNo,
                                       qCourse.TheoryUnitNo
                                   }).ToArray();
                    int startIndex = dgvClass.RowCount - 1;
                    if (results.Length > 0)
                    {
                        dgvClass.Rows.Add(results.Length);
                        foreach (var row in results)
                        {
                            //
                            // Create Class ID in RowAdded
                            //
                            int ID_Counter = 1;
                            if (dgvClass.RowCount > 0)
                            {
                                bool Find = true;
                                while (Find)
                                {
                                    Find = false;
                                    for (int rowC = 0; rowC < dgvClass.RowCount - 2; rowC++)
                                    {
                                        if (dgvClass[0, rowC].Value != null)
                                        {
                                            if (int.Parse(dgvClass[0, rowC].Value.ToString()) == ID_Counter)
                                            {
                                                ID_Counter++;
                                                Find = true;
                                                break;
                                            }
                                        }
                                        else continue;
                                    }
                                }
                                //
                                // fill other data in dgvClass
                                //
                                dgvClass.Rows[startIndex].Cells[0].Value = ID_Counter;
                                dgvClass.Rows[startIndex].Cells[3].Value = row.Name_Course;
                                dgvClass.Rows[startIndex].Cells[4].Value = row.CourseCode.Value.ToString();
                                dgvClass.Rows[startIndex].Cells[5].Value = row.PracticalUnitNo.Value.ToString();
                                dgvClass.Rows[startIndex].Cells[6].Value = row.TheoryUnitNo.Value.ToString();
                                dgvClass.Rows[startIndex].Cells[9].Value = anyGroup.Key.ToString() + " ";
                                startIndex++;
                            }
                        }
                    }
                }
                //
                // Enable RowsAdded Handler for add a row
                //
                dgvClass.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvClass_RowsAdded);
            }
            else
                MessageBox.Show("Please Fill All TextBox by trust data!", "Empty Field Error");
        }

        private void dgvClass_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Course ComboBox selectedItems_Changed() for fill Unit data
            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && e.RowIndex < dgvClass.RowCount - 1)
            {
                if (dgvClass[3, e.RowIndex].Value != null)
                {
                    var query = (from PTU in new LINQDataContext().Courses
                                 where PTU.Name_Course == dgvClass[3, e.RowIndex].Value.ToString()
                                 select new
                                 {
                                     PTU.CourseCode,
                                     PTU.PracticalUnitNo,
                                     PTU.TheoryUnitNo
                                 }).ToArray();
                    dgvClass[4, e.RowIndex].Value = query[0].CourseCode.Value;
                    dgvClass[5, e.RowIndex].Value = query[0].PracticalUnitNo.Value;
                    dgvClass[6, e.RowIndex].Value = query[0].TheoryUnitNo.Value;
                }
            }
            #endregion
        }

        private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShowHide.Checked = false;
            for (int r = 0; r < dgvClass.RowCount; r++)
                dgvClass.Rows[r].Visible = true;

            if (cmbGroups.SelectedItem != null)
            {
                //
                // Compile Group ID number's
                //
                string strGroupID = "";
                foreach (char ch in cmbGroups.SelectedItem.ToString().ToCharArray())
                {
                    if (char.IsDigit(ch))
                        strGroupID += ch.ToString();
                    else if (strGroupID != "")
                        break;
                }
                int SelectedGroupID = int.Parse(strGroupID);
                //
                // Compile any Rows That has a this Selected Group ID
                //
                List<int> lstHideRow = new List<int>();
                for (int rowC = 0; rowC < dgvClass.RowCount - 1; rowC++)
                {
                    if (dgvClass[9, rowC].Value != null)
                    {
                        strGroupID = "";
                        foreach (char ch in dgvClass[9, rowC].Value.ToString().ToCharArray()) 
                        {
                            if (char.IsDigit(ch))
                                strGroupID += ch.ToString();
                            else if (strGroupID != "")
                            {
                                if (int.Parse(strGroupID) == SelectedGroupID)
                                    lstHideRow.Add(rowC);
                                strGroupID = "";
                            }
                        }
                    }
                }
                //
                // Hide any rows in lstHideRow
                //
                for (int r = 0; r < dgvClass.RowCount - 1; r++) 
                    if (!lstHideRow.Contains(r))
                        dgvClass.Rows[r].Visible = false;
            }
        }

        /// <summary>
        /// Numeric TextBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrentTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            // Numeric TextBox
            //
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        /// <summary>
        /// Set this year and current Term to Persian Calender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrentTerm_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCurrentTerm.Text == "")
            {
                PersianCalendar pc = new PersianCalendar();
                txtCurrentTerm.Text = pc.GetYear(DateTime.Today).ToString();
            }
        }

        /// <summary>
        /// Toggle Button Show / Hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (btnShowHide.Text == "&Show")
            {
                for (int r = 0; r < dgvClass.RowCount; r++)
                    dgvClass.Rows[r].Visible = true;
                btnShowHide.Text = "&Hide";
            }
            else
            {
                cmbGroups_SelectedIndexChanged(sender, e);
                btnShowHide.Text = "&Show";
            }
        }

        private void dgvClass_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Row.Cells[0].Value.ToString(), out id))
            {
                var db = new LINQDataContext();
                db.Priority_ProfessorDeleteClass(id);
                db.Classroom_TimeDeleteClass(id);
                db.Group_ID_ListDeleteClass(id);
                db.ClassDelete(id);
                db.Dispose();
            }
        }
    }
}

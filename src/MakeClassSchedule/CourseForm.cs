using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MakeClassSchedule
{
    public partial class CourseForm : Form
    {
        private int BranchID;
        private string BranchName;
        private string BranchDegree;

        public CourseForm(int Branch_ID, string Branch_Name, string Branch_Degree)
        {
            InitializeComponent();
            BranchID = Branch_ID;
            BranchName = Branch_Name;
            BranchDegree = Branch_Degree;
        }

        private void dgvCourse_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var db = new LINQDataContext();
            // query for read any course ID and creat new iD
            IEnumerable<int> qCourseID = from queryId in db.Courses
                                         select queryId.Course_ID;

            List<int> idList_in_db = qCourseID.ToList();

            if (e.RowIndex > 0)
            {
                int ID_Counter = 1;
                bool Find = true;
                while (Find)
                {
                    Find = false;
                    for (int rowC = 0; rowC < dgvCourse.RowCount - 2; rowC++)
                    {
                        if (int.Parse(dgvCourse[0, rowC].Value.ToString()) == ID_Counter)
                        {
                            ID_Counter++;
                            Find = true;
                            break;
                        }
                    }
                    if (idList_in_db.Contains(ID_Counter))
                    {
                        ID_Counter++;
                        Find = true;
                    }
                }
                dgvCourse.Rows[e.RowIndex - 1].Cells[0].Value = ID_Counter;
            }
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            this.Text = BranchName + "  -  " + BranchDegree + "  Course Data";
            dgvCourse.Rows.Clear();
            var db = new LINQDataContext();
            //
            // SQL Query for Course list by Branch ID
            //
            var qCourse = (from lstCourse in db.Courses
                           where lstCourse.Branch_ID == BranchID
                           select new
                           {
                               lstCourse.Course_ID,
                               lstCourse.TermNo,
                               lstCourse.Name_Course,
                               lstCourse.Type_Course,
                               lstCourse.CourseCode,
                               lstCourse.TheoryUnitNo,
                               lstCourse.PracticalUnitNo,
                               lstCourse.InRequisite_CourseID,
                               lstCourse.PreRequisite_CourseID
                           });
            //
            var aryQCourse = qCourse.ToArray();
            if (aryQCourse.Length > 0)
            {
                dgvCourse.Rows.Add(aryQCourse.Length);
                for (int rowCounter = 0; rowCounter < aryQCourse.Length; rowCounter++)
                {
                    dgvCourse[0, rowCounter].Value = aryQCourse[rowCounter].Course_ID;

                    dgvCourse[1, rowCounter].Value = aryQCourse[rowCounter].TermNo.Value;

                    dgvCourse[2, rowCounter].Value = aryQCourse[rowCounter].InRequisite_CourseID;

                    dgvCourse[4, rowCounter].Value = aryQCourse[rowCounter].PreRequisite_CourseID;

                    dgvCourse[6, rowCounter].Value = aryQCourse[rowCounter].TheoryUnitNo.Value;

                    dgvCourse[7, rowCounter].Value = aryQCourse[rowCounter].PracticalUnitNo.Value;

                    dgvCourse[8, rowCounter].Value = int.Parse(dgvCourse[6, rowCounter].Value.ToString()) + int.Parse(dgvCourse[7, rowCounter].Value.ToString());

                    dgvCourse[9, rowCounter].Value = aryQCourse[rowCounter].Type_Course;

                    dgvCourse[10, rowCounter].Value = (aryQCourse[rowCounter].Name_Course != null) ? aryQCourse[rowCounter].Name_Course : "";

                    dgvCourse[11, rowCounter].Value = aryQCourse[rowCounter].CourseCode.Value;
                }
            }
        }

        private void CourseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvCourse[0, 0].Selected = true;
            
            // ----------------------------------------------------------------------------------------------
            //
            var db = new LINQDataContext();

            for (int rowCounter = 0; rowCounter < dgvCourse.RowCount - 1; rowCounter++)
            {
                //
                // search dgvClass.rows in db.Class
                //
                int ID_No = 0;
                int.TryParse(dgvCourse[0, rowCounter].Value.ToString(), out ID_No);
                // Define the query expression.
                IEnumerable<int> query =
                    from course in db.Courses
                    where course.Course_ID == ID_No
                    select course.Course_ID;
                //
                try
                {
                    if (query.ToArray().Length > 0) // EDIT
                    {
                        int intBuffer = 0;
                        decimal decBuffer = 0;
                        db.CourseEdit(ID_No, BranchID, (dgvCourse[1, rowCounter].Value != null) ? int.Parse(dgvCourse[1, rowCounter].Value.ToString()) : 0,
                            (dgvCourse[10, rowCounter].Value != null) ? (string)dgvCourse[10, rowCounter].Value.ToString() : "",
                            (dgvCourse[9, rowCounter].Value != null) ? (string)dgvCourse[9, rowCounter].Value.ToString() : "",
                            (dgvCourse[11, rowCounter].Value != null) ? decimal.TryParse(dgvCourse[11, rowCounter].Value.ToString(), out decBuffer) ? decBuffer : 0 : 0,
                            (dgvCourse[6, rowCounter].Value != null) ? (int.TryParse(dgvCourse[6, rowCounter].Value.ToString(), out intBuffer)) ? intBuffer : 0 : 0,
                            (dgvCourse[7, rowCounter].Value != null) ? (int.TryParse(dgvCourse[7, rowCounter].Value.ToString(), out intBuffer)) ? intBuffer : 0 : 0,
                            (dgvCourse[2, rowCounter].Value != null) ? (string)dgvCourse[2, rowCounter].Value.ToString() : "",
                            (dgvCourse[4, rowCounter].Value != null) ? (string)dgvCourse[4, rowCounter].Value.ToString() : "");
                    }
                    else // save
                    {
                        int intBuffer = 0;
                        decimal decBuffer = 0;
                        db.CourseSave(ID_No, BranchID, (dgvCourse[1, rowCounter].Value != null) ? int.Parse(dgvCourse[1, rowCounter].Value.ToString()) : 0,
                            (dgvCourse[10, rowCounter].Value != null) ? (string)dgvCourse[10, rowCounter].Value.ToString() : "",
                            (dgvCourse[9, rowCounter].Value != null) ? (string)dgvCourse[9, rowCounter].Value.ToString() : "",
                            (dgvCourse[11, rowCounter].Value != null) ? decimal.TryParse(dgvCourse[11, rowCounter].Value.ToString(), out decBuffer) ? decBuffer : 0 : 0,
                            (dgvCourse[6, rowCounter].Value != null) ? (int.TryParse(dgvCourse[6, rowCounter].Value.ToString(), out intBuffer)) ? intBuffer : 0 : 0,
                            (dgvCourse[7, rowCounter].Value != null) ? (int.TryParse(dgvCourse[7, rowCounter].Value.ToString(), out intBuffer)) ? intBuffer : 0 : 0,
                            (dgvCourse[2, rowCounter].Value != null) ? (string)dgvCourse[2, rowCounter].Value.ToString() : "",
                            (dgvCourse[4, rowCounter].Value != null) ? (string)dgvCourse[4, rowCounter].Value.ToString() : "");
                    }
                }
                catch { }
            }
            db.Dispose();
        }

        private void dgvCourse_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int intBufferT = 0;
            int intBufferP = 0;
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                try
                {
                    if (dgvCourse[6, e.RowIndex].Value != null)
                        int.TryParse(dgvCourse[6, e.RowIndex].Value.ToString(), out intBufferT);

                    if (dgvCourse[7, e.RowIndex].Value != null)
                        int.TryParse(dgvCourse[7, e.RowIndex].Value.ToString(), out intBufferP);

                    dgvCourse[8, e.RowIndex].Value = intBufferP + intBufferT;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 5) && e.RowIndex >= 0 && e.RowIndex < dgvCourse.RowCount - 1)
            {
                SelectCourseForm scForm = new SelectCourseForm(BranchID);
                //
                // set CheckBoxListBox Data by db.Course
                //
                var db = new LINQDataContext();
                IEnumerable<string> NameQuery = from strName in db.Courses
                                                where strName.Branch_ID == BranchID
                                                select strName.Name_Course;

                scForm.chblstSelectCourse.Items.AddRange(NameQuery.ToArray());
                
                //
                // set a Reference for save output data
                //
                scForm.LstSelectedCourse = (e.ColumnIndex == 3) ?
                    (DataGridViewTextBoxCell)dgvCourse[2, e.RowIndex] : (DataGridViewTextBoxCell)dgvCourse[4, e.RowIndex];
                //
                // set SelectCourseForm Location by this locate
                //
                scForm.Location = (e.ColumnIndex == 3) ?
                    new Point(this.Location.X + 30 + colID.Width + colTermNo.Width + colInReqCourseID.Width, this.Location.Y + 75) :
                    new Point(this.Location.X + 30 + colID.Width + colTermNo.Width + colInReqCourseID.Width +
                                       colBtnInReqCourseID.Width + colPreReqCourseID.Width, this.Location.Y + 75);
                //
                // set Checked Items
                //
                if (scForm.LstSelectedCourse.Value != null)
                {
                    string strID = "";
                    foreach (char chID in scForm.LstSelectedCourse.Value.ToString().ToCharArray())
                    {
                        if (char.IsDigit(chID)) // find ID in string value
                        {
                            strID += chID.ToString();
                        }
                        else if (strID != "") // search and save in checked list
                        {
                            scForm.chblstSelectCourse.SetItemChecked(
                                scForm.chblstSelectCourse.Items.IndexOf(
                                db.CourseSearchID(int.Parse(strID)).ToArray()[0].Name_Course), true);
                            strID = "";
                        }
                        // else continue;
                    }
                }
                //
                // load form
                //
                scForm.ShowDialog();
            }
        }

        private void dgvCourse_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Row.Cells[0].Value.ToString(), out id))
            {
                var db = new LINQDataContext();
                // Define the query expression.
                IEnumerable<int> query =
                    from classs in db.Classes
                    where classs.Course_ID == id
                    select classs.Class_ID;
                //
                // if exist data in class table : 
                //
                if (query.ToArray().Length > 0)
                {
                    string class_ID_List = "";
                    foreach (var anyClass in query)
                    {
                        class_ID_List += anyClass.ToString() + " and ";
                    }
                    class_ID_List = class_ID_List.Substring(0, class_ID_List.Length - 4);

                    e.Cancel = true;

                    MessageBox.Show("Information classes with class numbers " +
                        class_ID_List + "is related to Course " +
                        ((e.Row.Cells[10].Value != null) ? e.Row.Cells[10].Value.ToString() : "NULL") +
                        ".\n First, this information can change classes.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    db.CourseDelete(id);
                }
                db.Dispose();
            }
        }
    }
}

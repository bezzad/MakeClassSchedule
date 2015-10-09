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
    public partial class BranchForm : Form
    {
        public BranchForm()
        {
            InitializeComponent();
        }

        private void dgvBranch_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int ID_Counter = 1;
                bool Find = true;
                while (Find)
                {
                    Find = false;
                    for (int rowC = 0; rowC < dgvBranch.RowCount - 2; rowC++)
                    {
                        if (int.Parse(dgvBranch[0, rowC].Value.ToString()) == ID_Counter)
                        {
                            ID_Counter++;
                            Find = true;
                            break;
                        }
                    }
                }
                dgvBranch.Rows[e.RowIndex - 1].Cells[0].Value = ID_Counter;
            }
        }

        private void BranchForm_Load(object sender, EventArgs e)
        {
            dgvBranch.Rows.Clear();
            var db = new LINQDataContext();
            var aryBranch = db.Branches.ToArray();
            if (aryBranch.Length > 0)
            {
                dgvBranch.Rows.Add(aryBranch.Length);
                for (int rowCounter = 0; rowCounter < aryBranch.Length; rowCounter++)
                {
                    dgvBranch[0, rowCounter].Value = aryBranch[rowCounter].ID_Branch.ToString();

                    if (aryBranch[rowCounter].Branch_Name != null)
                        dgvBranch[1, rowCounter].Value = aryBranch[rowCounter].Branch_Name.ToString();

                    dgvBranch[2, rowCounter].Value = (aryBranch[rowCounter].Degree != null) ?
                                                   aryBranch[rowCounter].Degree.ToString() : "";
                }
            }
        }

        private void BranchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvBranch[0, 0].Selected = true;
            // ----------------------------------------------------------------------------------------------
            //
            var db = new LINQDataContext();
            
            for (int rowCounter = 0; rowCounter < dgvBranch.RowCount - 1; rowCounter++)
            {
                try
                {
                    //
                    // search dgvBranch.rows in db.Branch
                    //
                    int ID_No = 0;
                    int.TryParse(dgvBranch[0, rowCounter].Value.ToString(), out ID_No);
                    // Define the query expression.
                    var query = (from branch in db.Branches
                                 where branch.ID_Branch == ID_No
                                 select branch).SingleOrDefault();

                    if (query != null) // EDIT
                    {
                        db.BranchEdit(ID_No,
                            (dgvBranch[1, rowCounter].Value != null) ? (string)dgvBranch[1, rowCounter].Value.ToString() : "",
                            (dgvBranch[2, rowCounter].Value != null) ? (string)dgvBranch[2, rowCounter].Value.ToString() : "");
                    }
                    else // save
                    {
                        db.BranchSave(ID_No,
                            (dgvBranch[1, rowCounter].Value != null) ? (string)dgvBranch[1, rowCounter].Value.ToString() : "",
                            (dgvBranch[2, rowCounter].Value != null) ? (string)dgvBranch[2, rowCounter].Value.ToString() : "");
                    }
                }
                catch { }
            }
            db.Dispose();
        }

        private void dgvBranch_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Row.Cells[0].Value.ToString(), out id))
            {
                var db = new LINQDataContext();
                // Define the query expression.
                IEnumerable<int> qGroupID =
                    from groups in db.Groups
                    where groups.Branch_Selection == id
                    select groups.ID;
                //
                // Define the query expression.
                IEnumerable<int> qCourseID =
                    from course in db.Courses
                    where course.Branch_ID == id
                    select course.Course_ID;
                //
                // if exist data in the Groups table :
                //
                if (qGroupID.ToArray().Length > 0)
                {
                    string groups_ID_List = "";
                    foreach (var anyGroup in qGroupID)
                    {
                        groups_ID_List += anyGroup.ToString() + " and ";
                    }
                    groups_ID_List = groups_ID_List.Substring(0, groups_ID_List.Length - 4);

                    e.Cancel = true;

                    MessageBox.Show("Information Groups with group numbers " +
                        groups_ID_List + "is related to Branch (" +
                        ((e.Row.Cells[1].Value != null) ? e.Row.Cells[1].Value.ToString() : "NULL") +
                        ").\n First, this information can change groups.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                //
                // if exist data in the Groups table :
                //
                else if (qCourseID.ToArray().Length > 0)
                {
                    string course_ID_List = "";
                    foreach (var anyCourse in qCourseID)
                    {
                        course_ID_List += anyCourse.ToString() + " and ";
                    }
                    course_ID_List = course_ID_List.Substring(0, course_ID_List.Length - 4);

                    e.Cancel = true;

                    MessageBox.Show("Information courses with course numbers " +
                        course_ID_List + "is related to Branch (" +
                        ((e.Row.Cells[1].Value != null) ? e.Row.Cells[1].Value.ToString() : "NULL") +
                        ").\n First, this information can change courses.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    db.BranchDelete(id);
                }
                db.Dispose();
            }
        }
    }
}

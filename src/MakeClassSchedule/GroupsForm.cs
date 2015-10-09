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
    public partial class GroupsForm : Form
    {
        public GroupsForm()
        {
            InitializeComponent();
        }

        //private int? intNULL = null;

        private void dgvGroup_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int ID_Counter = 1;
                bool Find = true;
                while (Find)
                {
                    Find = false;
                    for (int rowC = 0; rowC < dgvGroup.RowCount - 2; rowC++)
                    {
                        if (int.Parse(dgvGroup[0, rowC].Value.ToString()) == ID_Counter)
                        {
                            ID_Counter++;
                            Find = true;
                            break;
                        }
                    }
                }
                dgvGroup.Rows[e.RowIndex - 1].Cells[0].Value = ID_Counter;
            }
        }

        private void GroupsForm_Load(object sender, EventArgs e)
        {
            dgvGroup.Rows.Clear();
            var db = new LINQDataContext();
            var dbQuery = (from seter in db.Groups
                           select new
                           {
                               seter.ID,
                               seter.Semester_Entry_Year,
                               seter.Semester_Entry_FS,
                               BranchIND = (seter.Branch.ID_Branch + ".  " + seter.Branch.Branch_Name + "  -  " + seter.Branch.Degree),
                               seter.Size_No
                           }).ToList();

            this.colSelectBranch.Items.Clear();
            this.colSelectBranch.Items.AddRange((from bIND in
                                                     (from bInfo in db.Branches
                                                      select new
                                                      {
                                                          Info = (bInfo.ID_Branch + ".  " + bInfo.Branch_Name + "  -  " + bInfo.Degree)
                                                      }).ToList()
                                                 select bIND.Info.ToString()).ToArray());
                                                 
            if (dbQuery.Count > 0)
            {
                dgvGroup.Rows.Add(dbQuery.Count);
                for (int rowCounter = 0; rowCounter < dbQuery.Count; rowCounter++)
                {
                    dgvGroup[0, rowCounter].Value = dbQuery[rowCounter].ID;

                    dgvGroup[1, rowCounter].Value = dbQuery[rowCounter].Semester_Entry_Year;

                    dgvGroup[2, rowCounter].Value = (dbQuery[rowCounter].Semester_Entry_FS == true) ?
                        colSemesterEntry.Items[0].ToString() : colSemesterEntry.Items[1];
                        
                    dgvGroup[3, rowCounter].Value = dbQuery[rowCounter].BranchIND;               

                    dgvGroup[4, rowCounter].Value = dbQuery[rowCounter].Size_No.ToString();
                }
            }
        }

        private void GroupsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvGroup[0, 0].Selected = true;
            
            // ----------------------------------------------------------------------------------------------
            //
            var db = new LINQDataContext();
            
            for (int rowCounter = 0; rowCounter < dgvGroup.RowCount - 1; rowCounter++)
            {
                try
                {
                    //
                    // search dgvGroup.rows in db.Groups
                    //
                    int ID_No = 0;
                    int.TryParse(dgvGroup[0, rowCounter].Value.ToString(), out ID_No);
                    // Define the query expression.
                    var query = (from groups in db.Groups
                                 where groups.ID == ID_No
                                 select groups).SingleOrDefault();

                    if (query != null) // EDIT
                    {
                        try
                        {
                            int year = 0;
                            query.Semester_Entry_Year = (int.TryParse(dgvGroup[1, rowCounter].Value.ToString(), out year)) ? year : 0;

                            query.Semester_Entry_FS = (dgvGroup[2, rowCounter].Value != null) ?
                                ((dgvGroup[2, rowCounter].Value.ToString() == colSemesterEntry.Items[0].ToString()) ? true : false) : true;
                            //
                            // find branch id in string ComboBox Select Academic field
                            //
                            int Branch_ID = 0;
                            string bIND = (dgvGroup[3, rowCounter].Value != null) ? dgvGroup[3, rowCounter].Value.ToString() : "";
                            if (bIND == "")
                            {
                                throw new Exception("Pleas Select a Branch for the Group by Group's Id (" + ID_No + ")");
                            }
                            string branch_id = "";
                            foreach (char ch in bIND.ToCharArray())
                            {
                                if (char.IsDigit(ch))
                                {
                                    branch_id += ch.ToString();
                                }
                                else
                                {
                                    Branch_ID = int.Parse(branch_id);
                                    break;
                                }
                            }
               
                            query.Branch_Selection = Branch_ID;
                            //
                            int size = 0;
                            query.Size_No = (dgvGroup[4, rowCounter].Value != null) ? (int.TryParse(dgvGroup[4, rowCounter].Value.ToString(), out size)) ? size : 0 : 0;

                            db.SubmitChanges();
                        }
                        catch { }
                    }
                    else
                    {
                        //
                        // find branch id in string ComboBox Select Academic field
                        //
                        int Branch_ID = 0;
                        string bIND = (dgvGroup[3, rowCounter].Value != null) ? dgvGroup[3, rowCounter].Value.ToString() : "";
                        if (bIND == "")
                        {
                            throw new Exception("Pleas Select a Branch for the Group by Group's Id (" + ID_No + ")");
                        }
                        string branch_id = "";
                        foreach (char ch in bIND.ToCharArray())
                        {
                            if (char.IsDigit(ch))
                            {
                                branch_id += ch.ToString();
                            }
                            else
                            {
                                Branch_ID = int.Parse(branch_id);
                                break;
                            }
                        }
                        //
                        int size = 0;
                        int year = 0;
                        db.GroupsSave(ID_No, (int.TryParse(dgvGroup[1, rowCounter].Value.ToString(), out year)) ? year : 0,
                            (dgvGroup[2, rowCounter].Value != null) ?
                            ((dgvGroup[2, rowCounter].Value.ToString() == colSemesterEntry.Items[0].ToString()) ? true : false) : true,
                             Branch_ID,
                            (dgvGroup[4, rowCounter].Value != null) ? (int.TryParse(dgvGroup[4, rowCounter].Value.ToString(), out size)) ? size : 0 : 0);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        
        private void dgvGroup_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Row.Cells[0].Value.ToString(), out id))
            {
                var db = new LINQDataContext();
                // Define the query expression.
                var cquery = (from classs in db.Group_ID_Lists
                              where classs.Group_ID == id
                              select classs).ToArray();
                if (cquery != null)
                {
                    string query = @"DELETE From dbo.Group_ID_List Where Group_ID = {0}";
                    db.ExecuteQuery<object>(query, id);
                }
                else
                {
                    db.New_GroupsPerClassDeleteByGroupID(id);
                    db.GroupsDelete(id);
                }
                db.Dispose();
            }
        }
    }
}

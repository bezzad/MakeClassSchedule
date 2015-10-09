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
    public partial class ProfessorForm : Form
    {
        public ProfessorForm()
        {
            InitializeComponent();
        }

        private void dgvProfessor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int ID_Counter = 1;
                bool Find = true;
                while (Find)
                {
                    Find = false;
                    for (int rowC = 0; rowC < dgvProfessor.RowCount - 2; rowC++)
                    {
                        if (int.Parse(dgvProfessor[0, rowC].Value.ToString()) == ID_Counter)
                        {
                            ID_Counter++;
                            Find = true;
                            break;
                        }
                    }
                }
                dgvProfessor.Rows[e.RowIndex - 1].Cells[0].Value = ID_Counter;
            }
        }

        private void dgvProfessor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    if (e.RowIndex < dgvProfessor.Rows.Count - 1 && dgvProfessor.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        ProfScheduleForm psForm = new ProfScheduleForm();
                        psForm.Text = "Professor " + "(" + dgvProfessor.Rows[e.RowIndex].Cells[1].Value.ToString() + ")" + " Schedule";
                        //
                        // Construct dgvSchedule in ProfScheduleForm psForm ---------------------------------
                        //
                        psForm.dgvSchedule.Rows.Add(12);
                        psForm.dgvSchedule.ForeColor = Color.DarkBlue;
                        psForm.dgvSchedule.Rows[0].Cells[0].Value = "8 ~ 9";
                        psForm.dgvSchedule.Rows[1].Cells[0].Value = "9 ~ 10";
                        psForm.dgvSchedule.Rows[2].Cells[0].Value = "10 ~ 11";
                        psForm.dgvSchedule.Rows[3].Cells[0].Value = "11 ~ 12";
                        psForm.dgvSchedule.Rows[4].Cells[0].Value = "12 ~ 13";
                        psForm.dgvSchedule.Rows[5].Cells[0].Value = "13 ~ 14";
                        psForm.dgvSchedule.Rows[6].Cells[0].Value = "14 ~ 15";
                        psForm.dgvSchedule.Rows[7].Cells[0].Value = "15 ~ 16";
                        psForm.dgvSchedule.Rows[8].Cells[0].Value = "16 ~ 17";
                        psForm.dgvSchedule.Rows[9].Cells[0].Value = "17 ~ 18";
                        psForm.dgvSchedule.Rows[10].Cells[0].Value = "18 ~ 19";
                        psForm.dgvSchedule.Rows[11].Cells[0].Value = "19 ~ 20";
                        // -------------------------------------------------------------------------------------
                        string scheduleData = "";
                        if (dgvProfessor[6, e.RowIndex].Value != null)
                            scheduleData = dgvProfessor[6, e.RowIndex].Value.ToString();

                        ProfessorInfoCompiler compileData = new ProfessorInfoCompiler();
                        if (compileData.StartScanner(scheduleData.ToUpper()))
                        {
                            // [1 ~ Columns.Count, 0 ~ Rows.Count]
                            bool[,] fillByChecker = compileData.CompiledData;

                            // read Rows
                            for (int i = 0; i < 12; i++)
                            {
                                // read Columns
                                for (int j = 1; j < 8; j++)
                                {
                                    if (fillByChecker[i, j])
                                        psForm.dgvSchedule[j, i].Value = true;
                                }
                            }
                        }
                        else
                        {
                            // error massage for dgvProfessor data's
                            MessageBox.Show(scheduleData, "Data is incorrect!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        psForm.Interface_TextBox = (DataGridViewTextBoxCell)dgvProfessor.Rows[e.RowIndex].Cells[6];
                        psForm.ShowDialog();
                    }
                }
            }
            catch { }
        }
 
        private void ProfessorForm_Load(object sender, EventArgs e)
        {
            dgvProfessor.Rows.Clear();
            var db = new LINQDataContext();
            var aryReader = db.Professors.ToArray();
            if (aryReader.Length > 0)
            {
                dgvProfessor.Rows.Add(aryReader.Length);
                for (int rowCounter = 0; rowCounter < aryReader.Length; rowCounter++) 
                {
                    dgvProfessor[0, rowCounter].Value = aryReader[rowCounter].ID.ToString();

                    if (aryReader[rowCounter].Name_Professor != null)
                        dgvProfessor[1, rowCounter].Value = aryReader[rowCounter].Name_Professor.ToString();

                    dgvProfessor[2, rowCounter].Value = (aryReader[rowCounter].Branch != null) ? aryReader[rowCounter].Branch.ToString() : "";

                    dgvProfessor[3, rowCounter].Value = (aryReader[rowCounter].Email != null) ? aryReader[rowCounter].Email.ToString() : "";

                    dgvProfessor[4, rowCounter].Value = (aryReader[rowCounter].EducationDegree != null) ? aryReader[rowCounter].EducationDegree.ToString() : "";

                    if (aryReader[rowCounter].Schedule != null)
                        dgvProfessor[6, rowCounter].Value = aryReader[rowCounter].Schedule.ToString();
                }
            }
        }

        private void ProfessorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvProfessor[0, 0].Selected = true;
            
            // ----------------------------------------------------------------------------------------------
            //
            var db = new LINQDataContext();
            
            for (int rowCounter = 0; rowCounter < dgvProfessor.RowCount - 1; rowCounter++) 
            {
                //
                // search dgvProfessor.rows in db.Professor
                //
                int ID_No = 0;
                int.TryParse(dgvProfessor[0, rowCounter].Value.ToString(), out ID_No);
                // Define the query expression.
                IEnumerable<int> query =
                    from prof in db.Professors
                    where prof.ID == ID_No
                    select prof.ID;
                    
                if (query.ToArray().Length > 0) // EDIT
                {
                    db.ProfessorEdit(ID_No,
                        (dgvProfessor[1, rowCounter].Value != null) ? (string)dgvProfessor[1, rowCounter].Value.ToString() : "",
                        (dgvProfessor[2, rowCounter].Value != null) ? (string)dgvProfessor[2, rowCounter].Value.ToString() : "",
                        (dgvProfessor[3, rowCounter].Value != null && dgvProfessor[3, rowCounter].Value.ToString().ValidateEmail()) ?
                        (string)dgvProfessor[3, rowCounter].Value.ToString() : "",
                        (dgvProfessor[4, rowCounter].Value != null) ? (string)dgvProfessor[4, rowCounter].Value.ToString() : "",
                        (dgvProfessor[6, rowCounter].Value != null) ? (string)dgvProfessor[6, rowCounter].Value.ToString() : "");
                }
                else // SAVE NEW
                {
                    db.ProfessorSave(ID_No,
                        (dgvProfessor[1, rowCounter].Value != null) ? (string)dgvProfessor[1, rowCounter].Value.ToString() : "",
                        (dgvProfessor[2, rowCounter].Value != null) ? (string)dgvProfessor[2, rowCounter].Value.ToString() : "",
                        (dgvProfessor[3, rowCounter].Value != null && dgvProfessor[3, rowCounter].Value.ToString().ValidateEmail()) ?
                        (string)dgvProfessor[3, rowCounter].Value.ToString() : "",
                        (dgvProfessor[4, rowCounter].Value != null) ? (string)dgvProfessor[4, rowCounter].Value.ToString() : "",
                        (dgvProfessor[6, rowCounter].Value != null) ? (string)dgvProfessor[6, rowCounter].Value.ToString() : "");
                }
            }

            db.Dispose();
        }

        private void dgvProfessor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Row.Cells[0].Value.ToString(), out id))
            {
                var db = new LINQDataContext();
                // Define the query expression.
                IEnumerable<int> query = from priority in db.Priority_Professors
                                         where priority.Professor_ID == id
                                         select priority.Class_ID;
                //
                // if exist data in table ? 
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
                        class_ID_List + "is related to Professor " +
                        ((e.Row.Cells[1].Value != null) ? e.Row.Cells[1].Value.ToString() : "NULL") +
                        ".\n First, this information can change classes.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    db.ClassroomDeleteProf(id);
                    db.ProfessorDelete(id);
                }
                db.Dispose();
            }
        }   
    }
}


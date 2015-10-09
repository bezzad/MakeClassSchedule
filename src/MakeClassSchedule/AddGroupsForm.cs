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
    public partial class AddGroupsForm : Form
    {
        public AddGroupsForm()
        {
            InitializeComponent();
        }

        private DataGridViewTextBoxCell interface_TextBox;
        public DataGridViewTextBoxCell Interface_TextBox
        {
            get { return interface_TextBox; }
            set { interface_TextBox = value; }
        }

        private void AddGroupsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvSelectGroups[0, 0].Selected = true;

            Interface_TextBox.Value = "";
            foreach (DataGridViewRow row in dgvSelectGroups.Rows)
            {
                if (row.Cells["colSelection"].Value != null)
                    if ((bool)row.Cells["colSelection"].Value == true)
                        Interface_TextBox.Value += row.Cells[0].Value.ToString() + "  ";
            }
        }

        private void AddGroupsForm_Load(object sender, EventArgs e)
        {
            var dbGroups = from db in new LINQDataContext().Groups
                           select new
                           {
                               db.ID,
                               db.Semester_Entry_Year,
                               SemesterEntry = ((db.Semester_Entry_FS == true) ? "First Entry" : "Second Entry"),
                               db.Size_No,
                               branchIN = (db.Branch.Branch_Name + "  -  " + db.Branch.Degree)
                           };
            dgvSelectGroups.DataSource = dbGroups;
            //
            // Create "Groups Selection" CheckBox Column
            //
            DataGridViewColumn colSelection = new DataGridViewCheckBoxColumn();
            colSelection.HeaderText = "Groups Selection";
            colSelection.MinimumWidth = 100;
            colSelection.Name = "colSelection";
            colSelection.Width = 130;
            dgvSelectGroups.Columns.Add(colSelection);
            //
            // Set Other Columns Header
            //
            dgvSelectGroups.Columns[0].HeaderText = "Group ID";
            dgvSelectGroups.Columns[0].Width = 60;
            dgvSelectGroups.Columns[1].HeaderText = "Semester Entry Year";
            dgvSelectGroups.Columns[1].Width = 100;
            dgvSelectGroups.Columns[2].HeaderText = "Semester Entry";
            dgvSelectGroups.Columns[2].Width = 100;
            dgvSelectGroups.Columns[3].HeaderText = "Size";
            dgvSelectGroups.Columns[3].Width = 60;
            dgvSelectGroups.Columns[4].HeaderText = "Academic field";
            dgvSelectGroups.Columns[4].Width = 180;
            dgvSelectGroups.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            // add selection group's Data in agForm.dgvSelectGroups
            //
            if (Interface_TextBox.Value != null)
            {
                char[] spell = Interface_TextBox.Value.ToString().ToCharArray();
                string strBuffer = "";
                for (int indexC = 0; indexC < spell.Length; indexC++)
                {
                    if (char.IsWhiteSpace(spell[indexC]))
                    {
                        if (strBuffer != "")
                        {
                            int idBuffer = 0;
                            int.TryParse(strBuffer, out idBuffer);
                            //
                            //search group id in groups and check that group
                            foreach (DataGridViewRow row in dgvSelectGroups.Rows)
                            {
                                if (idBuffer == int.Parse(row.Cells[0].Value.ToString()))
                                    row.Cells["colSelection"].Value = true;
                            }
                            //
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
                            int idBuffer = 0;
                            int.TryParse(strBuffer, out idBuffer);
                            //
                            //search group id in groups and check that group
                            foreach (DataGridViewRow row in dgvSelectGroups.Rows)
                            {
                                if (idBuffer == int.Parse(row.Cells[0].Value.ToString()))
                                    row.Cells["colSelection"].Value = true;
                            }
                            //
                            strBuffer = "";
                        }
                    }
                }
            }
            //
        }
    }
}

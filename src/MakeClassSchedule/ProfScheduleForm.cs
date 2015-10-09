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
    public partial class ProfScheduleForm : Form
    {
        public ProfScheduleForm()
        {
            InitializeComponent();
        }
        
        private void dgvSchedule_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 0 && e.RowIndex >= 0)
                {
                    DataGridViewCell currentCell = dgvSchedule.CurrentCell;
                    if (currentCell.Value != null)
                    {
                        if (FirstEnter)
                        {
                            trueToggle = !(bool)currentCell.Value;
                            FirstEnter = false;
                        }

                        foreach (DataGridViewCheckBoxCell cell in dgvSchedule.SelectedCells)
                        {
                            cell.Value = trueToggle;
                        }
                        dgvSchedule.Refresh();
                    }
                    else
                    {
                        FirstEnter = false;
                        trueToggle = true;
                        foreach (DataGridViewCheckBoxCell cell in dgvSchedule.SelectedCells)
                        {
                            cell.Value = trueToggle;
                        }
                    }
                }
            }
            catch { }
        }

        private DataGridViewTextBoxCell interface_TextBox;
        public DataGridViewTextBoxCell Interface_TextBox
        {
            get { return interface_TextBox; }
            set { interface_TextBox = value; }
        }

        private void ProfScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            // Read all checkBox in dgvSchedule and save that in string array
            //
            string[] Day = new string[7];
            for (int columnIndex = 1; columnIndex < 8; columnIndex++)
            {
                Day[columnIndex - 1] = string.Empty;
                for (int rowIndex = 0; rowIndex < 12; rowIndex++)
                {
                    if (dgvSchedule[columnIndex, rowIndex].Value != null)
                    {
                        if (dgvSchedule[columnIndex, rowIndex].Value.ToString() == "True")
                        {
                            Day[columnIndex - 1] += (string)dgvSchedule[0, rowIndex].Value.ToString() + " & ";
                        }
                    }
                }
            }
            //
            // clear over plus text in string array and add in dgvProfessor
            //
            interface_TextBox.Value = string.Empty;
            string buffer = "";
            for (int i = 0; i < 7; i++)
            {
                // clear overPlus data as string Array
                Day[i] = Day[i].Substring(0, (Day[i].Length > 2) ? Day[i].Length - 2 : 0);
                // add day schedule in DataGridView dgvProfessor
                string dayName = "";
                switch (i)
                {
                    case 0: dayName = "SAT";
                        break;
                    case 1: dayName = "SUN";
                        break;
                    case 2: dayName = "MON";
                        break;
                    case 3: dayName = "THU";
                        break;
                    case 4: dayName = "WED";
                        break;
                    case 5: dayName = "THR";
                        break;
                    case 6: dayName = "FRI";
                        break;
                }
                buffer += (Day[i].Length > 2) ? dayName + " { " + Day[i] + "} & " : "";
            }
            interface_TextBox.Value = buffer.Substring(0, (buffer.Length > 2) ? buffer.Length - 2 : 0);
            bool FREE = true;
            for (int i = 0; i < 12; i++)
                for (int j = 1; j < 8; j++)
                    if (dgvSchedule[j, i].Value == null)
                    { FREE = false; break; }
                    else if (dgvSchedule[j, i].Value.ToString() == "false")
                    { FREE = false; break; }
            if (FREE) interface_TextBox.Value = "FREE";
        }

        bool trueToggle = true;
        bool FirstEnter = false;
        private void dgvSchedule_MouseDown(object sender, MouseEventArgs e)
        {
            FirstEnter = true;
        }
    }
}

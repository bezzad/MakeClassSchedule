using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GemBox.Spreadsheet;
using System.Threading;
using DisconnectDB;

namespace MakeClassSchedule
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string FileName = string.Empty;
        private const string helpFile = "MCS_Help.html";

        #region Open just one MainForm in Windows Code
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
        #endregion

        #region Disable Excel Component Warning Code
        /// <summary>
        /// Non-activating component warning Excel file that more than 5 sheet and line is 150.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ef_LimitReached(object sender, LimitEventArgs e)
        {
            e.WriteWarningWorksheet = false;
            MessageBox.Show("Component for Excel files with a maximum sheet 5 and 150 line is.\n" +
                "http://www.gemboxsoftware.com/GBSpreadsheet.htm#Features", "Limit Reached");
        }
        private void ef_LimitNear(object sender, LimitEventArgs e)
        {
            e.WriteWarningWorksheet = false;
        }
        #endregion

        #region Graphics Code
        #region pbtnImport Graphic's Event
        // 
        // Pic Button Import MouseLeave Event
        //
        private void pbtnProfessorImport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnProfessorImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Normal;
        }
        private void pbtnCourseImport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnCourseImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Normal;
        }
        private void pbtnRoomImport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnRoomImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Normal;
        }
        private void pbtnGroupImport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnGroupImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Normal;
        }
        private void pbtnClassImport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnClassImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Normal;
        }
        private void pbtnBranchImport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnBranchImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Normal;
        }

        //
        // Pic Button Import MouseEnter Event
        //
        private void pbtnProfessorImport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnProfessorImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnCourseImport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnCourseImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnRoomImport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnRoomImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnGroupImport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnGroupImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnClassImport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnClassImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnBranchImport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnBranchImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        //
        // Pic Button Import MouseDown Event
        //
        private void pbtnProfessorImport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnProfessorImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Down;
        }
        private void pbtnCourseImport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnCourseImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Down;
        }
        private void pbtnRoomImport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnRoomImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Down;
        }
        private void pbtnGroupImport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnGroupImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Down;
        }
        private void pbtnClassImport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnClassImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Down;
        }
        private void pbtnBranchImport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnBranchImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Down;
        }
        //
        // Pic Button Import MouseUp Event
        //
        private void pbtnProfessorImport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnProfessorImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnCourseImport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnCourseImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnRoomImport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnRoomImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnGroupImport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnGroupImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnClassImport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnClassImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        private void pbtnBranchImport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnBranchImport.Image = global::MakeClassSchedule.Properties.Resources.Import_Over;
        }
        #endregion

        #region pbtnExport Graphic's Event
        //
        // Pic Button Export MouseUp Event
        //
        private void pbtnProfessorExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnProfessorExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnCourseExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnCourseExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnRoomExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnRoomExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnGroupExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnGroupExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnClassExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnClassExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnBranchExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnBranchExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnTermSchemeExport_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnTermSchemeExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        //
        // Pic Button Export MouseLeave Event
        //
        private void pbtnProfessorExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnProfessorExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        private void pbtnCourseExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnCourseExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        private void pbtnRoomExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnRoomExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        private void pbtnGroupExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnGroupExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        private void pbtnClassExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnClassExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        private void pbtnBranchExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnBranchExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        private void pbtnTermSchemeExport_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnTermSchemeExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
        }
        //
        // Pic Button Export MouseEnter Event
        //
        private void pbtnProfessorExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnProfessorExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnCourseExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnCourseExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnRoomExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnRoomExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnGroupExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnGroupExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnClassExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnClassExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnBranchExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnBranchExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        private void pbtnTermSchemeExport_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnTermSchemeExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Over;
        }
        //
        // Pic Button Export MouseDown Event
        //
        private void pbtnProfessorExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnProfessorExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        private void pbtnCourseExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnCourseExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        private void pbtnRoomExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnRoomExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        private void pbtnGroupExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnGroupExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        private void pbtnClassExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnClassExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        private void pbtnBranchExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnBranchExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        private void pbtnTermSchemeExport_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnTermSchemeExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Down;
        }
        #endregion
        #endregion

        #region Export To Excel files (*.xls)
        //--------------------------------------------------------------------------------
        private void pbtnProfessorExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "ProfessorData.xls";
            save2Excel.FileName = "ProfessorData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                // If using Professional version, put your serial key below. Otherwise, keep following
                // line commented out as Free version doesn't have SetLicense method.
                // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                var db = new LINQDataContext(); // for load from OLEDB  db.Professor.mdf database file's
                var aryDBProfessor = db.Professors.ToArray();
                ExcelFile ef = new ExcelFile();
                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                ExcelWorksheet ws = ef.Worksheets.Add("Professor");
                int NumberSheet = 1;
                //
                // column header text
                ws.Cells[0, 0].Value = "ID";
                ws.Cells[0, 1].Value = "Professor Name";
                ws.Cells[0, 2].Value = "Branch";
                ws.Cells[0, 3].Value = "Email";
                ws.Cells[0, 4].Value = "Education Degree";
                ws.Cells[0, 5].Value = "SCHEDULE";
                //
                // column width
                ws.Columns[0].Width = 5 * 256;
                ws.Columns[1].Width = 30 * 256;
                ws.Columns[2].Width = 20 * 256;
                ws.Columns[3].Width = 40 * 256;
                ws.Columns[4].Width = 20 * 256;
                ws.Columns[5].Width = 200 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                CellStyle tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                if (aryDBProfessor.Length >= 150)
                    ws.Cells.GetSubrangeAbsolute(1, 0, 149, 5).Style = tmpStyle;
                else
                    ws.Cells.GetSubrangeAbsolute(1, 0, aryDBProfessor.Length, 5).Style = tmpStyle;
                //
                // Header style's
                CellStyle HeaderStyle = new CellStyle();
                HeaderStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                HeaderStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                HeaderStyle.FillPattern.SetSolid(Color.Chocolate);
                HeaderStyle.Font.Weight = ExcelFont.MaxWeight;
                HeaderStyle.Font.Color = Color.White;
                HeaderStyle.WrapText = true;
                HeaderStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 5).Style = HeaderStyle;
                //
                // row data
                int RowCount = 0;
                for (int rowC = 0; rowC < aryDBProfessor.Length; rowC++, RowCount++)
                {
                    if (RowCount >= 149) // Go Next Sheet
                    {
                        RowCount = 0;
                        NumberSheet++;
                        ws = ef.Worksheets.Add("Professor(" + NumberSheet.ToString() + ")");
                        //
                        // column header text
                        ws.Cells[0, 0].Value = "ID";
                        ws.Cells[0, 1].Value = "Professor Name";
                        ws.Cells[0, 2].Value = "Branch";
                        ws.Cells[0, 3].Value = "Email";
                        ws.Cells[0, 4].Value = "Education Degree";
                        ws.Cells[0, 5].Value = "SCHEDULE";
                        //
                        // column width
                        ws.Columns[0].Width = 5 * 256;
                        ws.Columns[1].Width = 30 * 256;
                        ws.Columns[2].Width = 20 * 256;
                        ws.Columns[3].Width = 40 * 256;
                        ws.Columns[4].Width = 20 * 256;
                        ws.Columns[5].Width = 200 * 256;
                        //
                        // Header Hight
                        ws.Rows[0].Height = 2 * 256;
                        //
                        // row data style's
                        if (aryDBProfessor.Length - rowC >= 150)
                            ws.Cells.GetSubrangeAbsolute(1, 0, 149, 5).Style = tmpStyle;
                        else
                            ws.Cells.GetSubrangeAbsolute(1, 0, aryDBProfessor.Length - rowC, 5).Style = tmpStyle;
                        //
                        // Header style's
                        ws.Cells.GetSubrangeAbsolute(0, 0, 0, 5).Style = HeaderStyle;
                    }
                    ws.Cells[RowCount + 1, 0].Value = aryDBProfessor[rowC].ID.ToString();

                    ws.Cells[RowCount + 1, 1].Value = (aryDBProfessor[rowC].Name_Professor != null) ?
                        aryDBProfessor[rowC].Name_Professor.ToString() : "";

                    ws.Cells[RowCount + 1, 2].Value = (aryDBProfessor[rowC].Branch != null) ?
                       aryDBProfessor[rowC].Branch.ToString() : "";

                    ws.Cells[RowCount + 1, 3].Value = (aryDBProfessor[rowC].Email != null) ?
                       aryDBProfessor[rowC].Email.ToString() : "";

                    ws.Cells[RowCount + 1, 4].Value = (aryDBProfessor[rowC].EducationDegree != null) ?
                       aryDBProfessor[rowC].EducationDegree.ToString() : "";

                    ws.Cells[RowCount + 1, 5].Value = (aryDBProfessor[rowC].Schedule != null) ?
                        aryDBProfessor[rowC].Schedule.ToString() : "";
                    ws.Cells[RowCount + 1, 5].Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                }
                //
                // save professor data in save2Excel.FileName path's
                //
                ef.SaveXls(save2Excel.FileName);
                //
                // Try to open created excel file's
                //
                try
                {
                    System.Diagnostics.Process.Start(save2Excel.FileName);
                }
                catch
                { }
            }
        }

        private void pbtnCourseExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "CourseData.xls";
            save2Excel.FileName = "CourseData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                // If using Professional version, put your serial key below. Otherwise, keep following
                // line commented out as Free version doesn't have SetLicense method.
                // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                var db = new LINQDataContext(); // for load from OLEDB  db.Course.mdf database file's
                var aryDBCourse = db.Courses.ToArray();
                ExcelFile ef = new ExcelFile();
                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                ExcelWorksheet ws = ef.Worksheets.Add("Course");
                int NumberSheet = 1;
                //
                // column header text
                ws.Cells[0, 0].Value = "Branch ID";
                ws.Cells[0, 1].Value = "ID";
                ws.Cells[0, 2].Value = "Term No";
                ws.Cells[0, 3].Value = "InRequisite Course ID";
                ws.Cells[0, 4].Value = "InRequisite Course Name";
                ws.Cells[0, 5].Value = "PreRequisite Course ID";
                ws.Cells[0, 6].Value = "PreRequisite Course Name";
                ws.Cells[0, 7].Value = "Theory Unit No";
                ws.Cells[0, 8].Value = "Pratial Unit No";
                ws.Cells[0, 9].Value = "Course Type";
                ws.Cells[0, 10].Value = "Course Name";
                ws.Cells[0, 11].Value = "Course Code";
                //
                // column width
                ws.Columns[0].Width = 8 * 256;
                ws.Columns[1].Width = 8 * 256;
                ws.Columns[2].Width = 8 * 256;
                ws.Columns[3].Width = 25 * 256;
                ws.Columns[4].Width = 50 * 256;
                ws.Columns[5].Width = 25 * 256;
                ws.Columns[6].Width = 50 * 256;
                ws.Columns[7].Width = 20 * 256;
                ws.Columns[8].Width = 20 * 256;
                ws.Columns[9].Width = 15 * 256;
                ws.Columns[10].Width = 30 * 256;
                ws.Columns[11].Width = 20 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                CellStyle tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                if (aryDBCourse.Length > 149)
                    ws.Cells.GetSubrangeAbsolute(1, 0, 149, 11).Style = tmpStyle;
                else
                    ws.Cells.GetSubrangeAbsolute(1, 0, aryDBCourse.Length, 11).Style = tmpStyle;
                //
                // Header style's
                CellStyle headerStyle = new CellStyle();
                headerStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                headerStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                headerStyle.FillPattern.SetSolid(Color.Chocolate);
                headerStyle.Font.Weight = ExcelFont.MaxWeight;
                headerStyle.Font.Color = Color.White;
                headerStyle.WrapText = true;
                headerStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 11).Style = headerStyle;
                //
                // row data
                int RowCount = 0;
                for (int rowC = 0; rowC < aryDBCourse.Length; rowC++, RowCount++)
                {
                    if (RowCount >= 149)
                    {
                        RowCount = 0;
                        NumberSheet++;
                        ws = ef.Worksheets.Add("Course(" + NumberSheet.ToString() + ")");
                        //
                        // column header text
                        ws.Cells[0, 0].Value = "Branch ID";
                        ws.Cells[0, 1].Value = "ID";
                        ws.Cells[0, 2].Value = "Term No";
                        ws.Cells[0, 3].Value = "InRequisite Course ID";
                        ws.Cells[0, 4].Value = "InRequisite Course Name";
                        ws.Cells[0, 5].Value = "PreRequisite Course ID";
                        ws.Cells[0, 6].Value = "PreRequisite Course Name";
                        ws.Cells[0, 7].Value = "Theory Unit No";
                        ws.Cells[0, 8].Value = "Pratial Unit No";
                        ws.Cells[0, 9].Value = "Course Type";
                        ws.Cells[0, 10].Value = "Course Name";
                        ws.Cells[0, 11].Value = "Course Code";
                        //
                        // column width
                        ws.Columns[0].Width = 8 * 256;
                        ws.Columns[1].Width = 8 * 256;
                        ws.Columns[2].Width = 8 * 256;
                        ws.Columns[3].Width = 25 * 256;
                        ws.Columns[4].Width = 50 * 256;
                        ws.Columns[5].Width = 25 * 256;
                        ws.Columns[6].Width = 50 * 256;
                        ws.Columns[7].Width = 20 * 256;
                        ws.Columns[8].Width = 20 * 256;
                        ws.Columns[9].Width = 15 * 256;
                        ws.Columns[10].Width = 30 * 256;
                        ws.Columns[11].Width = 20 * 256;
                        //
                        // Header Hight
                        ws.Rows[0].Height = 2 * 256;
                        //
                        // row data style's
                        if (aryDBCourse.Length - rowC > 149)
                            ws.Cells.GetSubrangeAbsolute(1, 0, 149, 11).Style = tmpStyle;
                        else
                            ws.Cells.GetSubrangeAbsolute(1, 0, aryDBCourse.Length - rowC, 11).Style = tmpStyle;
                        //
                        // Header style's
                        ws.Cells.GetSubrangeAbsolute(0, 0, 0, 11).Style = headerStyle;
                    }
                    ws.Cells[RowCount + 1, 0].Value = aryDBCourse[rowC].Branch_ID;

                    ws.Cells[RowCount + 1, 1].Value = aryDBCourse[rowC].Course_ID;

                    ws.Cells[RowCount + 1, 2].Value = aryDBCourse[rowC].TermNo.Value;

                    ws.Cells[RowCount + 1, 3].Value = aryDBCourse[rowC].InRequisite_CourseID;
                    //
                    // Compile InReq Course iD to Name
                    //
                    string InRequisite_CourseName = "";
                    string buffer = "";
                    foreach (char reader in aryDBCourse[rowC].InRequisite_CourseID.ToCharArray())
                    {
                        if (char.IsDigit(reader))
                            buffer += reader.ToString();
                        else if (buffer != "")
                        {
                            InRequisite_CourseName += (from Qname in db.Courses
                                                       where Qname.Course_ID == int.Parse(buffer)
                                                       select Qname.Name_Course).ToArray()[0].ToString() + " & ";
                            buffer = "";
                        }
                    }
                    InRequisite_CourseName = (InRequisite_CourseName.Length > 3) ?
                        InRequisite_CourseName.Substring(0, InRequisite_CourseName.Length - 3) :
                        InRequisite_CourseName;
                    //
                    ws.Cells[RowCount + 1, 4].Value = InRequisite_CourseName;
                    ws.Cells[RowCount + 1, 5].Value = aryDBCourse[rowC].PreRequisite_CourseID;
                    //
                    // Compile PreReq Course iD to Name
                    //
                    string PreRequisite_CourseName = "";
                    buffer = "";
                    foreach (char reader in aryDBCourse[rowC].PreRequisite_CourseID.ToCharArray())
                    {
                        if (char.IsDigit(reader))
                            buffer += reader.ToString();
                        else if (buffer != "")
                        {
                            PreRequisite_CourseName += (from Qname in db.Courses
                                                        where Qname.Course_ID == int.Parse(buffer)
                                                        select Qname.Name_Course).ToArray()[0].ToString() + @"  &  ";
                            buffer = "";
                        }
                    }
                    PreRequisite_CourseName = (PreRequisite_CourseName.Length > 3) ?
                        PreRequisite_CourseName.Substring(0, PreRequisite_CourseName.Length - 3) :
                        PreRequisite_CourseName;
                    //
                    ws.Cells[RowCount + 1, 6].Value = PreRequisite_CourseName;
                    ws.Cells[RowCount + 1, 7].Value = aryDBCourse[rowC].TheoryUnitNo.Value;
                    ws.Cells[RowCount + 1, 8].Value = aryDBCourse[rowC].PracticalUnitNo.Value;
                    ws.Cells[RowCount + 1, 9].Value = aryDBCourse[rowC].Type_Course;
                    ws.Cells[RowCount + 1, 10].Value = aryDBCourse[rowC].Name_Course;
                    ws.Cells[RowCount + 1, 11].Value = aryDBCourse[rowC].CourseCode.Value;
                }

                //
                // save professor data in save2Excel.FileName path's
                //
                ef.SaveXls(save2Excel.FileName);
                //
                // Try to open created excel file's
                //
                try
                {
                    System.Diagnostics.Process.Start(save2Excel.FileName);
                }
                catch
                { }
            }
        }

        private void pbtnRoomExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "RoomData.xls";
            save2Excel.FileName = "RoomData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                // If using Professional version, put your serial key below. Otherwise, keep following
                // line commented out as Free version doesn't have SetLicense method.
                // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                var db = new LINQDataContext(); // for load from OLEDB  db.Room.mdf database file's
                var aryDBRoom = db.Rooms.ToArray();
                var aryDBRoom_Type = db.Room_Types.ToArray();
                ExcelFile ef = new ExcelFile();
                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                ExcelWorksheet ws;

                #region Room Data
                ws = ef.Worksheets.Add("Room");
                //
                // column header text
                ws.Cells[0, 0].Value = "ID";
                ws.Cells[0, 1].Value = "Room Name";
                ws.Cells[0, 2].Value = "Room Type";
                ws.Cells[0, 3].Value = "Size";
                //
                // column width
                ws.Columns[0].Width = 8 * 256;
                ws.Columns[1].Width = 50 * 256;
                ws.Columns[2].Width = 20 * 256;
                ws.Columns[3].Width = 10 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                CellStyle tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                ws.Cells.GetSubrangeAbsolute(1, 0, aryDBRoom.Length, 3).Style = tmpStyle;
                //
                // row data
                for (int rowC = 0; rowC < aryDBRoom.Length; rowC++)
                {
                    ws.Cells[rowC + 1, 0].Value = aryDBRoom[rowC].Room_ID.ToString();
                    ws.Cells[rowC + 1, 1].Value = aryDBRoom[rowC].Name_Room.ToString();
                    ws.Cells[rowC + 1, 2].Value = aryDBRoom[rowC].Type_Room.ToString();
                    ws.Cells[rowC + 1, 3].Value = aryDBRoom[rowC].Size_No.ToString();
                }
                //
                // Header style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.Chocolate);
                tmpStyle.Font.Weight = ExcelFont.MaxWeight;
                tmpStyle.Font.Color = Color.White;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 3).Style = tmpStyle;
                #endregion

                #region Room_Type Data
                ws = ef.Worksheets.Add("Room_Type");
                //
                // column header text
                ws.Cells[0, 0].Value = "Room Type";
                //
                // column width
                ws.Columns[0].Width = 30 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                ws.Cells.GetSubrangeAbsolute(1, 0, aryDBRoom_Type.Length, 0).Style = tmpStyle;
                //
                // row data
                for (int rowC = 0; rowC < aryDBRoom_Type.Length; rowC++)
                {
                    ws.Cells[rowC + 1, 0].Value = aryDBRoom_Type[rowC].Type_Name.ToString();
                }
                //
                // Header style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.Chocolate);
                tmpStyle.Font.Weight = ExcelFont.MaxWeight;
                tmpStyle.Font.Color = Color.White;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 0).Style = tmpStyle;
                #endregion

                //
                // save professor data in save2Excel.FileName path's
                //
                ef.SaveXls(save2Excel.FileName);
                //
                // Try to open created excel file's
                //
                try
                {
                    System.Diagnostics.Process.Start(save2Excel.FileName);
                }
                catch
                { }
            }
        }

        private void pbtnGroupExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "GroupData.xls";
            save2Excel.FileName = "GroupData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                // If using Professional version, put your serial key below. Otherwise, keep following
                // line commented out as Free version doesn't have SetLicense method.
                // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                var db = new LINQDataContext(); // for load from OLEDB  db.Groups.mdf database file's
                var aryDBGroups = db.Groups.ToArray();
                ExcelFile ef = new ExcelFile();
                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                ExcelWorksheet ws = ef.Worksheets.Add("Group");
                //
                // column header text
                ws.Cells[0, 0].Value = "ID";
                ws.Cells[0, 1].Value = "Semester Entry Year";
                ws.Cells[0, 2].Value = "Semester Entry First or Second";
                ws.Cells[0, 3].Value = "Education Course ID";
                ws.Cells[0, 4].Value = "Education Course Name";
                ws.Cells[0, 5].Value = "Education Course Degree";
                ws.Cells[0, 6].Value = "Size";
                //
                // column width
                ws.Columns[0].Width = 8 * 256;
                ws.Columns[1].Width = 20 * 256;
                ws.Columns[2].Width = 20 * 256;
                ws.Columns[3].Width = 20 * 256;
                ws.Columns[4].Width = 50 * 256;
                ws.Columns[5].Width = 50 * 256;
                ws.Columns[6].Width = 10 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                CellStyle tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                ws.Cells.GetSubrangeAbsolute(1, 0, aryDBGroups.Length, 6).Style = tmpStyle;
                //
                // row data
                for (int rowC = 0; rowC < aryDBGroups.Length; rowC++)
                {
                    ws.Cells[rowC + 1, 0].Value = aryDBGroups[rowC].ID.ToString();
                    ws.Cells[rowC + 1, 1].Value = aryDBGroups[rowC].Semester_Entry_Year;
                    ws.Cells[rowC + 1, 2].Value = aryDBGroups[rowC].Semester_Entry_FS.ToString();
                    ws.Cells[rowC + 1, 3].Value = aryDBGroups[rowC].Branch_Selection.ToString();
                    ws.Cells[rowC + 1, 4].Value = aryDBGroups[rowC].Branch.Branch_Name.ToString();
                    ws.Cells[rowC + 1, 5].Value = aryDBGroups[rowC].Branch.Degree.ToString();
                    ws.Cells[rowC + 1, 6].Value = aryDBGroups[rowC].Size_No.ToString();
                }
                //
                // Header style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.Chocolate);
                tmpStyle.Font.Weight = ExcelFont.MaxWeight;
                tmpStyle.Font.Color = Color.White;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 6).Style = tmpStyle;
                //
                // save professor data in save2Excel.FileName path's
                //
                ef.SaveXls(save2Excel.FileName);
                //
                // Try to open created excel file's
                //
                try
                {
                    System.Diagnostics.Process.Start(save2Excel.FileName);
                }
                catch
                { }
            }
        }

        private void pbtnBranchExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "BranchData.xls";
            save2Excel.FileName = "BranchData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                // If using Professional version, put your serial key below. Otherwise, keep following
                // line commented out as Free version doesn't have SetLicense method.
                // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                var db = new LINQDataContext(); // for load from OLEDB  db.Branches.mdf database file's
                var aryDBBranch = db.Branches.ToArray();
                ExcelFile ef = new ExcelFile();
                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                ExcelWorksheet ws = ef.Worksheets.Add("Branch");
                //
                // column header text
                ws.Cells[0, 0].Value = "ID";
                ws.Cells[0, 1].Value = "Education Course Name";
                ws.Cells[0, 2].Value = "Education Degree";
                //
                // column width
                ws.Columns[0].Width = 8 * 256;
                ws.Columns[1].Width = 50 * 256;
                ws.Columns[2].Width = 50 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                CellStyle tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                ws.Cells.GetSubrangeAbsolute(1, 0, aryDBBranch.Length, 2).Style = tmpStyle;
                //
                // row data
                for (int rowC = 0; rowC < aryDBBranch.Length; rowC++)
                {
                    ws.Cells[rowC + 1, 0].Value = aryDBBranch[rowC].ID_Branch.ToString();
                    ws.Cells[rowC + 1, 1].Value = aryDBBranch[rowC].Branch_Name.ToString();
                    ws.Cells[rowC + 1, 2].Value = aryDBBranch[rowC].Degree.ToString();
                }
                //
                // Header style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.Chocolate);
                tmpStyle.Font.Weight = ExcelFont.MaxWeight;
                tmpStyle.Font.Color = Color.White;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 2).Style = tmpStyle;
                //
                // save professor data in save2Excel.FileName path's
                //
                ef.SaveXls(save2Excel.FileName);
                //
                // Try to open created excel file's
                //
                try
                {
                    System.Diagnostics.Process.Start(save2Excel.FileName);
                }
                catch
                { }
            }
        }

        private void pbtnClassExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "ClassData.xls";
            save2Excel.FileName = "ClassData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                // If using Professional version, put your serial key below. Otherwise, keep following
                // line commented out as Free version doesn't have SetLicense method.
                // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
                var db = new LINQDataContext(); // for load from OLEDB  db.Class.mdf database file's
                ExcelFile ef = new ExcelFile();
                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                ef.LimitNear += new LimitEventHandler(ef_LimitNear);

                #region Class Worksheet's
                var aryDBClass = db.Classes.ToArray();
                ExcelWorksheet ws = ef.Worksheets.Add("Class");
                //
                // column header text
                ws.Cells[0, 0].Value = "Class ID";
                ws.Cells[0, 1].Value = "Professor ID (Priority)";
                ws.Cells[0, 2].Value = "Professor Name";
                ws.Cells[0, 3].Value = "Course ID";
                ws.Cells[0, 4].Value = "Course Name";
                ws.Cells[0, 5].Value = "Practical Unit";
                ws.Cells[0, 6].Value = "Theory Unit";
                ws.Cells[0, 7].Value = "Room Type";
                //
                // column width
                ws.Columns[0].Width = 15 * 256;
                ws.Columns[1].Width = 20 * 256;
                ws.Columns[2].Width = 30 * 256;
                ws.Columns[3].Width = 15 * 256;
                ws.Columns[4].Width = 30 * 256;
                ws.Columns[5].Width = 15 * 256;
                ws.Columns[6].Width = 15 * 256;
                ws.Columns[7].Width = 25 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                CellStyle tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.LightYellow);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                ws.Cells.GetSubrangeAbsolute(1, 0, aryDBClass.Length, 7).Style = tmpStyle;
                //
                // row data
                for (int rowC = 0; rowC < aryDBClass.Length; rowC++)
                {
                    ws.Cells[rowC + 1, 0].Value = aryDBClass[rowC].Class_ID;
                    //
                    // set Professor and Priority
                    //
                    var Professor = (from p in db.Priority_Professors
                                     join prof in db.Professors
                                         on p.Professor_ID equals prof.ID
                                     where p.Class_ID == aryDBClass[rowC].Class_ID
                                     select new
                                         {
                                             p.Professor_ID,
                                             p.Priority,
                                             prof.Name_Professor
                                         });
                    string professor_ID_Priority = "";
                    string prof_Name = "";
                    foreach (var anyProf in Professor)
                    {
                        professor_ID_Priority += anyProf.Professor_ID + "(" + anyProf.Priority + ")  ";
                        prof_Name += anyProf.Name_Professor + "  &  ";
                    }
                    if (prof_Name.Length >= 5) prof_Name = prof_Name.Substring(0, prof_Name.Length - 5);
                    //
                    ws.Cells[rowC + 1, 1].Value = professor_ID_Priority;
                    ws.Cells[rowC + 1, 2].Value = prof_Name;
                    ws.Cells[rowC + 1, 3].Value = aryDBClass[rowC].Course_ID;
                    ws.Cells[rowC + 1, 4].Value = aryDBClass[rowC].Course.Name_Course.ToString();
                    ws.Cells[rowC + 1, 5].Value = aryDBClass[rowC].Practical_unit;
                    ws.Cells[rowC + 1, 6].Value = aryDBClass[rowC].Theory_unit;
                    ws.Cells[rowC + 1, 7].Value = aryDBClass[rowC].RoomType.ToString();
                }
                //
                // Header style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.Chocolate);
                tmpStyle.Font.Weight = ExcelFont.MaxWeight;
                tmpStyle.Font.Color = Color.White;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 7).Style = tmpStyle;
                #endregion

                #region Group_ID_List Worksheet's
                var aryDBGroup_ID_List = db.Group_ID_Lists.ToArray();
                ws = ef.Worksheets.Add("Group_ID_List");
                //
                // column header text
                ws.Cells[0, 0].Value = "Class ID";
                ws.Cells[0, 1].Value = "Group ID";
                //
                // column width
                ws.Columns[0].Width = 15 * 256;
                ws.Columns[1].Width = 15 * 256;
                //
                // Header Hight
                ws.Rows[0].Height = 2 * 256;
                //
                // row data style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.AliceBlue);
                tmpStyle.Font.Weight = ExcelFont.BoldWeight;
                tmpStyle.Font.Color = Color.Black;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                ws.Cells.GetSubrangeAbsolute(1, 0, aryDBGroup_ID_List.Length, 1).Style = tmpStyle;
                //
                // row data
                for (int rowC = 0; rowC < aryDBGroup_ID_List.Length; rowC++)
                {
                    ws.Cells[rowC + 1, 0].Value = aryDBGroup_ID_List[rowC].Class_ID;
                    ws.Cells[rowC + 1, 1].Value = aryDBGroup_ID_List[rowC].Group_ID;
                }
                //
                // Header style's
                tmpStyle = new CellStyle();
                tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                tmpStyle.FillPattern.SetSolid(Color.Aqua);
                tmpStyle.Font.Weight = ExcelFont.MaxWeight;
                tmpStyle.Font.Color = Color.White;
                tmpStyle.WrapText = true;
                tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Medium);
                ws.Cells.GetSubrangeAbsolute(0, 0, 0, 1).Style = tmpStyle;
                #endregion
                //
                // save professor data in save2Excel.FileName path's
                //
                ef.SaveXls(save2Excel.FileName);
                //
                // Try to open created excel file's
                //
                try
                {
                    System.Diagnostics.Process.Start(save2Excel.FileName);
                }
                catch
                { }
            }
        }

        private void pbtnTermSchemeExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "TermSchemeData.xls";
            save2Excel.FileName = "TermSchemeData.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //
                    // delete exist file's
                    //
                    if (System.IO.File.Exists(save2Excel.FileName))
                        System.IO.File.Delete(save2Excel.FileName);
                    //
                    // If using Professional version, put your serial key below. Otherwise, keep following
                    // line commented out as Free version doesn't have SetLicense method.
                    // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");

                    ExcelFile ef = new ExcelFile();
                    ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                    ef.LimitNear += new LimitEventHandler(ef_LimitNear);

                    ExcelWorksheet ws = ef.Worksheets.Add("TermScheme");
                    int NumberSheet = 1;
                    int NumberFile = 1;

                    #region Set Header Text Data
                    object[,] headerText = new object[1, 9] {                                           
                                                            {"InRequisite Course ID", 
                                                            "InRequisite Course Name", 
                                                            "PreRequisite Course ID", 
                                                            "PreRequisite Course Name", 
                                                            "Course Type", 
                                                            "Practical", 
                                                            "Theory", 
                                                            "Course ID", 
                                                            "Course Name"}
                                                            };

                    for (int j = 0; j < 9; j++)
                        ws.Cells[1, j].Value = headerText[0, j];

                    ws.Cells[0, 11].Value = "Term NO";
                    ws.Cells[0, 11].Style.Font.Color = Color.White;
                    ws.Cells[0, 12].Value = "Branch ID";
                    ws.Cells[0, 12].Style.Font.Color = Color.White;
                    #endregion

                    #region Header Style's (Row[0~1] , Column[0~8])
                    CellStyle headStyle = new CellStyle();
                    headStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    headStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    headStyle.FillPattern.SetSolid(Color.Chocolate);
                    headStyle.Font.Weight = ExcelFont.BoldWeight;
                    headStyle.Font.Color = Color.White;
                    headStyle.WrapText = true;
                    headStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                    ws.Cells.GetSubrangeAbsolute(0, 0, 1, 8).Style = headStyle;
                    #endregion

                    #region Column width
                    // Column width of 13, 30, 13, 30, 16, 9, 9, 8, 40, 4 and 5 characters.
                    ws.Columns[0].Width = 13 * 256;
                    ws.Columns[1].Width = 30 * 256;
                    ws.Columns[2].Width = 13 * 256;
                    ws.Columns[3].Width = 30 * 256;
                    ws.Columns[4].Width = 16 * 256;
                    ws.Columns[5].Width = 9 * 256;
                    ws.Columns[6].Width = 9 * 256;
                    ws.Columns[7].Width = 8 * 256;
                    ws.Columns[8].Width = 40 * 256;
                    ws.Columns[9].Width = 4 * 256;
                    ws.Columns[10].Width = 5 * 256;
                    //
                    // set merged band
                    //
                    ws.Cells.GetSubrangeAbsolute(0, 0, 1, 0).Merged = true;
                    ws.Cells.GetSubrangeAbsolute(0, 1, 1, 1).Merged = true;
                    ws.Cells.GetSubrangeAbsolute(0, 2, 1, 2).Merged = true;
                    ws.Cells.GetSubrangeAbsolute(0, 3, 1, 3).Merged = true;
                    ws.Cells.GetSubrangeAbsolute(0, 4, 1, 4).Merged = true;
                    ws.Cells.GetSubrangeAbsolute(0, 5, 0, 6).Merged = true;
                    ws.Cells[0, 5].Value = "Unit";
                    ws.Cells.GetSubrangeAbsolute(0, 7, 1, 7).Merged = true;
                    ws.Cells.GetSubrangeAbsolute(0, 8, 1, 8).Merged = true;
                    #endregion

                    #region Term Style's
                    //
                    // Term Vertical Style's
                    //
                    CellStyle termStyle = new CellStyle();
                    termStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    termStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    termStyle.Font.Weight = ExcelFont.BoldWeight;
                    #endregion

                    #region Read Data from LINQ Database . . .
                    var db = new LINQDataContext();
                    var aryBranch = db.Branches.ToArray();
                    // read any branch term scheme
                    int firstRow = 2;
                    foreach (var branchGroup in aryBranch)
                    {
                        //db.TermSchemeLoad(branchGroup.ID_Branch).ToArray();
                        var aryBranchTermScheme = (from qCourse in db.Courses
                                                   where qCourse.Branch_ID == branchGroup.ID_Branch
                                                   orderby qCourse.TermNo.Value
                                                   select new
                                                   {
                                                       Term_No = qCourse.TermNo,
                                                       qCourse.Branch_ID,
                                                       qCourse.Course_ID,
                                                       qCourse.Name_Course,
                                                       qCourse.Type_Course,
                                                       qCourse.TheoryUnitNo,
                                                       qCourse.PracticalUnitNo,
                                                       qCourse.InRequisite_CourseID,
                                                       qCourse.PreRequisite_CourseID
                                                   }).ToArray();
                        //
                        // check if needs for other sheet or other file
                        //
                        if ((firstRow + aryBranchTermScheme.Length) > 150) // Go Next Sheet's
                        {
                            firstRow = 2;
                            if (NumberSheet > 5) // Go Next File's
                            {
                                NumberSheet = 1;
                                #region Save and open Excel file's
                                try
                                {
                                    //
                                    // Save in File *.xls
                                    //
                                    string NextFile = save2Excel.FileName.Substring(0, save2Excel.FileName.Length - 5) +
                                                                                 NumberFile.ToString() + ".xls";
                                    ef.SaveXls(NextFile);
                                    NumberFile++;
                                    ef = new ExcelFile();
                                    ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                                    ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                                    ws = ef.Worksheets.Add("TermScheme");
                                    //
                                    // Try to open created excel file's
                                    //
                                    System.Diagnostics.Process.Start(NextFile);
                                }
                                catch
                                { }
                                #endregion
                            }
                            else
                            {
                                NumberSheet++;
                                ws = ef.Worksheets.Add("TermScheme(" + NumberSheet.ToString() + ")");
                            }
                            //
                            // New Set Header
                            //
                            for (int j = 0; j < 9; j++)
                                ws.Cells[1, j].Value = headerText[0, j];

                            ws.Cells[0, 11].Value = "Term NO";
                            ws.Cells[0, 11].Style.Font.Color = Color.White;
                            ws.Cells[0, 12].Value = "Branch ID";
                            ws.Cells[0, 12].Style.Font.Color = Color.White;
                            //
                            // New Header Style
                            //
                            ws.Cells.GetSubrangeAbsolute(0, 0, 1, 8).Style = headStyle;
                            // 
                            #region Column width
                            // Column width of 13, 30, 13, 30, 16, 9, 9, 8, 40, 4 and 5 characters.
                            ws.Columns[0].Width = 13 * 256;
                            ws.Columns[1].Width = 30 * 256;
                            ws.Columns[2].Width = 13 * 256;
                            ws.Columns[3].Width = 30 * 256;
                            ws.Columns[4].Width = 16 * 256;
                            ws.Columns[5].Width = 9 * 256;
                            ws.Columns[6].Width = 9 * 256;
                            ws.Columns[7].Width = 8 * 256;
                            ws.Columns[8].Width = 40 * 256;
                            ws.Columns[9].Width = 4 * 256;
                            ws.Columns[10].Width = 5 * 256;
                            //
                            // set merged band
                            //
                            ws.Cells.GetSubrangeAbsolute(0, 0, 1, 0).Merged = true;
                            ws.Cells.GetSubrangeAbsolute(0, 1, 1, 1).Merged = true;
                            ws.Cells.GetSubrangeAbsolute(0, 2, 1, 2).Merged = true;
                            ws.Cells.GetSubrangeAbsolute(0, 3, 1, 3).Merged = true;
                            ws.Cells.GetSubrangeAbsolute(0, 4, 1, 4).Merged = true;
                            ws.Cells.GetSubrangeAbsolute(0, 5, 0, 6).Merged = true;
                            ws.Cells[0, 5].Value = "Unit";
                            ws.Cells.GetSubrangeAbsolute(0, 7, 1, 7).Merged = true;
                            ws.Cells.GetSubrangeAbsolute(0, 8, 1, 8).Merged = true;
                            #endregion
                        }
                        //
                        if (aryBranchTermScheme.Length > 0)
                        {
                            //
                            // BranchGroup Setting
                            //
                            CellRange mergedRange = ws.Cells.GetSubrangeAbsolute(firstRow, 10, (aryBranchTermScheme.Length - 1 + firstRow), 10);
                            mergedRange.Merged = true;
                            termStyle.FillPattern.SetSolid(Color.Gold);
                            mergedRange.Value = branchGroup.Branch_Name + " - " + branchGroup.Degree;
                            termStyle.Rotation = -90;
                            mergedRange.Style = termStyle;
                            string firstCell = "A" + (firstRow + 1).ToString();
                            string lastCell = "K" + (aryBranchTermScheme.Length + firstRow).ToString();
                            ws.Cells.GetSubrange(firstCell, lastCell).SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Double);
                            //
                            // read any term in a branch
                            //
                            Dictionary<int, int> anyTerm = new Dictionary<int, int>();
                            foreach (var row in aryBranchTermScheme)
                            {
                                if (anyTerm.ContainsKey(row.Term_No.Value))
                                    anyTerm[row.Term_No.Value]++;

                                else
                                    anyTerm.Add(row.Term_No.Value, 1);
                            }
                            // Notetion: the aryBranchTermScheme Order by Term_No in db.TermSchemeLoad
                            int indexRow = 0;
                            foreach (var term in anyTerm)
                            {
                                //
                                // Term Setting
                                //
                                mergedRange = ws.Cells.GetSubrangeAbsolute(firstRow, 9, term.Value + firstRow - 1, 9);
                                mergedRange.Merged = true;
                                Random rand = new Random();
                                int R = rand.Next(50, 255); // don't Black 0 or dark Color 0~30
                                int G = rand.Next(50, 255); // don't Black 0 or dark Color 0~30
                                int B = rand.Next(50, 255); // don't Black 0 or dark Color 0~30
                                termStyle.FillPattern.SetSolid(Color.FromArgb(R, G, B));
                                mergedRange.Value = "Term " + term.Key.ToString();
                                termStyle.IsTextVertical = true;
                                mergedRange.Style = termStyle;
                                firstCell = "A" + (firstRow + 1).ToString();
                                lastCell = "J" + (term.Value + firstRow).ToString();
                                ws.Cells.GetSubrange(firstCell, lastCell).SetBorders(MultipleBorders.Bottom | MultipleBorders.Right, Color.Black, LineStyle.Double);
                                //
                                // save term data in Excel file's from db.TermScheme
                                //
                                for (int end = firstRow; indexRow < term.Value + end - 2; indexRow++, firstRow++)
                                {
                                    try
                                    {
                                        if (aryBranchTermScheme[indexRow].Term_No == term.Key)
                                        {
                                            ExcelRow Row = ws.Rows[firstRow];
                                            Row.Height = 3 * 128;

                                            Row.Cells[0].Value = aryBranchTermScheme[indexRow].InRequisite_CourseID;
                                            Row.Cells[1].Value = fill_CourseName(aryBranchTermScheme[indexRow].InRequisite_CourseID);
                                            Row.Cells[2].Value = aryBranchTermScheme[indexRow].PreRequisite_CourseID;
                                            Row.Cells[3].Value = fill_CourseName(aryBranchTermScheme[indexRow].PreRequisite_CourseID);
                                            Row.Cells[4].Value = aryBranchTermScheme[indexRow].Type_Course;
                                            Row.Cells[5].Value = aryBranchTermScheme[indexRow].PracticalUnitNo.Value;
                                            Row.Cells[6].Value = aryBranchTermScheme[indexRow].TheoryUnitNo.Value;
                                            Row.Cells[7].Value = aryBranchTermScheme[indexRow].Course_ID;
                                            Row.Cells[8].Value = aryBranchTermScheme[indexRow].Name_Course;
                                            Row.Cells[11].Value = term.Key;
                                            Row.Cells[11].Style.Locked = true;
                                            Row.Cells[11].Style.FillPattern.PatternForegroundColor = Color.White;
                                            Row.Cells[11].Style.Font.Color = Color.White;
                                            Row.Cells[11].Style.FormulaHidden = true;
                                            Row.Cells[12].Value = aryBranchTermScheme[indexRow].Branch_ID;
                                            Row.Cells[12].Style.Locked = true;
                                            Row.Cells[12].Style.FillPattern.PatternForegroundColor = Color.White;
                                            Row.Cells[12].Style.Font.Color = Color.White;
                                            Row.Cells[12].Style.FormulaHidden = true;

                                            if (firstRow % 2 == 0)
                                                for (int col = 0; col < 9; col++)
                                                    Row.Cells[col].Style.FillPattern.SetSolid(Color.LightSkyBlue);
                                            else
                                                for (int col = 0; col < 9; col++)
                                                    Row.Cells[col].Style.FillPattern.SetSolid(Color.FromArgb(210, 210, 230));

                                            Row.Cells[8].Style.Font.Name = "Courier New";
                                            for (int col = 0; col < 9; col++)
                                            {
                                                Row.Cells[col].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                                                Row.Cells[col].Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                                                Row.Cells[col].Style.Borders[IndividualBorder.Right].LineStyle = LineStyle.Thin;
                                            }
                                        }
                                        else
                                            break;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                    //
                    // Line borders between Cell Setting
                    //
                    ws.Cells.GetSubrange("A1", "I2").SetBorders(MultipleBorders.Vertical | MultipleBorders.Top, Color.Black, LineStyle.Double);

                    #endregion

                    #region Save and open Excel file's
                    try
                    {
                        //
                        // Save in File *.xls
                        //
                        string NextFile;
                        if (NumberFile <= 1)
                            NextFile = save2Excel.FileName;
                        else
                        {
                            NextFile = save2Excel.FileName.Substring(0, save2Excel.FileName.Length - 5) +
                                                                          NumberFile.ToString() + ".xls";
                        }
                        ef.SaveXls(NextFile);
                        //
                        // Try to open created excel file's
                        //
                        System.Diagnostics.Process.Start(NextFile);
                    }
                    catch
                    { }
                    #endregion
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
            }
        }

        private string fill_CourseName(string course_id)
        {
            string strCourseID = "";
            string Course_Name = "";
            // compile string to some int ID to List<int> lstCourseID
            foreach (char cId in course_id.ToCharArray())
            {
                try
                {
                    if (char.IsDigit(cId))
                        strCourseID += cId.ToString();
                    else if (strCourseID != "")
                    {
                        Course_Name += (from CIN in new LINQDataContext().Courses
                                        where CIN.Course_ID == int.Parse(strCourseID)
                                        select CIN.Name_Course).ToArray()[0].ToString() + "  &  ";
                        strCourseID = "";
                    }
                }
                catch { }
            }

            Course_Name = (Course_Name.Length > 5) ? Course_Name.Substring(0, Course_Name.Length - 5) : Course_Name;
            return Course_Name;
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdExportAll = new SaveFileDialog();
            try
            {
                sfdExportAll.Title = "Export All Database file *.mdf";
                sfdExportAll.Filter = @"Database files|*.mdf";
                sfdExportAll.DefaultExt = "Backup.mdf";
                sfdExportAll.FileName = "Backup.mdf";
                sfdExportAll.AutoUpgradeEnabled = true;
                prbMain.Maximum = 100;

                if (sfdExportAll.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText("Copy.Log", sfdExportAll.FileName);
                        System.Diagnostics.Process.Start("DisconnectDB.exe");
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "اشکال در استخراج اطلاعات");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); return; }
            finally
            {
                sfdExportAll.Dispose();
            }
        }

        //--------------------------------------------------------------------------------
        #endregion

        #region Import From Excel files (*.xls)

        private void pbtnProfessorImport_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below. Otherwise, keep following
            // line commented out as Free version doesn't have SetLicense method.
            // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
            var db = new LINQDataContext(); // for save to OLEDB  db.Professor.mdf database file's
            ExcelFile ef = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xls";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelWorksheet sheet;
                try
                {
                    ef.LoadXls(openFromExcel.FileName);

                    sheet = ef.Worksheets["Professor"];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                int NumberSheet = 1;
                bool FirstRow = true;

            Loop: // for other sheets
                foreach (ExcelRow row in sheet.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            db.ProfessorSave(Convert.ToInt32(row.Cells[0].Value.ToString()),
                            (row.Cells[1].Value != null) ? row.Cells[1].Value.ToString() : "",
                            (row.Cells[2].Value != null) ? row.Cells[2].Value.ToString() : "",
                            (row.Cells[3].Value != null && row.Cells[3].Value.ToString().ValidateEmail()) ?
                                                           row.Cells[3].Value.ToString() : "",
                            (row.Cells[4].Value != null) ? row.Cells[4].Value.ToString() : "",
                            (row.Cells[5].Value != null) ? row.Cells[5].Value.ToString() : "");
                        }
                        catch { }
                    }
                    else FirstRow = false;
                }
                if (ef.Worksheets.Count > NumberSheet)
                {
                    NumberSheet++;
                    sheet = ef.Worksheets["Professor(" + NumberSheet.ToString() + ")"];
                    goto Loop;
                }
            }
        }

        private void pbtnCourseImport_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below. Otherwise, keep following
            // line commented out as Free version doesn't have SetLicense method.
            // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
            var db = new LINQDataContext(); // for save to OLEDB  db.Course.mdf database file's
            ExcelFile ef = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xls";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelWorksheet sheet;
                try
                {
                    ef.LoadXls(openFromExcel.FileName);

                    sheet = ef.Worksheets["Course"];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                int NumberSheet = 1;
                bool FirstRow = true;

            Loop: // for other sheets
                foreach (ExcelRow row in sheet.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            int intBuffer = 0;
                            decimal decBuffer = 0;
                            db.CourseSave(int.Parse(row.Cells[1].Value.ToString()), int.Parse(row.Cells[0].Value.ToString()),
                                int.Parse(row.Cells[2].Value.ToString()),
                                (row.Cells[10].Value != null) ? (string)row.Cells[10].Value.ToString() : "",
                                row.Cells[9].Value.ToString(),
                                decimal.TryParse(row.Cells[11].Value.ToString(), out decBuffer) ? decBuffer : 0,
                                int.TryParse(row.Cells[7].Value.ToString(), out intBuffer) ? intBuffer : 0,
                                int.TryParse(row.Cells[8].Value.ToString(), out intBuffer) ? intBuffer : 0,
                                (row.Cells[3].Value != null) ? (string)row.Cells[3].Value.ToString() : "",
                                (row.Cells[5].Value != null) ? (string)row.Cells[5].Value.ToString() : "");
                        }
                        catch { }
                    }
                    else FirstRow = false;
                }
                if (ef.Worksheets.Count > NumberSheet)
                {
                    NumberSheet++;
                    sheet = ef.Worksheets["Course(" + NumberSheet.ToString() + ")"];
                    goto Loop;
                }
            }
        }

        private void pbtnRoomImport_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below. Otherwise, keep following
            // line commented out as Free version doesn't have SetLicense method.
            // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
            var db = new LINQDataContext(); // for save to OLEDB  db.Room.mdf database file's
            ExcelFile ef = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xls";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelWorksheet sheet, sheet2;
                try
                {
                    ef.LoadXls(openFromExcel.FileName);

                    sheet = ef.Worksheets["Room"];
                    sheet2 = ef.Worksheets["Room_Type"];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                //
                // Room_Type Data
                //
                bool FirstRow = true;
                foreach (ExcelRow row in sheet2.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            db.Room_TypeSave(row.Cells[0].Value.ToString());
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    else FirstRow = false;
                }
                //
                // Room Data
                //
                FirstRow = true;
                foreach (ExcelRow row in sheet.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            int buffer = 0;
                            db.RoomSave(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                (row.Cells[1].Value != null) ? row.Cells[1].Value.ToString() : "NULL",
                                (row.Cells[2].Value != null) ? row.Cells[2].Value.ToString() : "",
                                (int.TryParse(row.Cells[3].Value.ToString(), out buffer)) ? buffer : 0);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    else FirstRow = false;
                }
            }
        }

        private void pbtnGroupImport_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below. Otherwise, keep following
            // line commented out as Free version doesn't have SetLicense method.
            // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
            var db = new LINQDataContext(); // for save to OLEDB  db.Group.mdf database file's
            ExcelFile ef = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xls";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelWorksheet sheet;
                try
                {
                    ef.LoadXls(openFromExcel.FileName);

                    sheet = ef.Worksheets["Group"];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                bool FirstRow = true;
                foreach (ExcelRow row in sheet.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            int size = 0;
                            int CourseID = 0;
                            db.GroupsSave(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                (row.Cells[1].Value != null) ? int.Parse(row.Cells[1].Value.ToString()) : 0,
                                (row.Cells[2].Value != null) ? bool.Parse(row.Cells[2].Value.ToString()) : true,
                                (int.TryParse(row.Cells[3].Value.ToString(), out CourseID)) ? CourseID : 0,
                                (int.TryParse(row.Cells[6].Value.ToString(), out size)) ? size : 0);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    else FirstRow = false;
                }
            }
        }

        private void pbtnBranchImport_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below. Otherwise, keep following
            // line commented out as Free version doesn't have SetLicense method.
            // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
            var db = new LINQDataContext(); // for save to OLEDB  db.Branches.mdf database file's
            ExcelFile ef = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xls";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelWorksheet sheet;
                try
                {
                    ef.LoadXls(openFromExcel.FileName);

                    sheet = ef.Worksheets["Branch"];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                bool FirstRow = true;
                foreach (ExcelRow row in sheet.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            db.BranchSave(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                (row.Cells[1].Value != null) ? row.Cells[1].Value.ToString() : "",
                                (row.Cells[2].Value != null) ? row.Cells[2].Value.ToString() : "");
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    else FirstRow = false;
                }
            }
        }

        private void pbtnClassImport_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below. Otherwise, keep following
            // line commented out as Free version doesn't have SetLicense method.
            // SpreadsheetInfo.SetLicense("YOUR-SERIAL-KEY-HERE");
            var db = new LINQDataContext(); // for save to OLEDB  db.Class.mdf database file's
            ExcelFile ef = new ExcelFile();
            OpenFileDialog openFromExcel = new OpenFileDialog();
            openFromExcel.Filter = @"Excel files|*.xls";
            if (openFromExcel.ShowDialog() == DialogResult.OK)
            {
                ExcelWorksheet sheetClass;
                ExcelWorksheet sheetGroup_ID_List;
                try
                {
                    ef.LoadXls(openFromExcel.FileName);
                    sheetClass = ef.Worksheets["Class"];
                    sheetGroup_ID_List = ef.Worksheets["Group_ID_List"];
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                #region Class Worksheet's
                bool FirstRow = true;
                foreach (ExcelRow row in sheetClass.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {

                            int buffer = 0;
                            db.ClassSave(Convert.ToInt32(row.Cells[0].Value.ToString()),
                                (int.TryParse(row.Cells[3].Value.ToString(), out buffer)) ? buffer : 0,
                                (int.TryParse(row.Cells[5].Value.ToString(), out buffer)) ? buffer : 0,
                                (int.TryParse(row.Cells[6].Value.ToString(), out buffer)) ? buffer : 0,
                                row.Cells[7].Value.ToString());
                            //
                            // Compile Professor ID (Priority)
                            //
                            saveAndCompile_Priority((row.Cells[1].Value != null) ?
                                                        row.Cells[1].Value.ToString() : " ",
                                                    Convert.ToInt32(row.Cells[0].Value.ToString()));
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    else FirstRow = false;
                }
                #endregion

                #region Group_ID_List Worksheet's
                FirstRow = true;
                foreach (ExcelRow row in sheetGroup_ID_List.Rows)
                {
                    if (!FirstRow)
                    {
                        try
                        {
                            int buffer_class = 0;
                            int buffer_group = 0;
                            db.Group_ID_ListSave(int.TryParse(row.Cells[1].Value.ToString(), out buffer_group) ? buffer_group : 0,
                                                 int.TryParse(row.Cells[0].Value.ToString(), out buffer_class) ? buffer_class : 0);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    else FirstRow = false;
                }
                #endregion
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

        Thread thImport;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdOpenAll = new OpenFileDialog();
            ofdOpenAll.Title = "Open Database file *.mdf";
            ofdOpenAll.Filter = @"Database files|*.mdf";
            ofdOpenAll.AutoUpgradeEnabled = true;
            ofdOpenAll.CheckFileExists = true;
            ofdOpenAll.CheckPathExists = true;
            prbMain.Maximum = 100;

            if (ofdOpenAll.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = ofdOpenAll.FileName;
                    thImport = new Thread(new ThreadStart(ImportMDF));
                    thImport.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "اشکال در بازیابی اطلاعات");
                }
                finally
                {
                    ResultControls.ResultForm._setting = new ResultControls.Setting(true);
                }
            }
            ofdOpenAll.Dispose();
        }
        private void ImportMDF()
        {
            try
            {
                Set_Cursor_Value("WaitCursor");
                var originDB = new LINQDataContext();
                var newDB = new LINQDataContext(FileName);
                Set_prbMain_Value(0);

                #region 1.  Professor DATA
                //
                // Delete old Professor data and Fill it by newDB data
                //
                var aryProfessor = newDB.Professors.ToArray();
                if (aryProfessor.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " + @"DELETE FROM dbo.Classroom_time "
                        + @"DELETE FROM dbo.Priority_Professor " + @"DELETE FROM dbo.Professor";
                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryProfessor)
                    {
                        originDB.ProfessorSave(row.ID, row.Name_Professor, row.Branch, row.Email, row.EducationDegree, row.Schedule);
                    }
                }
                #endregion
                Set_prbMain_Value(10);

                #region 2.  Branch DATA
                //
                // Delete old Branch data and Fill it by newDB data
                //
                var aryBranch = newDB.Branches.ToArray();
                if (aryBranch.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " + @"DELETE FROM dbo.Group_ID_List " + @"DELETE FROM dbo.Classroom_Time "
                        + @"DELETE FROM dbo.Class " + @"DELETE FROM dbo.Course "
                        + @"DELETE FROM dbo.Groups " + @"DELETE FROM dbo.Branch";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryBranch)
                    {
                        originDB.BranchSave(row.ID_Branch, row.Branch_Name, row.Degree);
                    }
                }
                #endregion
                Set_prbMain_Value(20);

                #region 3.  Room_Type DATA
                //
                // Delete old Room_Type data and Fill it by newDB data
                //
                var aryRoom_Type = newDB.Room_Types.ToArray();
                if (aryRoom_Type.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " + @"DELETE FROM dbo.Classroom_time "
                        + @"DELETE FROM dbo.Room " + @"DELETE FROM dbo.Priority_Professor "
                        + @"DELETE FROM dbo.Group_ID_List "
                        + @"DELETE FROM dbo.Class " + @"DELETE FROM dbo.Room_Type";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryRoom_Type)
                    {
                        originDB.Room_TypeSave(row.Type_Name);
                    }
                }
                #endregion
                Set_prbMain_Value(30);

                #region 4.  Course DATA
                //
                // Delete old Course data and Fill it by newDB data
                //
                var aryCourse = newDB.Courses.ToArray();
                if (aryCourse.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " + @"DELETE FROM dbo.Classroom_time "
                        + @"DELETE FROM dbo.Group_ID_List " + @"DELETE FROM dbo.Priority_Professor "
                        + @"DELETE FROM dbo.Class " + @"DELETE FROM dbo.Course";
                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryCourse)
                    {
                        originDB.CourseSave(row.Course_ID, row.Branch_ID,
                                            row.TermNo, row.Name_Course,
                                            row.Type_Course, row.CourseCode,
                                            row.TheoryUnitNo, row.PracticalUnitNo,
                                            row.InRequisite_CourseID, row.PreRequisite_CourseID);
                    }
                }
                #endregion
                Set_prbMain_Value(40);

                #region 5.  Groups DATA
                //
                // Delete old Group data and Fill it by newDB data
                //
                var aryGroup = newDB.Groups.ToArray();
                if (aryGroup.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " +
                                   @"DELETE FROM dbo.Group_ID_List " +
                                   @"DELETE FROM dbo.Groups";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryGroup)
                    {
                        originDB.GroupsSave(row.ID, row.Semester_Entry_Year, row.Semester_Entry_FS, row.Branch_Selection, row.Size_No);
                    }
                }
                #endregion
                Set_prbMain_Value(50);

                #region 6.  Room DATA
                //
                // Delete old Room data and Fill it by newDB data
                //
                var aryRoom = newDB.Rooms.ToArray();
                if (aryRoom.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " + @"DELETE FROM dbo.Classroom_time " + @"DELETE FROM dbo.Room";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryRoom)
                    {
                        originDB.RoomSave(row.Room_ID, row.Name_Room, row.Type_Room, row.Size_No);
                    }
                }
                #endregion
                Set_prbMain_Value(60);

                #region 7.  Class DATA
                //
                // Delete old Class data and Fill it by newDB data
                //
                var aryClass = newDB.Classes.ToArray();
                if (aryClass.Length > 0)
                {
                    string query = @"DELETE FROM dbo.New_GroupsPerClass " + @"DELETE FROM dbo.Group_ID_List " + @"DELETE FROM dbo.Classroom_Time "
                        + @"DELETE FROM dbo.Priority_Professor " + @"DELETE FROM dbo.Class";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryClass)
                    {
                        originDB.ClassSave(row.Class_ID, row.Course_ID, row.Practical_unit, row.Theory_unit, row.RoomType);
                    }
                }
                #endregion
                Set_prbMain_Value(70);

                #region 8.  Group_ID_List DATA
                //
                // Delete old Group_ID_List data and Fill it by newDB data
                //
                var aryGroup_ID_List = newDB.Group_ID_Lists.ToArray();
                if (aryGroup_ID_List.Length > 0)
                {
                    string query = @"DELETE FROM dbo.Group_ID_List";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryGroup_ID_List)
                    {
                        originDB.Group_ID_ListSave(row.Group_ID, row.Class_ID);
                    }
                }
                #endregion
                Set_prbMain_Value(80);

                #region 9.  Priority_Professor DATA
                //
                // Delete old Classroom_Time data and Fill it by newDB data
                //
                var aryPriority_Professor = newDB.Priority_Professors.ToArray();
                if (aryPriority_Professor.Length > 0)
                {
                    string query = @"DELETE FROM dbo.Priority_Professor";

                    originDB.ExecuteQuery<object>(query);
                    //
                    // read and save new data
                    //
                    foreach (var row in aryPriority_Professor)
                    {
                        originDB.Priority_ProfessorSave(row.Professor_ID, row.Class_ID, row.Priority);
                    }
                }
                #endregion
                Set_prbMain_Value(90);

                #region 10.  Classroom_Time DATA
                //
                // Delete old Classroom_Time data and Fill it by newDB data
                //
                var aryClassroom_Time = newDB.Classroom_Times.ToArray();
                var aryNew_GroupsPerClass = newDB.New_GroupsPerClasses.ToArray();
                if (aryClassroom_Time.Length > 0)
                {
                    originDB.Classroom_TimeDeleteAll();
                    //
                    // read and save new data about Classroom_Time
                    //
                    foreach (var row in aryClassroom_Time)
                    {
                        originDB.Classroom_TimeSave(row.Room_ID, row.Class_ID,
                            row.Professor_ID, row.StartTime, row.Duration, row.Day_No);
                    }
                    //
                    // read and save new data about New_GroupsPerClass
                    //
                    foreach (var row in aryNew_GroupsPerClass)
                    {
                        originDB.New_GroupsPerClassSave(row.Room_ID, row.Class_ID, row.StartTime, row.Day_No, row.Group_ID);
                    }
                }
                #endregion
                Set_prbMain_Value(98);

                originDB.Connection.Close();
                originDB.Dispose();
                newDB.Connection.Close();
                newDB.Dispose();
                Set_prbMain_Value(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "اشکال در بازیابی اطلاعات");
                thImport.Abort();
                return;
            }
            finally
            {
                Thread.CurrentThread.Join(1000);
                Set_prbMain_Value(0);
                Set_Cursor_Value("Default");
                bwExportBtnCheck.RunWorkerAsync();
                Thread.CurrentThread.Abort();
            }
        }

        #endregion

        #region Button_Click Event
        private void btnProfessor_Click(object sender, EventArgs e)
        {
            ProfessorForm profForm = new ProfessorForm();
            profForm.Show();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            BranchForCourseForm bfcForm = new BranchForCourseForm();
            bfcForm.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            RoomForm roomForm = new RoomForm();
            roomForm.Show();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            GroupsForm groupForm = new GroupsForm();
            groupForm.ShowDialog();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            try
            {
                ClassForm classForm = new ClassForm();
                classForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbtnStart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.pbtnStart.Image = global::MakeClassSchedule.Properties.Resources.ClassScheduleDown;
                this.pbtnStart.Location = new Point(pbtnStart.Location.X - 1, pbtnStart.Location.Y);
            }
        }

        private void pbtnStart_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.pbtnStart.Image = global::MakeClassSchedule.Properties.Resources.ClassScheduleNormal;
                this.pbtnStart.Location = new Point(pbtnStart.Location.X + 1, pbtnStart.Location.Y);
            }
        }

        private void pbtnStart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ResultControls.ResultForm RF = new ResultControls.ResultForm();
                this.Hide();
                RF.ShowDialog();
                this.Show();
            }
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            BranchForm branchForm = new BranchForm();
            branchForm.ShowDialog();
        }

        private void btnTermScheme_Click(object sender, EventArgs e)
        {
            TermSchemeForm termSchemeFrom = new TermSchemeForm();
            termSchemeFrom.Show();
        }
        #endregion

        #region Thread Invoked
        // ------------------------------------------------------------
        // This delegate enables asynchronous calls for setting
        // the Value property on a ProgressBar control.
        delegate void SetValueCallback(int v);
        private void Set_prbMain_Value(int v)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                if (this.prbMain.InvokeRequired)
                {
                    SetValueCallback d = new SetValueCallback(Set_prbMain_Value);
                    this.Invoke(d, new object[] { v });
                }
                else
                {
                    this.prbMain.Value = v;
                }
            }
            catch { }
        }
        //
        // ------------------------------------------------------------
        // This delegate enables asynchronous calls for setting
        // the Value property on a Mouse Cursor control.
        delegate void SetCursorValueCallback(string v);
        private void Set_Cursor_Value(string v)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                if (this.InvokeRequired)
                {
                    SetCursorValueCallback d = new SetCursorValueCallback(Set_Cursor_Value);
                    this.Invoke(d, new object[] { v });
                }
                else
                {
                    switch (v)
                    {
                        case "WaitCursor": this.Cursor = Cursors.WaitCursor;
                            break;
                        case "Default": this.Cursor = Cursors.Default;
                            break;
                        default: this.Cursor = Cursors.Default;
                            break;
                    }
                }
            }
            catch { }
        }
        // ------------------------------------------------------------
        //
        // This delegate enables asynchronous calls for setting
        // the Value property on a this control.
        delegate void SetThisValueCallback();
        private void Set_This_Value()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            try
            {
                if (this.InvokeRequired)
                {
                    SetCursorValueCallback d = new SetCursorValueCallback(Set_Cursor_Value);
                    this.Invoke(d);
                }
                else
                {
                    this.Refresh();
                    this.Invalidate();
                    this.DestroyHandle();
                }
            }
            catch { }
        }
        #endregion

        #region Check Export Button by Parallel programming
        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the Value property on a this Export Button control.
        /// </summary>
        /// <param name="pbtn"></param>
        /// <param name="En"></param>
        delegate void SetThisCallback(ref PictureBox pbtn, bool En);
        private void setCheckerWork(ref PictureBox pbtn, bool En)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetThisCallback(setCheckerWork), pbtn, En);
            }
            else
            {
                if (En)
                {
                    pbtn.Enabled = true;
                    pbtn.Image = global::MakeClassSchedule.Properties.Resources.Export_Normal;
                }
                else
                {
                    pbtn.Enabled = false;
                    pbtn.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;
                }
            }
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (!bwExportBtnCheck.IsBusy)
                bwExportBtnCheck.RunWorkerAsync();
        }
        private void bwExportBtnCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!LOCK)
            {
                #region Check Codes
                var db = new LINQDataContext();
                //
                // Professor Export
                //
                if (db.Professors.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnProfessorExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnProfessorExport, false);
                }
                //
                // Branch Export
                //
                if (db.Branches.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnBranchExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnBranchExport, false);
                }
                //
                // Course Export
                //
                if (db.Courses.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnCourseExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnCourseExport, false);
                }
                //
                // Room Export
                //
                if (db.Rooms.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnRoomExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnRoomExport, false);
                }
                //
                // Groups Export
                //
                if (db.Groups.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnGroupExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnGroupExport, false);
                }
                //
                // TermScheme Export
                //
                if (db.Courses.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnTermSchemeExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnTermSchemeExport, false);
                }
                //
                // Class Export
                //
                if (db.Classes.ToArray().Length > 0)
                {
                    setCheckerWork(ref pbtnClassExport, true);
                }
                else
                {
                    setCheckerWork(ref pbtnClassExport, false);
                }
                #endregion
                //
                // Garbage Collection Run to delete any object without Reference
                GC.Collect();
            }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Name = "Main";
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
        }

        #region ToolTipMenu Controls
        bool LOCK = false;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOCK = true;
            try
            {
                bool emptyDB = !(pbtnProfessorExport.Enabled | pbtnBranchExport.Enabled |
                             pbtnCourseExport.Enabled | pbtnRoomExport.Enabled |
                             pbtnGroupExport.Enabled | pbtnClassExport.Enabled);
                //
                // if Database have data then show a Warning for losing data
                if (!emptyDB)
                {
                    if (MessageBox.Show("Are you sure you want to permanently delete \n" +
                        "full database and create new database?", "Delete Old Database",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        var db = new LINQDataContext();
                        string query = @"DELETE FROM dbo.New_GroupsPerClass " +
                                       @"DELETE FROM dbo.Classroom_time " +
                                       @"DELETE FROM dbo.Priority_Professor " +
                                       @"DELETE FROM dbo.Professor " +
                                       @"DELETE FROM dbo.Group_ID_List " +
                                       @"DELETE FROM dbo.Groups " +
                                       @"DELETE FROM dbo.Room " +
                                       @"DELETE FROM dbo.Class " +
                                       @"DELETE FROM dbo.Room_Type " +
                                       @"DELETE FROM dbo.Course " +
                                       @"DELETE FROM dbo.Branch";

                        db.ExecuteQuery<object>(query);
                        //
                        // Disable Export Buttons
                        pbtnProfessorExport.Enabled = false;
                        pbtnProfessorExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;

                        pbtnBranchExport.Enabled = false;
                        pbtnBranchExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;

                        pbtnCourseExport.Enabled = false;
                        pbtnCourseExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;

                        pbtnRoomExport.Enabled = false;
                        pbtnRoomExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;

                        pbtnGroupExport.Enabled = false;
                        pbtnGroupExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;

                        pbtnClassExport.Enabled = false;
                        pbtnClassExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;

                        pbtnTermSchemeExport.Enabled = false;
                        pbtnTermSchemeExport.Image = global::MakeClassSchedule.Properties.Resources.Export_Disable;
                    }
                }
            }
            finally
            {
                LOCK = false;
            }

        }

        private void howDoIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpFile);
        }

        private void userAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option removed in this version!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RealtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
                HighToolStripMenuItem.Checked = false;
                AboveNormalToolStripMenuItem.Checked = false;
                NormalToolStripMenuItem.Checked = false;
                BelowNormalToolStripMenuItem.Checked = false;
                LowToolStripMenuItem.Checked = false;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
        }

        private void HighToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                RealtimeToolStripMenuItem.Checked = false;
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
                AboveNormalToolStripMenuItem.Checked = false;
                NormalToolStripMenuItem.Checked = false;
                BelowNormalToolStripMenuItem.Checked = false;
                LowToolStripMenuItem.Checked = false;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
        }

        private void AboveNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                RealtimeToolStripMenuItem.Checked = false;
                HighToolStripMenuItem.Checked = false;
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                NormalToolStripMenuItem.Checked = false;
                BelowNormalToolStripMenuItem.Checked = false;
                LowToolStripMenuItem.Checked = false;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
        }

        private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                RealtimeToolStripMenuItem.Checked = false;
                HighToolStripMenuItem.Checked = false;
                AboveNormalToolStripMenuItem.Checked = false;
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
                BelowNormalToolStripMenuItem.Checked = false;
                LowToolStripMenuItem.Checked = false;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
        }

        private void BelowNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                RealtimeToolStripMenuItem.Checked = false;
                HighToolStripMenuItem.Checked = false;
                AboveNormalToolStripMenuItem.Checked = false;
                NormalToolStripMenuItem.Checked = false;
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal;
                LowToolStripMenuItem.Checked = false;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
        }

        private void LowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                RealtimeToolStripMenuItem.Checked = false;
                HighToolStripMenuItem.Checked = false;
                AboveNormalToolStripMenuItem.Checked = false;
                NormalToolStripMenuItem.Checked = false;
                BelowNormalToolStripMenuItem.Checked = false;
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                ProcessPriorityToolStripMenuItem.ShowDropDown();
                SetPriorityToolStripMenuItem.ShowDropDown();
            }
        }

        private void SetAffinityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessorAffinityForm paf = new ProcessorAffinityForm();
            paf.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm AF = new AboutForm();
            AF.ShowDialog();
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int th = 0; th < System.Diagnostics.Process.GetCurrentProcess().Threads.Count; th++)
            {
                System.Diagnostics.Process.GetCurrentProcess().Threads[th].Dispose();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ResultControls.ResultForm RF = new ResultControls.ResultForm();
                this.Hide();
                RF.ShowDialog();
                this.Show();
            }
        }

    }
}


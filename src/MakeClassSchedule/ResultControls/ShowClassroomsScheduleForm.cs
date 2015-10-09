using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GemBox.Spreadsheet;

namespace MakeClassSchedule.ResultControls
{
    public partial class ShowClassroomsScheduleForm : Form
    {
        LINQDataContext DB = new LINQDataContext();
        //
        // a Tuple for save (null able decimal CourseCode, int numberStudents, string CourseName,
        // null able int Unit, string ProfessorName, string RoomName, string GroupsInfo, string TimeSchedule)
        List<Tuple<decimal?, int, string, int?, string, string, string, Tuple<string>>> lstClassroom =
            new List<Tuple<decimal?, int, string, int?, string, string, string, Tuple<string>>>();

        public ShowClassroomsScheduleForm()
        {
            InitializeComponent();
        }

        private void ShowClassroomsScheduleForm_Load(object sender, EventArgs e)
        {
            var classrooms = DB.Classroom_Times.ToList();
            foreach (var anyCR in classrooms)
            {
                int studentSize = 0;
                string groups = "";
                string TimeSchedule = "";
                //
                // set Groups Info
                foreach (var GIL in (from ng in DB.New_GroupsPerClasses
                                     join gr in DB.Groups on ng.Group_ID equals gr.ID
                                     where (ng.Day_No == anyCR.Day_No && 
                                            ng.StartTime == anyCR.StartTime && 
                                            ng.Room_ID == anyCR.Room_ID && 
                                            ng.Class_ID == anyCR.Class_ID)
                                     select gr).ToList()) 
                {
                    studentSize += GIL.Size_No;
                    //
                    groups += string.Format(System.Globalization.CultureInfo.CurrentCulture,
                        "{4}{0}  -  {1} {2}-{3}",
                        GIL.Branch.Branch_Name,
                        GIL.Branch.Degree,
                        GIL.Semester_Entry_Year,
                        GIL.Semester_Entry_FS ? "1" : "2",
                        (!string.IsNullOrEmpty(groups)) ? "   " + Environment.NewLine : ""); // New Line = "\n\r"
                }
                //
                // set TimeSchedule Info
                switch (anyCR.Day_No)
                {
                    case 0: TimeSchedule += "Saturday (";
                        break;
                    case 1: TimeSchedule += "Sunday (";
                        break;
                    case 2: TimeSchedule += "Monday (";
                        break;
                    case 3: TimeSchedule += "Tuesday (";
                        break;
                    case 4: TimeSchedule += "Wednesday (";
                        break;
                    case 5: TimeSchedule += "Thursday (";
                        break;
                    case 6: TimeSchedule += "Friday (";
                        break;
                }
                TimeSchedule += (anyCR.StartTime + 8).ToString() + " - " + (anyCR.StartTime + 8 + anyCR.Duration).ToString() + ")";
                //
                // fill DataGridView by classrooms data
                dgvClassroom.Rows.Add(new object[] 
                { 
                    anyCR.Class_ID, 
                    anyCR.Class.Course.CourseCode, 
                    studentSize,
                    anyCR.Class.Course.Name_Course,
                    anyCR.Class.Course.PracticalUnitNo + anyCR.Class.Course.TheoryUnitNo,
                    anyCR.Professor.Name_Professor,
                    anyCR.Room.Name_Room,
                    groups,
                    TimeSchedule
                });
                //
                // backup the dataGridView Data for Export to Excel
                lstClassroom.Add(
                    new Tuple<decimal?, int, string, int?, string, string, string, Tuple<string>>(
                            anyCR.Class.Course.CourseCode,
                            studentSize,
                            anyCR.Class.Course.Name_Course,
                            anyCR.Class.Course.PracticalUnitNo + anyCR.Class.Course.TheoryUnitNo,
                            anyCR.Professor.Name_Professor,
                            anyCR.Room.Name_Room,
                            groups,
                            new Tuple<string>(TimeSchedule)));
            }
            dgvClassroom.Focus();
        }

        private void ShowClassroomsScheduleForm_ClientSizeChanged(object sender, EventArgs e)
        {
            int xdCenterBtn = btnExportToExcel.Size.Width / 2;
            int xdCenterForm = this.Size.Width / 2;
            btnExportToExcel.Location = new Point(Math.Abs(xdCenterForm - xdCenterBtn), btnExportToExcel.Location.Y);
        }

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

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "ClassroomsSchedule.xls";
            save2Excel.FileName = "ClassroomsSchedule.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
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

                    ExcelWorksheet ws = ef.Worksheets.Add("RoomsSchedule");
                    int numberSheet = 1;
                    int numberFile = 1;
                    int startRow_No = 4;

                    #region Classroom title Style's
                    CellStyle classTitleStyle = new CellStyle();
                    classTitleStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    classTitleStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    classTitleStyle.Font.Weight = ExcelFont.BoldWeight;
                    classTitleStyle.FillPattern.SetSolid(Color.Azure);
                    classTitleStyle.Font.Color = Color.RoyalBlue;
                    classTitleStyle.WrapText = false;
                    classTitleStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                    #endregion

                    #region Header Style's (Example First Room:  Row[2~3] , Column[0~7])
                    CellStyle headerStyle = new CellStyle();
                    headerStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    headerStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    headerStyle.FillPattern.SetSolid(Color.Chocolate);
                    headerStyle.Font.Weight = ExcelFont.BoldWeight;
                    headerStyle.Font.Color = Color.White;
                    headerStyle.WrapText = true;
                    headerStyle.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
                    #endregion

                    #region Header Text Data
                    object[,] headerText = new object[1, 8] {                                           
                                                            {
                                                                "Course Code",
                                                                "Number of Students", 
                                                                "Course Name",
                                                                "Unit No.", 
                                                                "Professor Name", 
                                                                "Room Name", 
                                                                "Groups Info",
                                                                "Time Schedule"
                                                            }
                                                            };

                    #endregion

                    #region Column width
                    // Column width of 16, 16, 30, 10, 25, 20, 50, 30 characters.
                    ws.Columns[0].Width = 16 * 226;
                    ws.Columns[1].Width = 16 * 226;
                    ws.Columns[2].Width = 30 * 226;
                    ws.Columns[3].Width = 10 * 226;
                    ws.Columns[4].Width = 25 * 226;
                    ws.Columns[5].Width = 20 * 226;
                    ws.Columns[6].Width = 50 * 226;
                    ws.Columns[7].Width = 30 * 226;
                    #endregion

                    #region Any Cells Style's
                    CellStyle AnyCellStyle = new CellStyle();
                    AnyCellStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    AnyCellStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    AnyCellStyle.Font.Size = 14 * 16;
                    AnyCellStyle.Font.Weight = ExcelFont.BoldWeight;
                    AnyCellStyle.FillPattern.SetSolid(Color.White);
                    AnyCellStyle.Font.Color = Color.Black;
                    AnyCellStyle.WrapText = true;
                    AnyCellStyle.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
                    #endregion

                    #region Read any Classroom in DataGridView and Save in Excel files
                    bool FirstLine = true;
                    foreach (var cr in lstClassroom)
                    {
                    checkLoop:
                        if (FirstLine)
                        {
                            #region set First Line Styles
                            //
                            // set classroom title Style
                            ws.Cells.GetSubrangeAbsolute(0 , 0, 1 , 7).Style = classTitleStyle;
                            //
                            // classroom title text in Title
                            ws.Cells[0, 0].Value = "Classrooms Schedule";
                            //
                            // set Header Styles
                            ws.Cells.GetSubrangeAbsolute(2 , 0, 3 , 7).Style = headerStyle;
                            //
                            // set Header Text data
                            for (int j = 0; j < 8; j++)
                                ws.Cells[3 , j].Value = headerText[0, j];
                            //
                            // set Merged Band
                            #region Merged Band
                            //
                            // First Row for Room Name
                            ws.Cells.GetSubrangeAbsolute(0 , 0, 1 , 7).Merged = true;
                            //
                            // Second Row for Room Header "Course Code"
                            ws.Cells.GetSubrangeAbsolute(2 , 0, 3 , 0).Merged = true;
                            //
                            // Second Row for Room Header "Number of Students"
                            ws.Cells.GetSubrangeAbsolute(2 , 1, 3 , 1).Merged = true;
                            //
                            // Second Row for Room Header "Course Name"
                            ws.Cells.GetSubrangeAbsolute(2 , 2, 3 , 2).Merged = true;
                            //
                            // Second Row for Room Header "Unit No."
                            ws.Cells.GetSubrangeAbsolute(2 , 3, 3 , 3).Merged = true;
                            //
                            // Second Row for Room Header "Professor Name"
                            ws.Cells.GetSubrangeAbsolute(2 , 4, 3 , 4).Merged = true;
                            //
                            // Second Row for Room Header "Room Name"
                            ws.Cells.GetSubrangeAbsolute(2 , 5, 3 , 5).Merged = true;
                            //
                            // Second Row for Room Header "Groups Info"
                            ws.Cells.GetSubrangeAbsolute(2 , 6, 3 , 6).Merged = true;
                            //
                            // Second Row for Room Header "TimeSchedule Info"
                            ws.Cells.GetSubrangeAbsolute(2, 7, 3, 7).Merged = true;
                            #endregion
                            //
                            // set FirstLine to no
                            FirstLine = false;

                            #endregion
                        }
                        if (startRow_No + 1 <= 149) // Write in Exist Worksheet
                        {
                            #region Save in Excel Row by database.Classroom_Time 
                            //
                            // read any Classroom_Time for this Room and save that
                            #region Read and Save Cells by this room classrooms data
                            //-------------------------------------------------------------------------------------------------
                            ws.Cells[startRow_No, 0].Value = cr.Item1.Value; // Course Code data
                            ws.Cells[startRow_No, 0].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 1].Value = cr.Item2;       // Number of Students data
                            ws.Cells[startRow_No, 1].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 2].Value = cr.Item3;       // Course Name data
                            ws.Cells[startRow_No, 2].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 3].Value = cr.Item4.Value; // Unit No. data
                            ws.Cells[startRow_No, 3].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 4].Value = cr.Item5;       // Professor Name data
                            ws.Cells[startRow_No, 4].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 5].Value = cr.Item6;       // Room Name data
                            ws.Cells[startRow_No, 5].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 6].Value = cr.Item7;       // Groups Info data
                            ws.Cells[startRow_No, 6].Style = AnyCellStyle;
                            ws.Cells[startRow_No, 7].Value = cr.Rest.Item1;       // Time Schedule Info data
                            ws.Cells[startRow_No, 7].Style = AnyCellStyle;
                            //--------------------------------------------------------------------------------------------------
                            #endregion
                            //
                            // set to next step (add (2_Title + 2_Headers + 12_Row + 2_SpaceRow) = 18 step to start row)
                            startRow_No ++;
                            #endregion
                        }
                        else if (numberSheet > 5) // Go to Next File's
                        {
                            #region Save and open New Excel file's
                            try
                            {
                                //
                                // Save in File *.xls
                                //
                                numberFile++;
                                string NextFile = save2Excel.FileName.Substring(0, save2Excel.FileName.Length - 5) +
                                                                             numberFile.ToString() + ".xls";
                                ef.SaveXls(NextFile);
                                ef = new ExcelFile();
                                ef.LimitReached += new LimitEventHandler(ef_LimitReached);
                                ef.LimitNear += new LimitEventHandler(ef_LimitNear);
                                ws = ef.Worksheets.Add("ClassroomsSchedule");
                                //
                                // Try to open created excel file's
                                //
                                System.Diagnostics.Process.Start(NextFile);
                            }
                            finally
                            {
                                numberSheet = 1;
                                startRow_No = 4;
                                #region Column width
                                // Column width of 16, 16, 30, 10, 25, 20, 50, 30 characters.
                                ws.Columns[0].Width = 16 * 226;
                                ws.Columns[1].Width = 16 * 226;
                                ws.Columns[2].Width = 30 * 226;
                                ws.Columns[3].Width = 10 * 226;
                                ws.Columns[4].Width = 25 * 226;
                                ws.Columns[5].Width = 20 * 226;
                                ws.Columns[6].Width = 50 * 226;
                                ws.Columns[7].Width = 30 * 226;
                                #endregion
                            }
                            goto checkLoop;
                            #endregion
                        }
                        else // 150 row is complete go to next worksheet
                        {
                            #region Create New WorkSheet
                            startRow_No = 4;
                            numberSheet++;
                            ws = ef.Worksheets.Add("ClassroomsSchedule (" + numberSheet.ToString() + ")");
                            //
                            // set column width again
                            #region Column width
                            // Column width of 16, 16, 30, 10, 25, 20, 50, 30 characters.
                            ws.Columns[0].Width = 16 * 226;
                            ws.Columns[1].Width = 16 * 226;
                            ws.Columns[2].Width = 30 * 226;
                            ws.Columns[3].Width = 10 * 226;
                            ws.Columns[4].Width = 25 * 226;
                            ws.Columns[5].Width = 20 * 226;
                            ws.Columns[6].Width = 50 * 226;
                            ws.Columns[7].Width = 30 * 226;
                            #endregion
                            //
                            // go to check again
                            goto checkLoop;
                            #endregion
                        }
                    }
                    #endregion

                    #region Save and open Excel file's
                    try
                    {
                        //
                        // Save in File *.xls
                        //
                        string NextFile;
                        if (numberFile <= 1)
                            NextFile = save2Excel.FileName;
                        else
                        {
                            NextFile = save2Excel.FileName.Substring(0, save2Excel.FileName.Length - 5) +
                                                                          numberFile.ToString() + ".xls";
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
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

    }
}

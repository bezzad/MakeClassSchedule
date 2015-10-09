using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpannedDataGridView;
using System.Globalization;
using GemBox.Spreadsheet;

namespace MakeClassSchedule.ResultControls
{
    public partial class ShowGroupsScheduleForm : Form
    {
        public ShowGroupsScheduleForm()
        {
            InitializeComponent();
        }

        #region Properties

        LINQDataContext DB = new LINQDataContext();
        Dictionary<int, Group> _groups; // <int group_ID , Group group>

        Dictionary<int, Label> lblGroupList = new Dictionary<int, Label>();

        Dictionary<int, DataGridView> dgvList = new Dictionary<int, DataGridView>();

        static int Distance = 50 + 462; // 50 is free and 462 is dataGridView Height
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

        private void ShowGroupsScheduleForm_Load(object sender, EventArgs e)
        {
            //
            // Create Group List
            //
            _groups = new Dictionary<int, Group>();
            foreach(var anyGroup in DB.Groups)
            {
                _groups.Add(anyGroup.ID, anyGroup);
            }

            setPanelObj();
            //
            // add DataGridView
            //
            foreach (KeyValuePair<int, DataGridView> kvp in dgvList)
            {
                this.pGroups.Controls.Add(kvp.Value);
            }
            //
            // add Label
            //
            foreach (KeyValuePair<int, Label> kvp in lblGroupList)
            {
                this.pGroups.Controls.Add(kvp.Value);
            }
            //
            // Fill DataGridView by Data
            //
            FillDGV();
            //
            // Focus on Panel
            pGroups.Focus();
        }

        /// <summary>
        /// Set DataGridView and Label object's according by Groups for adding to Panel
        /// </summary>
        private void setPanelObj()
        {
            Point lastDGV_loc = new Point(12, 25);
            Point lastLBL_loc = new Point(12, 7);

            foreach (KeyValuePair<int, Group> g in _groups)
            {
                // set any Group just for once dataGridView in Panel
                if (!dgvList.ContainsKey(g.Key))
                {
                    //
                    // create new dataGridView for a Group
                    dgvList.Add(g.Key, Standard_dgv(lastDGV_loc, "dgv_" + g.Key.ToString()));
                    //
                    // create new label for a Group
                    lblGroupList.Add(g.Key, Standard_lbl(lastLBL_loc,
                        string.Format(CultureInfo.CurrentCulture,
                                      "Group: {0}  -  {1}  {2}-{3}     ,         ID: {4}",
                                      g.Value.Branch.Branch_Name,
                                      g.Value.Branch.Degree,
                                      g.Value.Semester_Entry_Year,
                                      g.Value.Semester_Entry_FS ? "1" : "2",
                                      g.Value.ID),
                        "lblGroup_" + g.Key.ToString()));
                    //
                    // new Location for a new Group
                    lastDGV_loc.Y += Distance;
                    lastLBL_loc.Y = lastDGV_loc.Y - 18;
                }
            }
        }

        /// <summary>
        /// Create a DataGridView according by a Location and Name
        /// </summary>
        /// <param name="location">Locate of DataGridView in Client Panel's</param>
        /// <param name="Name">Name of DataGridView</param>
        /// <returns>Created DataGridView's</returns>
        private DataGridView Standard_dgv(Point location, string Name)
        {
            DataGridView dgv = new DataGridView();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumnEx TimeSpans = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx SAT = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx SUN = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx MON = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx TUE = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx WED = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx THUR = new DataGridViewTextBoxColumnEx();
            DataGridViewTextBoxColumnEx FRI = new DataGridViewTextBoxColumnEx();
           
            #region DataGridViewTextBoxColumnEx TimeSpans
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TimeSpans.DefaultCellStyle = dataGridViewCellStyle2;
            TimeSpans.Frozen = true;
            TimeSpans.HeaderText = "Time Span";
            TimeSpans.Name = "TimeSpan";
            TimeSpans.ReadOnly = true;
            TimeSpans.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            TimeSpans.ToolTipText = "Class Time in Days";
            #endregion
           
            #region DataGridViewTextBoxColumnEx SAT
            SAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            SAT.DefaultCellStyle = dataGridViewCellStyle3;
            SAT.FillWeight = 90F;
            SAT.HeaderText = "SAT";
            SAT.Name = "SAT";
            SAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion
       
            #region DataGridViewTextBoxColumnEx SUN
            SUN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            SUN.DefaultCellStyle = dataGridViewCellStyle3;
            SUN.FillWeight = 90F;
            SUN.HeaderText = "SUN";
            SUN.Name = "SUN";
            SUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion
             
            #region DataGridViewTextBoxColumnEx MON
            MON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            MON.DefaultCellStyle = dataGridViewCellStyle3;
            MON.FillWeight = 90F;
            MON.HeaderText = "MON";
            MON.Name = "MON";
            MON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion
          
            #region DataGridViewTextBoxColumnEx TUE
            TUE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            TUE.DefaultCellStyle = dataGridViewCellStyle3;
            TUE.FillWeight = 90F;
            TUE.HeaderText = "TUE";
            TUE.Name = "TUE";
            TUE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion
            
            #region DataGridViewTextBoxColumnEx WED
            WED.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            WED.DefaultCellStyle = dataGridViewCellStyle3;
            WED.FillWeight = 90F;
            WED.HeaderText = "WED";
            WED.Name = "WED";
            WED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion

            #region DataGridViewTextBoxColumnEx THUR 
            THUR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            THUR.DefaultCellStyle = dataGridViewCellStyle3;
            THUR.FillWeight = 90F;
            THUR.HeaderText = "THUR";
            THUR.Name = "THUR";
            THUR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion
            
            #region DataGridViewTextBoxColumnEx FRI
            FRI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            FRI.DefaultCellStyle = dataGridViewCellStyle3;
            FRI.FillWeight = 90F;
            FRI.HeaderText = "FRI";
            FRI.Name = "FRI";
            FRI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            #endregion

            // 
            // Set Data for DataGridView dgv
            // 
            #region Define DataGridView dgv Body's
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                TimeSpans,
                                SAT,
                                SUN,
                                MON,
                                TUE,
                                WED,
                                THUR,
                                FRI});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgv.DefaultCellStyle = dataGridViewCellStyle10;
            dgv.GridColor = System.Drawing.SystemColors.ActiveCaption;
            dgv.Location = location;
            dgv.Name = Name;
            dgv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowTemplate.Height = 35;
            dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dgv.Size = new System.Drawing.Size(748, 462);
            dgv.ReadOnly = true;
            dgv.RightToLeft = (CultureInfo.CurrentCulture.EnglishName == "Persian" ||
                               CultureInfo.CurrentCulture.EnglishName == "Farsi") ? 
                               System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
            dgv.MultiSelect = false;
            #endregion
            //
            // Add TimeSlots Data (8 - 9 , 9 - 10 , 10 - 11 , ... , 19 - 20)
            //
            for (int i = 8; i < 20; i++)
            {
                dgv.Rows.Add(i.ToString() + " - " + (i + 1).ToString());
            }
            //
            // Clear any Selected
            dgv.ClearSelection();
            //
            // End
            return dgv;
        }

        /// <summary>
        /// Create a Label according by a Location and Name
        /// </summary>
        /// <param name="location">Locate of Label in Client Panel's</param>
        /// <param name="Name">Name of Label</param>
        /// <param name="Text">How Text to show in Label</param>
        /// <returns>Created Label's</returns>
        private Label Standard_lbl(Point location, string Text, string Name)
        {
            Label lbl = new Label();
            // 
            // Set Label Data
            // 
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            lbl.ForeColor = System.Drawing.Color.DarkRed;
            lbl.Location = location;
            lbl.Name = Name;
            lbl.Text = Text;
            //
            return lbl;
        }

        /// <summary>
        /// Fill DataGridViews by Group Data
        /// </summary>
        private void FillDGV()
        {
            Random rand = new Random(); // for Random Color.Argb
            //
            // Read any Group in _groups list's
            foreach (var g in _groups)
            {
                //
                // Find any classroom for this group
                List<MakeClassSchedule.Classroom_Time> lstClassrooms =
                    (from ng in DB.New_GroupsPerClasses
                     join cr in DB.Classroom_Times
                        on new { ng.Room_ID, ng.StartTime, ng.Day_No, ng.Class_ID } equals
                           new { cr.Room_ID, cr.StartTime, cr.Day_No, cr.Class_ID }
                     where g.Value.ID == ng.Group_ID
                     select cr).ToList();
                //
                // Read any classroom in this group
                Color cellColor = Color.FromArgb(rand.Next(70, 250), rand.Next(70, 250), rand.Next(70, 250));
                foreach (var cr in lstClassrooms)
                {
                    //
                    // Merge Cells according by classroom Unit (duration)
                    ((DataGridViewTextBoxCellEx)dgvList[g.Key][cr.Day_No + 1, cr.StartTime]).RowSpan = cr.Duration;
                    //
                    // Set back color
                    dgvList[g.Key][cr.Day_No + 1, cr.StartTime].Style.BackColor = cellColor;                                    
                    //
                    // Set cell value's
                    dgvList[g.Key][cr.Day_No + 1, cr.StartTime].Value =
                        string.Format(CultureInfo.CurrentCulture,
                            "{0}{4}{1}{4}{2}{4}{3}",
                            cr.Class.Course.Name_Course, // Course Name
                            cr.Class.Course.CourseCode,  // Course Code
                            cr.Professor.Name_Professor, // Professor Name 
                            cr.Room.Name_Room,          // Room Name
                            Environment.NewLine);   // NewLine = "\n\r"
                }
            }
        }

        public static void MergeRows(DataGridView gridView)
        {
            int Lenght = 1;
            int row = 0;
            bool Repeated = false;
            Random rand = new Random();
            for (int columnIndex = 0; columnIndex < gridView.ColumnCount; ++columnIndex)
            {
                for (int rowIndex = 0; rowIndex < gridView.RowCount - 1; ++rowIndex)
                {
                    row = rowIndex;
                    Lenght = 1;
                Loop:
                    if (gridView[columnIndex, rowIndex].Value != null && gridView[columnIndex, rowIndex + 1].Value != null)
                    {
                        if (gridView[columnIndex, rowIndex].Value.ToString() == gridView[columnIndex, rowIndex + 1].Value.ToString())
                        {
                            Lenght++;
                            if (rowIndex + 1 < gridView.RowCount - 1)
                            {
                                rowIndex++;
                                Repeated = true;
                                goto Loop;
                            }
                            else
                            {
                                ((DataGridViewTextBoxCellEx)gridView[columnIndex, row]).RowSpan = Lenght;
                                gridView[columnIndex, row].Style.BackColor =
                                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                            }
                        }
                        else if (Repeated)
                        {
                            ((DataGridViewTextBoxCellEx)gridView[columnIndex, row]).RowSpan = Lenght;
                            gridView[columnIndex, row].Style.BackColor =
                                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                            Repeated = false;
                        }
                    }
                    else if (Repeated)
                    {
                        ((DataGridViewTextBoxCellEx)gridView[columnIndex, row]).RowSpan = Lenght;
                        gridView[columnIndex, row].Style.BackColor =
                                    Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
                        Repeated = false;
                    }
                }
            }
        }

        public static void MergeRows(DataGridView gridView, Color mergedCells_Color)
        {
            int Lenght = 1;
            int row = 0;
            bool Repeated = false;
            Random rand = new Random();
            for (int columnIndex = 0; columnIndex < gridView.ColumnCount; ++columnIndex)
            {
                for (int rowIndex = 0; rowIndex < gridView.RowCount - 1; ++rowIndex)
                {
                    row = rowIndex;
                    Lenght = 1;
                Loop:
                    if (gridView[columnIndex, rowIndex].Value != null && gridView[columnIndex, rowIndex + 1].Value != null)
                    {
                        if (gridView[columnIndex, rowIndex].Value.ToString() == gridView[columnIndex, rowIndex + 1].Value.ToString())
                        {
                            Lenght++;
                            if (rowIndex + 1 < gridView.RowCount - 1)
                            {
                                rowIndex++;
                                Repeated = true;
                                goto Loop;
                            }
                            else
                            {
                                ((DataGridViewTextBoxCellEx)gridView[columnIndex, row]).RowSpan = Lenght;
                                gridView[columnIndex, row].Style.BackColor = mergedCells_Color;
                            }
                        }
                        else if (Repeated)
                        {
                            ((DataGridViewTextBoxCellEx)gridView[columnIndex, row]).RowSpan = Lenght;
                            gridView[columnIndex, row].Style.BackColor = mergedCells_Color;
                            Repeated = false;
                        }
                    }
                    else if (Repeated)
                    {
                        ((DataGridViewTextBoxCellEx)gridView[columnIndex, row]).RowSpan = Lenght;
                        gridView[columnIndex, row].Style.BackColor = mergedCells_Color;
                        Repeated = false;
                    }
                }
            }
        }

        private void ShowGroupsScheduleForm_ClientSizeChanged(object sender, EventArgs e)
        {
            int xdCenterBtn = btnExportToExcel.Size.Width / 2;
            int xdCenterForm = this.Size.Width / 2;
            btnExportToExcel.Location = new Point(Math.Abs(xdCenterForm - xdCenterBtn), btnExportToExcel.Location.Y);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "GroupsSchedule.xls";
            save2Excel.FileName = "GroupsSchedule.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                CheckListCellsTextDataForm CLCTDF = new CheckListCellsTextDataForm();
                //
                // check default items
                CLCTDF.chklstExportCell.Items.Clear();
                CLCTDF.chklstExportCell.Items.Add("Course Code", false);
                CLCTDF.chklstExportCell.Items.Add("Course Name", true);
                CLCTDF.chklstExportCell.Items.Add("Professor Name", false);
                CLCTDF.chklstExportCell.Items.Add("Room Name", false);
                //
                CheckedListBox chklstCTD_buffer = CLCTDF.chklstExportCell;
                CLCTDF.Location = new Point(btnExportToExcel.Location.X + this.Location.X + 7,
                    this.Location.Y + btnExportToExcel.Location.Y + btnExportToExcel.Size.Height + 32);
                CLCTDF.ShowDialog();
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

                    ExcelWorksheet ws = ef.Worksheets.Add("GroupsSchedule");
                    int numberSheet = 1;
                    int numberFile = 1;
                    int startRow_No = 0;

                    #region Group Name Style's
                    CellStyle GroupTitleStyle = new CellStyle();
                    GroupTitleStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    GroupTitleStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    GroupTitleStyle.Font.Weight = ExcelFont.BoldWeight;
                    GroupTitleStyle.FillPattern.SetSolid(Color.Azure);
                    GroupTitleStyle.Font.Color = Color.RoyalBlue;
                    GroupTitleStyle.WrapText = false;
                    GroupTitleStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
                    #endregion

                    #region Header Style's (Example First Group  Row[2~3] , Column[0~7])
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
                                                                "Time Slot",
                                                                "Saturday", 
                                                                "Sunday", 
                                                                "Monday", 
                                                                "Tuesday", 
                                                                "Wednesday", 
                                                                "Thursday", 
                                                                "Friday"
                                                            }
                                                            };

                    #endregion

                    #region Column width
                    // Column width of 16, 22, 22, 22, 22, 22, 22, 22 characters.
                    ws.Columns[0].Width = 16 * 226;
                    ws.Columns[1].Width = 22 * 226;
                    ws.Columns[2].Width = 22 * 226;
                    ws.Columns[3].Width = 22 * 226;
                    ws.Columns[4].Width = 22 * 226;
                    ws.Columns[5].Width = 22 * 226;
                    ws.Columns[6].Width = 22 * 226;
                    ws.Columns[7].Width = 22 * 226;
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

                    Random rand = new Random();
                    #region Read any Group in DataGridView and Save in Excel files
                    foreach (var g in _groups)
                    {
                    checkLoop:
                        if (startRow_No + 16 <= 149) // Write in Exist Worksheet
                        {
                            #region Save in Excel Row by database.Groups
                            //
                            // set Group Name Style
                            ws.Cells.GetSubrangeAbsolute(0 + startRow_No, 0, 1 + startRow_No, 7).Style = GroupTitleStyle;
                            //
                            // set Group Name text in Title
                            ws.Cells[0 + startRow_No, 0].Value = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                                      "Group: {0}  -  {1}  {2}-{3}     ,         ID: {4}",
                                      g.Value.Branch.Branch_Name,
                                      g.Value.Branch.Degree,
                                      g.Value.Semester_Entry_Year,
                                      g.Value.Semester_Entry_FS ? "1" : "2",
                                      g.Value.ID);
                            //
                            // set Header Styles
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 0, 3 + startRow_No, 7).Style = headerStyle;
                            //
                            // set Header Text data
                            for (int j = 0; j < 8; j++)
                                ws.Cells[3 + startRow_No, j].Value = headerText[0, j];
                            //
                            // set Merged Band
                            #region Merged Band
                            //
                            // First Row for Group Name
                            ws.Cells.GetSubrangeAbsolute(0 + startRow_No, 0, 1 + startRow_No, 7).Merged = true;
                            //
                            // Second Row for Group Header "Time Slot"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 0, 3 + startRow_No, 0).Merged = true;
                            //
                            // Second Row for Group Header "Saturday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 1, 3 + startRow_No, 1).Merged = true;
                            //
                            // Second Row for Group Header "Sunday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 2, 3 + startRow_No, 2).Merged = true;
                            //
                            // Second Row for Group Header "Monday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 3, 3 + startRow_No, 3).Merged = true;
                            //
                            // Second Row for Group Header "Tuesday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 4, 3 + startRow_No, 4).Merged = true;
                            //
                            // Second Row for Group Header "Wednesday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 5, 3 + startRow_No, 5).Merged = true;
                            //
                            // Second Row for Group Header "Thursday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 6, 3 + startRow_No, 6).Merged = true;
                            //
                            // Second Row for Group Header "Friday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 7, 3 + startRow_No, 7).Merged = true;
                            #endregion
                            //
                            // set Time Slot Styles
                            for (int row = 4; row < 12 + 4; row++)
                            {
                                ws.Cells[row + startRow_No, 0].Style = headerStyle; // headerStyle is equal by timeSlot Style
                                ws.Cells[row + startRow_No, 0].Value = string.Format("{0} ~ {1}", (row - 4) + 8, (row - 4) + 9);
                            }
                            //
                            // set all cells style's
                            for (int row = 0; row < 12; row++)
                                for (int column = 1; column < 8; column++)
                                {
                                    ws.Cells[row + startRow_No + 4, column].Style = AnyCellStyle;
                                }
                            //
                            // read any Classroom_Time for this Group and save that
                            #region Read and Save Cells by this Group classrooms data
                            //-------------------------------------------------------------------------------------------------
                            //
                            // Find any classroom for this group
                            List<MakeClassSchedule.Classroom_Time> lstClassrooms =
                                        (from ng in DB.New_GroupsPerClasses
                                         join cr in DB.Classroom_Times
                                            on new { ng.Room_ID, ng.StartTime, ng.Day_No, ng.Class_ID } equals
                                               new { cr.Room_ID, cr.StartTime, cr.Day_No, cr.Class_ID }
                                         where g.Value.ID == ng.Group_ID
                                         select cr).ToList();

                            Color cellColor = Color.FromArgb(rand.Next(70, 250), rand.Next(70, 250), rand.Next(70, 250));
                            foreach (var cr in lstClassrooms)
                            {
                                //
                                // 0. Course Code
                                // 1. Course Name
                                // 2. Professor Name
                                // 3. Room Name
                                string classesValue = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                                    "{0}{1}{2}{3}",
                                    (chklstCTD_buffer.GetItemChecked(1) ? cr.Class.Course.Name_Course + Environment.NewLine : string.Empty), // Course Name
                                    (chklstCTD_buffer.GetItemChecked(0) ? (cr.Class.Course.CourseCode.HasValue ? cr.Class.Course.CourseCode.Value : 0) + "\r\n" : ""), // Course Code
                                    (chklstCTD_buffer.GetItemChecked(2) ? cr.Professor.Name_Professor + Environment.NewLine : ""), // Professor Name
                                    (chklstCTD_buffer.GetItemChecked(3) ? cr.Room.Name_Room : "")); // Room Name 


                                int row = cr.StartTime;
                                int column = cr.Day_No + 1;
                                ws.Cells[row + startRow_No + 4, column].Value = classesValue;
                                ws.Cells[row + startRow_No + 4, column].Style.FillPattern.SetSolid(cellColor);
                                ws.Cells[row + startRow_No + 4, column].Style.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.DashDotDot);

                                try
                                {
                                    if (cr.Duration > 1)
                                        ws.Cells.GetSubrangeAbsolute(row + startRow_No + 4,
                                                                     column,
                                                                     (row + startRow_No + 4) + (cr.Duration - 1),
                                                                     column).Merged = true;
                                }
                                catch { } // maybe two class overlap in a cell

                                for (int d = 0; d < cr.Duration; d++)
                                    ws.Rows[row + startRow_No + 4 + d].AutoFit();
                                // ws.Rows[row + startRow_No + 4 + d].Height = 10 * 256;
                            }

                            //--------------------------------------------------------------------------------------------------
                            #endregion
                            //
                            // set to next step (add (2_Title + 2_Headers + 12_Row + 2_SpaceRow) = 18 step to start row)
                            startRow_No += 18;
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
                                ws = ef.Worksheets.Add("GroupsSchedule");
                                //
                                // Try to open created excel file's
                                //
                                System.Diagnostics.Process.Start(NextFile);
                            }
                            finally
                            {
                                numberSheet = 1;
                                startRow_No = 0;
                                #region Column width
                                // Column width of 16, 22, 22, 22, 22, 22, 22, 22 characters.
                                ws.Columns[0].Width = 16 * 226;
                                ws.Columns[1].Width = 22 * 226;
                                ws.Columns[2].Width = 22 * 226;
                                ws.Columns[3].Width = 22 * 226;
                                ws.Columns[4].Width = 22 * 226;
                                ws.Columns[5].Width = 22 * 226;
                                ws.Columns[6].Width = 22 * 226;
                                ws.Columns[7].Width = 22 * 226;
                                #endregion
                            }
                            goto checkLoop;
                            #endregion
                        }
                        else // 150 row is complete go to next worksheet
                        {
                            #region Create New WorkSheet
                            startRow_No = 0;
                            numberSheet++;
                            ws = ef.Worksheets.Add("GroupsSchedule (" + numberSheet.ToString() + ")");
                            //
                            // set column width again
                            #region Column width
                            // Column width of 16, 22, 22, 22, 22, 22, 22, 22 characters.
                            ws.Columns[0].Width = 16 * 226;
                            ws.Columns[1].Width = 22 * 226;
                            ws.Columns[2].Width = 22 * 226;
                            ws.Columns[3].Width = 22 * 226;
                            ws.Columns[4].Width = 22 * 226;
                            ws.Columns[5].Width = 22 * 226;
                            ws.Columns[6].Width = 22 * 226;
                            ws.Columns[7].Width = 22 * 226;
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

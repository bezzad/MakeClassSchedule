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
    public partial class ChangeRoomsDataForm : Form
    {
        #region Properties

        LINQDataContext db = new LINQDataContext();
        List<Classroom_Time> _classrooms;

        bool dataChanged = false;
        List<Classroom_Time> _ClassBuffer;
        List<New_GroupsPerClass> _GroupBuffer;

        Dictionary<int, Algorithm.Room> _rooms;
        Dictionary<int, Label> lblRoom = new Dictionary<int, Label>();

        Dictionary<int, DataGridView> dgvList = new Dictionary<int, DataGridView>();

        static Point LastDGV_Location;
        static Point LastLabel_Location;
        static int Distance = 50 + 462; // 50 is free and 462 is dgv Height

        //
        // Move Data Properties
        //
        int old_ColumnIndex, old_RowIndex, old_new_RowIndexDifferent;
        bool MoveData = false;
        string strValue;
        int rowSpan = 1;
        DataGridView old_dataGridView;
        bool CurrectCellRightClick = false;
        //
        // Cut and Copy Data Properties
        //

        bool Cut = false;
        bool Copy = false;
        int C_RowIndex, C_ColumnIndex, C_rowSpan, C_old_new_RowIndexDifferent;
        string C_strValue;
        DataGridView C_dataGridView;
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
            MessageBox.Show("Component for Excel files with a maximum sheet 5 and 150 line is.\n"+
                "http://www.gemboxsoftware.com/GBSpreadsheet.htm#Features", "Limit Reached");
        }
        private void ef_LimitNear(object sender, LimitEventArgs e)
        {
            e.WriteWarningWorksheet = false;
        }
        #endregion

        public ChangeRoomsDataForm()
        {
            InitializeComponent();

            //
            // Create Room List
            //
            _classrooms = db.Classroom_Times.AsParallel().Select(R => R).ToList();
            _ClassBuffer = db.Classroom_Times.AsParallel().Select(R => R).ToList(); // for reset chenged data
            _GroupBuffer = db.New_GroupsPerClasses.AsParallel().Select(G => G).ToList(); // for reset changed data
            _rooms = MakeClassSchedule.Algorithm.Configuration.GetInstance.Rooms;
            LastDGV_Location = new Point(12, 25);
            LastLabel_Location = new Point(12, 7);
            Create_FristTime();
            //
            // add DataGridView
            //
            foreach (KeyValuePair<int, DataGridView> kvp in dgvList)
            {
                this.pRooms.Controls.Add(kvp.Value);
            }
            //
            // add Label
            //
            foreach (KeyValuePair<int, Label> kvp in lblRoom)
            {
                this.pRooms.Controls.Add(kvp.Value);
            }
            //
            // Fill DataGridView by Data
            //
            FillDGV();
        }

        private void FillDGV()
        {
            Random rand = new Random();
            foreach (var cr in _classrooms)
            {
                ((DataGridViewTextBoxCellEx)dgvList[cr.Room_ID][cr.Day_No + 1, cr.StartTime]).RowSpan = cr.Duration;
                dgvList[cr.Room_ID][cr.Day_No + 1, cr.StartTime].Style.BackColor =
                                Color.FromArgb(rand.Next(70, 250), rand.Next(70, 250), rand.Next(70, 250));

                string groups_Name = "";
                var groups = (from n in db.New_GroupsPerClasses
                              join g in db.Groups on n.Group_ID equals g.ID
                              where ((n.Class_ID == cr.Class_ID) &&
                                     (n.Room_ID == cr.Room_ID) &&
                                     (n.StartTime == cr.StartTime) &&
                                     (n.Day_No == cr.Day_No))
                              select new
                              {
                                  GroupName = string.Format(CultureInfo.CurrentCulture, "{0}  {1}  {2}-{3}",
                                  g.Branch.Degree, g.Branch.Branch_Name, g.Semester_Entry_Year, (g.Semester_Entry_FS ? "1" : "2"))
                              }).ToList();
                //
                foreach (var gs in groups)
                {
                    groups_Name += gs.GroupName + "\r\n";
                }
                groups_Name = groups_Name.Trim();

                dgvList[cr.Room_ID][cr.Day_No + 1, cr.StartTime].Value = string.Format(CultureInfo.CurrentCulture,
                    "{0}\r\n{1}\r\n{2}\r\n{3}", cr.Class.Course.Name_Course, cr.Professor.Name_Professor, groups_Name, cr.Room.Type_Room);
            }
        }

        private void Create_FristTime()
        {
            //foreach (var cr in _classrooms)
            foreach (KeyValuePair<int, Algorithm.Room> cr in _rooms)
            {
                if (!dgvList.ContainsKey(cr.Value.Origin_ID_inDB))
                {
                    //
                    // create new dataGridView for a Room
                    dgvList.Add(cr.Value.Origin_ID_inDB, Standard_dgv(LastDGV_Location, "dgv_" + cr.Value.Origin_ID_inDB.ToString()));
                    //
                    // create new label for a Room
                    lblRoom.Add(cr.Value.Origin_ID_inDB, Standard_lbl(LastLabel_Location,
                        string.Format("Room: {0}   ,   NumberOfSeats: {1}    ,   Lab: {2}     ,   ID: {3}",
                        cr.Value.GetName, cr.Value.GetNumberOfSeats.ToString(), cr.Value.GetLab, cr.Value.Origin_ID_inDB),
                        "lblRoom_" + cr.Value.Origin_ID_inDB.ToString()));
                    //
                    // new Location for a new Room
                    LastDGV_Location.Y += Distance;
                    LastLabel_Location.Y = LastDGV_Location.Y - 18;
                }
            }
        }

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
            // 
            // TimeSpans
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TimeSpans.DefaultCellStyle = dataGridViewCellStyle2;
            TimeSpans.Frozen = true;
            TimeSpans.HeaderText = "Time Span";
            TimeSpans.Name = "TimeSpan";
            TimeSpans.ReadOnly = true;
            TimeSpans.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            TimeSpans.ToolTipText = "Class Time in Days";
            // 
            // SAT
            // 
            SAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            SAT.DefaultCellStyle = dataGridViewCellStyle3;
            SAT.FillWeight = 90F;
            SAT.HeaderText = "SAT";
            SAT.Name = "SAT";
            SAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SUN
            // 
            SUN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            SUN.DefaultCellStyle = dataGridViewCellStyle3;
            SUN.FillWeight = 90F;
            SUN.HeaderText = "SUN";
            SUN.Name = "SUN";
            SUN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MON
            // 
            MON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            MON.DefaultCellStyle = dataGridViewCellStyle3;
            MON.FillWeight = 90F;
            MON.HeaderText = "MON";
            MON.Name = "MON";
            MON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TUE
            // 
            TUE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            TUE.DefaultCellStyle = dataGridViewCellStyle3;
            TUE.FillWeight = 90F;
            TUE.HeaderText = "TUE";
            TUE.Name = "TUE";
            TUE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WED
            // 
            WED.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            WED.DefaultCellStyle = dataGridViewCellStyle3;
            WED.FillWeight = 90F;
            WED.HeaderText = "WED";
            WED.Name = "WED";
            WED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // THUR
            // 
            THUR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            THUR.DefaultCellStyle = dataGridViewCellStyle3;
            THUR.FillWeight = 90F;
            THUR.HeaderText = "THUR";
            THUR.Name = "THUR";
            THUR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FRI
            // 
            FRI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            FRI.DefaultCellStyle = dataGridViewCellStyle3;
            FRI.FillWeight = 90F;
            FRI.HeaderText = "FRI";
            FRI.Name = "FRI";
            FRI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv
            // 
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
                               CultureInfo.CurrentCulture.EnglishName == "Farsi") ? System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
            dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_CellMouseDown);
            dgv.CellMouseUp += new DataGridViewCellMouseEventHandler(dgv_CellMouseUp);
            dgv.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgv_CellMouseDoubleClick);
            dgv.KeyDown += new KeyEventHandler(dgv_KeyDown);
            dgv.MultiSelect = false;
            //
            // Add TimeSlots Data
            //
            for (int i = 8; i < 20; i++)
            {
                dgv.Rows.Add(i.ToString() + " - " + (i + 1).ToString());
            }
            //
            dgv.ClearSelection();
            return dgv;
        }

        void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (((DataGridView)sender).SelectedCells.Count == 1 && e.KeyData == Keys.Delete)
            {
                old_ColumnIndex = ((DataGridView)sender).SelectedCells[0].ColumnIndex;
                old_RowIndex = ((DataGridView)sender).SelectedCells[0].RowIndex;
                old_dataGridView = (DataGridView)sender;
                if (old_ColumnIndex > 0 && old_RowIndex >= 0)
                {
                    //
                    // Find Currect Place for first cell
                    for (int i = old_RowIndex; i >= 0; i--)
                        if (old_dataGridView[old_ColumnIndex, i].Value != null)
                        {
                            if (old_dataGridView[old_ColumnIndex, old_RowIndex].Value.ToString() == old_dataGridView[old_ColumnIndex, i].Value.ToString())
                            {
                                old_RowIndex = i;
                            }
                            else break;
                        }
                    //
                    CurrectCellRightClick = true;
                    toolStripMenuItemDelete_Click(sender, e);
                }
            }
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //
            // End of Works
            ((DataGridView)sender).ClearSelection();
        }

        private Label Standard_lbl(Point location, string Text, string Name)
        {
            Label lblRoom = new Label();
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            lblRoom.ForeColor = System.Drawing.Color.DarkRed;
            lblRoom.Location = location;
            lblRoom.Name = Name;
            lblRoom.Text = Text;
            //
            return lblRoom;
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

        private void Reset_dataGridView(DataGridView sender)
        {
            sender.Rows.Clear();
            //
            // Add TimeSlots Data
            //
            for (int i = 8; i < 20; i++)
            {
                sender.Rows.Add(string.Format(CultureInfo.CurrentCulture, "{0} - {1}", i, (i + 1)));
            }
            dataChanged = false;
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            CurrectCellRightClick = false;
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                if (((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    toolStripMenuItemCopy.Enabled = true;
                    toolStripMenuItemCut.Enabled = true;
                    toolStripMenuItemEdit.Enabled = true;
                    toolStripMenuItemDelete.Enabled = true;

                    this.Cursor = (e.Button == System.Windows.Forms.MouseButtons.Left) ? Cursors.NoMove2D : Cursors.Default;
                    MoveData = (e.Button == System.Windows.Forms.MouseButtons.Left);
                    old_ColumnIndex = e.ColumnIndex;
                    old_new_RowIndexDifferent = old_RowIndex = e.RowIndex;
                    strValue = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value.ToString();
                    //
                    // Find Currect Place for first cell
                    for (int i = e.RowIndex; i >= 0; i--)
                        if (((DataGridView)sender)[e.ColumnIndex, i].Value != null)
                        {
                            if (((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value.ToString() == ((DataGridView)sender)[e.ColumnIndex, i].Value.ToString())
                            {
                                old_RowIndex = i;
                            }
                            else break;
                        }
                    //
                    old_dataGridView = (DataGridView)sender;
                    rowSpan = ((DataGridViewTextBoxCellEx)((DataGridView)sender)[old_ColumnIndex, old_RowIndex]).RowSpan;
                    CurrectCellRightClick = (e.Button == System.Windows.Forms.MouseButtons.Right);
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right) // for Paste or Delete or Edit data
                {
                    toolStripMenuItemCopy.Enabled = false;
                    toolStripMenuItemCut.Enabled = false;
                    toolStripMenuItemEdit.Enabled = false;
                    toolStripMenuItemDelete.Enabled = false;

                    old_ColumnIndex = e.ColumnIndex;
                    old_new_RowIndexDifferent = old_RowIndex = e.RowIndex;
                    old_dataGridView = (DataGridView)sender;
                    CurrectCellRightClick = (e.Button == System.Windows.Forms.MouseButtons.Right);
                }
            }
        }

        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    if ((e.RowIndex != old_RowIndex || e.ColumnIndex != old_ColumnIndex) && MoveData && (e.RowIndex + rowSpan - 1) < ((DataGridView)sender).RowCount)
                    {
                        for (int r = e.RowIndex; r < e.RowIndex + rowSpan; r++)
                            if (((DataGridView)sender)[e.ColumnIndex, r].Value != null) // check for empty place to paste old cell data
                                if (((DataGridView)sender)[e.ColumnIndex, r].Value.ToString() != strValue) // Move in self place
                                    goto ExitUP;
                        if (old_new_RowIndexDifferent == e.RowIndex && e.ColumnIndex == old_ColumnIndex && old_dataGridView == (DataGridView)sender) goto ExitUP;
                        //
                        // Clear Old Cell
                        //
                        Color bcBuffer = old_dataGridView[old_ColumnIndex, old_RowIndex].Style.BackColor;
                        old_dataGridView[old_ColumnIndex, old_RowIndex].Style.BackColor = Color.White;
                        old_dataGridView[old_ColumnIndex, old_RowIndex].Value = null;
                        ((DataGridViewTextBoxCellEx)old_dataGridView[old_ColumnIndex, old_RowIndex]).RowSpan = 1;
                        //
                        // Create New Cell
                        //
                        ((DataGridViewTextBoxCellEx)((DataGridView)sender)[e.ColumnIndex, e.RowIndex]).RowSpan = rowSpan;
                        ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value = strValue;
                        ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Style.BackColor = bcBuffer;
                        //
                        if (!changeRoomSlot(old_dataGridView, old_ColumnIndex, old_RowIndex, (DataGridView)sender, e.ColumnIndex, e.RowIndex, rowSpan, true))
                        {
                            RefreshDGV((DataGridView)sender);
                        }
                        if (((DataGridView)sender).Name != old_dataGridView.Name)
                        {
                            RefreshDGV((DataGridView)sender);
                            RefreshDGV(old_dataGridView);
                        }
                        Cut = false;
                        Copy = false;
                        toolStripMenuItemPaste.Enabled = false;
                    }
                }
                catch
                {
                    goto ExitUP;
                }
            }
        ExitUP:
            MoveData = false;
            this.Cursor = Cursors.Default;
            ((DataGridView)sender).ClearSelection();

            if (CurrectCellRightClick)
            {
                old_dataGridView[old_ColumnIndex, old_RowIndex].Selected = true;
            }
        }

        /// <summary>
        /// Reset Changed DataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        private void RefreshDGV(DataGridView dataGridView)
        {
            int Roomkey = (from t in dgvList
                           where t.Value == dataGridView
                           select t.Key).Single();

            var aryC = (from c in db.Classroom_Times
                        where (c.Room_ID == Roomkey)
                        select c).ToList();

            //
            // Clear dgv Rows and reDraw
            //
            Reset_dataGridView(dataGridView);
            //
            // Fill Data
            //
            Random rand = new Random();
            foreach (var C in aryC)
            {
                ((DataGridViewTextBoxCellEx)dataGridView[C.Day_No + 1, C.StartTime]).RowSpan = C.Duration;
                dataGridView[C.Day_No + 1, C.StartTime].Style.BackColor = Color.FromArgb(rand.Next(70, 250), rand.Next(70, 250), rand.Next(70, 250));

                string groups_Name = "";
                var groups = (from n in db.New_GroupsPerClasses
                              join g in db.Groups on n.Group_ID equals g.ID
                              where ((n.Class_ID == C.Class_ID) &&
                                     (n.Room_ID == C.Room_ID) &&
                                     (n.StartTime == C.StartTime) &&
                                     (n.Day_No == C.Day_No))
                              select new
                              {
                                  GroupName = string.Format(CultureInfo.CurrentCulture, "{0}  {1}  {2}-{3}",
                                  g.Branch.Degree, g.Branch.Branch_Name, g.Semester_Entry_Year, (g.Semester_Entry_FS ? "1" : "2"))
                              }).ToList();
                //
                foreach (var gs in groups)
                {
                    groups_Name += gs.GroupName + "\r\n";
                }
                groups_Name = groups_Name.Trim();

                dataGridView[C.Day_No + 1, C.StartTime].Value = string.Format(CultureInfo.CurrentCulture,
                    "{0}\r\n{1}\r\n{2}\r\n{3}", C.Class.Course.Name_Course, C.Professor.Name_Professor, groups_Name, C.Room.Type_Room);
            }
        }

        /// <summary>
        /// Receive last dataGridView and Cell Position and change it by
        /// new cell Position.
        /// if in a cell exist more than one data ==>  return false for refresh data.
        /// else ==> return true
        /// </summary>
        /// <param name="old_DataGridView"></param>
        /// <param name="old_ColumnIndex"></param>
        /// <param name="old_RowIndex"></param>
        /// <param name="new_DataGridView"></param>
        /// <param name="new_ColumnIndex"></param>
        /// <param name="new_RowIndex"></param>
        /// <param name="duration"></param>
        /// <returns>One or More data in a cell exist?</returns>
        private bool changeRoomSlot(DataGridView old_DataGridView, int old_ColumnIndex, int old_RowIndex,
                                    DataGridView new_DataGridView, int new_ColumnIndex, int new_RowIndex,
                                    int duration, bool _cut)
        {
            bool OneData = true; // for refresh more than on data in a cell's

            int old_Roomkey = (from t in dgvList
                               where t.Value == old_DataGridView
                               select t.Key).Single();

            int new_Roomkey = (from t in dgvList
                               where t.Value == new_DataGridView
                               select t.Key).Single();

            int old_StartTime, new_StartTime, old_DayNo, new_DayNo;

            old_DayNo = old_ColumnIndex - 1;
            new_DayNo = new_ColumnIndex - 1;
            old_StartTime = old_RowIndex;
            new_StartTime = new_RowIndex;

            var aryCp = (from c in db.Classroom_Times
                         where ((c.Day_No == old_DayNo) && (c.Room_ID == old_Roomkey) && (c.StartTime == old_StartTime))
                         select new
                         {
                             c.Class_ID,
                             c.Professor_ID
                         }).ToArray();

            if (aryCp.Length < 1) return false; // Error
            var cp = aryCp[aryCp.Length - 1];
            OneData = (aryCp.Length > 1) ? false : true;

            List<int> groups = (from g in db.New_GroupsPerClasses
                                where ((g.Class_ID == cp.Class_ID) && (g.Day_No == old_DayNo) && (g.Room_ID == old_Roomkey) && (g.StartTime == old_StartTime))
                                select g.Group_ID).ToList();

            if (_cut) // Cut Old data and paste in new Place
                db.Classroom_TimeEdit(old_Roomkey, new_Roomkey, cp.Class_ID, cp.Class_ID, cp.Professor_ID,
                    old_StartTime, new_StartTime, duration, old_DayNo, new_DayNo);
            else // Copy Old data in new Place
                db.Classroom_TimeSave(new_Roomkey, cp.Class_ID, cp.Professor_ID, new_StartTime, duration, new_DayNo);

            foreach (int g in groups)
                db.New_GroupsPerClassSave(new_Roomkey, cp.Class_ID, new_StartTime, new_DayNo, g);

            //
            // Check other class in old class duration's
            //
            for (int sTd = old_StartTime + 1; sTd < old_StartTime + duration; sTd++)
            {
                var otherC = (from c in db.Classroom_Times
                              where ((c.Day_No == old_DayNo) && (c.Room_ID == old_Roomkey) && (c.StartTime == sTd))
                              select c).ToArray();
                if (otherC.Length > 0) return false; // More than one Class exist in old_StartTime Slot's!        
            }
            //
            dataChanged = true;
            return OneData;
        }

        private void toolStripMenuItemCut_Click(object sender, EventArgs e)
        {
            if (CurrectCellRightClick)
            {
                C_ColumnIndex = old_ColumnIndex;
                C_rowSpan = rowSpan;
                C_RowIndex = old_RowIndex;
                C_dataGridView = old_dataGridView;
                C_strValue = strValue;
                C_old_new_RowIndexDifferent = old_new_RowIndexDifferent;

                Cut = true;
                Copy = false;
                toolStripMenuItemPaste.Enabled = true;
                old_dataGridView.ClearSelection();
            }
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (CurrectCellRightClick)
            {
                C_ColumnIndex = old_ColumnIndex;
                C_rowSpan = rowSpan;
                C_RowIndex = old_RowIndex;
                C_dataGridView = old_dataGridView;
                C_strValue = strValue;
                C_old_new_RowIndexDifferent = old_new_RowIndexDifferent;

                Cut = false;
                Copy = true;
                toolStripMenuItemPaste.Enabled = true;
                old_dataGridView.ClearSelection();
            }
        }

        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            if (CurrectCellRightClick && toolStripMenuItemPaste.Enabled)
            {
                try
                {
                    if ((C_RowIndex != old_RowIndex || C_ColumnIndex != old_ColumnIndex) && (Cut || Copy) && (old_RowIndex + C_rowSpan - 1) < old_dataGridView.RowCount)
                    {
                        for (int r = old_RowIndex; r < old_RowIndex + C_rowSpan; r++)
                            if (old_dataGridView[old_ColumnIndex, r].Value != null) // check for empty place to paste old cell data
                                if (old_dataGridView[old_ColumnIndex, r].Value.ToString() != C_strValue) // Paste in self place
                                    goto ExitUP;
                        if (C_old_new_RowIndexDifferent == old_RowIndex && old_ColumnIndex == C_ColumnIndex && C_dataGridView == old_dataGridView) goto ExitUP;
                        //
                        // Clear Old Cell
                        //
                        Color bcBuffer = C_dataGridView[C_ColumnIndex, C_RowIndex].Style.BackColor;
                        if (Cut)
                        {
                            C_dataGridView[C_ColumnIndex, C_RowIndex].Style.BackColor = Color.White;
                            C_dataGridView[C_ColumnIndex, C_RowIndex].Value = null;
                            ((DataGridViewTextBoxCellEx)C_dataGridView[C_ColumnIndex, C_RowIndex]).RowSpan = 1;
                        }
                        //
                        // Create New Cell
                        //
                        ((DataGridViewTextBoxCellEx)old_dataGridView[old_ColumnIndex, old_RowIndex]).RowSpan = C_rowSpan;
                        C_dataGridView[old_ColumnIndex, old_RowIndex].Value = C_strValue;
                        C_dataGridView[old_ColumnIndex, old_RowIndex].Style.BackColor = bcBuffer;
                        //
                        if (!changeRoomSlot(C_dataGridView, C_ColumnIndex, C_RowIndex, old_dataGridView, old_ColumnIndex, old_RowIndex, C_rowSpan, Cut))
                        {
                            RefreshDGV(old_dataGridView);
                        }
                        if (old_dataGridView.Name != C_dataGridView.Name)
                        {
                            RefreshDGV(old_dataGridView);
                            RefreshDGV(C_dataGridView);
                        }

                    }
                }
                catch
                {
                    goto ExitUP;
                }
                finally
                {
                    dataChanged = true;
                }
            }
        ExitUP:
            Cut = false;
            Copy = false;
            toolStripMenuItemPaste.Enabled = false;
            C_dataGridView.ClearSelection();
            old_dataGridView.ClearSelection();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (CurrectCellRightClick)
            {
                if (old_dataGridView[old_ColumnIndex, old_RowIndex].Value != null)
                {
                    if (MessageBox.Show("Are you sure to delete a class with the following information?\n\r" +
                                        old_dataGridView[old_ColumnIndex, old_RowIndex].Value.ToString(),
                                        "Delete a Classroom slot's Warning!",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            int Roomkey = (from t in dgvList
                                           where t.Value == old_dataGridView
                                           select t.Key).Single();

                            int StartTime, DayNo;

                            DayNo = old_ColumnIndex - 1;
                            StartTime = old_RowIndex;

                            var aryCp = (from c in db.Classroom_Times
                                         where ((c.Day_No == DayNo) && (c.Room_ID == Roomkey) && (c.StartTime == StartTime))
                                         select new
                                         {
                                             c.Class_ID,
                                             c.Professor_ID
                                         }).ToArray();

                            var cp = aryCp[aryCp.Length - 1];

                            db.Classroom_TimeDelete(Roomkey, cp.Class_ID, StartTime, DayNo);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            RefreshDGV(old_dataGridView);
                            dataChanged = true;
                        }
                    }
                }
                old_dataGridView.ClearSelection();
            }
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (CurrectCellRightClick && old_dataGridView[old_ColumnIndex, old_RowIndex].Value != null)
            {
                int Roomkey = (from t in dgvList
                               where t.Value == old_dataGridView
                               select t.Key).Single();

                int StartTime, DayNo;
                DayNo = old_ColumnIndex - 1;
                StartTime = old_RowIndex;

                var aryCp = (from c in db.Classroom_Times
                             where ((c.Day_No == DayNo) && (c.Room_ID == Roomkey) && (c.StartTime == StartTime))
                             select new
                             {
                                 c.Class_ID,
                                 c.Professor_ID
                             }).ToArray();

                var cp = aryCp[aryCp.Length - 1];

                OneFieldOfRoomForm OFoRF = new OneFieldOfRoomForm(Roomkey, cp.Class_ID, StartTime, DayNo);
                OFoRF.CurrentCell = this.old_dataGridView[old_ColumnIndex, old_RowIndex];
                OFoRF.ShowDialog();
                old_dataGridView.ClearSelection();
                dataChanged = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save2Excel = new SaveFileDialog();
            save2Excel.Filter = @"Excel files|*.xls";
            save2Excel.DefaultExt = "RoomsSchedule.xls";
            save2Excel.FileName = "RoomsSchedule.xls";
            if (save2Excel.ShowDialog() == DialogResult.OK)
            {
                CheckListCellsTextDataForm CLCTDF = new CheckListCellsTextDataForm();
                CLCTDF.chklstExportCell.ItemCheck += new ItemCheckEventHandler(chklstExportCell_ItemCheck);
                //
                // check default items
                CLCTDF.chklstExportCell.Items.Clear();
                CLCTDF.chklstExportCell.Items.Add("Course Code", false);
                CLCTDF.chklstExportCell.Items.Add("Course Name", true);
                CLCTDF.chklstExportCell.Items.Add("Groups Name", true);
                CLCTDF.chklstExportCell.Items.Add("Groups Semester Entry", true);
                CLCTDF.chklstExportCell.Items.Add("Professor Name", true);
                CLCTDF.chklstExportCell.Items.Add("Room Type", false);
                //
                CheckedListBox chklstCTD_buffer = CLCTDF.chklstExportCell;
                CLCTDF.Location = new Point(btnExport.Location.X + this.Location.X + 7,
                    this.Location.Y + btnExport.Location.Y + btnExport.Size.Height + 32);
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

                    ExcelWorksheet ws = ef.Worksheets.Add("RoomsSchedule");
                    int numberSheet = 1;
                    int numberFile = 1;
                    int startRow_No = 0;

                    #region Room Name Style's
                    CellStyle RoomTitleStyle = new CellStyle();
                    RoomTitleStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    RoomTitleStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
                    RoomTitleStyle.Font.Weight = ExcelFont.BoldWeight;
                    RoomTitleStyle.FillPattern.SetSolid(Color.Azure);
                    RoomTitleStyle.Font.Color = Color.RoyalBlue;
                    RoomTitleStyle.WrapText = false;
                    RoomTitleStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
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

                    #region Read any Room in DataGridView and Save in Excel files
                    db = new LINQDataContext();
                    foreach (var room in db.Rooms)
                    {
                    checkLoop:
                        if (startRow_No + 16 <= 149) // Write in Exist Worksheet
                        {
                            #region Save in Excel Row by database.Classroom_Time
                            //
                            // set Room Name Style
                            ws.Cells.GetSubrangeAbsolute(0 + startRow_No, 0, 1 + startRow_No, 7).Style = RoomTitleStyle;
                            //
                            // set Room Name text in Title
                            ws.Cells[0 + startRow_No, 0].Value = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                                "Room Name: {0}  ,   Room type: {1}",
                                room.Name_Room, room.Type_Room);
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
                            // First Row for Room Name
                            ws.Cells.GetSubrangeAbsolute(0 + startRow_No, 0, 1 + startRow_No, 7).Merged = true;
                            //
                            // Second Row for Room Header "Time Slot"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 0, 3 + startRow_No, 0).Merged = true;
                            //
                            // Second Row for Room Header "Saturday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 1, 3 + startRow_No, 1).Merged = true;
                            //
                            // Second Row for Room Header "Sunday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 2, 3 + startRow_No, 2).Merged = true;
                            //
                            // Second Row for Room Header "Monday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 3, 3 + startRow_No, 3).Merged = true;
                            //
                            // Second Row for Room Header "Tuesday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 4, 3 + startRow_No, 4).Merged = true;
                            //
                            // Second Row for Room Header "Wednesday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 5, 3 + startRow_No, 5).Merged = true;
                            //
                            // Second Row for Room Header "Thursday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 6, 3 + startRow_No, 6).Merged = true;
                            //
                            // Second Row for Room Header "Friday"
                            ws.Cells.GetSubrangeAbsolute(2 + startRow_No, 7, 3 + startRow_No, 7).Merged = true;
                            #endregion
                            //
                            // set Time Slot Styles
                            for (int row = 4; row < 12 + 4; row++)
                            {
                                ws.Cells[row + startRow_No, 0].Style = headerStyle; // headerStyle is equal by timeSlotStyle
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
                            // read any Classroom_Time for this Room and save that
                            #region Read and Save Cells by this room classrooms data
                            //-------------------------------------------------------------------------------------------------
                            foreach (Classroom_Time roomClasses in room.Classroom_Times)
                            {
                                int row = roomClasses.StartTime;
                                int column = roomClasses.Day_No + 1;
                                //
                                // read and create cell text value by optional checkListBox
                                string groups_Name = "";
                                //
                                // have group name?
                                if (chklstCTD_buffer.GetItemChecked(2) || chklstCTD_buffer.GetItemChecked(3))
                                {
                                    var groups = (from n in db.New_GroupsPerClasses
                                                  join g in db.Groups on n.Group_ID equals g.ID
                                                  where ((n.Class_ID == roomClasses.Class_ID) &&
                                                         (n.Room_ID == roomClasses.Room_ID) &&
                                                         (n.StartTime == roomClasses.StartTime) &&
                                                         (n.Day_No == roomClasses.Day_No))
                                                  select new
                                                  {
                                                      GroupName = (chklstCTD_buffer.GetItemChecked(3)) ?
                                                                string.Format(CultureInfo.CurrentCulture, "{0}  {1}  {2}-{3}",
                                                                g.Branch.Degree, g.Branch.Branch_Name, g.Semester_Entry_Year, (g.Semester_Entry_FS ? "1" : "2")) :
                                                                string.Format(CultureInfo.CurrentCulture, "{0}  {1}",
                                                                g.Branch.Degree, g.Branch.Branch_Name)

                                                  }).ToList();
                                    //
                                    foreach (var gs in groups)
                                    {
                                        groups_Name += gs.GroupName + "\r\n";
                                    }
                                    groups_Name = groups_Name.Trim();
                                }
                                //
                                // 1. Course Name
                                // 2. Course Code
                                // 3. Professor Name
                                // 4. Groups Name or Groups Name + Group Semester Entry
                                // 5. Room Type
                                string classesValue = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                                    "{0}{1}{2}{3}{4}",
                                    (chklstCTD_buffer.GetItemChecked(1) ? roomClasses.Class.Course.Name_Course + Environment.NewLine : string.Empty), // Course Name
                                    (chklstCTD_buffer.GetItemChecked(0) ? (roomClasses.Class.Course.CourseCode.HasValue ? roomClasses.Class.Course.CourseCode.Value : 0) + "\r\n" : ""), // Course Code
                                    (chklstCTD_buffer.GetItemChecked(4) ? roomClasses.Professor.Name_Professor + Environment.NewLine : ""), // Professor Name
                                    groups_Name, // Groups Name or Groups Name + Group Semester Entry
                                    (chklstCTD_buffer.GetItemChecked(5) ? roomClasses.Room.Type_Room : "")); // Room Type 


                                ws.Cells[row + startRow_No + 4, column].Value = classesValue;
                                ws.Cells[row + startRow_No + 4, column].Style.FillPattern.SetSolid(Color.Aquamarine);
                                ws.Cells[row + startRow_No + 4, column].Style.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.DashDotDot);

                                try
                                {
                                    if (roomClasses.Duration > 1)
                                        ws.Cells.GetSubrangeAbsolute(row + startRow_No + 4,
                                                                     column,
                                                                     (row + startRow_No + 4) + (roomClasses.Duration - 1),
                                                                     column).Merged = true;
                                }
                                catch { } // maybe two classroom overlap in a cell's

                                for (int d = 0; d < roomClasses.Duration; d++)
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
                                ws = ef.Worksheets.Add("RoomsSchedule");
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
                            ws = ef.Worksheets.Add("RoomsSchedule (" + numberSheet.ToString() + ")");
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
                            // goto check again
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
        void chklstExportCell_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Groups Semester Entry is Checked then Groups Name must be checked!
            if (e.Index == 3 && e.NewValue == CheckState.Checked)
                ((CheckedListBox)sender).SetItemChecked(2, true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db = new LINQDataContext();
            _ClassBuffer = _classrooms = db.Classroom_Times.AsParallel().Select(R => R).ToList(); 
            _GroupBuffer = db.New_GroupsPerClasses.AsParallel().Select(G => G).ToList(); // for reset changed data
            dataChanged = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // delete changed data
                db.Classroom_TimeDeleteAll();
                //
                // save buffer data
                foreach (Classroom_Time c in _ClassBuffer)
                    db.Classroom_TimeSave(c.Room_ID, c.Class_ID, c.Professor_ID, c.StartTime, c.Duration, c.Day_No);
                foreach (New_GroupsPerClass g in _GroupBuffer)
                    db.New_GroupsPerClassSave(g.Room_ID, g.Class_ID, g.StartTime, g.Day_No, g.Group_ID);
                //
                // reset all dataGridView
                foreach (KeyValuePair<int, DataGridView> kvp in dgvList)
                {
                    Reset_dataGridView(kvp.Value);
                }
                //
                // Fill DataGridView by buffer Data
                //
                FillDGV();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ChangeRoomsDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            db = new LINQDataContext();
            if (dataChanged) // if data changed!
            {
                System.Windows.Forms.DialogResult closeQ = 
                    MessageBox.Show("Do you want to save information that has changed?", "Save or Reset",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (closeQ == System.Windows.Forms.DialogResult.Yes) // Save and Close
                {
                    btnSave_Click(sender, e);
                }
                else if (closeQ == System.Windows.Forms.DialogResult.No) // Reset and Close
                {
                    btnReset_Click(sender, e);
                }
                else // Cancel Closing
                {
                    e.Cancel = true;
                }
            }
        }

    }
}

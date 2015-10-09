using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Globalization;
using MakeClassSchedule.Algorithm;
using System.Threading;

namespace SpannedDataGridView
{
    public class CreateDataGridViews
    {
        #region Properties

        Dictionary<int, Room> roomList = new Dictionary<int, Room>();

        Dictionary<int, Label> lblRoom = new Dictionary<int, Label>();
        public Dictionary<int, Label> LblRoom { get { return lblRoom; } }

        Dictionary<int, DataGridView> dgvList = new Dictionary<int, DataGridView>();
        public Dictionary<int, DataGridView> DgvList { get { return dgvList; } }

        static Point LastDGV_Location;
        static Point LastLabel_Location;
        static int Distance = 50 + 462; // 50 is free and 462 is dgv Height

        #endregion

        #region Properties_Base
        private Schedule _schedule;
        private bool _running;
        private Form _resultWindow;
        #endregion

        public CreateDataGridViews(Dictionary<int, Room> rooms, Form rFrm)
        {
            _schedule = null;
            _running = false;
            _resultWindow = rFrm;
            roomList = rooms;
            LastDGV_Location = new Point(12, 25);
            LastLabel_Location = new Point(12, 7);
            Create_FristTime();
            //
            // add DataGridView
            //
            foreach (KeyValuePair<int, DataGridView> kvp in DgvList)
            {
                _resultWindow.Controls["panelRoomDGV"].Controls.Add(kvp.Value);
            }
            //
            // add Label
            //
            foreach (KeyValuePair<int, Label> kvp in LblRoom)
            {
                _resultWindow.Controls["panelRoomDGV"].Controls.Add(kvp.Value);
            }
        }

        ~CreateDataGridViews()
        {
            _schedule = null;
            _resultWindow.Dispose();
            roomList.Clear();
            lblRoom.Clear();
            dgvList.Clear();
        }

        private void Create_FristTime()
        {
            foreach (KeyValuePair<int, Room> ri in roomList)
            {
                // create new dataGridView for a Room
                dgvList.Add(ri.Key, Standard_dgv(LastDGV_Location, "dgv_" + ri.Value.GetId.ToString()));
                dgvList[ri.Key].ClearSelection();
                //
                // create new label for a Room
                lblRoom.Add(ri.Key, Standard_lbl(LastLabel_Location,
                    ("Room: " + ri.Value.GetName + "     ,     Size: " +
                     ri.Value.GetNumberOfSeats.ToString() + "     ,     Lab: " + ri.Value.GetLab +
                     "     ,     [ ID: " + ri.Value.GetId.ToString() + " ]"),
                    "lblRoom_" + ri.Value.GetId.ToString()));
                //
                // new Location for a new Room
                LastDGV_Location.Y += Distance;
                LastLabel_Location.Y = LastDGV_Location.Y - 18;
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
            dgv.CausesValidation = true;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            dgv.Size = new System.Drawing.Size(748, 462);
            dgv.ReadOnly = true;
            dgv.RightToLeft = (CultureInfo.CurrentCulture.EnglishName == "Persian" ||
                               CultureInfo.CurrentCulture.EnglishName == "Farsi") ? System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellContentClick);
            dgv.CellMouseUp += new DataGridViewCellMouseEventHandler(dgv_CellMouseUp);
            dgv.MultiSelect = false;
            //
            // Add TimeSlots Data
            //
            for (int i = 8; i < 20; i++)
            {
                dgv.Rows.Add(i.ToString() + " - " + (i + 1).ToString());
            }
            //
            return dgv;
        }

        private void dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void Reset_dataGridView(ref DataGridView sender)
        {
            sender.Rows.Clear();
            //
            // Add TimeSlots Data
            //
            for (int i = 8; i < 20; i++)
            {
                sender.Rows.Add(string.Format(CultureInfo.CurrentCulture, "{0} - {1}", i, (i + 1)));
            }
        }

        object Locker = new object();
        public void SetSchedule(Schedule schedule, bool showGraphical)
        {
            _schedule = schedule.MakeCopy(false);
            if (Monitor.TryEnter(Locker, 500))
            {
                //_resultWindow.Controls["lblFitness"].Text = schedule.GetFitness().ToString();
                SetText("Fitness: " + schedule.GetFitness().ToString());
                Monitor.Exit(Locker);
            }
            else return;
            if (showGraphical)
            {
                //
                // ReSet to New DataGridView
                //
                foreach (KeyValuePair<int, DataGridView> it in dgvList)
                {
                    ClearDataGridView(it.Value);
                }
                //
                int numberOfRooms = Configuration.GetInstance.GetNumberOfRooms();
                int daySize = schedule.day_Hours * numberOfRooms;
                Random rand = new Random();
                foreach (KeyValuePair<CourseClass, int> it in schedule.GetClasses().ToList())
                {
                    // coordinate of time-space slot
                    int pos = it.Value; // int pos of _slot array
                    int day = pos / daySize;
                    int time = pos % daySize; // this is not time now!
                    int room = time / schedule.day_Hours;
                    time = time % schedule.day_Hours;  // this is a time now!

                    int dur = it.Key.GetDuration;

                    CourseClass cc = it.Key;
                    Room r = Configuration.GetInstance.GetRoomById(room);
                    string groups_Name = "";
                    foreach (var gs in cc.GetGroups)
                    {
                        groups_Name += gs.GetName + "\r\n";
                    }
                    groups_Name = groups_Name.Trim();

                    ((DataGridViewTextBoxCellEx)dgvList[r.GetId][day + 1, time]).RowSpan = cc.GetDuration;
                    dgvList[r.GetId][day + 1, time].Style.BackColor =
                                Color.FromArgb(rand.Next(70, 250), rand.Next(70, 250), rand.Next(70, 250));

                    dgvList[r.GetId][day + 1, time].Value = string.Format(CultureInfo.CurrentCulture,
                        "{0}\r\n{1}\r\n{2}\r\n{3}", cc.GetCourse.GetName, cc.GetProfessor.GetName, groups_Name, cc.Lab);
                        
                        //(cc.GetCourse.GetName + Environment.NewLine +
                        // cc.GetProfessor.GetName + Environment.NewLine +
                        // groups_Name + Environment.NewLine + cc.Lab);
                }
            }
        }

        public void SetNewState(AlgorithmState state)
        {
            _running = state == AlgorithmState.AS_RUNNING;
        }

        public void OnFileStop()
        {
            Algorithm.GetInstance().Stop();
        }

        #region Safely Thread Codes

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the text property on a Label control.
        /// </summary>
        /// <param name="text"></param>
         delegate void SetTextCallback(string text);

        /// <summary>
        /// This method demonstrates a pattern for making thread-safe
        /// calls on a Windows Forms control. 
        /// If the calling thread is different from the thread that
        /// created the Label control, this method creates a
        /// SetTextCallback and calls itself asynchronously using the
        /// Invoke method.
        /// If the calling thread is the same as the thread that created
        /// the Label control, the Text property is set directly. 
        /// </summary>
        /// <param name="text"></param>
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (_resultWindow.Controls["lblFitness"].InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                _resultWindow.Invoke(d, new object[] { text });
            }
            else
            {
                _resultWindow.Controls["lblFitness"].Text = text;
            }
        }

        /// <summary>
        /// This delegate enables asynchronous calls for setting
        /// the object property on a DataGridView control.
        /// </summary>
        /// <param name="text"></param>
        delegate void ClearCallback(DataGridView dgv);

        /// <summary>
        /// This method demonstrates a pattern for making thread-safe
        /// calls on a Windows Forms control. 
        /// If the calling thread is different from the thread that
        /// created the DataGridView control, this method creates a
        /// ClearCallback and calls itself asynchronously using the
        /// Invoke method.
        /// If the calling thread is the same as the thread that created
        /// the DataGridView control, the Object is set directly. 
        /// </summary>
        /// <param name="text"></param>
        private void ClearDataGridView(DataGridView dgv)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (_resultWindow.Controls["panelRoomDGV"].Controls[dgv.Name].InvokeRequired)
            {
                ClearCallback d = new ClearCallback(ClearDataGridView);
                _resultWindow.Controls["panelRoomDGV"].Invoke(d, new object[] { dgv });
            }
            else
            {
                dgv.Rows.Clear();
                //
                // Add TimeSlots Data
                //
                for (int i = 8; i < 20; i++)
                {
                    dgv.Rows.Add(string.Format(CultureInfo.CurrentCulture, "{0} - {1}", i, (i + 1)));
                }                
            }
        }
        #endregion
    }
}

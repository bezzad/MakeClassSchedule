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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            dgvRoom.Rows[0].Height = 30;
            dgvType.Rows[0].Height = 30;

            var db = new LINQDataContext();
            IEnumerable<string> TypeQuery = from tQ in db.Room_Types
                                            select tQ.Type_Name;
            var aryRoom_Type = TypeQuery.ToArray();
            if (aryRoom_Type.Length > 0)
            {
                dgvType.Rows.Add(aryRoom_Type.Length);
                for (int rowCounter = 0; rowCounter < aryRoom_Type.Length; rowCounter++)
                {
                    dgvType[0, rowCounter].Value = aryRoom_Type[rowCounter];
                }
            }

            refreshItems();

            var aryRooms = db.Rooms.ToArray();
            if (aryRooms.Length > 0)
            {
                dgvRoom.Rows.Add(aryRooms.Length);
                for (int rowCounter = 0; rowCounter < aryRooms.Length; rowCounter++)
                {
                    dgvRoom[0, rowCounter].Value = aryRooms[rowCounter].Room_ID.ToString();

                    if (aryRooms[rowCounter].Name_Room != null)
                        dgvRoom[1, rowCounter].Value = aryRooms[rowCounter].Name_Room.ToString();

                    dgvRoom[2, rowCounter].Value = aryRooms[rowCounter].Type_Room.ToString();

                    dgvRoom[3, rowCounter].Value = aryRooms[rowCounter].Size_No.ToString();
                }
            }
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvRoom[0, 0].Selected = true;
    
            // ----------------------------------------------------------------------------------------------
            //
            var db = new LINQDataContext();
            
            for (int rowCounter = 0; rowCounter < dgvRoom.RowCount - 1; rowCounter++)
            {
                try
                {
                    //
                    // search dgvRoom.rows in db.Room
                    //
                    int ID_No = 0;
                    int.TryParse(dgvRoom[0, rowCounter].Value.ToString(), out ID_No);
                    // Define the query expression.
                    IEnumerable<int> query =
                        from room in db.Rooms
                        where room.Room_ID == ID_No
                        select room.Room_ID;

                    if (query.ToArray().Length > 0) // EDIT
                    {
                        int size = 0;
                        db.RoomEdit(ID_No,
                            (dgvRoom[1, rowCounter].Value != null) ? (string)dgvRoom[1, rowCounter].Value.ToString() : "",
                            (dgvRoom[2, rowCounter].Value != null) ? dgvRoom[2, rowCounter].Value.ToString() : "",
                            (dgvRoom[3, rowCounter].Value != null) ? (int.TryParse(dgvRoom[3, rowCounter].Value.ToString(), out size)) ? size : 0 : 0);
                    }
                    else
                    {
                        int size = 0;
                        db.RoomSave(ID_No,
                            (dgvRoom[1, rowCounter].Value != null) ? (string)dgvRoom[1, rowCounter].Value.ToString() : "",
                            (dgvRoom[2, rowCounter].Value != null) ? dgvRoom[2, rowCounter].Value.ToString() : "",
                            (dgvRoom[3, rowCounter].Value != null) ? (int.TryParse(dgvRoom[3, rowCounter].Value.ToString(), out size)) ? size : 0 : 0);
                    }
                }
                catch { }
            }
            db.Dispose();
        }

        private void dgvRoom_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int ID_Counter = 1;
                bool Find = true;
                while (Find)
                {
                    Find = false;
                    for (int rowC = 0; rowC < dgvRoom.RowCount - 2; rowC++)
                    {
                        if (int.Parse(dgvRoom[0, rowC].Value.ToString()) == ID_Counter)
                        {
                            ID_Counter++;
                            Find = true;
                            break;
                        }
                    }
                }
                dgvRoom.Rows[e.RowIndex - 1].Cells[0].Value = ID_Counter;
            }
        }

        private void dgvType_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var db = new LINQDataContext();
            if (dgvType[e.ColumnIndex, e.RowIndex].Value != null)
            {
                db.Room_TypeSave(dgvType[e.ColumnIndex, e.RowIndex].Value.ToString());
                refreshItems();
                dgvRoom.Refresh();
            }
        }

        private void refreshItems()
        {
            this.colType.Items.Clear();
            IEnumerable<string> TypeQuery = from tQ in new LINQDataContext().Room_Types
                                            select tQ.Type_Name;
            this.colType.Items.AddRange(TypeQuery.ToArray());
        }

        private void dgvType_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Cells[0].Value != null)
            {
                string delCell = e.Row.Cells[0].Value.ToString();
                // Define the query expression.
                IEnumerable<int> roomQuery = from roomQ in new LINQDataContext().Rooms
                                             where roomQ.Type_Room == delCell
                                             select roomQ.Room_ID;
                //
                // Define the query expression.
                IEnumerable<int> classQuery = from classQ in new LINQDataContext().Classes
                                              where classQ.RoomType == delCell
                                              select classQ.Class_ID;

                //
                // if exist room_Type data in room table :
                //
                if (roomQuery.ToArray().Length > 0)
                {
                    string room_ID_List = "";
                    foreach (var anyRoom in roomQuery)
                    {
                        room_ID_List += anyRoom.ToString() + " and ";
                    }
                    room_ID_List = room_ID_List.Substring(0, room_ID_List.Length - 4);

                    e.Cancel = true;

                    MessageBox.Show("Information Rooms with Room numbers " +
                        room_ID_List + "is related to Room Type's " +
                        e.Row.Cells[0].Value.ToString() +
                        ".\n First, this information can change rooms.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                //
                // if exist room_Type data in room table :
                //
                else if (classQuery.ToArray().Length > 0)
                {
                    string class_ID_List = "";
                    foreach (var anyClass in classQuery)
                    {
                        class_ID_List += anyClass.ToString() + " and ";
                    }
                    class_ID_List = class_ID_List.Substring(0, class_ID_List.Length - 4);

                    e.Cancel = true;

                    MessageBox.Show("Information Classes with class numbers " +
                        class_ID_List + "is related to Room Type's " +
                        e.Row.Cells[1].Value.ToString() +
                        ".\n First, this information can change classes.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    new LINQDataContext().Room_TypeDelete(delCell);
                }
            }
        }

        private void dgvType_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            refreshItems();
        }

        private void dgvRoom_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Row.Cells[0].Value.ToString(), out id))
            {
                IEnumerable<int> roomQuery = (from rQ in new LINQDataContext().Classroom_Times
                                              where rQ.Room_ID == id
                                              select rQ.Class_ID);
                var aryRQ = roomQuery.ToArray();
                if (aryRQ.Length>0)
                {
                    string class_ID_List = "";
                    foreach (var anyClass in aryRQ)
                    {
                        class_ID_List += anyClass.ToString() + " and ";
                    }
                    class_ID_List = class_ID_List.Substring(0, class_ID_List.Length - 5);

                    e.Cancel = true;

                    MessageBox.Show("Information Classes with class numbers " +
                        class_ID_List + "is related to Room " +
                        e.Row.Cells[1].Value.ToString() +
                        ".\n First, this information can change classes.", "Delete Row Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    new LINQDataContext().RoomDelete(id);
                }
            }
            
        }

        
    }
}

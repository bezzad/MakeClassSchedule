
/////////////////////////////////////////
// (C)2010-2011 B.B Company.           //
// All rights reserved.                //
// mailto:Behzad.khosravifar@gmail.com //
// Creator: Behzad Khosravifar         //
/////////////////////////////////////////


using System;

namespace MakeClassSchedule.Algorithm
{
    public class Room
    {
        // ID counter used to assign IDs automatically
        static int _nextRoomId = 0;

        #region Properties

        // Room ID - automatically assigned
        private int _id;
        public int GetId { get { return _id; } }

        // Room Name
        private string _name;
        public string GetName { get { return _name; } }

        // Inidicates if room has specific
        private string _lab = "false";
        public string GetLab { get { return _lab; } }

        // Number of seats in room
        private int _numberOfSeats;
        public int GetNumberOfSeats { get { return _numberOfSeats; } }

        public int Origin_ID_inDB;
        #endregion

        /// <summary>
        /// Constructor of Room Class 
        /// and assign ID to room
        /// </summary>
        /// <param name="Original_Id">Room ID</param>
        /// <param name="name">Room Name</param>
        /// <param name="lab">Room Lab Type Name's</param>
        /// <param name="numberOfSeats">Nomber Of Seats in the Room</param>
        public Room(int Original_Id, string name, string lab, int numberOfSeats)
        {
            _id = _nextRoomId++; 
            _name = name;
            _lab = lab;
            _numberOfSeats = numberOfSeats;
            Origin_ID_inDB = Original_Id;
        }

        /// <summary>
        /// Restarts ID assignments
        /// </summary>
	    public static void RestartIDs() { _nextRoomId = 0; }
    }
}

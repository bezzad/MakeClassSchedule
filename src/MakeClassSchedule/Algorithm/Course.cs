
/////////////////////////////////////////
// (C)2010-2011 B.B Company.           //
// All rights reserved.                //
// mailto:Behzad.khosravifar@gmail.com //
// Creator: Behzad Khosravifar         //
/////////////////////////////////////////

using System;

namespace MakeClassSchedule.Algorithm
{
    public class Course
    {
        #region Properties

        // Course ID
        private int _id = 0;
        public int GetId { get { return _id; } }

        private string _name = string.Empty;
        public string GetName { get { return _name; } }

        #endregion

        /// <summary>
        /// Constructor of Course Class
        /// </summary>
        /// <param name="_id">Course ID</param>
        /// <param name="_name">Course Name</param>
        public Course(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}

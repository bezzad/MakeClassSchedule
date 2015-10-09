
/////////////////////////////////////////
// (C)2010-2011 B.B Company.           //
// All rights reserved.                //
// mailto:Behzad.khosravifar@gmail.com //
// Creator: Behzad Khosravifar         //
/////////////////////////////////////////


using System;
using System.Collections.Generic;

namespace MakeClassSchedule.Algorithm
{
    public class Professor
    {
        #region Properties

        private string _name = ""; // Professor's Name
        public string GetName { get { return _name; } }

        private int _id; // Professor's ID
        public int GetId { get { return _id; } }

        // List of classes that professor teaches
        private List<CourseClass> _courseClasses = new List<CourseClass>();
        public List<CourseClass> GetCourseClasses { get { return _courseClasses; } }

        // Professor Time Schedule in a week [Time of Day's, Day of Week's]
        /// <summary>
        /// [Time (d.v.12), Day (d.v.7)]
        /// </summary>
        private bool[,] _schedule = new bool[12, 8]; 
        /// <summary>
        /// get [Time (d.v.12), Day (d.v.7)]
        /// </summary>
        public bool[,] GetSchedule { get { return _schedule; } }

        #endregion
        
        /// <summary>
        /// Constructor of Professor's Class
        /// </summary>
        /// <param name="_name">Professor Name</param>
        /// <param name="_id">Professor ID</param>
        /// <param name="_schedule">Professor Time Schedule</param>
        public Professor(int id, string name, bool[,] schedule)
        {
            _name = name;
            _id = id;
            _schedule = schedule;
        }

        /// <summary>
        /// Bind professor to course
        /// </summary>
        /// <param name="_courseClass"></param>
        public void AddCourseClass(CourseClass courseClass)
        {
            _courseClasses.Add(courseClass); 
        }

        // Compares ID's of two objects which represent professors
        public static bool operator ==(Professor lP, Professor rP)
        { return (lP._id == rP._id); }

        // Compares ID's of two objects which represent professors
        public static bool operator !=(Professor lP, Professor rP)
        { return (lP._id != rP._id); }

        // Compares ID's of two objects which represent studentGroups
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || this.GetType() != obj.GetType()) return false;
            Professor p = (Professor)obj;
            return (p._id == this._id);
        }

        // GetHashCode OverLoads
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

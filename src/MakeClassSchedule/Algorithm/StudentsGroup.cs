
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
    public class StudentsGroup
    {
        #region Properties

        private int _id; // Student Group's ID
        public int GetId { get { return _id; } }

        private string _name; // Name of Student Group
        public string GetName { get { return _name; } }

        private int _numberOfStudents; // Number of Students in Group
        public int GetNumberOfStudents { get { return _numberOfStudents; } }

        // List of classes that group attends
        private List<CourseClass> _courseClasses = new List<CourseClass>();
        public List<CourseClass> GetCourseClasses { get { return _courseClasses; } }

        #endregion

        /// <summary>
        /// Constructor of StudentsGroup's Class
        /// </summary>
        /// <param name="id">Group ID</param>
        /// <param name="name">Group Name</param>
        /// <param name="size">Number Students in Group</param>
        public StudentsGroup(int id, string name, int numberOfStudents)
        {
            _id = id;
            _name = name;
            _numberOfStudents = numberOfStudents;
        }

        /// <summary>
        /// Bind group to class
        /// </summary>
        /// <param name="courseClass"></param>
        public void AddCourseClass(CourseClass courseClass)
        {
            _courseClasses.Add(courseClass);
        }

        // Compares ID's of two objects which represent studentGroups
        public static bool operator ==(StudentsGroup lSG, StudentsGroup rSG)
        { return (lSG._id == rSG._id); }

        // Compares ID's of two objects which represent studentGroups
        public static bool operator !=(StudentsGroup lSG, StudentsGroup rSG)
        { return (lSG._id != rSG._id); }

        // Compares ID's of two objects which represent studentGroups
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || this.GetType() != obj.GetType()) return false;
            StudentsGroup sg = (StudentsGroup)obj;
            return (sg._id == this._id);
        }

        // GetHashCode OverLoads
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

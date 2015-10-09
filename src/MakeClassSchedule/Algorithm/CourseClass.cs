
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
    public class CourseClass
    {
        #region Properties

        // ID of a Professor who teaches, 
        // Each class can have several professors at first but one of them will be selected 
        private Professor _professor;
        public Professor GetProfessor { get { return _professor; } }

        // Course to which class belongs
        private Course _course; 
        public Course GetCourse { get { return _course; } }

        // Student groups who attend class, 
        // each class can be bound to multiple students group.
        private List<StudentsGroup> _groups = new List<StudentsGroup>();
        public List<StudentsGroup> GetGroups { get { return _groups; } }

        // Duration of class in hours
        private int _duration = 1;
        public int GetDuration { get { return _duration; } }

        // Initicates wheather class requires specified
        private string _lab = "false"; 
        public string Lab { get { return _lab; } }

        // Number of seats (students) required in room
        private int _numberOfSeats;
        public int GetNumberOfSeats { get { return _numberOfSeats; } }

        // CourseClass ID's
        public int Class_ID;
        #endregion

        /// <summary>
        /// Initializes class object
        /// </summary>
        /// <param name="professor">Professor ID</param>
        /// <param name="course">Course ID</param>
        /// <param name="groups">List of Group ID</param>
        /// <param name="lab">Class Lab name</param>
        /// <param name="duration">Class Duration (in hours)</param>
        public CourseClass(Professor professor, Course course, 
               List<StudentsGroup> groups, string lab, int duration, int class_Id)
        {
            _professor = professor;
            _course = course;
            _numberOfSeats = 0;
            _lab = lab;
            _duration = duration;
            Class_ID = class_Id;
            //
            // bind professor to class
            //
            /*
            for (int prof = 0; prof < _professor.Count; prof++)
                // multiple professor for a courseClass (One of several professor will be chosen)
                _professor[prof].AddCourseClass(this);
            */
            _professor.AddCourseClass(this);
            //
            // bind student groups to class
            //
            foreach (StudentsGroup it in groups)
            {
                it.AddCourseClass(this);
                _groups.Add(it);
                _numberOfSeats += it.GetNumberOfStudents;
            }
        }
    
        // Returns TRUE if another class has one or overlapping student groups.
        public bool GroupsOverlap(CourseClass c)
        {
            foreach (StudentsGroup it1 in _groups)
            {
                foreach (StudentsGroup it2 in c._groups)
                {
                    if (it1 == it2)
                        return true;
                }
            }
            return false;
        }

	    // Returns TRUE if another class has same professor.
        public bool ProfessorOverlaps(CourseClass c)
        {            
            return _professor == c._professor;
        }
    }
}

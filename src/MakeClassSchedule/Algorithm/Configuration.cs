
/////////////////////////////////////////
// (C)2010-2011 B.B Company.           //
// All rights reserved.                //
// mailto:Behzad.khosravifar@gmail.com //
// Creator: Behzad Khosravifar         //
/////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace MakeClassSchedule.Algorithm
{
    /// <summary>
    /// Reads configration file (LINQ.DB) and stores parsed objects
    /// </summary>
    public class Configuration
    {
        // Global instance
        static Configuration _instance = new Configuration();
        // Returns reference to global instance
        public static Configuration GetInstance { get { return _instance; } }

        #region Properties

        // Parsed professors
        private Dictionary<int, Professor> _professors = new Dictionary<int, Professor>();

        // Parsed student groups
        private Dictionary<int, StudentsGroup> _studentGroups = new Dictionary<int, StudentsGroup>();

        // Parsed courses
        private Dictionary<int, Course> _courses = new Dictionary<int, Course>();

        // Parsed rooms
        private Dictionary<int, Room> _rooms = new Dictionary<int, Room>();
        public Dictionary<int, Room> Rooms
        {
            get { return _rooms; }
        }

        // Parsed classes
        private List<CourseClass> _courseClasses = new List<CourseClass>();

        // Inidicate that configuration is not prsed yet
        private bool _isEmpty;

        #endregion

        // Initialize data
        public Configuration()
        {
            _isEmpty = true;
        }

        // Frees used resources
        ~Configuration()
        {
            _professors.Clear();

            _studentGroups.Clear();

            _courses.Clear();

            _rooms.Clear();

            _courseClasses.Clear();
        }

        // Parse file and store parsed object
        public void ParseFile(LINQDataContext db)
        {
            // clear previously parsed objects
            _professors.Clear();
            _studentGroups.Clear();
            _courses.Clear();
            _rooms.Clear();
            _courseClasses.Clear();

            Room.RestartIDs();
            //
            // Save Professor Data
            //
            foreach (var any in db.Professors)
            {
                ProfessorInfoCompiler pIc = new ProfessorInfoCompiler();
                Professor p;
                if (pIc.StartScanner(any.Schedule))
                {
                    p = new Professor(any.ID, any.Name_Professor, pIc.CompiledData);
                    _professors.Add(p.GetId, p);
                }
            }
            //
            // Save StudentsGroup Data
            //
            foreach (var any in db.Groups)
            {
                StudentsGroup sg;
                string sg_name = string.Format(CultureInfo.CurrentCulture, "{0}  {1}  {2}-{3}", any.Branch.Degree,
                    any.Branch.Branch_Name, any.Semester_Entry_Year, (any.Semester_Entry_FS) ? "1" : "2");
                sg = new StudentsGroup(any.ID, sg_name, any.Size_No);
                _studentGroups.Add(sg.GetId, sg);
            }
            //
            // Save Course Data
            //
            foreach (var any in db.Courses)
            {
                Course c;
                c = new Course(any.Course_ID, any.Name_Course);
                _courses.Add(c.GetId, c);
            }
            //
            // Save Room Data
            //
            foreach (var any in db.Rooms)
            {
                Room r;
                r = new Room(any.Room_ID, any.Name_Room, any.Type_Room, any.Size_No);
                _rooms.Add(r.GetId, r);
            }
            //
            // Save CourseClass Data -----------------------------------------------------------------------------
            //
            foreach (var any in db.Classes)
            {
                //
                // set Professor by best priority
                //
                var prof = (from p1 in db.Priority_Professors
                            join p2 in db.Professors on p1.Professor_ID equals p2.ID
                            where (p1.Class_ID == any.Class_ID)
                            orderby p1.Priority
                            select new
                            {
                                p1.Professor_ID,
                                p2.Name_Professor,
                                p2.Schedule
                            }).ToArray()[0];
                ProfessorInfoCompiler pIc = new ProfessorInfoCompiler();
                Professor p = (pIc.StartScanner(prof.Schedule)) ?
                    new Professor(prof.Professor_ID, prof.Name_Professor, pIc.CompiledData) :
                    new Professor(prof.Professor_ID, prof.Name_Professor, pIc.CompiledData);
                //
                // set selected course for class
                //
                Course c = new Course(any.Course_ID, any.Course.Name_Course);
                //
                // set StudentsGroup in List
                //
                List<StudentsGroup> g = new List<StudentsGroup>();
                foreach (var lstGroup in (from gil in db.Group_ID_Lists
                                          join groups in db.Groups on gil.Group_ID equals groups.ID
                                          where gil.Class_ID == any.Class_ID
                                          select new
                                          {
                                              gil.Group_ID,
                                              groups.Size_No,
                                              sg_name = string.Format(CultureInfo.CurrentCulture, "{0}  {1}  {2}-{3}", 
                                                                                                 groups.Branch.Degree,
                                                                                                 groups.Branch.Branch_Name,
                                                                                                 groups.Semester_Entry_Year,
                                                                                                 (groups.Semester_Entry_FS) ? "1" : "2")
                                          }))
                {
                    StudentsGroup sg = new StudentsGroup(lstGroup.Group_ID, lstGroup.sg_name, lstGroup.Size_No);
                    g.Add(sg);
                }
                //
                // save class by created data
                //
                CourseClass cc = new CourseClass(p, c, g, any.RoomType, (any.Practical_unit + any.Theory_unit), any.Class_ID);
                _courseClasses.Add(cc);
            }
            //----------------------------------------------------------------------------------------------------------------
            //
            db.Dispose();
            _isEmpty = false;
        }

        // Returns pointer to professor with specified ID
        // If there is no professor with such ID method returns NULL
        public Professor GetProfessorById(int id)
        {
            if (_professors.ContainsKey(id))
                return _professors[id];
            return null;
        }

        // Returns number of parsed professors
        public int GetNumberOfProfessors() { return (int)_professors.Count; }

        // Returns pointer to student group with specified ID
        // If there is no student group with such ID method returns NULL
        public StudentsGroup GetStudentsGroupById(int id)
        {
            if (_studentGroups.ContainsKey(id))
                return _studentGroups[id];
            return null;
        }

        // Returns number of parsed student groups
        public int GetNumberOfStudentGroups() { return (int)_studentGroups.Count; }

        // Returns pointer to course with specified ID
        // If there is no course with such ID method returns NULL
        public Course GetCourseById(int id)
        {
            if (_courses.ContainsKey(id))
                return _courses[id];
            return null;
        }

        public int GetNumberOfCourses() { return (int)_courses.Count; }

        // Returns pointer to room with specified ID
        // If there is no room with such ID method returns NULL
        public Room GetRoomById(int id)
        {
            if (_rooms.ContainsKey(id))
                return _rooms[id];
            return null;
        }

        // Returns number of parsed rooms
        public int GetNumberOfRooms() { return (int)_rooms.Count; }

        // Returns reference to list of parsed classes
        public List<CourseClass> GetCourseClasses() { return _courseClasses; }

        // Returns number of parsed classes
        public int GetNumberOfCourseClasses() { return (int)_courseClasses.Count; }

        // Returns TRUE if configuration is not parsed yet
        public bool IsEmpty() { return _isEmpty; }
    }
}

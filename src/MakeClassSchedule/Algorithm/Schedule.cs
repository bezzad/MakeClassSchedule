
/////////////////////////////////////////
// (C)2010-2011 B.B Company.           //
// All rights reserved.                //
// mailto:Behzad.khosravifar@gmail.com //
// Creator: Behzad Khosravifar         //
/////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using SpannedDataGridView;

namespace MakeClassSchedule.Algorithm
{
    // Schedule chromosome
    public class Schedule
    {
        // Number of working hours per day
        public const int DAY_HOURS = 12; // 8-9 , 9-10 , ... , 19-20
        public int day_Hours { get { return DAY_HOURS; } }

        // Number of days in week
        public const int DAYS_NUM = 7; // Sat , Sun , Mon , ... , Fri

        // Each class can have 0 to 34 points
        private const int numberOfScores = 34; // 34 scores is maximum fitness for a chromosome

        #region Properties
        // Number of crossover points of parent's class tables
        public int _numberOfCrossoverPoints;

        // Number of classes that is moved randomly by single mutation operation
        public int _mutationSize;

        // Probability that crossover will occur
        public int _crossoverProbability;

        // Probability that mutation will occur
        public int _mutationProbability;

        // Fitness value of chromosome
        float _fitness;

        // Flags of class requirements satisfaction
        bool[] _criteria;

        // Time-space slots, one entry represent one hour in one classroom
        List<CourseClass>[] _slots;

        // Class table for chromosome
        // Used to determine first time-space slot used by class
        Dictionary<CourseClass, int> _classes = new Dictionary<CourseClass, int>();

        #endregion

        #region Event

        // Initializes chromosomes with configuration block (setup of chromosome)
        public Schedule(int numberOfCrossoverPoints, int mutationSize,
            int crossoverProbability, int mutationProbability)
        {
            _mutationSize = mutationSize;
            _numberOfCrossoverPoints = numberOfCrossoverPoints;
            _crossoverProbability = crossoverProbability;
            _mutationProbability = mutationProbability;
            _fitness = 0;
            //
            // reserve space for time-space slots in chromosomes code
            _slots = new List<CourseClass>[(DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms())];
            for (int ptr = 0; ptr < (DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms()); ptr++)
                _slots[ptr] = new List<CourseClass>();

            // reserve space for flags of class requirements
            _criteria = new bool[(Configuration.GetInstance.GetNumberOfCourseClasses() * numberOfScores)];
        }

        // Copy constructor
        public Schedule(Schedule c, bool setupOnly)
        {
            if (setupOnly)
            {
                // reserve space for time-space slots in chromosomes code
                _slots = new List<CourseClass>[(DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms())];
                for (int ptr = 0; ptr < (DAYS_NUM * DAY_HOURS * Configuration.GetInstance.GetNumberOfRooms()); ptr++)
                    _slots[ptr] = new List<CourseClass>();

                // reserve space for flags of class requirements
                _criteria = new bool[(Configuration.GetInstance.GetNumberOfCourseClasses() * numberOfScores)];
            }
            else
            {
                // copy code
                _slots = c._slots;
                _classes = c._classes;

                // copy flags of class requirements
                _criteria = c._criteria;

                // copy fitness
                _fitness = c._fitness;
            }

            // copy parameters
            _numberOfCrossoverPoints = c._numberOfCrossoverPoints;
            _mutationSize = c._mutationSize;
            _crossoverProbability = c._crossoverProbability;
            _mutationProbability = c._mutationProbability;
        }

        // Makes copy at chromosome
        public Schedule MakeCopy(bool setupOnly)
        {
            // make object by calling copy constructor and return smart pointer to new object
            return new Schedule(this, setupOnly);
        }

        // Makes new chromosome with same setup but with randomly chosen code
        public Schedule MakeNewFromPrototype()
        {
            // number of time-space slots
            int size = _slots.Length;

            // make new chromosome, copy chromosome setup
            Schedule newChromosome = new Schedule(this, true);

            // place classes at random position
            List<CourseClass> cc = Configuration.GetInstance.GetCourseClasses();
            foreach (CourseClass it in cc)
            {
                // determine random position of class
                int num_rooms = Configuration.GetInstance.GetNumberOfRooms();
                int dur = it.GetDuration;
                Random rand = new Random();
                int day = rand.Next() % DAYS_NUM;
                int room = rand.Next() % num_rooms;
                int time = rand.Next() % (DAY_HOURS + 1 - dur);
                int pos = (day * num_rooms * DAY_HOURS) + (room * DAY_HOURS + time); // (Base) + (offset) time's

                // fill time-space slots, for each hour of class
                for (int i = dur - 1; i >= 0; i--)
                    newChromosome._slots[pos + i].Add(it);

                // insert in class table of chromosome
                newChromosome._classes.Add(it, pos);
            }

            newChromosome.CalculateFitness();

            // return smart pointer
            return newChromosome;
        }

        // Performed crossover operation using to chromosomes 
        // and returns pointer to offspring
        public Schedule Crossover(Schedule parent2)
        {
            Random rand = new Random();

            // check probability of crossover operation
            if (rand.Next() % 100 > _crossoverProbability)
                // no crossover, just copy first parent
                return new Schedule(this, false);

            // new chromosome object, copy chromosome setup
            Schedule n = new Schedule(this, true);

            // number of classes
            int size = _classes.Count;

            bool[] cp = new bool[size];

            // determine crossover point (randomly)
            for (int i = _numberOfCrossoverPoints; i > 0; i--)
            {
                while (true)
                {
                    int p = rand.Next() % size;
                    if (!cp[p])
                    {
                        cp[p] = true;
                        break;
                    }
                }
            }

            //Dictionary<CourseClass, int> it1 = _classes;
            List<KeyValuePair<CourseClass, int>> it1 = _classes.ToList<KeyValuePair<CourseClass, int>>();

            //Dictionary<CourseClass, int> it2 = parent2._classes;
            List<KeyValuePair<CourseClass, int>> it2 = parent2._classes.ToList<KeyValuePair<CourseClass, int>>();

            // make new code by combining parent codes
            bool first = (rand.Next() % 2 == 0);
            //
            for (int i = 0; i < size; i++)
            {
                if (first)
                {
                    // insert class from first parent into new chromosome's class table
                    n._classes.Add(it1[i].Key, it1[i].Value);
                    // all time-space slots of class are copied
                    for (int j = it1[i].Key.GetDuration - 1; j >= 0; j--)
                        n._slots[it1[i].Value + j].Add(it1[i].Key);
                }
                else
                {
                    // insert class from second parent into new chromosome's class table
                    n._classes.Add(it2[i].Key, it2[i].Value);
                    // all time-space slots of class are copied
                    for (int j = it2[i].Key.GetDuration - 1; j >= 0; j--)
                        n._slots[it2[i].Value + j].Add(it2[i].Key);
                }

                // crossover point
                if (cp[i])
                    // change source chromosome
                    first = !first;
            }

            n.CalculateFitness();

            // return smart pointer to offspring
            return n;
        }

        // Performs mutation on chromosome
        public void Mutation()
        {
            Random rand = new Random();

            // check probability of mutation operation
            if (rand.Next() % 100 > _mutationProbability)
                // will not do mutation
                return;

            // number of classes
            int numberOfClasses = _classes.Count;
            // number of time-space slots
            int size = _slots.Length;

            // move selected number of classes at random position
            for (int i = _mutationSize; i > 0; i--)
            {
                // select random chromosome for movement
                int mpos = rand.Next() % numberOfClasses;
                int pos1 = 0;
                KeyValuePair<CourseClass, int> it = _classes.ToList<KeyValuePair<CourseClass, int>>()[mpos];

                // current time-space slot used by class
                pos1 = it.Value;

                CourseClass cc1 = it.Key;

                // determine position of class randomly
                int nr = Configuration.GetInstance.GetNumberOfRooms();
                int dur = cc1.GetDuration;
                int day = rand.Next() % DAYS_NUM;
                int room = rand.Next() % nr;
                int time = rand.Next() % (DAY_HOURS + 1 - dur);
                int pos2 = day * nr * DAY_HOURS + room * DAY_HOURS + time;

                // move all time-space slots
                for (int j = dur - 1; j >= 0; j--)
                {
                    // remove class hour from current time-space slot
                    List<CourseClass> cl = _slots[pos1 + j];
                    foreach (CourseClass It in cl)
                    {
                        if (It == cc1)
                        {
                            cl.Remove(It);
                            break;
                        }
                    }

                    // move class hour to new time-space slot
                    _slots[pos2 + j].Add(cc1);
                }

                // change entry of class table to point to new time-space slots
                _classes[cc1] = pos2;
            }
        }

        // Calculates fitness value of chromosome
        public void CalculateFitness()
        {
            // chromosome's score
            int score = 0;

            int numberOfRooms = Configuration.GetInstance.GetNumberOfRooms();
            int daySize = DAY_HOURS * numberOfRooms;

            int ci = 0;

            // check criteria and calculate scores for each class in schedule
            foreach (KeyValuePair<CourseClass, int> it in _classes.ToList())
            {                                           //_classes.ToList<KeyValuePair<CourseClass, int>>())
                // coordinate of time-space slot
                int pos = it.Value; // int pos of _slot array
                int day = pos / daySize;
                int time = pos % daySize; // this is not time now!
                int room = time / DAY_HOURS;
                time = time % DAY_HOURS;  // this is a time now!

                int dur = it.Key.GetDuration;

                CourseClass cc = it.Key;
                Room r = Configuration.GetInstance.GetRoomById(room);

                #region Score 1 (check for room overlapping of classes)  [+3]

                // check for room overlapping of classes
                bool overlapping = false;
                for (int i = dur - 1; i >= 0; i--)
                {
                    if (_slots[pos + i].Count > 1)
                    {
                        overlapping = true;
                        break;
                    }
                }

                // on room overlapping
                if (!overlapping)
                    score += 3;

                _criteria[ci + 0] = !overlapping;

                #endregion

                #region Score 2 (does current room have enough seats)  [+2]
                // does current room have enough seats
                _criteria[ci + 1] = r.GetNumberOfSeats >= cc.GetNumberOfSeats;
                if (_criteria[ci + 1])
                    score += 2;
                #endregion

                #region Score 3 (does current room have computers if they are required)  [+12]
                // does current room have computers if they are required
                _criteria[ci + 2] = (cc.Lab == r.GetLab) ? true : false;
                if (_criteria[ci + 2])
                    score += 10;
                #endregion

                #region Score 4 and 5 (check overlapping of classes for professors and student groups)  [+4][+4]

                bool prof = false, gro = false;
                // check overlapping of classes for professors and student groups
                for (int i = numberOfRooms, t = (day * daySize + time); i > 0; i--, t += DAY_HOURS)
                {
                    // for each hour of class
                    for (int j = dur - 1; j >= 0; j--)
                    {
                        // check for overlapping with other classes at same time
                        List<CourseClass> cl = _slots[t + j];
                        foreach (CourseClass it_cc in cl)
                        {
                            if (cc != it_cc)
                            {
                                // professor overlaps?
                                if (!prof && cc.ProfessorOverlaps(it_cc))
                                    prof = true;

                                // student group overlaps?
                                if (!gro && cc.GroupsOverlap(it_cc))
                                    gro = true;

                                // both type of overlapping? no need to check more
                                if (prof && gro)
                                    goto total_overlap;
                            }
                        }
                    }
                }

            total_overlap:

                // professors have no overlapping classes?
                if (!prof)
                    score += 4;
                _criteria[ci + 3] = !prof;

                // student groups has no overlapping classes?
                if (!gro)
                    score += 4;
                _criteria[ci + 4] = !gro;

                #endregion

                #region Score 6 (check this class time by professor's free TimeTable)  [+8]
                _criteria[ci + 5] = true;
                for (int i = 0; i < dur; i++)
                {
                    if (!cc.GetProfessor.GetSchedule[time + i, day + 1]) 
                    {
                        _criteria[ci + 5] = false;
                        break;
                    }
                }
                if (_criteria[ci + 5])
                    score += 8;

                #endregion

                #region Score 7 (doesn't current class in 13-14 DayHours or it TimeSlot is 5)  [+1]
                // All Time-Slot is 8~19 in 12 Hours
                // Time-Slot 5 is in 13-14 Hour's
                _criteria[ci + 6] = true;
                for (int i = 0; i < dur; i++)
                {
                    if ((time + i) == 5)
                    {
                        _criteria[ci + 6] = false;
                        break;
                    }
                }
                if (_criteria[ci + 6]) score++;
                #endregion

                ci += numberOfScores;
            }

            // calculate fitness value based on score
            _fitness = (float)score / (Configuration.GetInstance.GetNumberOfCourseClasses() * numberOfScores);
        }

        // Returns fitness value of chromosome
        public float GetFitness() { return _fitness; }

        // Returns reference to table of classes
        public Dictionary<CourseClass, int> GetClasses() { return _classes; }

        // Returns array of flags of class requirements satisfaction
        public bool[] GetCriteria() { return _criteria; }

        // Return reference to array of time-space slots
        public List<CourseClass>[] GetSlots() { return _slots; }
        #endregion

        // Algorithm's observer (friend class for Schedule class's)
        public class ScheduleObserver
        {
            // Window which displays schedule
            private static CreateDataGridViews _window;

            // Handles event that is raised when algorithm finds new best chromosome
            public void NewBestChromosome(Schedule newChromosome, bool showGraphical)
            {
                if (_window.DgvList.Count > 0)
                    _window.SetSchedule(newChromosome, showGraphical);
            }

            // Handles event that is raised when state of execution of algorithm is changed
            public void EvolutionStateChanged(AlgorithmState newState)
            {
                if (_window != null)
                    _window.SetNewState(newState);
            }

            // Sets window which displays schedule
            public void SetWindow(CreateDataGridViews window)
            { _window = window; }
        }
    }
}

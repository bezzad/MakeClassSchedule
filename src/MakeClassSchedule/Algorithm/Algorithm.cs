
/////////////////////////////////////////
// (C)2010-2011 B.B Company.           //
// All rights reserved.                //
// mailto:Behzad.khosravifar@gmail.com //
// Creator: Behzad Khosravifar         //
/////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq; // PLINQ (Parallel LINQ in AsParallel())
using System.Threading;
using System.Threading.Tasks;

namespace MakeClassSchedule.Algorithm
{
    // State Structure for Algorithm 
    public enum AlgorithmState
    {
        AS_USER_STOPPED,
        AS_CRITERIA_STOPPED,
        AS_RUNNING,
        AS_SUSPENDED
    };
    
    // Genetic algorithm
    public class Algorithm
    {
        #region Public Properties
        //
        // Number of Chromosomes for All Population
        private int _numberOfChromosomes = 1000;
        public int NumberOfChromosomes
        {
            get { return _numberOfChromosomes; }
            set 
            {
                // there should be at least 2 chromosomes in population
                if (value < 2) value = 2;
                _numberOfChromosomes = value; 
            }
        } 
        //
        // Number of chromosome for track the best chromosomes
        private int _trackBest = 50;
        public int TrackBest
        {
            get { return _trackBest; }
            set
            {
                // algorithm should track at least on of best chromosomes
                if (value < 1) value = 1;
                //
                // track best chromosomes should be less than Generation size
                if (value >= NumberOfChromosomes) value = NumberOfChromosomes - 1;
                //
                // set
                _trackBest = value;
            }
        }
        //
        // Number of chromosomes which are replaced in each generation by offspring
        private int _replaceByGeneration = 180;
        public int ReplaceByGeneration
        {
            get { return _replaceByGeneration; }
            set
            {
                if (value < 1) value = 1;
                else if (value > NumberOfChromosomes - TrackBest)
                    value = NumberOfChromosomes - TrackBest;
                //
                // set
                _replaceByGeneration = value; 
            }
        }
        //
        // Number of crossover points of parent's class tables
        public int NumberOfCrossoverPoints
        {
            get { return _prototype._numberOfCrossoverPoints; }
            set
            {
                if (value < 2) value = 2;
                _prototype._numberOfCrossoverPoints = value;
            }
        }

        // Number of classes that is moved randomly by single mutation operation
        public int MutationSize
        {
            get { return _prototype._mutationSize; }
            set
            {
                if (value < 2) value = 2;
                _prototype._mutationSize = value;
            }
        }

        // Probability that crossover will occur
        public int CrossoverProbability
        {
            get { return _prototype._crossoverProbability; }
            set
            {
                // probability is a Percent between 0 and 100
                if (value < 0) value = 0;
                else if (value > 100) value = 100;
                //
                // set
                _prototype._crossoverProbability = value;
            }
        }

        // Probability that mutation will occur
        public int MutationProbability
        {
            get { return _prototype._mutationProbability; }
            set
            {
                // probability is a Percent between 0 and 100
                if (value < 0) value = 0;
                else if (value > 100) value = 100;
                //
                // set
                _prototype._mutationProbability = value;
            }
        }
        #endregion

        #region Properties

        public Thread[] MultiThreads = null;
        public int numCore = 0; // Number of Active CPU or CPU core's for this Programs

        // object for lock or Unlock
        object Locker0 = new object(); // for Lock _state of Algorithm
        object Locker1 = new object(); // for Lock _Chromosome jobs (W/R) 
        object Locker2 = new object(); // for Lock _bestChromosome & _bestFlags job's (W)
                
        // Population of chromosomes
        private Schedule[] _chromosomes;

        // Indicates weather chromosome belongs to best chromosome group
        private bool[] _bestFlags;

        // Indices of best chromosomes
        private int[] _bestChromosomes;

        // Number of best chromosomes currently saved in best chromosome group
        private int _currentBestSize;

        // Pointer to algorithm observer
        private Schedule.ScheduleObserver _observer;

        // Prototype of chromosomes in population
        public Schedule _prototype;

        // Current generation
        private int _currentGeneration;

        // State of execution of algorithm
        internal static AlgorithmState _state;

        // Pointer to global instance of algorithm
        private static Algorithm _instance;

        #endregion

        // Returns reference to global instance of algorithm
        public static Algorithm GetInstance()
        {
            // global instance doesn't exist?
            if (_instance == null)
            {
                // make prototype of chromosomes
                Schedule prototype = new Schedule(5, 5, 90, 10);

                // make new global instance of algorithm using chromosome prototype
                _instance = new Algorithm(1000, 180, 50, prototype, new Schedule.ScheduleObserver());
            }

            return _instance;
        }

        // Frees memory used by global instance
        public static void FreeInstance()
        {
            // free memory used by global instance if it exists
            if (_instance != null)
            {
                _instance._prototype = null;
                _instance._observer = null;
                _instance = null;
            }
        }

        // Initializes genetic algorithm
        public Algorithm(int numberOfChromosomes, int replaceByGeneration, int trackBest,
            Schedule prototype, Schedule.ScheduleObserver observer)
        {
            NumberOfChromosomes = numberOfChromosomes;
            TrackBest = trackBest;
            ReplaceByGeneration = replaceByGeneration;
            _currentBestSize = 0;
            _prototype = prototype;
            _observer = observer;
            _currentGeneration = 0;
            _state =  AlgorithmState.AS_USER_STOPPED;

            // reserve space for population
            _chromosomes = new Schedule[NumberOfChromosomes];
            _bestFlags = new bool[NumberOfChromosomes];

            // reserve space for best chromosome group
            _bestChromosomes = new int[TrackBest];

            // clear population
            for (int i = _chromosomes.Length - 1; i >= 0; --i)
            {
                _chromosomes[i] = null;
                _bestFlags[i] = false;
            }
            _instance = this;

            #region Find number of Active CPU or CPU core's for this Programs
            long Affinity_Dec = System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity.ToInt64();
            string Affinity_Bin = Convert.ToString(Affinity_Dec, 2); // toBase 2
            foreach (char anyOne in Affinity_Bin.ToCharArray())
                if (anyOne == '1') numCore++;
            #endregion
        }

        // Frees used resources
        ~Algorithm()
        {
            // clear population by deleting chromosomes 
            Array.Clear(_chromosomes, 0, _chromosomes.Length);
            _chromosomes = null;
            MultiThreads = null;
        }

        // Starts and executes algorithm
        public bool Start()
        {
            #region Start by initialize new population 
            if (_prototype == null)
                return false;

            if (Monitor.TryEnter(Locker0, 10))
            {
                // do not run already running algorithm
                if (_state == AlgorithmState.AS_RUNNING)
                {
                    Monitor.Exit(Locker0);
                    return false;
                }
                _state = AlgorithmState.AS_RUNNING;
                Monitor.Exit(Locker0);
            }
            else return false;
            
            if (_observer != null)
            {
                // notify observer that execution of algorithm has changed it state
                _observer.EvolutionStateChanged(_state);
            }

            if (!ResultControls.ResultForm._setting.Parallel_Process) // Single Process for GA
            {
                // clear best chromosome group from previous execution
                ClearBest_Sequence();

                // initialize new population with chromosomes randomly built using prototype
                for (int i = 0; i < _chromosomes.Length; i++)
                {
                    // remove chromosome from previous execution
                    if (_chromosomes[i] != null)
                        _chromosomes[i] = null;

                    // add new chromosome to population
                    _chromosomes[i] = _prototype.MakeNewFromPrototype();
                    AddToBest_Sequence(i);
                }
            }
            else // Multi Process for GA
            {
                // clear best chromosome group from previous execution
                ClearBest_Parallel();

                // initialize new population with chromosomes randomly built using prototype
                ParallelOptions options = new ParallelOptions();
                options.MaxDegreeOfParallelism = numCore;
                Parallel.For(0, _chromosomes.Length, options, i =>
                    {
                        // remove chromosome from previous execution
                        if (_chromosomes[i] != null)
                            _chromosomes[i] = null;

                        // add new chromosome to population
                        _chromosomes[i] = _prototype.MakeNewFromPrototype();
                        AddToBest_Parallel(i);
                    });
            }

            _currentGeneration = 0;
            #endregion
            //
            // create new Threads as for manual selected CPU core's
            //
            if (ResultControls.ResultForm._setting.Parallel_Process) // Multi Process
            {
                MultiThreads = new Thread[numCore];
                for (int cpu = 0; cpu < numCore; ++cpu)
                {
                    MultiThreads[cpu] = new Thread(new ParameterizedThreadStart(GA_Start));
                    MultiThreads[cpu].Name = "MultiThread_" + cpu.ToString();
                    MultiThreads[cpu].Start(true as object);
                }
                System.Diagnostics.Process.GetCurrentProcess().Threads.AsParallel();
            }
            else // Single Process
            {
                MultiThreads = new Thread[1];
                MultiThreads[0] = new Thread(new ParameterizedThreadStart(GA_Start));
                MultiThreads[0].Name = "MultiThread_0";
                MultiThreads[0].Start((object)false);
            }
            return true;
        }

        // new Thread for Start GA
        private void GA_Start(object Parallel_Mutex_On)
        {
            if ((Boolean)Parallel_Mutex_On) // Parallel Process Requirement's
            {
                #region GA for Mutex On

                while (true) //------------------------------------------------------------------------
                {
                    // user has stopped execution?
                    if (_state == AlgorithmState.AS_CRITERIA_STOPPED || _state == AlgorithmState.AS_USER_STOPPED)
                    {
                        break;
                    }
                    else if (_state == AlgorithmState.AS_SUSPENDED)
                    {
                        if (Thread.CurrentThread.IsAlive)
                            Thread.CurrentThread.Suspend();
                    }

                    // Save a Elite Chromosome for protection in Mutation and etc.
                    Schedule best = GetBestChromosome();

                    // algorithm has reached criteria?
                    if (best.GetFitness() >= 1)
                    {
                         _state = AlgorithmState.AS_CRITERIA_STOPPED;
                        break;
                    }


                    // produce offspring
                    Schedule[] offspring;
                    offspring = new Schedule[_replaceByGeneration];
                    Random rand = new Random();
                    for (int j = 0; j < _replaceByGeneration; j++)
                    {
                        Schedule p1;
                        Schedule p2;
                        // selects parent randomly
                        lock (Locker1)
                        {
                            p1 = _chromosomes[(rand.Next() % _chromosomes.Length)].MakeCopy(false);
                        }
                        lock (Locker1)
                        {
                            p2 = _chromosomes[(rand.Next() % _chromosomes.Length)].MakeCopy(false);
                        }

                        offspring[j] = p1.Crossover(p2);
                        lock (Locker1)
                        {
                            offspring[j].Mutation();
                            offspring[j].CalculateFitness();
                        }
                    }

                    // replace chromosomes of current operation with offspring
                    for (int j = 0; j < _replaceByGeneration; j++)
                    {
                        int ci;
                        do
                        {
                            // select chromosome for replacement randomly
                            ci = rand.Next() % _chromosomes.Length;

                            // protect best chromosomes from replacement
                        } while (IsInBest(ci));

                        lock (Locker1)
                        {
                            // replace chromosomes
                            _chromosomes[ci] = null;
                            _chromosomes[ci] = offspring[j];
                        }
                        // try to add new chromosomes in best chromosome group
                        AddToBest_Parallel(ci);
                    }

                    // algorithm has found new best chromosome
                    if (best != GetBestChromosome())
                    // notify observer
                    {
                        lock (Locker1)
                        {
                            _observer.NewBestChromosome(GetBestChromosome(), ResultControls.ResultForm._setting.Display_RealTime);
                        }
                    }
                    _currentGeneration++;
                }

                // The GA job's is Complete!
                if (_observer != null)
                {
                    lock (Locker0)
                    {
                        // notify observer that execution of algorithm has changed it state
                        _observer.EvolutionStateChanged(_state);
                    }
                }
                Thread.CurrentThread.Abort();
                #endregion
            }
            else
            {
                #region GA for Mutex Off
    
                while (true) //------------------------------------------------------------------------
                {
                    // user has stopped execution?
                    if (_state == AlgorithmState.AS_CRITERIA_STOPPED || _state == AlgorithmState.AS_USER_STOPPED)
                    {
                        break;
                    }
                    else if (_state == AlgorithmState.AS_SUSPENDED)
                    {
                        if (Thread.CurrentThread.IsAlive)
                            Thread.CurrentThread.Suspend();
                    }


                    // Save a Elite Chromosome for protection in Mutation and etc.
                    Schedule best = GetBestChromosome();

                    // algorithm has reached criteria?
                    if (best.GetFitness() >= 1)
                    {
                        _state = AlgorithmState.AS_CRITERIA_STOPPED;
                        break;
                    }

                    // produce offspring
                    Schedule[] offspring;
                    offspring = new Schedule[_replaceByGeneration];
                    Random rand = new Random();
                    for (int j = 0; j < _replaceByGeneration; j++)
                    {
                        // selects parent randomly
                        Schedule p1 = _chromosomes[(rand.Next() % _chromosomes.Length)];
                        Schedule p2 = _chromosomes[(rand.Next() % _chromosomes.Length)];

                        offspring[j] = p1.Crossover(p2);
                        offspring[j].Mutation();
                        offspring[j].CalculateFitness();
                    }

                    // replace chromosomes of current operation with offspring
                    for (int j = 0; j < _replaceByGeneration; j++)
                    {
                        int ci;
                        do
                        {
                            // select chromosome for replacement randomly
                            ci = rand.Next() % _chromosomes.Length;

                            // protect best chromosomes from replacement
                        } while (IsInBest(ci));

                        // replace chromosomes
                        _chromosomes[ci] = null;
                        _chromosomes[ci] = offspring[j];

                        // try to add new chromosomes in best chromosome group
                        AddToBest_Sequence(ci);
                    }

                    // algorithm has found new best chromosome
                    if (best != GetBestChromosome())
                    // notify observer
                    {
                        _observer.NewBestChromosome(GetBestChromosome(), ResultControls.ResultForm._setting.Display_RealTime);
                    }
                    _currentGeneration++;
                }

                // The GA job's is Complete!
                if (_observer != null)
                {
                    // notify observer that execution of algorithm has changed it state
                    _observer.EvolutionStateChanged(_state);
                }    
                
                Thread.CurrentThread.Abort();
                #endregion
            }
        }

        // Stops execution of algorithm
        public void Stop()
        {
            if (_state == AlgorithmState.AS_RUNNING)
            {
                _state = AlgorithmState.AS_USER_STOPPED;

                //for (int cpu = 0; cpu < MultiThreads.Length; cpu++)
                //    MultiThreads[cpu].Abort();
                //
                // Show Final Best Chromosome's
                _observer.NewBestChromosome(GetBestChromosome(), true);
            }
        }

        /// <summary>
        /// Resume Stopped algorithm
        /// </summary>
        /// <returns>if Successfully Resume then return true else false</returns>
        public bool Resume()
        {
            try
            {
                if (_state == AlgorithmState.AS_SUSPENDED)
                {
                    if (ResultControls.ResultForm._setting.Parallel_Process) // For Multi Process
                    {
                        _state = AlgorithmState.AS_RUNNING;

                        for (int cpu = 0; cpu < MultiThreads.Length; cpu++)
                            if (MultiThreads[cpu].ThreadState == ThreadState.Suspended)
                                MultiThreads[cpu].Resume();

                        System.Diagnostics.Process.GetCurrentProcess().Threads.AsParallel();
                    }
                    else // For Single Process
                    {
                        _state = AlgorithmState.AS_RUNNING;

                        if (MultiThreads[0].ThreadState == ThreadState.Suspended)
                            MultiThreads[0].Resume();
                    }
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, ex.Source);
                ResultControls.ResultForm.state = ThreadState.Stopped;
                _state = AlgorithmState.AS_USER_STOPPED;
                Thread.Sleep(1000);
                for (int cpu = 0; cpu < MultiThreads.Length; cpu++)
                    if (MultiThreads[cpu].IsAlive)
                        MultiThreads[cpu].Abort();
                return false;
            }
        }

        /// <summary>
        /// Pause Running algorithm
        /// </summary>
        /// <returns>if Try to Paused is successful then return True else false</returns>
        public bool Pause()
        {
            if (_state == AlgorithmState.AS_RUNNING)
            {
                if (Monitor.TryEnter(Locker0, 10))
                {
                    _state = AlgorithmState.AS_SUSPENDED;
                    Monitor.Exit(Locker0);

                    //for (int cpu = 0; cpu < MultiThreads.Length; cpu++)
                    //    if (MultiThreads[cpu].ThreadState == ThreadState.WaitSleepJoin ||
                    //        MultiThreads[cpu].ThreadState == ThreadState.Running)
                    //        MultiThreads[cpu].Suspend();
                    
                    //
                    // Show Final Best Chromosome's
                    _observer.NewBestChromosome(GetBestChromosome(), true);
                    return true;
                }
                else return false;
            }
            return false;
        }

        // Returns pointer to best chromosomes in population
        public Schedule GetBestChromosome()
        {
            return _chromosomes[_bestChromosomes[0]];
        }

        // Returns current generation
        public int GetCurrentGeneration() { return _currentGeneration; }

        // Return points to algorithm's observer
        public Schedule.ScheduleObserver GetObserver() { return _observer; }

        // Tries to add chromosomes in best chromosome group
        private void AddToBest_Parallel(int chromosomeIndex)
        {
            // don't add if new chromosome hasn't fitness big enough for best chromosome group
            // or it is already in the group?
            lock (Locker1)
            {
                if ((_currentBestSize == _bestChromosomes.Length &&
                    _chromosomes[_bestChromosomes[_currentBestSize - 1]].GetFitness() >=
                    _chromosomes[chromosomeIndex].GetFitness()) || _bestFlags[chromosomeIndex])
                    return;
            }
            // find place for new chromosome
            //var cts = new CancellationTokenSource();
            //var option = new ParallelOptions() { MaxDegreeOfParallelism = numCore, CancellationToken = cts.Token };
            //var loopResult = Parallel.For(_currentBestSize, 0, option, (i, loopState) =>
            //    { ... });
            int i = _currentBestSize;
            for (; i > 0; i--)
            {
                // group is not full?
                if (i < _bestChromosomes.Length)
                {
                        Monitor.Enter(Locker1);
                        // position of new chromosomes is found?
                        if (_chromosomes[_bestChromosomes[i - 1]].GetFitness() >
                            _chromosomes[chromosomeIndex].GetFitness())
                        {
                            Monitor.Exit(Locker1);
                            break;
                        }
                        Monitor.Exit(Locker1);
                    lock (Locker2)
                    {
                        // move chromosomes to make room for new
                        _bestChromosomes[i] = _bestChromosomes[i - 1];
                    }
                }
                else
                    lock (Locker2)
                    {
                        // group is full remove worst chromosomes in the group
                        _bestFlags[_bestChromosomes[i - 1]] = false;
                    }
            }

            lock (Locker2)
            {
                // store chromosome in best chromosome group
                _bestChromosomes[i] = chromosomeIndex;
                _bestFlags[chromosomeIndex] = true;
            }

            // increase current size if it has not reached the limit yet
            if (_currentBestSize < _bestChromosomes.Length)
                _currentBestSize++;
        }

        // Tries to add chromosomes in best chromosome group
        private void AddToBest_Sequence(int chromosomeIndex)
        {
            // don't add if new chromosome hasn't fitness big enough for best chromosome group
            // or it is already in the group?
            if ((_currentBestSize == _bestChromosomes.Length &&
                 _chromosomes[_bestChromosomes[_currentBestSize - 1]].GetFitness() >=
                 _chromosomes[chromosomeIndex].GetFitness()) || _bestFlags[chromosomeIndex])
                return;

            // find place for new chromosome
            int i = _currentBestSize;
            for (; i > 0; i--)
            {
                // group is not full?
                if (i < _bestChromosomes.Length)
                {
                    // position of new chromosomes is found?
                    if (_chromosomes[_bestChromosomes[i - 1]].GetFitness() >
                        _chromosomes[chromosomeIndex].GetFitness())
                        break;

                    // move chromosomes to make room for new
                    _bestChromosomes[i] = _bestChromosomes[i - 1];
                }
                else
                    // group is full remove worst chromosomes in the group
                    _bestFlags[_bestChromosomes[i - 1]] = false;
            }
            //
            // store chromosome in best chromosome group
            _bestChromosomes[i] = chromosomeIndex;
            _bestFlags[chromosomeIndex] = true;

            // increase current size if it has not reached the limit yet
            if (_currentBestSize < _bestChromosomes.Length)
                _currentBestSize++;
        }

        // Returns TRUE if chromosome belongs to best chromosome group
        private bool IsInBest(int chromosomeIndex)
        {
            return _bestFlags[chromosomeIndex];
        }

        // Clears best chromosome group
        private void ClearBest_Parallel()
        {
            lock (Locker2)
            {
                //for (int i = _bestFlags.Length - 1; i >= 0; --i)
                //    _bestFlags[i] = false;
                //
                ParallelOptions option = new ParallelOptions() { MaxDegreeOfParallelism = numCore };
                Parallel.For(_bestFlags.Length - 1, -1, option, i =>
                    {
                        _bestFlags[i] = false;
                    });
            }
            _currentBestSize = 0;
        }

        // Clears best chromosome group
        private void ClearBest_Sequence()
        {
            for (int i = _bestFlags.Length - 1; i >= 0; --i)
                _bestFlags[i] = false;

            _currentBestSize = 0;
        }
    }
}

# [Make Class Schedule](https://github.com/Behzadkhosravifar/MakeClassSchedule)
--------------------
[![Build status](https://ci.appveyor.com/api/projects/status/4cjm8ir7bswf6nse?svg=true)](https://ci.appveyor.com/project/Behzadkhosravifar/makeclassschedule)

Make university class schedule by Parallel Genetic Algorithm in C# WinForm.

--------------------------------
### Welcome

Thank you for choosing Make Class Schedule !
Make Class Schedule is one of those NP hard problems. The problem can be solved using a heuristic search algorithm to find the optimal solution, but it only works for simple cases. For more complex inputs and requirements, finding a considerably good solution can take a while, or it may be impossible. This is where genetic algorithms come in to the game. In this article, I assume that you are familiar with the basic concepts of genetic algorithms, and I won't describe them in detail because it has been done so many times before.
When you make a class schedule, you must take into consideration many requirements (number of professors, students, classes and classrooms, size of classroom, laboratory equipment in classroom, and many others). These requirements can be divided into several groups by their importance. Hard requirements (if you break one of these, then the schedule is infeasible):

* A class can be placed only in a spare classroom.
* No professor or student group can have more then one class at a time.
* A classroom must have enough seats to accommodate all students.
* To place a class in a classroom, the classroom must have laboratory equipment (computers, in our case) if the class requires it.

Some soft requirements (can be broken, but the schedule is still feasible):

* Preferred time of class by professors.
* Preferred classroom by professors.
* Distribution (in time or space) of classes for student groups or professors.

Hard and soft requirements, of course, depend on the situation.


**Algorithm**

The genetic algorithm is fairly simple. For each generation, it performs two basic operations:

1. Randomly selects N pairs of parents from the current population and produces N new chromosomes by performing a crossover operation on the pair of parents.
2. Randomly selects N chromosomes from the current population and replaces them with new ones. The algorithm doesn't select chromosomes for replacement if it is among the best chromosomes in the population.

And, these two operations are repeated until the best chromosome reaches a fitness value equal to 1 (meaning that all classes in the schedule meet the requirement). As mentioned before, the genetic algorithm keeps track of the M best chromosomes in the population, and guarantees that they are not going to be replaced while they are among the best chromosomes.

--------------------------------
### Feedback

Make Class Schedule v1.0.0.0 programmed and designed by Mr. Behzad Khosravi Far.
You can obtain free support for Make Class Schedule. You may email any questions/suggestions to:
Behzad.khosravifar@gmail.com
 
For contact him use this phone number: +989149149202
or use following Email: Behzadkh@Hotmail.com


--------------------------
### LICENSE INFORMATION      [![OSI-Approved-License-100x137.png](http://opensource.org/trademarks/opensource/OSI-Approved-License-100x137.png)](http://opensource.org/licenses/GPL-3.0.html)

This software is open source, licensed under the GNU General Public License, Version 3.0.
See [GPL-3.0](http://opensource.org/licenses/GPL-3.0.html) for details.
This Class Library creates a way of handling structured exception handling,
inheriting from the Exception class gives us access to many method
we wouldn't otherwise have access to
                  
Copyright (C) 2015-2016 [Behzad Khosravifar](mailto:Behzad.Khosravifar@Gmail.com)

This program published by the Free Software Foundation,
either version 1.0.1 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

# NameSorter
Name Sorter

Demo application on Name Sorting Coding Assessment.

Code sample is developed using .Net Framework 4.6.1 and it is a console application.

Contains three proejcts -
  1. name-sorter: main project
  2. name-sorter.Logic: library used
  3. name-sorter.Test: Dev Unit Test cases
  
Steps to run the application
----------------------------------
1. Download the source code from the repo.
2. Open Solution "NameSorter" in Visual Studio.
3. Build the Solution.
4. Executable named "name-sorter" will be created. This can be found at <your file path>\NameSorter\name-sorter\bin\Debug.
5. This accepts input file name containing unsorted names as the arguments.
6. Invoke this executable on console as follows from the above file location :
   Usage: name-sorter <file name containing unsorted names>
   e.g  name-sorter ./unsorted-names-list.txt
6. Output will be displayed on the screen and also saved in a file named "sorted-names-list.txt" at execution directory.

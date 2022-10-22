using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers


            var sum = numbers.Sum(); // works off an IEnumerable. This is is an extension method, which just means it's going to work off of something.
                                     //foreach (var num in numbers) //lines 27 through 30 here perform the same function as line 26's code.
                                     //{
                                     //    sum += num;
                                     //}

            //TODO: Print the Average of numbers
            Console.WriteLine("Linq exercises.");
            Console.WriteLine();
            Console.WriteLine("Average of a numbers list, as well as sum of a numbers list.");
            Console.WriteLine();
            var average = numbers.Average();
            Console.WriteLine($"Sum{sum}, average; {average}"); //Remember, we're printing the name of the assigned variables to the console.
            Console.WriteLine();


            //TODO: Order numbers in ascending order and print to the console

            //the .OrderBy extension method automatically orders values in a list or an array in an ascending manner.

            var asc = numbers.OrderBy(num => num); //if we don't give this method extension a parameter, it won't run. It would also serve no purpose, until a parameter has been determined for it.
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine();
            var desc = numbers.OrderByDescending(num => num);
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            //var desc1 = numbers.OrderByDescending(x => x.FirstName); An example of how you might order a list based on a specific property.

            //foreach (var x in numbers)
            //{
            //OrderBy x.FirstName
            //}
            Console.WriteLine();
            Console.WriteLine("Numbers greater than 6.");
            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6
            var greaterThan6 = numbers.Where(num => num > 6);
            //foreach (var num in numbers.Where(num => num > 6)); Could also be written this way.
            foreach (var num in greaterThan6)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine();
            Console.WriteLine("First seven numbers ascending.");
            Console.WriteLine();
            foreach (var num in asc.Take(7)) //we can use 'asc' as a list for this method extension because it has already been defined above.
            {
                Console.WriteLine(num); //Remember, you're starting with a collection, and refining it down with different method extensions.
            }
            Console.WriteLine();
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Altering the fourth index to a different number."); //expected the program to print the altered value at the fourth index....
            numbers[4] = 35;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C')|| person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);

            Console.WriteLine("Printing names of staff that start with an S or C.");
            Console.WriteLine();
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine();
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName).ThenBy(emp => emp.YearsOfExperience);
            Console.WriteLine("Staff members who are over the age of 26 years.");
            Console.WriteLine();
            foreach (var person in overTwentySix) //we also added a method extension to the variable above that provides for additonal filtering, using the 'ThenBy' phrase.
            {
                Console.WriteLine($"Full name: {person.FullName} YOE: {person.YearsOfExperience}");
            }
            Console.WriteLine();
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfYOE = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);
            Console.WriteLine("Printing the sum of all staff member's experience, then taking the average of it.");
            Console.WriteLine();
            Console.WriteLine($"Sum: {sumOfYOE}, Avg: {avgOfYOE}");
            //TODO: Add an employee to  the end of the list without using employees.Add()
            Console.WriteLine();
            Console.WriteLine("Adding a new staff member to the end of the list. Also adding age and years of experience characteristics for them.");
            employees = employees.Append(new Employee("first", "lastName", 98, 1)).ToList(); //append is a method extension which let's us add something to a list, but only to the end of it.
            foreach (var item in employees)
            {
                Console.WriteLine($"First name: {item.FirstName}, Age: {item.Age} Years of experience :{item.YearsOfExperience}");
            }
            

           
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}

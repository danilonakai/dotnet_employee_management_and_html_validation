/*
    Documentation:
        This program was created to read the data from a txt file in the class Employee, and sort according to Employee
        parameters.

        The sort method used was Insertion Sort.

        References:
        https://anh.cs.luc.edu/170/notes/CSharpHtml/sorting.html
 */


using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    /// <summary>
    /// The main class of the application
    /// </summary>
    class Program
    {
        const string DATAFILE = "employees.txt";
        static List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Prompts the user for input and returns the entered string.
        /// </summary>
        /// <returns>The user-input string.</returns>
        public string Prompt()
        {
            Console.Write("1. Sort by Employee Name (ascending)\n" +
                "2. Sort by Employee Number (ascending)\n" +
                "3. Sort by Employee Pay Rate (descending)\n" +
                "4. Sort by Employee Hours (descending)\n" +
                "5. Sort by Employee Gross Pay (descending)\n" +
                "6. Exit\n");

            string input = Console.ReadLine();

            return input;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Read();

            Program program = new Program();

            string input = program.Prompt();

            while (input != "6")
            {
                switch (input)
                {
                    case "1":
                        // Sort employees by name in ascending order
                        Console.WriteLine("\n");
                        employees.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
                        Console.WriteLine("\n");
                        break;

                    case "2":
                        // Sort employees by number in ascending order
                        Console.WriteLine("\n");
                        employees.Sort((emp1, emp2) => emp1.Number.CompareTo(emp2.Number));
                        Console.WriteLine("\n");
                        break;

                    case "3":
                        // Sort employees by pay rate in descending order
                        Console.WriteLine("\n");
                        employees.Sort((emp1, emp2) => emp2.Rate.CompareTo(emp1.Rate));
                        Console.WriteLine("\n");
                        break;

                    case "4":
                        // Sort employees by hours worked in descending order
                        Console.WriteLine("\n");
                        employees.Sort((emp1, emp2) => emp2.Hours.CompareTo(emp1.Hours));
                        Console.WriteLine("\n");
                        break;

                    case "5":
                        // Sort employees by gross pay in descending order
                        Console.WriteLine("\n");
                        employees.Sort((emp1, emp2) => emp2.Gross.CompareTo(emp1.Gross));
                        Console.WriteLine("\n");
                        break;
                }

                DisplayEmployees();

                input = program.Prompt();
            }

            Console.WriteLine("Bye!");
        }

        /// <summary>
        /// Reads employee data from the specified file and populates the employees list.
        /// </summary>
        static void Read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(DATAFILE))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] items = reader.ReadLine().Split(',');
                        employees.Add(new Employee(
                            items[0].Trim(),
                            int.Parse(items[1]),
                            decimal.Parse(items[2]),
                            double.Parse(items[3])
                        ));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading data: {e.Message}");
            }
        }

        /// <summary>
        /// Displays the details of each employee in the employees list.
        /// </summary>
        static void DisplayEmployees()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}

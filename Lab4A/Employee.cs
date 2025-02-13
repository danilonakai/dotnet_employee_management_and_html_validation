using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// The Employee class 
    /// </summary>
    class Employee : IComparable<Employee>
    {
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the hourly rate of the employee.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the number of hours worked by the employee.
        /// </summary>
        public double Hours { get; set; }

        /// <summary>
        /// Gets or sets the gross income of the employee.
        /// </summary>
        public decimal Gross { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">The name of the employee.</param>
        /// <param name="number">The employee number.</param>
        /// <param name="rate">The hourly rate of the employee.</param>
        /// <param name="hours">The number of hours worked by the employee.</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;

            if (hours > 40)
            {
                decimal extraHours = (decimal)hours - 40;
                Gross = (Rate * 40) + ((Rate * (decimal)1.5) * extraHours);
            }
            else
            {
                Gross = Rate * (decimal)hours;
            }
        }

        /// <summary>
        /// Compares the current instance with another instance of the Employee class.
        /// </summary>
        /// <param name="other">The other employee to compare to.</param>
        /// <returns>
        /// A value indicating the relative order of the objects being compared.
        /// </returns>
        public int CompareTo(Employee other)
        {
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"Employee:\t{Name}\t{Number}\t{Rate}\t{Hours}\t{Gross}";
        }
    }
}

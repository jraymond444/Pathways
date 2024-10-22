using System;
using System.Collections.Generic;
/*
*/
namespace week3
{
    class Program
    {
        static void Main(string [] args)
        {
                
            // Declare variables
            bool userChoice;
            string userChoiceString;
            //const int arrayRowSize = 25;
            //Employee[] empArray = new Employee[arrayRowSize];     
            List<Employee> empList = new List<Employee>();
            //string fileName = "EmployeeList.txt";

            empList.Add(new Intern ("Jimmy", "Dean", "intern",0));
            empList.Add(new Hourly("Dean","Jimmy","hourly",15.00));
            empList.Add(new Salary("Jake","Farm","salary",50000));

            foreach (Employee emp in empList)
            {
                Console.WriteLine(emp);
            } 
        }
    }
}
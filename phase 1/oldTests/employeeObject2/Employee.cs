using System;
using System.Collections.Generic;
/*  Employee class.  It will include first name, last name, and employee type.  
*/
namespace week3
{
    abstract class Employee
    {
        public string fName
        {get; set;}
        public string lName
        {get; set;}
        public string type
        {get; set;}
        //default construct
        public Employee()
        {
            fName = "Gary";
            lName = "Smith";
            type = "contractor";
        }
        //bonus method, will be reused in the children.
        public abstract string Bonus(double rate);  
        //input construct
        public Employee(string firstName, string lastName, string empType) 
        {
            this.fName = firstName;
            this.lName = lastName;
            this.type = empType;
        }
        //print employee record
        public override string ToString()
        {
            return (this.fName + " " + this.lName + " is a " + this.type + ". ");
        }
        
    }
 } 

using System;
/*  Employee class.  It will include first name, last name, and employee type.  
*/
namespace week3
{
    class Employee
    {
        public string fName
        {get; set;}
        public string lName
        {get; set;}
        public string type
        {get; set;}
        public double rate
        {get; set;}
        //default construct
        public Employee()
        {
            fName = "Gary";
            lName = "Smith";
            type = "contractor";
            rate = 5000;
        }
        //bonus method, will be reused in the children.
        public virtual string Bonus(double eRate)
        {
            return "This employees doesn't get a bonus. ";
        }   
        //input construct
        public Employee(string firstName, string lastName, string empType, double empRate) 
        {
            this.fName = firstName;
            this.lName = lastName;
            this.type = empType;
            this.rate = empRate;
        }
        //print employee record
        public override string ToString()
        {
            return (this.fName + " " + this.lName + " is a " + this.type + " employee and is paid " + this.rate.ToString("C2") + " per job. ");
        }
        
    }
 } 

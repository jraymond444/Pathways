using System;
/*  
This is the Intern class, a chile of Employee.  This will add the rate in addition to the Employee fields and calculate the bonus.
It'll then print the message including the bonus.
*/
namespace week3
{
    class Intern : Employee
    {
        public double rate
        {get; set;}
        //default construct using values from base() and adding the rate
        public Intern() : base()
        {
            this.type = "intern";
            rate = 0.00;
        }
  
        //input contruct using values from the input from both base() and the rate
        public Intern(string firstName, string lastName, string empType, double empRate):base(firstName, lastName, empType)
        {
            this.rate = empRate;
        }
       
        //display the Employee record, including their bonus 
        public override string ToString()
        {
            return (this.fName + " " + this.lName + " is an " + this.type + " and is not paid, but they get a bonus at the end of their run in this amount:  " + Bonus(this.rate) + ".");
        }

        //calculate the bonus
        public override string Bonus(double empRate)
        {
            double bonusAmt = 500;
            return bonusAmt.ToString("C2");
        } 
    }
 } 

using System;
/*  
This is the Contractor class, a chile of Employee.  This will add the rate in addition to the Employee fields and calculate the bonus.
It'll then print the message including the bonus.
*/
namespace week3
{
    class Contractor : Employee
    {
        public double rate
        {get; set;}
        //default construct using values from base() and adding the rate
        public Contractor() : base()
        {
            rate = 5000;
        }
  
        //input contruct using values from the input from both base() and the rate
        public Contractor(string firstName, string lastName, string empType, double empRate):base(firstName, lastName, empType)
        {
            this.rate = empRate;
        }
       
        //display the Employee record, including their bonus 
        public override string ToString()
        {
            return (this.fName + " " + this.lName + " is a " + this.type + " paid  " + this.rate.ToString("C2") + " and if they complete the job, their bonus is " + Bonus(this.rate) + ".");
        }

        //calculate the bonus
        public override string Bonus(double empRate)
        {
            double bonusAmt = empRate * .05;
            return bonusAmt.ToString("C2");
        } 
    }
 } 

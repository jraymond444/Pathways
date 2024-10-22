using System;
/*
This is the Salary class, another child to Employee.  This adds the rate and calculates the salaried bonus and prints the message.  
*/
namespace week3
{
    class Salary : Employee
    {
        public double rate
        {get; set;}

        //default construct with values from base() and the rate
        public Salary() : base()
        {
            rate = 50000;
        }
        //construct from input, including values from base and the rate
        public Salary(string firstName, string lastName, string empType, double empRate):base(firstName, lastName, empType)
        {
            this.rate = empRate;
        }
        //print the message along with the bonus amount
        public override string ToString()
        {
            return (this.fName + " " + this.lName + " is a " + this.type + " employee and paid at an annual rate of  " + this.rate.ToString("C2") + " and their bonus is " + Bonus(this.rate) + ".");
        }
        //calculate the bonus for salary
        public override string Bonus(double empRate)
        {
            double bonusAmt = empRate * .10;
            return bonusAmt.ToString("C2");
        } 
    }
 } 

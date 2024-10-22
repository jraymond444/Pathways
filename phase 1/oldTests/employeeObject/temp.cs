using System;
/*  
This is the Temp class, a chile of Employee.  This will add the rate in addition to the Employee fields and calculate the bonus.
It'll then print the message including the bonus.
*/
namespace week3
{
    class Temp : Hourly
    {
        public double rate
        {get; set;}
        public int hours
        {get; set;}
        public double eRate
        {get; set;}
        //default construct using values from base() and adding the rate
        public Temp() : base()
        {
            rate = 25.00;
            hours = 20;
        }
  
        //input contruct using values from the input from both base() and the rate
        public Temp(string firstName, string lastName, string empType, double empRate,int empHours):base(firstName, lastName, empType, empRate)
        {
            this.hours = empHours;
            this.eRate = empRate;           
        }

        
        //display the Employee record, including their bonus 
        public override string ToString()
        {
            return (this.fName + " " + this.lName + " is a " + this.type + " and they are paid time and a half:  " + Overtime(this.eRate, this.hours) + " based on " + this.hours + " worked and " + this.eRate.ToString("C2") + " per hour.");
        }

        //calculate the bonus
        public override string Bonus(double empRate)
        {
            double bonusAmt = empRate;
            return bonusAmt.ToString("C2");
        }
        public string Overtime(double empRate, int hours)
        {
            double overtime = empRate * 1.5 * hours;
            return overtime.ToString("C2");
        } 
    }
 } 

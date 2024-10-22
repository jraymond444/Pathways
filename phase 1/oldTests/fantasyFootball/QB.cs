using System;
/*  
This is the qb class.  It'll use the player interface and provide the fantasy points calculated for qb stats.
*/
namespace football
{
    class QB : Players, IfantasyPoints
    {
        public double fantasyPoints
        {get; set;}
        //default construct using values from base() and adding the rate
        public QB() : base()
        {
            double fantasyPoints = 15.00;
        }
  
        //input contruct using values from the input from both base() and the rate
        public QB(string inpFirstName, string inpLastName, string inpPosition, double inpYards, int inpTouchdowns):base(inpFirstName, inpLastName, inpPosition, inpYards, inpTouchdowns)
        {
            this.fantasyPoints = FantasyPointsCalculated(YardPoints(this.yards), TouchPoints(this.touchdowns));  
        }
       
        //display the Employee record, including their bonus 
        public override string ToString()
        {
            return (this.firstName + " " + this.lastName + " is a " + this.position + " and scored  " + this.fantasyPoints + ".");
        }
        public double YardPoints(double yards)
        {
            //double yardPoints;
            return yards = this.yards / 25;
        }
        public double TouchPoints(int touchdowns)
        {
            double touchdownPoints;
            return touchdownPoints = this.touchdowns * 4;
        }
        //calculate the points
        public override double FantasyPointsCalculated(double yardPoints, double touchdownPoints)
        {
            return yardPoints + touchdownPoints;
        } 
    }
 } 

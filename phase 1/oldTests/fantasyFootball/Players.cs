using System;
/*  
This is the qb class.  It'll use the player interface and provide the fantasy points calculated for qb stats.
*/
namespace football
{
    public abstract class Players
    {
        public string firstName  // property
            { get; set; }

        public string lastName  // property
            { get; set; }

        public string position  //property
            { get; set; } 
        public double yards // property
            {get; set; }
        public int touchdowns //property
            {get; set; }

        //default construct 
        public Players() 
        {
            firstName = "";
            lastName = "";
            position = "";
            yards = 0;
            touchdowns = 0;
        }
  
        //input construct 
        public Players(string inpFirstName, string inpLastName, string inpPosition, double inpYards, int inpTouchdowns)
        {
            firstName = inpFirstName;
            lastName = inpLastName;
            position = inpPosition;
            yards = inpYards;
            touchdowns = inpTouchdowns;
        }
       
        //display player info and points 
        public override string ToString()
        {
            return (this.firstName + " " + this.lastName + " is a " + this.position + ".");
        }

        public abstract double FantasyPointsCalculated(double yardsPoints, double touchdownPoints); //adds yards and touchdown points together

        //calculate the yard points...this one doesn't matter because this is an abstract class
        /*public double YardPoints(int yards)
        {
            return yards;
        } 
        //calculate the touchdown points...this one doesn't matter because this is an abstract class
        public double TouchPoints(int touchdowns)
        {
            return touchdowns;
        }
        */
    }
 } 

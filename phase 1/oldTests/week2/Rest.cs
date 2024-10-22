using System;
/*  
*/
namespace restaurants
{
    class Rest
    {
        public string name
        {get; set;}
        public int rating
        {get; set;}
        public Rest()
        {
            name = "Restaurant";
            rating = "5";
        }   
        public Rest(string restName, string restRating) 
        {
            this.name = restName;
            this.rating = restRating;               
        }
        
        public override string ToString()
        {
            return ("Restaurant: " + this.name + " Rating: " + this.rating);
        }
        
    }
 } 

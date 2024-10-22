using System;
/*  
*/
namespace Cars
{
    class Car
    {
        public string Color
        {get; set;}
        public string Model
        {get; set;}
        public Car()
        {
            Color = "yellow";
            Model = "Mazda 3";
        }   
        public Car(string modelName, string colorName) 
        {
            this.Model = modelName;
            this.Color = colorName;               
        }
        
        public override string ToString()
        {
            return ("Car color: " + this.Color + " Car model: " + this.Model);
        }
        
    }
 } 

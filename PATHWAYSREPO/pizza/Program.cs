using System;
/*This program will ask for user input to determine how many pizza's to order
  Step 1: Ask how many people will be there
  Step 2: Ask how many slices will they eat on average
  Step 3: Display how many pizzas they will need to order
*/
namespace pizza
{
    class Program
    {
        static void Main(string [] args)
        {
            //declare variables
            double people;
            double pizzas;
            double slicesWanted;
            const int slices = 8;
            
            //Ask for input to determine how many people
            Console.Write("How many people are coming to the party?");
            people = Convert.ToDouble(Console.ReadLine());
            
            //Ask for input to determine how many slices they want to eat
            Console.Write("How many slices does each person want on average?");
            slicesWanted = Convert.ToDouble (Console.ReadLine());  
            
            //Calculate number of pizzas needed.
            pizzas = (people * slicesWanted)/slices; 
            Console.WriteLine("You will need to order ", pizzas, "pizzas");
            Console.ReadKey();
        }   
    }
 }  
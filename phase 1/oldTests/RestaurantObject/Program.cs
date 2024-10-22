using System;
/*
*/
namespace restaurants
{
    class Program
    {
        static void Main(string [] args)
        {
            Rest[] restArray = new Rest[4];

            for (int index = 0; index < restArray.Length; index++)
            {
                restArray[index] = new Rest();
            }

            restArray[0] = new Rest("Mcdonalds", 3);
            restArray[1] = new Rest();
            restArray[2] = new Rest("Burger King", 2);
            restArray[3] = new Rest();   

            for (int i = 0; i < restArray.Length; i++)
            {
                Console.WriteLine(restArray[i].name + " " + restArray[i].rating);
            }
        }
    }
 }  

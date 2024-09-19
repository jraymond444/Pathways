using System;

namespace Feet2inches
{
    class Program
    {
        static void Main(string [] args)
        {
            double inches, feet;
            Console.Write("Enter number of feet:  ");
            feet = Convert.ToDouble(Console.ReadLine());   
            inches = feet*12;
            Console.WriteLine("{0} Feet equals {1} Inches", feet, inches);
            Console.ReadKey();
        }   
    }
    
}
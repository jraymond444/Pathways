using System;

namespace Exponent
{
    class Program
    {
        static void Main(string[] args)
        {
            int aBase, bExponent, eExponent; 
            bool again = true;

            do {
                Console.WriteLine("Please enter the base ");
                aBase = getValidInt();

                Console.WriteLine("Please enter the beginning exponent ");
                bExponent = getValidInt();

                do {
                    Console.WriteLine("Please enter the ending exponent.  Make sure it is greater than the beginning ");
                    eExponent = getValidInt();
                } while (bExponent > eExponent);

                for (int i = bExponent; i < (eExponent + 1); i++)       
                { 
                    Console.WriteLine("The base " + aBase + " to the power " + bExponent + " is " + Power(aBase,bExponent));
                    bExponent = bExponent + 1;
                }    

                Console.WriteLine("Again? (y) or (n) ");
                again = (Console.ReadLine().ToUpper() =="Y");
            } while (again);
        }

        /*The method Power will do the following:
            Take in a base value, and an exponent value
            Perform the calculation using math.pow
            Return the result
        */
        static int Power(int num, int exponent)
        {
            int result;
            result = (int)Math.Pow(num, exponent);
            return result;
        }

        /*The valid method will validate that the input value is numeric and > 1
          If it is valid, we return that value.
          If it is invalid, we return a 0.  
        */
        static int getValidInt()
        {
            bool isInt;
            int userExponent;

            Console.WriteLine("Please enter a valid integer > 0");

            do
            {
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out userExponent);

                if (!isInt || userExponent < 1)
                {
                    Console.WriteLine("Please enter a valid integer greater than 0!");
                }
            } while (!isInt || userExponent < 1);

            return userExponent;

        }
    }
}

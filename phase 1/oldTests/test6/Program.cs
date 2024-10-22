/*
This program will take in input from the user for a base value and an exponent.  It'll calculate the results and print them.
We'll keep doing this until the user decides it is time to exit.  Once they type exit the program will end.  We'll be utilizing
2 methods in this program.  Power to calculate the results, and Validate to ensure we have valid numeric input.
1. Take in the base input
    - Loop through until the valid method returns a good value.
        -Or until the user writes "exit" on the command prompt.
2. Take in exponent input
    - Loop through until the valid method returns a good value.
        -Or until the user writes "exit" on the command prompt.
3. Once we have valid values, we pass both values to the power method.
4. The power method will return the results and we'll print out the value.
5. At this point we'll prompt the user to input a new base/exponent or they can exit.
*/
using System;

namespace Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double inpNum = 0;
            double inpEx = 0;
            string inputBase;
            string inputExponent;
            double answer;
            double valNum;
            double valEx;
            string baseExit = "xx";
            string exponentExit = "yy";

            //Loop asking for input until the user writes "exit"
            while (true)
            {
                Console.WriteLine("Please enter a base numer first, then the exponent. To quit, enter 'exit' ");
                while (baseExit.ToLower() != "exit" || exponentExit.ToLower() != "exit")
                {
                    //loop until we get a valid base number
                    while (true)
                    {
                        Console.WriteLine("Please enter a valid base number, greater than or equal to 1 ");
                        inputBase = Console.ReadLine();
                        if (inputBase == "exit")
                        {
                            baseExit = inputBase;
                            break;
                        }
                        valNum = Valid(inputBase);

                        if (valNum == 0)
                        {
                            Console.WriteLine("Base entry invalid, please enter a valid number, greater than or equal to 1 ");
                        }

                        else
                        {
                            inpNum = valNum;
                            break;
                        }
                    }
                    if (inputBase == "exit")
                    {
                        break;
                    }
                    else
                        //loop until we get a valid exponent
                        while (true)
                        {
                            Console.WriteLine("Please enter a valid exponent, greater than or equal to 1 ");
                            inputExponent = Console.ReadLine();
                            if (inputExponent == "exit")
                            {
                                exponentExit = inputExponent;
                                break;
                            }

                            valEx = Valid(inputExponent);

                            if (valEx == 0)
                            {
                                Console.WriteLine("Exponent entry invalid, please enter a valid number, greater than or equal to 1 ");
                            }
                            else
                            {
                                inpEx = valEx;
                                break;
                            }
                        }
                    if (inputExponent == "exit")
                    {
                        break;
                    }
                    //write out the answer that was returned from the power method
                    answer = Power(inpNum, inpEx);
                    if (answer > 1)
                    {
                        Console.WriteLine("The answer is: " + answer + " ");
                        Console.WriteLine("Please enter another base number or exit to quit. ");
                    }
                    inpNum = 0;
                    valEx = 0;
                }

                if (baseExit.ToLower() == "exit" || exponentExit.ToLower() == "exit")
                {
                    Console.WriteLine("Thank you! ");
                    break;
                }
            }
        }

        /*The method Power will do the following:
            Take in a base value, and an exponent value
            Perform the calculation using math.pow
            Return the result
        */
        static double Power(double num, double exponent)
        {
            double result;
            result = Math.Pow(num, exponent);
            return result;
        }

        /*The valid method will validate that the input value is numeric and > 1
          If it is valid, we return that value.
          If it is invalid, we return a 0.  
        */
        static double Valid(string number)
        {
            double validResult;
            double invalidResult = 0;

            double.TryParse(number, out validResult);

            if (validResult >= 1)
            {
                return validResult;
            }
            else
            {
                return invalidResult;
            }
        }
    }
}
using System;
/*T
  Step 1: Take input from the user until they've entered 5 numbers.
  Step 2: For each number they enter, validate it and then determine whether or not it is lager than the last.
  Step 3: If it is larger than the last, replace the value in maxNum 
  Step 4: Write out the biggest number, which is stored in maxNum
*/
namespace maxNum
{
    class Program
    {
        static void Main(string [] args)
        {
            //declare variables
            double inputNum; 
            double maxNum = 1;
            double minNum = 5;
            double avgNum;
            double accumNum = 0;

            Console.WriteLine("Please enter 5 numbers ");       

            //Enter numbers

            int i = 0;
            while (i < 5) 
            {
                Console.Write("Please enter valid number between 1 and 100 ");
                inputNum = Convert.ToDouble(Console.ReadLine());               
                while (inputNum < 1 || inputNum > 100)
                    {
                    Console.Write("Try again: ");
                    inputNum = Convert.ToDouble(Console.ReadLine());
                    }
                if (inputNum > maxNum)
                    {
                        maxNum = inputNum;
                    }
                if (inputNum < minNum)
                    {
                        minNum = inputNum;
                    }
                accumNum += inputNum;
                i++;
            } //end while loop

            avgNum = accumNum / 5;

            //Display the final grade
            Console.WriteLine("The largest number is: " + maxNum);
            Console.WriteLine("The smallest number is: " + minNum);
            Console.WriteLine("The average of what was entered is: " + avgNum);
            Console.WriteLine("The total of all the numbers is: " + accumNum);

        }   
    }
 } 
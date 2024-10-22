using System;
/*This program will ask for user input to determine how many pizza's to order
  Step 1: Explain the grade entry process and the weights involved. 
  Step 2: Ask for grade entry for each type of work.  We will have homework, quizzes, and weights.
  Step 3: Calculate the final grade using the input and the weights. 
  Step 4: Display the final grade. 
*/
namespace grades
{
    class Program
    {
        static void Main(string [] args)
        {
            //declare variables
            int hwGrade, quizGrade, projectGrade;
            double hwWeight = .5; 
            double quizWeight = .25; 
            double projectWeight = .25;
            double finalGrade;
            
            //Explain what we are doing then ask for input for each grade type
            Console.WriteLine("We will be doing grade entry and calculating the final grade. Homework will be 50% of the grade, quizzes will be 25%, and projects will be 25%.");
            Console.Write("Please enter the homework grade between 0 and 100: ");
            hwGrade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the quiz grade between  0 and 100: ");
            quizGrade = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the project grade between  0 and 100: ");
            projectGrade = Convert.ToInt32(Console.ReadLine());
            
            finalGrade = (hwGrade * hwWeight) + (quizGrade * quizWeight) + (projectGrade * projectWeight);

            //Display the final grade
            Console.WriteLine("The final grade is: ", finalGrade);
            Console.ReadKey();
        }   
    }
 }  
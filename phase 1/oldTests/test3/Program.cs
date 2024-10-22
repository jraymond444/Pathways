using System;
/*This program will ask for user input to determine how many pizza's to order
  Step 1: Explain the grade entry process and the weights involved. 
  Step 2: Ask for grade entry for each type of work.  We will have homework, quizzes, and weights.
  Step 3: Calculate the final grade using the input and the weights. 
  Step 4: Display the final grade. 

  Future enhancements:
    -Take in multiple grades for each type of work
    -Convert the grade to a letter grade  ----done but commented
    -Add data validation to ensure the user enters a valid grade ---- done but commented
        -Or we could assume anything over 100 is extra credit
    -Handle multiple students
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
            
            //Enter valid gardes
            Console.Write("Please enter the homework grade between 0 and 100: ");
            hwGrade = Convert.ToInt32(Console.ReadLine());
            if (hwGrade < 0 || hwGrade > 100)
                {
                    Console.Write("Please enter a valid grade: ");
                    hwGrade = Convert.ToInt32(Console.ReadLine());
                }
                
            Console.Write("Please enter the quiz grade between  0 and 100: ");
            quizGrade = Convert.ToInt32(Console.ReadLine());
            if (quizGrade < 0 || quizGrade > 100)
                {
                    Console.Write("Please enter a valid grade: ");
                    quizGrade = Convert.ToInt32(Console.ReadLine());
                }
                
            Console.Write("Please enter the project grade between  0 and 100: ");
            projectGrade = Convert.ToInt32(Console.ReadLine());
            if (projectGrade < 0 || projectGrade > 100)
                {
                    Console.Write("Please enter a valid grade: ");
                    projectGrade = Convert.ToInt32(Console.ReadLine());
                }
            
            //Calculate final grade
            finalGrade = (hwGrade * hwWeight) + (quizGrade * quizWeight) + (projectGrade * projectWeight);

            //Display the final grade
            Console.WriteLine("The final grade is: " + finalGrade);

            //Convert to a letter grade and dispaly it
            switch (finalGrade)
                {
                    case < 60:
                        Console.WriteLine("They earned an F");
                    break;  
                    case >= 60 and < 70:
                        Console.WriteLine("They earned an D");
                    break;
                    case >= 70 and < 80:
                        Console.WriteLine("They earned an C");
                    break;
                    case >= 80 and < 90:
                        Console.WriteLine("They earned an B");
                    break;
                    case > 90:
                        Console.WriteLine("They earned an A");
                    break;
                }
        }   
    }
 } 
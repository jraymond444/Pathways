using System;

namespace Exponent
{
    class Program
    {
        /*
        In this program we will ask for the number of students, calculate the grades for each student, and write them out.
        1. Ask for number of students.
            2. Loop through that number of students.
                Take in the student's name.
            3. Loop through the homework entry.  There wil be 5 assignments entered.
                Calculate the average score of the homework assignments.  
            4. Loop through the quiz entry.  There will be 3 quizzes.
                Calculate the average quiz score.
            5. Loop through the exam entry.  There will be 2 exams.
                Calculate the average exam score.
            6. Calculate and display the final score along with the student's name.
        7. Exit the student loop and write out a message saying we're done.
        */
        static void Main(string[] args)
        {
            //variables 
            int hwGrade, quizGrade, examGrade, studentNum;
            int hwGradeTot = 0;
            int quizGradeTot = 0;
            int examGradeTot = 0;
            double hwWeight = .5;
            double quizWeight = .3;
            double examWeight = .2;
            double finalGrade, hwGradeAvg, quizGradeAvg, examGradeAvg;
            string studentName;

            //1. prompt the user to enter the number of students.
            Console.WriteLine("We are entering grades, first write down how many students are in the calss, then enter the grades for each. ");
            studentNum = GetValidInt();

            //2. loop through the number of student's that were entered to provide grades for each
            for (int i = 0; i < studentNum; i++)
            {
                Console.WriteLine("Please enter the student's name ");
                studentName = (Console.ReadLine());

                //3. loop for homework entry.  We'll also calculate the homework average
                Console.WriteLine("Please enter 5 grades for homework: ");
                for (int j = 0; j < 5; j++)
                {
                    hwGrade = GetValidGrade();
                    hwGradeTot += hwGrade;
                }
                hwGradeAvg = hwGradeTot / 5;

                //4. loop for the quiz entry, we'll also calculate the quiz average
                Console.WriteLine("Please enter 3 grades for quizzes: ");
                for (int j = 0; j < 3; j++)
                {
                    quizGrade = GetValidGrade();
                    quizGradeTot += quizGrade;
                }
                quizGradeAvg = quizGradeTot / 3;

                //5. loop for the exam entry.  we'll also calculate the exam average
                Console.WriteLine("Please enter 2 grades for exams: ");
                for (int j = 0; j < 2; j++)
                {
                    examGrade = GetValidGrade();
                    examGradeTot += examGrade;
                }
                examGradeAvg = examGradeTot / 2;

                //6. calculate the final grade using the weights for each grade type and write it out along with the student's name
                finalGrade = (examGradeAvg * examWeight) + (quizGradeAvg * quizWeight) + (hwGradeAvg * hwWeight);
                Console.WriteLine(studentName + "'s final grade is " + finalGrade);

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

                //Initialize all the variables so they are ready for the next student in the loop
                finalGrade = 0;
                hwGradeTot = 0;
                quizGradeTot = 0;
                examGradeTot = 0;

            }//student loop   
            //7. Let the user know we are done entering grades. 
            Console.WriteLine("All grades have been entered. ");
        }//void main

        /*The valid method will validate that the input value is numeric and > 1
          First it will take the input and use try parse to make sure it is numeric
          Then it will check that the value is larger than 0
          If it fails either case, we'll prompt the user to enter valid input
          Once we pass the checks and have a valid input, we return it. 
        */
        static int GetValidInt()
        {
            bool isInt;
            int userStudentNum;
            do
            {
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out userStudentNum);

                if (!isInt || userStudentNum < 1)
                {
                    Console.WriteLine("Please enter at least one student. ");
                }
            } while (!isInt || userStudentNum < 1);

            return userStudentNum;

        }
        /*The getValidGrade method will validate that the input value is numeric and between 0 and 100.
          First it will take the input and use try parse to make sure it is numeric
          Then it will check that the value is larger than 0 and less than 100
          If it fails either case, we'll prompt the user to enter valid input
          Once we pass the checks and have a valid input, we return it. 
        */
        static int GetValidGrade()
        {
            bool isInt;
            int userGrade;
            do
            {
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out userGrade);

                if (!isInt || userGrade < 0 || userGrade > 100)
                {
                    Console.WriteLine("Please enter at a valid grade between 0 and 100 ");
                }
            } while (!isInt || userGrade < 0 || userGrade > 100);

            return userGrade;

        }
    }
}

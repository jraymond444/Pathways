using System;

namespace Exponent
{
    class Program
    {
        /*
        In this program will have a hard coded array where we will have 3 methods and write output for each.
        
        1. Define array and hard coode the values where columns are the students and rows are the scores.
            1b. loop through each row for each student and accumulate the scores so we can calculate the average.
        2. call min method using the average array
        3. call max method using the average array
        4. call sum method then use the results to calculate the average.

        */
        static void Main(string[] args)
        {
            //variables 
            int[,] studentScores = {{70, 55, 90}, {98, 94, 98}, {84, 75, 36}, {55, 66, 77}};
            double sum = 0;
            double total = 0;
            double average = 0;
            double classAverage = 0;
            double minAverage = 101;
            double maxAverage = 0;
            double [] avgArray = new double[studentScores.GetLength(1)];
            double [,] studentArray = new double[studentScores.GetLength(0),studentScores.GetLength(0)];
            //Console.WriteLine(studentScores.GetLength(0));
            //Console.WriteLine(studentScores.GetLength(1));
            //Console.ReadLine();
            for (int scores = 0; scores < studentScores.GetLength(1); scores++)
                {
                    for (int student = 0; student < studentScores.GetLength(0); student++)
                    {
                        sum += studentScores[student, scores];  
                    }
                    average = sum / studentScores.GetLength(0);
                    sum = 0;
                    ////////////////here would be where I need to figure out how to load a multidimentional array to include which student the average belongs to
                    avgArray[scores] = average;
                    ///////////studentArray[scores, average];

                    Console.WriteLine("For student number " + scores + " the average grade was " + average);// + avgArray[scores]);
                }      
            minAverage = GetArrayMin(avgArray);
            double minStudent = GetStudentMin(avgArray);
            Console.WriteLine("The lowest average grade was " + minAverage + " by student " + minStudent);
            maxAverage = GetArrayMax(avgArray);
            Console.WriteLine("The highest average grade was " + maxAverage);
            total = GetArraySum(avgArray);
            classAverage = total / avgArray.Length;
            Console.WriteLine("The average class grade was " + classAverage);

        }//void main

        /*The getArrayMin method will loop through the input array and replace the min value each team an element is less than previous, resulting in the min value
          being the smallest value in the array after we are done looping.
          It will then write out the lowest value.
        */
        static double GetArrayMin(double[] arr)
        {
            double min = arr[0];
            foreach (double i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }
        static double GetStudentMin(double[] arr)
        {
            double min = arr[0];
            double minIndex = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        /*
        The getArrayMax method will loop through the input array and replace the max value each team an element is greater than previous, resulting in the max value
          being the largest value in the array after we are done looping.
          It will then write out the largest value.
        */
        static double GetArrayMax(double[] arr)
        {
            double max = arr[0];
            foreach (double i in arr)
            {
                if (i > max)
                {
                    max = i;
                } 
            } 
            return max;
        }
        /*The getArraySum method will loop through an array and add each element to the last value in sum until the loop is completed.
          Then we will write the sum out.
        */
        static double GetArraySum(double[] arr)
        {
            double sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            } 
            return sum;
        }
    }
}

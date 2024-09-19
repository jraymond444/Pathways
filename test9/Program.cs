using System;

namespace Exponent
{
    class Program
    {
        /*
        In this program will have a hard coded array where we will have 3 methods and write output for each.
        
        1. Define array and hard coode the values.
        2. call min method
        3. call max method
        4. call sum method then use the results to calculate the average.

        */
        static void Main(string[] args)
        {
            //variables 
            int[] baseNum = {11, 15, 2, 3, 41, 5, 66, 7, 8, 9, 5, 27, -1, 70};
            double total, average;  
            Console.WriteLine(baseNum.Length);
            
            GetArrayMin(baseNum);
            GetArrayMax(baseNum);
            total = GetArraySum(baseNum);
            average = total / baseNum.Length;

            Console.WriteLine(average);

        }//void main

        /*The getArrayMin method will loop through the input array and replace the min value each team an element is less than previous, resulting in the min value
          being the smallest value in the array after we are done looping.
          It will then write out the lowest value.
        */
        static void GetArrayMin(int[] arr)
        {
            int min = arr[0];
            foreach (int i in arr)
            {
                if (i < min)
                {
                    min = i;
                } 
            } 
            Console.WriteLine(min);
        }
        /*The getArrayMax method will loop through the input array and replace the max value each team an element is greater than previous, resulting in the max value
          being the largest value in the array after we are done looping.
          It will then write out the largest value.
        */
        static void GetArrayMax(int[] arr)
        {
            int max = arr[0];
            foreach (int i in arr)
            {
                if (i > max)
                {
                    max = i;
                } 
            } 
            Console.WriteLine(max);
        }
        /*The getArraySum method will loop through an array and add each element to the last value in sum until the loop is completed.
          Then we will write the sum out.
        */
        static int GetArraySum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            } 
            Console.WriteLine(sum);
            return sum;
        }
    }
}

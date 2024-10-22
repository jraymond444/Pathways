using System;

namespace Methods
{
    class Program
    {        
        static void Main(string [] args)
        {
            //int x = Validate(1, 100, "Please enter a number: ");
            Console.WriteLine(x);

            Console.WriteLine(Validate(-50, 50, "Please enter another number: "));
            //Console.WriteLine(y);

        }   
        static int Validate(int lowNum, int highNum, string prompt)
        {    
            //int inputNum;
            int num;
            Console.WriteLine(prompt);        
            string inputNum = Console.ReadLine(); 
            if (int.TryParse(inputNum, out num))
                {
                    while  (num < lowNum || num > highNum)

                            {
                                Console.Write("Please enter a valid num in range: " + lowNum + " through " + highNum + " ");
                                num = Convert.ToInt32(Console.ReadLine());
                            }
                            
                    return num;
                }
            else
                {
                    Console.WriteLine("You didn't end a valid number: ");
                    return num;
                }
        }
           
    }
}
  



using System;
/*
*/
namespace Cars
{
    class Program
    {
        static void Main(string [] args)
        {
            Car[] myCars = new Car[4];

            Car car1 = new Car();   
            Car car2 = new Car("honda","red");
            string carColor = "blue";
            string carModel = "mazda 3";  
            Car car3 = new Car(carModel, carColor);
            Console.WriteLine(car1.Color);
            Console.WriteLine(car1.Model);

        Console.WriteLine(car2.Color + " " + car2.Model);
        Console.WriteLine(car3.Color + " " + car3.Model);
        //Console.WriteLine(car2.Model);

        myCars[0] = car1;
        myCars[1] = car2;
        myCars[2] = car3;
        myCars[3] = new Car();
        for (int i = 0; i < myCars.Length; i++)
        {
            Console.WriteLine(myCars[i].Color + " " + myCars[i].Model);
        }
        for (int i = 0; i < myCars.Length; i++)
        {
            Console.WriteLine(myCars[i]);   
        }
        }   
    }
 }  

using System;
/*
*/
namespace test11
{
    class Program
    {
        static void Main(string [] args)
        {
            
            //test all constructs....MusicValue is the child to Music
            MusicValue testobj = new MusicValue();
            Music testobj2 = new Music();
            MusicValue testobj3 = new MusicValue("F",3,5);
            Music testobj4 = new Music("A",3);
            Music testobj5 = new MusicSentimentalValue();
            //print one of each construct
            Console.WriteLine(testobj);
            Console.WriteLine(testobj2);
            Console.WriteLine(testobj3);
            Console.WriteLine(testobj4);
            Console.WriteLine(testobj5);
            testobj2.Sound();
            testobj3.Sound();
            testobj5.Sound();

            Console.WriteLine("How many artits are in your catalog? ");
            //define array and size
            int musicArraySize=Convert.ToInt32(Console.ReadLine());
            Music[] musicArray = new Music[musicArraySize];            
            
            //use the load music method to fill the array with user entry
            LoadMusic(musicArray);
            
            //write out the array by looping through it and printing each object.
            Console.WriteLine("Here is your catalog and it's value: ");
                
            foreach (var music in musicArray)
            {
                Console.WriteLine(music);   
            }

        }
        /*takes user input to create an object in either the Music class or the child MusicValue based on what 
          the user says.  then we load those objects into the musicArray for use in the main program
        */
        static void LoadMusic(Music[] musicArray)
        {
            for (int i = 0; i < musicArray.Length; i++)
            {
                Console.WriteLine("Enter an artist ");
                string inpArtist = Console.ReadLine();

                Console.WriteLine("How many " + inpArtist + " records do you have?");
                int inpCatalog=Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Do you think this catalog is worth anything? ");
                string inpV = Console.ReadLine();

                if (inpV == "y" || inpV == "Y")
                {
                    Console.WriteLine("What is the value of this catalog? ");
                    int inpValue=Convert.ToInt32(Console.ReadLine());
                    musicArray[i] = new MusicValue(inpArtist, inpCatalog, inpValue);
                }
                else
                {
                    musicArray[i] = new MusicSentimentalValue(inpArtist, inpCatalog);
                }
            }
        }
    }
 }  

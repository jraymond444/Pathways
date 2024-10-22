using System;
using System.Collections.Generic;
/*
*/
namespace football
{
    class Program
    {
        static void Main(string [] args)
        {
                
                
            /*List<Players> playerList = new List<Players>();
            playerList.Add(new QB("Jimmy", "Dean", "qb",300,2));
            
            playerList.Add(new QB("Jeff", "Doilly", "qb",250,3));

            playerList.Add(new Flex("Jake","stateFarm","wr",200,1));
            
            foreach (Players p in playerList)
            {
               Console.WriteLine(p);
            } */

            List<Players> playerList = new List<Players>();
            string fileName = "playerList.txt";
            
            bool userChoice;
            string userChoiceString;

            // Repeat main loop
            do
            {

                // TODO: Get a valid input
                do
                {
                    //  Initialize variables


                    //  TODO: Provide the user a menu of options

                    Console.WriteLine("What's your pleasure? ");
                    Console.WriteLine("L: Load the data file into a list.");
                    Console.WriteLine("S: Save the array to the data file.");
                    Console.WriteLine("N: New file.");
                    Console.WriteLine("E: Delete a file.");
                    Console.WriteLine("C: Add a name to the array.");
                    Console.WriteLine("R: Read a name from the array.");
                    Console.WriteLine("U: Update a name in the array.");
                    Console.WriteLine("D: Delete a name from the array.");
                    Console.WriteLine("Q: Quit the program.");

                    //  TODO: Get a user option (valid means its on the menu)

                    userChoiceString = Console.ReadLine();

                    userChoice = (userChoiceString == "L" || userChoiceString == "l" ||
                                userChoiceString == "S" || userChoiceString == "s" ||
                                userChoiceString == "N" || userChoiceString == "n" ||
                                userChoiceString == "C" || userChoiceString == "c" ||
                                userChoiceString == "R" || userChoiceString == "r" ||
                                userChoiceString == "U" || userChoiceString == "u" ||
                                userChoiceString == "D" || userChoiceString == "d" ||
                                userChoiceString == "E" || userChoiceString == "e" ||
                                userChoiceString == "Q" || userChoiceString == "q");

                    if (!userChoice)
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }

                } while (!userChoice);

                //  TODO: If the option is L or l then load the text file (names.txt) into the list playerList

                if (userChoiceString == "L" || userChoiceString == "l")
                {
                    try
                    {
                        using (StreamReader sr = File.OpenText(fileName))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                    string[] fields = s.Split('|');
                                    {
                                        string firstName = fields[0];
                                        string lastName = fields[1];
                                        string position  = fields[2];
                                        double yards = double.Parse(fields[3]);
                                        int touchdowns = int.Parse(fields[4]);
                                        {
                                            if (position.ToLower() == "qb")
                                            {
                                                playerList.Add(new QB(firstName,lastName,position,yards,touchdowns));
                                            }
                                            else 
                                            {
                                                playerList.Add(new Flex(firstName,lastName,position,yards,touchdowns));
                                            }
                                        }
                                    }
                            }
                        }
                        Console.WriteLine(" File loaded : ");
                            
                        Console.WriteLine("");
                    }

                    catch (Exception e)
                    {

                        Console.WriteLine("error: " + e.Message);

                    }
                    finally
                    {
                        Console.WriteLine("Let's move on...");
                    }

                }

                //  TODO: Else if the option is an S or s then store the array of strings into the text file
                /*  1.  Delete the file
                    2.  Create the file
                    3.  Write out the contents of the array
                */

                else if (userChoiceString == "S" || userChoiceString == "s")
                {
                    try // Starting a try block to catch exceptions
                    {
                        // 1.  Delete the file
                        if (File.Exists(fileName)) // Checking if the file exists
                        {
                            Console.WriteLine("deleting file ");
                            File.Delete(fileName); // If the file exists, delete it
                        }
                        //2.  Create the file
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            //3.  Write out the contents of the array
                            foreach (var player in playerList)
                            {
                                    sw.WriteLine($"{player.firstName}|{player.lastName}|{player.position}|{player.yards}|{player.touchdowns}");
                            }
                            Console.WriteLine(" A file created with name " + fileName); // Displaying a message indicating successful file creation
                        }
                    }
                    catch (Exception e) // Catching any exceptions that might occur
                    {
                        Console.WriteLine(e.ToString()); // Displaying the exception details if any
                    }

                }
                /*This section will delete a file
                1. prmopt user for file name to be deleted.
                2. delete that file
                */
                else if (userChoiceString == "E" || userChoiceString == "e")
                {
                    try // Starting a try block to catch exceptions
                    {
                        // 1.  Delete the file
                        Console.WriteLine("Which file do you want to delete? ");
                        string deleteFile = Console.ReadLine();
                        if (File.Exists(deleteFile)) // Checking if the file exists
                        {
                            Console.WriteLine("Deleting file " + deleteFile);
                            File.Delete(deleteFile); // If the file exists, delete it
                        }
                    }
                    catch (Exception e) // Catching any exceptions that might occur
                    {
                        Console.WriteLine(e.ToString()); // Displaying the exception details if any
                    }

                }
                //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)

                else if (userChoiceString == "C" || userChoiceString == "c")
                {
                    Console.Write("Please enter the player's first name you'd like to add> ");
                    string newFirstName = Console.ReadLine();
                    Console.Write("Please enter the player's last name> ");
                    string newLastName = Console.ReadLine();
                    Console.Write("Please enter the player's position> ");
                    string newPosition = Console.ReadLine();
                    Console.Write("How many yards did they get? ");
                    string sYards = Console.ReadLine();
                    double.TryParse(sYards, out double newYards);
                    Console.Write("How many touchdowns did they score? ");
                    string sTouchdowns = Console.ReadLine();
                    int.TryParse(sTouchdowns, out int newTouchdowns);

                    switch (newPosition)
                    {
                        case "qb":
                        case "QB":
                            playerList.Add(new QB(newFirstName,newLastName,newPosition,newYards,newTouchdowns));
                            Console.WriteLine("The player has been added.");
                        break;
                            
                        default:
                            playerList.Add(new Flex(newFirstName,newLastName,newPosition,newYards,newTouchdowns));
                            Console.WriteLine("The player has been added.");

                        break;

                    }

                }
                
                //  TODO: Else if the option is an R or r then print the array

                else if (userChoiceString == "R" || userChoiceString == "r")
                {
                    bool notEmpty = false;
                    foreach (var player in playerList)
                        {
                            Console.WriteLine(player.ToString());
                        }
                    if (notEmpty != true)
                        {
                            Console.WriteLine("File is empty. ");
                        }
                }
                
                //GIT COMMENT
                //  TODO: Else if the option is a U or u then update a name in the array (if it's there)
                /*
                Allows the user to update an existing name.
                1. prmopt user for the name to be changed.
                2. find that name in the array.
                3. replace it.
                */
                /*
                else if (userChoiceString == "U" || userChoiceString == "u")
                {
                    Console.Write("Please enter the employee's first name you would like to update> ");
                    string updateFirstName = Console.ReadLine();
                    string updateInputRate, updateLastName, updateType;

                    int indexFound = -1;
                    for (int i = 0; i < arrayRowSize; i++)
                    {
                        if (empArray[i] !=null && empArray[i].fName == updateFirstName)
                        {
                            indexFound = i;
                        }
                    }
                    if (indexFound != -1)
                    {
                        string response;
                        do{
                        Console.WriteLine("What would you like to update? (F)irst name/(L)ast name or (q) to finish" ); ///(T)ype of employee/(R)ate 

                        response=Console.ReadLine();
                        /*if (response == "R" || response == "r" || response == "Rate" || response == "rate")
                        {
                            Console.Write("Enter the new pay rate: ");
                            updateInputRate = Console.ReadLine();
                            double updateRate;
                            double.TryParse(updateInputRate, out updateRate);
                            empArray[indexFound].rate = updateRate;
                            
                        }
                        if (response == "F" || response == "f" || response == "First" || response == "first")
                        {
                            Console.Write("And what is their first name? ");
                            updateFirstName = Console.ReadLine();
                            empArray[indexFound].fName = updateFirstName;
                        }
                        if (response == "L" || response == "l" || response == "Last" || response == "last")
                        {
                            Console.Write("And what rating do you give them? ");
                            updateLastName = Console.ReadLine();
                            empArray[indexFound].lName = updateLastName;
                        }
                        if (response == "T" || response == "t" || response == "Type" || response == "type")
                        {
                            Console.Write("And what rating do you give them? ");
                            updateType = Console.ReadLine();
                            empArray[indexFound].type = updateType;
                        }
                        }while(response != "q" && response != "Q" && response != "quit" && response != "Quit");                      
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that name is not on the file. ");
                    }
                }
                
                
                //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)
                allows user to delete a name from the array
                1. prompt the user for the name to be deleted.
                2. find name in array.
                3. replace it with space.
                
                
                else if (userChoiceString == "D" || userChoiceString == "d")
                {
                    Console.Write("Please enter the employee you'd like to fire> ");
                    string deleteFirstName = Console.ReadLine();
                    
                    int indexFound = -1;
                    for (int i = 0; i < arrayRowSize; i++)
                    {
                        if (empArray[i] !=null && empArray[i].fName == deleteFirstName)
                        {
                            indexFound = i;
                        }
                    }
                    if (indexFound != -1)
                    {
                        empArray[indexFound] = null;
                        Console.WriteLine(deleteFirstName + " has been fired!.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that name is not on the file. ");
                    }
                }
                //  TODO: Else if the option is a Q or q then quit the program
                */
                else
                {
                    Console.WriteLine("Good-bye!");
                }
            } while (!(userChoiceString == "Q") && !(userChoiceString == "q"));  
            
        }  // end main
    }  // end program
}  // end namespace

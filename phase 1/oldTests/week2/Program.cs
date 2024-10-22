using System;

namespace restaurants
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declare variables
            bool userChoice;
            string userChoiceString;
            const int arrayRowSize = 25;
            const int arrayColSize = 3;
            string[,] foodArray = new string[arrayRowSize, arrayColSize];
            string fileName = "food.txt";

            // Repeat main loop
            do
            {

                // TODO: Get a valid input
                do
                {
                    //  Initialize variables

                    userChoice = false;

                    //  TODO: Provide the user a menu of options

                    Console.WriteLine("What's your pleasure? ");
                    Console.WriteLine("L: Load the data file into an array.");
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

                //  TODO: If the option is L or l then load the text file (names.txt) into the array of strings (nameArray)

                if (userChoiceString == "L" || userChoiceString == "l")
                {
                    try
                    {
                        int rowIndex = 0;  // index for my array
                        using (StreamReader sr = File.OpenText(fileName))
                        {
                            string s = "";
                            Console.WriteLine(" Here are the contents of the file : ");
                            while ((s = sr.ReadLine()) != null && rowIndex < arrayRowSize)// && index < maxIndex)
                            {
                                //if(s != " ")
                                //{
                                    string[] fields = s.Split('|');
                                    if (fields.Length == arrayColSize)
                                    {
                                        foodArray[rowIndex, 0] = fields[0];
                                        foodArray[rowIndex, 1] = fields[1];
                                        foodArray[rowIndex, 2] = fields[2];
                                    }
                                    rowIndex++;
                                //}
                            }
                        }
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
                            for (int i = 0; i < arrayRowSize; i++)
                            {
                                if (foodArray[i,0] != null && foodArray[i,0] != " ")
                                {
                                    sw.WriteLine($"{foodArray[i,0]}|{foodArray[i,1]}|{foodArray[i,2]}");
                                }
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
                /*
                This section will allow a user to create a new file.
                1. prompt user for new file name.
                2. Create the file
                */
                else if (userChoiceString == "N" || userChoiceString == "n")
                {
                    Console.WriteLine("In the N/n area");
                    try // Starting a try block to catch exceptions
                    {
                        //1. prompt user for new file name
                        Console.WriteLine("What do you want to name the file? ");
                        string newFile = Console.ReadLine();
                        if (File.Exists(newFile)) // Checking if the file exists
                        {
                            Console.WriteLine("That file already exists. ");
                        }
                        //2.  Create the file
                        using (StreamWriter sw = File.CreateText(newFile))
                        {
                            //3.  Write out the contents of the array
                            for (int i = 0; i < arrayRowSize; i++)
                            {
                                sw.WriteLine($"{foodArray[i,0]}|{foodArray[i,1]}|{foodArray[i,2]}");
                            }
                            Console.WriteLine(" A file created with name " + newFile); // Displaying a message indicating successful file creation
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
                    Console.Write("Please enter a restaurant name you'd like to add> ");
                    string newName = Console.ReadLine();

                    int indexFound = -1;
                    for (int i = 0; i < arrayRowSize; i++)
                    {
                        Console.WriteLine(foodArray[i,0]);
                        if (foodArray[i,0] == " " || foodArray[i,0] == null)
                        {
                            indexFound = i;
                        }
                    }
                    if (indexFound != -1)
                    {
                        foodArray[indexFound,0] = newName;
                        Console.WriteLine("What type of cuisine is it? ");
                        string newCuisine = Console.ReadLine();
                        foodArray[indexFound,1] = newCuisine;
                        Console.WriteLine("What rating would you give it? ");
                        string newRating = Console.ReadLine();
                        foodArray[indexFound,2] = newRating;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, no more room. ");
                    }
                }

                //  TODO: Else if the option is an R or r then print the array

                else if (userChoiceString == "R" || userChoiceString == "r")
                {
                    bool notEmpty = false;
                    for (int row = 0; row < arrayRowSize; row++)
                    {
                        
                        if ((foodArray[row,0]) != null && foodArray[row,0] != " ")  
                        {
                            Console.WriteLine(foodArray[row,0] + " " + foodArray[row,1] + " " + foodArray[row,2]);
                            notEmpty = true;
                            Console.WriteLine("--------------");
                        }
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
                else if (userChoiceString == "U" || userChoiceString == "u")
                {
                    Console.Write("Please enter a restaurant you'd like to update> ");
                    string updateName = Console.ReadLine();

                    int indexFound = -1;
                    for (int i = 0; i < arrayRowSize; i++)
                    {
                        //Console.WriteLine(foodArray[i,0]);
                        if (foodArray[i,0] == updateName)
                        {
                            indexFound = i;
                        }
                    }
                    if (indexFound != -1)
                    {
                        string response;
                        do{
                        Console.WriteLine("Which category would you like to update? (R)estaraunt/(C)uisine/Ra(T)ing? or (q) to finish" );

                        response=Console.ReadLine();
                        if (response == "R" || response == "r" || response == "Restaurant" || response == "restaurant")
                        {
                            Console.Write("Enter the new restaurant: ");
                            string uName = Console.ReadLine();
                            foodArray[indexFound,0] = uName;
                        }
                        if (response == "C" || response == "c" || response == "Cuisine" || response == "cuisine")
                        {
                            Console.Write("And what should we update it to? ");
                            string uCuisine = Console.ReadLine();
                            foodArray[indexFound,1] = uCuisine;
                        }
                        if (response == "T" || response == "t" || response == "Rating" || response == "rating")
                        {
                            Console.Write("And what rating do you give them? ");
                            string uRating = Console.ReadLine();
                            foodArray[indexFound,2] = uRating;
                        }
                        }while(response != "q" && response != "Q" && response != "quit" && response != "Quit");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that name is not on the file. ");
                    }
                }
                

                //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)
                /*allows user to delete a name from the array
                1. prompt the user for the name to be deleted.
                2. find name in array.
                3. replace it with space.
                */
                else if (userChoiceString == "D" || userChoiceString == "d")
                {
                    Console.Write("Please enter a name you'd like to delete> ");
                    string deleteName = Console.ReadLine();
                    
                    int indexFound = -1;
                    for (int i = 0; i < arrayRowSize; i++)
                    {
                        //Console.WriteLine(foodArray[i,0]);
                        if (foodArray[i,0] == deleteName)
                        {
                            indexFound = i;
                        }
                    }
                    if (indexFound != -1)
                    {
                        foodArray[indexFound,0] = " ";
                        foodArray[indexFound,1] = " ";
                        foodArray[indexFound,2] = " ";
                        Console.WriteLine(deleteName + " has been removed from the file.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that name is not on the file. ");
                    }
                }
                //  TODO: Else if the option is a Q or q then quit the program

                else
                {
                    Console.WriteLine("Good-bye!");
                }
            } while (!(userChoiceString == "Q") && !(userChoiceString == "q"));
        }  // end main
    }  // end program
}  // end namespace
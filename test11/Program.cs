using System;

namespace bandSongs
{
  class Program
  {
    static void Main(string[] args)
    {
        
        // Declare variables
        bool userChoice;
        string userChoiceString;
        const int arraySize=12;
        string[] nameArray = new string[arraySize/2];
        string[] songArray = new string[arraySize/2];
        string fileName = "names.txt";

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

                userChoice = (userChoiceString=="L" || userChoiceString=="l" ||
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

            if (userChoiceString=="L" || userChoiceString=="l")
            { try
            {
                int index = 0;  // index for my array
                int maxIndex = arraySize / 2;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
				    Console.WriteLine(" Here is the content of the file : ");
                    while ((s = sr.ReadLine()) != null)// && index < maxIndex)
                    {
                       //Console.WriteLine(s);
                        if (index < arraySize)
                            {
                            if (index % 2 == 0)
                            {
                                nameArray[index / 2] = s;
                            }
                            else
                            {
                                songArray[index / 2] = s;
                            }
                            index++;    
                            }                   
                    }
                    foreach (string band in nameArray)
                    {
                        Console.WriteLine(band);
                    }
                    foreach (string song in songArray)
                    {
                        Console.WriteLine(song);

                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception e)
            {
                
                  Console.WriteLine("error: " + e.Message);
                               
            }
            finally
            {
                    Console.WriteLine ("Let's move on...");
            }

            }

        //  TODO: Else if the option is an S or s then store the array of strings into the text file
        /*  1.  Delete the file
            2.  Create the file
            3.  Write out the contents of the array
        */

            else if (userChoiceString=="S" || userChoiceString=="s")
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
                        for (int i= 0; i < arraySize / 2; i++)
                            {
                                sw.WriteLine(nameArray[i]);
                                sw.WriteLine(songArray[i]);
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
            else if (userChoiceString=="E" || userChoiceString=="e")
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
            else if (userChoiceString=="N" || userChoiceString=="n")
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
                        for (int i= 0; i < arraySize/2; i++)
                            {
                                sw.WriteLine(nameArray[i]);
                                sw.WriteLine(songArray[i]);
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

            else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.Write("Please enter a band name you'd like to add> ");
                string newName=Console.ReadLine();

                int indexFound = -1;
                for (int i = 0; i < nameArray.GetLength(0); i++)
                {
                    Console.WriteLine(nameArray[i]);
                    if (nameArray[i] == " ")
                    {
                        indexFound = i;
                    }
                }
                if (indexFound != -1)
                {
                    nameArray[indexFound] = newName;
                    Console.WriteLine("What song do they sing? ");
                    string newSong=Console.ReadLine();
                    songArray[indexFound] = newSong;
                }
                else
                {
                    Console.WriteLine("Sorry, no more room for names. ");
                }
            }

        //  TODO: Else if the option is an R or r then print the array

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                for (int index = 0; index < arraySize / 2; index++)
                {
                    if ((nameArray[index])!=" ")
                        Console.WriteLine(nameArray[index]);
                    else
                        Console.WriteLine("Index " + index + " is available.");
                    if ((songArray[index])!=" ")
                        Console.WriteLine(songArray[index]);
                    else 
                        Console.WriteLine("Index " + index + " is available.");
                    Console.WriteLine("--------------");
                }
            }
        //  TODO: Else if the option is a U or u then update a name in the array (if it's there)
            /*
            Allows the user to update an existing name.
            1. prmopt user for the name to be changed.
            2. find that name in the array.
            3. replace it.
            */
            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.Write("Please enter a name you'd like to update> ");
                string updateName=Console.ReadLine();

                int indexFound = -1;
                for (int i = 0; i < nameArray.GetLength(0); i++)
                {
                    Console.WriteLine(nameArray[i]);
                    if (nameArray[i] == updateName)
                    {
                        indexFound = i;
                    }
                }
                if (indexFound != -1)
                {
                    Console.Write("Enter the new name: ");
                    string uName=Console.ReadLine();
                    nameArray[indexFound] = uName;
                    Console.Write("And what song do they sing? ");
                    string uSong=Console.ReadLine();
                    songArray[indexFound] = uSong;
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
            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.Write("Please enter a name you'd like to delete> ");
                string deleteName=Console.ReadLine();

                int indexFound = -1;
                for (int i = 0; i < nameArray.GetLength(0); i++)
                {
                    Console.WriteLine(nameArray[i]);
                    if (nameArray[i] == deleteName)
                    {
                        indexFound = i;
                    }
                }
                if (indexFound != -1)
                {
                    Console.WriteLine(deleteName + " has been removed from the file.");
                    nameArray[indexFound] = " ";
                    Console.WriteLine("Their song " + songArray[indexFound] + " has also been removed from the file.");
                    songArray[indexFound] = " ";
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
        } while (!(userChoiceString=="Q") && !(userChoiceString=="q"));
    }  // end main
  }  // end program
}  // end namespace
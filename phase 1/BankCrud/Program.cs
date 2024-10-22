using System;
using System.Collections.Generic;
/*
*/
namespace bank
{
    class Program
    {
        static void Main(string [] args)
        {
            
            List<Account> accountList = new List<Account>();
            bool userChoice, userType, employeeChoice;
            string userChoiceString, userTypeChoiceString, employeeChoiceString;
            string fileName = "accountList.txt";
            
            try
                    {
                        using (StreamReader sr = File.OpenText(fileName))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                    string[] fields = s.Split('|');
                                    {
                                        string accountID = fields[0];
                                        string accountType = fields[1];
                                        double balance = double.Parse(fields[2]);

                                        switch (accountType.ToUpper())
                                        {
                                            case "CHECKING":
                                                accountList.Add(new Checking(accountID,accountType,balance));
                                                break;
                                            case "SAVINGS":
                                                accountList.Add(new Savings(accountID,accountType,balance));
                                                break;
                                            case "CD":
                                                accountList.Add(new CD(accountID,accountType,balance));
                                                break;
                                            default:
                                                Console.WriteLine("Invalid record");
                                                break;
                                        }
                                    }
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
                        Console.WriteLine(" File loaded : ");
                    }
            
            do
            { 
                Console.WriteLine("Welcome to the bank menu, are you an account holder or a bank employee? ");
                Console.WriteLine("A: Account holder");
                Console.WriteLine("E: Employee");
                Console.WriteLine("Q: Quit.");

                //  TODO: Get a user option (valid means its on the menu)

                userTypeChoiceString = Console.ReadLine();
                userType = (userTypeChoiceString == "E" || userTypeChoiceString == "e" ||
                            userTypeChoiceString == "A" || userTypeChoiceString == "a" ||
                            userTypeChoiceString == "Q" || userTypeChoiceString == "q");

                if (!userType)
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            
                if (userTypeChoiceString == "A" || userTypeChoiceString == "a")
                {
                    // TODO: Get a valid input
                    do
                    {
                        //  TODO: Provide the user a menu of options

                        Console.WriteLine("Welcome to the bank menu, what would you like to do? ");
                        Console.WriteLine("L: List all available accounts and their contents.");
                        Console.WriteLine("D: Deposit.");
                        Console.WriteLine("W: Withdrawal.");
                        Console.WriteLine("Q: Quit to main menu.");

                        //  TODO: Get a user option (valid means its on the menu)

                        userChoiceString = Console.ReadLine();

                        userChoice = (userChoiceString == "L" || userChoiceString == "l" ||
                                    userChoiceString == "D" || userChoiceString == "d" ||
                                    userChoiceString == "W" || userChoiceString == "w" ||
                                    userChoiceString == "Q" || userChoiceString == "q");

                        if (!userChoice)
                        {
                            Console.WriteLine("Please enter a valid option.");
                        }

                    } while (!userChoice);//end of user input prompt
                    
                    //List all accounts
                    if (userChoiceString == "L" || userChoiceString == "l")
                    {
                        Console.WriteLine("Enter your account number: ");
                        string userAccountID = Console.ReadLine();
                        bool notEmpty = false;
                        bool found = false;
                        foreach (var acct in accountList)
                            {
                                if (acct.accountID == userAccountID)
                                {
                                    Console.WriteLine(acct);
                                    found = true;
                                }
                                else
                                {
                                    found = false;
                                }
                            }
                        //if (notEmpty != true)
                          //  {
                           //     Console.WriteLine("File is empty. ");
                            //}
                    }

                    //Deposit
                    else if (userChoiceString == "D" || userChoiceString == "d")
                    {
                        Console.Write("Please enter an account ID you'd like to make the deposit under: ");
                        string findAccountID = Console.ReadLine();
                        bool found = false;
                        foreach (Account acct in accountList)
                            {
                                if (acct.accountID == findAccountID)
                                {
                                    found = true;
                                    Console.WriteLine("Please enter the deposit amount for " + acct.accountID);
                                    string inputd = Console.ReadLine();
                                    double depositAmount;
                                    double.TryParse(inputd, out depositAmount);
                                    if (depositAmount > 0)
                                    {
                                        acct.Deposit(depositAmount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid deposit amount.");
                                    }
                                }           
                            }  // end foreach  
                        if (!(found))
                            Console.WriteLine("Account was not found.");
                    }
                    else if (userChoiceString == "W" || userChoiceString == "w")
                    {
                        Console.Write("Please enter an account ID you'd like to make the withdrawal from: ");
                        string findAccountID = Console.ReadLine();
                        bool found = false;
                        foreach (Account acct in accountList)
                            {
                                if (acct.accountID == findAccountID)
                                {
                                    found = true;
                                    Console.WriteLine("Please enter the withdrawal amount for " + acct.accountID);
                                    string inputw = Console.ReadLine();
                                    double withdrawalAmount;
                                    double.TryParse(inputw, out withdrawalAmount);
                                    if (withdrawalAmount > 0)
                                    {
                                        acct.Withdrawal(withdrawalAmount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid withdrawal amount.");
                                    }
                                }           
                            }  // end foreach  
                        if (!(found))
                            Console.WriteLine("Account was not found.");
                    }
                    else 
                    {
                        Console.WriteLine("Thank you.");
                    }
                    
                }
                else if (userTypeChoiceString == "E" || userTypeChoiceString == "e")
                {
                    do
                    {
                        //  TODO: Provide the user a menu of options

                        Console.WriteLine("Welcome to the employee menu, what would you like to do? ");
                        Console.WriteLine("C: Create a new account.");
                        Console.WriteLine("D: Delete an account.");
                        Console.WriteLine("U: Update an existing account.");
                        Console.WriteLine("L: List all accounts on file.");
                        Console.WriteLine("Q: Quit to main menu.");

                        //  TODO: Get a user option (valid means its on the menu)

                        employeeChoiceString = Console.ReadLine();

                        employeeChoice = (employeeChoiceString == "C" || employeeChoiceString == "C" ||
                                    employeeChoiceString == "D" || employeeChoiceString == "d" ||
                                    employeeChoiceString == "U" || employeeChoiceString == "u" ||
                                    employeeChoiceString == "L" || employeeChoiceString == "l" ||
                                    employeeChoiceString == "Q" || employeeChoiceString == "q");

                        if (!employeeChoice)
                        {
                            Console.WriteLine("Please enter a valid option.");
                        }

                    } while (!employeeChoice);//end of user input prompt
                    //List all accounts
                    if (employeeChoiceString == "L" || employeeChoiceString == "l")
                    {
                        bool notEmpty = false;
                        foreach (var acct in accountList)
                            {
                                Console.WriteLine(acct.ToString());
                            }
                        if (notEmpty != true)
                            {
                                Console.WriteLine("File is empty. ");
                            }
                    }
                    else if (employeeChoiceString == "C" || employeeChoiceString == "c")
                    {
                        Console.Write("Please enter the new account number> ");
                        string newAccountID = Console.ReadLine();
                        Console.Write("What is the account type? Enter: Checking, savings, or CD. ");
                        string newAccountType = Console.ReadLine();
                        Console.WriteLine("Enter the balance: ");
                        string sNewBalance = Console.ReadLine();
                        double.TryParse(sNewBalance, out double newBalance);

                        switch (newAccountType.ToUpper())
                        {
                            case "CHECKING":
                                accountList.Add(new Checking(newAccountID,newAccountType,newBalance));
                                break;
                            case "SAVINGS":
                                accountList.Add(new Savings(newAccountID,newAccountType,newBalance));
                                break;
                            case "CD":
                                accountList.Add(new CD(newAccountID,newAccountType,newBalance));
                                break;
                            default:
                                Console.WriteLine("Invalid account");
                                break;
                        }
                    }
                    else if (employeeChoiceString == "D" || employeeChoiceString == "d")
                    {
                        Console.Write("Please enter the new account you would like deleted> ");
                        string deleteAccountId = Console.ReadLine();
                        
                        bool found = false;
                        for (int acct = 0; acct < accountList.Count; acct++)
                        {
                            if (accountList[acct].accountID == deleteAccountId)
                            {
                                accountList.RemoveAt(acct);
                                found = true;
                            }
                        }  // end foreach  
                        if (found)
                            Console.WriteLine("Account " + deleteAccountId + " was deleted.");
                        else
                            Console.WriteLine("Account not on file.");
                    }
                    else if (employeeChoiceString == "U" || employeeChoiceString == "u")
                    {
                        Console.WriteLine("Please enter the new account you would like to update> ");
                        string updateAccountId = Console.ReadLine();
                        
                        Console.WriteLine("Would you like to update the account type or the balance?  Enter: (T)ype or (B)alance.");
                        string updateField = Console.ReadLine();
                        bool found = false;

                        for (int acct = 0; acct < accountList.Count; acct++)
                        {
                            if (accountList[acct].accountID == updateAccountId)
                            {
                                found = true;
                                if (updateField == "T" || updateField == "Type" || updateField == "type" || updateField == "t")
                                {
                                    Console.WriteLine("Enter the new account type: Checking/savings/CD");
                                    string updateAccountType = Console.ReadLine();
                                    accountList[acct].accountType = updateAccountType;
                                }
                                else if (updateField == "B" || updateField == "Balance" || updateField == "balance" || updateField == "b")
                                {
                                    Console.WriteLine("Enter the new balance: ");
                                    string sUpdateBalance = Console.ReadLine();
                                    double.TryParse(sUpdateBalance, out double updateBalance);
                                    accountList[acct].balance = updateBalance;
                                }
                            }
                        }  // end foreach  
                        if (found)
                            Console.WriteLine("Account " + updateAccountId + " has been updated.");
                        else
                            Console.WriteLine("Account not on file.");
                    }
                    else
                    {
                        Console.WriteLine("Logging off. ");
                    }
                    
                }
                
                try // Starting a try block to catch exceptions
                        {
                            // 1.  Delete the file
                            if (File.Exists(fileName)) // Checking if the file exists
                            {
                                File.Delete(fileName); // If the file exists, delete it
                            }
                            //2.  Create the file
                            using (StreamWriter sw = File.CreateText(fileName))
                            {
                                //3.  Write out the contents of the array
                                foreach (var acct in accountList)
                                {
                                        sw.WriteLine($"{acct.accountID}|{acct.accountType}|{acct.balance}");
                                }
                                Console.WriteLine("Updates have been made "); // Displaying a message indicating successful file creation
                            }
                        }
                        catch (Exception e) // Catching any exceptions that might occur
                        {
                            Console.WriteLine(e.ToString()); // Displaying the exception details if any
                        }
            }while ((userTypeChoiceString != "Q") && (userTypeChoiceString != "q")); // main menu do while
        }  // end main
    }  // end program
}  // end namespace

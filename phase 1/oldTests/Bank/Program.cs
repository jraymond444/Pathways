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
            bool userChoice;
            string userChoiceString;

            accountList.Add(new Checking ("8889", "Checking", 0));
            accountList.Add(new Savings("7778","Savings", 1500.00));
            accountList.Add(new CD("6667","CD", 50000));
            
            
        
            do
            {
                // TODO: Get a valid input
                do
                {
                    //  TODO: Provide the user a menu of options

                    Console.WriteLine("Welcome to the bank menu, what would you like to do? ");
                    Console.WriteLine("L: List all available accounts and their contents.");
                    Console.WriteLine("D: Deposit.");
                    Console.WriteLine("W: Withdrawal.");
                    Console.WriteLine("Q: Quit the program.");

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
            }while (!(userChoiceString == "Q") && !(userChoiceString == "q"));  
            
            
        }  // end main
    }  // end program
}  // end namespace

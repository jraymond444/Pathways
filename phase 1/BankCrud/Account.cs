using System;
/*  
This is the account class.  It will contain the properties for account id, account type, and balance.  
*/
namespace bank
{
    public abstract class Account
    {
        public string accountID  // property
            { get; set; }

        public string accountType  // property
            { get; set; }

        public double balance // property
            {get; set; }

        //default construct 
        public Account() 
        {
            accountID = "9999";
            accountType = "Checking";
            balance = 100.00;
        }
  
        //input construct 
        public Account(string inAccountID, string inAccountType, double inBalance)
        {
            accountID = inAccountID;
            accountType = inAccountType;
            balance = inBalance;
        }
       
        //display player info and points 
        public override string ToString()
        {
            return ("The balance for the " + this.accountType + "  under " + this.accountID + " is " + this.balance.ToString("C2") + ".");
        }

        public abstract void Withdrawal(double amount); //abstract method for withdrawal amount

        //deposit method
        public double Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine(amount.ToString("C2") + " has been deposited.  New balance is " + this.balance.ToString("C2") + ".");
            return balance;
        }
        
    }
 } 

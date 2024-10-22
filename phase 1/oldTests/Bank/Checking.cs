using System;
/*  
This is the checking account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace bank
{
    class Checking : Account
    {
        //default construct using values from base()
        public Checking() : base()
        {}
  
        //input contruct using values from the from both base()
        public Checking(string accountID, string accountType, double balance):base(accountID, accountType, balance)
        {}
       
        //display the checking account information including the annual fee. 
        public override string ToString()
        {
            return ("For account ID " + this.accountID + " the checking balance is " + this.balance.ToString("C2") + "." + " The annual fee is 1% of the balance: " + AnnualFee(this.balance).ToString("C2") + ".");
        }
        //handle the withdrawal
        
        public override void Withdrawal(double amount)
        {
            if (amount <= balance/2)
            {
                balance -= amount;
                Console.WriteLine("New balance is: " + balance.ToString("C2") + ".");
            }
            else
            {
                Console.WriteLine("Sorry, not enough funds to perform that withdrawal.");
            }
        }
        public double AnnualFee(double balance)
        {
            double annualFee = balance * .01;
            return annualFee;
        } 
    }
 } 

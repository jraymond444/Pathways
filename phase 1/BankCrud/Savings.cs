using System;
/*  
This is the Savings account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace bank
{
    class Savings : Account, ICalculateInterest
    {
        //default construct using values from base()
        public Savings() : base()
        {}
  
        //input contruct using values from the from both base()
        public Savings(string accountID, string accountType, double balance):base(accountID, accountType, balance)
        {}
       
        //display the Savings account information including the annual fee. 
        public override string ToString()
        {
            return ("For account ID " + this.accountID + " the Savings balance is " + this.balance.ToString("C2") + "." + " The annual interest is: " + CalcInterest(this.balance).ToString("C2") + ".");
        }
        //handle the withdrawal
        
        public override void Withdrawal(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("New balance is: " + balance.ToString("C2") + ".");
            }
            else
            {
                Console.WriteLine("Sorry, not enough funds to perform that withdrawal.");
            }
        }
        public double CalcInterest(double balance)
        {
            double annualRate = balance * .05;
            return annualRate;
        } 
    }
 } 

using System;
/*  
This is the CD account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace bank
{
    class CD : Account, ICalculateInterest
    {
        //default construct using values from base()
        public CD() : base()
        {}
  
        //input contruct using values from the from both base()
        public CD(string accountID, string accountType, double balance):base(accountID, accountType, balance)
        {}
       
        //display the CD account information including the annual fee. 
        public override string ToString()
        {
            return ("For account ID " + this.accountID + " the CD balance is " + this.balance.ToString("C2") + "." + " The annual interest is: " + CalcInterest(this.balance).ToString("C2") + ".");
        }
        //handle the withdrawal
        
        public override void Withdrawal(double amount)
        {
            Console.WriteLine("The early withdrawal penalty is 20%.");
            if (amount <= (balance/2)+(amount*.2))
            {
                balance -= amount+(amount*.2);
                Console.WriteLine("Balance after the withdrawal and penalty is: " + balance.ToString("C2"));
            }
            else
            {
                Console.WriteLine("Sorry, not enough funds to perform that withdrawal.");
            }
        }
        public double CalcInterest(double balance)
        {
            double annualRate = balance * .15;
            return annualRate;
        } 
    }
 } 

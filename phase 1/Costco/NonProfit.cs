using System;
/*  
This is the checking account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace costco;

class NonProfit : Members
{
    public string nonProfitType  // property
    {get; set;}
    //default construct using values from base()
    public NonProfit() : base()
    {
        nonProfitType = "T";
    }

    //input contruct using values from the from both base()
    public NonProfit(string membershipID, string email, string membershipType, double annualCost, double monthlyTranAmount, string inNonProfitType):base(membershipID, email, membershipType, annualCost, monthlyTranAmount)
    {
        nonProfitType = inNonProfitType;
    }
    
    //display the NonProfit memebership information 
    public override string ToString()
    {
        return ("NonProfit account: " + this.membershipID + "  email " + this.email + " has an annual fee of " + this.annualCost.ToString("C2") + ".  The current transaction total this month is " + this.monthlyTranAmount.ToString("C2") + ".");
    }
    //handle the withdrawal
    
    public override string CashBack(double monthlyTranAmount)
    {
        if (nonProfitType == "T" || nonProfitType == "M")// || nonProfitType = "t" || nonProfitType = "m"
        {
            double cashBackReward = monthlyTranAmount * .06;
            return (" your reward amount is doubled thanks to your teacher/military reward: " + cashBackReward.ToString("C2") + ".");
        }
        else
        {
            double cashBackReward = monthlyTranAmount * .03;
            return (" cash back reward amount is " + cashBackReward.ToString("C2") + ".");
        }
        
    }
} 

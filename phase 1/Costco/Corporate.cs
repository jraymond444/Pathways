using System;
/*  
This is the checking account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace costco;

class Corporate : Members
{
    //default construct using values from base()
    public Corporate() : base()
    {}

    //input contruct using values from the from both base()
    public Corporate(string membershipID, string email, string membershipType, double annualCost, double monthlyTranAmount):base(membershipID, email, membershipType, annualCost, monthlyTranAmount)
    {}
    
    //display the Corporate memebership information 
    public override string ToString()
    {
        return ("Corporate account: " + this.membershipID + " email " + this.email + " has an annual fee of " + this.annualCost.ToString("C2") + ".  The current transaction total this month is " + this.monthlyTranAmount.ToString("C2") + ".");
    }
    //handle the withdrawal
    
    public override string CashBack(double monthlyTranAmount)
    {
        double cashBackReward = monthlyTranAmount * .04;
        return ("Cash back reward amount is " + cashBackReward.ToString("C2") + ".");
    }
} 

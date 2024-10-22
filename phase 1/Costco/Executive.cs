using System;
/*  
This is the checking account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace costco;
class Executive : Members, ISpecialOffers
{
    //default construct using values from base()
    public Executive() : base()
    {}

    //input contruct using values from the from both base()
    public Executive(string membershipID, string email, string membershipType, double annualCost, double monthlyTranAmount):base(membershipID, email, membershipType, annualCost, monthlyTranAmount)
    {}
    
    //display the Executive memebership information 
    public override string ToString()
    {
        return ("Executive account: " + this.membershipID + " email " + this.email +  " has an annual fee of  " + this.annualCost.ToString("C2") + ". But with the special discount price it is just " + SpecialOffers(annualCost).ToString("C2") + ". The current transaction total this month is " + this.monthlyTranAmount.ToString("C2") + ".");
    }
    //handle the withdrawal
    
    public override string CashBack(double monthlyTranAmount)
    {
        
        if (monthlyTranAmount >= 1000)
        {
            double cashBackReward = monthlyTranAmount * .10;
            return ("Cash back reward amount is doubled thanks to monthly transactions exceeding $1,000:  " + cashBackReward.ToString("C2") + ".");
        }
        else
        {    
            double cashBackReward = monthlyTranAmount * .05;
            return ("Cash back reward amount is " + cashBackReward.ToString("C2") + ".");
        }
        
    }

    public double SpecialOffers(double annualCost)
    {
        double discountedCost = annualCost * .5;
        return discountedCost;
    } 
}
 

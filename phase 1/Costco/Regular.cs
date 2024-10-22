using System;
/*  
This is the checking account class.  It will use depsoit and withdrawal methods and display the annual fee.  
*/
namespace costco;
class Regular : Members, ISpecialOffers
{
    //default construct using values from base()
    public Regular() : base()
    {}

    //input contruct using values from the from both base()
    public Regular(string membershipID, string email, string membershipType, double annualCost, double monthlyTranAmount):base(membershipID, email, membershipType, annualCost, monthlyTranAmount)
    {}
    
    //display the regular memebership information 
    public override string ToString()
    {
        return ("Regular account: " + this.membershipID + " email " + this.email +  " has an annual fee of " + this.annualCost.ToString("C2") + ". But with the special discount price it is just " + SpecialOffers(annualCost).ToString("C2") + ". The current transaction total this month is " + this.monthlyTranAmount.ToString("C2") + ".");
    }
    //handle the withdrawal
    
    public override string CashBack(double monthlyTranAmount)
    {
        double cashBackReward = monthlyTranAmount * .03;
        return ("Cash back reward amount is " + cashBackReward.ToString("C2") + ".");
    }

    public double SpecialOffers(double annualCost)
    {
        double discountedCost = annualCost * .75;
        return discountedCost;
    } 
}
 

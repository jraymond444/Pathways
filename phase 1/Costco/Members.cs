using System;
/*  
This is the membership class.  It will contain the properties for membership id, email, membership type, annual cost and monthly tran amount.  
*/
namespace costco;
public abstract class Members
{
    public string membershipID  // property
        {get; set;}
    public string email
        {get; set;}
    public string membershipType  // property
        {get; set;}
    public double annualCost // property
        {get; set;}
    public double monthlyTranAmount // property
        {get; set;}

    //default construct 
    public Members() 
    {
        membershipID = "9999";
        email  = "member1@costco.com";
        membershipType = "regular";
        annualCost = 100.00;
        monthlyTranAmount = 200.00;
    }

    //input construct 
    public Members(string inMembershipID, string inEmail, string inMembershipType, double inAnnualCost, double inMonthlyTranAmount)
    {
        membershipID = inMembershipID;
        email = inEmail;
        membershipType = inMembershipType;
        annualCost = inAnnualCost;
        monthlyTranAmount = inMonthlyTranAmount;
    }
    
    //display member information
    public override string ToString()
    {
        return ("Membership ID: " + this.membershipID + "  email: " + this.email + " account type: " + this.membershipType + " annual cost: " + this.annualCost + " monlyth tran amount: " + this.monthlyTranAmount.ToString("C2") + ".");
    }

    public abstract string CashBack(double rewardAmount); //abstract method for withdrawal amount

    //deposit method
    public double Purchase(double amount)
    {
        monthlyTranAmount += amount;
        Console.WriteLine(amount.ToString("C2") + " has been added to the monthly tran amount.  Total spent this month is " + this.monthlyTranAmount.ToString("C2") + ".");
        return monthlyTranAmount;
    }

    public double Return(double amount)
    {
        monthlyTranAmount -= amount;
        Console.WriteLine(amount.ToString("C2") + " has been deducted from the monthly tran amount.  Your new balance is " + this.monthlyTranAmount.ToString("C2") + ".");
        return monthlyTranAmount;
    }
    
}


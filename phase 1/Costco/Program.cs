using System;
using System.Collections.Generic;
/*
*/
namespace costco;
class Program
{
    private static List<Members> memberList = new List<Members>();
    static void Main(string [] args)
    {
        
        
        //bool userChoice, userType, employeeChoice;
        //string userChoiceString, userTypeChoiceString, employeeChoiceString;
        string fileName = "memberList.txt";
        
        try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] fields = s.Split('|');
                        {
                            string membershipID = fields[0];
                            string email = fields[1];
                            string membershipType = fields[2];
                            double annualCost = double.Parse(fields[3]);
                            double monthlyTranAmount = double.Parse(fields[4]);
                            string nonProfitType = fields[5];

                            switch (membershipType.ToUpper())
                            {
                                case "REGULAR":
                                    memberList.Add(new Regular(membershipID,email,membershipType,annualCost,monthlyTranAmount));
                                    break;
                                case "EXECUTIVE":
                                    memberList.Add(new Executive(membershipID,email,membershipType,annualCost,monthlyTranAmount));
                                    break;
                                case "NONPROFIT":
                                    memberList.Add(new NonProfit(membershipID,email,membershipType,annualCost,monthlyTranAmount,nonProfitType));
                                    break;
                                case "CORPORATE":
                                    memberList.Add(new Corporate(membershipID,email,membershipType,annualCost,monthlyTranAmount));
                                    break;
                                default:
                                    Console.WriteLine("Invalid member");
                                    break;
                            }
                        }
                    }
                }
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }
            finally
            {
                Console.WriteLine(" File loaded : ");
            }
        
                        //List all accounts
        
            

        //This is the main menu loop method.  Everything in the loops will be contained in methods.
        
        MainMenu();
        /*
        //This writes to the file of record
        Console.WriteLine("Would you like to (s)ave your updates?");
        string save = Console.ReadLine();
        if (save == "S" || save == "s" || save == "save")
        {
            try // Starting a try block to catch exceptions
            {
                // 1.  Delete the file
                if (File.Exists(fileName)) // Checking if the file exists
                {
                    File.Delete(fileName); // If the file exists, delete it
                }
                //2.  Create the file
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    //3.  Write out the contents of the array
                    foreach (var member in memberList)
                    {
                            sw.WriteLine($"{member.membershipID}|{member.email}|{member.membershipType}|{member.annualCost}|{member.monthlyTranAmount}");
                    }
                    Console.WriteLine("Updates have been recorded "); // Displaying a message indicating successful file creation
                }
            }
            catch (Exception e) // Catching any exceptions that might occur
            {
                Console.WriteLine(e.ToString()); // Displaying the exception details if any
            }
        }
        else
        {
            Console.WriteLine("Updates disregarded. ");
        }*/
        
    }  // end main
    static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("(A)dmin | (U)ser | (Q)uit ");
            string userMainMenuSelection;
            do
            {
                Console.WriteLine("Please make a selection: ");
                userMainMenuSelection = Console.ReadLine();
            }while (userMainMenuSelection != "A" && userMainMenuSelection != "a" && userMainMenuSelection != "U" && userMainMenuSelection != "u" && userMainMenuSelection != "q" && userMainMenuSelection != "Q");

            switch(userMainMenuSelection)
            {
                case "A":
                case "a":
                    AdminMenu();
                    break;
                case "U":
                case "u":
                    UserMenu();
                    break;
                case "q":
                case "Q":
                    Console.WriteLine("Exiting program, thank you. ");
                    return;
            }//end switch
        }//end do
    } //end mainmenu
    static void AdminMenu()
    {
        while(true)
        {
            Console.WriteLine("ADMIN MENU");
            Console.WriteLine("(C)reate|(R)ead|(U)pdate|(D)elete|(Q)uit");
            string adminMenuChoice;
            do
            {
                Console.WriteLine("Please select a choice from the menu");
                adminMenuChoice = Console.ReadLine();
            }while (adminMenuChoice != "C" &&adminMenuChoice != "c" &&adminMenuChoice != "R" &&adminMenuChoice != "r" &&adminMenuChoice != "D" &&adminMenuChoice != "d" &&adminMenuChoice != "U" &&adminMenuChoice != "u" && adminMenuChoice != "Q" && adminMenuChoice != "q");
            //each method will be responsible for a CRUD function
            switch (adminMenuChoice)
            {
            case "C":
            case "c":
                //create new members
                CreateMembers(memberList);
                break;
            case "R":
            case "r":
                //lists all members ToStrings
                ListMembers(memberList);
                break;
            case "U":
            case "u":
                UpdateMembers(memberList);
                break;
            case "D":
            case "d":
                DeleteMembers(memberList);
                break;
            case "Q":
            case "q":
                Console.WriteLine("Exiting to main menu");
                return;
            }
        }
    }
    static void UserMenu()
    {
        while(true)
        {
            Console.WriteLine("USER MENU");
            Console.WriteLine("(L)ist all memberships|(P)urchase|Re(t)urn|(A)pply cash back rewards|(Q)uit");
            string userMenuChoice;
            do
            {
                Console.WriteLine("Please select a choice from the menu");
                userMenuChoice = Console.ReadLine();
            }while (userMenuChoice != "L" &&userMenuChoice != "l" &&userMenuChoice != "P" &&userMenuChoice != "p" &&userMenuChoice != "T" &&userMenuChoice != "t" &&userMenuChoice != "A" &&userMenuChoice != "a" && userMenuChoice != "Q" && userMenuChoice != "q");
            
            switch (userMenuChoice)
            {
            case "L":
            case "l":
                //calls ListMembers method to print out the members on file.
                ListMembers(memberList);
                break;
            case "P":
            case "p":
                MemberPurchase(memberList);
                break;
            case "T":
            case "t":
                MemberReturn(memberList);
                break;
            case "A":
            case "a":
                MemberApplyCashBack(memberList);
                break;
            case "Q":
            case "q":
                Console.WriteLine("Exiting to main menu");
                return;
            }
        }
    }
    static void ListMembers(List<Members> memberList)
    {
        Console.WriteLine("Member list: ");
        foreach (var member in memberList)
            {
                    Console.WriteLine(member);
            }
    }

    static void CreateMembers(List<Members> memberList)
    {
        Console.Write("Please enter the new membership ID> ");
        string newMembershipID = Console.ReadLine();
        newMembershipID = newMembershipID.Trim();
        bool memberFound = false;
        foreach (var oldMember in memberList)
        {
            if (oldMember.membershipID == newMembershipID)
            {
                memberFound = true;
            }
        }
        switch (memberFound)
        {
            case false:
                Console.Write("What type of membership is it? Enter: Regular, Executive, NonProfit, or Corporate. ");
                string newMembershipType = Console.ReadLine();
                Console.WriteLine("Enter their email: ");
                string newEmail = Console.ReadLine();
                Console.WriteLine("How much have they spent this month? ");
                string sNewMonthlyTranAmount = Console.ReadLine();
                double.TryParse(sNewMonthlyTranAmount, out double newMonthlyTranAmount);
                double newAnnualCost;
                switch (newMembershipType.ToUpper())
                {
                    case "REGULAR":
                        Console.WriteLine("Annual cost for a regular membership is $100.00");
                        newAnnualCost = 100.00;
                        memberList.Add(new Regular(newMembershipID,newEmail,newMembershipType,newAnnualCost,newMonthlyTranAmount));
                        break;
                    case "EXECUTIVE":
                        Console.WriteLine("Annual cost for an executive membership is $200.00");
                        newAnnualCost = 200.00;
                        memberList.Add(new Executive(newMembershipID,newEmail,newMembershipType,newAnnualCost,newMonthlyTranAmount));
                        break;
                    case "NONPROFIT":
                        Console.WriteLine("Annual cost for a non profit membership is $20.00");
                        newAnnualCost = 20.00;
                        Console.WriteLine("Enter T or M for the teacher/military rewards, otherwise enter n if they do not qualify");
                        string newNonProfitType = Console.ReadLine();
                        memberList.Add(new NonProfit(newMembershipID,newEmail,newMembershipType,newAnnualCost,newMonthlyTranAmount,newNonProfitType));
                        break;
                    case "CORPORATE":
                        Console.WriteLine("Annual cost for a corporate membership is $750.00");
                        newAnnualCost = 750.00;
                        memberList.Add(new Corporate(newMembershipID,newEmail,newMembershipType,newAnnualCost,newMonthlyTranAmount));
                        break;
                    default:
                        Console.WriteLine("Invalid account");
                        break;
                }
                break;
            case true:
                Console.WriteLine("Entry not accepted, duplicate account.");
                break;
        }

    }
    static void UpdateMembers(List<Members> memberList)
    {
        Console.WriteLine("Please enter the membership ID for the member you would like to update> ");
        string updateMemberID = Console.ReadLine();
        
        Console.WriteLine("Would you like to update?");
        Console.WriteLine("Enter: (E)mail|(T)ype|(A)nnual Fee|(S)pend this month");
        string updateField = Console.ReadLine();
        bool found = false;

        for (int updateMember = 0; updateMember < memberList.Count; updateMember++)
        {
            if (memberList[updateMember].membershipID == updateMemberID)
            {
                found = true;
                switch (updateField)
                {
                    case "E":
                    case "e":
                        Console.WriteLine("Please enter the new email address: ");
                        string updateEmail = Console.ReadLine();
                        memberList[updateMember].email = updateEmail;
                        Console.WriteLine("New email is " + memberList[updateMember].email);
                        break;
                    case "T":
                    case "t":
                        Console.WriteLine("Please enter the new membership type: ");
                        string updateMembershipType = Console.ReadLine();
                        string bigUpdateType = updateMembershipType.ToUpper();
                        memberList[updateMember].membershipType = updateMembershipType;
                        Console.WriteLine("New membership type is " + memberList[updateMember].membershipType);
                        /*if (bigUpdateType == "NONPROFIT")
                        {
                            if (bigUpdateType is NonProfit nonProfitMember)
                            {
                                Console.WriteLine("Enter T or M for teacher/military rewards tier, otherwise enter N: ");
                                string updateNonProfitType = Console.ReadLine();
                                memberList[updateMember].nonProfitMember.nonProfitType = updateNonProfitType;
                            }
                        }*/
                        break;
                    case "A":
                    case "a":
                        Console.WriteLine("Please enter the new membership annual fee: ");
                        string supdateAnnualCost = Console.ReadLine();
                        double.TryParse(supdateAnnualCost, out double updateAnnualCost); 
                        memberList[updateMember].annualCost = updateAnnualCost;
                        Console.WriteLine("New annual fee is " + memberList[updateMember].annualCost);
                        break;
                    case "S":
                    case "s":
                        Console.WriteLine("Please enter the updated amount for the monthly spend: ");
                        string supdateMonthlyTranAmount = Console.ReadLine();
                        double.TryParse(supdateMonthlyTranAmount, out double updateMonthlyTranAmount); 
                        memberList[updateMember].monthlyTranAmount = updateMonthlyTranAmount;
                        Console.WriteLine("Updated monthly spend is " + memberList[updateMember].monthlyTranAmount);
                        break;
                    default:
                        Console.WriteLine("Invalid entry. ");
                        break;
                }
            }
        }  // end foreach  
        if (found)
            Console.WriteLine("Member " + updateMemberID + " has been updated.");
        else
            Console.WriteLine("Member not on file.");
    }
    static void DeleteMembers(List<Members> memberList)
    {
        Console.Write("Please enter the ID for the membership you would like deleted> ");
        string deleteMembershipID = Console.ReadLine();
        
        bool found = false;
        for (int member = 0; member < memberList.Count; member++)
        {
            if (memberList[member].membershipID == deleteMembershipID)
            {
                memberList.RemoveAt(member);
                found = true;
            }
        }  // end foreach  
        if (found)
            Console.WriteLine("Membership: " + deleteMembershipID + " was deleted.");
        else
            Console.WriteLine("Member not on file.");
    }
    static void MemberPurchase(List<Members> memberList)
    {
        Console.WriteLine("Enter the member ID that made the purchase: ");
        string costMemberId = Console.ReadLine();
        Console.WriteLine("What was the cost of the item? ");
        string sCost = Console.ReadLine();
        double.TryParse(sCost, out double cost);
        bool found = false;
        if (cost > 0)
        {
            foreach(var buyerID in memberList)
            {
                if (buyerID.membershipID == costMemberId)
                {
                    buyerID.Purchase(cost);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Member not found. ");
            }
        }
        else
        {
            Console.WriteLine("Item cost must be greater than 0 to complete a purchase. ");
        }

    }
    static void MemberReturn(List<Members> memberList)
    {
        Console.WriteLine("Enter the member ID that making the return: ");
        string costMemberId = Console.ReadLine();
        Console.WriteLine("What was the cost of the item? ");
        string sCost = Console.ReadLine();
        double.TryParse(sCost, out double cost);
        bool found = false;
        if (cost > 0)
        {
            foreach(var returnID in memberList)
            {
                if (returnID.membershipID == costMemberId)
                {
                    returnID.Return(cost);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Member not found. ");
            }
        }
        else 
        {
            Console.WriteLine("Item cost needs to be greater than 0 to complete a return. ");
        }
    }
    static void MemberApplyCashBack(List<Members> memberList)
    {
        Console.WriteLine("Please enter the reward account member ID: ");
        string rewardMemberID = Console.ReadLine();
        bool found = false;
        foreach(var cashBack in memberList)
        {
            if (rewardMemberID == cashBack.membershipID)
            {
                switch (cashBack.membershipType.ToUpper())
                {
                    case "NONPROFIT":
                        if (cashBack is NonProfit nonProfitMember)
                            {
                                string display = nonProfitMember.CashBack(nonProfitMember.monthlyTranAmount);
                                Console.WriteLine("NonProfit accounts earn 3%. Since you spent " + nonProfitMember.monthlyTranAmount.ToString("C2") + display);
                            }
                        break;
                    case "CORPORATE":
                        if (cashBack is Corporate corporateMember)
                            {
                                string display = corporateMember.CashBack(corporateMember.monthlyTranAmount);
                                Console.WriteLine("Corporate accounts earn 4% cashback, since you spent " + corporateMember.monthlyTranAmount.ToString("C2") + " you have "+ display);
                            }
                        break;
                    case "REGULAR":
                        if (cashBack is Regular regularMember)
                            {
                                string display = regularMember.CashBack(regularMember.monthlyTranAmount);
                                Console.WriteLine("Regular accounts earn 3% cashback, since you spent " + regularMember.monthlyTranAmount.ToString("C2") + " you have "+ display);
                            }
                        break;
                    case "EXECUTIVE":
                        if (cashBack is Executive executiveMember)
                            {
                                string display = executiveMember.CashBack(executiveMember.monthlyTranAmount);
                                Console.WriteLine("Executive accounts earn 5% cashback, or 10% if spending exceeds $1,000.00. Since you spent " + executiveMember.monthlyTranAmount.ToString("C2") + " you have "+ display);
                            }
                        break;
                    default:
                        Console.WriteLine("Invalid type ");
                        break;
                }
                found = true;
                Console.WriteLine("Congrats on accumulating reward points, our rewards shop is currently closed.  Come back later to use your points. ");
            }    
        }
    }

}  // end program

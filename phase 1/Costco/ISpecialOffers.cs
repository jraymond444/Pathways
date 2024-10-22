using System;
using System.Collections.Generic;
/*  interface for showing the special offers
*/
namespace costco;

public interface ISpecialOffers 
{
    double SpecialOffers(double annualCost); //calculates interest to be used by savings or CD classes
}
 

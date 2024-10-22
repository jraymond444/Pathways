using System;
using System.Collections.Generic;
/*  interface for calculating intertest
*/
namespace bank
{
    public interface ICalculateInterest 
    {
        double CalcInterest(double balance); //calculates interest to be used by savings or CD classes
    }
 } 

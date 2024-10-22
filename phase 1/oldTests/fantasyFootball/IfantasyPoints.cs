using System;
using System.Collections.Generic;
/*  interface for calculating fantasy points
*/
namespace football
{
    public interface IfantasyPoints 
    {
        double YardPoints(double yards); //calculates points based on yards
        double TouchPoints(int touchdowns); //calculates points based on touchdowns  
    }
 } 

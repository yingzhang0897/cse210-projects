using System;
using System.Diagnostics;

class Program
{
   
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        fraction.SetTop(1);
        double top = Convert.ToDouble(fraction.GetTop());
        
        fraction.SetBottom(3);
        double bottom = Convert.ToDouble(fraction.GetBottom());
        fraction.GetFractionString(top,bottom);
        fraction.GetDecimalValue(top,bottom);
        

       
    }
}

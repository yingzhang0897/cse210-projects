public class Fraction
{
    private int _top;
    private int _bottom;

    //constructors
    //1.non-argument constructor
    public Fraction()
        {
            _top = 1;
            _bottom = 1;
            Console.WriteLine($"The result is {_top/_bottom}");
        }
    //2.has one parameter
    public Fraction(int top) 
    {
        _top = top;
        _bottom = 1;
        Console.WriteLine($"The result is {_top/_bottom}");
    }
    //3. has two parameters( the question is int/int cannot return double)

    public Fraction (int top, int bottom)
    {
        _top = top;
        _bottom = bottom;

        Console.WriteLine($"The result is {_top/_bottom}");
    }
    //Get ans set top
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    //get and set bottom
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    //get the string result
    public void GetFractionString(double top, double bottom)
    {
        
        Console.WriteLine($"The string result is {top}/{bottom}");
    }
    //get the decimal result
    public void GetDecimalValue(double top, double bottom)
    {
        
        double num  = top/bottom;
        Console.WriteLine($"The decimal result is {num}");
    }


}
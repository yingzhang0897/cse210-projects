class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // constructor
    public  Job(string aCompany, string aTitle, int aStartYear, int aEndYear)
    {
        _company = aCompany;
        _jobTitle = aTitle;
        _startYear = aStartYear;
        _endYear = aEndYear;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"{_jobTitle } ({_company}) {_startYear}-{_endYear}");
    }

}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;

class Program
{
    static void Main(string[] args)
    {
        //call constructor in class "Job"
        Job job1 = new Job("Microsoft","Softwate Engineer",2015,2018);
        Job job2 = new Job("Apple","IT Supporter",2018,2019);

        Resume myResume = new Resume();
        myResume._name = " Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.ResumeDisplay();


    }
}
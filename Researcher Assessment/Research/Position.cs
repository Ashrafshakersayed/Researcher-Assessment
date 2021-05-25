using System;

namespace Researcher_Assessment.Research
{
    public class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }


    }

    public enum EmploymentLevel
    {
        Student,
        A,
        B,
        C,
        D,
        E
    }
}

using System;

namespace Researcher_Assessment.Research
{
    public class Publication
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Year { get; set; }
        public OutputType Type { get; set; }
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }

        public override string ToString()
        {
            return $"({Year}) {Title}";
        }
    }

    public enum OutputType
    {
        Conference,
        Journal,
        Other
    }
}

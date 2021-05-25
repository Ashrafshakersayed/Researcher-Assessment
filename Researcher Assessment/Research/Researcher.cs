using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Researcher_Assessment.Research
{
    public class Researcher
    {
        public int id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Unit { get; set; }
        public EmploymentLevel Level { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public List<Position> positions { get; set; }
        public List<Publication> publications { get; set; }

        public override string ToString()
        {
            return $"{FamilyName}, {GivenName} ({Title})";
        }

        public int GetId()
        {
            return id;
        }

        public Position GetCurrentJob()
        {
           
            Position currentJob = positions.FirstOrDefault();
            foreach (var job in positions)
            {
                if (currentJob.Start < job.Start)
                {
                    currentJob = job;
                }
            }
            return currentJob;
        }

        public string CurrentJobTitle()
        {
            return GetCurrentJob().Title;
        }

        public DateTime CurrentJobStart()
        {
            return GetCurrentJob().Start;
        }

        public Position GetEarliestJob()
        {
            Position currentJob = positions.FirstOrDefault();
            foreach (var job in positions)
            {
                if (currentJob.Start > job.Start)
                {
                    currentJob = job;
                }
            }
            return currentJob;
        }

        public DateTime EarliestStart()
        {
            return GetEarliestJob().Start;
        }

        public float Tenure()
        {
            float dayes = (DateTime.Now.Subtract(EarliestStart()).Days);
            return dayes/ 365;
        }

         public int PublicationsCount()
        {
            return publications.Count;
        }
    }
}

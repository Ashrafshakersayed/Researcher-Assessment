using Researcher_Assessment.Database;
using Researcher_Assessment.Research;
using System.Collections.Generic;
using System.Linq;

namespace Researcher_Assessment.Controls
{


    public class ResearcherController
    {
        ERDAdapter adapter;
        PublicationsController publicationsController;
        public List<Researcher> MainList { get; set; }
        public List<Researcher> DisList { get; set; }

        public Researcher disResearcher { get; set; }

        public ResearcherController()
        {
            adapter = new ERDAdapter();
            publicationsController = new PublicationsController();
        }

        public void LoadReseachers()
        {
            MainList = DisList = adapter.fetchBasicResearcherDetails();
        }

        public void FilterBy(EmploymentLevel level)
        {

            DisList = MainList.Where(s => s.Level == level)
                .ToList();
        }

        public void FilterByName(string name)
        {
            DisList = MainList.Where(s => (s.GivenName + s.FamilyName)
            .ToLower().Contains(name.Trim().ToLower()))
                .ToList();
        }

        public void LoadResearcherDetails(int index)
        {
            if (DisList.Count == 0 || index < 0) return;

            disResearcher = DisList[index];
            disResearcher.positions = adapter.fetchFullResearcherDetails(disResearcher.GetId()).positions;
            disResearcher.publications = publicationsController.loadPublicationsFor(disResearcher);

        }
    }
}


using Researcher_Assessment.Database;
using Researcher_Assessment.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Researcher_Assessment.Controls
{
   public class PublicationsController
    {
        ERDAdapter adapter;

        public List<Researcher> MainList { get; set; }
        public List<Researcher> DisList { get; set; }


        public PublicationsController()
        {
            adapter = new ERDAdapter();
        }

        public List<Publication> loadPublicationsFor( Researcher r)
        {
            return adapter.fetchBasicPublicationDetails(r);
        }
    }
}

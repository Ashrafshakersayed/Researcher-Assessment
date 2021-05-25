using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Researcher_Assessment.Research
{
   public class Staff : Researcher
    {
        public float ThreeYearAverage()
        {
            return (PublicationsCount()/Tenure()) * 3;
        }
        public float Performance()
        {
            return PublicationsCount() / Tenure() ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public class CompanyParameters : RequestParameters
    {
        public CompanyParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
    }
}

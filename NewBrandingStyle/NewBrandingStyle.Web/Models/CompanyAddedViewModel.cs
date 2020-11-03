using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBrandingStyle.Web.Models
{
    public class CompanyAddedViewModel
    {
        public int NumbersOfCharsInName { get; set; }
        public int NumbersOfCharsInDescription { get; set; }
        public bool IsHidden { get; set; }
    }
}

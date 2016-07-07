using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerG6.Services.SDM
{
    public class HamburgerCase
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
        public string CustomerDescription { get; set; }
        public string CustomerOrganization { get; set; }
        public string Status { get; set; }
        public string Callback { get; set; }
        public string Reference { get; set; }

        public string ProblemSnippet { get; set; }
    }
}

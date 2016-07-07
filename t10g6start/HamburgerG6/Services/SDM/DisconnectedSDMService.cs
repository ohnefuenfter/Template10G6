using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerG6.Services.SDM
{
    public class DisconnectedSDMService : ISDMService
    {
        HamburgerCase[] disconnectedCases = new HamburgerCase[] {
            new HamburgerCase
            {
                Id="123",
                Description = "Case 123",
                ProblemSnippet = "When i start the case ..."
            },
            new HamburgerCase
            {
                Id="124",
                Description = "Case 123",
                ProblemSnippet = "When i load the case ..."
            },
            new HamburgerCase
            {
                Id="125",
                Description = "Case 123",
                ProblemSnippet = "When i delete the case ..."
            }
            };

        public HamburgerCase GetCase(string id)
        {
            return disconnectedCases.FirstOrDefault(c => c.Id == id);
        }

        public IList<HamburgerCase> GetCases()
        {
            return new List<HamburgerCase>(disconnectedCases);
        }
    }
}

using HamburgerG6.Services.SDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerG6.Services
{
    public interface ISDMService
    {
        IList<HamburgerCase> GetCases();
        HamburgerCase GetCase(string id);
    }
}

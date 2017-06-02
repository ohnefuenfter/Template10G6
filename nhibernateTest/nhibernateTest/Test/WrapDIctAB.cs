using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhibernateTest.Test
{
    public class WrapDictAB
    {
        public virtual int WrapDictABPK { get; set; }

        public virtual ClassB ClassB { get; set; }
        
        public virtual int Factor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhibernateTest.Test
{
    public class ClassA
    {
        public ClassA()
        {
            Dict = new Dictionary<ClassB, int>();
            // WrapDict = new List<WrapDictAB>();
        }

        public virtual int ClassAPK { get; set; }
        public virtual IDictionary<ClassB, int> Dict { get; set; } //int is 1 or -1

        public virtual IList<WrapDictAB> WrapDict { get; set; }
    }
}

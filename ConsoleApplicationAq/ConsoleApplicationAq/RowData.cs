using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class RowData
    {

        public List<Attribute> Attributes { get; set; }
        public ClassData Class { get; set; } = new ClassData();
        public int State { get; set; } = 0;

    }
}

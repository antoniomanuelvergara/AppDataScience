using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common.Graph
{
    public class Arc<T>
    {

        public Node<T> from { get; set; }
        public Node<T> to { get; set; }
        public int Cost { get; set; }
        public Arc(Node<T> from, Node<T> to, int cost = 0)
        {
            this.from = from;
            this.to = to;
            this.Cost = cost;
        }

    }
}

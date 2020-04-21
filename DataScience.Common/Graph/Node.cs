using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common.Graph
{
    public class Node<T>
    {
        private T data;
        private NodeList<T> adyacentsNodes = null;
        private bool isVisit = false;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> adyacentsNodes)
        {
            this.data = data;
            this.adyacentsNodes = adyacentsNodes;
        }

        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public bool IsVisit
        {
            get
            {
                return isVisit;
            }
            set
            {
                isVisit = value;
            }
        }


        public NodeList<T> AdyacentsNodes
        {
            get
            {
                if (adyacentsNodes == null)
                    adyacentsNodes = new NodeList<T>();
                return adyacentsNodes;
            }
            set
            {
                adyacentsNodes = value;
            }
        }
    }
}

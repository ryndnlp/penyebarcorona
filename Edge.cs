using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Edge
    {
        public string fromNode;
        public string toNode;
        public double tr;

        public Edge(string fromNode, string toNode, double tr)
        {
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.tr = tr;
        }

    }
}

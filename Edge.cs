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
        public int tr;

        public Edge(string fromNode, string toNode, double chance)
        {
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.chance = chance;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Edge
    {
        public enum Status
        {
            Exists,
            Activated,
            Pathway
        }

        public Status status;
        public string fromNode;
        public string toNode;
        public double transferChance;

        public Edge(string fromNode, string toNode, double tr)
        {
            this.status = Status.Exists;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.transferChance = tr;
        }

    }
}

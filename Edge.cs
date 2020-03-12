using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Edge
    {
        // Berbagai jenis status sisi
        public enum Status
        {
            Exists,
            Activated,
            Pathway
        }

        // Status sisi
        public Status status;

        // Simpul asal
        public string fromNode;

        // Simpul akhir
        public string toNode;

        // Peluang transfer penyakit
        public double transferChance;

        // Konstruktor sisi baru
        public Edge(string fromNode, string toNode, double tr)
        {
            this.status = Status.Exists;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.transferChance = tr;
        }

    }
}

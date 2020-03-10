using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Simulator
    {
        public int nodeCount;
        public int currentTime;

        public List<Node> daftarNode;
        public List<Edge> daftarEdge;

        public Simulator()
        {
            daftarNode = loadNodes("nodes.txt");
            daftarEdge = loadEdges("edges.txt");
        }

        public float getS(string A, string B)
        {
            return 1; // edit
        }

        public void next()
        {
            /* 1. liat semua Node yg sakit (A)
             * 2. liat semua tetangga (B), cek S
             *      2.1. Kalo S >= 1, T(B) = currentTime;
             *      2.2. Kalo S < 1, diemin bgst
             * 3. 
             * 
             */
            currentTime++;
        }

        public List<Node> loadNodes(string path)
        {
            return new List<Node>();
        }
        public List<Edge> loadEdges(string path)
        {
            return new List<Edge>();
        }
    }
}

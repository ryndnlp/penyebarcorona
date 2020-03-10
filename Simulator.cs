using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public double getS(string A, string B)
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
            // Dekarasi
            string[] unitEdges;
            int N;
            string fromNode;
            string toNode;
            string chance;
            List<Edge> e = new List<Edge>;

            // Baca teks per line
            string[] lines = File.ReadAllLines(path);

            char[] separator = {' '};

            // Split
            unitEdges = lines[0].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            N = int.Parse(unitEdges[0]);

            for (int i=1; i < N; i++);
            {
                unitEdges = lines[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                fromNode = unitEdges[1];
                toNode = unitEdges[1];
                chance = int.Parse(unitEdges[1]);
            }
               
            return new List<Edge>();
        }
    }
}

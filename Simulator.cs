using System;
using System.Collections.Generic;
using System.IO;
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
            // Declaration
            string[] unitNode;
            string name;
            int P;
            List<Node> r = new List<Node>();
            Node N;
       
            // Read a text file line by line.  
            string[] lines = File.ReadAllLines(path);
            
            char[] separator = {' '};

            // Split into strings and split at separator
            unitNode = lines[0].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            
            string firstNode = unitNode[1];
            
            for (int i=1; i<lines.Length;i++)
            {
                unitNode = lines[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                name = unitNode[0];
                P = int.Parse(unitNode[1]);
                N = new Node(name, P);
                if(name == firstNode)
                {
                    N.T = 0;
                }
                r.Add(N);
            }
            return r;
        }
        public List<Edge> loadEdges(string path)
        {
            return new List<Edge>();
        }
    }
}

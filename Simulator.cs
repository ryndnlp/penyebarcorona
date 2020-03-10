using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Simulator
    {
        public int currentTime;

        public List<Node> daftarNode;
        public List<Edge> daftarEdge;

        public Simulator()
        {
            daftarNode = loadNodes("nodes.txt");
            daftarEdge = loadEdges("edges.txt");
            currentTime = 0;
        }

        public double getS(string A, string B)
        {
            Console.WriteLine($"S dari {A} ke {B}:");
            var IA = (daftarNode.Find((node) => node.name == A).getI(currentTime));
            Console.WriteLine($"I = {IA}");
            var tr = (daftarEdge.Find((edge) => edge.fromNode == A && edge.toNode == B)).tr;
            Console.WriteLine($"TR = {tr}");
            return IA * tr;
        }

        public void next()
        {
            // cari semua node yang terinfeksi
            var infected = daftarNode.FindAll((node) => node.T >= 0).Select((node) => node.name);

            // isi queue dengan edge yang berasal dari node yang terinfeksi dan menuju yang tidak terinfeksi
            var list = daftarEdge.FindAll((edge) => infected.Contains(edge.fromNode) && !infected.Contains(edge.toNode));
            Queue<Edge> queue = new Queue<Edge>(list);

            // catat yang sudah dimasukkan kedalam queue
            var done = new HashSet<string>();

            // looping pengujian S
            while (queue.Count > 0)
            {
                // pop queue
                var e = queue.Dequeue();

                // cek S
                var S = getS(e.fromNode, e.toNode);
                
                // jika terjadi infeksi
                if (S > 1 && !done.Contains(e.toNode))
                {
                    Console.WriteLine($"{e.fromNode} berhasil menginfeksi {e.toNode} (S = {S})");
                    // tandai udah
                    done.Add(e.toNode);

                    // update nilai T
                    daftarNode.Find((node) => node.name == e.toNode).T = currentTime;

                    // masukkan edge yang lain ke queue
                    foreach (Edge newInfection in daftarEdge.FindAll((edge) => edge.fromNode == e.toNode))
                    {
                        queue.Enqueue(newInfection);
                    }
                }
            }

            // tambahkan currentTime
            currentTime++;
        }

        public void output(Graph g)
        {
            foreach (Edge e in daftarEdge)
            {
                g.AddEdge(e.fromNode, e.toNode);
            }

            foreach (Node n in daftarNode)
            {
                var node = g.FindNode(n.name);
                if (n.T >= 0) node.Attr.Color = Color.Red;
            }
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
            // Dekarasi
            string[] unitEdges;
            int N;
            string fromNode;
            string toNode;
            double chance;
            List<Edge> e = new List<Edge>();
            Edge ed;

            // Baca teks per line
            string[] lines = File.ReadAllLines(path);

            char[] separator = {' '};

            // Split
            unitEdges = lines[0].Split(separator, StringSplitOptions.RemoveEmptyEntries);
            N = int.Parse(unitEdges[0]);

            for (int i=1; i <= N; i++)
            {
                unitEdges = lines[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                fromNode = unitEdges[0];
                toNode = unitEdges[1];
                chance = double.Parse(unitEdges[2], CultureInfo.InvariantCulture);
                ed = new Edge(fromNode, toNode, chance);
                e.Add(ed);
            }
               
            return e;
        }
    }
}

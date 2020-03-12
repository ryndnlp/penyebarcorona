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
    // Simulator
    // Kelas yang menangani proses simulasi secara keseluruhan
    class Simulator
    {
        // Nomor hari yang sedang disimulasikan
        public int currentTime;

        // Daftar simpul dan sisi
        public List<Node> nodeList;
        public List<Edge> edgeList;

        public Simulator()
        {
            nodeList = loadNodes("nodes.txt");
            edgeList = loadEdges("edges.txt");
            currentTime = 0;
        }

        public double getS(string A, string B)
        {
            var IA = (nodeList.Find((node) => node.name == A).getInfectionCount(currentTime));
            var tr = (edgeList.Find((edge) => edge.fromNode == A && edge.toNode == B)).transferChance;
            return IA * tr;
        }

        public void next()
        {
            // cari semua node yang terinfeksi
            var infectedNodeNames = nodeList.FindAll((node) => node.infectionDay >= 0).Select((node) => node.name);

            // isi queue dengan edge yang berasal dari node yang terinfeksi dan menuju yang tidak terinfeksi
            var list = edgeList.FindAll((edge) => infectedNodeNames.Contains(edge.fromNode) && !infectedNodeNames.Contains(edge.toNode));
            Queue<Edge> queue = new Queue<Edge>(list);

            // catat yang sudah dimasukkan kedalam queue
            var doneNodeNames = new HashSet<string>();
            foreach (string s in infectedNodeNames)
            {
                doneNodeNames.Add(s);
            }

            // looping pengujian S
            while (queue.Count > 0)
            {
                // pop queue
                var e = queue.Dequeue();

                // cek S
                var S = getS(e.fromNode, e.toNode);
                
                // jika terjadi infeksi
                if (S > 1 && !doneNodeNames.Contains(e.toNode))
                {
                    // tandai udah
                    doneNodeNames.Add(e.toNode);

                    // update nilai T
                    nodeList.Find((node) => node.name == e.toNode).infectionDay = currentTime;

                    // masukkan edge yang lain ke queue
                    foreach (Edge newInfection in edgeList.FindAll((edge) => edge.fromNode == e.toNode))
                    {
                        queue.Enqueue(newInfection);
                    }
                }
            }

            // tambahkan currentTime
            currentTime++;
        }

        public void output(System.Windows.Controls.Label l, Graph g)
        {
            l.Content = $"Day {currentTime}";
            foreach (Edge e in edgeList)
            {
                var draw = g.AddEdge(e.fromNode, e.transferChance.ToString(), e.toNode);
                draw.Attr.Color = Color.White;
                draw.Label.FontColor = Color.White;
                draw.Label.FontSize = 7;
            }

            foreach (Node n in nodeList)
            {
                var node = g.FindNode(n.name);
                var b = Convert.ToByte(255 - ((n.getInfectionCount(currentTime) / n.populationCount) * 255));
                if (n.infectionDay >= 0)  
                {
                    node.Attr.FillColor = new Color(255, b, b);
                    node.Attr.Color = new Color(255, b, b);
                }
                else
                {
                    node.Attr.FillColor = Color.White;
                    node.Attr.Color = Color.White;
                }
                node.Attr.Shape = Shape.Circle;
                node.LabelText = n.name + ((n.infectionDay >= 0) ? $" ({n.getInfectionCount(currentTime):N0})" : " (0)");
            }
            g.Attr.BackgroundColor = new Color(30, 30, 30);

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
                    N.infectionDay = 0;
                }
                r.Add(N);
            }
            return r;
        }
        public List<Edge> loadEdges(string path)
        {
            // Deklarasi
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

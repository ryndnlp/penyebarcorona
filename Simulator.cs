using System;
using System.Collections.Generic;
using System.Linq;
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

        public float getS(string A, string B)
        {
            return 1; // edit
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Node
    {
        public string name;
        public int P;
        private double I;
        public int T;
        private int t;

        public Node(string name, int P)
        {
            this.name = name;
            this.P = P;
            this.T = -1;
            this.t = -1;
            this.I = -1d;
        }
        public double getI(int currentTime)
        { 
            this.I = (double)this.P / (double)(1 + ((this.P - 1) * Math.Exp(-0.25 * (this.gett(currentTime)))));
            return this.I;
        }

        public double gett(int currentTime)
        {
            t = currentTime - T;
            return t;
        }
    }
}

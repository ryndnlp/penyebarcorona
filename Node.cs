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
        private float I;
        public int T;
        private int t;

        public float getI(int currentTime)
        {
            I = 1.0f; // edit
            return I;
        }

        public float gett(int currentTime)
        {
            t = currentTime - T;
            return t;
        }
    }
}

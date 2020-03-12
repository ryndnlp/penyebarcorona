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
        public int populationCount;
        public int infectionDay;

        public Node(string name, int P)
        {
            this.name = name;
            this.populationCount = P;
            this.infectionDay = -1;
        }
        public double getInfectionCount(int currentTime)
        { 
            return (double)this.populationCount / (double)(1 + ((this.populationCount - 1) * Math.Exp(-0.25 * (this.getTimeFromInfection(currentTime))))); ;
        }

        public double getTimeFromInfection(int currentTime)
        {
            return currentTime - infectionDay;
        }
    }
}

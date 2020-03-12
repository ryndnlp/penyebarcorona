using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penyebarcorona
{
    class Node
    {
        // Nama simpul
        public string name;

        // Jumlah populasi
        public int populationCount;

        // Hari pertama infeksi
        public int infectionDay;

        // Konstruktor simpul baru
        public Node(string name, int P)
        {
            this.name = name;
            this.populationCount = P;
            this.infectionDay = -1;
        }
        
        // Fungsi menghitung nilai I
        public double getInfectionCount(int currentTime)
        { 
            return (double)this.populationCount / (double)(1 + ((this.populationCount - 1) * Math.Exp(-0.25 * (this.getTimeFromInfection(currentTime))))); ;
        }

        // Fungsi mengambil waktu sejak pertama infeksi
        public double getTimeFromInfection(int currentTime)
        {
            return currentTime - infectionDay;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Armour
    {

        public int id, prot1, prot2, aglPenalty;
        public string name;

        public Armour(int id, string name, int prot1, int prot2, int penalty)
        {
            this.id = id;
            this.name = name;
            this.prot1 = prot1;
            this.prot2 = prot2;
            this.aglPenalty = penalty;
        }

    }
}

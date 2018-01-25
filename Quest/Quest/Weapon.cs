using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Weapon
    {

        public int id, minDmg, maxDmg, defense, penetration, cunning;
        public string name;

        public Weapon(int id, string name, int minDmg, int maxDmg, int defense, int penetration, int cunning)
        {
            this.id = id;
            this.name = name;
            this.minDmg = minDmg;
            this.maxDmg = maxDmg;
            this.defense = defense;
            this.penetration = penetration;
            this.cunning = cunning;

        }

    }
}

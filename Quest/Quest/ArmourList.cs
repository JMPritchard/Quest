using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class ArmourList
    {

        public List<Armour> list = new List<Armour>();

        //const int NUMBEROFARMOURS = 12;

        public ArmourList()
        {
            //add concrete objects to armour list
            list.Add(new Armour(0, "None", 0, 0, 0));
            list.Add(new Armour(1, "Leather Jerkin", 30, 0, 0));
            list.Add(new Armour(2, "Chain Hauberk", 80, 0, 1));
            list.Add(new Armour(3, "Platemail", 100, 25, 2));
            list.Add(new Armour(4, "Displacement Cloak", 30, 0, -1));
            list.Add(new Armour(5, "Mithril Chain", 80, 0, 0));
            list.Add(new Armour(6, "Heavy Runed Plate", 100, 65, 2));
        }

    }
}

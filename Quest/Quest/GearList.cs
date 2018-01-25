using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class GearList
    {

        public List<Gear> list = new List<Gear>();

        public GearList()
        {
            //add concrete objects to gear list
            list.Add(new Gear(0, "Nothing"));
            list.Add(new Gear(1, "Lantern"));
            list.Add(new Gear(2, "Lock Picks"));
            list.Add(new Gear(3, "Crowbar"));
            list.Add(new Gear(4, "Elixir of Restoration"));

        }
    }
}

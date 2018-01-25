using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class WeaponList
    {
        public List<Weapon> list = new List<Weapon>();

        //const int NUMBEROFWEAPONS = 12;

        public WeaponList()
        {
            //add concrete weapon objects to weapon list
            list.Add(new Weapon(0, "None", 0, 1, 0, 0, 0));
            list.Add(new Weapon(1, "Rusty Sword", 1, 3, 1, 0, 0));
            list.Add(new Weapon(2, "Sturdy Club", 1, 3, 0, 1, 0));
            list.Add(new Weapon(3, "Fighting Knife", 1, 3, 0, 0, 1));
            list.Add(new Weapon(4, "Iron Broadsword", 1, 4, 2, 0, 0));
            list.Add(new Weapon(5, "Steel Mace", 1, 4, 0, 2, 0));
            list.Add(new Weapon(6, "Balanced Dagger", 1, 4, 0, 0, 2));
            list.Add(new Weapon(7, "Vorpal Longsword", 2, 5, 2, 0, 0));
            list.Add(new Weapon(8, "Runed Warhammer", 2, 5, 0, 2, 0));
            list.Add(new Weapon(9, "Blacksteel Dirk", 2, 5, 0, 0, 2));
            list.Add(new Weapon(10, "Staff of Power", 1, 4, 1, 1, 0));

        }

    }
}

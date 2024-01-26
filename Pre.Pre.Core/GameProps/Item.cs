using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.Enums;
using Pre.Pre.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.GameProps
{
    internal abstract class Item
    {
        internal string Name { get; private set; }
        internal string Description { get; private set; }
        internal int StatsBonus { get; private set; }
        internal Tiers Tier { get; private set; }

        protected Item(int statsBonus, string name, string description, Tiers tier)
        {
            Name = name;
            Description = description;
            StatsBonus = statsBonus;
            Tier = tier;
        }

        internal abstract void UseItem(Player player, Item toUse);
    }
}

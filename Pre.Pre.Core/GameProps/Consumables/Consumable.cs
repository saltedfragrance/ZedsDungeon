using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameProps.Consumables
{
    internal abstract class Consumable : Item
    {
        internal Consumable(int statsBonus, string name, string description, Tiers tier) : base(statsBonus, name, description, tier) { }
    }
}

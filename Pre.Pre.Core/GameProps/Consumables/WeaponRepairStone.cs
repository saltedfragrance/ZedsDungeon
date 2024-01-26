using Pre.Pe2.Cons.Entities;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.GameProps
{
    internal class WeaponRepairStone : Consumable
    {
        internal WeaponRepairStone(int statsBonus, string name, string description, Tiers tier) : base(statsBonus, name, description, tier) { }

        internal override void UseItem(Player player, Item toUse)
        {
            throw new NotImplementedException();
        }
    }
}

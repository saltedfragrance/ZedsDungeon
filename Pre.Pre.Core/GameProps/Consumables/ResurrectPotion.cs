using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameProps
{
    internal class ResurrectPotion : Consumable
    {
        internal ResurrectPotion(int statsBonus, string name, string description, Tiers tier) : base(statsBonus, name, description, tier) { }

        internal override void UseItem(Player player, Item toUse)
        {
            if (player.HealthPercentage > 0) throw new Exception("You can't use this whilst alive!");
            else
            {
                player.HealthPercentage += StatsBonus;
                player.IsResurrected = true;
            }

            player.Inventory.Items.Remove(toUse);
        }

    }
}

using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.Enums;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps.Wearables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameProps
{
    internal class Weapon : Wearable
    {
        internal Weapon(int statsBonus, string name, string description, Tiers tier, Classes playerClass) : base(statsBonus, name, description, tier, playerClass) { }

        internal override void UseItem(Player player, Item toUse)
        {
            if (player.HealthPercentage <= 0) throw new Exception("You can't change weapon whilst dead!");
            else
            {
                player.Inventory.Items.Add(player.Weapon);
                player.Weapon = (Weapon)toUse;
                player.GrantWearablesBonuses(player);
                player.Inventory.Items.Remove(toUse);
            }
        }

    }
}

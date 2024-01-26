using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.Enums;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameProps.Wearables
{
    internal class Armor : Wearable
    {
        internal Armor(int statsBonus, string name, string description, Tiers tier, Classes playerClass) : base(statsBonus, name, description, tier, playerClass) { }

        internal override void UseItem(Player player, Item toUse)
        {
            if (toUse != null)
            {
                if (player.HealthPercentage <= 0) throw new Exception("You can't change armor whilst dead!");
                else
                {
                    player.Inventory.Items.Add(player.Armor);
                    player.Armor = (Armor)toUse;
                    player.GrantWearablesBonuses(player);
                    player.Inventory.Items.Remove(toUse);
                }
            }
        }
    }
}
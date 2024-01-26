using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.Enums;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.GameProps
{
    internal class ArmorRepairStone : Consumable
    {
        internal ArmorRepairStone(int statsBonus, string name, string description, Tiers tier) : base(statsBonus, name, description, tier) { }

        internal override void UseItem(Player player, Item toUse)
        {
            if (toUse != null)
                if (player.ArmorPercentage == 100) throw new Exception("Your armor is already full! Using this would be a waste.");
                else if (player.HealthPercentage <= 0) throw new Exception("You can't use this when dead!");
                else if ((player.ArmorPercentage + toUse.StatsBonus) > 100) player.HealthPercentage = 100;
                else player.ArmorPercentage += StatsBonus;

            player.Inventory.Items.Remove(toUse);
        }
    }
}


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
    internal class HealthPotion : Consumable
    {

        internal HealthPotion(int statsBonus, string name, string description, Tiers tier) : base(statsBonus, name, description, tier)
        {

        }
        internal override void UseItem(Player player, Item toUse)
        {
            if (toUse != null)
            {
                if (player.HealthPercentage == 100) throw new Exception("Your health is already full! Using this would be a waste.");
                else if (player.HealthPercentage <= 0) throw new Exception("You can't use this when dead!");
                else if ((player.HealthPercentage + toUse.StatsBonus) > 100) player.HealthPercentage = 100;
                else player.HealthPercentage += StatsBonus;

                player.Inventory.Items.Remove(toUse);
            }
        }
    }
}

using Pre.Pe2.Cons.Enums;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps;
using Pre.Pre.Core.GameProps.Wearables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.DataRepositories
{
    internal class ItemsRepository
    {
        internal IEnumerable<Item> GetItems()
        {
            return new List<Item>
            {
                new HealthPotion(15, "Small Health Potion", "Restores 15 Health Points", Tiers.Meh),
                new HealthPotion(30, "Large Health Potion", "Restores 30 Health Points", Tiers.Good),
                new HealthPotion(50, "Super Health Potion", "Restores 50 Health Points", Tiers.Great),
                new HealthPotion(70, "Elixir", "Restores 70 Health Points", Tiers.God),
                new HealthPotion(100, "MegaElixir", "Fully restores health", Tiers.Unbelievable),

                new ArmorRepairStone(15, "Small Armor Repair Stone", "Restores 15 Armor Points", Tiers.Meh),
                new ArmorRepairStone(30, "Large Armor Repair Stone", "Restores 30 Armor Points", Tiers.Good),
                new ArmorRepairStone(50, "Super Armor Repair Stone", "Restores 50 Armor Points", Tiers.Great),
                new ArmorRepairStone(70, "Mega Armor Repair Stone", "Restores 70 Armor Points", Tiers.God),
                new ArmorRepairStone(70, "Ungodly Armor Repair Stone", "Restores 70 Armor Points", Tiers.Unbelievable),

                new ResurrectPotion(100, "Resurrect Potion", "Your ghost will drink this ethereal potion to come back from the dead.\nOnly useable when dead", Tiers.God),

                new Weapon(15, "Sorcerer's Staff", "The basic staff every Wizard graduates with.", Tiers.Good, Classes.Wizard),
                new Weapon(25, "Sage's Staff", "A standard staff some people say is quite powerful.", Tiers.Great, Classes.Wizard),
                new Weapon(40, "Archdeacon Great Staff", "This staff makes you cast immensily powerfull spells.", Tiers.God, Classes.Wizard),
                new Weapon(15, "Broadsword", "A standard sword every Knight graduates with.", Tiers.Good, Classes.Knight),
                new Weapon(25, "Darksword", "Quite a step above average, this sword.", Tiers.Great, Classes.Knight),
                new Weapon(40, "Drake's Sword", "Cuts right through butter! Beware you don't cut yourself!", Tiers.God, Classes.Knight),
                new Weapon(15, "Hand Axe", "A standard axe every warrior graduates with.", Tiers.Good, Classes.Warrior),
                new Weapon(25, "Golem Axe", "Quite a step above average, this axe.", Tiers.Great, Classes.Warrior),
                new Weapon(40, "Crescent Axe", "An axe which could cut one's head off in one fell swoop.", Tiers.God, Classes.Warrior),

                new Armor(15, "Cleric Robe", "The basic robe set every Wizard graduates with.", Tiers.Good, Classes.Wizard),
                new Armor(25, "Antiquated Robe", "A robe set that's for the 'above average' Wizard.", Tiers.Great, Classes.Wizard),
                new Armor(40, "Black Sorcerer's Robe", "This robe radiates power.", Tiers.God, Classes.Wizard),
                new Armor(15, "Leather Armor", "The basic armor set every Knight graduates with.", Tiers.Good, Classes.Knight),
                new Armor(25, "Plate Armor", "For the Knight who has some skills.", Tiers.Great, Classes.Knight),
                new Armor(40, "Full Plate Armor", "Impenetrable armor for a Knight, even for the most dangerous animals.", Tiers.God, Classes.Knight),
                new Armor(15, "Bandit Armor", "The basic armor set every Warrior graduates with.", Tiers.Good, Classes.Warrior),
                new Armor(25, "Iron Armor", "For the warrior who has some skills.", Tiers.Great, Classes.Warrior),
                new Armor(40, "Crimson Armor", "This armor set is by some regarded as the best armor there is for Warriors.", Tiers.God, Classes.Warrior)
            };
        }
    }
}

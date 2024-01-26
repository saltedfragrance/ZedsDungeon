using Pre.Pe2.Cons.Enums;
using Pre.Pe2.Cons.GameFunctionality;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps;
using Pre.Pre.Core.GameProps.Wearables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.Entities
{
    internal delegate void PlayerParryAttemptEventHandler(object source, EventArgs args);

    internal class Player : GameEntity
    {
        internal event PlayerParryAttemptEventHandler ParryAttempted;

        internal PlayerClass PlayerClass { get; }

        internal Weapon Weapon { get; set; }

        internal Armor Armor { get; set; }

        internal bool IsResurrected { get; set; }

        internal Player(string name, PlayerClass playerClass, Weapon weapon = null, Armor armor = null, int healthPercentage = 100, int armorPercentage = 100)
            : base(name, playerClass.AttackPower, playerClass.DefendPower, playerClass.ParryPower, healthPercentage, armorPercentage)
        {
            PlayerClass = playerClass;
            Weapon = weapon;
            Armor = armor;
            SetInventory(this);
        }

        protected virtual void OnParryAttempted()
        {
            if (ParryAttempted != null)
                ParryAttempted(this, EventArgs.Empty);
        }

        internal void Use(Item item)
        {
            item.UseItem(this, item);
        }

        internal override void SetInventory(GameEntity gameEntity)
        {
            Inventory = new Inventory();
            Inventory.InventoryLog = new List<string>();
            Inventory.ItemCategories = new List<string>();
            Inventory.Items = itemsRepository.GetItems().Where(i => i.Tier == Tiers.Meh)
                                              .OrderBy(i => random.Next()).Take(3).ToList();

            Inventory.Items.Add(itemsRepository.GetItems().First(i => i.Name == "Resurrect Potion"));

            if (PlayerClass.Name == Classes.Knight.ToString())
            {
                Weapon = itemsRepository.GetItems().First(w => w.Name == "Broadsword") as Weapon;
                Armor = itemsRepository.GetItems().First(w => w.Name == "Leather Armor") as Armor;
            }
            else if (PlayerClass.Name == Classes.Wizard.ToString())
            {
                Weapon = itemsRepository.GetItems().First(w => w.Name == "Sorcerer's Staff") as Weapon;
                Armor = itemsRepository.GetItems().First(w => w.Name == "Cleric Robe") as Armor;
            }
            else if (PlayerClass.Name == Classes.Warrior.ToString())
            {
                Weapon = itemsRepository.GetItems().First(w => w.Name == "Hand Axe") as Weapon;
                Armor = itemsRepository.GetItems().First(w => w.Name == "Bandit Armor") as Armor;
            }
            else
            {
                Weapon = itemsRepository.GetItems().Where(w => w.GetType() == typeof(Weapon)).First() as Weapon;
                Armor = itemsRepository.GetItems().Where(w => w.GetType() == typeof(Armor)).First() as Armor;
            }

            GrantWearablesBonuses(this);
        }

        internal void GrantWearablesBonuses(Player player)
        {
            if (Weapon != null) player.AttackPower += player.Weapon.StatsBonus;
            if (Armor != null) player.DefendPower += player.Armor.StatsBonus;
        }

        internal void ParryAttempt(GameEntity gameEntity)
        {
            gameEntity.Attack(this);
            OnParryAttempted();
        }
    }
}

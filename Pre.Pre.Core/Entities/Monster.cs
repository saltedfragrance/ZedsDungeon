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
    internal class Monster : GameEntity
    {
        private Tiers Tier { get; }

        internal string MonsterType { get; }

        internal Monster(string name, int attackPower, int defendPower,
            int parryPower, string monsterType, Tiers tier, int healthPercentage = 100, int armorPercentage = 100) : base(name, attackPower, defendPower, parryPower, healthPercentage, armorPercentage)
        {
            MonsterType = monsterType;
            Tier = tier;
        }

        internal void DropLoot(Battle battle)
        {
            Inventory.Items.ForEach(i => battle.Loot.Add(i));
            battle.Loot.ForEach(i => battle.Player.Inventory.Items.Add(i));
        }

        internal override void SetInventory(GameEntity gameEntity)
        {
            Inventory = new Inventory();

            if (MonsterType == "Random")
                Inventory.Items = itemsRepository.GetItems().Where(i => i.Tier == Tier)
                                                 .Where(i => i.GetType() != typeof(Weapon) && i.GetType() != typeof(Armor))
                                                 .OrderBy(i => random.Next()).Take(2).ToList();

            if (MonsterType == "Boss")
            {
                Inventory.Items = itemsRepository.GetItems().Where(i => i.Tier == Tier)
                                                            .Where(i => i.GetType() != typeof(Weapon) && i.GetType() != typeof(Armor))
                                                            .OrderBy(i => random.Next()).Take(2).ToList();


                if (((Player)gameEntity).PlayerClass.Type == "Premade")
                {
                    Inventory.Items.AddRange(itemsRepository.GetItems().Where(i => i.Tier == Tier)
                                                                      .Where((i => i.GetType() == typeof(Weapon)))
                                                                      .Where(i => ((Weapon)i).PlayerClass.ToString() == ((Player)gameEntity).PlayerClass.Name.ToString())
                                                                      .OrderBy(i => random.Next()).Take(1).ToList());

                    Inventory.Items.AddRange(itemsRepository.GetItems().Where(i => i.Tier == Tier)
                                                       .Where((i => i.GetType() == typeof(Armor)))
                                                       .Where(i => ((Armor)i).PlayerClass.ToString() == ((Player)gameEntity).PlayerClass.Name.ToString())
                                                       .OrderBy(i => random.Next()).Take(1).ToList());
                }
                else
                {
                    Inventory.Items.AddRange(itemsRepository.GetItems().Where(i => i.Tier == Tier)
                                                                          .Where((i => i.GetType() == typeof(Weapon)))
                                                                          .OrderBy(i => random.Next()).Take(1).ToList());

                    Inventory.Items.AddRange(itemsRepository.GetItems().Where(i => i.Tier == Tier)
                                                       .Where((i => i.GetType() == typeof(Armor)))
                                                       .OrderBy(i => random.Next()).Take(1).ToList());
                }
            }
        }
    }
}
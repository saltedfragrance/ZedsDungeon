using Pre.Pe2.Cons.Entities;
using Pre.Pre.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.DataRepositories
{
    internal class MonsterRepository
    { 
        internal IEnumerable<Monster> GetMonsters()
        {
            return new List<Monster>
            {
                new Monster("Prison Keeper", 25, 15, 30, "Boss", Tiers.Great),
                new Monster("Beelzebub", 40, 30, 30, "Boss",Tiers.God),
                new Monster("Zed", 50, 40, 50, "Boss", Tiers.Unbelievable),
                new Monster("Goblin", 15, 10, 30, "Random", Tiers.Meh),
                new Monster("Stench Mutant", 15, 10, 20, "Random", Tiers.Meh),
                new Monster("Blob", 15, 10, 20, "Random", Tiers.Meh),
                new Monster("Mad Witch", 25, 20, 30, "Random", Tiers.Good),
                new Monster("DawnBeast", 25, 25, 25, "Random", Tiers.Good),
                new Monster("Stone Golem", 30, 20, 20, "Random", Tiers.Great),
                new Monster("Scorpion", 30, 25, 30, "Random", Tiers.Great),
                new Monster("Giant Lizard", 25, 25, 30, "Random", Tiers.Great),
                new Monster("Wyvern", 35, 35, 35, "Random", Tiers.God),
                new Monster("HellClaw", 40, 30, 30, "Random", Tiers.God),
                new Monster("Demon", 40, 30, 30, "Random", Tiers.God),
            };
        }

        internal Monster GetRandomMonster(Player player)
        {
            Random random = new Random();

            int randomsCount = GetMonsters().Where(p => p.MonsterType == "Random").Count();
            Monster monster = GetMonsters().Where(p => p.MonsterType == "Random").ElementAt(random.Next(randomsCount));
            monster.SetInventory(player);
            return monster;
        }

        internal Monster GetBoss(string monsterName, Player player)
        {
            Monster boss = GetMonsters().First(p => p.Name == monsterName);
            boss.SetInventory(player);
            return boss;
        }
    }
}

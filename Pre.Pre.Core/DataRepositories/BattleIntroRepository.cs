using Pre.Pe2.Cons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.DataRepositories
{
    internal class BattleIntroRepository
    {
        internal List<string> BattleIntros { get; private set; }

        internal void PopulateBattleIntros(Monster monster)
        {
            BattleIntros = new List<string>();
            string monsterStats = $"Attack power: {monster.AttackPower}\n" +
                                  $"Defence power: {monster.DefendPower}\n" +
                                  $"Parry Power: {monster.ParryPower}\n\n";

            BattleIntros.Add($"\n\nYou encounter a fierce {monster.Name}. He looks about ready to pull your head off and smash it to bits.\n\nMonster stats:\n\n" + monsterStats);
            BattleIntros.Add($"\n\nA stupendously large {monster.Name} appears. You don't really want to mess with him... What's it going to be?\n\nMonster stats:\n\n" + monsterStats);
            BattleIntros.Add($"\n\nA ginormous {monster.Name} appears. Looks like he's about one step away from ripping your head off.\n\n" + monsterStats);
            BattleIntros.Add($"\n\nRAAAAAAAAAAAAAAAHG. A slithering {monster.Name} comes out of the woodwork. I'm going to eat your brains, he says.\n\n" + monsterStats);
        }
    }
}

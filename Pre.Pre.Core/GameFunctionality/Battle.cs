using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.GameProps;
using Pre.Pe2.Cons.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.GameFunctionality
{
    internal class Battle
    {
        private int TurnCount { get; set; }

        internal string Turn { get; set; }

        internal List<Item> Loot { get; set; }

        internal bool BattleStatus { get; set; } = true;

        internal Player Player { get; }

        internal Monster Monster { get; }

        internal string[,] Stats { get; private set; }

        internal List<string> BattleLog { get; set; }

        internal bool ParryAttempted { get; set; }

        internal Battle(Player player, Monster monster)
        {
            BattleLog = new List<string>();
            Loot = new List<Item>();
            Player = player;
            Monster = monster;
            UpdateStats();
            player.ParryAttempted += OnParryAttempted;
        }

        internal void OnParryAttempted(object source, EventArgs e)
        {
            ParryAttempted = true;
        }

        internal string NewTurn()
        {
            if (TurnCount % 2 == 0)
            {
                TurnCount++;
                Turn = "Player";
            }
            else
            {
                TurnCount++;
                Turn = "Monster";
            };
            return Turn;
        }

        internal void UpdateStats()
        {
            Stats = new string[3, 2] {
                                        { $"{Player.Name} stats:", $"{Monster.Name} stats:" },
                                        { $"Health: {Player.HealthPercentage}", $"Health: {Monster.HealthPercentage}" },
                                        { $"Armor: {Player.ArmorPercentage}", $"Armor: {Monster.ArmorPercentage}" }
                                 };
        }

        internal void AppendBattleLogItem()
        {
            if (Turn == "Player")
            {
                if (ParryAttempted == false)
                {
                    if (Player.Report.attackParried == false)
                    {
                        if (Player.Report.armorDamageDealt > 0 && Player.Report.healthDamageDealt == 0) BattleLog.Add($">> You've hit {Monster.Name} for {Player.Report.armorDamageDealt} armor damage!\n");
                        else if (Player.Report.armorDamageDealt == 0 && Player.Report.healthDamageDealt > 0) BattleLog.Add($">> You've hit {Monster.Name} for {Player.Report.healthDamageDealt} health damage!\n");
                        else if (Player.Report.armorDamageDealt > 0 && Player.Report.healthDamageDealt > 0) BattleLog.Add($">> You've hit {Monster.Name} for {Player.Report.armorDamageDealt} armor damage and {Player.Report.healthDamageDealt} health damage!\n");
                    }
                    else BattleLog.Add($">> {Monster.Name} has unfortunately cunningly evaded your attack!\n");
                }
                else
                {
                    if (Monster.Report.attackParried == true)
                    {
                        BattleLog.Add($">> Parry attempt Succeeded! You've evaded {Monster.Name}'s attack!");
                    }
                    else BattleLog.Add($">> Parry attempt failed! {Monster.Name} has hit you for {Monster.Report.armorDamageDealt} armor damage and {Monster.Report.healthDamageDealt} health damage!\n");
                }
            }

            else
            {
                if (ParryAttempted == false)
                {
                    if (Monster.Report.attackParried == false)
                    {
                        if (Monster.Report.armorDamageDealt > 0 && Monster.Report.healthDamageDealt == 0) BattleLog.Add($">> {Monster.Name} has hit you for {Monster.Report.armorDamageDealt} armor damage!\n");
                        else if (Monster.Report.armorDamageDealt == 0 && Monster.Report.healthDamageDealt > 0) BattleLog.Add($">> {Monster.Name} has hit you for {Monster.Report.healthDamageDealt} health damage!\n");
                        else if (Monster.Report.armorDamageDealt > 0 && Monster.Report.healthDamageDealt > 0) BattleLog.Add($">> {Monster.Name} has hit you for {Monster.Report.armorDamageDealt} armor damage and {Monster.Report.healthDamageDealt} health damage\n");
                    }
                    else BattleLog.Add($">> You've succesfully parried the monster's attack! Congratulations.\n");
                }
            }
        }
    }
}
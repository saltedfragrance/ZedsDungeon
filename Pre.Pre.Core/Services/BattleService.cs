using Pre.Pe2.Cons.DataRepositories;
using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.GameFunctionality;
using Pre.Pre.Core.Services;
using Pre.Pre.Core.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.Services
{
    internal class BattleService
    {
        internal Battle CurrentBattle { get; set; }

        internal void Encounter(Player player, Monster monster, GameService game)
        {
            CurrentBattle = new Battle(player, monster);

            game.BattleIntros.PopulateBattleIntros(monster);
            game.BattleIntro.DisplayScreen();
        }

        internal void DoBattle(GameService game)
        {
            if (CurrentBattle != null)
                while (CurrentBattle.BattleStatus == true && CheckIfDead(CurrentBattle.Player, CurrentBattle.Monster) == false)
                {
                    if (game.CurrentPlayer.IsResurrected == true) game.CurrentPlayer.IsResurrected = false;

                    CurrentBattle.UpdateStats();
                    game.BattleScreen.DisplayScreen();

                    if (CurrentBattle.ParryAttempted == false)
                    {
                        CurrentBattle.NewTurn();
                    }

                    if (CurrentBattle.Turn == "Player")
                    {
                        CurrentBattle.ParryAttempted = false;
                        game.BattleScreen.ExecuteChoice();
                    }
                    else
                    {
                        CurrentBattle.Monster.Attack(CurrentBattle.Player);
                        CurrentBattle.AppendBattleLogItem();
                    }
                }

            if (CurrentBattle.BattleStatus == true && CheckIfDead(game.BattleService.CurrentBattle.Player, game.BattleService.CurrentBattle.Monster) == true)
            {
                game.BattleScreen.DisplayScreen();

                if (game.CurrentPlayer.HealthPercentage == 0)
                {
                    CurrentBattle.BattleLog.Add($">> {game.CurrentPlayer.Name} perishes into the ground...");
                }
                else
                {
                    CurrentBattle.BattleLog.Add($">> {CurrentBattle.Monster.Name} perishes into the ground...");
                    CurrentBattle.Monster.DropLoot(CurrentBattle);
                }

                game.BattleScreen.DisplayScreen();
                System.Threading.Thread.Sleep(3000);

                game.BattleEnd.DisplayScreen();
            }
        }

        internal bool CheckIfDead(Player player, Monster monster)
        {
            if (player.HealthPercentage <= 0 || monster.HealthPercentage <= 0) return true;
            else return false;
        }
    }
}
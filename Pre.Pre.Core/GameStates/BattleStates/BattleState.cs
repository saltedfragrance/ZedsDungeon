using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.GameFunctionality;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class BattleState : State
    {
        internal BattleState(GameService game) : base(game)
        {
            Title = CurrentGame.AsciiArt.Battle;
            MenuOptions = CurrentGame.MenusRepository.BattleMenu;
        }

        internal override void DisplayScreen()
        {
            CurrentGame.DisplayService.DisplayTitle(Title);
            CurrentGame.DisplayService.PageDivider();
            PrintBattleStats();
            
            CurrentGame.DisplayService.Write($"{string.Join("\n", CurrentGame.BattleService.CurrentBattle.BattleLog.Cast<string>())}");

            CurrentGame.DisplayService.WriteMenu(MenuOptions);
        }

        internal override void ExecuteChoice()
        {
            ChosenValue = CurrentGame.DisplayService.AskMenu(1, 5);

            CurrentGame.BattleService.CurrentBattle.BattleLog.Clear();

            switch (ChosenValue)
            {
                case 1:
                    CurrentGame.BattleService.CurrentBattle.Player.Attack(CurrentGame.BattleService.CurrentBattle.Monster);
                    CurrentGame.BattleService.CurrentBattle.AppendBattleLogItem();
                    break;
                case 2:
                    CurrentGame.BattleService.CurrentBattle.Player.ParryAttempt(CurrentGame.BattleService.CurrentBattle.Monster);
                    CurrentGame.BattleService.CurrentBattle.AppendBattleLogItem();
                    break;
                case 3:
                    CurrentGame.Inventory.DisplayScreen();
                    break;
                case 4:
                    CurrentGame.EscapeState.DisplayScreen();
                    break;
            }
        }

        internal void PrintBattleStats()
        {
            for (int i = 0; i < CurrentGame.BattleService.CurrentBattle.Stats.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGame.BattleService.CurrentBattle.Stats.GetLength(1); j++)
                {
                    Console.Write("\t\t\t     >> {0}", CurrentGame.BattleService.CurrentBattle.Stats[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            CurrentGame.BattleService.CurrentBattle.UpdateStats();
        }

    }
}

using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class BattleEndState : State
    {
        internal string[] MenuOptionsGameOver { get; }

        internal BattleEndState(GameService game) : base(game)
        {
            MenuOptions = CurrentGame.MenusRepository.VictoriousBattleEndMenu;
            MenuOptionsGameOver = CurrentGame.MenusRepository.DefeatBattleEndMenu;
        }

        internal override void DisplayScreen()
        {
            if (CurrentGame.CurrentPlayer.HealthPercentage == 0)
            {
                CurrentGame.DisplayService.DisplayTitle(CurrentGame.AsciiArt.YouDied);
                CurrentGame.DisplayService.WriteMenu(MenuOptionsGameOver);
            }
            else
            {
                if (CurrentGame.CurrentPlayer.IsResurrected == true)
                {
                    CurrentGame.DisplayService.DisplayTitle(CurrentGame.AsciiArt.Resurrected);
                    CurrentGame.DisplayService.PageDivider();
                    CurrentGame.DisplayService.Write($"You've successfully risen back from the dead! You can now continue the story.");
                }
                else
                {
                    CurrentGame.DisplayService.DisplayTitle(CurrentGame.AsciiArt.Victory);
                    CurrentGame.DisplayService.PageDivider();
                    CurrentGame.DisplayService.Write($"You've successfully beaten the wretched {CurrentGame.BattleService.CurrentBattle.Monster.Name}!\n\n" +
                                      $"You've looted the following items from its corpse:\n\n" +
                                      $"{string.Join("\n", CurrentGame.BattleService.CurrentBattle.Loot.Select(l => l.Name).ToArray())}");
                }
                CurrentGame.DisplayService.WriteMenu(MenuOptions);
            }
            ExecuteChoice();
        }

        internal override void ExecuteChoice()
        {
            ChosenValue = CurrentGame.DisplayService.AskMenu(1, 2);

            if (CurrentGame.CurrentPlayer.HealthPercentage <= 0)
            {
                switch (ChosenValue)
                {
                    case 1:
                        CurrentGame.CurrentPlayer = null;
                        CurrentGame.BattleService.CurrentBattle = null;
                        CurrentGame.MainMenu.DisplayScreen();
                        break;
                    case 2:
                        CurrentGame.Inventory.DisplayScreen();
                        break;
                }
            }
            else
            {
                switch (ChosenValue)
                {
                    case 1:
                        CurrentGame.BattleService.CurrentBattle.BattleStatus = false;
                        break;
                    case 2:
                        CurrentGame.Inventory.DisplayScreen();
                        break;
                }
            }
        }
    }
}

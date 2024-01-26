using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class InventoryState : State
    {
        internal InventoryState(GameService game) : base(game)
        {
            MenuOptions = CurrentGame.MenusRepository.InventoryMenu;
            Title = CurrentGame.AsciiArt.Inventory;
        }

        internal override void DisplayScreen()
        {
            CurrentGame.DisplayService.DisplayTitle(Title);
            CurrentGame.DisplayService.PageDivider();

            if (CurrentGame.CurrentPlayer.Inventory.Items.Count() != 0) CurrentGame.CurrentPlayer.Inventory.ShowInventory(CurrentGame.CurrentPlayer.Inventory);
            else
            {
                CurrentGame.DisplayService.Write("Your inventory is empty!");
                CurrentGame.CurrentPlayer.Inventory.ItemCategories.Clear();
            }

            CurrentGame.DisplayService.Write($"\n{string.Join("\n", CurrentGame.CurrentPlayer.Inventory.InventoryLog.Cast<string>())}");
            CurrentGame.DisplayService.WriteMenu(MenuOptions);

            ExecuteChoice();
        }

        internal override void ExecuteChoice()
        {
            int numberOfItems = CurrentGame.CurrentPlayer.Inventory.ItemCategories.Count();
            ChosenValue = CurrentGame.DisplayService.AskMenu(0, numberOfItems);

            if (ChosenValue == 0)
            {
                CurrentGame.CurrentPlayer.Inventory.InventoryLog.Clear();
                if (CurrentGame.CurrentPlayer.IsResurrected == true) CurrentGame.BattleEnd.DisplayScreen();
                if (CurrentGame.BattleService.CurrentBattle.BattleStatus == true &&
                        (CurrentGame.CurrentPlayer.HealthPercentage <= 0 || CurrentGame.BattleService.CurrentBattle.Monster.HealthPercentage <= 0)) CurrentGame.BattleEnd.DisplayScreen();
            }
            else
            {
                Item toUse = CurrentGame.CurrentPlayer.Inventory.Items.Find(i => ChosenValue + i.Name == CurrentGame.CurrentPlayer.Inventory.ItemCategories.Find(c => c == ChosenValue + i.Name));

                if (toUse != null)
                {
                    try
                    {
                        CurrentGame.CurrentPlayer.Use(toUse);
                        CurrentGame.CurrentPlayer.Inventory.AppendInventoryLogItem(null, toUse);
                    }
                    catch (Exception ex)
                    {
                        CurrentGame.CurrentPlayer.Inventory.AppendInventoryLogItem(ex.Message.ToString());
                    }
                }
                DisplayScreen();
            }
        }
    }
}

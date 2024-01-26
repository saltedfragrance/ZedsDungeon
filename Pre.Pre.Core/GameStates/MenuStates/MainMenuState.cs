using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class MainMenuState : State
    {
        internal MainMenuState(GameService game) : base(game)
        {
            MenuOptions = CurrentGame.MenusRepository.MainMenu;
            Title = CurrentGame.AsciiArt.MainMenuArt;
        }

        internal override void ExecuteChoice()
        {
            ChosenValue = CurrentGame.DisplayService.AskMenu(1, 4);

            switch (ChosenValue)
            {
                case 1:
                    CurrentGame.PremadeCharacterSelection.DisplayScreen();
                    break;
                case 2:
                    CurrentGame.CustomCharacterSelection.DisplayScreen();
                    break;
                case 3:
                    CurrentGame.CreditsState.DisplayScreen();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

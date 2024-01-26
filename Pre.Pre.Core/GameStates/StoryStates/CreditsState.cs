using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class CreditsState : State
    {
        internal CreditsState(GameService game) : base(game)
        {
            Title = CurrentGame.AsciiArt.Credits;
            MenuOptions = CurrentGame.MenusRepository.CreditsMenu;
        }

        internal override void DisplayScreen()
        {
            CurrentGame.DisplayService.DisplayTitle(Title);
            CurrentGame.DisplayService.PageDivider();

            string credits = $"Game made by: Stijn Vandekerckhove\n" +
                             $"Ascii art source: https://patorjk.com/software/taag/";

            if (CurrentGame.CurrentPlayer != null)
            {
                Prompt = $"You've finished the game and escaped the dungeon! Congratulations.\n\n" + credits;
            }
            else Prompt = credits;

            CurrentGame.DisplayService.Write(Prompt);
            CurrentGame.DisplayService.WriteMenu(MenuOptions);

            ExecuteChoice();
        }

        internal override void ExecuteChoice()
        {
            ChosenValue = CurrentGame.DisplayService.AskMenu(1, 2);

            switch (ChosenValue)
            {
                case 1:
                    CurrentGame.CurrentPlayer = null;
                    CurrentGame.MainMenu.DisplayScreen();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
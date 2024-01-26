using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class BattleIntroState : State
    {
        internal BattleIntroState(GameService game) : base(game)
        {
            MenuOptions = CurrentGame.MenusRepository.BattleIntroMenu;
            Title = CurrentGame.AsciiArt.Fight;
        }

        internal override void DisplayScreen()
        {
            Random random = new Random();

            CurrentGame.DisplayService.DisplayTitle(Title);
            CurrentGame.DisplayService.Write(CurrentGame.BattleIntros.BattleIntros.ElementAt(random.Next(CurrentGame.BattleIntros.BattleIntros.Count)));
            CurrentGame.DisplayService.WriteMenu(MenuOptions);

            ExecuteChoice();
        }

        internal override void ExecuteChoice()
        {
            ChosenValue = CurrentGame.DisplayService.AskMenu(1, 2);

            switch (ChosenValue)
            {
                case 1:
                    CurrentGame.BattleService.DoBattle(CurrentGame);
                    break;
                case 2:
                    CurrentGame.EscapeState.DisplayScreen();
                    break;
            }
        }
    }
}


using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal abstract class CharacterCreation : State
    {
        internal PlayerClass ChosenClass { get; set; }

        internal CharacterCreation(GameService game) : base(game)
        {
            MenuOptions = CurrentGame.MenusRepository.ClassSelectionMenu;
            Title = CurrentGame.AsciiArt.CharacterCreation;
        }

        internal override void ExecuteChoice()
        {
            string playerName;

            do
            {
                try
                {
                    playerName = CurrentGame.DisplayService.AskQuestionCenter("What name do you wish to give your adventurer?");
                    CurrentGame.CurrentPlayer = new Player(playerName, ChosenClass, null);
                }
                catch (Exception ex)
                {
                    CurrentGame.DisplayService.Write(ex.Message.ToString());
                }

            } while (CurrentGame.CurrentPlayer == null);

            CurrentGame.CharacterIntroState.DisplayScreen();

            CurrentGame.Story.DisplayScreen();
        }
    }
}


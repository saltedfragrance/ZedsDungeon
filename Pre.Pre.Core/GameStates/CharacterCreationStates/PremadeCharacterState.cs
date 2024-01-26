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
    internal class PremadeCharacterState : CharacterCreation
    {
        internal PremadeCharacterState(GameService game) : base(game) { }

        internal override void ExecuteChoice()
        {
            PlayerClass chosenClass = null;

            ChosenValue = CurrentGame.DisplayService.AskMenu(1, 3, "What class do you wish to play?");

            switch (ChosenValue)
            {
                case 1:
                    chosenClass = CurrentGame.PlayerClasses.GetPlayerClasses().First(C => C.Name == "Knight");
                    break;
                case 2:
                    chosenClass = CurrentGame.PlayerClasses.GetPlayerClasses().First(C => C.Name == "Wizard");
                    break;
                case 3:
                    chosenClass = CurrentGame.PlayerClasses.GetPlayerClasses().First(C => C.Name == "Warrior");
                    break;
            }

            ChosenClass = chosenClass;

            base.ExecuteChoice();
        }
    }
}



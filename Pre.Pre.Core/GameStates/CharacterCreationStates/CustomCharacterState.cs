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
    internal class CustomCharacterState : CharacterCreation
    {
        private int pointsToDistribute;
        private int PointsToDistribute
        {
            get { return pointsToDistribute; }
            set
            {
                if (value < 0) throw new Exception($"You can't allocate this many points. You have {PointsToDistribute} left.");

                pointsToDistribute = value;
            }
        }

        private string className;
        private string ClassName
        {
            get { return className; }
            set
            {
                if (value.All(char.IsDigit)) { throw new Exception("Name can't contain any numbers."); }
                else if (value.Length > 20) { throw new Exception("Name is limited to 15 characters."); }
                else if (value.Length < 2) { throw new Exception("Name should be at least 2 characters."); }
                else className = value;
            }
        }

        internal CustomCharacterState(GameService game) : base(game)
        {
            PointsToDistribute = 50;
        }

        internal override void DisplayScreen()
        {
            CurrentGame.DisplayService.DisplayTitle(Title);
            ExecuteChoice();
        }

        internal override void ExecuteChoice()
        {
            int attackPower = 0;
            int defendPower = 0;
            int parryPower = 0;

            do
            {
                try
                {
                    if (ClassName == null) ClassName = CurrentGame.DisplayService.AskQuestionCenter("What name do you wish to give this custom class?\n\n");

                    if (attackPower == 0)
                    {
                        CurrentGame.DisplayService.Write($"You have {PointsToDistribute} left.\n");
                        attackPower = CurrentGame.DisplayService.AskValueCenter($"You have {PointsToDistribute } points left.\n\nChoose a number between 0 and {PointsToDistribute} for your character's attack power.", 0, pointsToDistribute);
                        PointsToDistribute -= attackPower;
                    }

                    if (defendPower == 0)
                    {
                        CurrentGame.DisplayService.Write($"You have {PointsToDistribute} left.\n");
                        defendPower = CurrentGame.DisplayService.AskValueCenter($"You have {PointsToDistribute } points left.\n\nChoose a number between 0 and {PointsToDistribute} for your character's defence power.", 0, pointsToDistribute);
                        PointsToDistribute -= defendPower;
                    }

                    if (parryPower == 0)
                    {
                        CurrentGame.DisplayService.Write($"You have {PointsToDistribute} left.\n");
                        parryPower = CurrentGame.DisplayService.AskValueCenter($"You have {PointsToDistribute } points left.\n\nChoose a number between 0 and {PointsToDistribute} for your character's parry power.", 0, pointsToDistribute);
                        PointsToDistribute -= parryPower;
                    }

                    ChosenClass = new PlayerClass(ClassName, attackPower, defendPower, parryPower, "Custom");
                }
                catch (Exception ex)
                {
                    CurrentGame.DisplayService.WriteCenter(ex.Message.ToString());
                }
            } while (ChosenClass == null);
            base.ExecuteChoice();
        }
    }
}

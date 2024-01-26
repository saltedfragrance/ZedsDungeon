using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class EscapeState : State
    {
        internal EscapeState(GameService game) : base(game) { }

        internal override void DisplayScreen()
        {
            if (CurrentGame.BattleService.CurrentBattle.Monster.MonsterType != "Boss")
            {
                Prompt = $"WAAAAAAAAAAAAAAAAAAAAARGHL!!! The wretched {CurrentGame.BattleService.CurrentBattle.Monster.Name} screams at you while you cunningly evade its attacks and run down\nthe corridor!!! " +
                               "The monster chases you for a while, but you manage to outrun it. You hide in a cupboard\nfor a while.\n\n" +
                               "Eventually, the monster is gone and you continue on further down the dungeon...";

                CurrentGame.DisplayService.WriteCenter(Prompt);
                CurrentGame.BattleService.CurrentBattle.BattleStatus = false;
            }
            else
            {
                Prompt = "Sorry, you can't escape a Boss fight! You'll have to fight this monster.";

                CurrentGame.DisplayService.WriteCenter(Prompt);
                CurrentGame.BattleService.DoBattle(CurrentGame);
            }
        }
    }
}


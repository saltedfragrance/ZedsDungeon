using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates.CharacterCreationStates
{
    internal class CharacterIntroState : State
    {
        internal CharacterIntroState(GameService game) : base(game) { }

        internal override void DisplayScreen()
        {
            CurrentGame.DisplayService.DisplayTitle(Title);

            string introText = $"Welcome to Zed's Dungeon, {CurrentGame.CurrentPlayer.Name}, you will be playing as a {CurrentGame.CurrentPlayer.PlayerClass}!\n\n" +
                             $"Starter weapon: {CurrentGame.CurrentPlayer.Weapon.Name} ({CurrentGame.CurrentPlayer.Weapon.StatsBonus}+ attack power bonus).\n\n" +
                             $"Attack Power: {CurrentGame.CurrentPlayer.PlayerClass.AttackPower}\n" +
                             $"Defence Power: {CurrentGame.CurrentPlayer.PlayerClass.DefendPower}\n" +
                             $"Parry Power: {CurrentGame.CurrentPlayer.PlayerClass.ParryPower}\n\n" +
                             $"You'll start with the following items in your inventory:\n" +
                             $"{CurrentGame.CurrentPlayer.Inventory.Items[0].Name}: {CurrentGame.CurrentPlayer.Inventory.Items[0].Description}\n" +
                             $"{CurrentGame.CurrentPlayer.Inventory.Items[1].Name}: {CurrentGame.CurrentPlayer.Inventory.Items[0].Description}\n";

            CurrentGame.DisplayService.WriteCenter(introText);;
            CurrentGame.Story.DisplayScreen();
        }
    }
}

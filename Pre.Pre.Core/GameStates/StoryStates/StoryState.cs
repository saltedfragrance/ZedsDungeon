using Pre.Pre.Core.GameStates;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal class StoryState : State
    {
        internal StoryService storyService;

        internal StoryState(GameService game) : base(game)
        {
            storyService = new StoryService();
        }

        internal override void DisplayScreen()
        {
            storyService.Intro(CurrentGame);
            storyService.Dungeon(CurrentGame);
            CurrentGame.CreditsState.DisplayScreen();
        }
    }
}
using Pre.Pe2.Cons;
using Pre.Pe2.Cons.DataRepositories;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameStates
{
    internal abstract class State
    {
        protected int ChosenValue { get; set; }

        protected GameService CurrentGame { get; }

        protected string Title { get; set; }

        protected string[] MenuOptions { get; set; }

        protected string Prompt { get; set; }

        protected State(GameService game)
        {
            CurrentGame = game;
        }

        internal virtual void DisplayScreen()
        {
            CurrentGame.DisplayService.DisplayTitle(Title);
            CurrentGame.DisplayService.WriteMenu(MenuOptions);
            ExecuteChoice();
        }

        internal virtual void ExecuteChoice() { }
    }
}
using Pre.Pe2.Cons;
using Pre.Pe2.Cons.DataRepositories;
using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.Services;
using Pre.Pre.Core.Art;
using Pre.Pre.Core.DataRepositories;
using Pre.Pre.Core.GameStates;
using Pre.Pre.Core.GameStates.CharacterCreationStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.Services
{
    public class GameService
    {
        internal Player CurrentPlayer { get; set;  }

        internal MainMenuState MainMenu { get; }
        internal PremadeCharacterState PremadeCharacterSelection { get; }
        internal CustomCharacterState CustomCharacterSelection { get; }
        internal CharacterIntroState CharacterIntroState { get; }
        internal StoryState Story { get; }
        internal BattleState BattleScreen { get; }
        internal BattleIntroState BattleIntro { get; }
        internal BattleEndState BattleEnd { get; }
        internal InventoryState Inventory { get; }
        internal CreditsState CreditsState { get; }
        internal EscapeState EscapeState { get; }

        internal ItemsRepository Items { get; }
        internal MonsterRepository Monsters { get; }
        internal BattleIntroRepository BattleIntros { get; }
        internal PlayerClassRepository PlayerClasses { get; }
        internal AsciiArt AsciiArt { get; set; }
        internal StoryRepository StoryRepository { get; }
        internal MenusRepository MenusRepository { get; }

        internal BattleService BattleService { get; }
        internal DisplayService DisplayService { get; }

        public GameService()
        {
            CurrentPlayer = null;

            Items = new ItemsRepository();
            Monsters = new MonsterRepository();
            BattleIntros = new BattleIntroRepository();
            PlayerClasses = new PlayerClassRepository();
            AsciiArt = new AsciiArt();
            StoryRepository = new StoryRepository();
            MenusRepository = new MenusRepository();
            BattleService = new BattleService();
            DisplayService = new DisplayService();

            MainMenu = new MainMenuState(this);
            PremadeCharacterSelection = new PremadeCharacterState(this);
            CustomCharacterSelection = new CustomCharacterState(this);
            Story = new StoryState(this);
            Inventory = new InventoryState(this);
            BattleIntro = new BattleIntroState(this);
            BattleScreen = new BattleState(this);
            BattleEnd = new BattleEndState(this);
            CreditsState = new CreditsState(this);
            EscapeState = new EscapeState(this);
            CharacterIntroState = new CharacterIntroState(this);

            StartGame();
        }

        public void StartGame()
        {
            MainMenu.DisplayScreen();
        }
    }
}


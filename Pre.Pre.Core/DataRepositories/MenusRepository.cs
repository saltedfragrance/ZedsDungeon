using Pre.Pe2.Cons.Entities;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.DataRepositories
{
    internal class MenusRepository
    {
        internal string[] MainMenu { get; private set; }

        internal string[] BattleMenu { get; private set; }

        internal string[] ClassSelectionMenu { get; private set; }

        internal string[] InventoryMenu { get; private set; }

        internal string[] VictoriousBattleEndMenu { get; private set; }

        internal string[] DefeatBattleEndMenu { get; private set; }

        internal string[] BattleIntroMenu { get; private set; }

        internal string[] CreditsMenu { get; private set; }

        internal MenusRepository()
        {
            PopulateMenus();
        }

        private void PopulateMenus()
        {
            MainMenu = new string[] { "[1] Choose a premade character", "[2] Create your own character", "[3] Credits", "[4] Exit game", };
            BattleMenu = new string[] { "[1] Attack", "[2] Attempt to parry", "[3] Inventory (Entering the inventory takes up your turn!)", "[4] Try to Escape (Attempting to escape takes up your turn!" };
            ClassSelectionMenu = new string[]     {
                                                    $"[1] Knight - Attack skills: mediocre, Defence skills: superb, Evade skills: poor",
                                                    $"[2] Wizard - Attack skills: superb, Defence skills: poor, Parry skills: mediocre",
                                                    $"[3] Warrior - Attack skills: Good, Defence skills: mediocre, Evade skills: good"
                                                  };
            InventoryMenu = new string[] { "[X] Enter number of item to consume or equip", "[0] Back to previous menu" };

            VictoriousBattleEndMenu = new string[] { "[1] Continue story", "[2] Show Inventory. Replenish health and armor before the next battle!" };

            DefeatBattleEndMenu = new string[] { "[1] Restart Game", "[2] Inventory (resurrect yourself if you have a Resurrect potion!)" };

            BattleIntroMenu = new string[] { "[1] Fight", "[2] Try to Escape" };

            CreditsMenu = new string[] { "[1] Main Menu (Start a new game)", "[2] Exit game" };
        }
    }
}

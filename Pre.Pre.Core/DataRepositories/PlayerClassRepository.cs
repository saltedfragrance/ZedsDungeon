using Pre.Pe2.Cons.Enums;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.GameProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.DataRepositories
{
    internal class PlayerClassRepository
    {
        internal IEnumerable<PlayerClass> GetPlayerClasses()
        {
            return new List<PlayerClass>
            {
                new PlayerClass(Classes.Knight.ToString(), 25, 50, 15, "Premade"),

                new PlayerClass(Classes.Wizard.ToString(), 50, 15, 25, "Premade"),

                new PlayerClass(Classes.Warrior.ToString(), 35, 30, 40, "Premade")
            };
        }
    }
}

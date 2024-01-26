using Pre.Pe2.Cons.Enums;
using Pre.Pe2.Cons.GameProps;
using Pre.Pre.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameProps.Wearables
{
    internal abstract class Wearable : Item
    {
        internal Classes PlayerClass { get; private set; }

        internal Wearable(int statsBonus, string name, string description, Tiers tier, Classes playerClass) : base(statsBonus, name, description, tier)
        {
            PlayerClass = playerClass;
        }
    }
}

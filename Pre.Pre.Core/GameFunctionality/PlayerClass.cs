using Pre.Pre.Core.GameProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.GameProps
{
    internal class PlayerClass
    {
        internal string Name { get; private set; }
        internal string Type { get; private set; }
        internal int AttackPower { get; private set; }
        internal int DefendPower { get; private set; }
        internal int ParryPower { get; private set; }

        internal PlayerClass(string name, int attackPower, int defendPower, int parryPower, string type)
        {
            Name = name;
            AttackPower = attackPower;
            DefendPower = defendPower;
            ParryPower = parryPower;
            Type = type;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

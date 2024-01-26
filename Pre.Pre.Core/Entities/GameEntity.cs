using Pre.Pe2.Cons.DataRepositories;
using Pre.Pe2.Cons.GameProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.Entities
{
    internal abstract class GameEntity
    {
        protected ItemsRepository itemsRepository = new ItemsRepository();

        protected static Random random = new Random();

        internal struct DamageReport
        {
            internal bool attackParried;
            internal int armorDamageDealt;
            internal int healthDamageDealt;

        }

        private string name;

        internal string Name
        {
            get { return name; }
            private set
            {
                if (value.All(char.IsDigit)) { throw new Exception("Name can't contain any numbers."); }
                else if (value.Length > 20) { throw new Exception("Name is limited to 15 characters."); }
                else if (value.Length < 2) { throw new Exception("Name should be at least 2 characters."); }
                else name = value;
            }
        }

        internal int AttackPower { get; set; }
        internal int DefendPower { get; set; }
        internal int ParryPower { get; private set; }

        internal int HealthPercentage { get; set; }
        internal int ArmorPercentage { get; set; }

        internal Inventory Inventory { get; set; }

        internal DamageReport Report { get; private set; }

        protected GameEntity(string name, int attackPower, int defendPower, int parryPower,
            int healthPercentage, int armorPercentage)
        {
            Name = name;
            HealthPercentage = healthPercentage;
            ArmorPercentage = armorPercentage;
            AttackPower = attackPower;
            DefendPower = defendPower;
            ParryPower = parryPower;
        }

        internal abstract void SetInventory(GameEntity gameEntity = null);

        internal void Attack(GameEntity gameEntity)
        {
            bool parrySuccess;
            int remainingAttackPower;
            int initialArmor = gameEntity.ArmorPercentage;
            int initialHealth = gameEntity.HealthPercentage;
            int remainingArmor = gameEntity.ArmorPercentage;
            int remainingHealth = gameEntity.HealthPercentage;

            parrySuccess = CalculateParrySuccess(gameEntity);

            if (parrySuccess == true)
            {
                Report = new DamageReport()
                {
                    attackParried = true
                };
                return;
            }

            switch (remainingArmor, remainingHealth)
            {
                case ( > 0, > 0):
                    if (remainingArmor < AttackPower)
                    {
                        remainingAttackPower = (AttackPower - remainingArmor);
                        remainingArmor = 0;

                        if (remainingAttackPower < remainingHealth) remainingHealth -= remainingAttackPower;
                        else remainingHealth = 100;
                    }
                    else
                        remainingArmor -= (AttackPower - (gameEntity.DefendPower / 5));
                    break;
                case (0, > 0):
                    if (remainingHealth < AttackPower)
                    {
                        remainingHealth = 0;
                    }
                    else remainingHealth -= AttackPower;
                    break;
            }

            gameEntity.ArmorPercentage = remainingArmor;
            gameEntity.HealthPercentage = remainingHealth;

            Report = new DamageReport()
            {
                armorDamageDealt = initialArmor - remainingArmor,
                healthDamageDealt = initialHealth - remainingHealth
            };
        }

        private bool CalculateParrySuccess(GameEntity gameEntity)
        {
            if (random.Next(1, 101) <= (int)gameEntity.ParryPower) return true;
            else return false;
        }
    }
}

using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot a fire bolt that does 9d8 damage.
    /// </summary>
    [Serializable]
    internal class BoFire1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It is covered in fire...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(8) + 8;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBolt(new ProjectFire(saveGame), direction, Program.Rng.DiceRoll(9, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "fire bolt (9d8) every 8+d8 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}

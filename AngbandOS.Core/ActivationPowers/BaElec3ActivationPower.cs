using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a lightning storm that does 250 damage with a larger radius.
    /// </summary>
    [Serializable]
    internal class BaElec3ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 50;

        public override string PreActivationMessage => "It glows deep blue...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(425) + 425;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBall(new ProjectElec(), direction, 250, 3);
            return true;
        }

        public override int Value => 2500;

        public override string Description => "ball of lightning (250) every 425+d425 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}

using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot a fire ball that does 120 damage with a larger radius.
    /// </summary>
    [Serializable]
    internal class BaFire2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It glows deep red...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(225) + 225;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            SaveGame.Instance.FireBall(new ProjectFire(), direction, 120, 3);
            return true;
        }

        public override int Value => 1750;

        public override string Description => "fire ball (120) every 225+d225 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResNexus;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}

using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Shoot an arrow that does 150 damage.
    /// </summary>
    [Serializable]
    internal class BoMiss2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It grows magical spikes...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(90) + 90;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.SpellEffects.FireBolt(new ProjectArrow(SaveGame.Instance.SpellEffects), direction, 150);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "arrows (150) every 90+d90 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}

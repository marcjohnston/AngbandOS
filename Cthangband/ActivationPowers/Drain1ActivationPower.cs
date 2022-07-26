using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Drain up to 100 life from an opponent.  This particular drain life is unique, in that, if the power doesn't affect a monster, it doesn't need to be recharged.
    /// </summary>
    [Serializable]
    internal class Drain1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows black...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(100) + 100;

        protected override bool Activate(Player player, Level level, int direction)
        {
            return SaveGame.Instance.SpellEffects.DrainLife(direction, 100);
        }

        public override int Value => 500;

        public override string Description => "drain life (100) every 100+d100 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}

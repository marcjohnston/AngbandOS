using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Drain up to 120 life from an opponent.
    /// </summary>
    [Serializable]
    internal class Drain2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It glows black...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.SpellEffects.DrainLife(direction, 120);
            return true;
        }

        public override int Value => 750;

        public override string Description => "drain life (120) every 400 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

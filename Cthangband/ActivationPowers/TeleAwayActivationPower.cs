using Cthangband.Enumerations;
using Cthangband.Projection;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Teleport away an opponent.
    /// </summary>
    [Serializable]
    internal class TeleAwayActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 200;

        protected override bool Activate(Player player, Level level, int direction)
        {
            SaveGame.Instance.FireBeam(new ProjectAwayAll(), direction, player.Level);
            return true;
        }

        public override int Value => 2000;

        public override string Description => "teleport away every 200 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResBlind;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}

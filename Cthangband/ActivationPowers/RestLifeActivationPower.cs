using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Restore lost experience.
    /// </summary>
    [Serializable]
    internal class RestLifeActivationPower : ActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It glows a deep red...";

        public override bool Activate(Player player, Level level, Item item)
        {
            player.RestoreLevel();
            return true;
        }

        public override int RechargeTime(Player player) => 450;

        public override int Value => 7500;

        public override string Description => "restore life levels every 450 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}

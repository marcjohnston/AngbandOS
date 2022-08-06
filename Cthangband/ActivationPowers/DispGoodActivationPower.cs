using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Dispel good with a strength of x5.
    /// </summary>
    [Serializable]
    internal class DispGoodActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It floods the area with evil...";

        public override bool Activate(Player player, Level level)
        {
            SaveGame.Instance.DispelGood(player.Level * 5);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(300) + 300;

        public override int Value => 3500;

        public override string Description => "dispel good (level*5) every 300+d300 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}

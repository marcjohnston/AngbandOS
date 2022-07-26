using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Give us temporary etherealness.
    /// </summary>
    [Serializable]
    internal class WraithActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level, Item item)
        {
            player.SetTimedEtherealness(player.TimedEtherealness + Program.Rng.DieRoll(player.Level / 2) + (player.Level / 2));
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 25000;

        public override string Description => "wraith form (level/2 + d(level/2)) every 1000 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResDark;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}

using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Give us extra haste for a long time.
    /// </summary>
    [Serializable]
    internal class XtraSpeedActivationPower : ActivationPower
    {
        public override int RandomChance => 10;

        public override string PreActivationMessage => "It glows brightly...";

        public override bool Activate(Player player, Level level)
        {
            if (player.TimedHaste == 0)
            {
                player.SetTimedHaste(Program.Rng.DieRoll(75) + 75);
            }
            else
            {
                player.SetTimedHaste(player.TimedHaste + 5);
            }
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(200) + 200;

        public override int Value => 25000;

        public override string Description => "speed (dur 75+d75) every 200+d200 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResPois;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}

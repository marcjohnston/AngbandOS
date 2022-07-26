using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Give us temporary haste.
    /// </summary>
    [Serializable]
    internal class SpeedActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows bright green...";

        public override bool Activate(Player player, Level level, Item item)
        {
            if (player.TimedHaste == 0)
            {
                player.SetTimedHaste(Program.Rng.DieRoll(20) + 20);
            }
            else
            {
                player.SetTimedHaste(player.TimedHaste + 5);
            }
            return true;
        }

        public override int RechargeTime(Player player) => 250;

        public override int Value => 15000;

        public override string Description => "speed (dur 20+d20) every 250 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag2.HoldLife;
    }
}

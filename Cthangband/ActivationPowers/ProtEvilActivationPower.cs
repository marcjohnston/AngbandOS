using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Give us protection from evil.
    /// </summary>
    [Serializable]
    internal class ProtEvilActivationPower : ActivationPower
    {
        public override int RandomChance => 75;

        public override string PreActivationMessage => "It lets out a shrill wail...";

        public override bool Activate(Player player, Level level, Item item)
        {
            int k = 3 * player.Level;
            player.SetTimedProtectionFromEvil(player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + k);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(225) + 225;

        public override int Value => 5000;

        public override string Description => "protect evil (dur level*3 + d25) every 225+d225 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResNexus;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

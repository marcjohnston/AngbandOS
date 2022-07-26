using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Give us temporary resistance to the basic elements.
    /// </summary>
    [Serializable]
    internal class ResistAllActivationPower : ActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows many colours...";

        public override bool Activate(Player player, Level level)
        {
            player.SetTimedAcidResistance(player.TimedAcidResistance + Program.Rng.DieRoll(40) + 40);
            player.SetTimedLightningResistance(player.TimedLightningResistance + Program.Rng.DieRoll(40) + 40);
            player.SetTimedFireResistance(player.TimedFireResistance + Program.Rng.DieRoll(40) + 40);
            player.SetTimedColdResistance(player.TimedColdResistance + Program.Rng.DieRoll(40) + 40);
            player.SetTimedPoisonResistance(player.TimedPoisonResistance + Program.Rng.DieRoll(40) + 40);
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 5000;

        public override string Description => "resist elements (dur 40+d40) every 200 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResChaos;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}

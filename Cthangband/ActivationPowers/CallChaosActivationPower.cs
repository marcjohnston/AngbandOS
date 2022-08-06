using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Activate the Call Chaos spell.
    /// </summary>
    [Serializable]
    internal class CallChaosActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows in scintillating colours...";

        public override int RechargeTime(Player player) => 350;

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.CallChaos();
            return true;
        }

        public override int Value => 5000;

        public override string Description => "call chaos every 350 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

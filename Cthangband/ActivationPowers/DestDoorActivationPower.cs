using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Destroy nearby doors.
    /// </summary>
    [Serializable]
    internal class DestDoorActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It glows bright red...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.DestroyDoorsTouch();
            return true;
        }

        public override int RechargeTime(Player player) => 10;

        public override int Value => 100;

        public override string Description => "destroy doors every 10 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag3.Feather;
    }
}

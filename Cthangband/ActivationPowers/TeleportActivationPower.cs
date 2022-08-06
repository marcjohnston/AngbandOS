using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Long range teleport.
    /// </summary>
    [Serializable]
    internal class TeleportActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It twists space around you...";

        public override bool Activate(Player player, Level level)
        {
            SaveGame.Instance.TeleportPlayer(100);
            return true;
        }

        public override int RechargeTime(Player player) => 45;

        public override int Value => 2000;

        public override string Description => "teleport (range 100) every 45 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

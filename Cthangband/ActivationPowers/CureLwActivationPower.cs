using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Heal 30 health and remove fear.
    /// </summary>
    [Serializable]
    internal class CureLwActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level)
        {
            player.SetTimedFear(0);
            player.RestoreHealth(30);
            return true;
        }

        public override int RechargeTime(Player player) => 10;

        public override int Value => 500;

        public override string Description => "remove fear & heal 30 hp every 10 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}

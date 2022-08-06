using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Mass carnage creatures near the player.
    /// </summary>
    [Serializable]
    internal class MassGenoActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It lets out a long, shrill note...";

        public override bool Activate(Player player, Level level)
        {
            SaveGame.Instance.MassCarnage(true);
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 10000;

        public override string Description => "mass carnage every 1000 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}

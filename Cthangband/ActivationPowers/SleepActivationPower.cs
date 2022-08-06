using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Activate sleep on touch.
    /// </summary>
    [Serializable]
    internal class SleepActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It glows deep blue...";

        public override int RechargeTime(Player player) => 55;

        public override bool Activate(Player player, Level level)
        {
            SaveGame.Instance.SleepMonstersTouch();
            return true;
        }

        public override int Value => 750;

        public override string Description => "sleep nearby monsters every 55 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCon;

        public override uint SpecialPowerFlag => ItemFlag2.ResPois;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}

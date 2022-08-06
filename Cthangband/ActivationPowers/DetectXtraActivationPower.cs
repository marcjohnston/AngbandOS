using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Detect everything and do probing and identify an item fully.
    /// </summary>
    [Serializable]
    internal class DetectXtraActivationPower : ActivationPower
    {
        public override int RandomChance => 10;

        public override string PreActivationMessage => "It glows brightly...";

        public override bool Activate(SaveGame saveGame)
        {
            SaveGame.Instance.DetectAll();
            SaveGame.Instance.Probing();
            SaveGame.Instance.IdentifyFully();
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 12500;

        public override string Description => "detection, probing and identify true every 1000 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResNether;

        public override uint SpecialAbilityFlag => ItemFlag3.SeeInvis;
    }
}

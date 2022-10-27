using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Detect everything.
    /// </summary>
    [Serializable]
    internal class DetectAllActivationPower : ActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "It glows bright white...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.MsgPrint("An image forms in your mind...");
            saveGame.DetectAll();
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(55) + 55;

        public override int Value => 1000;

        public override string Description => "detection every 55+d55 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}

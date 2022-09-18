using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Identify an item fully.
    /// </summary>
    [Serializable]
    internal class IdFullActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows yellow...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.IdentifyFully();
            return true;
        }

        public override int RechargeTime(Player player) => 750;

        public override int Value => 10000;

        public override string Description => "identify true every 750 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResNexus;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}

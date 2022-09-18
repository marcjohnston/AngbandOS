using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Carnage a chosen creature type.
    /// </summary>
    [Serializable]
    internal class CarnageActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It glows deep blue...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Carnage(true);
            return true;
        }

        public override int RechargeTime(Player player) => 500;

        public override int Value => 10000;

        public override string Description => "carnage every 500 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.Lightsource;
    }
}

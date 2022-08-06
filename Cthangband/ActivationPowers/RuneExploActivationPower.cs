using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Place a Yellow Sign.
    /// </summary>
    [Serializable]
    internal class RuneExploActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It glows a sickly yellow...";

        public override bool Activate(SaveGame saveGame)
        {
            SaveGame.Instance.YellowSign();
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 4000;

        public override string Description => "Yellow Sign every 200 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResDisen;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Turn an item to gold.
    /// </summary>
    [Serializable]
    internal class AlchemyActivationPower : ActivationPower
    {
        public override int RandomChance => 5;

        public override string PreActivationMessage => "It glows bright yellow...";

        public override bool Activate(Player player, Level level, Item item)
        {
            SaveGame.Instance.SpellEffects.Alchemy();
            return true;
        }

        public override int RechargeTime(Player player) => 500;

        public override int Value => 10000;

        public override string Description => "alchemy every 500 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResSound;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}

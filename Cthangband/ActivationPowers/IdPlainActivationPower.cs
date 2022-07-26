using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Identify an item.
    /// </summary>
    [Serializable]
    internal class IdPlainActivationPower : ActivationPower
    {
        public override int RandomChance => 75;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level, Item item)
        {
            return SaveGame.Instance.SpellEffects.IdentifyItem();
        }

        public override int RechargeTime(Player player) => 10;

        public override int Value => 1250;

        public override string Description => "identify spell every 10 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustWis;

        public override uint SpecialPowerFlag => ItemFlag2.ResChaos;

        public override uint SpecialAbilityFlag => ItemFlag3.SlowDigest;
    }
}

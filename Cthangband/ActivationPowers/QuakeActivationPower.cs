using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Cause an earthquake around the player.
    /// </summary>
    [Serializable]
    internal class QuakeActivationPower : ActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "";

        public override int RechargeTime(Player player) => 50;

        public override bool Activate(Player player, Level level, Item item)
        {
            SaveGame.Instance.SpellEffects.Earthquake(player.MapY, player.MapX, 10);
            return true;
        }

        public override int Value => 600;

        public override string Description => "earthquake (rad 10) every 50 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustCha;

        public override uint SpecialPowerFlag => ItemFlag2.ResDark;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

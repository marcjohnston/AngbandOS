using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Scare monsters with a 40+level strength.
    /// </summary>
    [Serializable]
    internal class TerrorActivationPower : ActivationPower
    {
        public override int RandomChance => 75;

        public override string PreActivationMessage => ""; // No message is displayed to the player.

        public override int RechargeTime(Player player) => 3 * (player.Level + 10);

        public override bool Activate(Player player, Level level, Item item)
        {
            SaveGame.Instance.SpellEffects.TurnMonsters(40 + player.Level);
            return true;
        }

        public override int Value => 2500;

        public override string Description => "terror every 3 * (level+10) turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustStr;

        public override uint SpecialPowerFlag => ItemFlag2.ResLight;

        public override uint SpecialAbilityFlag => ItemFlag2.FreeAct;
    }
}

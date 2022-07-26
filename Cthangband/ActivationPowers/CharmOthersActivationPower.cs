using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Charm multiple monsters.
    /// </summary>
    [Serializable]
    internal class CharmOthersActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "";

        public override bool Activate(Player player, Level level)
        {
            SaveGame.Instance.SpellEffects.CharmMonsters(player.Level * 2);
            return true;
        }

        public override int RechargeTime(Player player) => 750;

        public override int Value => 17500;

        public override string Description => "mass charm every 750 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustDex;

        public override uint SpecialPowerFlag => ItemFlag2.ResShards;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

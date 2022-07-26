using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Restore all ability drain and lost experience.
    /// </summary>
    [Serializable]
    internal class RestAllActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It glows a deep green...";

        public override bool Activate(Player player, Level level)
        {
            player.TryRestoringAbilityScore(Ability.Strength);
            player.TryRestoringAbilityScore(Ability.Intelligence);
            player.TryRestoringAbilityScore(Ability.Wisdom);
            player.TryRestoringAbilityScore(Ability.Dexterity);
            player.TryRestoringAbilityScore(Ability.Constitution);
            player.TryRestoringAbilityScore(Ability.Charisma);
            player.RestoreLevel();
            return true;
        }

        public override int RechargeTime(Player player) => 750;

        public override int Value => 15000;

        public override string Description => "restore stats and life levels every 750 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResPois;

        public override uint SpecialAbilityFlag => ItemFlag3.Regen;
    }
}

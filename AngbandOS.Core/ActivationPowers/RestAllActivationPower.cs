using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Restore all ability drain and lost experience.
    /// </summary>
    [Serializable]
    internal class RestAllActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It glows a deep green...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.Player.TryRestoringAbilityScore(Ability.Strength);
            saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
            saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
            saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
            saveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
            saveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
            saveGame.Player.RestoreLevel();
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

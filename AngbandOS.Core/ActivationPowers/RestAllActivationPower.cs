namespace AngbandOS.Core.ActivationPowers
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

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
